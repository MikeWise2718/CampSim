using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Aiskwk.Dataframe;

namespace Tests
{
    public class SimpleDfTests
    {
        string [] sdflines =
            {"id,x,y,dt,n",
            "1,1.0,2.0,2019-12-29 16:20:00+00,string1",
            "2,2.0,3.0,2019-12-29 16:21:10+00,string2",
            "3,3.0,4.0,2019-12-29 16:22:20+00,string3"};
        // A Test behaves as an ordinary method
        [Test]
        public void SimpleTest()
        {
            var sdf = new SimpleDf("sdf");
            sdf.preferedType["id"] = SdfColType.dfint;
            sdf.preferedType["dt"] = SdfColType.dfdatetime;
            sdf.preferedFormat["dt"] = "yyyy-MM-dd HH:mm:ss";
            sdf.preferedSubstitute["dt"] = ("+00","");
            sdf.ReadCsv(new List<string>(sdflines));
            Assert.True(sdf.Nrow() == 3);
            Assert.True(sdf.Ncol() == 5);
            Assert.True(sdf.InfoClassStr()=="Classes:id:dfint,x:dfdouble,y:dfdouble,dt:dfdatetime,n:dfstring");
            Assert.True(sdf.GetIntCol("id").Sum()==6);
            Assert.True(sdf.GetDoubleCol("x").Sum()==6);
            Assert.True(sdf.GetDoubleCol("y").Sum() == 9);
            Assert.True(sdf.DataErrors() == 0);
            // Use the Assert class to test conditions
        }


    }
}
