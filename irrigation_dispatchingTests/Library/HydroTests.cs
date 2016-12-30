using Microsoft.VisualStudio.TestTools.UnitTesting;
using irrigation_dispatching.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.Library.Tests
{
    [TestClass()]
    public class HydroTests
    {
        private bool IsListEqual(List<int> a, List<int> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsListEqual(List<double> a, List<double> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }
            for (int i = 0; i < a.Count; i++)
            {
                if (Math.Abs(a[i] - b[i]) > 0.001)
                {
                    return false;
                }
            }
            return true;
        }

        private List<Dictionary<string, double>> InitInflowData()
        {
            List<Dictionary<string, double>> inflow = new List<Dictionary<string, double>>();
            double[] inflowData = { 9.98, 9.91, 9.41, 9.75, 11.5, 11.11, 10.95, 9.98, 10.7, 16.93, 17.92, 33.69, 18.74, 14.1, 19.55, 23.7, 31.92, 70.02, 68.92, 52.79, 114.25, 118.83, 130.01, 71.45, 43.93, 27.28, 20.55, 18.41, 17.85, 17.56, 16, 14.3, 11.39, 11.31, 10.81, 10.98 };
            for (int i = 0; i < inflowData.Length; i++)
            {
                Dictionary<string, double> item = new Dictionary<string, double>()
                {
                    { "average_flow", inflowData[i] }
                };
                inflow.Insert(i, item);
            }
            return inflow;
        }

        private List<int> InitDryEarthData()
        {
            List<int> dryEarth = new List<int>();
            int[] dryEarthData = { 65488, 0, 0, 0, 0, 0, 0, 0, 344209 };
            for (int i = 0; i < dryEarthData.Length; i++)
            {
                dryEarth.Insert(i, dryEarthData[i]);
            }
            return dryEarth;
        }

        private List<Dictionary<string, int>> InitDeptCropAreaData()
        {
            List<Dictionary<string, int>> deptCropArea = new List<Dictionary<string, int>>();
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 1 }, { "area", 6982 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 3 }, { "area", 5318 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 4 }, { "area", 6050 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 5 }, { "area", 885 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 6 }, { "area", 6696 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 7 }, { "area", 50 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 8 }, { "area", 1079 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 9 }, { "area", 39 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 10 }, { "area", 965 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 11 }, { "area", 355 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 12 }, { "area", 90 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 13 }, { "area", 2351 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 14 }, { "area", 1353 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 15 }, { "area", 9850 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 2 }, { "crop_id", 16 }, { "area", 4988 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 1 }, { "area", 12982 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 2 }, { "area", 525 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 3 }, { "area", 8714 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 4 }, { "area", 7783 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 5 }, { "area", 1389 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 6 }, { "area", 10191 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 7 }, { "area", 262 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 8 }, { "area", 944 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 9 }, { "area", 612 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 10 }, { "area", 768 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 11 }, { "area", 839 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 12 }, { "area", 2482 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 13 }, { "area", 4243 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 14 }, { "area", 4505 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 15 }, { "area", 909 } });
            deptCropArea.Add(new Dictionary<string, int>() { { "dept_id", 3 }, { "crop_id", 16 }, { "area", 6777 } });
            return deptCropArea;
        }

        private List<Dictionary<string, int>> InitRoundOrderInfo()
        {
            List<Dictionary<string, int>> roundOrderInfo = new List<Dictionary<string, int>>()
            {
                new Dictionary<string, int>() { { "start_time", 1458835200 }, { "end_time", 1460649600 }, { "qouta", 150 } },
                new Dictionary<string, int>() { { "start_time", 1461772800 }, { "end_time", 1463241600 }, { "qouta", 74 } },
                new Dictionary<string, int>() { { "start_time", 1463328000 }, { "end_time", 1465142400 }, { "qouta", 69 } },
                new Dictionary<string, int>() { { "start_time", 1465228800 }, { "end_time", 1466870400 }, { "qouta", 71 } },
                new Dictionary<string, int>() { { "start_time", 1466956800 }, { "end_time", 1468512000 }, { "qouta", 73 } },
                new Dictionary<string, int>() { { "start_time", 1468598400 }, { "end_time", 1469894400 }, { "qouta", 71 } },
                new Dictionary<string, int>() { { "start_time", 1469980800 }, { "end_time", 1471622400 }, { "qouta", 72 } },
                new Dictionary<string, int>() { { "start_time", 1472313600 }, { "end_time", 1473868800 }, { "qouta", 73 } },
                new Dictionary<string, int>() { { "start_time", 1473955200 }, { "end_time", 1478707200 }, { "qouta", 182 } }
            };
            return roundOrderInfo;
        }

        private List<Dictionary<string, int>> InitIrrigationInstitution()
        {
            List<Dictionary<string, int>> irrigationInstitution = new List<Dictionary<string, int>>()
            {
                new Dictionary<string, int>() { { "round_order", 2 }, { "crop_id", 1 } },
                new Dictionary<string, int>() { { "round_order", 3 }, { "crop_id", 1 } },
                new Dictionary<string, int>() { { "round_order", 4 }, { "crop_id", 1 } },
                new Dictionary<string, int>() { { "round_order", 4 }, { "crop_id", 2 } },
                new Dictionary<string, int>() { { "round_order", 5 }, { "crop_id", 2 } },
                new Dictionary<string, int>() { { "round_order", 5 }, { "crop_id", 3 } },
                new Dictionary<string, int>() { { "round_order", 6 }, { "crop_id", 3 } },
                new Dictionary<string, int>() { { "round_order", 4 }, { "crop_id", 4 } },
                new Dictionary<string, int>() { { "round_order", 5 }, { "crop_id", 4 } },
                new Dictionary<string, int>() { { "round_order", 7 }, { "crop_id", 5 } },
                new Dictionary<string, int>() { { "round_order", 8 }, { "crop_id", 5 } },
                new Dictionary<string, int>() { { "round_order", 6 }, { "crop_id", 6 } },
                new Dictionary<string, int>() { { "round_order", 7 }, { "crop_id", 6 } },
                new Dictionary<string, int>() { { "round_order", 1 }, { "crop_id", 7 } },
                new Dictionary<string, int>() { { "round_order", 2 }, { "crop_id", 7 } },
                new Dictionary<string, int>() { { "round_order", 2 }, { "crop_id", 8 } },
                new Dictionary<string, int>() { { "round_order", 3 }, { "crop_id", 8 } },
                new Dictionary<string, int>() { { "round_order", 4 }, { "crop_id", 9 } },
                new Dictionary<string, int>() { { "round_order", 5 }, { "crop_id", 9 } },
                new Dictionary<string, int>() { { "round_order", 8 }, { "crop_id", 10 } },
                new Dictionary<string, int>() { { "round_order", 9 }, { "crop_id", 10 } },
                new Dictionary<string, int>() { { "round_order", 7 }, { "crop_id", 11 } },
                new Dictionary<string, int>() { { "round_order", 8 }, { "crop_id", 11 } },
                new Dictionary<string, int>() { { "round_order", 5 }, { "crop_id", 12} },
                new Dictionary<string, int>() { { "round_order", 6 }, { "crop_id", 12 } },
                new Dictionary<string, int>() { { "round_order", 3 }, { "crop_id", 13 } },
                new Dictionary<string, int>() { { "round_order", 4 }, { "crop_id", 13 } },
                new Dictionary<string, int>() { { "round_order", 5 }, { "crop_id", 14 } },
                new Dictionary<string, int>() { { "round_order", 6 }, { "crop_id", 14 } },
                new Dictionary<string, int>() { { "round_order", 2 }, { "crop_id", 15 } },
                new Dictionary<string, int>() { { "round_order", 3 }, { "crop_id", 15 } },
                new Dictionary<string, int>() { { "round_order", 1 }, { "crop_id", 16 } }
            };
            return irrigationInstitution;
        }

        private Hydro InitHydro()
        {
            Hydro hydroCalculator = new Hydro(HydroConst.GrossIrrigationConst, HydroConst.AverageWaterSupplyOfCanalHeadConst, HydroConst.WaterRequirementConst, HydroConst.BasicUtilizableCapacity);
            hydroCalculator.Inflow = InitInflowData();
            hydroCalculator.DryEarth = InitDryEarthData();
            hydroCalculator.DeptCropArea = InitDeptCropAreaData();
            hydroCalculator.RoundOrderInfo = InitRoundOrderInfo();
            hydroCalculator.IrrigationInstitution = InitIrrigationInstitution();
            return hydroCalculator;
        }

        [TestMethod()]
        public void CalculateRoundOrderAreaTest()
        {
            Hydro hydroCalculator = InitHydro();
            hydroCalculator.CalculateRoundOrderArea();
            //List<int> testCase = new List<int>() { 19964, 525, 14032, 13833, 2274, 16887, 312, 2023, 651, 1733, 1194, 2572, 6594, 5858, 10759, 11765};
            List<int> testCase = new List<int>() { 77565, 33058, 39340, 41567, 37471, 39349, 20355, 5201, 345942 };
            for (int i = 0; i < hydroCalculator.RoundOrderArea.Count; i++)
            {
                Console.WriteLine(hydroCalculator.RoundOrderArea[i]);
                Console.WriteLine(testCase[i]);
            }
            Assert.IsTrue(IsListEqual(hydroCalculator.RoundOrderArea, testCase));
        }

        [TestMethod()]
        public void CalculateOriginalIrrigationRequirementTest()
        {
            Hydro hydroCalculator = InitHydro();
            hydroCalculator.CalculateRoundOrderArea();
            hydroCalculator.CalculateOriginalIrrigationRequirement();
            List<int> testCase = new List<int>() { 11634750, 2446292, 2714460, 2951257, 2735383, 2793779, 1465560, 379673, 62961444 };
            for (int i = 0; i < hydroCalculator.OriginalIrrigationRequirement.Count; i++)
            {
                Console.WriteLine(hydroCalculator.OriginalIrrigationRequirement[i]);
                Console.WriteLine(testCase[i]);
            }
            Assert.IsTrue(IsListEqual(hydroCalculator.OriginalIrrigationRequirement, testCase));
        }

        [TestMethod()]
        public void CalculateGrossIrrigationRequirementTest()
        {
            Hydro hydroCalculator = InitHydro();
            hydroCalculator.CalculateRoundOrderArea();
            hydroCalculator.CalculateOriginalIrrigationRequirement();
            hydroCalculator.CalculateGrossIrrigationRequirement();
            List<double> testCase = new List<double>() { 11634750, 2446292, 2714460, 2951257, 2735383, 2793779, 1465560, 379673, 62961444 };
            for (int i = 0; i < testCase.Count; i++)
            {
                testCase[i] /= 0.63;
            }
            Assert.IsTrue(IsListEqual(hydroCalculator.GrossIrrigationRequirement, testCase));
        }

        [TestMethod()]
        public void CalculateAverageWaterSupplyOfCanalHeadTest()
        {
            Hydro hydroCalculator = InitHydro();
            hydroCalculator.CalculateRoundOrderArea();
            hydroCalculator.CalculateOriginalIrrigationRequirement();
            hydroCalculator.CalculateGrossIrrigationRequirement();
            hydroCalculator.CalculateAverageWaterSupplyOfCanalHead();
            List<double> testCase = new List<double>() { 11634750, 2446292, 2714460, 2951257, 2735383, 2793779, 1465560, 379673, 62961444 };
            List<double> roundDays = new List<double>() { 21, 17, 21, 19, 18, 15, 19, 18, 55 };
            for (int i = 0; i < testCase.Count; i++)
            {
                testCase[i] = testCase[i] / 0.63 / roundDays[i] / 8.64;
                Console.WriteLine(testCase[i]);
                Console.WriteLine(hydroCalculator.AverageWaterSupplyOfCanalHead[i]);
            }
            Assert.IsTrue(IsListEqual(hydroCalculator.AverageWaterSupplyOfCanalHead, testCase));
        }

        [TestMethod()]
        public void CalculateWaterRequirementTest()
        {
            Hydro hydroCalculator = InitHydro();
            hydroCalculator.CalculateRoundOrderArea();
            hydroCalculator.CalculateOriginalIrrigationRequirement();
            hydroCalculator.CalculateGrossIrrigationRequirement();
            hydroCalculator.CalculateWaterRequirement();
            List<double> testCase = new List<double>() { 11634750, 2446292, 2714460, 2951257, 2735383, 2793779, 1465560, 379673, 62961444 };
            for (int i = 0; i < testCase.Count; i++)
            {
                testCase[i] = testCase[i] / 0.63 / 0.8;
                Console.WriteLine(testCase[i]);
                Console.WriteLine(hydroCalculator.WaterRequirement[i]);
            }
            Assert.IsTrue(IsListEqual(hydroCalculator.WaterRequirement, testCase));
        }

        [TestMethod()]
        public void CalculateAverageFlowTest()
        {
            Hydro hydroCalculator = InitHydro();
            hydroCalculator.CalculateRoundOrderArea();
            hydroCalculator.CalculateOriginalIrrigationRequirement();
            hydroCalculator.CalculateGrossIrrigationRequirement();
            hydroCalculator.CalculateAverageWaterSupplyOfCanalHead();
            hydroCalculator.CalculateAverageFlow();
            List<double> testCase = new List<double>() { 11634750, 2446292, 2714460, 2951257, 2735383, 2793779, 1465560, 379673, 62961444 };
            List<double> roundDays = new List<double>() { 21, 17, 21, 19, 18, 15, 19, 18, 55 };
            for (int i = 0; i < testCase.Count; i++)
            {
                testCase[i] = testCase[i] / 0.63 / roundDays[i] / 8.64 / roundDays[i] / 8.64;
            }
            Assert.IsTrue(IsListEqual(hydroCalculator.AverageFlow, testCase));
        }

        [TestMethod()]
        public void CalculateInflowAveragePredictionTest()
        {
            Hydro hydroCalculator = InitHydro();
            hydroCalculator.CalculateInflowAveragePrediction();
            List<double> testCase = new List<double>() { 119.18, 68.44, 40.82, 83.412, 123.323, 140.645, 248.84, 129.02, 104.01 };
            for (int i = 0; i < testCase.Count; i++)
            {
                testCase[i] = testCase[i] * 8.64 * 10;
                Console.WriteLine(testCase[i]);
                Console.WriteLine(hydroCalculator.InflowAveragePrediction[i]);
            }
            Assert.IsTrue(IsListEqual(testCase, hydroCalculator.InflowAveragePrediction));                      
        }

        [TestMethod()]
        public void CalculateUtilizableCapacityTest()
        {
            Hydro hydroCalculator = InitHydro();
            hydroCalculator.CalculateRoundOrderArea();
            hydroCalculator.CalculateOriginalIrrigationRequirement();
            hydroCalculator.CalculateGrossIrrigationRequirement();
            hydroCalculator.CalculateAverageWaterSupplyOfCanalHead();
            hydroCalculator.CalculateAverageFlow();
            hydroCalculator.CalculateWaterRequirement();
            hydroCalculator.CalculateInflowAveragePrediction();
            hydroCalculator.CalculateUtilizableCapacity();
            List<double> testCase = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < hydroCalculator.InflowAveragePrediction.Count; i++)
            {
                double restWater = (0 == i ? 18956.8062545455 : testCase[i - 1]);
                testCase[i] = restWater + hydroCalculator.InflowAveragePrediction[i] - hydroCalculator.WaterRequirement[i];
            }
            Assert.IsTrue(IsListEqual(testCase, hydroCalculator.UtilizableCapacity));
        }
    }
}