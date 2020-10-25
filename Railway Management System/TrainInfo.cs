using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Management_System
{
    class TrainInfo
    {
        public string TrainId;
        public string TrainName;
        public string TrainType;
        public string TrainNum;
        public string RouteId;
        public string RouteDestination;
        public string RouteName;
        public string Depart;
        public string Arrival;
        public int StationId;
        public string StationType;
        public string StationName;
        public static ArrayList Trains = new ArrayList();
        public static ArrayList Stations = new ArrayList();
        public static ArrayList Route = new ArrayList();
        public static ArrayList Time = new ArrayList();
        public TrainInfo(string TrainId, string TrainName, string TrainType, string TrainNum) // Cunstructor for Train Info
        {
            this.TrainId = TrainId;
            this.TrainName = TrainName;
            this.TrainType = TrainType;
            this.TrainNum = TrainNum;
        }
        public TrainInfo(string RouteId, string RouteName, string RouteDestination) // Constructor for Route Info
        {
            this.RouteId = RouteId;
            this.RouteName = RouteName;
            this.RouteDestination = RouteDestination;
        }
       public TrainInfo(int id, string name, string type)
        {
            this.StationId = id;
            this.StationName = name;
            this.StationType = type;
        }
        public TrainInfo(string Depart, string Arrival)  // Cunstructor for Time Table Info
        {
            this.Depart = Depart;
            this.Arrival = Arrival;
        }
    }
}
