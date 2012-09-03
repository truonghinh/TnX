using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.tn.config
{
    public struct TaskPair
    {
        public int _task;
        public int[] _hesok;
        public TaskPair(int task,int[] hsk)
        {
            _task=task;
            _hesok=hsk;
        }
        public bool ExistHsk(int hsk)
        {
            if (!(_hesok.Length > 0))
            {
                return false;
            }
            foreach (int i in _hesok)
            {
                if (i == hsk)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class TasksPool
    {
        private static List<TaskPair> _pool;
        private static TasksPool _meClass=null;

        private TasksPool()
        {
            _pool = new List<TaskPair>();
            _pool.Add(new TaskPair(TnTasks.tinhThuaMatTienTronThua, new int[] { 3010, 4010, 5010 }));
            _pool.Add(new TaskPair(TnTasks.tinhThuaMatTienHon50m, new int[] { 3011, 4011, 5011 }));
            _pool.Add(new TaskPair(TnTasks.tinhThuaSau50m, new int[] { 3020, 4020, 5020 }));
            _pool.Add(new TaskPair(TnTasks.tinhThuaHc100_200mTronThua, new int[] { 3113, 3123, 3133, 3213, 3223, 3233, 4113, 4123, 4133, 4213, 4223, 4233, 5113, 5123, 5133, 5213, 5223, 5233 }));
            _pool.Add(new TaskPair(TnTasks.tinhThuaHc100_200mKoTtGan100, new int[] { 3114, 3124, 3134, 3214, 3224, 3234, 4114, 4124, 4134, 4214, 4224, 4234, 5114, 5124, 5134, 5214, 5224, 5234 }));
            _pool.Add(new TaskPair(TnTasks.tinhThuaHc100_200mKoTtGan200, new int[] { 3115, 3125, 3135, 3215, 3225, 3235, 4115, 4125, 4135, 4215, 4225, 4235, 5115, 5125, 5135, 5215, 5225, 5235 }));
            
        }

        public static TasksPool CallMe()
        {
            if (_meClass == null)
            {
                _meClass = new TasksPool();
            }
            return _meClass;
        }

        public List<TaskPair> GetPool()
        {
            return _pool;
        }

        public object FindTaskFromHsk(int hsk)
        {
            int len = _pool.Count;
            if (!(len > 0))
            {
                return -1;
            }
            foreach (TaskPair task in _pool)
            {
                if (task.ExistHsk(hsk))
                {
                    return task._task;
                }
            }
            return -1;
        }
    }
}
