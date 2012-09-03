@echo off

gacutil -u DevExpress.Data.v10.2
mkdir %windir%\assembly\GAC_MSIL\DevExpress.Data.v10.2\10.2.3.0__b88d1754d700e49a
copy DevExpress.Data.v10.2.dll %windir%\assembly\GAC_MSIL\DevExpress.Data.v10.2\10.2.3.0__b88d1754d700e49a

gacutil -u DevExpress.Utils.v10.2
mkdir %windir%\assembly\GAC_MSIL\DevExpress.Utils.v10.2\10.2.3.0__b88d1754d700e49a
copy DevExpress.Utils.v10.2.dll %windir%\assembly\GAC_MSIL\DevExpress.Utils.v10.2\10.2.3.0__b88d1754d700e49a

gacutil -u DevExpress.CodeRush.Common
mkdir %windir%\assembly\GAC_MSIL\DevExpress.CodeRush.Common\10.2.3.0__35c9f04b7764aa3d
copy DevExpress.CodeRush.Common.dll %windir%\assembly\GAC_MSIL\DevExpress.CodeRush.Common\10.2.3.0__35c9f04b7764aa3d
copy DevExpress.CodeRush.Common.dll "C:\Program Files\DevExpress 2010.2\IDETools\System\DXCore\BIN\DevExpress.CodeRush.Common.dll"


echo 'OK'
