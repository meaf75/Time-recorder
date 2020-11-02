using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Meaf75.Unity{
    [Serializable]
    public class DateInfo{
        public int date;
        public int timeInSeconds;
    }

    [Serializable]
    public class MonthInfo{
        public int month;
        public List<DateInfo> dates;
    }

    [Serializable]
    public class YearInfo{
        public int year;
        public List<MonthInfo> months;
    }

    [Serializable]
    public class TimeRecorderInfo {
        public List<YearInfo> years;
        /// <summary> Worked time in seconds </summary>
        public long totalRecordedTime;
    }

    [Serializable]
    public class TimeTrackerWindowData{
        /// <summary> This variable cannot be serialized by the JsonUtility </summary>
        public DateTime selectedDate;
        public long selectedDateTicks;

        public TimeTrackerWindowData(){
            selectedDate = DateTime.Now;
        }

        public string GetJson(){
            selectedDateTicks = selectedDate.Ticks;
            return JsonUtility.ToJson(this);
        }
    }

    public static class TimeRecorderExtras{
        public static bool IsDefault(this TimeRecorderInfo timeRecorderInfo){
            return timeRecorderInfo.Equals(default(TimeRecorderInfo));
        }
    }
}

