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
        [TestMethod()]
        public void CalculateRoundOrderAreaTest()
        {
            Hydro hydroCalculator = new Hydro(HydroConst.GrossIrrigationConst, HydroConst.AverageWaterSupplyOfCanalHeadConst, HydroConst.WaterRequirementConst, HydroConst.BasicUtilizableCapacity);

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
            hydroCalculator.Inflow = inflow;

            List<int> dryEarth = new List<int>();
            int[] dryEarthData = { 65488, 0, 0, 0, 0, 0, 0, 0, 344209 };
            for (int i = 0; i < dryEarthData.Length; i++)
            {
                dryEarth.Insert(i, dryEarth[i]);
            }
            hydroCalculator.DryEarth = dryEarth;
        }

        [TestMethod()]
        public void CalculateOriginalIrrigationRequirementTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalculateGrossIrrigationRequirementTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalculateAverageWaterSupplyOfCanalHeadTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalculateWaterRequirementTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalculateAverageFlowTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalculateInflowAveragePredictionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalculateUtilizableCapacityTest()
        {
            Assert.Fail();
        }
    }
}