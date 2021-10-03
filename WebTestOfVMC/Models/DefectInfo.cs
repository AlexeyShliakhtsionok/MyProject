using RailDBProject.Model;
using System;

namespace WebTestOfVMC.Models
{
    public class DefectInfo
    {
        public int DefectId;
        public DateTime DateOfDetection;
        public WaySide WaySide;
        public int Path;
        public string ManufactureYear;
        public double DefectDepth;
        public double DefectLenght;
        public DefectCodes DefectCode;
    }
}
