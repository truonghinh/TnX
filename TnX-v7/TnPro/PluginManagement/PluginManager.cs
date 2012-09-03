//-----------------------------------------------------------------------------
// <copyright file="PluginManager.cs">
//     Copyright (c) 2003 Jason Clark.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Reflection; 
using System.Runtime.Remoting;
using System.Security;
using System.Security.Policy;
using System.Text;

namespace TNPro.PluginManagement{

[Serializable]
public enum PluginTrustLevel{
   Full = 1,
   Semi
}

[Serializable]
public enum PluginCriteria{
   Interface = 1,
   BaseClass,
   CustomAttribute
}

public sealed class PluginManager:MarshalByRefObject{

   static String fullTrustPath;
   static String semiTrustPath;
   static Boolean supportSecurePlugins;

   // Path for full trust plugins
   public static String FullTrustPath{
      get{return fullTrustPath;} 
      set{fullTrustPath = value;}
   }

   // Path for partial trust plugins
   public static String SemiTrustPath{
      get{return semiTrustPath;} 
      set{
         String path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, value);      
         if((value != String.Empty)&&MakeSecurePath(path)){
            semiTrustPath = value;
            supportSecurePlugins=true;
         }else{
            supportSecurePlugins=false;
         }
      }
   }

   // Avoids instantiation by users of the class
   // also used to create an instance for cross-domain functions
   private PluginManager(){}

   // Setup default values for plugin paths
   static PluginManager(){
      fullTrustPath = @"Plugins\FullTrust";
      supportSecurePlugins=false;
      semiTrustPath = String.Empty;            
   }
   
   // Get an array of plugin types using a 
   // plugin criteria and trust level
   public static Type[] LoadPluginTypes(
      PluginTrustLevel level, PluginCriteria criteria, Type criteriaType){
      // Build the path for plugins we are searching for
      // also, if secure plugins won't work, throw
      String pluginPath;
      if(level == PluginTrustLevel.Full){
         pluginPath = fullTrustPath;
      }else{
         if(!supportSecurePlugins){
            throw new SecurityException(
               "Semi-trusted plugins were not enabled!");
         }
         pluginPath = semiTrustPath;
      }

      // Create a temporary app domain so that we can unload assemblies
      AppDomain domain = 
         AppDomain.CreateDomain("TempDom"+Guid.NewGuid().ToString());

      // Find the name of this assembly and load it into the domain
      String assemblyName = Assembly.GetExecutingAssembly().FullName;
      domain.Load(assemblyName);

      // Create an instance of the PluginManager type 
      // in the temporary domain
      BindingFlags binding = BindingFlags.CreateInstance | 
         BindingFlags.NonPublic | BindingFlags.Instance;
      ObjectHandle handle = domain.CreateInstance(
         assemblyName, typeof(PluginManager).ToString(), false, 
         binding, null, null, null, null, null);
      PluginManager helper = (PluginManager)handle.Unwrap();  
      
      try{
         // Get an array of assemblies that include matching plugins
         String[] assemblies= helper.DiscoverPluginAssembliesHelper(
            pluginPath, criteria, criteriaType);            
         // return loaded plugin types
         return LoadPluginTypesHelper(assemblies, criteria, criteriaType);
      }catch(ReflectionTypeLoadException){
         return new Type[0];
      }finally{
         // Unload any unwanted assemblies
         AppDomain.Unload(domain);            
      }
   }

   static Boolean MakeSecurePath(String path){
      Boolean secure = false;
      try{
         // Create an Url from the path
         String url = MakePathUrl(path);
         // Get machine policy level
         PolicyLevel level = FindMachinePolicy();
         // Make sure we recognize the root code group
         CodeGroup root = level.RootCodeGroup;
         AllMembershipCondition test = 
            (AllMembershipCondition)root.MembershipCondition;         
         if(!FindPluginCodeGroup(root, url)){
            MakePluginCodeGroup(level, root, url);
         }         
         secure = true;
      }catch(InvalidCastException){}
      return secure;
   }

   static Boolean FindPluginCodeGroup(CodeGroup root, String url){
      Boolean ret = false;
      // Get children
      IList children = root.Children;
      // Get name to test against
      String matchName = GenerateCodeGroupName(url);
      // Check-um all
      foreach(CodeGroup child in children){
         if(child.Name == matchName){
            ret = true;
            break;
         }
      }
      return ret;
   }

   static void MakePluginCodeGroup(PolicyLevel level, CodeGroup root, String url){
      // Create a membership condition for our path
      IMembershipCondition membership = 
         new UrlMembershipCondition(url);
      // Get the internet permissiion set
      PermissionSet permissions = 
         level.GetNamedPermissionSet("Internet");
      permissions.GetType(); // Again, no nulls allowed
      // Create a policy statement from the permissions and condition
      PolicyStatement statement = new PolicyStatement(permissions, 
         PolicyStatementAttribute.Exclusive | 
         PolicyStatementAttribute.LevelFinal);
      // New code group
      UnionCodeGroup group = new UnionCodeGroup(membership, statement);
      group.Description=String.Format(
         "Code group that restricts permissions on "+
         "assemblies in {0}, to support secure loading of plugins. "+
         "This group was added by application: {1}", url,
         Assembly.GetEntryAssembly().CodeBase);      
      group.Name = GenerateCodeGroupName(url);
      root.AddChild(group);
      SecurityManager.SavePolicyLevel(level);
   }

   // What is the name of our code group?
   static String GenerateCodeGroupName(String url){
      String appName = Assembly.GetEntryAssembly().GetName().Name;
      return String.Format("{0}-{1}", appName, url);
   }

   // Get machine policy
   static PolicyLevel FindMachinePolicy(){      
      PolicyLevel ret = null;
      // Get the policy hierarchy
      IEnumerator en = SecurityManager.PolicyHierarchy();
      en.Reset();
      // Find the policy named "Machine"
      while(en.MoveNext()){
         PolicyLevel level = (PolicyLevel) en.Current;         
         if(level.Label == "Machine"){
            ret = level;
            break;
         }
      }
      return ret;
   }

   // Add a path to "file://" and move any back-slashes forward
   static String MakePathUrl(String path){
      StringBuilder builder = new StringBuilder("file://");
      builder.Append(path);
      for(Int32 index=0, end=builder.Length; index<end; index++){
         if(builder[index] == '\\')
            builder[index] = '/';
      }
      if(builder[builder.Length-1] != '/'){
         builder.Append("/*");
      }else{
         builder.Append("*");
      }      
      return builder.ToString().ToLower();
   }

   // From an array of assemblies find the plugin types
   static private Type[] LoadPluginTypesHelper(
      String[] assemblies, PluginCriteria criteria, Type criteriaType){                  
      
      ArrayList typesIncluded = new ArrayList();
      foreach(String s in assemblies){
         // Load the assembly         
         Assembly assembly = Assembly.LoadFrom(s);
         // Find the plugin types
         Type[] types = assembly.GetExportedTypes();         
         foreach(Type t in types){
            if(IncludeType(t, criteria, criteriaType)){
               typesIncluded.Add(t);               
            }
         }         
      }      
      // Return an array of types
      return (Type[])typesIncluded.ToArray(typeof(Type));
   }

   private String[] DiscoverPluginAssembliesHelper(
      String path, PluginCriteria criteria, Type criteriaType){                  
      String[] assemblies;
      // Get .dll names
      path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);      
      assemblies = Directory.GetFiles(path, "*.dll");      
      if(assemblies.Length != 0){

         ArrayList assembliesIncluded = new ArrayList();
         foreach(String s in assemblies){
            // Load the assembly
            Assembly assembly = Assembly.LoadFrom(s);
            // Find matching type?
            Type[] types = assembly.GetTypes();         
            foreach(Type t in types){
               if(IncludeType(t, criteria, criteriaType)){
                  assembliesIncluded.Add(s);               
                  break; // match found, move on
               }
            }         
         }
         // Get array of matching assemblies
         assemblies = (String[])assembliesIncluded.ToArray(
            typeof(String));      
      }
      return assemblies;
   }

   // Test a type for matching the plugin criteria
   private static Boolean IncludeType(
      Type type, PluginCriteria criteria, Type criteriaType){
      Boolean judgement = false;
      
      // Switch on criteria type
      switch(criteria){ 
      case PluginCriteria.Interface: // interface
         if(!criteriaType.IsInterface){
            throw new ArgumentException(
               "Criteria does not match criteria type."); 
         }
         // If compatible with the interface type, thumbs-up
         judgement = criteriaType.IsAssignableFrom(type);                     
         break;
      case PluginCriteria.BaseClass:
         if(!(criteriaType.IsClass && !criteriaType.IsSealed)){
            throw new ArgumentException(
               "Criteria does not match criteria type."); 
         }
         // If compatible with the base type, thumbs-up
         judgement = criteriaType.IsAssignableFrom(type);            
         break;            
      case PluginCriteria.CustomAttribute:
         if(!typeof(Attribute).IsAssignableFrom(criteriaType)){
            throw new ArgumentException(
               "Criteria does not match criteria type.");
         }
         // If the attribute is defined on the type, then true
         judgement = type.IsDefined(criteriaType, true);
         break;
      default:
         throw new ArgumentException("Invalid plugin criteria.");
      }
      
      return judgement;
   }

   public static Object CreateInstance(Type type, Object[] args){
      try{
         // Calls through reflection mask exceptions in a 
         // TargetInvocationException, which is annoying.
         // Un-mask by rethrowing the inner exception
         return Activator.CreateInstance(type, args); 
      }catch(TargetInvocationException e){
         throw e.InnerException;
      }
   }

   public static Object CreateInstance(Type type){
      return CreateInstance(type, null);
   }
}
}