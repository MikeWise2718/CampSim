using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;  // just for mathf and vector3?
using CampusSimulator;
using Aiskwk.Map;

namespace GraphAlgos
{
    public class LcMapData
    {
        GraphCtrl grc;
        LcMapMaker lmm;
        public LcMapData(LcMapMaker lmm, GraphCtrl grc)
        {
            this.grc = grc;
            this.lmm = lmm;
        }
 

        // computer generated

        public void createPointsFor_eb12_resident()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("eb12-resident", "blue", saveToFile: true);
            grc.AddNodePtxyz("eb12-dw03", 0.000, 0.000, 4.000, comment: "driveway start"); //  1 nn:1 nl:0
            grc.AddLinkByNodeName("eb12-dw03", "reg:eb12-streets", LinkUse.driveway); //  2 nn:0 nl:1
            grc.LinkToPtxyz("eb12-dw03", "eb12-dw02", 6.600, 0.000, -1.000, LinkUse.driveway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("eb12-dw02", "eb12-dw01", 31.400, 0.000, -1.000, LinkUse.driveway, comment: ""); //  4 nn:1 nl:1
            grc.LinkToPtxyz("eb12-dw01", "eb12-oso04", 33.000, 0.000, 1.000, LinkUse.walkway, comment: "walkway start"); //  5 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso04", "eb12-oso03", 33.000, 0.000, 7.000, LinkUse.walkway, comment: ""); //  6 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso03", "eb12-oso02", 31.000, 0.000, 10.000, LinkUse.walkway, comment: ""); //  7 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso02", "eb12-oso01", 31.000, 0.000, 23.500, LinkUse.walkway, comment: ""); //  8 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso01", "eb12-oso14", 23.600, 0.000, 23.500, LinkUse.walkway, comment: ""); //  9 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso14", "eb12-oso12", 19.000, 0.000, 23.500, LinkUse.walkway, comment: ""); //  10 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso12", "eb12-oso10", 12.500, 0.000, 23.500, LinkUse.walkway, comment: ""); //  11 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso10", "eb12-oso08", 8.000, 0.000, 23.500, LinkUse.walkway, comment: ""); //  12 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso01", "eb12-oso1a", 29.000, 0.000, 21.200, LinkUse.walkway, comment: "place for Arnie"); //  13 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso14", "eb12-14-lob", 23.600, 0.000, 28.000, LinkUse.walkway, comment: ""); //  14 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso12", "eb12-12-lob", 19.000, 0.000, 28.000, LinkUse.walkway, comment: ""); //  15 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso10", "eb12-10-lob", 12.500, 0.000, 28.000, LinkUse.walkway, comment: ""); //  16 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso08", "eb12-08-lob", 8.000, 0.000, 28.000, LinkUse.walkway, comment: ""); //  17 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso01", "eb12-oso16", 30.000, 0.000, 28.000, LinkUse.walkway, comment: ""); //  18 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso16", "eb12-16-lob", 30.000, 0.000, 30.800, LinkUse.walkway, comment: ""); //  19 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso01", "eb12-oso18", 34.400, 0.000, 28.000, LinkUse.walkway, comment: ""); //  20 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso18", "eb12-18-lob", 34.400, 0.000, 30.800, LinkUse.walkway, comment: ""); //  21 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso01", "eb12-oso20", 41.000, 0.000, 28.000, LinkUse.walkway, comment: ""); //  22 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso20", "eb12-20-lob", 41.000, 0.000, 30.800, LinkUse.walkway, comment: ""); //  23 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso01", "eb12-oso22", 45.600, 0.000, 28.000, LinkUse.walkway, comment: ""); //  24 nn:1 nl:1
            grc.LinkToPtxyz("eb12-oso22", "eb12-22-lob", 45.600, 0.000, 30.800, LinkUse.walkway, comment: ""); //  25 nn:1 nl:1
            grc.AddNodePtxyz("eb12-el-l01", 0.000, 0.000, 0.000, comment: "elecpipe start"); //  26 nn:1 nl:0
            grc.LinkToPtxyz("eb12-el-l01", "eb12-el-l02", 0.000, 0.000, 22.200, LinkUse.elecpipe, comment: ""); //  27 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-l02", "eb12-el-o08a", 8.500, 0.000, 22.200, LinkUse.elecpipe, comment: ""); //  28 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o08a", "eb12-el-o10a", 13.000, 0.000, 22.200, LinkUse.elecpipe, comment: ""); //  29 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o10a", "eb12-el-lp03a", 15.840, 0.000, 22.200, LinkUse.elecpipe, comment: ""); //  30 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-lp03a", "eb12-el-o12a", 19.500, 0.000, 22.200, LinkUse.elecpipe, comment: ""); //  31 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o12a", "eb12-el-o14a", 24.100, 0.000, 22.200, LinkUse.elecpipe, comment: ""); //  32 nn:1 nl:1
            grc.AddLinkByNodeName("eb12-el-o14a", "eb12-el-o14a", LinkUse.elecpipe); //  33 nn:0 nl:1
            grc.LinkToPtxyz("eb12-el-o14a", "eb12-el-l04", 30.500, 0.000, 22.200, LinkUse.elecpipe, comment: ""); //  34 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-l04", "eb12-el-o16a", 30.500, 0.000, 25.220, LinkUse.elecpipe, comment: ""); //  35 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o16a", "eb12-el-o18a", 34.900, 0.000, 25.220, LinkUse.elecpipe, comment: ""); //  36 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o18a", "eb12-el-lp04a", 38.000, 0.000, 25.220, LinkUse.elecpipe, comment: ""); //  37 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-lp04a", "eb12-el-o20a", 41.500, 0.000, 25.220, LinkUse.elecpipe, comment: ""); //  38 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o20a", "eb12-el-o22a", 46.100, 0.000, 25.220, LinkUse.elecpipe, comment: ""); //  39 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o08a", "eb12-el-o08b", 8.500, 0.000, 28.000, LinkUse.elecpipe, comment: ""); //  40 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o10a", "eb12-el-o10b", 13.000, 0.000, 28.000, LinkUse.elecpipe, comment: ""); //  41 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o12a", "eb12-el-o12b", 19.500, 0.000, 28.000, LinkUse.elecpipe, comment: ""); //  42 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o14a", "eb12-el-o14b", 24.100, 0.000, 28.000, LinkUse.elecpipe, comment: ""); //  43 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o16a", "eb12-el-o16b", 30.500, 0.000, 30.800, LinkUse.elecpipe, comment: ""); //  44 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o18a", "eb12-el-o18b", 34.900, 0.000, 30.800, LinkUse.elecpipe, comment: ""); //  45 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o20a", "eb12-el-o20b", 41.500, 0.000, 30.800, LinkUse.elecpipe, comment: ""); //  46 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-o22a", "eb12-el-o22b", 46.100, 0.000, 30.800, LinkUse.elecpipe, comment: ""); //  47 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-lp03a", "eb12-el-lp03b", 15.840, 0.000, 21.280, LinkUse.elecpipe, comment: ""); //  48 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-lp04a", "eb12-el-lp04b", 38.000, 0.000, 23.700, LinkUse.elecpipe, comment: ""); //  49 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-l02", "eb12-el-l03", -1.000, 0.000, 56.000, LinkUse.elecpipe, comment: ""); //  50 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-l04", "eb12-el-l05", 32.000, 0.000, 22.200, LinkUse.elecpipe, comment: ""); //  51 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-l05", "eb12-el-lp05a", 32.000, 0.000, 11.380, LinkUse.elecpipe, comment: ""); //  52 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-lp05a", "eb12-el-l06", 32.860, 0.000, -4.200, LinkUse.elecpipe, comment: ""); //  53 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-l06", "eb12-el-hl06", 32.860, 2.700, -4.200, LinkUse.elecpipe, comment: ""); //  54 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06", "eb12-el-hl06-1", 30.675, 2.700, -4.200, LinkUse.elecpipe, comment: ""); //  55 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-1", "eb12-el-hl06-2", 27.750, 2.700, -4.200, LinkUse.elecpipe, comment: ""); //  56 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-2", "eb12-el-hl06-3", 24.825, 2.700, -4.200, LinkUse.elecpipe, comment: ""); //  57 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-3", "eb12-el-hl06-4", 21.900, 2.700, -4.200, LinkUse.elecpipe, comment: ""); //  58 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-4", "eb12-el-hl06-5", 18.975, 2.700, -4.200, LinkUse.elecpipe, comment: ""); //  59 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-5", "eb12-el-hl06-6", 16.050, 2.700, -4.200, LinkUse.elecpipe, comment: ""); //  60 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-6", "eb12-el-hl06-7", 13.125, 2.700, -4.200, LinkUse.elecpipe, comment: ""); //  61 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-7", "eb12-el-hl08", 10.000, 2.700, -4.200, LinkUse.elecpipe, comment: ""); //  62 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-1", "eb12-el-hl06-1a", 30.675, 2.700, -4.600, LinkUse.elecpipe, comment: ""); //  63 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-1a", "eb12-el-hl06-1b", 30.675, 1.500, -4.600, LinkUse.elecpipe, comment: ""); //  64 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-2", "eb12-el-hl06-2a", 27.750, 2.700, -4.600, LinkUse.elecpipe, comment: ""); //  65 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-2a", "eb12-el-hl06-2b", 27.750, 1.500, -4.600, LinkUse.elecpipe, comment: ""); //  66 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-3", "eb12-el-hl06-3a", 24.825, 2.700, -4.600, LinkUse.elecpipe, comment: ""); //  67 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-3a", "eb12-el-hl06-3b", 24.825, 1.500, -4.600, LinkUse.elecpipe, comment: ""); //  68 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-4", "eb12-el-hl06-4a", 21.900, 2.700, -4.600, LinkUse.elecpipe, comment: ""); //  69 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-4a", "eb12-el-hl06-4b", 21.900, 1.500, -4.600, LinkUse.elecpipe, comment: ""); //  70 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-5", "eb12-el-hl06-5a", 18.975, 2.700, -4.600, LinkUse.elecpipe, comment: ""); //  71 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-5a", "eb12-el-hl06-5b", 18.975, 1.500, -4.600, LinkUse.elecpipe, comment: ""); //  72 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-6", "eb12-el-hl06-6a", 16.050, 2.700, -4.600, LinkUse.elecpipe, comment: ""); //  73 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-6a", "eb12-el-hl06-6b", 16.050, 1.500, -4.600, LinkUse.elecpipe, comment: ""); //  74 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-7", "eb12-el-hl06-7a", 13.125, 2.700, -4.600, LinkUse.elecpipe, comment: ""); //  75 nn:1 nl:1
            grc.LinkToPtxyz("eb12-el-hl06-7a", "eb12-el-hl06-7b", 13.125, 1.500, -4.600, LinkUse.elecpipe, comment: ""); //  76 nn:1 nl:1
            grc.AddNodePtxyz("eb12-wt-l00", -2.680, 0.000, -15.000, comment: "waterpipe start"); //  77 nn:1 nl:0
            grc.LinkToPtxyz("eb12-wt-l00", "eb12-wt-l01", -3.270, 0.000, 4.190, LinkUse.waterpipe, comment: ""); //  78 nn:1 nl:1
            grc.LinkToPtxyz("eb12-wt-l01", "eb12-wt-l02", -1.550, 0.000, 22.700, LinkUse.waterpipe, comment: ""); //  79 nn:1 nl:1
            grc.LinkToPtxyz("eb12-wt-l02", "eb12-wt-l03", -4.340, 0.000, 47.500, LinkUse.waterpipe, comment: ""); //  80 nn:1 nl:1
            grc.LinkToPtxyz("eb12-wt-l01", "eb12-wt-l01-01", 33.000, 0.000, 4.190, LinkUse.waterpipe, comment: ""); //  81 nn:1 nl:1
            grc.LinkToPtxyz("eb12-wt-l01-01", "eb12-wt-l01-02", 44.000, 0.000, 4.190, LinkUse.waterpipe, comment: ""); //  82 nn:1 nl:1
            grc.LinkToPtxyz("eb12-wt-l02", "eb12-wt-l02-01", 15.000, 0.000, 22.700, LinkUse.waterpipe, comment: ""); //  83 nn:1 nl:1
            grc.LinkToPtxyz("eb12-wt-l02-01", "eb12-wt-l02-02", 25.000, 0.000, 22.700, LinkUse.waterpipe, comment: ""); //  84 nn:1 nl:1
            grc.regman.SetRegion("default");
        }


        public void createPointsFor_eb12_retail()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("eb12-retail", "blue", saveToFile: true);
            grc.AddNodePtxyz("eb12-rw01", 237.000, 0.000, 169.000, comment: "driveway start"); //  1 nn:1 nl:0
            grc.LinkToPtxyz("eb12-rw01", "eb12-rw02", 247.000, 0.000, 109.000, LinkUse.driveway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("eb12-rw02", "eb12-rw03", 270.000, 0.000, 112.000, LinkUse.driveway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("eb12-rw03", "eb12-rw04", 257.000, 0.000, 153.000, LinkUse.driveway, comment: ""); //  4 nn:1 nl:1
            grc.LinkToPtxyz("eb12-rw04", "eb12-rw05", 254.000, 0.000, 172.000, LinkUse.driveway, comment: ""); //  5 nn:1 nl:1
            grc.AddLinkByNodeName("eb12-rw05", "eb12-rw01", LinkUse.driveway); //  6 nn:0 nl:1
            grc.LinkToPtxyz("eb12-rw04", "eb12-rewe-lob", 262.000, 0.000, 156.000, LinkUse.walkway, comment: "walkway start"); //  7 nn:1 nl:1
            grc.LinkToPtxyz("eb12-rewe-lob", "eb12-rewe-rm01", 275.000, 0.000, 170.000, LinkUse.walkway, comment: ""); //  8 nn:1 nl:1
            grc.LinkToPtxyz("eb12-rewe-lob", "eb12-rewe-rm02", 283.000, 0.000, 156.000, LinkUse.walkway, comment: ""); //  9 nn:1 nl:1
            grc.LinkToPtxyz("eb12-rw04", "eb12-rewe-os21", 243.000, 0.000, 150.000, LinkUse.walkway, comment: ""); //  10 nn:1 nl:1
            grc.AddLinkByNodeName("eb12-rewe-rm01", "eb12-rewe-rm02", LinkUse.walkway); //  11 nn:0 nl:1
            grc.AddLinkByNodeName("eb12-rw01", "reg:eb12-streets", LinkUse.driveway); //  12 nn:0 nl:1
            grc.AddLinkByNodeName("eb12-rw03", "reg:eb12-streets", LinkUse.driveway); //  
            grc.AddLinkByNodeName("eb12-rw03", "g_rewe_1-dt-dps01", LinkUse.driveway); // 
            grc.regman.SetRegion("default");
        }



        public void CreateGraphForOsmImport_Eb12small()  // machine generated on 2020-06-30 18:20:43.198403 local time  - do not edit
        {
            grc.regman.NewNodeRegion("EB12 Area", "blue", saveToFile: true);
            var xs = 0;  // offsets for error correction
            var zs = 0;
            grc.AddNodePtxz("osm33702042", 130.814 + xs, 284.477 + zs);
            grc.AddNodePtxz("osm738283752", 124.605 + xs, 284.326 + zs);
            grc.AddNodePtxz("osm5457326852", 110.423 + xs, 284.070 + zs);
            grc.AddNodePtxz("osm33702932", 21.873 + xs, 282.462 + zs);
            grc.AddNodePtxz("osm1347958012", 9.142 + xs, 281.016 + zs);
            grc.AddNodePtxz("osm5467434859", 5.950 + xs, 280.500 + zs);
            grc.AddNodePtxz("osm3662353680", 1.610 + xs, 279.797 + zs);
            grc.AddNodePtxz("osm3666468611", -4.437 + xs, 278.181 + zs);
            grc.AddNodePtxz("osm473651436", -7.872 + xs, 277.260 + zs);
            grc.AddNodePtxz("osm3662352895", -15.637 + xs, 273.938 + zs);
            grc.AddNodePtxz("osm3662352894", -24.191 + xs, 269.280 + zs);
            grc.AddNodePtxz("osm33702933", -31.596 + xs, 263.367 + zs);
            grc.AddNodePtxz("osm3662352893", -40.638 + xs, 254.525 + zs);
            grc.AddNodePtxz("osm3662352892", -47.382 + xs, 245.920 + zs);
            grc.AddNodePtxz("osm33702934", -50.923 + xs, 238.541 + zs);
            grc.AddNodePtxz("osm473651438", -51.876 + xs, 232.535 + zs);
            grc.AddNodePtxz("osm3662352891", -51.831 + xs, 224.597 + zs);
            grc.AddNodePtxz("osm33702935", -50.161 + xs, 215.302 + zs);
            grc.AddNodePtxz("osm5474088800", -46.508 + xs, 201.817 + zs);
            grc.AddNodePtxz("osm3666466781", -46.229 + xs, 200.781 + zs);
            grc.AddNodePtxz("osm5474088796", -36.058 + xs, 163.163 + zs);
            grc.AddNodePtxz("osm5467434854", -34.643 + xs, 157.952 + zs);
            grc.AddNodePtxz("osm33702925", -23.102 + xs, 115.297 + zs);
            grc.AddNodePtxz("osm248731300", 486.785 + xs, 689.415 + zs);
            grc.AddNodePtxz("osm738281714", 482.976 + xs, 675.254 + zs);
            grc.AddNodePtxz("osm6373715031", 467.601 + xs, 618.183 + zs);
            grc.AddNodePtxz("osm3666999699", 460.006 + xs, 587.372 + zs);
            grc.AddNodePtxz("osm243312270", 452.050 + xs, 548.475 + zs);
            grc.AddNodePtxz("osm2769223913", 448.763 + xs, 530.137 + zs);
            grc.AddNodePtxz("osm3666999698", 441.305 + xs, 490.564 + zs);
            grc.AddNodePtxz("osm243312208", 434.233 + xs, 459.484 + zs);
            grc.AddNodePtxz("osm2769223901", 425.987 + xs, 425.026 + zs);
            grc.AddNodePtxz("osm243312276", 418.358 + xs, 403.073 + zs);
            grc.AddNodePtxz("osm2769404079", 409.477 + xs, 384.859 + zs);
            grc.AddNodePtxz("osm243312283", 392.679 + xs, 351.386 + zs);
            grc.AddNodePtxz("osm2769404063", 369.810 + xs, 312.880 + zs);
            grc.AddNodePtxz("osm243312291", 347.719 + xs, 280.766 + zs);
            grc.AddNodePtxz("osm2769404025", 325.084 + xs, 252.452 + zs);
            grc.AddNodePtxz("osm6373714855", 311.282 + xs, 238.097 + zs);
            grc.AddNodePtxz("osm243312239", 296.634 + xs, 222.860 + zs);
            grc.AddNodePtxz("osm3666040458", 286.466 + xs, 214.495 + zs);
            grc.AddNodePtxz("osm5443078096", 280.256 + xs, 209.644 + zs);
            grc.AddNodePtxz("osm243312210", 276.705 + xs, 206.874 + zs);
            grc.AddNodePtxz("osm3666040648", 267.884 + xs, 200.966 + zs);
            grc.AddNodePtxz("osm3666040647", 256.509 + xs, 195.042 + zs);
            grc.AddNodePtxz("osm3666040645", 244.601 + xs, 189.846 + zs);
            grc.AddNodePtxz("osm33702006", 150.972 + xs, 72.428 + zs);
            grc.AddNodePtxz("osm2245330472", 194.656 + xs, 79.330 + zs);
            grc.AddNodePtxz("osm2697503323", 240.174 + xs, 87.484 + zs);
            grc.AddNodePtxz("osm5455174268", 271.324 + xs, 92.553 + zs);
            grc.AddNodePtxz("osm243312298", 276.024 + xs, 93.321 + zs);
            grc.AddNodePtxz("osm33702008", 161.524 + xs, 15.423 + zs);
            grc.AddNodePtxz("osm3662352904", 163.727 + xs, 6.561 + zs);
            grc.AddNodePtxz("osm3662353689", 166.267 + xs, -3.066 + zs);
            grc.AddNodePtxz("osm456054460", 170.455 + xs, -14.782 + zs);
            grc.AddNodePtxz("osm2761659548", 172.311 + xs, -17.552 + zs);
            grc.AddNodePtxz("osm33701942", 322.411 + xs, 22.504 + zs);
            grc.AddNodePtxz("osm2347271301", 313.426 + xs, 9.692 + zs);
            grc.AddNodePtxz("osm3662352910", 308.679 + xs, 3.463 + zs);
            grc.AddNodePtxz("osm33701943", 302.364 + xs, -2.203 + zs);
            grc.AddNodePtxz("osm3662353589", 297.083 + xs, -6.157 + zs);
            grc.AddNodePtxz("osm3662353587", 291.907 + xs, -9.101 + zs);
            grc.AddNodePtxz("osm266520730", 285.802 + xs, -11.411 + zs);
            grc.AddNodePtxz("osm33482004", 259.038 + xs, -20.358 + zs);
            grc.AddNodePtxz("osm33702044", 146.845 + xs, 96.352 + zs);
            grc.AddNodePtxz("osm5891568362", 139.939 + xs, 95.883 + zs);
            grc.AddNodePtxz("osm434631893", -5.761 + xs, 60.671 + zs);
            grc.AddNodePtxz("osm434631896", -4.528 + xs, 12.113 + zs);
            grc.AddNodePtxz("osm3662352902", 137.422 + xs, 173.585 + zs);
            grc.AddNodePtxz("osm3666040550", 139.229 + xs, 153.635 + zs);
            grc.AddNodePtxz("osm1106475589", 168.626 + xs, 225.164 + zs);
            grc.AddNodePtxz("osm1881642037", 141.643 + xs, 224.519 + zs);
            grc.AddNodePtxz("osm243312243", 171.555 + xs, 183.541 + zs);
            grc.AddNodePtxz("osm2245330484", 225.533 + xs, 185.353 + zs);
            grc.AddNodePtxz("osm1587776905", 362.490 + xs, 123.362 + zs);
            grc.AddNodePtxz("osm6638749507", 351.553 + xs, 97.401 + zs);
            grc.AddNodePtxz("osm2347271303", 315.723 + xs, 2.618 + zs);
            grc.AddNodePtxz("osm2347271302", 310.590 + xs, -18.036 + zs);
            grc.AddNodePtxz("osm3662352908", 305.212 + xs, -43.411 + zs);
            grc.AddNodePtxz("osm33702434", 299.509 + xs, -73.589 + zs);
            grc.AddNodePtxz("osm616247", 405.339 + xs, -146.452 + zs);
            grc.AddNodePtxz("osm2347271310", 405.854 + xs, -117.270 + zs);
            grc.AddNodePtxz("osm6638749506", 405.090 + xs, -107.983 + zs);
            grc.AddNodePtxz("osm33482006", 403.617 + xs, -98.787 + zs);
            grc.AddNodePtxz("osm3662353711", 401.599 + xs, -91.625 + zs);
            grc.AddNodePtxz("osm33701937", 398.839 + xs, -83.791 + zs);
            grc.AddNodePtxz("osm3662353710", 394.465 + xs, -74.239 + zs);
            grc.AddNodePtxz("osm1881642050", 389.371 + xs, -65.790 + zs);
            grc.AddNodePtxz("osm3662353708", 384.255 + xs, -59.031 + zs);
            grc.AddNodePtxz("osm33702330", 378.047 + xs, -51.931 + zs);
            grc.AddNodePtxz("osm33701936", 363.298 + xs, -40.668 + zs);
            grc.AddNodePtxz("osm2347271307", 342.782 + xs, -27.085 + zs);
            grc.AddNodePtxz("osm2347271306", 333.731 + xs, -18.701 + zs);
            grc.AddNodePtxz("osm33701950", 329.728 + xs, -11.974 + zs);
            grc.AddNodePtxz("osm33701935", 327.699 + xs, -4.101 + zs);
            grc.AddNodePtxz("osm3662353700", 326.435 + xs, 2.783 + zs);
            grc.AddNodePtxz("osm33701944", 326.158 + xs, 12.610 + zs);
            grc.AddNodePtxz("osm456054459", 48.616 + xs, 94.216 + zs);
            grc.AddNodePtxz("osm3666040363", 45.134 + xs, 93.876 + zs);
            grc.AddNodePtxz("osm434631885", 42.430 + xs, 93.069 + zs);
            grc.AddNodePtxz("osm3666040353", 38.901 + xs, 90.601 + zs);
            grc.AddNodePtxz("osm3666040300", 27.120 + xs, 79.519 + zs);
            grc.AddNodePtxz("osm3662353685", 25.588 + xs, 76.718 + zs);
            grc.AddNodePtxz("osm3666040294", 25.854 + xs, 73.048 + zs);
            grc.AddNodePtxz("osm3662353686", 27.188 + xs, 66.435 + zs);
            grc.AddNodePtxz("osm434631889", 26.665 + xs, 63.934 + zs);
            grc.AddNodePtxz("osm3666040217", 25.226 + xs, 62.520 + zs);
            grc.AddNodePtxz("osm3662353683", 23.148 + xs, 61.730 + zs);
            grc.AddNodePtxz("osm2245330467", 148.050 + xs, 88.510 + zs);
            grc.AddNodePtxz("osm738283754", 130.054 + xs, 183.449 + zs);
            grc.AddNodePtxz("osm5457326850", 116.406 + xs, 183.339 + zs);
            grc.AddNodePtxz("osm3665957604", 65.760 + xs, 182.940 + zs);
            grc.AddNodePtxz("osm3665957603", 61.431 + xs, 182.427 + zs);
            grc.AddNodePtxz("osm33702924", 57.369 + xs, 180.703 + zs);
            grc.AddNodePtxz("osm5548868468", 45.344 + xs, 170.928 + zs);
            grc.AddNodePtxz("osm3665957584", -98.050 + xs, 114.464 + zs);
            grc.AddNodePtxz("osm33702899", -105.907 + xs, 115.074 + zs);
            grc.AddNodePtxz("osm33701960", 307.201 + xs, -87.297 + zs);
            grc.AddNodePtxz("osm449011090", 310.606 + xs, -63.218 + zs);
            grc.AddNodePtxz("osm3662352911", 314.300 + xs, -38.553 + zs);
            grc.AddNodePtxz("osm2347271304", 318.365 + xs, -20.660 + zs);
            grc.AddNodePtxz("osm3662352915", 322.639 + xs, -2.436 + zs);
            grc.AddNodePtxz("osm1587776903", 336.308 + xs, 55.917 + zs);
            grc.AddNodePtxz("osm268560288", 233.692 + xs, 186.868 + zs);
            grc.AddNodePtxz("osm3662352900", 125.786 + xs, 335.082 + zs);
            grc.AddNodePtxz("osm3662352901", 129.888 + xs, 300.481 + zs);
            grc.AddNodePtxz("osm1881642018", 130.883 + xs, 280.673 + zs);
            grc.AddNodePtxz("osm667020999", 134.480 + xs, 208.516 + zs);
            grc.AddNodePtxz("osm2137895182", 206.105 + xs, 183.632 + zs);
            grc.AddNodePtxz("osm5926244886", 136.137 + xs, 191.343 + zs);
            grc.AddNodePtxz("osm5891573270", 136.809 + xs, 183.218 + zs);
            grc.AddNodePtxz("osm6373714848", 409.120 + xs, 258.316 + zs);
            grc.AddNodePtxz("osm6373715030", 543.357 + xs, 520.050 + zs);
            grc.AddNodePtxz("osm6373714863", 545.851 + xs, 512.137 + zs);
            grc.AddNodePtxz("osm6373714864", 547.645 + xs, 483.388 + zs);
            grc.AddNodePtxz("osm6373714865", 557.657 + xs, 460.832 + zs);
            grc.AddNodePtxz("osm6373714866", 560.046 + xs, 453.931 + zs);
            grc.AddNodePtxz("osm6373714867", 559.245 + xs, 449.086 + zs);
            grc.AddNodePtxz("osm6373714862", 514.021 + xs, 397.860 + zs);
            grc.AddNodePtxz("osm6373714868", 495.007 + xs, 372.322 + zs);
            grc.AddNodePtxz("osm6373714861", 464.188 + xs, 329.273 + zs);
            grc.AddNodePtxz("osm6373714860", 399.741 + xs, 246.233 + zs);
            grc.AddNodePtxz("osm6373714859", 376.316 + xs, 218.506 + zs);
            grc.AddNodePtxz("osm6373714858", 357.708 + xs, 190.128 + zs);
            grc.AddNodePtxz("osm6373714857", 354.505 + xs, 188.940 + zs);
            grc.AddNodePtxz("osm6373714856", 350.501 + xs, 192.619 + zs);
            grc.AddNodePtxz("osm6638749509", 343.356 + xs, 76.298 + zs);
            grc.AddNodePtxz("osm2137895149", 103.989 + xs, 45.544 + zs);
            grc.AddNodePtxz("osm2137895151", 104.521 + xs, 37.133 + zs);
            grc.AddNodePtxz("osm2137895137", 81.426 + xs, 35.814 + zs);
            grc.AddNodePtxz("osm2137895138", 81.693 + xs, 31.669 + zs);
            grc.AddNodePtxz("osm2137895129", 74.671 + xs, 31.268 + zs);
            grc.AddNodePtxz("osm2137895130", 75.424 + xs, 19.581 + zs);
            grc.AddNodePtxz("osm2137895147", 102.755 + xs, 21.145 + zs);
            grc.AddNodePtxz("osm2137895148", 103.113 + xs, 15.543 + zs);
            grc.AddNodePtxz("osm2137895154", 106.259 + xs, 15.727 + zs);
            grc.AddNodePtxz("osm2137895155", 106.872 + xs, 6.154 + zs);
            grc.AddNodePtxz("osm2137895135", 79.622 + xs, 4.606 + zs);
            grc.AddNodePtxz("osm2137895136", 80.745 + xs, -12.864 + zs);
            grc.AddNodePtxz("osm2137895150", 104.409 + xs, -11.519 + zs);
            grc.AddNodePtxz("osm2137895153", 104.733 + xs, -16.736 + zs);
            grc.AddNodePtxz("osm2137895156", 108.006 + xs, -16.545 + zs);
            grc.AddNodePtxz("osm2137895157", 108.608 + xs, -26.065 + zs);
            grc.AddNodePtxz("osm2137895133", 78.155 + xs, -27.797 + zs);
            grc.AddNodePtxz("osm2137895134", 79.081 + xs, -42.270 + zs);
            grc.AddNodePtxz("osm2137895131", 76.028 + xs, -42.440 + zs);
            grc.AddNodePtxz("osm2137895121", 47.838 + xs, -44.049 + zs);
            grc.AddNodePtxz("osm2137895120", 47.491 + xs, -38.613 + zs);
            grc.AddNodePtxz("osm2137895119", 43.754 + xs, -38.823 + zs);
            grc.AddNodePtxz("osm2137895118", 43.118 + xs, -28.751 + zs);
            grc.AddNodePtxz("osm2137895128", 70.286 + xs, -27.195 + zs);
            grc.AddNodePtxz("osm3666029366", 70.032 + xs, -23.337 + zs);
            grc.AddNodePtxz("osm3666040376", 65.320 + xs, -23.606 + zs);
            grc.AddNodePtxz("osm3666040373", 64.660 + xs, -13.301 + zs);
            grc.AddNodePtxz("osm3666029365", 69.349 + xs, -13.031 + zs);
            grc.AddNodePtxz("osm2137895127", 69.152 + xs, -10.079 + zs);
            grc.AddNodePtxz("osm2137895117", 42.308 + xs, -11.616 + zs);
            grc.AddNodePtxz("osm2137895116", 41.313 + xs, 3.958 + zs);
            grc.AddNodePtxz("osm2137895126", 68.249 + xs, 5.502 + zs);
            grc.AddNodePtxz("osm2137895125", 67.809 + xs, 12.267 + zs);
            grc.AddNodePtxz("osm2137895124", 61.090 + xs, 11.886 + zs);
            grc.AddNodePtxz("osm2137895122", 59.099 + xs, 42.976 + zs);
            grc.AddNodePtxz("osm3177096959", 113.234 + xs, 87.131 + zs);
            grc.AddNodePtxz("osm3177096960", 113.626 + xs, 70.430 + zs);
            grc.AddNodePtxz("osm3177098461", 79.111 + xs, 69.901 + zs);
            grc.AddNodePtxz("osm3177098462", 78.719 + xs, 86.603 + zs);
            grc.AddNodePtxz("osm3177098463", 131.718 + xs, 69.619 + zs);
            grc.AddNodePtxz("osm3666040533", 134.084 + xs, 61.284 + zs);
            grc.AddNodePtxz("osm3666040528", 131.438 + xs, 60.537 + zs);
            grc.AddNodePtxz("osm3666040532", 132.946 + xs, 55.227 + zs);
            grc.AddNodePtxz("osm3666040538", 135.604 + xs, 55.974 + zs);
            grc.AddNodePtxz("osm3177098464", 137.599 + xs, 48.970 + zs);
            grc.AddNodePtxz("osm3177098465", 135.011 + xs, 48.245 + zs);
            grc.AddNodePtxz("osm3666040541", 137.353 + xs, 38.620 + zs);
            grc.AddNodePtxz("osm3177098466", 138.548 + xs, 33.727 + zs);
            grc.AddNodePtxz("osm3666040527", 130.737 + xs, 31.968 + zs);
            grc.AddNodePtxz("osm3666040525", 129.519 + xs, 31.692 + zs);
            grc.AddNodePtxz("osm3177098467", 125.935 + xs, 48.232 + zs);
            grc.AddNodePtxz("osm3666040397", 121.806 + xs, 62.830 + zs);
            grc.AddNodePtxz("osm3666040400", 123.663 + xs, 63.350 + zs);
            grc.AddNodePtxz("osm3177098468", 122.619 + xs, 67.056 + zs);
            grc.AddNodePtxz("osm3472027587", 209.090 + xs, 58.434 + zs);
            grc.AddNodePtxz("osm344604967", 220.023 + xs, 60.326 + zs);
            grc.AddNodePtxz("osm3472027591", 218.550 + xs, 68.608 + zs);
            grc.AddNodePtxz("osm3472027593", 244.152 + xs, 73.038 + zs);
            grc.AddNodePtxz("osm3472027592", 242.645 + xs, 81.585 + zs);
            grc.AddNodePtxz("osm3472027596", 256.073 + xs, 83.908 + zs);
            grc.AddNodePtxz("osm3472027597", 257.511 + xs, 75.807 + zs);
            grc.AddNodePtxz("osm3472027598", 275.534 + xs, 78.921 + zs);
            grc.AddNodePtxz("osm3472027599", 280.346 + xs, 51.754 + zs);
            grc.AddNodePtxz("osm3472027594", 247.502 + xs, 46.072 + zs);
            grc.AddNodePtxz("osm3472027595", 248.557 + xs, 40.117 + zs);
            grc.AddNodePtxz("osm3472027590", 214.366 + xs, 34.199 + zs);
            grc.AddNodePtxz("osm3472027589", 213.427 + xs, 39.511 + zs);
            grc.AddNodePtxz("osm3472027588", 212.476 + xs, 39.346 + zs);
            grc.AddNodePtxz("osm3472027603", 306.900 + xs, 193.511 + zs);
            grc.AddNodePtxz("osm3472027608", 336.210 + xs, 160.069 + zs);
            grc.AddNodePtxz("osm3472027609", 346.785 + xs, 179.936 + zs);
            grc.AddNodePtxz("osm3472027606", 322.256 + xs, 208.230 + zs);
            grc.AddNodePtxz("osm344604976", 259.963 + xs, 167.750 + zs);
            grc.AddNodePtxz("osm3472027600", 285.091 + xs, 181.526 + zs);
            grc.AddNodePtxz("osm3472027602", 299.420 + xs, 155.085 + zs);
            grc.AddNodePtxz("osm3472027604", 311.502 + xs, 161.698 + zs);
            grc.AddNodePtxz("osm3666040459", 326.991 + xs, 136.590 + zs);
            grc.AddNodePtxz("osm3472027607", 324.218 + xs, 138.244 + zs);
            grc.AddNodePtxz("osm3472027601", 286.996 + xs, 117.833 + zs);
            grc.AddNodePtxz("osm2320845707", 305.008 + xs, 192.471 + zs);
            grc.AddNodePtxz("osm3472027605", 319.394 + xs, 166.052 + zs);
            grc.AddNodePtxz("osm3634590166", 214.325 + xs, -6.833 + zs);
            grc.AddNodePtxz("osm3634590167", 183.917 + xs, -13.041 + zs);
            grc.AddNodePtxz("osm5891559543", 182.086 + xs, -2.145 + zs);
            grc.AddNodePtxz("osm5891559542", 176.642 + xs, -3.366 + zs);
            grc.AddNodePtxz("osm3634590168", 173.779 + xs, 12.753 + zs);
            grc.AddNodePtxz("osm3634590169", 210.290 + xs, 19.814 + zs);
            grc.AddNodePtxz("osm3666040572", 149.462 + xs, -4.734 + zs);
            grc.AddNodePtxz("osm3666040574", 151.215 + xs, -4.161 + zs);
            grc.AddNodePtxz("osm3666040577", 153.442 + xs, -11.076 + zs);
            grc.AddNodePtxz("osm3666040565", 145.898 + xs, -13.509 + zs);
            grc.AddNodePtxz("osm3666040563", 144.750 + xs, -9.953 + zs);
            grc.AddNodePtxz("osm3666040559", 142.579 + xs, -10.652 + zs);
            grc.AddNodePtxz("osm3666040553", 140.967 + xs, -5.658 + zs);
            grc.AddNodePtxz("osm3666040558", 142.545 + xs, -5.913 + zs);
            grc.AddNodePtxz("osm3666040557", 141.780 + xs, -4.246 + zs);
            grc.AddNodePtxz("osm3666040570", 148.313 + xs, -3.985 + zs);
            grc.AddNodePtxz("osm3666040641", 225.987 + xs, 126.856 + zs);
            grc.AddNodePtxz("osm3666040640", 224.560 + xs, 126.612 + zs);
            grc.AddNodePtxz("osm3666040639", 224.235 + xs, 128.395 + zs);
            grc.AddNodePtxz("osm3666040635", 218.328 + xs, 127.367 + zs);
            grc.AddNodePtxz("osm3666040636", 219.070 + xs, 123.203 + zs);
            grc.AddNodePtxz("osm3666040633", 214.207 + xs, 122.399 + zs);
            grc.AddNodePtxz("osm3666040634", 216.630 + xs, 108.155 + zs);
            grc.AddNodePtxz("osm3666040644", 229.733 + xs, 110.451 + zs);
            grc.AddNodePtxz("osm3666040643", 227.565 + xs, 122.640 + zs);
            grc.AddNodePtxz("osm3666040642", 226.764 + xs, 122.496 + zs);
            grc.AddNodePtxz("osm3666040545", 138.614 + xs, 11.724 + zs);
            grc.AddNodePtxz("osm3666040537", 135.367 + xs, 25.673 + zs);
            grc.AddNodePtxz("osm3666040535", 134.961 + xs, 27.382 + zs);
            grc.AddNodePtxz("osm3666040556", 141.332 + xs, 28.867 + zs);
            grc.AddNodePtxz("osm3666040560", 143.503 + xs, 29.362 + zs);
            grc.AddNodePtxz("osm3666040569", 147.341 + xs, 12.880 + zs);
            grc.AddNodePtxz("osm3666040549", 139.192 + xs, -4.353 + zs);
            grc.AddNodePtxz("osm3666040546", 138.787 + xs, 6.758 + zs);
            grc.AddNodePtxz("osm3666039920", -56.795 + xs, 33.927 + zs);
            grc.AddNodePtxz("osm3666039952", -68.969 + xs, 33.276 + zs);
            grc.AddNodePtxz("osm3666039901", -68.807 + xs, 30.634 + zs);
            grc.AddNodePtxz("osm3666039891", -75.654 + xs, 30.262 + zs);
            grc.AddNodePtxz("osm3666039742", -80.401 + xs, 30.008 + zs);
            grc.AddNodePtxz("osm3666039747", -79.579 + xs, 16.532 + zs);
            grc.AddNodePtxz("osm3666039957", -63.250 + xs, 17.412 + zs);
            grc.AddNodePtxz("osm3666039956", -63.447 + xs, 20.666 + zs);
            grc.AddNodePtxz("osm3666039973", -47.745 + xs, 21.513 + zs);
            grc.AddNodePtxz("osm3666039972", -48.705 + xs, 37.254 + zs);
            grc.AddNodePtxz("osm3666033019", -52.814 + xs, 36.194 + zs);
            grc.AddNodePtxz("osm3666033012", -55.553 + xs, 34.218 + zs);
            grc.AddNodePtxz("osm3666040151", -17.758 + xs, 81.267 + zs);
            grc.AddNodePtxz("osm3666040003", -27.611 + xs, 81.087 + zs);
            grc.AddNodePtxz("osm3666040132", -27.334 + xs, 70.762 + zs);
            grc.AddNodePtxz("osm3666039986", -32.058 + xs, 70.674 + zs);
            grc.AddNodePtxz("osm3666039988", -31.838 + xs, 62.335 + zs);
            grc.AddNodePtxz("osm3666039992", -31.014 + xs, 62.350 + zs);
            grc.AddNodePtxz("osm3666039993", -30.888 + xs, 57.663 + zs);
            grc.AddNodePtxz("osm3666040007", -22.358 + xs, 57.825 + zs);
            grc.AddNodePtxz("osm3666040023", -15.081 + xs, 57.944 + zs);
            grc.AddNodePtxz("osm3666040158", -13.619 + xs, 57.977 + zs);
            grc.AddNodePtxz("osm3666040155", -13.838 + xs, 66.407 + zs);
            grc.AddNodePtxz("osm3666040022", -15.462 + xs, 66.375 + zs);
            grc.AddNodePtxz("osm3666040021", -15.693 + xs, 75.205 + zs);
            grc.AddNodePtxz("osm3666040014", -17.596 + xs, 75.169 + zs);
            grc.AddNodePtxz("osm3666040195", 8.950 + xs, 103.646 + zs);
            grc.AddNodePtxz("osm3666040278", 18.322 + xs, 73.105 + zs);
            grc.AddNodePtxz("osm3666040193", 8.376 + xs, 70.058 + zs);
            grc.AddNodePtxz("osm3666040194", 8.851 + xs, 68.492 + zs);
            grc.AddNodePtxz("osm3666040190", 3.733 + xs, 66.929 + zs);
            grc.AddNodePtxz("osm3666040184", 1.808 + xs, 73.193 + zs);
            grc.AddNodePtxz("osm3666040042", 3.955 + xs, 73.854 + zs);
            grc.AddNodePtxz("osm3666040186", 2.226 + xs, 79.459 + zs);
            grc.AddNodePtxz("osm3666040253", 0.311 + xs, 78.872 + zs);
            grc.AddNodePtxz("osm3666040249", -1.185 + xs, 83.737 + zs);
            grc.AddNodePtxz("osm3666040252", 0.208 + xs, 84.155 + zs);
            grc.AddNodePtxz("osm3666040250", -0.662 + xs, 87.007 + zs);
            grc.AddNodePtxz("osm3666040180", -2.299 + xs, 86.508 + zs);
            grc.AddNodePtxz("osm3666040174", -3.458 + xs, 90.313 + zs);
            grc.AddNodePtxz("osm3666040247", -1.718 + xs, 90.841 + zs);
            grc.AddNodePtxz("osm3666040244", -2.089 + xs, 92.052 + zs);
            grc.AddNodePtxz("osm3666040173", -3.818 + xs, 91.516 + zs);
            grc.AddNodePtxz("osm3666040241", -5.036 + xs, 95.495 + zs);
            grc.AddNodePtxz("osm3666040176", -3.225 + xs, 96.046 + zs);
            grc.AddNodePtxz("osm3666040171", -6.752 + xs, 107.575 + zs);
            grc.AddNodePtxz("osm3666040239", -5.230 + xs, 113.131 + zs);
            grc.AddNodePtxz("osm3666040183", 1.293 + xs, 118.455 + zs);
            grc.AddNodePtxz("osm3666040258", 11.260 + xs, 105.626 + zs);
            grc.AddNodePtxz("osm3666040161", -11.856 + xs, 48.703 + zs);
            grc.AddNodePtxz("osm3666040135", -24.959 + xs, 48.468 + zs);
            grc.AddNodePtxz("osm3666040138", -24.764 + xs, 35.767 + zs);
            grc.AddNodePtxz("osm3666040024", -11.510 + xs, 35.979 + zs);
            grc.AddNodePtxz("osm3666040337", 32.677 + xs, -3.830 + zs);
            grc.AddNodePtxz("osm3666040200", 9.942 + xs, -4.059 + zs);
            grc.AddNodePtxz("osm3666040201", 10.057 + xs, -10.632 + zs);
            grc.AddNodePtxz("osm3666040339", 32.792 + xs, -10.403 + zs);
            grc.AddNodePtxz("osm3666039991", -31.069 + xs, 83.508 + zs);
            grc.AddNodePtxz("osm3666040012", -21.912 + xs, 83.551 + zs);
            grc.AddNodePtxz("osm3666040011", -21.992 + xs, 89.648 + zs);
            grc.AddNodePtxz("osm3666039990", -31.149 + xs, 89.613 + zs);
            grc.AddNodePtxz("osm3666040368", 48.027 + xs, 45.650 + zs);
            grc.AddNodePtxz("osm3666040367", 47.958 + xs, 48.813 + zs);
            grc.AddNodePtxz("osm3666040318", 36.840 + xs, 48.651 + zs);
            grc.AddNodePtxz("osm3666040319", 36.909 + xs, 45.489 + zs);
            grc.AddNodePtxz("osm3666040009", -22.208 + xs, 51.787 + zs);
            grc.AddNodePtxz("osm3666040152", -14.931 + xs, 51.906 + zs);
            grc.AddNodePtxz("osm3666039968", -50.714 + xs, 102.720 + zs);
            grc.AddNodePtxz("osm3666039958", -62.192 + xs, 102.486 + zs);
            grc.AddNodePtxz("osm3666039959", -61.730 + xs, 86.312 + zs);
            grc.AddNodePtxz("osm3666039969", -50.252 + xs, 86.554 + zs);
            grc.AddNodePtxz("osm3666040452", 106.742 + xs, 58.589 + zs);
            grc.AddNodePtxz("osm3666040391", 100.765 + xs, 58.285 + zs);
            grc.AddNodePtxz("osm3666040448", 101.089 + xs, 52.556 + zs);
            grc.AddNodePtxz("osm3666040453", 107.066 + xs, 52.859 + zs);
            grc.AddNodePtxz("osm3666040124", 128.433 + xs, -4.827 + zs);
            grc.AddNodePtxz("osm3666040122", 127.866 + xs, 6.210 + zs);
            grc.AddNodePtxz("osm3666040016", -17.038 + xs, 13.510 + zs);
            grc.AddNodePtxz("osm3666040039", -33.541 + xs, 13.462 + zs);
            grc.AddNodePtxz("osm3666040040", -33.472 + xs, 7.297 + zs);
            grc.AddNodePtxz("osm3666040017", -16.969 + xs, 7.345 + zs);
            grc.AddNodePtxz("osm3666040191", 3.843 + xs, 27.623 + zs);
            grc.AddNodePtxz("osm3666040182", 0.338 + xs, 27.532 + zs);
            grc.AddNodePtxz("osm3666040251", 0.141 + xs, 33.623 + zs);
            grc.AddNodePtxz("osm3666040189", 3.635 + xs, 33.714 + zs);
            grc.AddNodePtxz("osm3666040120", 126.883 + xs, 24.380 + zs);
            grc.AddNodePtxz("osm3666040454", 112.121 + xs, 23.525 + zs);
            grc.AddNodePtxz("osm3666040456", 113.128 + xs, 7.980 + zs);
            grc.AddNodePtxz("osm3666040123", 127.890 + xs, 8.835 + zs);
            grc.AddNodePtxz("osm3666040381", 68.935 + xs, 79.857 + zs);
            grc.AddNodePtxz("osm3666040344", 35.244 + xs, 79.661 + zs);
            grc.AddNodePtxz("osm3666040345", 35.462 + xs, 63.980 + zs);
            grc.AddNodePtxz("osm3666029364", 69.152 + xs, 64.176 + zs);
            grc.AddNodePtxz("osm3666040139", -24.429 + xs, 21.503 + zs);
            grc.AddNodePtxz("osm3666040225", -11.164 + xs, 21.715 + zs);
            grc.AddNodePtxz("osm3666040631", 209.001 + xs, 150.090 + zs);
            grc.AddNodePtxz("osm3666040628", 203.859 + xs, 149.349 + zs);
            grc.AddNodePtxz("osm3666040626", 202.167 + xs, 160.644 + zs);
            grc.AddNodePtxz("osm3666040630", 207.366 + xs, 161.400 + zs);
            grc.AddNodePtxz("osm3666040392", 113.510 + xs, 5.577 + zs);
            grc.AddNodePtxz("osm3666040393", 114.077 + xs, -5.459 + zs);
            grc.AddNodePtxz("osm3666040035", -34.965 + xs, 103.092 + zs);
            grc.AddNodePtxz("osm3666040029", -44.435 + xs, 102.991 + zs);
            grc.AddNodePtxz("osm3666040030", -44.205 + xs, 90.607 + zs);
            grc.AddNodePtxz("osm3666039982", -39.377 + xs, 90.664 + zs);
            grc.AddNodePtxz("osm3666039983", -39.320 + xs, 87.887 + zs);
            grc.AddNodePtxz("osm3666040037", -34.666 + xs, 87.945 + zs);
            grc.AddNodePtxz("osm3666040637", 219.345 + xs, 172.948 + zs);
            grc.AddNodePtxz("osm3666040629", 205.964 + xs, 171.085 + zs);
            grc.AddNodePtxz("osm3666040632", 210.148 + xs, 142.090 + zs);
            grc.AddNodePtxz("osm3666040638", 223.530 + xs, 143.953 + zs);
            grc.AddNodePtxz("osm3666040238", -5.319 + xs, -0.157 + zs);
            grc.AddNodePtxz("osm3666040144", -20.104 + xs, -0.695 + zs);
            grc.AddNodePtxz("osm3666040145", -19.919 + xs, -4.892 + zs);
            grc.AddNodePtxz("osm3666040006", -22.542 + xs, -4.990 + zs);
            grc.AddNodePtxz("osm3666040010", -22.195 + xs, -12.810 + zs);
            grc.AddNodePtxz("osm3666040243", -4.787 + xs, -12.174 + zs);
            grc.AddNodePtxz("osm5891623046", 335.383 + xs, 141.355 + zs);
            grc.AddNodePtxz("osm3666040460", 328.108 + xs, 154.011 + zs);
            grc.AddNodePtxz("osm3666040461", 332.994 + xs, 157.123 + zs);
            grc.AddNodePtxz("osm3666040261", 13.225 + xs, 128.472 + zs);
            grc.AddNodePtxz("osm3666040196", 9.441 + xs, 125.471 + zs);
            grc.AddNodePtxz("osm3666040255", 10.358 + xs, 124.293 + zs);
            grc.AddNodePtxz("osm3666040048", 6.423 + xs, 121.180 + zs);
            grc.AddNodePtxz("osm3666040044", 5.773 + xs, 122.008 + zs);
            grc.AddNodePtxz("osm3666040288", 23.470 + xs, 115.286 + zs);
            grc.AddNodePtxz("osm3666040298", 26.892 + xs, 31.554 + zs);
            grc.AddNodePtxz("osm3666040299", 27.007 + xs, 28.256 + zs);
            grc.AddNodePtxz("osm3666040188", 3.346 + xs, 41.775 + zs);
            grc.AddNodePtxz("osm3666040215", 25.164 + xs, 42.382 + zs);
            grc.AddNodePtxz("osm3666040219", 25.384 + xs, 36.313 + zs);
            grc.AddNodePtxz("osm3666040297", 26.718 + xs, 36.355 + zs);
            grc.AddNodePtxz("osm3666040214", 25.118 + xs, 45.242 + zs);
            grc.AddNodePtxz("osm3666040369", 48.420 + xs, 31.967 + zs);
            grc.AddNodePtxz("osm3666040547", 138.943 + xs, 38.991 + zs);
            grc.AddNodePtxz("osm3666040531", 132.384 + xs, 24.974 + zs);
            grc.AddNodePtxz("osm3666040627", 202.183 + xs, 120.404 + zs);
            grc.AddNodePtxz("osm3666040625", 201.696 + xs, 123.222 + zs);
            grc.AddNodePtxz("osm3666040620", 190.868 + xs, 121.428 + zs);
            grc.AddNodePtxz("osm3666040621", 191.332 + xs, 118.731 + zs);
            grc.AddNodePtxz("osm3666040618", 184.125 + xs, 117.532 + zs);
            grc.AddNodePtxz("osm3666040619", 186.571 + xs, 103.160 + zs);
            grc.AddNodePtxz("osm3666431790", -49.309 + xs, 174.760 + zs);
            grc.AddNodePtxz("osm3666431794", -48.555 + xs, 171.826 + zs);
            grc.AddNodePtxz("osm3666431678", -47.615 + xs, 172.067 + zs);
            grc.AddNodePtxz("osm3666431899", -46.525 + xs, 167.840 + zs);
            grc.AddNodePtxz("osm3666431681", -47.268 + xs, 167.657 + zs);
            grc.AddNodePtxz("osm3666431897", -46.665 + xs, 165.328 + zs);
            grc.AddNodePtxz("osm3666431907", -45.620 + xs, 165.591 + zs);
            grc.AddNodePtxz("osm3666431914", -44.982 + xs, 163.148 + zs);
            grc.AddNodePtxz("osm3666431801", -44.414 + xs, 163.302 + zs);
            grc.AddNodePtxz("osm3666431917", -43.718 + xs, 160.602 + zs);
            grc.AddNodePtxz("osm3666431912", -45.308 + xs, 160.193 + zs);
            grc.AddNodePtxz("osm3666431919", -43.533 + xs, 153.289 + zs);
            grc.AddNodePtxz("osm3666431805", -44.102 + xs, 153.136 + zs);
            grc.AddNodePtxz("osm3666431771", -55.986 + xs, 150.113 + zs);
            grc.AddNodePtxz("osm3666431875", -57.309 + xs, 149.762 + zs);
            grc.AddNodePtxz("osm3666431853", -62.772 + xs, 170.944 + zs);
            grc.AddNodePtxz("osm3666431884", -54.177 + xs, 143.043 + zs);
            grc.AddNodePtxz("osm3666431924", -42.316 + xs, 146.156 + zs);
            grc.AddNodePtxz("osm3666431744", -66.703 + xs, 189.886 + zs);
            grc.AddNodePtxz("osm3666431635", -76.092 + xs, 187.778 + zs);
            grc.AddNodePtxz("osm3666430514", -74.678 + xs, 181.571 + zs);
            grc.AddNodePtxz("osm3666431828", -65.300 + xs, 183.679 + zs);
            grc.AddNodePtxz("osm3666431768", -56.859 + xs, 208.439 + zs);
            grc.AddNodePtxz("osm3666431642", -70.496 + xs, 205.085 + zs);
            grc.AddNodePtxz("osm3666430524", -68.605 + xs, 197.161 + zs);
            grc.AddNodePtxz("osm3666431882", -54.876 + xs, 200.590 + zs);
            grc.AddNodePtxz("osm3666431669", -61.248 + xs, 191.198 + zs);
            grc.AddNodePtxz("osm3666431757", -59.776 + xs, 185.315 + zs);
            grc.AddNodePtxz("osm3666431785", -50.212 + xs, 187.686 + zs);
            grc.AddNodePtxz("osm3666431893", -51.674 + xs, 193.568 + zs);
            grc.AddNodePtxz("osm3666428305", -53.020 + xs, 193.233 + zs);
            grc.AddNodePtxz("osm3666431645", -70.279 + xs, 251.163 + zs);
            grc.AddNodePtxz("osm3666431826", -68.110 + xs, 243.011 + zs);
            grc.AddNodePtxz("osm3666430495", -79.310 + xs, 240.110 + zs);
            grc.AddNodePtxz("osm3666430483", -80.680 + xs, 239.730 + zs);
            grc.AddNodePtxz("osm3666431009", -82.837 + xs, 247.837 + zs);
            grc.AddNodePtxz("osm3666428292", -73.914 + xs, 167.809 + zs);
            grc.AddNodePtxz("osm3666431684", -47.034 + xs, 175.397 + zs);
            grc.AddNodePtxz("osm3666431793", -48.751 + xs, 181.456 + zs);
            grc.AddNodePtxz("osm3666430509", -75.630 + xs, 173.860 + zs);
            grc.AddNodePtxz("osm3666431650", -65.963 + xs, 243.558 + zs);
            grc.AddNodePtxz("osm3666431839", -63.887 + xs, 235.603 + zs);
            grc.AddNodePtxz("osm3666428293", -73.741 + xs, 233.016 + zs);
            grc.AddNodePtxz("osm3666430504", -77.234 + xs, 232.140 + zs);
            grc.AddNodePtxz("osm3666431809", -41.492 + xs, 146.368 + zs);
            grc.AddNodePtxz("osm3666431934", -37.027 + xs, 129.413 + zs);
            grc.AddNodePtxz("osm3666431782", -50.698 + xs, 125.832 + zs);
            grc.AddNodePtxz("osm3666431879", -55.175 + xs, 142.779 + zs);
            grc.AddNodePtxz("osm3666466070", 26.603 + xs, 178.022 + zs);
            grc.AddNodePtxz("osm3666466823", 20.836 + xs, 185.081 + zs);
            grc.AddNodePtxz("osm3666466820", 18.630 + xs, 183.236 + zs);
            grc.AddNodePtxz("osm3666466817", 17.250 + xs, 184.915 + zs);
            grc.AddNodePtxz("osm3666466818", 17.760 + xs, 185.334 + zs);
            grc.AddNodePtxz("osm3666466814", 14.987 + xs, 188.730 + zs);
            grc.AddNodePtxz("osm3666466812", 14.372 + xs, 188.222 + zs);
            grc.AddNodePtxz("osm3666466810", 12.028 + xs, 191.079 + zs);
            grc.AddNodePtxz("osm3666466791", 4.681 + xs, 184.955 + zs);
            grc.AddNodePtxz("osm3666466803", 6.468 + xs, 182.751 + zs);
            grc.AddNodePtxz("osm3666466801", 5.853 + xs, 182.236 + zs);
            grc.AddNodePtxz("osm3666466806", 8.997 + xs, 178.391 + zs);
            grc.AddNodePtxz("osm3666466804", 8.742 + xs, 178.189 + zs);
            grc.AddNodePtxz("osm3666466808", 10.494 + xs, 176.047 + zs);
            grc.AddNodePtxz("osm3666466807", 9.287 + xs, 175.189 + zs);
            grc.AddNodePtxz("osm3666466813", 14.821 + xs, 168.223 + zs);
            grc.AddNodePtxz("osm3666466802", 6.408 + xs, 172.860 + zs);
            grc.AddNodePtxz("osm3666466794", 4.842 + xs, 174.820 + zs);
            grc.AddNodePtxz("osm3666466800", 5.318 + xs, 175.200 + zs);
            grc.AddNodePtxz("osm3666466787", 2.591 + xs, 178.634 + zs);
            grc.AddNodePtxz("osm3666468623", 1.929 + xs, 178.104 + zs);
            grc.AddNodePtxz("osm3666468618", -0.322 + xs, 180.938 + zs);
            grc.AddNodePtxz("osm3666468595", -7.773 + xs, 174.912 + zs);
            grc.AddNodePtxz("osm3666468605", -5.963 + xs, 172.625 + zs);
            grc.AddNodePtxz("osm3666468602", -6.544 + xs, 172.155 + zs);
            grc.AddNodePtxz("osm3666467905", -3.457 + xs, 168.258 + zs);
            grc.AddNodePtxz("osm3666468613", -3.654 + xs, 168.093 + zs);
            grc.AddNodePtxz("osm3666467907", -1.937 + xs, 165.921 + zs);
            grc.AddNodePtxz("osm3666467906", -3.063 + xs, 165.002 + zs);
            grc.AddNodePtxz("osm3666466786", 2.367 + xs, 158.150 + zs);
            grc.AddNodePtxz("osm3666468606", -5.965 + xs, 162.771 + zs);
            grc.AddNodePtxz("osm3666468596", -7.531 + xs, 164.731 + zs);
            grc.AddNodePtxz("osm3666468599", -7.055 + xs, 165.119 + zs);
            grc.AddNodePtxz("osm3666468589", -9.782 + xs, 168.546 + zs);
            grc.AddNodePtxz("osm3666468584", -10.444 + xs, 168.015 + zs);
            grc.AddNodePtxz("osm3666467902", -12.706 + xs, 170.857 + zs);
            grc.AddNodePtxz("osm3666467881", -20.135 + xs, 164.808 + zs);
            grc.AddNodePtxz("osm3666467886", -18.325 + xs, 162.544 + zs);
            grc.AddNodePtxz("osm3666467883", -18.917 + xs, 162.059 + zs);
            grc.AddNodePtxz("osm3666467889", -15.819 + xs, 158.177 + zs);
            grc.AddNodePtxz("osm3666467888", -16.028 + xs, 158.005 + zs);
            grc.AddNodePtxz("osm3666467897", -14.206 + xs, 155.711 + zs);
            grc.AddNodePtxz("osm3666467891", -15.320 + xs, 154.792 + zs);
            grc.AddNodePtxz("osm3666468587", -9.994 + xs, 148.122 + zs);
            grc.AddNodePtxz("osm3666468607", -5.588 + xs, 193.893 + zs);
            grc.AddNodePtxz("osm3666468608", -5.390 + xs, 200.501 + zs);
            grc.AddNodePtxz("osm3666468600", -6.851 + xs, 205.667 + zs);
            grc.AddNodePtxz("osm3666468604", -6.016 + xs, 205.901 + zs);
            grc.AddNodePtxz("osm3666468597", -7.419 + xs, 210.886 + zs);
            grc.AddNodePtxz("osm3666468588", -9.880 + xs, 210.197 + zs);
            grc.AddNodePtxz("osm3666468585", -10.251 + xs, 211.498 + zs);
            grc.AddNodePtxz("osm3666467890", -15.787 + xs, 209.938 + zs);
            grc.AddNodePtxz("osm3666467896", -14.244 + xs, 204.493 + zs);
            grc.AddNodePtxz("osm3666467882", -19.827 + xs, 202.918 + zs);
            grc.AddNodePtxz("osm3666467887", -16.069 + xs, 189.621 + zs);
            grc.AddNodePtxz("osm3666467900", -13.597 + xs, 190.317 + zs);
            grc.AddNodePtxz("osm3666467901", -13.110 + xs, 188.569 + zs);
            grc.AddNodePtxz("osm3666468586", -10.127 + xs, 189.412 + zs);
            grc.AddNodePtxz("osm3666467903", -10.533 + xs, 190.826 + zs);
            grc.AddNodePtxz("osm3666468601", -6.830 + xs, 191.866 + zs);
            grc.AddNodePtxz("osm3666468598", -7.271 + xs, 193.424 + zs);
            grc.AddNodePtxz("osm3666466098", 90.114 + xs, 215.843 + zs);
            grc.AddNodePtxz("osm3666466079", 82.721 + xs, 215.709 + zs);
            grc.AddNodePtxz("osm3666466078", 82.664 + xs, 218.072 + zs);
            grc.AddNodePtxz("osm3666469265", 78.126 + xs, 217.990 + zs);
            grc.AddNodePtxz("osm3666469266", 78.160 + xs, 216.510 + zs);
            grc.AddNodePtxz("osm3666469335", 67.089 + xs, 216.318 + zs);
            grc.AddNodePtxz("osm3666469334", 67.054 + xs, 217.578 + zs);
            grc.AddNodePtxz("osm3666469247", 61.344 + xs, 217.476 + zs);
            grc.AddNodePtxz("osm3666469248", 61.390 + xs, 215.627 + zs);
            grc.AddNodePtxz("osm3666469239", 55.321 + xs, 215.520 + zs);
            grc.AddNodePtxz("osm3666469238", 55.286 + xs, 216.849 + zs);
            grc.AddNodePtxz("osm3666469328", 51.120 + xs, 216.778 + zs);
            grc.AddNodePtxz("osm3666469329", 51.154 + xs, 215.344 + zs);
            grc.AddNodePtxz("osm3666469232", 45.769 + xs, 215.247 + zs);
            grc.AddNodePtxz("osm3666469230", 45.723 + xs, 217.141 + zs);
            grc.AddNodePtxz("osm3666469136", 38.377 + xs, 217.008 + zs);
            grc.AddNodePtxz("osm3666469139", 38.527 + xs, 210.985 + zs);
            grc.AddNodePtxz("osm3666469144", 40.082 + xs, 211.017 + zs);
            grc.AddNodePtxz("osm3666469145", 40.382 + xs, 199.432 + zs);
            grc.AddNodePtxz("osm3666466099", 90.401 + xs, 200.327 + zs);
            grc.AddNodePtxz("osm3666469280", 103.736 + xs, 198.440 + zs);
            grc.AddNodePtxz("osm3666469286", 105.837 + xs, 201.516 + zs);
            grc.AddNodePtxz("osm3666469285", 105.733 + xs, 207.666 + zs);
            grc.AddNodePtxz("osm3666469290", 106.256 + xs, 207.669 + zs);
            grc.AddNodePtxz("osm3666469289", 106.152 + xs, 213.480 + zs);
            grc.AddNodePtxz("osm3666469284", 105.491 + xs, 213.478 + zs);
            grc.AddNodePtxz("osm3666469169", 105.410 + xs, 218.089 + zs);
            grc.AddNodePtxz("osm3666469170", 106.768 + xs, 218.108 + zs);
            grc.AddNodePtxz("osm3666469293", 106.653 + xs, 224.379 + zs);
            grc.AddNodePtxz("osm3666469166", 104.831 + xs, 224.357 + zs);
            grc.AddNodePtxz("osm3666469165", 104.727 + xs, 229.896 + zs);
            grc.AddNodePtxz("osm3666469168", 105.412 + xs, 229.905 + zs);
            grc.AddNodePtxz("osm3666469167", 105.320 + xs, 235.150 + zs);
            grc.AddNodePtxz("osm3666469164", 104.589 + xs, 235.142 + zs);
            grc.AddNodePtxz("osm3666469162", 104.520 + xs, 239.020 + zs);
            grc.AddNodePtxz("osm3666469288", 106.006 + xs, 239.038 + zs);
            grc.AddNodePtxz("osm3666469287", 105.914 + xs, 244.057 + zs);
            grc.AddNodePtxz("osm3666469163", 104.556 + xs, 244.045 + zs);
            grc.AddNodePtxz("osm3666469161", 104.521 + xs, 246.257 + zs);
            grc.AddNodePtxz("osm3666466085", 86.011 + xs, 246.067 + zs);
            grc.AddNodePtxz("osm3666466087", 86.298 + xs, 230.061 + zs);
            grc.AddNodePtxz("osm3666466094", 88.886 + xs, 230.084 + zs);
            grc.AddNodePtxz("osm3666466095", 88.978 + xs, 224.703 + zs);
            grc.AddNodePtxz("osm3666466097", 89.953 + xs, 224.710 + zs);
            grc.AddNodePtxz("osm3666466100", 90.436 + xs, 198.304 + zs);
            grc.AddNodePtxz("osm3666467912", -1.113 + xs, 237.875 + zs);
            grc.AddNodePtxz("osm3666467911", -1.184 + xs, 228.731 + zs);
            grc.AddNodePtxz("osm3666466796", 5.036 + xs, 228.632 + zs);
            grc.AddNodePtxz("osm3666466797", 5.108 + xs, 237.769 + zs);
            grc.AddNodePtxz("osm3666467916", 35.157 + xs, 185.163 + zs);
            grc.AddNodePtxz("osm3666467915", 34.996 + xs, 193.585 + zs);
            grc.AddNodePtxz("osm3666467923", 38.280 + xs, 193.617 + zs);
            grc.AddNodePtxz("osm3666469138", 38.441 + xs, 185.203 + zs);
            grc.AddNodePtxz("osm3666467892", -14.618 + xs, 259.970 + zs);
            grc.AddNodePtxz("osm3666467893", -14.481 + xs, 246.123 + zs);
            grc.AddNodePtxz("osm3666467894", -14.413 + xs, 238.434 + zs);
            grc.AddNodePtxz("osm3666468594", -7.937 + xs, 238.476 + zs);
            grc.AddNodePtxz("osm3666468593", -8.235 + xs, 260.006 + zs);
            grc.AddNodePtxz("osm3666467895", -14.344 + xs, 230.593 + zs);
            grc.AddNodePtxz("osm3666467880", -25.045 + xs, 230.586 + zs);
            grc.AddNodePtxz("osm3666467879", -25.192 + xs, 249.127 + zs);
            grc.AddNodePtxz("osm3666467884", -18.473 + xs, 249.130 + zs);
            grc.AddNodePtxz("osm3666467885", -18.438 + xs, 246.119 + zs);
            grc.AddNodePtxz("osm3666467874", -31.413 + xs, 177.037 + zs);
            grc.AddNodePtxz("osm3666466785", -32.805 + xs, 181.848 + zs);
            grc.AddNodePtxz("osm3666466784", -33.908 + xs, 181.533 + zs);
            grc.AddNodePtxz("osm3666466783", -36.691 + xs, 191.124 + zs);
            grc.AddNodePtxz("osm3666467875", -29.252 + xs, 193.279 + zs);
            grc.AddNodePtxz("osm3666467877", -26.515 + xs, 183.885 + zs);
            grc.AddNodePtxz("osm3666467876", -27.048 + xs, 183.731 + zs);
            grc.AddNodePtxz("osm3666467878", -25.599 + xs, 178.723 + zs);
            grc.AddNodePtxz("osm3666999124", 216.716 + xs, 208.396 + zs);
            grc.AddNodePtxz("osm3666999332", 219.581 + xs, 196.224 + zs);
            grc.AddNodePtxz("osm3666999116", 213.964 + xs, 194.913 + zs);
            grc.AddNodePtxz("osm3666999110", 211.099 + xs, 207.086 + zs);
            grc.AddNodePtxz("osm3666999086", 191.984 + xs, 201.831 + zs);
            grc.AddNodePtxz("osm3666999088", 192.423 + xs, 191.686 + zs);
            grc.AddNodePtxz("osm3666999078", 186.145 + xs, 191.460 + zs);
            grc.AddNodePtxz("osm3666999077", 185.706 + xs, 201.613 + zs);
            grc.AddNodePtxz("osm3666999052", 165.316 + xs, 206.955 + zs);
            grc.AddNodePtxz("osm3666999043", 152.944 + xs, 206.389 + zs);
            grc.AddNodePtxz("osm3666999044", 153.546 + xs, 194.303 + zs);
            grc.AddNodePtxz("osm3666999053", 165.952 + xs, 194.869 + zs);
            grc.AddNodePtxz("osm3666999065", 177.738 + xs, 233.757 + zs);
            grc.AddNodePtxz("osm3666999153", 179.114 + xs, 201.382 + zs);
            grc.AddNodePtxz("osm3666999082", 190.643 + xs, 234.205 + zs);
            grc.AddNodePtxz("osm3666999111", 211.278 + xs, 234.444 + zs);
            grc.AddNodePtxz("osm3666999095", 198.709 + xs, 231.827 + zs);
            grc.AddNodePtxz("osm3666999185", 204.217 + xs, 205.726 + zs);
            grc.AddNodePtxz("osm3666999031", 144.971 + xs, 206.049 + zs);
            grc.AddNodePtxz("osm3666999033", 145.226 + xs, 200.977 + zs);
            grc.AddNodePtxz("osm3666999039", 146.142 + xs, 201.014 + zs);
            grc.AddNodePtxz("osm3666997221", 146.570 + xs, 192.537 + zs);
            grc.AddNodePtxz("osm3666999046", 153.627 + xs, 192.839 + zs);
            grc.AddNodePtxz("osm3666991854", 163.056 + xs, 228.502 + zs);
            grc.AddNodePtxz("osm3666999129", 144.058 + xs, 228.392 + zs);
            grc.AddNodePtxz("osm3666999128", 143.989 + xs, 233.440 + zs);
            grc.AddNodePtxz("osm3666998822", 143.026 + xs, 233.433 + zs);
            grc.AddNodePtxz("osm3666999029", 142.946 + xs, 238.776 + zs);
            grc.AddNodePtxz("osm3666999127", 143.688 + xs, 238.785 + zs);
            grc.AddNodePtxz("osm3666999125", 143.620 + xs, 243.864 + zs);
            grc.AddNodePtxz("osm3666991853", 162.838 + xs, 243.972 + zs);
            grc.AddNodePtxz("osm5455089557", 196.436 + xs, 173.671 + zs);
            grc.AddNodePtxz("osm5455089558", 156.211 + xs, 172.550 + zs);
            grc.AddNodePtxz("osm5455089559", 156.859 + xs, 157.121 + zs);
            grc.AddNodePtxz("osm5455089560", 196.817 + xs, 159.316 + zs);
            grc.AddNodePtxz("osm5730170647", 297.805 + xs, 285.983 + zs);
            grc.AddNodePtxz("osm5730170648", 319.782 + xs, 266.253 + zs);
            grc.AddNodePtxz("osm5730170649", 290.845 + xs, 236.581 + zs);
            grc.AddNodePtxz("osm5730170650", 274.078 + xs, 256.025 + zs);
            grc.AddNodePtxz("osm5730170651", 282.389 + xs, 263.742 + zs);
            grc.AddNodePtxz("osm5730170652", 290.454 + xs, 255.290 + zs);
            grc.AddNodePtxz("osm5730170653", 300.610 + xs, 265.141 + zs);
            grc.AddNodePtxz("osm5730170654", 288.902 + xs, 276.151 + zs);
            grc.AddNodePtxz("osm5730170655", 262.611 + xs, 246.193 + zs);
            grc.AddNodePtxz("osm5730170656", 277.335 + xs, 227.310 + zs);
            grc.AddNodePtxz("osm5730170657", 243.153 + xs, 206.187 + zs);
            grc.AddNodePtxz("osm5730170658", 227.606 + xs, 229.687 + zs);
            grc.AddNodePtxz("osm5730170659", 237.762 + xs, 235.283 + zs);
            grc.AddNodePtxz("osm5730170660", 245.361 + xs, 221.636 + zs);
            grc.AddNodePtxz("osm5730170661", 258.859 + xs, 228.780 + zs);
            grc.AddNodePtxz("osm5730170662", 250.946 + xs, 239.532 + zs);
            grc.AddNodePtxz("osm5891566774", 128.300 + xs, 169.913 + zs);
            grc.AddNodePtxz("osm5891566775", 98.683 + xs, 169.561 + zs);
            grc.AddNodePtxz("osm5891566776", 98.680 + xs, 154.380 + zs);
            grc.AddNodePtxz("osm5891566777", 128.297 + xs, 154.331 + zs);
            grc.AddNodePtxz("osm5891566778", 87.681 + xs, 169.451 + zs);
            grc.AddNodePtxz("osm5891566779", 72.675 + xs, 169.171 + zs);
            grc.AddNodePtxz("osm5891566780", 73.063 + xs, 133.757 + zs);
            grc.AddNodePtxz("osm5891566781", 88.081 + xs, 134.029 + zs);
            grc.AddNodePtxz("osm5891566782", 102.283 + xs, 118.123 + zs);
            grc.AddNodePtxz("osm5891566783", 57.451 + xs, 117.901 + zs);
            grc.AddNodePtxz("osm5891566784", 57.449 + xs, 103.935 + zs);
            grc.AddNodePtxz("osm5891567185", 102.281 + xs, 103.757 + zs);
            grc.AddNodePtxz("osm5891567186", 50.854 + xs, 153.980 + zs);
            grc.AddNodePtxz("osm5891567187", 59.661 + xs, 142.368 + zs);
            grc.AddNodePtxz("osm5891567188", 35.240 + xs, 124.361 + zs);
            grc.AddNodePtxz("osm5891567189", 27.245 + xs, 134.955 + zs);
            grc.AddNodePtxz("osm5891567190", 130.691 + xs, 103.311 + zs);
            grc.AddNodePtxz("osm5891567191", 116.683 + xs, 103.023 + zs);
            grc.AddNodePtxz("osm5891567192", 116.690 + xs, 141.678 + zs);
            grc.AddNodePtxz("osm5891567193", 130.303 + xs, 141.359 + zs);

            grc.AddLinkByNodeName("osm738283752", "osm33702042", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link1");
            grc.AddLinkByNodeName("osm5457326852", "osm738283752", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link2");
            grc.AddLinkByNodeName("osm33702932", "osm5457326852", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link3");
            grc.AddLinkByNodeName("osm1347958012", "osm33702932", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link4");
            grc.AddLinkByNodeName("osm5467434859", "osm1347958012", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link5");
            grc.AddLinkByNodeName("osm3662353680", "osm5467434859", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link6");
            grc.AddLinkByNodeName("osm3666468611", "osm3662353680", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link7");
            grc.AddLinkByNodeName("osm473651436", "osm3666468611", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link8");
            grc.AddLinkByNodeName("osm3662352895", "osm473651436", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link9");
            grc.AddLinkByNodeName("osm3662352894", "osm3662352895", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link10");
            grc.AddLinkByNodeName("osm33702933", "osm3662352894", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link11");
            grc.AddLinkByNodeName("osm3662352893", "osm33702933", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link12");
            grc.AddLinkByNodeName("osm3662352892", "osm3662352893", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link13");
            grc.AddLinkByNodeName("osm33702934", "osm3662352892", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link14");
            grc.AddLinkByNodeName("osm473651438", "osm33702934", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link15");
            grc.AddLinkByNodeName("osm3662352891", "osm473651438", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link16");
            grc.AddLinkByNodeName("osm33702935", "osm3662352891", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link17");
            grc.AddLinkByNodeName("osm5474088800", "osm33702935", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link18");
            grc.AddLinkByNodeName("osm3666466781", "osm5474088800", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link19");
            grc.AddLinkByNodeName("osm5474088796", "osm3666466781", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link20");
            grc.AddLinkByNodeName("osm5467434854", "osm5474088796", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link21");
            grc.AddLinkByNodeName("osm33702925", "osm5467434854", usetype: LinkUse.slowroad, comment: "Edith-Stein-Strasse.link22");

            grc.AddLinkByNodeName("osm738281714", "osm248731300", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link1");
            grc.AddLinkByNodeName("osm6373715031", "osm738281714", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link2");
            grc.AddLinkByNodeName("osm3666999699", "osm6373715031", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link3");
            grc.AddLinkByNodeName("osm243312270", "osm3666999699", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link4");
            grc.AddLinkByNodeName("osm2769223913", "osm243312270", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link5");
            grc.AddLinkByNodeName("osm3666999698", "osm2769223913", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link6");
            grc.AddLinkByNodeName("osm243312208", "osm3666999698", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link7");
            grc.AddLinkByNodeName("osm2769223901", "osm243312208", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link8");
            grc.AddLinkByNodeName("osm243312276", "osm2769223901", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link9");
            grc.AddLinkByNodeName("osm2769404079", "osm243312276", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link10");
            grc.AddLinkByNodeName("osm243312283", "osm2769404079", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link11");
            grc.AddLinkByNodeName("osm2769404063", "osm243312283", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link12");
            grc.AddLinkByNodeName("osm243312291", "osm2769404063", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link13");
            grc.AddLinkByNodeName("osm2769404025", "osm243312291", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link14");
            grc.AddLinkByNodeName("osm6373714855", "osm2769404025", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link15");
            grc.AddLinkByNodeName("osm243312239", "osm6373714855", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link16");
            grc.AddLinkByNodeName("osm3666040458", "osm243312239", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link17");
            grc.AddLinkByNodeName("osm5443078096", "osm3666040458", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link18");
            grc.AddLinkByNodeName("osm243312210", "osm5443078096", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link19");
            grc.AddLinkByNodeName("osm3666040648", "osm243312210", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link20");
            grc.AddLinkByNodeName("osm3666040647", "osm3666040648", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link21");
            grc.AddLinkByNodeName("osm3666040645", "osm3666040647", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee.link22");

            grc.AddLinkByNodeName("osm2245330472", "osm33702006", usetype: LinkUse.slowroad, comment: "An der Winkelwiese.link1");
            grc.AddLinkByNodeName("osm2697503323", "osm2245330472", usetype: LinkUse.slowroad, comment: "An der Winkelwiese.link2");
            grc.AddLinkByNodeName("osm5455174268", "osm2697503323", usetype: LinkUse.slowroad, comment: "An der Winkelwiese.link3");
            grc.AddLinkByNodeName("osm243312298", "osm5455174268", usetype: LinkUse.slowroad, comment: "An der Winkelwiese.link4");

            grc.AddLinkByNodeName("osm33702008", "osm33702006", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse.link1");

            grc.AddLinkByNodeName("osm3662352904", "osm33702008", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse01.link1");
            grc.AddLinkByNodeName("osm3662353689", "osm3662352904", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse01.link2");
            grc.AddLinkByNodeName("osm456054460", "osm3662353689", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse01.link3");
            grc.AddLinkByNodeName("osm2761659548", "osm456054460", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse01.link4");

            grc.AddLinkByNodeName("osm2347271301", "osm33701942", usetype: LinkUse.road, comment: "secondary_link01.link1");
            grc.AddLinkByNodeName("osm3662352910", "osm2347271301", usetype: LinkUse.road, comment: "secondary_link01.link2");
            grc.AddLinkByNodeName("osm33701943", "osm3662352910", usetype: LinkUse.road, comment: "secondary_link01.link3");
            grc.AddLinkByNodeName("osm3662353589", "osm33701943", usetype: LinkUse.road, comment: "secondary_link01.link4");
            grc.AddLinkByNodeName("osm3662353587", "osm3662353589", usetype: LinkUse.road, comment: "secondary_link01.link5");
            grc.AddLinkByNodeName("osm266520730", "osm3662353587", usetype: LinkUse.road, comment: "secondary_link01.link6");
            grc.AddLinkByNodeName("osm33482004", "osm266520730", usetype: LinkUse.road, comment: "secondary_link01.link7");

            grc.AddLinkByNodeName("osm5891568362", "osm33702044", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse.link1");

            grc.AddLinkByNodeName("osm434631896", "osm434631893", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse01.link1");

            grc.AddLinkByNodeName("osm3666040550", "osm3662352902", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse02.link1");
            grc.AddLinkByNodeName("osm33702044", "osm3666040550", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse02.link2");

            grc.AddLinkByNodeName("osm1881642037", "osm1106475589", usetype: LinkUse.slowroad, comment: "Anne-Frank-Strasse.link1");

            grc.AddLinkByNodeName("osm6638749507", "osm1587776905", usetype: LinkUse.road, comment: "primary01.link1");

            grc.AddLinkByNodeName("osm2347271303", "osm33701942", usetype: LinkUse.road, comment: "primary02.link1");
            grc.AddLinkByNodeName("osm2347271302", "osm2347271303", usetype: LinkUse.road, comment: "primary02.link2");
            grc.AddLinkByNodeName("osm3662352908", "osm2347271302", usetype: LinkUse.road, comment: "primary02.link3");
            grc.AddLinkByNodeName("osm33702434", "osm3662352908", usetype: LinkUse.road, comment: "primary02.link4");

            grc.AddLinkByNodeName("osm2347271310", "osm616247", usetype: LinkUse.road, comment: "secondary_link02.link1");
            grc.AddLinkByNodeName("osm6638749506", "osm2347271310", usetype: LinkUse.road, comment: "secondary_link02.link2");
            grc.AddLinkByNodeName("osm33482006", "osm6638749506", usetype: LinkUse.road, comment: "secondary_link02.link3");
            grc.AddLinkByNodeName("osm3662353711", "osm33482006", usetype: LinkUse.road, comment: "secondary_link02.link4");
            grc.AddLinkByNodeName("osm33701937", "osm3662353711", usetype: LinkUse.road, comment: "secondary_link02.link5");
            grc.AddLinkByNodeName("osm3662353710", "osm33701937", usetype: LinkUse.road, comment: "secondary_link02.link6");
            grc.AddLinkByNodeName("osm1881642050", "osm3662353710", usetype: LinkUse.road, comment: "secondary_link02.link7");
            grc.AddLinkByNodeName("osm3662353708", "osm1881642050", usetype: LinkUse.road, comment: "secondary_link02.link8");
            grc.AddLinkByNodeName("osm33702330", "osm3662353708", usetype: LinkUse.road, comment: "secondary_link02.link9");
            grc.AddLinkByNodeName("osm33701936", "osm33702330", usetype: LinkUse.road, comment: "secondary_link02.link10");
            grc.AddLinkByNodeName("osm2347271307", "osm33701936", usetype: LinkUse.road, comment: "secondary_link02.link11");
            grc.AddLinkByNodeName("osm2347271306", "osm2347271307", usetype: LinkUse.road, comment: "secondary_link02.link12");
            grc.AddLinkByNodeName("osm33701950", "osm2347271306", usetype: LinkUse.road, comment: "secondary_link02.link13");
            grc.AddLinkByNodeName("osm33701935", "osm33701950", usetype: LinkUse.road, comment: "secondary_link02.link14");
            grc.AddLinkByNodeName("osm3662353700", "osm33701935", usetype: LinkUse.road, comment: "secondary_link02.link15");
            grc.AddLinkByNodeName("osm33701944", "osm3662353700", usetype: LinkUse.road, comment: "secondary_link02.link16");

            grc.AddLinkByNodeName("osm456054459", "osm5891568362", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link1");
            grc.AddLinkByNodeName("osm3666040363", "osm456054459", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link2");
            grc.AddLinkByNodeName("osm434631885", "osm3666040363", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link3");
            grc.AddLinkByNodeName("osm3666040353", "osm434631885", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link4");
            grc.AddLinkByNodeName("osm3666040300", "osm3666040353", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link5");
            grc.AddLinkByNodeName("osm3662353685", "osm3666040300", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link6");
            grc.AddLinkByNodeName("osm3666040294", "osm3662353685", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link7");
            grc.AddLinkByNodeName("osm3662353686", "osm3666040294", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link8");
            grc.AddLinkByNodeName("osm434631889", "osm3662353686", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link9");
            grc.AddLinkByNodeName("osm3666040217", "osm434631889", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link10");
            grc.AddLinkByNodeName("osm3662353683", "osm3666040217", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link11");
            grc.AddLinkByNodeName("osm434631893", "osm3662353683", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link12");
            grc.AddLinkByNodeName("osm33702925", "osm434631893", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse02.link13");

            grc.AddLinkByNodeName("osm2245330467", "osm33702044", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse03.link1");
            grc.AddLinkByNodeName("osm33702006", "osm2245330467", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse03.link2");

            grc.AddLinkByNodeName("osm5457326850", "osm738283754", usetype: LinkUse.slowroad, comment: "Pestalozzistrasse.link1");
            grc.AddLinkByNodeName("osm3665957604", "osm5457326850", usetype: LinkUse.slowroad, comment: "Pestalozzistrasse.link2");
            grc.AddLinkByNodeName("osm3665957603", "osm3665957604", usetype: LinkUse.slowroad, comment: "Pestalozzistrasse.link3");
            grc.AddLinkByNodeName("osm33702924", "osm3665957603", usetype: LinkUse.slowroad, comment: "Pestalozzistrasse.link4");
            grc.AddLinkByNodeName("osm5548868468", "osm33702924", usetype: LinkUse.slowroad, comment: "Pestalozzistrasse.link5");
            grc.AddLinkByNodeName("osm33702925", "osm5548868468", usetype: LinkUse.slowroad, comment: "Pestalozzistrasse.link6");
            grc.AddLinkByNodeName("osm3665957584", "osm33702925", usetype: LinkUse.slowroad, comment: "Pestalozzistrasse.link7");
            grc.AddLinkByNodeName("osm33702899", "osm3665957584", usetype: LinkUse.slowroad, comment: "Pestalozzistrasse.link8");

            grc.AddLinkByNodeName("osm449011090", "osm33701960", usetype: LinkUse.road, comment: "primary03.link1");
            grc.AddLinkByNodeName("osm3662352911", "osm449011090", usetype: LinkUse.road, comment: "primary03.link2");
            grc.AddLinkByNodeName("osm2347271304", "osm3662352911", usetype: LinkUse.road, comment: "primary03.link3");
            grc.AddLinkByNodeName("osm3662352915", "osm2347271304", usetype: LinkUse.road, comment: "primary03.link4");
            grc.AddLinkByNodeName("osm33701944", "osm3662352915", usetype: LinkUse.road, comment: "primary03.link5");
            grc.AddLinkByNodeName("osm1587776903", "osm33701944", usetype: LinkUse.road, comment: "primary03.link6");

            grc.AddLinkByNodeName("osm33701942", "osm1587776903", usetype: LinkUse.road, comment: "primary04.link1");

            grc.AddLinkByNodeName("osm3662352901", "osm3662352900", usetype: LinkUse.slowroad, comment: "Noerdliche Ringstrasse04.link1");
            grc.AddLinkByNodeName("osm33702042", "osm3662352901", usetype: LinkUse.slowroad, comment: "Noerdliche Ringstrasse04.link2");
            grc.AddLinkByNodeName("osm1881642018", "osm33702042", usetype: LinkUse.slowroad, comment: "Noerdliche Ringstrasse04.link3");
            grc.AddLinkByNodeName("osm667020999", "osm1881642018", usetype: LinkUse.slowroad, comment: "Noerdliche Ringstrasse04.link4");

            grc.AddLinkByNodeName("osm268560288", "osm3666040645", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee01.link1");
            grc.AddLinkByNodeName("osm2245330484", "osm268560288", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee01.link2");
            grc.AddLinkByNodeName("osm2137895182", "osm2245330484", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee01.link3");
            grc.AddLinkByNodeName("osm243312243", "osm2137895182", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee01.link4");

            grc.AddLinkByNodeName("osm5891573270", "osm3662352902", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse05.link1");

            grc.AddLinkByNodeName("osm5891573270", "osm243312243", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee02.link1");

            grc.AddLinkByNodeName("osm5891573270", "osm738283754", usetype: LinkUse.slowroad, comment: "Pestalozzistrasse01.link1");

            grc.AddLinkByNodeName("osm5926244886", "osm5891573270", usetype: LinkUse.slowroad, comment: "Noerdliche Ringstrasse06.link1");
            grc.AddLinkByNodeName("osm667020999", "osm5926244886", usetype: LinkUse.slowroad, comment: "Noerdliche Ringstrasse06.link2");

            grc.AddLinkByNodeName("osm6373714863", "osm6373715030", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link1");
            grc.AddLinkByNodeName("osm6373714864", "osm6373714863", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link2");
            grc.AddLinkByNodeName("osm6373714865", "osm6373714864", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link3");
            grc.AddLinkByNodeName("osm6373714866", "osm6373714865", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link4");
            grc.AddLinkByNodeName("osm6373714867", "osm6373714866", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link5");
            grc.AddLinkByNodeName("osm6373714862", "osm6373714867", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link6");
            grc.AddLinkByNodeName("osm6373714868", "osm6373714862", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link7");
            grc.AddLinkByNodeName("osm6373714861", "osm6373714868", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link8");
            grc.AddLinkByNodeName("osm6373714848", "osm6373714861", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link9");
            grc.AddLinkByNodeName("osm6373714860", "osm6373714848", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link10");
            grc.AddLinkByNodeName("osm6373714859", "osm6373714860", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link11");
            grc.AddLinkByNodeName("osm6373714858", "osm6373714859", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link12");
            grc.AddLinkByNodeName("osm6373714857", "osm6373714858", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link13");
            grc.AddLinkByNodeName("osm6373714856", "osm6373714857", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link14");
            grc.AddLinkByNodeName("osm6373714855", "osm6373714856", usetype: LinkUse.slowroad, comment: "Am Dornbusch.link15");

            grc.AddLinkByNodeName("osm6638749509", "osm6638749507", usetype: LinkUse.road, comment: "primary05.link1");
            grc.AddLinkByNodeName("osm1587776903", "osm6638749509", usetype: LinkUse.road, comment: "primary05.link2");

            grc.AddLinkByNodeName("osm2137895151", "osm2137895149", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link1");
            grc.AddLinkByNodeName("osm2137895137", "osm2137895151", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link2");
            grc.AddLinkByNodeName("osm2137895138", "osm2137895137", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link3");
            grc.AddLinkByNodeName("osm2137895129", "osm2137895138", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link4");
            grc.AddLinkByNodeName("osm2137895130", "osm2137895129", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link5");
            grc.AddLinkByNodeName("osm2137895147", "osm2137895130", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link6");
            grc.AddLinkByNodeName("osm2137895148", "osm2137895147", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link7");
            grc.AddLinkByNodeName("osm2137895154", "osm2137895148", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link8");
            grc.AddLinkByNodeName("osm2137895155", "osm2137895154", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link9");
            grc.AddLinkByNodeName("osm2137895135", "osm2137895155", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link10");
            grc.AddLinkByNodeName("osm2137895136", "osm2137895135", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link11");
            grc.AddLinkByNodeName("osm2137895150", "osm2137895136", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link12");
            grc.AddLinkByNodeName("osm2137895153", "osm2137895150", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link13");
            grc.AddLinkByNodeName("osm2137895156", "osm2137895153", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link14");
            grc.AddLinkByNodeName("osm2137895157", "osm2137895156", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link15");
            grc.AddLinkByNodeName("osm2137895133", "osm2137895157", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link16");
            grc.AddLinkByNodeName("osm2137895134", "osm2137895133", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link17");
            grc.AddLinkByNodeName("osm2137895131", "osm2137895134", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link18");
            grc.AddLinkByNodeName("osm2137895121", "osm2137895131", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link19");
            grc.AddLinkByNodeName("osm2137895120", "osm2137895121", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link20");
            grc.AddLinkByNodeName("osm2137895119", "osm2137895120", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link21");
            grc.AddLinkByNodeName("osm2137895118", "osm2137895119", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link22");
            grc.AddLinkByNodeName("osm2137895128", "osm2137895118", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link23");
            grc.AddLinkByNodeName("osm3666029366", "osm2137895128", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link24");
            grc.AddLinkByNodeName("osm3666040376", "osm3666029366", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link25");
            grc.AddLinkByNodeName("osm3666040373", "osm3666040376", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link26");
            grc.AddLinkByNodeName("osm3666029365", "osm3666040373", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link27");
            grc.AddLinkByNodeName("osm2137895127", "osm3666029365", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link28");
            grc.AddLinkByNodeName("osm2137895117", "osm2137895127", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link29");
            grc.AddLinkByNodeName("osm2137895116", "osm2137895117", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link30");
            grc.AddLinkByNodeName("osm2137895126", "osm2137895116", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link31");
            grc.AddLinkByNodeName("osm2137895125", "osm2137895126", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link32");
            grc.AddLinkByNodeName("osm2137895124", "osm2137895125", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link33");
            grc.AddLinkByNodeName("osm2137895122", "osm2137895124", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link34");
            grc.AddLinkByNodeName("osm2137895149", "osm2137895122", usetype: LinkUse.bldwall, comment: "DRK-Senioren-Zentrum Langen gemeinnuetzige GmbH.link35");

            grc.AddLinkByNodeName("osm3177096960", "osm3177096959", usetype: LinkUse.bldwall, comment: "house01.link1");
            grc.AddLinkByNodeName("osm3177098461", "osm3177096960", usetype: LinkUse.bldwall, comment: "house01.link2");
            grc.AddLinkByNodeName("osm3177098462", "osm3177098461", usetype: LinkUse.bldwall, comment: "house01.link3");
            grc.AddLinkByNodeName("osm3177096959", "osm3177098462", usetype: LinkUse.bldwall, comment: "house01.link4");

            grc.AddLinkByNodeName("osm3666040533", "osm3177098463", usetype: LinkUse.bldwall, comment: "bld01.link1");
            grc.AddLinkByNodeName("osm3666040528", "osm3666040533", usetype: LinkUse.bldwall, comment: "bld01.link2");
            grc.AddLinkByNodeName("osm3666040532", "osm3666040528", usetype: LinkUse.bldwall, comment: "bld01.link3");
            grc.AddLinkByNodeName("osm3666040538", "osm3666040532", usetype: LinkUse.bldwall, comment: "bld01.link4");
            grc.AddLinkByNodeName("osm3177098464", "osm3666040538", usetype: LinkUse.bldwall, comment: "bld01.link5");
            grc.AddLinkByNodeName("osm3177098465", "osm3177098464", usetype: LinkUse.bldwall, comment: "bld01.link6");
            grc.AddLinkByNodeName("osm3666040541", "osm3177098465", usetype: LinkUse.bldwall, comment: "bld01.link7");
            grc.AddLinkByNodeName("osm3177098466", "osm3666040541", usetype: LinkUse.bldwall, comment: "bld01.link8");
            grc.AddLinkByNodeName("osm3666040527", "osm3177098466", usetype: LinkUse.bldwall, comment: "bld01.link9");
            grc.AddLinkByNodeName("osm3666040525", "osm3666040527", usetype: LinkUse.bldwall, comment: "bld01.link10");
            grc.AddLinkByNodeName("osm3177098467", "osm3666040525", usetype: LinkUse.bldwall, comment: "bld01.link11");
            grc.AddLinkByNodeName("osm3666040397", "osm3177098467", usetype: LinkUse.bldwall, comment: "bld01.link12");
            grc.AddLinkByNodeName("osm3666040400", "osm3666040397", usetype: LinkUse.bldwall, comment: "bld01.link13");
            grc.AddLinkByNodeName("osm3177098468", "osm3666040400", usetype: LinkUse.bldwall, comment: "bld01.link14");
            grc.AddLinkByNodeName("osm3177098463", "osm3177098468", usetype: LinkUse.bldwall, comment: "bld01.link15");

            grc.AddLinkByNodeName("osm344604967", "osm3472027587", usetype: LinkUse.bldwall, comment: "Aldi.link1");
            grc.AddLinkByNodeName("osm3472027591", "osm344604967", usetype: LinkUse.bldwall, comment: "Aldi.link2");
            grc.AddLinkByNodeName("osm3472027593", "osm3472027591", usetype: LinkUse.bldwall, comment: "Aldi.link3");
            grc.AddLinkByNodeName("osm3472027592", "osm3472027593", usetype: LinkUse.bldwall, comment: "Aldi.link4");
            grc.AddLinkByNodeName("osm3472027596", "osm3472027592", usetype: LinkUse.bldwall, comment: "Aldi.link5");
            grc.AddLinkByNodeName("osm3472027597", "osm3472027596", usetype: LinkUse.bldwall, comment: "Aldi.link6");
            grc.AddLinkByNodeName("osm3472027598", "osm3472027597", usetype: LinkUse.bldwall, comment: "Aldi.link7");
            grc.AddLinkByNodeName("osm3472027599", "osm3472027598", usetype: LinkUse.bldwall, comment: "Aldi.link8");
            grc.AddLinkByNodeName("osm3472027594", "osm3472027599", usetype: LinkUse.bldwall, comment: "Aldi.link9");
            grc.AddLinkByNodeName("osm3472027595", "osm3472027594", usetype: LinkUse.bldwall, comment: "Aldi.link10");
            grc.AddLinkByNodeName("osm3472027590", "osm3472027595", usetype: LinkUse.bldwall, comment: "Aldi.link11");
            grc.AddLinkByNodeName("osm3472027589", "osm3472027590", usetype: LinkUse.bldwall, comment: "Aldi.link12");
            grc.AddLinkByNodeName("osm3472027588", "osm3472027589", usetype: LinkUse.bldwall, comment: "Aldi.link13");
            grc.AddLinkByNodeName("osm3472027587", "osm3472027588", usetype: LinkUse.bldwall, comment: "Aldi.link14");

            grc.AddLinkByNodeName("osm3472027608", "osm3472027603", usetype: LinkUse.bldwall, comment: "Rossmann.link1");
            grc.AddLinkByNodeName("osm3472027609", "osm3472027608", usetype: LinkUse.bldwall, comment: "Rossmann.link2");
            grc.AddLinkByNodeName("osm3472027606", "osm3472027609", usetype: LinkUse.bldwall, comment: "Rossmann.link3");
            grc.AddLinkByNodeName("osm3472027603", "osm3472027606", usetype: LinkUse.bldwall, comment: "Rossmann.link4");

            grc.AddLinkByNodeName("osm3472027600", "osm344604976", usetype: LinkUse.bldwall, comment: "Rewe.link1");
            grc.AddLinkByNodeName("osm3472027602", "osm3472027600", usetype: LinkUse.bldwall, comment: "Rewe.link2");
            grc.AddLinkByNodeName("osm3472027604", "osm3472027602", usetype: LinkUse.bldwall, comment: "Rewe.link3");
            grc.AddLinkByNodeName("osm3666040459", "osm3472027604", usetype: LinkUse.bldwall, comment: "Rewe.link4");
            grc.AddLinkByNodeName("osm3472027607", "osm3666040459", usetype: LinkUse.bldwall, comment: "Rewe.link5");
            grc.AddLinkByNodeName("osm3472027601", "osm3472027607", usetype: LinkUse.bldwall, comment: "Rewe.link6");
            grc.AddLinkByNodeName("osm344604976", "osm3472027601", usetype: LinkUse.bldwall, comment: "Rewe.link7");

            grc.AddLinkByNodeName("osm2320845707", "osm3472027600", usetype: LinkUse.bldwall, comment: "Rewe Getraenkemarkt.link1");
            grc.AddLinkByNodeName("osm3472027605", "osm2320845707", usetype: LinkUse.bldwall, comment: "Rewe Getraenkemarkt.link2");
            grc.AddLinkByNodeName("osm3472027604", "osm3472027605", usetype: LinkUse.bldwall, comment: "Rewe Getraenkemarkt.link3");
            grc.AddLinkByNodeName("osm3472027602", "osm3472027604", usetype: LinkUse.bldwall, comment: "Rewe Getraenkemarkt.link4");
            grc.AddLinkByNodeName("osm3472027600", "osm3472027602", usetype: LinkUse.bldwall, comment: "Rewe Getraenkemarkt.link5");

            grc.AddLinkByNodeName("osm3634590167", "osm3634590166", usetype: LinkUse.bldwall, comment: "dm.link1");
            grc.AddLinkByNodeName("osm5891559543", "osm3634590167", usetype: LinkUse.bldwall, comment: "dm.link2");
            grc.AddLinkByNodeName("osm5891559542", "osm5891559543", usetype: LinkUse.bldwall, comment: "dm.link3");
            grc.AddLinkByNodeName("osm3634590168", "osm5891559542", usetype: LinkUse.bldwall, comment: "dm.link4");
            grc.AddLinkByNodeName("osm3634590169", "osm3634590168", usetype: LinkUse.bldwall, comment: "dm.link5");
            grc.AddLinkByNodeName("osm3634590166", "osm3634590169", usetype: LinkUse.bldwall, comment: "dm.link6");

            grc.AddLinkByNodeName("osm3666040574", "osm3666040572", usetype: LinkUse.bldwall, comment: "bld02.link1");
            grc.AddLinkByNodeName("osm3666040577", "osm3666040574", usetype: LinkUse.bldwall, comment: "bld02.link2");
            grc.AddLinkByNodeName("osm3666040565", "osm3666040577", usetype: LinkUse.bldwall, comment: "bld02.link3");
            grc.AddLinkByNodeName("osm3666040563", "osm3666040565", usetype: LinkUse.bldwall, comment: "bld02.link4");
            grc.AddLinkByNodeName("osm3666040559", "osm3666040563", usetype: LinkUse.bldwall, comment: "bld02.link5");
            grc.AddLinkByNodeName("osm3666040553", "osm3666040559", usetype: LinkUse.bldwall, comment: "bld02.link6");
            grc.AddLinkByNodeName("osm3666040558", "osm3666040553", usetype: LinkUse.bldwall, comment: "bld02.link7");
            grc.AddLinkByNodeName("osm3666040557", "osm3666040558", usetype: LinkUse.bldwall, comment: "bld02.link8");
            grc.AddLinkByNodeName("osm3666040570", "osm3666040557", usetype: LinkUse.bldwall, comment: "bld02.link9");
            grc.AddLinkByNodeName("osm3666040572", "osm3666040570", usetype: LinkUse.bldwall, comment: "bld02.link10");

            grc.AddLinkByNodeName("osm3666040640", "osm3666040641", usetype: LinkUse.bldwall, comment: "bld03.link1");
            grc.AddLinkByNodeName("osm3666040639", "osm3666040640", usetype: LinkUse.bldwall, comment: "bld03.link2");
            grc.AddLinkByNodeName("osm3666040635", "osm3666040639", usetype: LinkUse.bldwall, comment: "bld03.link3");
            grc.AddLinkByNodeName("osm3666040636", "osm3666040635", usetype: LinkUse.bldwall, comment: "bld03.link4");
            grc.AddLinkByNodeName("osm3666040633", "osm3666040636", usetype: LinkUse.bldwall, comment: "bld03.link5");
            grc.AddLinkByNodeName("osm3666040634", "osm3666040633", usetype: LinkUse.bldwall, comment: "bld03.link6");
            grc.AddLinkByNodeName("osm3666040644", "osm3666040634", usetype: LinkUse.bldwall, comment: "bld03.link7");
            grc.AddLinkByNodeName("osm3666040643", "osm3666040644", usetype: LinkUse.bldwall, comment: "bld03.link8");
            grc.AddLinkByNodeName("osm3666040642", "osm3666040643", usetype: LinkUse.bldwall, comment: "bld03.link9");
            grc.AddLinkByNodeName("osm3666040641", "osm3666040642", usetype: LinkUse.bldwall, comment: "bld03.link10");

            grc.AddLinkByNodeName("osm3666040537", "osm3666040545", usetype: LinkUse.bldwall, comment: "bld04.link1");
            grc.AddLinkByNodeName("osm3666040535", "osm3666040537", usetype: LinkUse.bldwall, comment: "bld04.link2");
            grc.AddLinkByNodeName("osm3666040556", "osm3666040535", usetype: LinkUse.bldwall, comment: "bld04.link3");
            grc.AddLinkByNodeName("osm3666040560", "osm3666040556", usetype: LinkUse.bldwall, comment: "bld04.link4");
            grc.AddLinkByNodeName("osm3666040569", "osm3666040560", usetype: LinkUse.bldwall, comment: "bld04.link5");
            grc.AddLinkByNodeName("osm3666040570", "osm3666040569", usetype: LinkUse.bldwall, comment: "bld04.link6");
            grc.AddLinkByNodeName("osm3666040557", "osm3666040570", usetype: LinkUse.bldwall, comment: "bld04.link7");
            grc.AddLinkByNodeName("osm3666040549", "osm3666040557", usetype: LinkUse.bldwall, comment: "bld04.link8");
            grc.AddLinkByNodeName("osm3666040546", "osm3666040549", usetype: LinkUse.bldwall, comment: "bld04.link9");
            grc.AddLinkByNodeName("osm3666040545", "osm3666040546", usetype: LinkUse.bldwall, comment: "bld04.link10");

            grc.AddLinkByNodeName("osm3666039952", "osm3666039920", usetype: LinkUse.bldwall, comment: "bld05.link1");
            grc.AddLinkByNodeName("osm3666039901", "osm3666039952", usetype: LinkUse.bldwall, comment: "bld05.link2");
            grc.AddLinkByNodeName("osm3666039891", "osm3666039901", usetype: LinkUse.bldwall, comment: "bld05.link3");
            grc.AddLinkByNodeName("osm3666039742", "osm3666039891", usetype: LinkUse.bldwall, comment: "bld05.link4");
            grc.AddLinkByNodeName("osm3666039747", "osm3666039742", usetype: LinkUse.bldwall, comment: "bld05.link5");
            grc.AddLinkByNodeName("osm3666039957", "osm3666039747", usetype: LinkUse.bldwall, comment: "bld05.link6");
            grc.AddLinkByNodeName("osm3666039956", "osm3666039957", usetype: LinkUse.bldwall, comment: "bld05.link7");
            grc.AddLinkByNodeName("osm3666039973", "osm3666039956", usetype: LinkUse.bldwall, comment: "bld05.link8");
            grc.AddLinkByNodeName("osm3666039972", "osm3666039973", usetype: LinkUse.bldwall, comment: "bld05.link9");
            grc.AddLinkByNodeName("osm3666033019", "osm3666039972", usetype: LinkUse.bldwall, comment: "bld05.link10");
            grc.AddLinkByNodeName("osm3666033012", "osm3666033019", usetype: LinkUse.bldwall, comment: "bld05.link11");
            grc.AddLinkByNodeName("osm3666039920", "osm3666033012", usetype: LinkUse.bldwall, comment: "bld05.link12");

            grc.AddLinkByNodeName("osm3666040003", "osm3666040151", usetype: LinkUse.bldwall, comment: "bld06.link1");
            grc.AddLinkByNodeName("osm3666040132", "osm3666040003", usetype: LinkUse.bldwall, comment: "bld06.link2");
            grc.AddLinkByNodeName("osm3666039986", "osm3666040132", usetype: LinkUse.bldwall, comment: "bld06.link3");
            grc.AddLinkByNodeName("osm3666039988", "osm3666039986", usetype: LinkUse.bldwall, comment: "bld06.link4");
            grc.AddLinkByNodeName("osm3666039992", "osm3666039988", usetype: LinkUse.bldwall, comment: "bld06.link5");
            grc.AddLinkByNodeName("osm3666039993", "osm3666039992", usetype: LinkUse.bldwall, comment: "bld06.link6");
            grc.AddLinkByNodeName("osm3666040007", "osm3666039993", usetype: LinkUse.bldwall, comment: "bld06.link7");
            grc.AddLinkByNodeName("osm3666040023", "osm3666040007", usetype: LinkUse.bldwall, comment: "bld06.link8");
            grc.AddLinkByNodeName("osm3666040158", "osm3666040023", usetype: LinkUse.bldwall, comment: "bld06.link9");
            grc.AddLinkByNodeName("osm3666040155", "osm3666040158", usetype: LinkUse.bldwall, comment: "bld06.link10");
            grc.AddLinkByNodeName("osm3666040022", "osm3666040155", usetype: LinkUse.bldwall, comment: "bld06.link11");
            grc.AddLinkByNodeName("osm3666040021", "osm3666040022", usetype: LinkUse.bldwall, comment: "bld06.link12");
            grc.AddLinkByNodeName("osm3666040014", "osm3666040021", usetype: LinkUse.bldwall, comment: "bld06.link13");
            grc.AddLinkByNodeName("osm3666040151", "osm3666040014", usetype: LinkUse.bldwall, comment: "bld06.link14");

            grc.AddLinkByNodeName("osm3666040278", "osm3666040195", usetype: LinkUse.bldwall, comment: "bld07.link1");
            grc.AddLinkByNodeName("osm3666040193", "osm3666040278", usetype: LinkUse.bldwall, comment: "bld07.link2");
            grc.AddLinkByNodeName("osm3666040194", "osm3666040193", usetype: LinkUse.bldwall, comment: "bld07.link3");
            grc.AddLinkByNodeName("osm3666040190", "osm3666040194", usetype: LinkUse.bldwall, comment: "bld07.link4");
            grc.AddLinkByNodeName("osm3666040184", "osm3666040190", usetype: LinkUse.bldwall, comment: "bld07.link5");
            grc.AddLinkByNodeName("osm3666040042", "osm3666040184", usetype: LinkUse.bldwall, comment: "bld07.link6");
            grc.AddLinkByNodeName("osm3666040186", "osm3666040042", usetype: LinkUse.bldwall, comment: "bld07.link7");
            grc.AddLinkByNodeName("osm3666040253", "osm3666040186", usetype: LinkUse.bldwall, comment: "bld07.link8");
            grc.AddLinkByNodeName("osm3666040249", "osm3666040253", usetype: LinkUse.bldwall, comment: "bld07.link9");
            grc.AddLinkByNodeName("osm3666040252", "osm3666040249", usetype: LinkUse.bldwall, comment: "bld07.link10");
            grc.AddLinkByNodeName("osm3666040250", "osm3666040252", usetype: LinkUse.bldwall, comment: "bld07.link11");
            grc.AddLinkByNodeName("osm3666040180", "osm3666040250", usetype: LinkUse.bldwall, comment: "bld07.link12");
            grc.AddLinkByNodeName("osm3666040174", "osm3666040180", usetype: LinkUse.bldwall, comment: "bld07.link13");
            grc.AddLinkByNodeName("osm3666040247", "osm3666040174", usetype: LinkUse.bldwall, comment: "bld07.link14");
            grc.AddLinkByNodeName("osm3666040244", "osm3666040247", usetype: LinkUse.bldwall, comment: "bld07.link15");
            grc.AddLinkByNodeName("osm3666040173", "osm3666040244", usetype: LinkUse.bldwall, comment: "bld07.link16");
            grc.AddLinkByNodeName("osm3666040241", "osm3666040173", usetype: LinkUse.bldwall, comment: "bld07.link17");
            grc.AddLinkByNodeName("osm3666040176", "osm3666040241", usetype: LinkUse.bldwall, comment: "bld07.link18");
            grc.AddLinkByNodeName("osm3666040171", "osm3666040176", usetype: LinkUse.bldwall, comment: "bld07.link19");
            grc.AddLinkByNodeName("osm3666040239", "osm3666040171", usetype: LinkUse.bldwall, comment: "bld07.link20");
            grc.AddLinkByNodeName("osm3666040183", "osm3666040239", usetype: LinkUse.bldwall, comment: "bld07.link21");
            grc.AddLinkByNodeName("osm3666040258", "osm3666040183", usetype: LinkUse.bldwall, comment: "bld07.link22");
            grc.AddLinkByNodeName("osm3666040195", "osm3666040258", usetype: LinkUse.bldwall, comment: "bld07.link23");

            grc.AddLinkByNodeName("osm3666040135", "osm3666040161", usetype: LinkUse.bldwall, comment: "bld08.link1");
            grc.AddLinkByNodeName("osm3666040138", "osm3666040135", usetype: LinkUse.bldwall, comment: "bld08.link2");
            grc.AddLinkByNodeName("osm3666040024", "osm3666040138", usetype: LinkUse.bldwall, comment: "bld08.link3");
            grc.AddLinkByNodeName("osm3666040161", "osm3666040024", usetype: LinkUse.bldwall, comment: "bld08.link4");

            grc.AddLinkByNodeName("osm3666040200", "osm3666040337", usetype: LinkUse.bldwall, comment: "bld09.link1");
            grc.AddLinkByNodeName("osm3666040201", "osm3666040200", usetype: LinkUse.bldwall, comment: "bld09.link2");
            grc.AddLinkByNodeName("osm3666040339", "osm3666040201", usetype: LinkUse.bldwall, comment: "bld09.link3");
            grc.AddLinkByNodeName("osm3666040337", "osm3666040339", usetype: LinkUse.bldwall, comment: "bld09.link4");

            grc.AddLinkByNodeName("osm3666040012", "osm3666039991", usetype: LinkUse.bldwall, comment: "bld10.link1");
            grc.AddLinkByNodeName("osm3666040011", "osm3666040012", usetype: LinkUse.bldwall, comment: "bld10.link2");
            grc.AddLinkByNodeName("osm3666039990", "osm3666040011", usetype: LinkUse.bldwall, comment: "bld10.link3");
            grc.AddLinkByNodeName("osm3666039991", "osm3666039990", usetype: LinkUse.bldwall, comment: "bld10.link4");

            grc.AddLinkByNodeName("osm3666040367", "osm3666040368", usetype: LinkUse.bldwall, comment: "bld11.link1");
            grc.AddLinkByNodeName("osm3666040318", "osm3666040367", usetype: LinkUse.bldwall, comment: "bld11.link2");
            grc.AddLinkByNodeName("osm3666040319", "osm3666040318", usetype: LinkUse.bldwall, comment: "bld11.link3");
            grc.AddLinkByNodeName("osm3666040368", "osm3666040319", usetype: LinkUse.bldwall, comment: "bld11.link4");

            grc.AddLinkByNodeName("osm3666040009", "osm3666040007", usetype: LinkUse.bldwall, comment: "bld12.link1");
            grc.AddLinkByNodeName("osm3666040152", "osm3666040009", usetype: LinkUse.bldwall, comment: "bld12.link2");
            grc.AddLinkByNodeName("osm3666040023", "osm3666040152", usetype: LinkUse.bldwall, comment: "bld12.link3");
            grc.AddLinkByNodeName("osm3666040007", "osm3666040023", usetype: LinkUse.bldwall, comment: "bld12.link4");

            grc.AddLinkByNodeName("osm3666039958", "osm3666039968", usetype: LinkUse.bldwall, comment: "bld13.link1");
            grc.AddLinkByNodeName("osm3666039959", "osm3666039958", usetype: LinkUse.bldwall, comment: "bld13.link2");
            grc.AddLinkByNodeName("osm3666039969", "osm3666039959", usetype: LinkUse.bldwall, comment: "bld13.link3");
            grc.AddLinkByNodeName("osm3666039968", "osm3666039969", usetype: LinkUse.bldwall, comment: "bld13.link4");

            grc.AddLinkByNodeName("osm3666040391", "osm3666040452", usetype: LinkUse.bldwall, comment: "bld14.link1");
            grc.AddLinkByNodeName("osm3666040448", "osm3666040391", usetype: LinkUse.bldwall, comment: "bld14.link2");
            grc.AddLinkByNodeName("osm3666040453", "osm3666040448", usetype: LinkUse.bldwall, comment: "bld14.link3");
            grc.AddLinkByNodeName("osm3666040452", "osm3666040453", usetype: LinkUse.bldwall, comment: "bld14.link4");

            grc.AddLinkByNodeName("osm3666040124", "osm3666040549", usetype: LinkUse.bldwall, comment: "bld15.link1");
            grc.AddLinkByNodeName("osm3666040122", "osm3666040124", usetype: LinkUse.bldwall, comment: "bld15.link2");
            grc.AddLinkByNodeName("osm3666040546", "osm3666040122", usetype: LinkUse.bldwall, comment: "bld15.link3");
            grc.AddLinkByNodeName("osm3666040549", "osm3666040546", usetype: LinkUse.bldwall, comment: "bld15.link4");

            grc.AddLinkByNodeName("osm3666040039", "osm3666040016", usetype: LinkUse.bldwall, comment: "bld16.link1");
            grc.AddLinkByNodeName("osm3666040040", "osm3666040039", usetype: LinkUse.bldwall, comment: "bld16.link2");
            grc.AddLinkByNodeName("osm3666040017", "osm3666040040", usetype: LinkUse.bldwall, comment: "bld16.link3");
            grc.AddLinkByNodeName("osm3666040016", "osm3666040017", usetype: LinkUse.bldwall, comment: "bld16.link4");

            grc.AddLinkByNodeName("osm3666040182", "osm3666040191", usetype: LinkUse.bldwall, comment: "bld17.link1");
            grc.AddLinkByNodeName("osm3666040251", "osm3666040182", usetype: LinkUse.bldwall, comment: "bld17.link2");
            grc.AddLinkByNodeName("osm3666040189", "osm3666040251", usetype: LinkUse.bldwall, comment: "bld17.link3");
            grc.AddLinkByNodeName("osm3666040191", "osm3666040189", usetype: LinkUse.bldwall, comment: "bld17.link4");

            grc.AddLinkByNodeName("osm3666040454", "osm3666040120", usetype: LinkUse.bldwall, comment: "bld18.link1");
            grc.AddLinkByNodeName("osm3666040456", "osm3666040454", usetype: LinkUse.bldwall, comment: "bld18.link2");
            grc.AddLinkByNodeName("osm3666040123", "osm3666040456", usetype: LinkUse.bldwall, comment: "bld18.link3");
            grc.AddLinkByNodeName("osm3666040120", "osm3666040123", usetype: LinkUse.bldwall, comment: "bld18.link4");

            grc.AddLinkByNodeName("osm3666040344", "osm3666040381", usetype: LinkUse.bldwall, comment: "bld19.link1");
            grc.AddLinkByNodeName("osm3666040345", "osm3666040344", usetype: LinkUse.bldwall, comment: "bld19.link2");
            grc.AddLinkByNodeName("osm3666029364", "osm3666040345", usetype: LinkUse.bldwall, comment: "bld19.link3");
            grc.AddLinkByNodeName("osm3666040381", "osm3666029364", usetype: LinkUse.bldwall, comment: "bld19.link4");

            grc.AddLinkByNodeName("osm3666040139", "osm3666040138", usetype: LinkUse.bldwall, comment: "bld20.link1");
            grc.AddLinkByNodeName("osm3666040225", "osm3666040139", usetype: LinkUse.bldwall, comment: "bld20.link2");
            grc.AddLinkByNodeName("osm3666040024", "osm3666040225", usetype: LinkUse.bldwall, comment: "bld20.link3");
            grc.AddLinkByNodeName("osm3666040138", "osm3666040024", usetype: LinkUse.bldwall, comment: "bld20.link4");

            grc.AddLinkByNodeName("osm3666040628", "osm3666040631", usetype: LinkUse.bldwall, comment: "bld21.link1");
            grc.AddLinkByNodeName("osm3666040626", "osm3666040628", usetype: LinkUse.bldwall, comment: "bld21.link2");
            grc.AddLinkByNodeName("osm3666040630", "osm3666040626", usetype: LinkUse.bldwall, comment: "bld21.link3");
            grc.AddLinkByNodeName("osm3666040631", "osm3666040630", usetype: LinkUse.bldwall, comment: "bld21.link4");

            grc.AddLinkByNodeName("osm3666040392", "osm3666040122", usetype: LinkUse.bldwall, comment: "bld22.link1");
            grc.AddLinkByNodeName("osm3666040393", "osm3666040392", usetype: LinkUse.bldwall, comment: "bld22.link2");
            grc.AddLinkByNodeName("osm3666040124", "osm3666040393", usetype: LinkUse.bldwall, comment: "bld22.link3");
            grc.AddLinkByNodeName("osm3666040122", "osm3666040124", usetype: LinkUse.bldwall, comment: "bld22.link4");

            grc.AddLinkByNodeName("osm3666040029", "osm3666040035", usetype: LinkUse.bldwall, comment: "bld23.link1");
            grc.AddLinkByNodeName("osm3666040030", "osm3666040029", usetype: LinkUse.bldwall, comment: "bld23.link2");
            grc.AddLinkByNodeName("osm3666039982", "osm3666040030", usetype: LinkUse.bldwall, comment: "bld23.link3");
            grc.AddLinkByNodeName("osm3666039983", "osm3666039982", usetype: LinkUse.bldwall, comment: "bld23.link4");
            grc.AddLinkByNodeName("osm3666040037", "osm3666039983", usetype: LinkUse.bldwall, comment: "bld23.link5");
            grc.AddLinkByNodeName("osm3666040035", "osm3666040037", usetype: LinkUse.bldwall, comment: "bld23.link6");

            grc.AddLinkByNodeName("osm3666040629", "osm3666040637", usetype: LinkUse.bldwall, comment: "bld24.link1");
            grc.AddLinkByNodeName("osm3666040630", "osm3666040629", usetype: LinkUse.bldwall, comment: "bld24.link2");
            grc.AddLinkByNodeName("osm3666040631", "osm3666040630", usetype: LinkUse.bldwall, comment: "bld24.link3");
            grc.AddLinkByNodeName("osm3666040632", "osm3666040631", usetype: LinkUse.bldwall, comment: "bld24.link4");
            grc.AddLinkByNodeName("osm3666040638", "osm3666040632", usetype: LinkUse.bldwall, comment: "bld24.link5");
            grc.AddLinkByNodeName("osm3666040637", "osm3666040638", usetype: LinkUse.bldwall, comment: "bld24.link6");

            grc.AddLinkByNodeName("osm3666040144", "osm3666040238", usetype: LinkUse.bldwall, comment: "bld25.link1");
            grc.AddLinkByNodeName("osm3666040145", "osm3666040144", usetype: LinkUse.bldwall, comment: "bld25.link2");
            grc.AddLinkByNodeName("osm3666040006", "osm3666040145", usetype: LinkUse.bldwall, comment: "bld25.link3");
            grc.AddLinkByNodeName("osm3666040010", "osm3666040006", usetype: LinkUse.bldwall, comment: "bld25.link4");
            grc.AddLinkByNodeName("osm3666040243", "osm3666040010", usetype: LinkUse.bldwall, comment: "bld25.link5");
            grc.AddLinkByNodeName("osm3666040238", "osm3666040243", usetype: LinkUse.bldwall, comment: "bld25.link6");

            grc.AddLinkByNodeName("osm2320845707", "osm3472027603", usetype: LinkUse.bldwall, comment: "bld26.link1");
            grc.AddLinkByNodeName("osm3472027605", "osm2320845707", usetype: LinkUse.bldwall, comment: "bld26.link2");
            grc.AddLinkByNodeName("osm3472027604", "osm3472027605", usetype: LinkUse.bldwall, comment: "bld26.link3");
            grc.AddLinkByNodeName("osm3666040459", "osm3472027604", usetype: LinkUse.bldwall, comment: "bld26.link4");
            grc.AddLinkByNodeName("osm5891623046", "osm3666040459", usetype: LinkUse.bldwall, comment: "bld26.link5");
            grc.AddLinkByNodeName("osm3666040460", "osm5891623046", usetype: LinkUse.bldwall, comment: "bld26.link6");
            grc.AddLinkByNodeName("osm3666040461", "osm3666040460", usetype: LinkUse.bldwall, comment: "bld26.link7");
            grc.AddLinkByNodeName("osm3472027608", "osm3666040461", usetype: LinkUse.bldwall, comment: "bld26.link8");
            grc.AddLinkByNodeName("osm3472027603", "osm3472027608", usetype: LinkUse.bldwall, comment: "bld26.link9");

            grc.AddLinkByNodeName("osm3666040196", "osm3666040261", usetype: LinkUse.bldwall, comment: "bld27.link1");
            grc.AddLinkByNodeName("osm3666040255", "osm3666040196", usetype: LinkUse.bldwall, comment: "bld27.link2");
            grc.AddLinkByNodeName("osm3666040048", "osm3666040255", usetype: LinkUse.bldwall, comment: "bld27.link3");
            grc.AddLinkByNodeName("osm3666040044", "osm3666040048", usetype: LinkUse.bldwall, comment: "bld27.link4");
            grc.AddLinkByNodeName("osm3666040183", "osm3666040044", usetype: LinkUse.bldwall, comment: "bld27.link5");
            grc.AddLinkByNodeName("osm3666040258", "osm3666040183", usetype: LinkUse.bldwall, comment: "bld27.link6");
            grc.AddLinkByNodeName("osm3666040288", "osm3666040258", usetype: LinkUse.bldwall, comment: "bld27.link7");
            grc.AddLinkByNodeName("osm3666040261", "osm3666040288", usetype: LinkUse.bldwall, comment: "bld27.link8");

            grc.AddLinkByNodeName("osm3666040299", "osm3666040298", usetype: LinkUse.bldwall, comment: "bld28.link1");
            grc.AddLinkByNodeName("osm3666040191", "osm3666040299", usetype: LinkUse.bldwall, comment: "bld28.link2");
            grc.AddLinkByNodeName("osm3666040189", "osm3666040191", usetype: LinkUse.bldwall, comment: "bld28.link3");
            grc.AddLinkByNodeName("osm3666040188", "osm3666040189", usetype: LinkUse.bldwall, comment: "bld28.link4");
            grc.AddLinkByNodeName("osm3666040215", "osm3666040188", usetype: LinkUse.bldwall, comment: "bld28.link5");
            grc.AddLinkByNodeName("osm3666040219", "osm3666040215", usetype: LinkUse.bldwall, comment: "bld28.link6");
            grc.AddLinkByNodeName("osm3666040297", "osm3666040219", usetype: LinkUse.bldwall, comment: "bld28.link7");
            grc.AddLinkByNodeName("osm3666040298", "osm3666040297", usetype: LinkUse.bldwall, comment: "bld28.link8");

            grc.AddLinkByNodeName("osm3666040319", "osm3666040368", usetype: LinkUse.bldwall, comment: "bld29.link1");
            grc.AddLinkByNodeName("osm3666040214", "osm3666040319", usetype: LinkUse.bldwall, comment: "bld29.link2");
            grc.AddLinkByNodeName("osm3666040215", "osm3666040214", usetype: LinkUse.bldwall, comment: "bld29.link3");
            grc.AddLinkByNodeName("osm3666040219", "osm3666040215", usetype: LinkUse.bldwall, comment: "bld29.link4");
            grc.AddLinkByNodeName("osm3666040297", "osm3666040219", usetype: LinkUse.bldwall, comment: "bld29.link5");
            grc.AddLinkByNodeName("osm3666040298", "osm3666040297", usetype: LinkUse.bldwall, comment: "bld29.link6");
            grc.AddLinkByNodeName("osm3666040369", "osm3666040298", usetype: LinkUse.bldwall, comment: "bld29.link7");
            grc.AddLinkByNodeName("osm3666040368", "osm3666040369", usetype: LinkUse.bldwall, comment: "bld29.link8");

            grc.AddLinkByNodeName("osm3666040547", "osm3666040541", usetype: LinkUse.bldwall, comment: "bld30.link1");
            grc.AddLinkByNodeName("osm3666040556", "osm3666040547", usetype: LinkUse.bldwall, comment: "bld30.link2");
            grc.AddLinkByNodeName("osm3666040535", "osm3666040556", usetype: LinkUse.bldwall, comment: "bld30.link3");
            grc.AddLinkByNodeName("osm3666040537", "osm3666040535", usetype: LinkUse.bldwall, comment: "bld30.link4");
            grc.AddLinkByNodeName("osm3666040531", "osm3666040537", usetype: LinkUse.bldwall, comment: "bld30.link5");
            grc.AddLinkByNodeName("osm3666040527", "osm3666040531", usetype: LinkUse.bldwall, comment: "bld30.link6");
            grc.AddLinkByNodeName("osm3177098466", "osm3666040527", usetype: LinkUse.bldwall, comment: "bld30.link7");
            grc.AddLinkByNodeName("osm3666040541", "osm3177098466", usetype: LinkUse.bldwall, comment: "bld30.link8");

            grc.AddLinkByNodeName("osm3666040627", "osm3666040633", usetype: LinkUse.bldwall, comment: "bld31.link1");
            grc.AddLinkByNodeName("osm3666040625", "osm3666040627", usetype: LinkUse.bldwall, comment: "bld31.link2");
            grc.AddLinkByNodeName("osm3666040620", "osm3666040625", usetype: LinkUse.bldwall, comment: "bld31.link3");
            grc.AddLinkByNodeName("osm3666040621", "osm3666040620", usetype: LinkUse.bldwall, comment: "bld31.link4");
            grc.AddLinkByNodeName("osm3666040618", "osm3666040621", usetype: LinkUse.bldwall, comment: "bld31.link5");
            grc.AddLinkByNodeName("osm3666040619", "osm3666040618", usetype: LinkUse.bldwall, comment: "bld31.link6");
            grc.AddLinkByNodeName("osm3666040634", "osm3666040619", usetype: LinkUse.bldwall, comment: "bld31.link7");
            grc.AddLinkByNodeName("osm3666040633", "osm3666040634", usetype: LinkUse.bldwall, comment: "bld31.link8");

            grc.AddLinkByNodeName("osm3666431794", "osm3666431790", usetype: LinkUse.bldwall, comment: "bld32.link1");
            grc.AddLinkByNodeName("osm3666431678", "osm3666431794", usetype: LinkUse.bldwall, comment: "bld32.link2");
            grc.AddLinkByNodeName("osm3666431899", "osm3666431678", usetype: LinkUse.bldwall, comment: "bld32.link3");
            grc.AddLinkByNodeName("osm3666431681", "osm3666431899", usetype: LinkUse.bldwall, comment: "bld32.link4");
            grc.AddLinkByNodeName("osm3666431897", "osm3666431681", usetype: LinkUse.bldwall, comment: "bld32.link5");
            grc.AddLinkByNodeName("osm3666431907", "osm3666431897", usetype: LinkUse.bldwall, comment: "bld32.link6");
            grc.AddLinkByNodeName("osm3666431914", "osm3666431907", usetype: LinkUse.bldwall, comment: "bld32.link7");
            grc.AddLinkByNodeName("osm3666431801", "osm3666431914", usetype: LinkUse.bldwall, comment: "bld32.link8");
            grc.AddLinkByNodeName("osm3666431917", "osm3666431801", usetype: LinkUse.bldwall, comment: "bld32.link9");
            grc.AddLinkByNodeName("osm3666431912", "osm3666431917", usetype: LinkUse.bldwall, comment: "bld32.link10");
            grc.AddLinkByNodeName("osm3666431919", "osm3666431912", usetype: LinkUse.bldwall, comment: "bld32.link11");
            grc.AddLinkByNodeName("osm3666431805", "osm3666431919", usetype: LinkUse.bldwall, comment: "bld32.link12");
            grc.AddLinkByNodeName("osm3666431771", "osm3666431805", usetype: LinkUse.bldwall, comment: "bld32.link13");
            grc.AddLinkByNodeName("osm3666431875", "osm3666431771", usetype: LinkUse.bldwall, comment: "bld32.link14");
            grc.AddLinkByNodeName("osm3666431853", "osm3666431875", usetype: LinkUse.bldwall, comment: "bld32.link15");
            grc.AddLinkByNodeName("osm3666431790", "osm3666431853", usetype: LinkUse.bldwall, comment: "bld32.link16");

            grc.AddLinkByNodeName("osm3666431884", "osm3666431771", usetype: LinkUse.bldwall, comment: "bld33.link1");
            grc.AddLinkByNodeName("osm3666431924", "osm3666431884", usetype: LinkUse.bldwall, comment: "bld33.link2");
            grc.AddLinkByNodeName("osm3666431805", "osm3666431924", usetype: LinkUse.bldwall, comment: "bld33.link3");
            grc.AddLinkByNodeName("osm3666431771", "osm3666431805", usetype: LinkUse.bldwall, comment: "bld33.link4");

            grc.AddLinkByNodeName("osm3666431635", "osm3666431744", usetype: LinkUse.bldwall, comment: "bld34.link1");
            grc.AddLinkByNodeName("osm3666430514", "osm3666431635", usetype: LinkUse.bldwall, comment: "bld34.link2");
            grc.AddLinkByNodeName("osm3666431828", "osm3666430514", usetype: LinkUse.bldwall, comment: "bld34.link3");
            grc.AddLinkByNodeName("osm3666431744", "osm3666431828", usetype: LinkUse.bldwall, comment: "bld34.link4");

            grc.AddLinkByNodeName("osm3666431642", "osm3666431768", usetype: LinkUse.bldwall, comment: "bld35.link1");
            grc.AddLinkByNodeName("osm3666430524", "osm3666431642", usetype: LinkUse.bldwall, comment: "bld35.link2");
            grc.AddLinkByNodeName("osm3666431882", "osm3666430524", usetype: LinkUse.bldwall, comment: "bld35.link3");
            grc.AddLinkByNodeName("osm3666431768", "osm3666431882", usetype: LinkUse.bldwall, comment: "bld35.link4");

            grc.AddLinkByNodeName("osm3666431757", "osm3666431669", usetype: LinkUse.bldwall, comment: "bld36.link1");
            grc.AddLinkByNodeName("osm3666431785", "osm3666431757", usetype: LinkUse.bldwall, comment: "bld36.link2");
            grc.AddLinkByNodeName("osm3666431893", "osm3666431785", usetype: LinkUse.bldwall, comment: "bld36.link3");
            grc.AddLinkByNodeName("osm3666428305", "osm3666431893", usetype: LinkUse.bldwall, comment: "bld36.link4");
            grc.AddLinkByNodeName("osm3666431669", "osm3666428305", usetype: LinkUse.bldwall, comment: "bld36.link5");

            grc.AddLinkByNodeName("osm3666431826", "osm3666431645", usetype: LinkUse.bldwall, comment: "bld37.link1");
            grc.AddLinkByNodeName("osm3666430495", "osm3666431826", usetype: LinkUse.bldwall, comment: "bld37.link2");
            grc.AddLinkByNodeName("osm3666430483", "osm3666430495", usetype: LinkUse.bldwall, comment: "bld37.link3");
            grc.AddLinkByNodeName("osm3666431009", "osm3666430483", usetype: LinkUse.bldwall, comment: "bld37.link4");
            grc.AddLinkByNodeName("osm3666431645", "osm3666431009", usetype: LinkUse.bldwall, comment: "bld37.link5");

            grc.AddLinkByNodeName("osm3666431744", "osm3666430524", usetype: LinkUse.bldwall, comment: "bld38.link1");
            grc.AddLinkByNodeName("osm3666431669", "osm3666431744", usetype: LinkUse.bldwall, comment: "bld38.link2");
            grc.AddLinkByNodeName("osm3666428305", "osm3666431669", usetype: LinkUse.bldwall, comment: "bld38.link3");
            grc.AddLinkByNodeName("osm3666431882", "osm3666428305", usetype: LinkUse.bldwall, comment: "bld38.link4");
            grc.AddLinkByNodeName("osm3666430524", "osm3666431882", usetype: LinkUse.bldwall, comment: "bld38.link5");

            grc.AddLinkByNodeName("osm3666431853", "osm3666428292", usetype: LinkUse.bldwall, comment: "bld39.link1");
            grc.AddLinkByNodeName("osm3666431790", "osm3666431853", usetype: LinkUse.bldwall, comment: "bld39.link2");
            grc.AddLinkByNodeName("osm3666431684", "osm3666431790", usetype: LinkUse.bldwall, comment: "bld39.link3");
            grc.AddLinkByNodeName("osm3666431793", "osm3666431684", usetype: LinkUse.bldwall, comment: "bld39.link4");
            grc.AddLinkByNodeName("osm3666430509", "osm3666431793", usetype: LinkUse.bldwall, comment: "bld39.link5");
            grc.AddLinkByNodeName("osm3666428292", "osm3666430509", usetype: LinkUse.bldwall, comment: "bld39.link6");

            grc.AddLinkByNodeName("osm3666431650", "osm3666431826", usetype: LinkUse.bldwall, comment: "bld40.link1");
            grc.AddLinkByNodeName("osm3666431839", "osm3666431650", usetype: LinkUse.bldwall, comment: "bld40.link2");
            grc.AddLinkByNodeName("osm3666428293", "osm3666431839", usetype: LinkUse.bldwall, comment: "bld40.link3");
            grc.AddLinkByNodeName("osm3666430504", "osm3666428293", usetype: LinkUse.bldwall, comment: "bld40.link4");
            grc.AddLinkByNodeName("osm3666430495", "osm3666430504", usetype: LinkUse.bldwall, comment: "bld40.link5");
            grc.AddLinkByNodeName("osm3666431826", "osm3666430495", usetype: LinkUse.bldwall, comment: "bld40.link6");

            grc.AddLinkByNodeName("osm3666431809", "osm3666431924", usetype: LinkUse.bldwall, comment: "bld41.link1");
            grc.AddLinkByNodeName("osm3666431934", "osm3666431809", usetype: LinkUse.bldwall, comment: "bld41.link2");
            grc.AddLinkByNodeName("osm3666431782", "osm3666431934", usetype: LinkUse.bldwall, comment: "bld41.link3");
            grc.AddLinkByNodeName("osm3666431879", "osm3666431782", usetype: LinkUse.bldwall, comment: "bld41.link4");
            grc.AddLinkByNodeName("osm3666431884", "osm3666431879", usetype: LinkUse.bldwall, comment: "bld41.link5");
            grc.AddLinkByNodeName("osm3666431924", "osm3666431884", usetype: LinkUse.bldwall, comment: "bld41.link6");

            grc.AddLinkByNodeName("osm3666466823", "osm3666466070", usetype: LinkUse.bldwall, comment: "bld42.link1");
            grc.AddLinkByNodeName("osm3666466820", "osm3666466823", usetype: LinkUse.bldwall, comment: "bld42.link2");
            grc.AddLinkByNodeName("osm3666466817", "osm3666466820", usetype: LinkUse.bldwall, comment: "bld42.link3");
            grc.AddLinkByNodeName("osm3666466818", "osm3666466817", usetype: LinkUse.bldwall, comment: "bld42.link4");
            grc.AddLinkByNodeName("osm3666466814", "osm3666466818", usetype: LinkUse.bldwall, comment: "bld42.link5");
            grc.AddLinkByNodeName("osm3666466812", "osm3666466814", usetype: LinkUse.bldwall, comment: "bld42.link6");
            grc.AddLinkByNodeName("osm3666466810", "osm3666466812", usetype: LinkUse.bldwall, comment: "bld42.link7");
            grc.AddLinkByNodeName("osm3666466791", "osm3666466810", usetype: LinkUse.bldwall, comment: "bld42.link8");
            grc.AddLinkByNodeName("osm3666466803", "osm3666466791", usetype: LinkUse.bldwall, comment: "bld42.link9");
            grc.AddLinkByNodeName("osm3666466801", "osm3666466803", usetype: LinkUse.bldwall, comment: "bld42.link10");
            grc.AddLinkByNodeName("osm3666466806", "osm3666466801", usetype: LinkUse.bldwall, comment: "bld42.link11");
            grc.AddLinkByNodeName("osm3666466804", "osm3666466806", usetype: LinkUse.bldwall, comment: "bld42.link12");
            grc.AddLinkByNodeName("osm3666466808", "osm3666466804", usetype: LinkUse.bldwall, comment: "bld42.link13");
            grc.AddLinkByNodeName("osm3666466807", "osm3666466808", usetype: LinkUse.bldwall, comment: "bld42.link14");
            grc.AddLinkByNodeName("osm3666466813", "osm3666466807", usetype: LinkUse.bldwall, comment: "bld42.link15");
            grc.AddLinkByNodeName("osm3666466070", "osm3666466813", usetype: LinkUse.bldwall, comment: "bld42.link16");

            grc.AddLinkByNodeName("osm3666466807", "osm3666466813", usetype: LinkUse.bldwall, comment: "bld43.link1");
            grc.AddLinkByNodeName("osm3666466802", "osm3666466807", usetype: LinkUse.bldwall, comment: "bld43.link2");
            grc.AddLinkByNodeName("osm3666466794", "osm3666466802", usetype: LinkUse.bldwall, comment: "bld43.link3");
            grc.AddLinkByNodeName("osm3666466800", "osm3666466794", usetype: LinkUse.bldwall, comment: "bld43.link4");
            grc.AddLinkByNodeName("osm3666466787", "osm3666466800", usetype: LinkUse.bldwall, comment: "bld43.link5");
            grc.AddLinkByNodeName("osm3666468623", "osm3666466787", usetype: LinkUse.bldwall, comment: "bld43.link6");
            grc.AddLinkByNodeName("osm3666468618", "osm3666468623", usetype: LinkUse.bldwall, comment: "bld43.link7");
            grc.AddLinkByNodeName("osm3666468595", "osm3666468618", usetype: LinkUse.bldwall, comment: "bld43.link8");
            grc.AddLinkByNodeName("osm3666468605", "osm3666468595", usetype: LinkUse.bldwall, comment: "bld43.link9");
            grc.AddLinkByNodeName("osm3666468602", "osm3666468605", usetype: LinkUse.bldwall, comment: "bld43.link10");
            grc.AddLinkByNodeName("osm3666467905", "osm3666468602", usetype: LinkUse.bldwall, comment: "bld43.link11");
            grc.AddLinkByNodeName("osm3666468613", "osm3666467905", usetype: LinkUse.bldwall, comment: "bld43.link12");
            grc.AddLinkByNodeName("osm3666467907", "osm3666468613", usetype: LinkUse.bldwall, comment: "bld43.link13");
            grc.AddLinkByNodeName("osm3666467906", "osm3666467907", usetype: LinkUse.bldwall, comment: "bld43.link14");
            grc.AddLinkByNodeName("osm3666466786", "osm3666467906", usetype: LinkUse.bldwall, comment: "bld43.link15");
            grc.AddLinkByNodeName("osm3666466813", "osm3666466786", usetype: LinkUse.bldwall, comment: "bld43.link16");

            grc.AddLinkByNodeName("osm3666467906", "osm3666466786", usetype: LinkUse.bldwall, comment: "bld44.link1");
            grc.AddLinkByNodeName("osm3666468606", "osm3666467906", usetype: LinkUse.bldwall, comment: "bld44.link2");
            grc.AddLinkByNodeName("osm3666468596", "osm3666468606", usetype: LinkUse.bldwall, comment: "bld44.link3");
            grc.AddLinkByNodeName("osm3666468599", "osm3666468596", usetype: LinkUse.bldwall, comment: "bld44.link4");
            grc.AddLinkByNodeName("osm3666468589", "osm3666468599", usetype: LinkUse.bldwall, comment: "bld44.link5");
            grc.AddLinkByNodeName("osm3666468584", "osm3666468589", usetype: LinkUse.bldwall, comment: "bld44.link6");
            grc.AddLinkByNodeName("osm3666467902", "osm3666468584", usetype: LinkUse.bldwall, comment: "bld44.link7");
            grc.AddLinkByNodeName("osm3666467881", "osm3666467902", usetype: LinkUse.bldwall, comment: "bld44.link8");
            grc.AddLinkByNodeName("osm3666467886", "osm3666467881", usetype: LinkUse.bldwall, comment: "bld44.link9");
            grc.AddLinkByNodeName("osm3666467883", "osm3666467886", usetype: LinkUse.bldwall, comment: "bld44.link10");
            grc.AddLinkByNodeName("osm3666467889", "osm3666467883", usetype: LinkUse.bldwall, comment: "bld44.link11");
            grc.AddLinkByNodeName("osm3666467888", "osm3666467889", usetype: LinkUse.bldwall, comment: "bld44.link12");
            grc.AddLinkByNodeName("osm3666467897", "osm3666467888", usetype: LinkUse.bldwall, comment: "bld44.link13");
            grc.AddLinkByNodeName("osm3666467891", "osm3666467897", usetype: LinkUse.bldwall, comment: "bld44.link14");
            grc.AddLinkByNodeName("osm3666468587", "osm3666467891", usetype: LinkUse.bldwall, comment: "bld44.link15");
            grc.AddLinkByNodeName("osm3666466786", "osm3666468587", usetype: LinkUse.bldwall, comment: "bld44.link16");

            grc.AddLinkByNodeName("osm3666468608", "osm3666468607", usetype: LinkUse.bldwall, comment: "bld45.link1");
            grc.AddLinkByNodeName("osm3666468600", "osm3666468608", usetype: LinkUse.bldwall, comment: "bld45.link2");
            grc.AddLinkByNodeName("osm3666468604", "osm3666468600", usetype: LinkUse.bldwall, comment: "bld45.link3");
            grc.AddLinkByNodeName("osm3666468597", "osm3666468604", usetype: LinkUse.bldwall, comment: "bld45.link4");
            grc.AddLinkByNodeName("osm3666468588", "osm3666468597", usetype: LinkUse.bldwall, comment: "bld45.link5");
            grc.AddLinkByNodeName("osm3666468585", "osm3666468588", usetype: LinkUse.bldwall, comment: "bld45.link6");
            grc.AddLinkByNodeName("osm3666467890", "osm3666468585", usetype: LinkUse.bldwall, comment: "bld45.link7");
            grc.AddLinkByNodeName("osm3666467896", "osm3666467890", usetype: LinkUse.bldwall, comment: "bld45.link8");
            grc.AddLinkByNodeName("osm3666467882", "osm3666467896", usetype: LinkUse.bldwall, comment: "bld45.link9");
            grc.AddLinkByNodeName("osm3666467887", "osm3666467882", usetype: LinkUse.bldwall, comment: "bld45.link10");
            grc.AddLinkByNodeName("osm3666467900", "osm3666467887", usetype: LinkUse.bldwall, comment: "bld45.link11");
            grc.AddLinkByNodeName("osm3666467901", "osm3666467900", usetype: LinkUse.bldwall, comment: "bld45.link12");
            grc.AddLinkByNodeName("osm3666468586", "osm3666467901", usetype: LinkUse.bldwall, comment: "bld45.link13");
            grc.AddLinkByNodeName("osm3666467903", "osm3666468586", usetype: LinkUse.bldwall, comment: "bld45.link14");
            grc.AddLinkByNodeName("osm3666468601", "osm3666467903", usetype: LinkUse.bldwall, comment: "bld45.link15");
            grc.AddLinkByNodeName("osm3666468598", "osm3666468601", usetype: LinkUse.bldwall, comment: "bld45.link16");
            grc.AddLinkByNodeName("osm3666468607", "osm3666468598", usetype: LinkUse.bldwall, comment: "bld45.link17");

            grc.AddLinkByNodeName("osm3666466079", "osm3666466098", usetype: LinkUse.bldwall, comment: "bld46.link1");
            grc.AddLinkByNodeName("osm3666466078", "osm3666466079", usetype: LinkUse.bldwall, comment: "bld46.link2");
            grc.AddLinkByNodeName("osm3666469265", "osm3666466078", usetype: LinkUse.bldwall, comment: "bld46.link3");
            grc.AddLinkByNodeName("osm3666469266", "osm3666469265", usetype: LinkUse.bldwall, comment: "bld46.link4");
            grc.AddLinkByNodeName("osm3666469335", "osm3666469266", usetype: LinkUse.bldwall, comment: "bld46.link5");
            grc.AddLinkByNodeName("osm3666469334", "osm3666469335", usetype: LinkUse.bldwall, comment: "bld46.link6");
            grc.AddLinkByNodeName("osm3666469247", "osm3666469334", usetype: LinkUse.bldwall, comment: "bld46.link7");
            grc.AddLinkByNodeName("osm3666469248", "osm3666469247", usetype: LinkUse.bldwall, comment: "bld46.link8");
            grc.AddLinkByNodeName("osm3666469239", "osm3666469248", usetype: LinkUse.bldwall, comment: "bld46.link9");
            grc.AddLinkByNodeName("osm3666469238", "osm3666469239", usetype: LinkUse.bldwall, comment: "bld46.link10");
            grc.AddLinkByNodeName("osm3666469328", "osm3666469238", usetype: LinkUse.bldwall, comment: "bld46.link11");
            grc.AddLinkByNodeName("osm3666469329", "osm3666469328", usetype: LinkUse.bldwall, comment: "bld46.link12");
            grc.AddLinkByNodeName("osm3666469232", "osm3666469329", usetype: LinkUse.bldwall, comment: "bld46.link13");
            grc.AddLinkByNodeName("osm3666469230", "osm3666469232", usetype: LinkUse.bldwall, comment: "bld46.link14");
            grc.AddLinkByNodeName("osm3666469136", "osm3666469230", usetype: LinkUse.bldwall, comment: "bld46.link15");
            grc.AddLinkByNodeName("osm3666469139", "osm3666469136", usetype: LinkUse.bldwall, comment: "bld46.link16");
            grc.AddLinkByNodeName("osm3666469144", "osm3666469139", usetype: LinkUse.bldwall, comment: "bld46.link17");
            grc.AddLinkByNodeName("osm3666469145", "osm3666469144", usetype: LinkUse.bldwall, comment: "bld46.link18");
            grc.AddLinkByNodeName("osm3666466099", "osm3666469145", usetype: LinkUse.bldwall, comment: "bld46.link19");
            grc.AddLinkByNodeName("osm3666466098", "osm3666466099", usetype: LinkUse.bldwall, comment: "bld46.link20");

            grc.AddLinkByNodeName("osm3666469286", "osm3666469280", usetype: LinkUse.bldwall, comment: "bld47.link1");
            grc.AddLinkByNodeName("osm3666469285", "osm3666469286", usetype: LinkUse.bldwall, comment: "bld47.link2");
            grc.AddLinkByNodeName("osm3666469290", "osm3666469285", usetype: LinkUse.bldwall, comment: "bld47.link3");
            grc.AddLinkByNodeName("osm3666469289", "osm3666469290", usetype: LinkUse.bldwall, comment: "bld47.link4");
            grc.AddLinkByNodeName("osm3666469284", "osm3666469289", usetype: LinkUse.bldwall, comment: "bld47.link5");
            grc.AddLinkByNodeName("osm3666469169", "osm3666469284", usetype: LinkUse.bldwall, comment: "bld47.link6");
            grc.AddLinkByNodeName("osm3666469170", "osm3666469169", usetype: LinkUse.bldwall, comment: "bld47.link7");
            grc.AddLinkByNodeName("osm3666469293", "osm3666469170", usetype: LinkUse.bldwall, comment: "bld47.link8");
            grc.AddLinkByNodeName("osm3666469166", "osm3666469293", usetype: LinkUse.bldwall, comment: "bld47.link9");
            grc.AddLinkByNodeName("osm3666469165", "osm3666469166", usetype: LinkUse.bldwall, comment: "bld47.link10");
            grc.AddLinkByNodeName("osm3666469168", "osm3666469165", usetype: LinkUse.bldwall, comment: "bld47.link11");
            grc.AddLinkByNodeName("osm3666469167", "osm3666469168", usetype: LinkUse.bldwall, comment: "bld47.link12");
            grc.AddLinkByNodeName("osm3666469164", "osm3666469167", usetype: LinkUse.bldwall, comment: "bld47.link13");
            grc.AddLinkByNodeName("osm3666469162", "osm3666469164", usetype: LinkUse.bldwall, comment: "bld47.link14");
            grc.AddLinkByNodeName("osm3666469288", "osm3666469162", usetype: LinkUse.bldwall, comment: "bld47.link15");
            grc.AddLinkByNodeName("osm3666469287", "osm3666469288", usetype: LinkUse.bldwall, comment: "bld47.link16");
            grc.AddLinkByNodeName("osm3666469163", "osm3666469287", usetype: LinkUse.bldwall, comment: "bld47.link17");
            grc.AddLinkByNodeName("osm3666469161", "osm3666469163", usetype: LinkUse.bldwall, comment: "bld47.link18");
            grc.AddLinkByNodeName("osm3666466085", "osm3666469161", usetype: LinkUse.bldwall, comment: "bld47.link19");
            grc.AddLinkByNodeName("osm3666466087", "osm3666466085", usetype: LinkUse.bldwall, comment: "bld47.link20");
            grc.AddLinkByNodeName("osm3666466094", "osm3666466087", usetype: LinkUse.bldwall, comment: "bld47.link21");
            grc.AddLinkByNodeName("osm3666466095", "osm3666466094", usetype: LinkUse.bldwall, comment: "bld47.link22");
            grc.AddLinkByNodeName("osm3666466097", "osm3666466095", usetype: LinkUse.bldwall, comment: "bld47.link23");
            grc.AddLinkByNodeName("osm3666466098", "osm3666466097", usetype: LinkUse.bldwall, comment: "bld47.link24");
            grc.AddLinkByNodeName("osm3666466099", "osm3666466098", usetype: LinkUse.bldwall, comment: "bld47.link25");
            grc.AddLinkByNodeName("osm3666466100", "osm3666466099", usetype: LinkUse.bldwall, comment: "bld47.link26");
            grc.AddLinkByNodeName("osm3666469280", "osm3666466100", usetype: LinkUse.bldwall, comment: "bld47.link27");

            grc.AddLinkByNodeName("osm3666467911", "osm3666467912", usetype: LinkUse.bldwall, comment: "bld48.link1");
            grc.AddLinkByNodeName("osm3666466796", "osm3666467911", usetype: LinkUse.bldwall, comment: "bld48.link2");
            grc.AddLinkByNodeName("osm3666466797", "osm3666466796", usetype: LinkUse.bldwall, comment: "bld48.link3");
            grc.AddLinkByNodeName("osm3666467912", "osm3666466797", usetype: LinkUse.bldwall, comment: "bld48.link4");

            grc.AddLinkByNodeName("osm3666467915", "osm3666467916", usetype: LinkUse.bldwall, comment: "bld49.link1");
            grc.AddLinkByNodeName("osm3666467923", "osm3666467915", usetype: LinkUse.bldwall, comment: "bld49.link2");
            grc.AddLinkByNodeName("osm3666469138", "osm3666467923", usetype: LinkUse.bldwall, comment: "bld49.link3");
            grc.AddLinkByNodeName("osm3666467916", "osm3666469138", usetype: LinkUse.bldwall, comment: "bld49.link4");

            grc.AddLinkByNodeName("osm3666467893", "osm3666467892", usetype: LinkUse.bldwall, comment: "bld50.link1");
            grc.AddLinkByNodeName("osm3666467894", "osm3666467893", usetype: LinkUse.bldwall, comment: "bld50.link2");
            grc.AddLinkByNodeName("osm3666468594", "osm3666467894", usetype: LinkUse.bldwall, comment: "bld50.link3");
            grc.AddLinkByNodeName("osm3666468593", "osm3666468594", usetype: LinkUse.bldwall, comment: "bld50.link4");
            grc.AddLinkByNodeName("osm3666467892", "osm3666468593", usetype: LinkUse.bldwall, comment: "bld50.link5");

            grc.AddLinkByNodeName("osm3666467895", "osm3666467894", usetype: LinkUse.bldwall, comment: "bld51.link1");
            grc.AddLinkByNodeName("osm3666467880", "osm3666467895", usetype: LinkUse.bldwall, comment: "bld51.link2");
            grc.AddLinkByNodeName("osm3666467879", "osm3666467880", usetype: LinkUse.bldwall, comment: "bld51.link3");
            grc.AddLinkByNodeName("osm3666467884", "osm3666467879", usetype: LinkUse.bldwall, comment: "bld51.link4");
            grc.AddLinkByNodeName("osm3666467885", "osm3666467884", usetype: LinkUse.bldwall, comment: "bld51.link5");
            grc.AddLinkByNodeName("osm3666467893", "osm3666467885", usetype: LinkUse.bldwall, comment: "bld51.link6");
            grc.AddLinkByNodeName("osm3666467894", "osm3666467893", usetype: LinkUse.bldwall, comment: "bld51.link7");

            grc.AddLinkByNodeName("osm3666466785", "osm3666467874", usetype: LinkUse.bldwall, comment: "bld52.link1");
            grc.AddLinkByNodeName("osm3666466784", "osm3666466785", usetype: LinkUse.bldwall, comment: "bld52.link2");
            grc.AddLinkByNodeName("osm3666466783", "osm3666466784", usetype: LinkUse.bldwall, comment: "bld52.link3");
            grc.AddLinkByNodeName("osm3666467875", "osm3666466783", usetype: LinkUse.bldwall, comment: "bld52.link4");
            grc.AddLinkByNodeName("osm3666467877", "osm3666467875", usetype: LinkUse.bldwall, comment: "bld52.link5");
            grc.AddLinkByNodeName("osm3666467876", "osm3666467877", usetype: LinkUse.bldwall, comment: "bld52.link6");
            grc.AddLinkByNodeName("osm3666467878", "osm3666467876", usetype: LinkUse.bldwall, comment: "bld52.link7");
            grc.AddLinkByNodeName("osm3666467874", "osm3666467878", usetype: LinkUse.bldwall, comment: "bld52.link8");

            grc.AddLinkByNodeName("osm3666999332", "osm3666999124", usetype: LinkUse.bldwall, comment: "bld53.link1");
            grc.AddLinkByNodeName("osm3666999116", "osm3666999332", usetype: LinkUse.bldwall, comment: "bld53.link2");
            grc.AddLinkByNodeName("osm3666999110", "osm3666999116", usetype: LinkUse.bldwall, comment: "bld53.link3");
            grc.AddLinkByNodeName("osm3666999124", "osm3666999110", usetype: LinkUse.bldwall, comment: "bld53.link4");

            grc.AddLinkByNodeName("osm3666999088", "osm3666999086", usetype: LinkUse.bldwall, comment: "bld54.link1");
            grc.AddLinkByNodeName("osm3666999078", "osm3666999088", usetype: LinkUse.bldwall, comment: "bld54.link2");
            grc.AddLinkByNodeName("osm3666999077", "osm3666999078", usetype: LinkUse.bldwall, comment: "bld54.link3");
            grc.AddLinkByNodeName("osm3666999086", "osm3666999077", usetype: LinkUse.bldwall, comment: "bld54.link4");

            grc.AddLinkByNodeName("osm3666999043", "osm3666999052", usetype: LinkUse.bldwall, comment: "terrace01.link1");
            grc.AddLinkByNodeName("osm3666999044", "osm3666999043", usetype: LinkUse.bldwall, comment: "terrace01.link2");
            grc.AddLinkByNodeName("osm3666999053", "osm3666999044", usetype: LinkUse.bldwall, comment: "terrace01.link3");
            grc.AddLinkByNodeName("osm3666999052", "osm3666999053", usetype: LinkUse.bldwall, comment: "terrace01.link4");

            grc.AddLinkByNodeName("osm3666999153", "osm3666999065", usetype: LinkUse.bldwall, comment: "terrace02.link1");
            grc.AddLinkByNodeName("osm3666999077", "osm3666999153", usetype: LinkUse.bldwall, comment: "terrace02.link2");
            grc.AddLinkByNodeName("osm3666999086", "osm3666999077", usetype: LinkUse.bldwall, comment: "terrace02.link3");
            grc.AddLinkByNodeName("osm3666999082", "osm3666999086", usetype: LinkUse.bldwall, comment: "terrace02.link4");
            grc.AddLinkByNodeName("osm3666999065", "osm3666999082", usetype: LinkUse.bldwall, comment: "terrace02.link5");

            grc.AddLinkByNodeName("osm3666999095", "osm3666999111", usetype: LinkUse.bldwall, comment: "bld55.link1");
            grc.AddLinkByNodeName("osm3666999185", "osm3666999095", usetype: LinkUse.bldwall, comment: "bld55.link2");
            grc.AddLinkByNodeName("osm3666999110", "osm3666999185", usetype: LinkUse.bldwall, comment: "bld55.link3");
            grc.AddLinkByNodeName("osm3666999124", "osm3666999110", usetype: LinkUse.bldwall, comment: "bld55.link4");
            grc.AddLinkByNodeName("osm3666999111", "osm3666999124", usetype: LinkUse.bldwall, comment: "bld55.link5");

            grc.AddLinkByNodeName("osm3666999031", "osm3666999043", usetype: LinkUse.bldwall, comment: "terrace03.link1");
            grc.AddLinkByNodeName("osm3666999033", "osm3666999031", usetype: LinkUse.bldwall, comment: "terrace03.link2");
            grc.AddLinkByNodeName("osm3666999039", "osm3666999033", usetype: LinkUse.bldwall, comment: "terrace03.link3");
            grc.AddLinkByNodeName("osm3666997221", "osm3666999039", usetype: LinkUse.bldwall, comment: "terrace03.link4");
            grc.AddLinkByNodeName("osm3666999046", "osm3666997221", usetype: LinkUse.bldwall, comment: "terrace03.link5");
            grc.AddLinkByNodeName("osm3666999044", "osm3666999046", usetype: LinkUse.bldwall, comment: "terrace03.link6");
            grc.AddLinkByNodeName("osm3666999043", "osm3666999044", usetype: LinkUse.bldwall, comment: "terrace03.link7");

            grc.AddLinkByNodeName("osm3666999129", "osm3666991854", usetype: LinkUse.bldwall, comment: "bld56.link1");
            grc.AddLinkByNodeName("osm3666999128", "osm3666999129", usetype: LinkUse.bldwall, comment: "bld56.link2");
            grc.AddLinkByNodeName("osm3666998822", "osm3666999128", usetype: LinkUse.bldwall, comment: "bld56.link3");
            grc.AddLinkByNodeName("osm3666999029", "osm3666998822", usetype: LinkUse.bldwall, comment: "bld56.link4");
            grc.AddLinkByNodeName("osm3666999127", "osm3666999029", usetype: LinkUse.bldwall, comment: "bld56.link5");
            grc.AddLinkByNodeName("osm3666999125", "osm3666999127", usetype: LinkUse.bldwall, comment: "bld56.link6");
            grc.AddLinkByNodeName("osm3666991853", "osm3666999125", usetype: LinkUse.bldwall, comment: "bld56.link7");
            grc.AddLinkByNodeName("osm3666991854", "osm3666991853", usetype: LinkUse.bldwall, comment: "bld56.link8");

            grc.AddLinkByNodeName("osm5455089558", "osm5455089557", usetype: LinkUse.bldwall, comment: "apartments01.link1");
            grc.AddLinkByNodeName("osm5455089559", "osm5455089558", usetype: LinkUse.bldwall, comment: "apartments01.link2");
            grc.AddLinkByNodeName("osm5455089560", "osm5455089559", usetype: LinkUse.bldwall, comment: "apartments01.link3");
            grc.AddLinkByNodeName("osm5455089557", "osm5455089560", usetype: LinkUse.bldwall, comment: "apartments01.link4");

            grc.AddLinkByNodeName("osm5730170648", "osm5730170647", usetype: LinkUse.bldwall, comment: "apartments02.link1");
            grc.AddLinkByNodeName("osm5730170649", "osm5730170648", usetype: LinkUse.bldwall, comment: "apartments02.link2");
            grc.AddLinkByNodeName("osm5730170650", "osm5730170649", usetype: LinkUse.bldwall, comment: "apartments02.link3");
            grc.AddLinkByNodeName("osm5730170651", "osm5730170650", usetype: LinkUse.bldwall, comment: "apartments02.link4");
            grc.AddLinkByNodeName("osm5730170652", "osm5730170651", usetype: LinkUse.bldwall, comment: "apartments02.link5");
            grc.AddLinkByNodeName("osm5730170653", "osm5730170652", usetype: LinkUse.bldwall, comment: "apartments02.link6");
            grc.AddLinkByNodeName("osm5730170654", "osm5730170653", usetype: LinkUse.bldwall, comment: "apartments02.link7");
            grc.AddLinkByNodeName("osm5730170647", "osm5730170654", usetype: LinkUse.bldwall, comment: "apartments02.link8");

            grc.AddLinkByNodeName("osm5730170656", "osm5730170655", usetype: LinkUse.bldwall, comment: "apartments03.link1");
            grc.AddLinkByNodeName("osm5730170657", "osm5730170656", usetype: LinkUse.bldwall, comment: "apartments03.link2");
            grc.AddLinkByNodeName("osm5730170658", "osm5730170657", usetype: LinkUse.bldwall, comment: "apartments03.link3");
            grc.AddLinkByNodeName("osm5730170659", "osm5730170658", usetype: LinkUse.bldwall, comment: "apartments03.link4");
            grc.AddLinkByNodeName("osm5730170660", "osm5730170659", usetype: LinkUse.bldwall, comment: "apartments03.link5");
            grc.AddLinkByNodeName("osm5730170661", "osm5730170660", usetype: LinkUse.bldwall, comment: "apartments03.link6");
            grc.AddLinkByNodeName("osm5730170662", "osm5730170661", usetype: LinkUse.bldwall, comment: "apartments03.link7");
            grc.AddLinkByNodeName("osm5730170655", "osm5730170662", usetype: LinkUse.bldwall, comment: "apartments03.link8");

            grc.AddLinkByNodeName("osm5891566775", "osm5891566774", usetype: LinkUse.bldwall, comment: "apartments04.link1");
            grc.AddLinkByNodeName("osm5891566776", "osm5891566775", usetype: LinkUse.bldwall, comment: "apartments04.link2");
            grc.AddLinkByNodeName("osm5891566777", "osm5891566776", usetype: LinkUse.bldwall, comment: "apartments04.link3");
            grc.AddLinkByNodeName("osm5891566774", "osm5891566777", usetype: LinkUse.bldwall, comment: "apartments04.link4");

            grc.AddLinkByNodeName("osm5891566779", "osm5891566778", usetype: LinkUse.bldwall, comment: "apartments05.link1");
            grc.AddLinkByNodeName("osm5891566780", "osm5891566779", usetype: LinkUse.bldwall, comment: "apartments05.link2");
            grc.AddLinkByNodeName("osm5891566781", "osm5891566780", usetype: LinkUse.bldwall, comment: "apartments05.link3");
            grc.AddLinkByNodeName("osm5891566778", "osm5891566781", usetype: LinkUse.bldwall, comment: "apartments05.link4");

            grc.AddLinkByNodeName("osm5891566783", "osm5891566782", usetype: LinkUse.bldwall, comment: "apartments06.link1");
            grc.AddLinkByNodeName("osm5891566784", "osm5891566783", usetype: LinkUse.bldwall, comment: "apartments06.link2");
            grc.AddLinkByNodeName("osm5891567185", "osm5891566784", usetype: LinkUse.bldwall, comment: "apartments06.link3");
            grc.AddLinkByNodeName("osm5891566782", "osm5891567185", usetype: LinkUse.bldwall, comment: "apartments06.link4");

            grc.AddLinkByNodeName("osm5891567187", "osm5891567186", usetype: LinkUse.bldwall, comment: "apartments07.link1");
            grc.AddLinkByNodeName("osm5891567188", "osm5891567187", usetype: LinkUse.bldwall, comment: "apartments07.link2");
            grc.AddLinkByNodeName("osm5891567189", "osm5891567188", usetype: LinkUse.bldwall, comment: "apartments07.link3");
            grc.AddLinkByNodeName("osm5891567186", "osm5891567189", usetype: LinkUse.bldwall, comment: "apartments07.link4");

            grc.AddLinkByNodeName("osm5891567191", "osm5891567190", usetype: LinkUse.bldwall, comment: "apartments08.link1");
            grc.AddLinkByNodeName("osm5891567192", "osm5891567191", usetype: LinkUse.bldwall, comment: "apartments08.link2");
            grc.AddLinkByNodeName("osm5891567193", "osm5891567192", usetype: LinkUse.bldwall, comment: "apartments08.link3");
            grc.AddLinkByNodeName("osm5891567190", "osm5891567193", usetype: LinkUse.bldwall, comment: "apartments08.link4");
            grc.regman.SetRegion("default");
            // Area eb12small machine generated 655 nodes and 720 links on 2020-06-30 18:20:43.198403
        }



         

        /// ===================================   Campus Data ===========================================================
        /// 
        public void CreatePointsForB43RoomsFloor1()
        {
            grc.regman.NewNodeRegion("msft-b43-f1", "purple", true);

            grc.yfloor = 0;
            grc.SetCurUseType(LinkUse.walkway);
            grc.AddNodePtxz("b43-f01-lobby", 0, 0);

            grc.LinkToPtxz("b43-f01-c01", 6.52, 0);

            grc.LinkToPtxz("b43-f01-c02", 8.74, 0);
            grc.LinkToPtxz("b43-f01-c03", 10.84, 0);
            grc.LinkToPtxz("b43-f01-c04", 14.34, 0);
            grc.LinkToPtxz("b43-f01-c05", 17.80, 0);
            grc.LinkToPtxz("b43-f01-c06", 21.53, -0.11);
            grc.LinkToPtxz("b43-f01-c07", 23.25, 1.92);
            grc.LinkToPtxz("b43-f01-c08", 29.15, 1.92);
            grc.LinkToPtxz("b43-f01-c09", 32.76, 1.92);
            grc.LinkToPtxz("b43-f01-c10", 33.22, 4.43);
            grc.LinkToPtxz("b43-f01-c11", 33.22, 5.97);
            grc.LinkToPtxz("b43-f01-c12", 33.22, 8.3);
            grc.LinkToPtxz("b43-f01-c13", 29.44, 8.63);
            grc.LinkToPtxz("b43-f01-c14", 29.44, 11.91);
            grc.LinkToPtxz("b43-f01-c15", 27.55, 11.91);
            grc.LinkToPtxz("b43-f01-c16", 27.55, 9.04);
            grc.NewAnchorLinkToxz("b43-f01-c01", "b43-f01-rm1001", 6.29, -3.47);
            grc.NewAnchorLinkToxz("b43-f01-c02", "b43-f01-rm1002", 8.47, -3.47);
            grc.NewAnchorLinkToxz("b43-f01-c03", "b43-f01-rm1003", 10.53, -3.47);

            grc.NewAnchorLinkToxz("b43-f01-c04", "b43-f01-k01", 14.15, 5.04);
            grc.NewAnchorLinkToxz("b43-f01-c05", "b43-f01-rm1004", 17.46, 4.31);
            grc.NewAnchorLinkToxz("b43-f01-c08", "b43-f01-rm1005", 29.68, -1.66);
            grc.NewAnchorLinkToxz("b43-f01-c09", "b43-f01-rm1006", 32.76, -0.60);
            grc.NewAnchorLinkToxz("b43-f01-c10", "b43-f01-rm1007", 30.35, 4.43);
            grc.NewAnchorLinkToxz("b43-f01-c10", "b43-f01-rm1008", 36.44, 4.43);
            grc.NewAnchorLinkToxz("b43-f01-c11", "b43-f01-rm1009", 30.20, 5.97);
            grc.NewAnchorLinkToxz("b43-f01-c16", "b43-f01-rm1012", 25.03, 9.17);
            grc.NewAnchorLinkToxz("b43-f01-c15", "b43-f01-rm1013", 24.49, 11.91);
            grc.NewAnchorLinkToxz("b43-f01-c15", "b43-f01-rm1014", 27.55, 14.97);

            grc.NewAnchorLinkToxz("b43-f01-c03", "b43-f01-c20", 10.84, 12.63);
            grc.LinkToPtxz("b43-f01-c21", 14.15, 12.63);
            grc.LinkToPtxz("b43-f01-c22", 14.15, 9.66);
            grc.LinkToPtxz("b43-f01-c23", 17.74, 9.66);
            grc.LinkToPtxz("b43-f01-c24", 21.73, 8.73);
            grc.LinkToPtxz("b43-f01-c25", 21.73, 4.68);
            grc.NewAnchorLinkToxz("b43-f01-c23", "b43-f01-rm1015", 18.27, 12.37);

            grc.AddLinkByNodeName("b43-f01-rm1004", "b43-f01-c25");
            grc.AddLinkByNodeName("b43-f01-rm1012", "b43-f01-c24");

            // add path to ps1
            grc.NewAnchorLinkToxz("b43-f01-lobby", "b43-os1-o01", 0f, 8f);
            grc.LinkToPtxz("b43-os1-o02", -1.5f, 11.5f);
            grc.LinkToPtxz("b43-os1-o03", -1.5f, 27.5f);
            grc.LinkToPtxz("b43-os1-o04", 1.8f, 32.0f);
            grc.LinkToPtxz("b43-os1-o05", 4.0f, 33.3f);
            grc.LinkToPtxz("b43-os1-o06", 10.4f, 30.31f);

            // now add the keywords for the keyword recognizer
            //string template = "f01-dt-rm";
            //foreach (var nname in ptlist)
            //{
            //    if (nname.StartsWith(template))
            //    {
            //        var key = "room " + nname.Remove(0, template.Length);
            //        ptkeywords.Add(key, nname);
            //        // Debug.Log("Key:" + key + "  Node:" + nname);
            //    }
            //}
            //ptkeywords.Add("lobby 1", "b43-f01-lobby");
            //ptkeywords.Add("kitchen 1", "b43-f01-k01");
        }

        public void CreatePointsForB43RoomsFloor2()
        {
            grc.gm.initmods();
            grc.yfloor = 4;
            grc.AddNodePtxz("f02-dt-st02", 0, 0);

            grc.LinkToPtxz("f02-wp-c01", 6.52, 0);

            grc.LinkToPtxz("f02-wp-c02", 8.74, 0);
            grc.LinkToPtxz("f02-wp-c03", 10.84, 0);
            grc.LinkToPtxz("f02-wp-c04", 14.34, 0);
            grc.LinkToPtxz("f02-wp-c05", 17.80, 0);
            grc.LinkToPtxz("f02-wp-c06", 21.53, -0.11);
            grc.LinkToPtxz("f02-wp-c07", 23.25, 1.92);
            grc.LinkToPtxz("f02-wp-c08", 29.15, 1.92);
            grc.LinkToPtxz("f02-wp-c09", 32.76, 1.92);
            grc.LinkToPtxz("f02-wp-c10", 33.22, 4.43);
            grc.LinkToPtxz("f02-wp-c11", 33.22, 5.97);
            grc.LinkToPtxz("f02-wp-c12", 33.22, 8.3);
            grc.LinkToPtxz("f02-wp-c13", 29.44, 8.63);
            grc.LinkToPtxz("f02-wp-c14", 29.44, 11.91);
            grc.LinkToPtxz("f02-wp-c15", 27.55, 11.91);
            grc.LinkToPtxz("f02-wp-c16", 27.55, 9.04);
            grc.NewAnchorLinkToxz("f02-wp-c01", "f02-dt-rm2001", 6.29, -3.47);
            grc.NewAnchorLinkToxz("f02-wp-c02", "f02-dt-rm2002", 8.47, -3.47);
            grc.NewAnchorLinkToxz("f02-wp-c03", "f02-dt-rm2003", 10.53, -3.47);

            grc.NewAnchorLinkToxz("f02-wp-c04", "f02-dt-k02", 14.15, 5.04);
            grc.NewAnchorLinkToxz("f02-wp-c05", "f02-dt-rm2004", 17.46, 4.31);
            grc.NewAnchorLinkToxz("f02-wp-c08", "f02-dt-rm2005", 29.68, -1.66);
            grc.NewAnchorLinkToxz("f02-wp-c09", "f02-dt-rm2006", 32.76, -0.60);
            grc.NewAnchorLinkToxz("f02-wp-c10", "f02-dt-rm2007", 30.35, 4.43);
            grc.NewAnchorLinkToxz("f02-wp-c10", "f02-dt-rm2008", 36.44, 4.43);
            grc.NewAnchorLinkToxz("f02-wp-c11", "f02-dt-rm2009", 30.20, 5.97);
            grc.NewAnchorLinkToxz("f02-wp-c16", "f02-dt-rm2012", 25.03, 9.17);
            grc.NewAnchorLinkToxz("f02-wp-c15", "f02-dt-rm2013", 24.49, 11.91);
            grc.NewAnchorLinkToxz("f02-wp-c15", "f02-dt-rm2014", 27.55, 14.97);

            grc.NewAnchorLinkToxz("f02-wp-c03", "f02-wp-c20", 10.84, 12.63);
            grc.LinkToPtxz("f02-wp-c21", 14.15, 12.63);
            grc.LinkToPtxz("f02-wp-c22", 14.15, 9.66);
            grc.LinkToPtxz("f02-wp-c23", 17.74, 9.66);
            grc.LinkToPtxz("f02-wp-c24", 21.73, 8.73);
            grc.LinkToPtxz("f02-wp-c25", 21.73, 4.68);
            grc.NewAnchorLinkToxz("f02-wp-c23", "f02-dt-rm2015", 18.27, 12.37);

            grc.AddLinkByNodeName("f02-dt-rm2004", "f02-wp-c25");
            grc.AddLinkByNodeName("f02-dt-rm2012", "f02-wp-c24");

            // now add the keywords for the keyword recognizer
            string template = "f02-dt-rm";
            foreach (var nname in grc.nodenamelist)
            {
                if (nname.StartsWith(template))
                {
                    var key = "room " + nname.Remove(0, template.Length);
                    grc.nodekeywords.Add(key, nname);
                    // RegionMan.Log("Key:" + key + "  Node:" + nname);
                }
            }
            grc.nodekeywords.Add("lobby 2", "f02-dt-st02");
            grc.nodekeywords.Add("kitchen 2", "f02-dt-k02");
        }

 
        public void AddRedwB3rooms()
        {
            try
            {
                grc.addRoomLink("3261", 42.95f, 158.96f, "NA");
                grc.addRoomLink("3215", 145.14f, 187.71f, "BAPERRY");
                grc.addRoomLink("3377", 196.52f, 217.20f, "KIWATANA");
                grc.addRoomLink("3267", 56.81f, 144.34f, "MNARANJO");
                grc.addRoomLink("3381", 196.52f, 232.14f, "KABYSTRO,ALCARDEN");
                grc.addRoomLink("3375", 196.52f, 209.86f, "AMITAGRA");
                grc.addRoomLink("3359", 232.03f, 166.37f, "ABOCZAR");
                grc.addRoomLink("3353", 232.05f, 144.32f, "PETERYI");
                grc.addRoomLink("3173", 65.29f, 253.45f, "PKHANNA");
                grc.addRoomLink("3169", 65.29f, 275.39f, "BALUS");
                grc.addRoomLink("3374", 210.96f, 209.86f, "BLAIRSH");
                grc.addRoomLink("3257", 43.00f, 144.32f, "KATHLEES,OMASEK");
                grc.addRoomLink("3376", 210.96f, 217.20f, "MPIGGOTT");
                grc.addRoomLink("3129", 144.24f, 264.42f, "MARIANAQ");
                grc.addRoomLink("3205", 145.12f, 232.14f, "MATTPE");
                grc.addRoomLink("3282", 85.74f, 131.11f, "LAUPRES");
                grc.addRoomLink("3184", 107.90f, 240.24f, "GILPETTE");
                grc.addRoomLink("3207", 145.12f, 224.67f, "WENDYJ");
                grc.addRoomLink("3372", 210.96f, 202.51f, "FPACE");
                grc.addRoomLink("3069", 254.08f, 253.45f, "FAYEB");
                grc.addRoomLink("3335", 197.41f, 145.54f, "JEPEARSO,EUNICES");
                grc.addRoomLink("3221", 159.81f, 165.29f, "PHILIBRI");
                grc.addRoomLink("3253", 43.03f, 166.37f, "PAGUNASH");
                grc.addRoomLink("3385", 197.41f, 165.29f, "EVANI");
                grc.addRoomLink("3371", 196.52f, 195.17f, "NINDYHU");
                grc.addRoomLink("3073", 254.08f, 275.39f, "NA");
                grc.addRoomLink("3105", 197.41f, 274.17f, "SENTHILC,MKRANZ");
                grc.addRoomLink("3199", 159.81f, 254.68f, "ROSALYNV");
                grc.addRoomLink("3063", 231.59f, 254.68f, "NA");
                grc.addRoomLink("3378", 210.95f, 224.66f, "TOMFREE");
                grc.addRoomLink("3337", 197.41f, 155.42f, "NA");
                grc.addRoomLink("3103", 197.41f, 264.42f, "ANKURT,SIMRANS");
                grc.addRoomLink("3141", 122.08f, 274.30f, "THOKRAKU,SAWEAVER");
                grc.addRoomLink("3234", 115.24f, 179.47f, "NA");
                grc.addRoomLink("3155", 87.90f, 274.17f, "SACHAA");
                grc.addRoomLink("3179", 87.90f, 254.68f, "ROBERH");
                grc.addRoomLink("3370", 210.96f, 195.17f, "MARKKOTT");
                grc.addRoomLink("3089", 231.59f, 264.42f, "KRMARCHB");
                grc.addRoomLink("3185", 110.05f, 264.55f, "JOEGURA,LANAMAY");
                grc.addRoomLink("3097", 209.40f, 274.21f, "PURNAG");
                grc.addRoomLink("3223", 151.96f, 165.29f, "KAVENK");
                grc.addRoomLink("3087", 231.59f, 274.17f, "NA");
                grc.addRoomLink("3123", 159.81f, 274.17f, "SHTANYA");
                //     lc.addRoomLink("3115", 157.53f, 261.26f, "NA");
                grc.addRoomLink("3236", 107.90f, 179.47f, "EMILYM");
                //      lc.addRoomLink("3115", 160.82f, 261.26f, "NA");
                //       lc.addRoomLink("3115", 160.06f, 267.59f, "NA");
                grc.addRoomLink("3238", 100.56f, 179.47f, "SHYATT");
                //     lc.addRoomLink("3115", 163.35f, 267.59f, "SASO");
                grc.addRoomLink("3244", 78.28f, 179.47f, "LUCYHUR");
                grc.addRoomLink("3140", 116.00f, 264.42f, "NA");
                //      lc.addRoomLink("3115", 156.77f, 267.59f, "NA");
                grc.addRoomLink("3240", 93.21f, 179.47f, "NA");
                grc.addRoomLink("3348", 225.14f, 155.42f, "NA");
                grc.addRoomLink("3321", 163.35f, 152.38f, "ANIDH");
                grc.addRoomLink("3252", 56.25f, 179.47f, "SUSANNEV");
                // lc.addRoomLink("3321", 150.44f, 152.38f, "NA");
                // lc.addRoomLink("3321", 160.06f, 152.38f, "GIJOHN");
                grc.addRoomLink("3248", 63.59f, 179.47f, "TOMURPHY");
                grc.addRoomLink("3296", 116.00f, 155.42f, "NA");
                //  lc.addRoomLink("3115", 166.65f, 267.59f, "NA");
                grc.addRoomLink("3306", 138.16f, 155.42f, "NA");
                grc.addRoomLink("3326", 174.24f, 153.14f, "NA");
                grc.addRoomLink("3112", 174.24f, 266.58f, "NA");
                grc.addRoomLink("3274", 71.66f, 155.48f, "NA");
                grc.addRoomLink("3246", 70.93f, 179.47f, "MODEME");
                grc.addRoomLink("3284", 93.85f, 155.42f, "NA");
                grc.addRoomLink("3264", 49.92f, 155.42f, "NA");
                grc.addRoomLink("3242", 85.74f, 179.47f, "ERIKAH");
                grc.addRoomLink("3360", 226.28f, 179.47f, "NABINK");
                grc.addRoomLink("3168", 70.93f, 288.61f, "RICKOL");
                grc.addRoomLink("3158", 78.28f, 288.61f, "JALLEN");
                grc.addRoomLink("3156", 85.74f, 288.61f, "RLONGDEN");
                grc.addRoomLink("3152", 93.85f, 264.42f, "NA");
                //  lc.addRoomLink("3115", 154.36f, 261.26f, "NA");
                grc.addRoomLink("3148", 93.21f, 288.61f, "AMBROSEW");
                // lc.addRoomLink("3115", 150.06f, 267.59f, "NA");
                //  lc.addRoomLink("3115", 160.69f, 263.85f, "NA");
                grc.addRoomLink("3340", 203.36f, 155.42f, "NA");
                grc.addRoomLink("3146", 100.56f, 288.61f, "ALEXMUK");
                // lc.addRoomLink("3115", 153.48f, 267.59f, "NA");
                grc.addRoomLink("3144", 107.90f, 288.61f, "SHAUNH");
                grc.addRoomLink("3115", 164.11f, 261.26f, "SAIEMA");
                grc.addRoomLink("3090", 225.64f, 264.42f, "NA");
                grc.addRoomLink("3142", 115.24f, 288.61f, "LUISTO");
                grc.addRoomLink("3080", 247.29f, 264.42f, "NA");
                grc.addRoomLink("3102", 203.36f, 264.42f, "NA");
                grc.addRoomLink("3166", 72.20f, 264.42f, "NA");
                grc.addRoomLink("3310", 138.29f, 264.42f, "NA");
                grc.addRoomLink("3391", 179.58f, 177.81f, "NA");
                grc.addRoomLink("3100", 204.12f, 288.61f, "CARLACAS");
                grc.addRoomLink("3134", 137.53f, 288.61f, "LISAOL");
                grc.addRoomLink("3075", 253.62f, 268.10f, "NA");
                grc.addRoomLink("3401", 152.21f, 195.05f, "NA");
                grc.addRoomLink("3136", 130.18f, 288.61f, "BKRAFFT");
                grc.addRoomLink("3138", 122.71f, 288.61f, "DOTTIES");
                grc.addRoomLink("3037", 152.21f, 224.67f, "NA");
                grc.addRoomLink("3167", 65.61f, 268.10f, "KOBELL");
                grc.addRoomLink("3096", 218.81f, 288.61f, "SQUINN");
                grc.addRoomLink("3259", 43.33f, 151.62f, "KERAINES");
                grc.addRoomLink("3351", 231.72f, 151.62f, "GORKEMY");
                grc.addRoomLink("3098", 211.46f, 288.61f, "SCHUMA");
                grc.addRoomLink("3027", 158.24f, 215.20f, "ConfRoom3027");
                grc.addRoomLink("3403", 158.24f, 204.64f, "ConfRoom3403");
                grc.addRoomLink("3108", 181.97f, 287.69f, "NA");
                grc.addRoomLink("3327", 185.26f, 155.42f, "NA");
                grc.addRoomLink("3094", 226.28f, 288.61f, "MARCBAX");
                grc.addRoomLink("3111", 185.26f, 264.42f, "NA");
                grc.addRoomLink("3086", 233.75f, 288.61f, "ADRIENR");
                grc.addRoomLink("3254", 45.05f, 179.40f, "ANANDE");
                grc.addRoomLink("3041", 184.29f, 240.26f, "NA");
                //       lc.addRoomLink("3321", 161.71f, 158.33f, "HOLLIS");
                grc.addRoomLink("3178", 85.74f, 240.24f, "DREWG");
                //       lc.addRoomLink("3321", 153.73f, 152.38f, "ANDDAL");
                grc.addRoomLink("3186", 115.24f, 240.24f, "TIMTHO");
                grc.addRoomLink("3074", 248.43f, 288.61f, "MIKEPAL");
                grc.addRoomLink("3084", 241.09f, 288.61f, "ERICDAI");
                //       lc.addRoomLink("3321", 169.81f, 152.38f, "NA");
                grc.addRoomLink("3174", 70.93f, 240.24f, "MARLAB");
                //     lc.addRoomLink("3321", 155.25f, 158.33f, "CHMCMU");
                grc.addRoomLink("3062", 226.28f, 240.24f, "ANGELACO");
                //   lc.addRoomLink("3321", 164.87f, 158.33f, "NA");
                grc.addRoomLink("3180", 93.21f, 240.24f, "LCOZZENS");
                //    lc.addRoomLink("3321", 158.54f, 158.33f, "NA");
                grc.addRoomLink("3176", 78.28f, 240.24f, "JUANCOL");
                grc.addRoomLink("3043", 186.04f, 255.03f, "NA");
                grc.addRoomLink("3389", 186.09f, 164.93f, "NA");
                grc.addRoomLink("3399", 162.82f, 195.03f, "CopyRoom");
                grc.addRoomLink("3999", 178.02f, 196.03f, "Stairs");
                //     lc.addRoomLink("3321", 166.52f, 152.38f, "RYBER");
                //    lc.addRoomLink("3321", 156.90f, 152.38f, "AMLUND");
                grc.addRoomLink("3033", 162.94f, 224.69f, "Kitchen");
                grc.addRoomLink("3064", 233.75f, 240.24f, "RGUSTAFS");
                grc.addRoomLink("3288", 100.56f, 131.11f, "LPAPPS");
                grc.addRoomLink("3270", 63.59f, 131.11f, "DALEW");
                grc.addRoomLink("3258", 48.78f, 131.11f, "BRUJO");
                grc.addRoomLink("3278", 70.93f, 131.11f, "WFONG");
                grc.addRoomLink("3039", 159.81f, 237.67f, "NA");
                grc.addRoomLink("3268", 56.25f, 131.11f, "MMERCURI");
                grc.addRoomLink("3290", 107.90f, 131.11f, "KLEADER");
                grc.addRoomLink("3334", 137.40f, 138.46f, "NA");
                grc.addRoomLink("3314", 152.34f, 131.11f, "KFILE");
                grc.addRoomLink("3143", 159.94f, 281.27f, "NA");
                grc.addRoomLink("3286", 93.21f, 131.11f, "MERTB");
                grc.addRoomLink("3233", 140.80f, 172.22f, "NA");
                // lc.addRoomLink("3185", 160.95f, 247.59f, "NA");
                grc.addRoomLink("3393", 160.37f, 181.19f, "NA");
                grc.addRoomLink("3304", 137.53f, 131.11f, "DMOREH");
                grc.addRoomLink("3313", 159.81f, 145.54f, "HALBER");
                grc.addRoomLink("3312", 144.87f, 131.11f, "MHOISECK");
                grc.addRoomLink("3316", 159.81f, 131.11f, "CORINMAR");
                grc.addRoomLink("3298", 115.24f, 131.11f, "NICOLM");
                grc.addRoomLink("3300", 122.71f, 131.11f, "XAVIERP");
                grc.addRoomLink("3302", 130.18f, 131.11f, "MARKCROF");
                grc.addRoomLink("3068", 248.43f, 240.24f, "CARRIEAM");
                grc.addRoomLink("3066", 241.09f, 240.24f, "MSELIN");
                grc.addRoomLink("3342", 204.12f, 131.11f, "LAURALON");
                grc.addRoomLink("3099", 203.49f, 209.86f, "NA");
                grc.addRoomLink("3308", 138.16f, 209.86f, "NA");
                grc.addRoomLink("3128", 144.87f, 288.61f, "MPEREZ");
                grc.addRoomLink("3354", 226.28f, 131.11f, "TERRIM");
                grc.addRoomLink("3346", 218.81f, 131.11f, "MIKEMOL");
                grc.addRoomLink("3344", 211.46f, 131.11f, "THDRELLE");
                grc.addRoomLink("3153", 87.90f, 264.42f, "MANDLAM,KSBAFNA");
                grc.addRoomLink("3060", 218.82f, 240.25f, "TSCHMIDT");
                grc.addRoomLink("3362", 218.82f, 179.46f, "TSTORCH");
                grc.addRoomLink("3145", 110.05f, 274.30f, "RADEOK");
                grc.addRoomLink("3122", 159.81f, 288.61f, "TODDGAR");
                grc.addRoomLink("3237", 99.92f, 165.29f, "KRISTENQ");
                grc.addRoomLink("3188", 122.70f, 240.26f, "SBUCHAN");
                grc.addRoomLink("3124", 152.34f, 288.61f, "DEREKMO");
                grc.addRoomLink("3101", 209.37f, 264.38f, "PABLOJB");
                grc.addRoomLink("3232", 122.70f, 179.45f, "LUZJARA");
                grc.addRoomLink("3225", 144.24f, 165.29f, "SUSKA,PABHANDA");
                grc.addRoomLink("3231", 122.08f, 165.29f, "EVANW,BIBARF");
                grc.addRoomLink("3247", 65.61f, 165.29f, "JANC");
                grc.addRoomLink("3218", 130.83f, 187.72f, "ALICEC");
                grc.addRoomLink("3204", 130.83f, 232.13f, "JASONLEE");
                grc.addRoomLink("3297", 122.08f, 155.42f, "ROBESM");
                grc.addRoomLink("3309", 144.24f, 155.42f, "AKANGAW,PGURU");
                grc.addRoomLink("3285", 99.92f, 155.42f, "DOHAMI");
                grc.addRoomLink("3206", 130.82f, 224.67f, "GREGGPI");
                grc.addRoomLink("3208", 130.82f, 217.20f, "CSLOTTA");
                grc.addRoomLink("3210", 130.82f, 209.86f, "SPYROS");
                grc.addRoomLink("3273", 65.61f, 155.42f, "NA");
                grc.addRoomLink("3271", 65.62f, 145.55f, "BSMIT");
                grc.addRoomLink("3212", 130.82f, 202.51f, "ALIHOB");
                grc.addRoomLink("3216", 130.82f, 195.17f, "PUVITH");
                grc.addRoomLink("3182", 100.56f, 240.24f, "JMEIER");
                grc.addRoomLink("3280", 78.28f, 131.11f, "SHINOY");
                grc.addRoomLink("3287", 99.92f, 145.54f, "SPATHANI");
                grc.addRoomLink("3301", 122.08f, 145.54f, "RODOLPHD");
                grc.addRoomLink("3311", 144.24f, 145.54f, "TACRIS,BRITTB");
                grc.addRoomLink("3293", 108.79f, 151.62f, "NICONS,JANEENS");
                grc.addRoomLink("3121", 167.66f, 274.17f, "ISABELF");
                grc.addRoomLink("3235", 108.79f, 166.43f, "LANIO");
                grc.addRoomLink("3245", 78.91f, 166.43f, "AHANSON");
                grc.addRoomLink("3291", 108.79f, 144.28f, "RSHARPL");
                grc.addRoomLink("3227", 130.94f, 166.43f, "MLALL");
                grc.addRoomLink("3307", 130.94f, 158.96f, "PKHODAK,JELIPE");
                grc.addRoomLink("3281", 87.81f, 145.51f, "SUSANJA");
                grc.addRoomLink("3305", 130.94f, 151.62f, "VAIBHAVA,JOEMRICK");
                grc.addRoomLink("3295", 108.79f, 158.96f, "STFRANK,JONSAMP");
                grc.addRoomLink("3197", 151.96f, 254.68f, "DDECATUR");
                grc.addRoomLink("3201", 167.66f, 254.68f, "ALEXISC");
                grc.addRoomLink("3181", 101.06f, 253.41f, "CHBARRET,ANDYEUN");
                grc.addRoomLink("3195", 144.24f, 254.68f, "ROBSIMP,BEROMO");
                grc.addRoomLink("3059", 218.43f, 253.41f, "DASCHWIE");
                grc.addRoomLink("3183", 110.05f, 254.68f, "VINELAP");
                grc.addRoomLink("3131", 131.07f, 260.75f, "FCORTES");
                grc.addRoomLink("3133", 131.07f, 268.10f, "PABERNAL");
                grc.addRoomLink("3135", 131.07f, 275.44f, "DILIPSIN");
                grc.addRoomLink("3243", 87.77f, 165.29f, "KEROSH");
                grc.addRoomLink("3367", 210.58f, 166.43f, "FRANKP");
                grc.addRoomLink("3051", 197.41f, 254.68f, "YVISHWA");
                grc.addRoomLink("3191", 131.07f, 253.41f, "JOLLYK,BREULAND");
                grc.addRoomLink("3190", 122.08f, 264.55f, "JOMANNIN,ILOSTFEL");
                grc.addRoomLink("3125", 151.96f, 274.17f, "CALVIND");
                grc.addRoomLink("3187", 122.08f, 254.68f, "JAYANG");
                grc.addRoomLink("3127", 144.24f, 274.17f, "ALESCURE");
                grc.addRoomLink("3163", 79.16f, 260.75f, "ALISONLU");
                grc.addRoomLink("3161", 79.16f, 268.10f, "GARRETTD,PASEHG");
                grc.addRoomLink("3175", 79.16f, 253.41f, "MARKBES");
                grc.addRoomLink("3363", 219.31f, 165.29f, "UFUKT");
                grc.addRoomLink("3256", 41.23f, 131.26f, "RIMESM");
                grc.addRoomLink("3072", 255.98f, 288.47f, "SCOTTCLA");
                grc.addRoomLink("3279", 78.91f, 144.15f, "BRENTSIN");
                grc.addRoomLink("3172", 63.47f, 240.35f, "FRANKPET");
                grc.addRoomLink("3070", 255.98f, 240.38f, "ACORLEY");
                grc.addRoomLink("3055", 209.44f, 254.68f, "YAMAGDI,MAKASIEW");
                grc.addRoomLink("3219", 167.66f, 165.29f, "YELENAK");
                grc.addRoomLink("3275", 78.91f, 159.09f, "JOCLARKE");
                grc.addRoomLink("3380", 210.70f, 232.14f, "LIZD");
                grc.addRoomLink("3170", 63.47f, 288.50f, "RSIVA");
                grc.addRoomLink("3368", 210.70f, 187.70f, "MARCOAL");
                grc.addRoomLink("3356", 233.83f, 131.26f, "JJESTER");
                grc.addRoomLink("3095", 218.43f, 275.57f, "MIRST");
                grc.addRoomLink("3104", 196.63f, 288.48f, "RDIXIT");
                grc.addRoomLink("3343", 210.58f, 144.15f, "GVERSTER");
                grc.addRoomLink("3147", 101.06f, 275.57f, "GREGVAR");
                grc.addRoomLink("3091", 218.43f, 260.63f, "NA");
                grc.addRoomLink("3339", 210.58f, 159.09f, "LISATHOM");
                grc.addRoomLink("3151", 101.06f, 260.63f, "JIMSMI");
                grc.addRoomLink("3283", 87.83f, 155.46f, "VINGU");
                grc.addRoomLink("3336", 196.63f, 131.23f, "SIMONBOO");
                grc.addRoomLink("3318", 167.28f, 131.26f, "MAZENS");
                grc.addRoomLink("3120", 167.28f, 288.46f, "STHENRY,CAROU");
                grc.addRoomLink("3358", 233.83f, 179.32f, "TGERBER");
                grc.addRoomLink("3303", 130.94f, 144.28f, "SKOSTED");
                grc.addRoomLink("3379", 196.52f, 224.67f, "GRARCHIB,KABABBAR");
                grc.addRoomLink("3369", 196.52f, 187.70f, "JESAM");
                grc.addRoomLink("3373", 196.52f, 202.51f, "MARVINQ,DASCHMID");
                grc.addRoomLink("3083", 240.39f, 275.38f, "DMANI");
                grc.addRoomLink("3107", 189.43f, 274.17f, "SANAIR");
                grc.addRoomLink("3213", 145.25f, 195.17f, "WAELA");
                //       lc.addRoomLink("3321", 159.32f, 154.28f, "NA");
                grc.addRoomLink("3077", 254.13f, 260.75f, "NA");
                grc.addRoomLink("3211", 144.11f, 204.41f, "GUANGW");
                grc.addRoomLink("3209", 144.11f, 215.43f, "MANIR");
                grc.addRoomLink("3331", 181.08f, 145.54f, "TINALANG");
                grc.addRoomLink("3109", 181.08f, 274.17f, "JIMEPES");
                grc.addRoomLink("3349", 232.10f, 158.96f, "SAMESHS");
                grc.addRoomLink("3333", 189.43f, 145.54f, "STLEIGH");
                grc.addRoomLink("3165", 65.24f, 260.75f, "WIRIVERA,BMJ");
                grc.addRoomLink("3347", 219.38f, 155.46f, "FLORENTR");
                grc.addRoomLink("3263", 56.88f, 158.96f, "RACHELHA");
                grc.addRoomLink("3056", 210.45f, 240.62f, "PABA,VIRAN");
                grc.addRoomLink("3265", 56.88f, 151.62f, "NA");
                grc.addRoomLink("3383", 196.52f, 179.09f, "PRITHAB,TMCCANTS");
                grc.addRoomLink("3251", 56.88f, 166.43f, "SAMFO");
                grc.addRoomLink("3067", 240.33f, 253.41f, "NDEREUCK");
                grc.addRoomLink("3189", 131.20f, 240.62f, "DINAG");
                grc.addRoomLink("3365", 210.45f, 179.09f, "GEETUM,JABELL");
                grc.addRoomLink("3081", 240.33f, 268.10f, "GERMYONG,JAPAG");
                grc.addRoomLink("3395", 184.37f, 184.92f, "NA");
                grc.addRoomLink("3079", 240.33f, 260.75f, "YVETTEW");
                grc.addRoomLink("3345", 219.35f, 145.51f, "TREYFLY,DAKING");
                grc.addRoomLink("3229", 131.20f, 179.09f, "BJORNJ,BRTINK");
                grc.addRoomLink("3217", 145.12f, 179.09f, "NA");
                grc.addRoomLink("3193", 145.12f, 240.62f, "ALVEISEH,JEPOUTON");
                grc.addRoomLink("3049", 196.52f, 240.62f, "CHENMLIU,SABINEM");
                // There are about 260 rooms in Redwest B3
            }
            catch (Exception ex)
            {
                Debug.Log("In AddRoomms caught exception " + ex.Message);
            }
        }
        public void CreatePointsForBredwB3floor(float height = 0, string bldname = "")
        {
            grc.regman.NewNodeRegion("msft-bredwb-f3", "purple", true);
            if (bldname != "")
            {
                //var bld = GameObject.Find(bldname);
                //var llm = bld.GetComponent<LatLongMap>();
                //grc.gm.initmods();
                //grc.gm.setmapper(llm);
            }
            else
            {
                grc.gm.initmods();
            }
            grc.yfloor = height;

            float[] Fz = { 138.45f, 172.25f, 247.65f, 281.45f };
            float[] Fx = { 30.3f, 50.0f, 53.5f, 72.0f, 94.0f, 116.0f, 138.0f, 173.6f, 203.0f, 225.0f, 244.0f, 247.0f, 266.5f };
            grc.gm.mod_name_pfx = lmm.getmodelprefix("rwb-f03-");
            grc.gm.mod_x_fak = 1 / 2.6f;
            grc.gm.mod_x_off = grc.gm.mod_x_fak * Fx[1];
            grc.gm.mod_z_fak = -1 / 2.6f;
            grc.gm.mod_z_off = grc.gm.mod_z_fak * Fz[0] + 4.1f;
            grc.AddNodePtxz("cv0-s", Fx[00], Fz[0]);
            var pfx = "";
            var cv0n = pfx + "cv0";
            var cv1n = pfx + "cv1";
            var cv2n = pfx + "cv2";
            var cv3n = pfx + "cv3";

            grc.LinkToPtxz("cv0-e", Fx[10], Fz[0], lname: cv0n);

            grc.AddNodePtxz("cv1-s", Fx[00], Fz[1]);
            grc.LinkToPtxz("cv1-e", Fx[10], Fz[1], lname: cv1n);

            grc.AddNodePtxz("cv2-s", Fx[02], Fz[2]);
            grc.LinkToPtxz("cv2-e", Fx[12], Fz[2], lname: cv2n);

            grc.AddNodePtxz("cv3-s", Fx[02], Fz[3]);
            grc.LinkToPtxz("cv3-e", Fx[12], Fz[3], lname: cv3n);

            var Fzmid0 = (Fz[0] + Fz[1]) / 2;
            grc.AddCrossLink("ch01", Fx[01], Fzmid0, cv0n, cv1n);
            grc.AddCrossLink("ch02", Fx[03], Fzmid0, cv0n, cv1n);
            grc.AddCrossLink("ch03", Fx[04], Fzmid0, cv0n, cv1n);
            grc.AddCrossLink("ch04", Fx[05], Fzmid0, cv0n, cv1n);
            grc.AddCrossLink("ch05", Fx[06], Fzmid0, cv0n, cv1n);
            grc.AddCrossLink("ch06", Fx[07], Fzmid0, cv0n, cv1n);
            grc.AddCrossLink("ch07", Fx[08], Fzmid0, cv0n, cv1n);
            grc.AddCrossLink("ch08", Fx[09], Fzmid0, cv0n, cv1n);
            grc.AddCrossLink("ch09", Fx[10], Fzmid0, cv0n, cv1n);

            var Fzmid1 = (Fz[1] + Fz[2]) / 2;
            grc.AddCrossLink("ch10", Fx[06], Fzmid1, cv1n, cv2n);
            grc.AddCrossLink("ch11", Fx[07], Fzmid1, cv1n, cv2n);
            grc.AddCrossLink("ch12", Fx[08], Fzmid1, cv1n, cv2n);

            var Fzmid2 = (Fz[2] + Fz[3]) / 2;
            grc.AddCrossLink("ch20", Fx[02], Fzmid2, cv2n, cv3n);
            grc.AddCrossLink("ch21", Fx[03], Fzmid2, cv2n, cv3n);
            grc.AddCrossLink("ch22", Fx[04], Fzmid2, cv2n, cv3n);
            grc.AddCrossLink("ch23", Fx[05], Fzmid2, cv2n, cv3n);
            grc.AddCrossLink("ch24", Fx[06], Fzmid2, cv2n, cv3n);
            grc.AddCrossLink("ch25", Fx[07], Fzmid2, cv2n, cv3n);
            grc.AddCrossLink("ch26", Fx[08], Fzmid2, cv2n, cv3n);
            grc.AddCrossLink("ch27", Fx[09], Fzmid2, cv2n, cv3n);
            grc.AddCrossLink("ch28", Fx[11], Fzmid2, cv2n, cv3n);
            grc.AddCrossLink("ch29", Fx[12], Fzmid2, cv2n, cv3n);

            AddRedwB3rooms();

            grc.gm.initmods();// reset
            grc.yfloor = 0;
        }

        public void createPointsFor_msft_b121()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-b121", "purple", saveToFile: true);
            var xs = 0;
            var zs = 0;
            //xs = 0;
            //zs = 0;

            // stairwell
            var d1 = 4.3f;
            var d2 = 4.1f;
            var land1 = 2.70f;// was 2.8
            var land2 = 2.50f;// was 2.6
            grc.AddNodePtxyz("b121-f01-str102-0", -820.2 + xs, 0.000, -481.8 + zs, comment: ""); //  1 nn:1 nl:0
            //grc.LinkToPtxyz("b121-s12-str102-1", -818.35 + xs, 1.400, -481.25 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-s12-str102-1", -818.12 + xs, 1.500, -481.13 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-s12-str102-2", -816.26 + xs, land1, -480.56 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-s12-str102-3", -815.3 + xs, land1, -480.2 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-s12-str102-4", -814.7 + xs, land1, -482.4 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-s12-str102-5", -816.2 + xs, land1, -483.0 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f02-str102-6", -818.4 + xs, d1, -483.77 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f02-str102-7", -820.16 + xs, d1, -484.45 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f02-str102-8", -820.83 + xs, d1, -482.29 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0

            grc.LinkToPtxyz("b121-f02-str102-10", -820.2 + xs, d1 + 0.000, -481.8 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            //grc.LinkToPtxyz("b121-s23-str102-11", -818.35 + xs, d1 + 1.200, -481.25 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-s23-str102-11", -818.12 + xs, d1 + 1.300, -481.13 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-s23-str102-12", -816.26 + xs, d1 + land2, -480.56 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-s23-str102-13", -815.3 + xs, d1 + land2, -480.2 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-s23-str102-14", -814.7 + xs, d1 + land2, -482.4 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-s23-str102-15", -816.2 + xs, d1 + land2, -483.0 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f03-str102-16", -818.4 + xs, d1 + d2, -483.77 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f03-str102-17", -820.16 + xs, d1 + d2, -484.45 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f03-str102-18", -821.82 + xs, d1 + d2, -482.29 + zs, LinkUse.stairs, comment: ""); //  1 nn:1 nl:0


            grc.AddNodePtxyz("b121-f01-lobby", -811.80 + xs, 0.200, -485.8 + zs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-os1-o001", -808.1 + xs, 0.000, -484.8 + zs, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b121-os1-o002", -807.200 + xs, 0.000, -486.0 + zs, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b121-os1-o003", -808.600 + xs, 0.000, -492.0 + zs, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b121-os1-o004", -817.900 + xs, 0.000, -503.0 + zs, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b121-os1-o005", -830.800 + xs, 0.000, -523.0 + zs, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1

            // path to 1071
            grc.LinkToPtxyz("b121-f01-lobby", "b121-f01-1000", -821.50 + xs, 0.200, -486.8 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f01-1531-0", -823.00 + xs, 0.000, -482.8 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f01-1531-1", -825.70 + xs, 0.000, -480.8 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f01-1203-1", -833.90 + xs, 0.000, -484.1 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f01-1202-1", -836.20 + xs, 0.000, -477.8 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f01-1205-1", -849.20 + xs, 0.000, -482.5 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f01-1071", -850.70 + xs, 0.000, -487.7 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0

            grc.AddLinkByNodeName("b121-f01-1531-0", "b121-f01-str102-0", LinkUse.walkway);

            grc.AddNodePtxyz("b121-f01-elev1-1", -825.42 + xs, 0.0, -477.35 + zs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f01-elev1-2", -826.24 + xs, 0.0, -474.97 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.AddLinkByNodeName("b121-f01-1531-0", "b121-f01-elev1-1", LinkUse.walkway);
            grc.AddLinkByNodeName("b121-f01-1531-1", "b121-f01-elev1-1", LinkUse.walkway);



            // path to 2060
            grc.AddNodePtxyz("b121-f02-2100-1", -824.1 + xs, 4.050, -480.9 + zs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f02-2203-1", -826.3 + xs, 4.000, -481.6 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f02-2203-2", -832.23 + xs, 4.000, -484.05 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f02-2200-1", -832.00 + xs, 4.130, -488.38 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f02-2200-9", -861.90 + xs, 4.130, -499.30 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f02-2060-1", -860.60 + xs, 4.280, -505.60 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f02-2060-2", -862.30 + xs, 4.280, -506.20 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.AddLinkByNodeName("b121-f02-2100-1", "b121-f02-str102-7", LinkUse.walkway);

            grc.AddNodePtxyz("b121-f02-elev1-1", -825.42 + xs, 4.050, -477.35 + zs,  comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f02-elev1-2", -826.24 + xs, 4.050, -474.97 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.AddLinkByNodeName("b121-f02-2100-1", "b121-f02-elev1-1", LinkUse.walkway);


            // path to 31
            var d3 = d1 + d2;
            grc.AddNodePtxyz("b121-f03-3100-1", -823.89 + xs, d3, -480.9 + zs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f03-elev1-1", -825.42 + xs, d3, -477.35 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f03-elev2-2", -826.24 + xs, d3, -474.97 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f03-3106-1", -826.80 + xs, d3, -472.02 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f03-3106-2", -825.49 + xs, d3, -471.11 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f03-31-1", -826.04 + xs, d3, -468.85 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-f03-31-2", -828.12 + xs, d3, -467.71 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
            grc.AddLinkByNodeName("b121-f03-3100-1", "b121-f03-str102-18", LinkUse.walkway);

            grc.AddNodePtxyz("b121-f03-3100-2", -821.76 + xs, d3, -480.29 + zs, comment: ""); //  1 nn:1 nl:0
            grc.AddLinkByNodeName("b121-f03-3100-2", "b121-f03-str102-18", LinkUse.walkway);
            grc.AddLinkByNodeName("b121-f03-3100-1", "b121-f03-3100-2", LinkUse.walkway);

            grc.AddNodePtxyz("b121-dw-d01", -824.40 + xs, 0.000, -593.2 + zs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b121-dw-d02", -777.0 + xs, 0.000, -725.6 + zs, LinkUse.driveway, comment: ""); //  2 nn:1 nl:1
            grc.AddLinkByNodeName("b121-dw-d02", "reg:msft-campus", LinkUse.driveway);
            grc.regman.SetRegion("default");
        }

        public void createPointsFor_msft_drones()
        {
            var xs = 0;
            var zs = 0;
            grc.regman.NewNodeRegion("msft-drones", "purple", saveToFile: true);
            grc.AddNodePtxyz("b19-dronepad", -458.5 + xs, 0.000, 104.1+ zs, comment: "");
            //grc.LinkToPtxyz("b19-dronepad-high", -458.5 + xs, 15.000, 104.1 + zs, LinkUse.droneway, comment: "");
            grc.AddNodePtxyz("b121-dronepad", -806.4 + xs, 0.000, -508.5 + zs, comment: "");
            //grc.LinkToPtxyz("b121-dronepad-high", -806.4 + xs, 15.000, -508.5 + zs, LinkUse.droneway, comment: "");
            //grc.AddLinkByNodeName("b121-dronepad-high", "b19-dronepad-high", LinkUse.droneway);

            grc.AddLinkByNodeName("b121-dronepad", "b121-os1-o004", LinkUse.walkway);
            grc.AddLinkByNodeName("b19-dronepad", "b19-os1-o00", LinkUse.walkway);
            grc.regman.SetRegion("default");
        }

        public void createPointsFor_msft_b33()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-b33", "purple", saveToFile: true);
            var xs = 0;
            var zs = 0;
            grc.AddNodePtxyz("b33-f01-room1", -567.600 + xs, 0.000, 470.400 + zs, comment: "");
            grc.LinkToPtxyz("b33-f01-lobby", -563.000 + xs, 0.000, 463.300 + zs, comment: "");
            grc.LinkToPtxyz("b33-o01-001", -558.900 + xs, 0.000, 451.500 + zs, comment: "");
            grc.regman.SetRegion("default");
        }



        public void createPointsFor_msft_b34()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-b34", "purple", saveToFile: true);
            var xs = 0;
            var zs = 0;
            grc.AddNodePtxyz("b34-f01-lobby", -702.300 + xs, 0.000, 431.400 + zs, comment: "");
            grc.LinkToPtxyz("b34-o01-001", -697.700 + xs, 0.000, 415.700 + zs, comment: "");
            grc.regman.SetRegion("default");
        }



        public void createPointsFor_msft_b19()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-b19", "purple", saveToFile: true);
            var xs = -3;
            var zs = -3;
            //xs = 0;
            //zs = 0;
            grc.AddNodePtxyz("b19-f01-lobby", -474.400+xs, 0.000, 95.700 + zs, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b19-f01-lobby", "b19-os1-o00b", -471.000 + xs, 0.000, 98.900 + zs, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b19-os1-o00b", "b19-os1-o00a", -467.400 + xs, 0.000, 99.700 + zs, LinkUse.walkway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("b19-os1-o00a", "b19-os1-o00", -459.500 + xs, 0.000, 105.600 + zs, LinkUse.walkway, comment: ""); //  4 nn:1 nl:1
            grc.LinkToPtxyz("b19-os1-o00", "b19-os1-o01", -458.300 + xs, 0.000, 112.900 + zs, LinkUse.walkway, comment: ""); //  5 nn:1 nl:1
            grc.LinkToPtxyz("b19-os1-o01", "b19-os1-o02", -462.000 + xs, 0.000, 118.400 + zs, LinkUse.walkway, comment: ""); //  6 nn:1 nl:1
            grc.LinkToPtxyz("b19-os1-o02", "b19-os1-o03", -459.400 + xs, 0.000, 132.300 + zs, LinkUse.walkway, comment: ""); //  7 nn:1 nl:1
            grc.LinkToPtxyz("b19-os1-o00", "b19-os2-o01", -450.400 + xs, 0.000, 101.100 + zs, LinkUse.walkway, comment: ""); //  8 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-lobby", "b19-f01-lbba", -469.000 + xs, 0.000, 92.900 + zs, LinkUse.walkway, comment: ""); //  9 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-lbba", "b19-f01-cp00", -467.100 + xs, 0.000, 93.400 + zs, LinkUse.walkway, comment: ""); //  10 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-lbba", "b19-f01-cp001", -465.900 + xs, 0.000, 93.700 + zs, LinkUse.walkway, comment: ""); //  11 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-lobby", "b19-f01-rm1003", -483.400 + xs, 0.000, 93.900 + zs, LinkUse.walkway, comment: ""); //  12 nn:1 nl:1
            grc.AddLinkByNodeName("b19-os1-o00b", "b19-f01-lbba", LinkUse.walkway); //  13 nn:0 nl:1
            grc.LinkToPtxyz("b19-os1-o00b", "b19-f01-cp0b0", -471.200 + xs, 0.000, 99.800 + zs, LinkUse.walkway, comment: ""); //  14 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp0b0", "b19-f01-cp0b1", -471.600 + xs, 0.000, 101.200 + zs, LinkUse.walkway, comment: ""); //  15 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp0b0", "b19-f01-cp0b2", -474.000 + xs, 0.000, 99.500 + zs, LinkUse.walkway, comment: ""); //  16 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp001", "b19-f01-cp01", -463.400 + xs, 0.000, 94.940 + zs, LinkUse.walkway, comment: ""); //  17 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp01", "b19-f01-cp02", -462.560 + xs, 0.000, 95.300 + zs, LinkUse.walkway, comment: ""); //  18 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp001", "b19-f01-rm1004", -467.600 + xs, 0.000, 96.500 + zs, LinkUse.walkway, comment: ""); //  19 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp01", "b19-f01-rm1005", -465.100 + xs, 0.000, 97.400 + zs, LinkUse.walkway, comment: ""); //  20 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp02", "b19-f01-rm1006", -462.000 + xs, 0.000, 98.100 + zs, LinkUse.walkway, comment: ""); //  21 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp00", "b19-f01-cp021", -465.100 + xs, 0.000, 87.880 + zs, LinkUse.walkway, comment: ""); //  22 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp021", "b19-f01-cp031", -468.100 + xs, 0.000, 86.900 + zs, LinkUse.walkway, comment: ""); //  23 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp031", "b19-f01-rm1001", -469.000 + xs, 0.000, 89.800 + zs, LinkUse.walkway, comment: ""); //  24 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp031", "b19-f01-cp032", -472.150 + xs, 0.000, 85.670 + zs, LinkUse.walkway, comment: ""); //  25 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp032", "b19-f01-rm1002", -472.900 + xs, 0.000, 88.500 + zs, LinkUse.walkway, comment: ""); //  26 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp021", "b19-f01-cp022", -464.060 + xs, 0.000, 84.800 + zs, LinkUse.walkway, comment: ""); //  27 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp022", "b19-f01-cp023", -463.800 + xs, 0.000, 84.000 + zs, LinkUse.walkway, comment: ""); //  28 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp023", "b19-f01-cp024", -462.700 + xs, 0.000, 80.800 + zs, LinkUse.walkway, comment: ""); //  29 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp024", "b19-f01-cp025", -461.700 + xs, 0.000, 78.000 + zs, LinkUse.walkway, comment: ""); //  30 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp025", "b19-f01-cp026", -461.000 + xs, 0.000, 76.100 + zs, LinkUse.walkway, comment: ""); //  31 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp026", "b19-f01-cp027", -461.000 + xs, 0.000, 74.140 + zs, LinkUse.walkway, comment: ""); //  32 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp027", "b19-f01-cp028", -458.100 + xs, 0.000, 68.000 + zs, LinkUse.walkway, comment: ""); //  33 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp028", "b19-f01-cp029", -457.900 + xs, 0.000, 67.200 + zs, LinkUse.walkway, comment: ""); //  34 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp029", "b19-f01-cp041", -456.500 + xs, 0.000, 68.300 + zs, LinkUse.walkway, comment: ""); //  35 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp029", "b19-f01-cp029a", -456.100 + xs, 0.000, 64.800 + zs, LinkUse.walkway, comment: ""); //  36 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp024", "b19-f01-cp051", -458.000 + xs, 0.000, 82.700 + zs, LinkUse.walkway, comment: ""); //  37 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp051", "b19-f01-cp052", -456.900 + xs, 0.000, 82.800 + zs, LinkUse.walkway, comment: ""); //  38 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp052", "b19-f01-cp053", -451.600 + xs, 0.000, 84.800 + zs, LinkUse.walkway, comment: ""); //  39 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp053", "b19-f01-cp054", -450.200 + xs, 0.000, 85.100 + zs, LinkUse.walkway, comment: ""); //  40 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp054", "b19-f01-cp054a", -447.300 + xs, 0.000, 86.100 + zs, LinkUse.walkway, comment: ""); //  41 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp054", "b19-f01-cp055", -449.700 + xs, 0.000, 87.100 + zs, LinkUse.walkway, comment: ""); //  42 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp055", "b19-f01-cp056", -451.000 + xs, 0.000, 90.400 + zs, LinkUse.walkway, comment: ""); //  43 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp056", "b19-f01-cp057", -452.500 + xs, 0.000, 91.740 + zs, LinkUse.walkway, comment: ""); //  44 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp057", "b19-f01-cp058", -457.600 + xs, 0.000, 94.300 + zs, LinkUse.walkway, comment: ""); //  45 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp058", "b19-f01-cp059", -458.250 + xs, 0.000, 94.620 + zs, LinkUse.walkway, comment: ""); //  46 nn:1 nl:1
            grc.AddLinkByNodeName("b19-f01-cp059", "b19-f01-cp02", LinkUse.walkway); //  47 nn:0 nl:1
            grc.LinkToPtxyz("b19-f01-cp051", "b19-f01-cp051a", -458.850 + xs, 0.000, 85.050 + zs, LinkUse.walkway, comment: ""); //  48 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp051a", "b19-f01-cp051b", -460.200 + xs, 0.000, 88.840 + zs, LinkUse.walkway, comment: ""); //  49 nn:1 nl:1
            grc.AddLinkByNodeName("b19-f01-cp051b", "b19-f01-cp02", LinkUse.walkway); //  50 nn:0 nl:1
            grc.LinkToPtxyz("b19-f01-cp022", "b19-f01-rm1012", -467.100 + xs, 0.000, 84.900 + zs, LinkUse.walkway, comment: ""); //  51 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-rm1012", "b19-f01-rm1012a", -471.000 + xs, 0.000, 83.800 + zs, LinkUse.walkway, comment: ""); //  52 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp023", "b19-f01-rm1013", -466.400 + xs, 0.000, 82.300 + zs, LinkUse.walkway, comment: ""); //  53 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp024", "b19-f01-rm1014", -466.100 + xs, 0.000, 79.900 + zs, LinkUse.walkway, comment: ""); //  54 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp025", "b19-f01-rm1015", -465.100 + xs, 0.000, 78.000 + zs, LinkUse.walkway, comment: ""); //  55 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp026", "b19-f01-rm1016", -464.000 + xs, 0.000, 75.300 + zs, LinkUse.walkway, comment: ""); //  56 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp027", "b19-f01-rm1017", -462.500 + xs, 0.000, 70.400 + zs, LinkUse.walkway, comment: ""); //  57 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp029", "b19-f01-rm1018", -461.000 + xs, 0.000, 67.200 + zs, LinkUse.walkway, comment: ""); //  58 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp029", "b19-f01-rm1019", -460.000 + xs, 0.000, 63.900 + zs, LinkUse.walkway, comment: ""); //  59 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp052", "b19-f01-rm1021", -454.300 + xs, 0.000, 80.400 + zs, LinkUse.walkway, comment: ""); //  60 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp053", "b19-f01-rm1022", -450.900 + xs, 0.000, 81.600 + zs, LinkUse.walkway, comment: ""); //  61 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp054", "b19-f01-rm1023", -448.200 + xs, 0.000, 82.800 + zs, LinkUse.walkway, comment: ""); //  62 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp054a", "b19-f01-rm1024", -445.600 + xs, 0.000, 83.500 + zs, LinkUse.walkway, comment: ""); //  63 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp055", "b19-f01-rm1025", -447.900 + xs, 0.000, 89.100 + zs, LinkUse.walkway, comment: ""); //  64 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp056", "b19-f01-rm1026", -449.200 + xs, 0.000, 92.600 + zs, LinkUse.walkway, comment: ""); //  65 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp057", "b19-f01-rm1027", -452.300 + xs, 0.000, 94.700 + zs, LinkUse.walkway, comment: ""); //  66 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp058", "b19-f01-rm1028", -455.300 + xs, 0.000, 96.400 + zs, LinkUse.walkway, comment: ""); //  67 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp059", "b19-f01-rm1029", -458.200 + xs, 0.000, 97.600 + zs, LinkUse.walkway, comment: ""); //  68 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp051", "b19-f01-cp061", -455.600 + xs, 0.000, 75.900 + zs, LinkUse.walkway, comment: ""); //  69 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp061", "b19-f01-cp062", -455.110 + xs, 0.000, 74.440 + zs, LinkUse.walkway, comment: ""); //  70 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp061", "b19-f01-cp061a", -460.200 + xs, 0.000, 74.300 + zs, LinkUse.walkway, comment: ""); //  71 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp062", "b19-f01-cp063", -453.400 + xs, 0.000, 69.600 + zs, LinkUse.walkway, comment: ""); //  72 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp063", "b19-f01-cp064", -451.300 + xs, 0.000, 69.600 + zs, LinkUse.walkway, comment: ""); //  73 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp064", "b19-f01-cp065", -448.200 + xs, 0.000, 68.400 + zs, LinkUse.walkway, comment: ""); //  74 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp065", "b19-f01-cp066", -445.400 + xs, 0.000, 73.600 + zs, LinkUse.walkway, comment: ""); //  75 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp066", "b19-f01-cp067a", -445.700 + xs, 0.000, 77.600 + zs, LinkUse.walkway, comment: ""); //  76 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp066", "b19-f01-cp067b", -446.600 + xs, 0.000, 78.000 + zs, LinkUse.walkway, comment: ""); //  77 nn:1 nl:1
            grc.AddLinkByNodeName("b19-f01-cp067a", "b19-f01-cp067b", LinkUse.walkway); //  78 nn:0 nl:1
            grc.AddLinkByNodeName("b19-f01-cp063", "b19-f01-cp041", LinkUse.walkway); //  79 nn:0 nl:1
            grc.AddLinkByNodeName("b19-f01-cp061a", "b19-f01-cp027", LinkUse.walkway); //  80 nn:0 nl:1
            grc.LinkToPtxyz("b19-f01-cp029a", "b19-f01-rm1030", -456.100 + xs, 0.000, 62.200 + zs, LinkUse.walkway, comment: ""); //  81 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp041", "b19-f01-rm1031", -454.400 + xs, 0.000, 65.900 + zs, LinkUse.walkway, comment: ""); //  82 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp064", "b19-f01-rm1032", -451.300 + xs, 0.000, 67.000 + zs, LinkUse.walkway, comment: ""); //  83 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp065", "b19-f01-rm1033", -448.700 + xs, 0.000, 64.500 + zs, LinkUse.walkway, comment: ""); //  84 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-rm1033", "b19-f01-rm1033a", -452.200 + xs, 0.000, 63.600 + zs, LinkUse.walkway, comment: ""); //  85 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp067a", "b19-f01-rm1034", -443.500 + xs, 0.000, 77.100 + zs, LinkUse.walkway, comment: ""); //  86 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp067a", "b19-f01-rm1035", -444.400 + xs, 0.000, 79.900 + zs, LinkUse.walkway, comment: ""); //  87 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp067b", "b19-f01-rm1036", -450.000 + xs, 0.000, 78.500 + zs, LinkUse.walkway, comment: ""); //  88 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp067b", "b19-f01-rm1037", -448.700 + xs, 0.000, 75.900 + zs, LinkUse.walkway, comment: ""); //  89 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp061", "b19-f01-rm1038", -453.100 + xs, 0.000, 77.400 + zs, LinkUse.walkway, comment: ""); //  90 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp061", "b19-f01-rm1039", -452.300 + xs, 0.000, 74.800 + zs, LinkUse.walkway, comment: ""); //  91 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp021", "b19-f01-sp1003", -463.735 + xs, 0.180, 88.964 + zs, LinkUse.walkway, comment: ""); //  92 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp058", "b19-f01-sp1030", -457.491 + xs, 0.180, 92.681 + zs, LinkUse.walkway, comment: ""); //  93 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp052", "b19-f01-sp1029", -456.760 + xs, 0.180, 85.280 + zs, LinkUse.walkway, comment: ""); //  94 nn:1 nl:1
            grc.AddNodePtxyz("dw-B19-c01", -525.500 + xs, 0.000, 106.400 + zs, comment: ""); //  95 nn:1 nl:0
            grc.LinkToPtxyz("dw-B19-c01", "dw-B19-c02", -520.260 + xs, 0.000, 105.260 + zs, LinkUse.driveway, comment: ""); //  96 nn:1 nl:1
            //grc.AddLinkByNodeName("dw-B19-c01", "reg:msft-campus", LinkUse.driveway); //  97 nn:0 nl:1
            grc.LinkToPtxyz("dw-B19-c01", "dw-B19-d01", -525.500 + xs, 0.000, 117.000 + zs, LinkUse.driveway, comment: ""); //  96 nn:1 nl:1
            grc.LinkToPtxyz("dw-B19-d01", "dw-B19-d02", -521.500 + xs, 0.000, 128.000 + zs, LinkUse.driveway, comment: ""); //  96 nn:1 nl:1
            grc.LinkToPtxyz("dw-B19-d02", "dw-B19-d03", -438.500 + xs, 0.000, 154.400 + zs, LinkUse.driveway, comment: ""); //  96 nn:1 nl:1
            grc.LinkToPtxyz("dw-B19-d03", "dw-B19-d04", -430.160 + xs, 0.000, 150.400 + zs, LinkUse.driveway, comment: ""); //  96 nn:1 nl:1
            grc.AddLinkByNodeName("dw-B19-d04", "reg:msft-campus", LinkUse.driveway); //  97 nn:0 nl:1
            grc.regman.SetRegion("default");
        }

        public void CreateGraphForOsmImport_msftb19area()  // machine generated on 2020-06-23 13:25:36.547991 local time  - do not edit
        {
            grc.regman.NewNodeRegion("Microsoft B19 Area", "green", saveToFile: true);
            var xs = 0;  // offsets for error correction
            var zs = 0;
            grc.AddNodePtxz("osm7473295912", -784.539 + xs, 188.724 + zs);
            grc.AddNodePtxz("osm409799028", -738.025 + xs, 121.077 + zs);
            grc.AddNodePtxz("osm2671027615", -647.710 + xs, 217.878 + zs);
            grc.AddNodePtxz("osm2671027616", -659.672 + xs, 251.988 + zs);
            grc.AddNodePtxz("osm2671027619", -568.654 + xs, 208.354 + zs);
            grc.AddNodePtxz("osm2671027618", -602.852 + xs, 196.385 + zs);
            grc.AddNodePtxz("osm3834803720", -818.985 + xs, 405.929 + zs);
            grc.AddNodePtxz("osm4753326325", -697.765 + xs, 420.971 + zs);
            grc.AddNodePtxz("osm4758568841", -588.438 + xs, 436.084 + zs);
            grc.AddNodePtxz("osm4758568844", -566.889 + xs, 447.691 + zs);
            grc.AddNodePtxz("osm4740268536", -615.800 + xs, 427.089 + zs);
            grc.AddNodePtxz("osm4753326326", -721.622 + xs, 433.146 + zs);
            grc.AddNodePtxz("osm4760408332", -707.537 + xs, 419.804 + zs);
            grc.AddNodePtxz("osm4775434185", -667.702 + xs, 284.275 + zs);
            grc.AddNodePtxz("osm2670280688", -626.733 + xs, 204.194 + zs);
            grc.AddNodePtxz("osm4779937956", -892.888 + xs, 369.785 + zs);
            grc.AddNodePtxz("osm4983712038", -637.026 + xs, -4.294 + zs);
            grc.AddNodePtxz("osm2672290205", -592.146 + xs, 275.113 + zs);
            grc.AddNodePtxz("osm7065046248", -472.236 + xs, 102.825 + zs);
            grc.AddNodePtxz("osm4753326215", -631.774 + xs, 472.531 + zs);
            grc.AddNodePtxz("osm4806471174", -552.890 + xs, 274.856 + zs);
            grc.AddNodePtxz("osm4806471175", -559.047 + xs, 272.669 + zs);
            grc.AddNodePtxz("osm4098517739", -578.096 + xs, 279.146 + zs);
            grc.AddNodePtxz("osm4098517743", -597.539 + xs, 288.729 + zs);
            grc.AddNodePtxz("osm4098517744", -613.362 + xs, 300.366 + zs);
            grc.AddNodePtxz("osm4806537128", -614.671 + xs, 304.196 + zs);
            grc.AddNodePtxz("osm4773452876", -612.845 + xs, 294.793 + zs);
            grc.AddNodePtxz("osm4098517727", -552.755 + xs, 305.962 + zs);
            grc.AddNodePtxz("osm4098517737", -591.866 + xs, 324.962 + zs);
            grc.AddNodePtxz("osm7120384994", -813.784 + xs, 417.089 + zs);
            grc.AddNodePtxz("osm7120525634", -780.098 + xs, 190.323 + zs);
            grc.AddNodePtxz("osm7120525642", -795.152 + xs, 222.051 + zs);
            grc.AddNodePtxz("osm2675737178", -702.083 + xs, 49.669 + zs);
            grc.AddNodePtxz("osm336768326", -723.129 + xs, 87.949 + zs);
            grc.AddNodePtxz("osm336768316", -713.715 + xs, 61.601 + zs);
            grc.AddNodePtxz("osm336772826", -685.630 + xs, 48.101 + zs);
            grc.AddNodePtxz("osm336772818", -658.859 + xs, 57.401 + zs);
            grc.AddNodePtxz("osm2671035422", -538.063 + xs, 221.425 + zs);
            grc.AddNodePtxz("osm4773716039", -603.632 + xs, 253.120 + zs);
            grc.AddNodePtxz("osm7123400113", -653.026 + xs, 205.127 + zs);
            grc.AddNodePtxz("osm4777391860", -609.842 + xs, 184.003 + zs);
            grc.AddNodePtxz("osm7123470523", -510.943 + xs, 97.686 + zs);
            grc.AddNodePtxz("osm7123470544", -481.265 + xs, 68.152 + zs);
            grc.AddNodePtxz("osm4779937955", -845.372 + xs, 394.156 + zs);
            grc.AddNodePtxz("osm7132304286", -876.850 + xs, 354.442 + zs);
            grc.AddNodePtxz("osm7132304293", -812.626 + xs, 343.619 + zs);
            grc.AddNodePtxz("osm7132371562", -572.944 + xs, 43.967 + zs);
            grc.AddNodePtxz("osm7132371567", -562.631 + xs, 80.157 + zs);
            grc.AddNodePtxz("osm2675681645", -644.467 + xs, 167.872 + zs);
            grc.AddNodePtxz("osm7132371575", -624.827 + xs, 138.371 + zs);
            grc.AddNodePtxz("osm4806537131", -679.457 + xs, 164.678 + zs);
            grc.AddNodePtxz("osm7132384717", -564.540 + xs, 474.406 + zs);
            grc.AddNodePtxz("osm7132384722", -561.593 + xs, 472.595 + zs);
            grc.AddNodePtxz("osm4753385702", -784.379 + xs, 426.213 + zs);
            grc.AddNodePtxz("osm4983712048", -660.980 + xs, -21.652 + zs);
            grc.AddNodePtxz("osm4781518455", -708.283 + xs, 175.247 + zs);
            grc.AddNodePtxz("osm4806471176", -556.231 + xs, 330.619 + zs);
            grc.AddNodePtxz("osm4773452875", -570.413 + xs, 337.749 + zs);
            grc.AddNodePtxz("osm4773476250", -681.155 + xs, 244.966 + zs);
            grc.AddNodePtxz("osm4779937984", -706.109 + xs, 241.682 + zs);
            grc.AddNodePtxz("osm4060068699", -560.638 + xs, 185.654 + zs);
            grc.AddNodePtxz("osm4806471180", -547.884 + xs, 164.847 + zs);
            grc.AddNodePtxz("osm7132384719", -591.803 + xs, 539.034 + zs);
            grc.AddNodePtxz("osm4806537129", -603.069 + xs, 119.236 + zs);
            grc.AddNodePtxz("osm7472985454", -447.827 + xs, 67.971 + zs);
            grc.AddNodePtxz("osm7484825433", -838.399 + xs, 261.872 + zs);
            grc.AddNodePtxz("osm3516771316", -807.549 + xs, 251.790 + zs);
            grc.AddNodePtxz("osm7484830111", -782.119 + xs, 234.593 + zs);
            grc.AddNodePtxz("osm4985583154", -782.964 + xs, 37.672 + zs);
            grc.AddNodePtxz("osm4985583152", -721.040 + xs, 22.410 + zs);
            grc.AddNodePtxz("osm4985583151", -711.675 + xs, 17.948 + zs);
            grc.AddNodePtxz("osm321406063", -488.626 + xs, 110.902 + zs);
            grc.AddNodePtxz("osm321406064", -507.757 + xs, 104.234 + zs);
            grc.AddNodePtxz("osm7473295815", -510.352 + xs, 98.823 + zs);
            grc.AddNodePtxz("osm7473295819", -511.578 + xs, 96.470 + zs);
            grc.AddNodePtxz("osm321406065", -513.707 + xs, 92.216 + zs);
            grc.AddNodePtxz("osm321406066", -510.374 + xs, 82.521 + zs);
            grc.AddNodePtxz("osm6323327743", -503.733 + xs, 79.028 + zs);
            grc.AddNodePtxz("osm6323327701", -463.281 + xs, 59.401 + zs);
            grc.AddNodePtxz("osm321406067", -460.539 + xs, 58.177 + zs);
            grc.AddNodePtxz("osm321406068", -450.904 + xs, 61.412 + zs);
            grc.AddNodePtxz("osm321406069", -444.777 + xs, 74.069 + zs);
            grc.AddNodePtxz("osm321406070", -451.226 + xs, 92.710 + zs);
            grc.AddNodePtxz("osm6323327724", -463.123 + xs, 98.372 + zs);
            grc.AddNodePtxz("osm7473295813", -486.518 + xs, 109.802 + zs);
            grc.AddNodePtxz("osm321406158", -616.769 + xs, 115.346 + zs);
            grc.AddNodePtxz("osm2660169201", -611.932 + xs, 117.026 + zs);
            grc.AddNodePtxz("osm2660169203", -611.289 + xs, 115.162 + zs);
            grc.AddNodePtxz("osm2660169196", -602.700 + xs, 118.150 + zs);
            grc.AddNodePtxz("osm2660169206", -603.306 + xs, 119.876 + zs);
            grc.AddNodePtxz("osm321406159", -598.610 + xs, 121.555 + zs);
            grc.AddNodePtxz("osm321406160", -607.658 + xs, 147.330 + zs);
            grc.AddNodePtxz("osm321406161", -589.745 + xs, 153.367 + zs);
            grc.AddNodePtxz("osm2660169277", -591.437 + xs, 158.254 + zs);
            grc.AddNodePtxz("osm2660169274", -589.776 + xs, 158.799 + zs);
            grc.AddNodePtxz("osm2660169269", -592.731 + xs, 167.451 + zs);
            grc.AddNodePtxz("osm2660169271", -594.478 + xs, 166.917 + zs);
            grc.AddNodePtxz("osm321406162", -596.053 + xs, 171.471 + zs);
            grc.AddNodePtxz("osm321406163", -605.495 + xs, 168.357 + zs);
            grc.AddNodePtxz("osm7469570210", -610.158 + xs, 181.407 + zs);
            grc.AddNodePtxz("osm321406164", -610.933 + xs, 183.582 + zs);
            grc.AddNodePtxz("osm7469570217", -606.820 + xs, 185.006 + zs);
            grc.AddNodePtxz("osm321406165", -601.387 + xs, 186.802 + zs);
            grc.AddNodePtxz("osm2660169266", -603.071 + xs, 191.565 + zs);
            grc.AddNodePtxz("osm2660169264", -601.345 + xs, 192.227 + zs);
            grc.AddNodePtxz("osm2660169258", -604.376 + xs, 200.695 + zs);
            grc.AddNodePtxz("osm2660169261", -606.089 + xs, 200.061 + zs);
            grc.AddNodePtxz("osm321406166", -607.836 + xs, 204.905 + zs);
            grc.AddNodePtxz("osm7350890235", -622.026 + xs, 199.825 + zs);
            grc.AddNodePtxz("osm321406167", -623.048 + xs, 200.418 + zs);
            grc.AddNodePtxz("osm321406168", -623.501 + xs, 202.648 + zs);
            grc.AddNodePtxz("osm321406169", -629.476 + xs, 205.489 + zs);
            grc.AddNodePtxz("osm321406170", -632.862 + xs, 205.455 + zs);
            grc.AddNodePtxz("osm321406171", -637.725 + xs, 219.308 + zs);
            grc.AddNodePtxz("osm2660169253", -642.448 + xs, 217.572 + zs);
            grc.AddNodePtxz("osm2660169251", -643.144 + xs, 219.489 + zs);
            grc.AddNodePtxz("osm2660169248", -651.612 + xs, 216.558 + zs);
            grc.AddNodePtxz("osm2660169256", -650.946 + xs, 214.695 + zs);
            grc.AddNodePtxz("osm321406172", -655.808 + xs, 212.951 + zs);
            grc.AddNodePtxz("osm7469570234", -653.856 + xs, 207.457 + zs);
            grc.AddNodePtxz("osm321406173", -652.535 + xs, 203.695 + zs);
            grc.AddNodePtxz("osm7469570224", -654.086 + xs, 203.172 + zs);
            grc.AddNodePtxz("osm321406174", -667.945 + xs, 198.459 + zs);
            grc.AddNodePtxz("osm321406175", -671.301 + xs, 207.853 + zs);
            grc.AddNodePtxz("osm2660169232", -676.049 + xs, 206.188 + zs);
            grc.AddNodePtxz("osm2660169230", -676.699 + xs, 208.041 + zs);
            grc.AddNodePtxz("osm2660169227", -685.219 + xs, 205.021 + zs);
            grc.AddNodePtxz("osm2660169235", -684.638 + xs, 203.367 + zs);
            grc.AddNodePtxz("osm321406176", -689.396 + xs, 201.698 + zs);
            grc.AddNodePtxz("osm321406177", -683.129 + xs, 183.810 + zs);
            grc.AddNodePtxz("osm7469570230", -707.440 + xs, 175.535 + zs);
            grc.AddNodePtxz("osm321406178", -709.121 + xs, 174.912 + zs);
            grc.AddNodePtxz("osm2660169219", -707.546 + xs, 170.192 + zs);
            grc.AddNodePtxz("osm2660169216", -709.176 + xs, 169.626 + zs);
            grc.AddNodePtxz("osm2660169212", -706.227 + xs, 160.987 + zs);
            grc.AddNodePtxz("osm2660169222", -704.504 + xs, 161.593 + zs);
            grc.AddNodePtxz("osm321406179", -702.838 + xs, 156.745 + zs);
            grc.AddNodePtxz("osm7469570328", -682.135 + xs, 163.737 + zs);
            grc.AddNodePtxz("osm7469570335", -678.751 + xs, 164.952 + zs);
            grc.AddNodePtxz("osm321406180", -676.848 + xs, 165.682 + zs);
            grc.AddNodePtxz("osm7469570331", -673.629 + xs, 156.344 + zs);
            grc.AddNodePtxz("osm2675681594", -673.488 + xs, 155.941 + zs);
            grc.AddNodePtxz("osm2675681602", -671.227 + xs, 156.691 + zs);
            grc.AddNodePtxz("osm2660169245", -668.630 + xs, 157.627 + zs);
            grc.AddNodePtxz("osm2660169237", -668.020 + xs, 155.856 + zs);
            grc.AddNodePtxz("osm2660169240", -659.400 + xs, 158.791 + zs);
            grc.AddNodePtxz("osm2660169243", -660.013 + xs, 160.538 + zs);
            grc.AddNodePtxz("osm321406182", -655.196 + xs, 162.242 + zs);
            grc.AddNodePtxz("osm7469570252", -655.832 + xs, 164.052 + zs);
            grc.AddNodePtxz("osm321406183", -658.633 + xs, 171.965 + zs);
            grc.AddNodePtxz("osm321406184", -651.379 + xs, 174.591 + zs);
            grc.AddNodePtxz("osm2660169209", -647.635 + xs, 172.697 + zs);
            grc.AddNodePtxz("osm2675681636", -646.763 + xs, 169.003 + zs);
            grc.AddNodePtxz("osm2675681646", -642.042 + xs, 166.611 + zs);
            grc.AddNodePtxz("osm321406187", -638.396 + xs, 168.556 + zs);
            grc.AddNodePtxz("osm321406188", -634.752 + xs, 166.611 + zs);
            grc.AddNodePtxz("osm321406189", -632.150 + xs, 159.232 + zs);
            grc.AddNodePtxz("osm7469570271", -640.186 + xs, 156.481 + zs);
            grc.AddNodePtxz("osm7469570264", -641.702 + xs, 155.962 + zs);
            grc.AddNodePtxz("osm321406190", -641.944 + xs, 155.879 + zs);
            grc.AddNodePtxz("osm7469570262", -641.298 + xs, 153.970 + zs);
            grc.AddNodePtxz("osm2660169284", -640.319 + xs, 151.081 + zs);
            grc.AddNodePtxz("osm2660169282", -642.078 + xs, 150.479 + zs);
            grc.AddNodePtxz("osm2660169279", -639.110 + xs, 141.957 + zs);
            grc.AddNodePtxz("osm2660169287", -637.312 + xs, 142.581 + zs);
            grc.AddNodePtxz("osm2675681628", -636.370 + xs, 139.798 + zs);
            grc.AddNodePtxz("osm2675681627", -635.681 + xs, 137.768 + zs);
            grc.AddNodePtxz("osm7469570245", -635.471 + xs, 137.840 + zs);
            grc.AddNodePtxz("osm321406192", -625.771 + xs, 141.193 + zs);
            grc.AddNodePtxz("osm7469570241", -625.095 + xs, 139.167 + zs);
            grc.AddNodePtxz("osm7469570189", -623.924 + xs, 135.797 + zs);
            grc.AddNodePtxz("osm321406211", -826.301 + xs, 340.735 + zs);
            grc.AddNodePtxz("osm4779937963", -814.433 + xs, 344.933 + zs);
            grc.AddNodePtxz("osm4779937962", -813.840 + xs, 343.179 + zs);
            grc.AddNodePtxz("osm4779937961", -804.443 + xs, 346.420 + zs);
            grc.AddNodePtxz("osm321406212", -805.176 + xs, 348.474 + zs);
            grc.AddNodePtxz("osm4779937960", -799.483 + xs, 350.471 + zs);
            grc.AddNodePtxz("osm321406213", -820.309 + xs, 409.936 + zs);
            grc.AddNodePtxz("osm321406214", -812.328 + xs, 412.740 + zs);
            grc.AddNodePtxz("osm4779937954", -814.111 + xs, 418.055 + zs);
            grc.AddNodePtxz("osm4779937953", -812.127 + xs, 418.789 + zs);
            grc.AddNodePtxz("osm4779937952", -815.739 + xs, 428.777 + zs);
            grc.AddNodePtxz("osm4779937951", -817.525 + xs, 428.118 + zs);
            grc.AddNodePtxz("osm321406215", -821.791 + xs, 440.037 + zs);
            grc.AddNodePtxz("osm321406216", -840.756 + xs, 433.402 + zs);
            grc.AddNodePtxz("osm4781664647", -858.029 + xs, 481.536 + zs);
            grc.AddNodePtxz("osm321406217", -860.781 + xs, 480.602 + zs);
            grc.AddNodePtxz("osm4781664644", -861.021 + xs, 481.288 + zs);
            grc.AddNodePtxz("osm4781664648", -862.016 + xs, 484.020 + zs);
            grc.AddNodePtxz("osm321406218", -864.535 + xs, 483.198 + zs);
            grc.AddNodePtxz("osm4781664649", -864.775 + xs, 483.813 + zs);
            grc.AddNodePtxz("osm321406219", -871.478 + xs, 481.502 + zs);
            grc.AddNodePtxz("osm7346635974", -875.564 + xs, 480.103 + zs);
            grc.AddNodePtxz("osm4781664650", -875.275 + xs, 479.212 + zs);
            grc.AddNodePtxz("osm7346635975", -877.722 + xs, 478.351 + zs);
            grc.AddNodePtxz("osm4781664643", -876.892 + xs, 476.021 + zs);
            grc.AddNodePtxz("osm4781664651", -876.561 + xs, 475.009 + zs);
            grc.AddNodePtxz("osm321406220", -879.455 + xs, 473.947 + zs);
            grc.AddNodePtxz("osm321406221", -852.666 + xs, 399.073 + zs);
            grc.AddNodePtxz("osm321406222", -847.600 + xs, 400.672 + zs);
            grc.AddNodePtxz("osm321406223", -843.756 + xs, 389.552 + zs);
            grc.AddNodePtxz("osm321406224", -892.404 + xs, 373.412 + zs);
            grc.AddNodePtxz("osm4779937957", -891.403 + xs, 370.325 + zs);
            grc.AddNodePtxz("osm321406225", -894.825 + xs, 369.051 + zs);
            grc.AddNodePtxz("osm321406226", -889.432 + xs, 353.620 + zs);
            grc.AddNodePtxz("osm4779937958", -885.848 + xs, 354.871 + zs);
            grc.AddNodePtxz("osm321406227", -884.707 + xs, 351.721 + zs);
            grc.AddNodePtxz("osm321406228", -835.982 + xs, 368.584 + zs);
            grc.AddNodePtxz("osm325609441", -553.036 + xs, 164.097 + zs);
            grc.AddNodePtxz("osm2672290200", -548.177 + xs, 165.681 + zs);
            grc.AddNodePtxz("osm2672290197", -547.538 + xs, 163.928 + zs);
            grc.AddNodePtxz("osm2672290193", -539.131 + xs, 166.798 + zs);
            grc.AddNodePtxz("osm2672290202", -539.768 + xs, 168.711 + zs);
            grc.AddNodePtxz("osm325609443", -534.939 + xs, 170.380 + zs);
            grc.AddNodePtxz("osm325609445", -549.748 + xs, 212.972 + zs);
            grc.AddNodePtxz("osm2671035405", -548.455 + xs, 213.423 + zs);
            grc.AddNodePtxz("osm2671035407", -549.156 + xs, 215.520 + zs);
            grc.AddNodePtxz("osm325609446", -545.585 + xs, 216.774 + zs);
            grc.AddNodePtxz("osm325609447", -547.352 + xs, 221.841 + zs);
            grc.AddNodePtxz("osm2671035411", -545.890 + xs, 222.381 + zs);
            grc.AddNodePtxz("osm2671035409", -545.567 + xs, 221.462 + zs);
            grc.AddNodePtxz("osm2671035420", -544.080 + xs, 221.963 + zs);
            grc.AddNodePtxz("osm2671035418", -533.360 + xs, 225.538 + zs);
            grc.AddNodePtxz("osm2671035414", -532.046 + xs, 225.995 + zs);
            grc.AddNodePtxz("osm2671035416", -532.452 + xs, 227.116 + zs);
            grc.AddNodePtxz("osm325609450", -530.864 + xs, 227.668 + zs);
            grc.AddNodePtxz("osm325609451", -527.553 + xs, 217.933 + zs);
            grc.AddNodePtxz("osm6326434701", -525.863 + xs, 218.496 + zs);
            grc.AddNodePtxz("osm2671035403", -522.764 + xs, 219.549 + zs);
            grc.AddNodePtxz("osm2671035395", -522.080 + xs, 217.668 + zs);
            grc.AddNodePtxz("osm2671035398", -513.617 + xs, 220.644 + zs);
            grc.AddNodePtxz("osm2671035401", -514.239 + xs, 222.349 + zs);
            grc.AddNodePtxz("osm325609452", -509.454 + xs, 224.042 + zs);
            grc.AddNodePtxz("osm325609453", -531.829 + xs, 287.650 + zs);
            grc.AddNodePtxz("osm2671035390", -530.034 + xs, 288.320 + zs);
            grc.AddNodePtxz("osm2671035392", -530.906 + xs, 290.668 + zs);
            grc.AddNodePtxz("osm325609454", -527.296 + xs, 291.911 + zs);
            grc.AddNodePtxz("osm6325521614", -533.175 + xs, 308.324 + zs);
            grc.AddNodePtxz("osm325609456", -542.528 + xs, 334.399 + zs);
            grc.AddNodePtxz("osm2671035386", -547.303 + xs, 332.812 + zs);
            grc.AddNodePtxz("osm2671035380", -547.979 + xs, 334.601 + zs);
            grc.AddNodePtxz("osm2671035383", -556.559 + xs, 331.655 + zs);
            grc.AddNodePtxz("osm2671035493", -555.915 + xs, 329.753 + zs);
            grc.AddNodePtxz("osm2671035491", -560.429 + xs, 328.160 + zs);
            grc.AddNodePtxz("osm2671035485", -545.616 + xs, 285.457 + zs);
            grc.AddNodePtxz("osm2671035487", -547.070 + xs, 284.928 + zs);
            grc.AddNodePtxz("osm2671035489", -546.338 + xs, 282.842 + zs);
            grc.AddNodePtxz("osm2671035455", -549.924 + xs, 281.630 + zs);
            grc.AddNodePtxz("osm2671035468", -548.164 + xs, 276.616 + zs);
            grc.AddNodePtxz("osm4098517730", -556.203 + xs, 273.674 + zs);
            grc.AddNodePtxz("osm2671035466", -564.572 + xs, 270.698 + zs);
            grc.AddNodePtxz("osm2671035459", -567.985 + xs, 280.421 + zs);
            grc.AddNodePtxz("osm2671035374", -572.751 + xs, 278.806 + zs);
            grc.AddNodePtxz("osm2671035463", -573.411 + xs, 280.790 + zs);
            grc.AddNodePtxz("osm2671035461", -581.842 + xs, 277.888 + zs);
            grc.AddNodePtxz("osm2671035377", -581.174 + xs, 276.017 + zs);
            grc.AddNodePtxz("osm2671035457", -586.062 + xs, 274.415 + zs);
            grc.AddNodePtxz("osm2671035477", -584.358 + xs, 269.731 + zs);
            grc.AddNodePtxz("osm2671027641", -577.847 + xs, 251.047 + zs);
            grc.AddNodePtxz("osm4806471178", -563.907 + xs, 211.064 + zs);
            grc.AddNodePtxz("osm4806471179", -569.015 + xs, 209.315 + zs);
            grc.AddNodePtxz("osm325610115", -572.450 + xs, 346.074 + zs);
            grc.AddNodePtxz("osm2671027714", -574.141 + xs, 345.479 + zs);
            grc.AddNodePtxz("osm325610116", -575.893 + xs, 350.369 + zs);
            grc.AddNodePtxz("osm6326434733", -601.384 + xs, 341.658 + zs);
            grc.AddNodePtxz("osm325610118", -618.668 + xs, 335.780 + zs);
            grc.AddNodePtxz("osm2671027716", -617.556 + xs, 332.478 + zs);
            grc.AddNodePtxz("osm2671027717", -620.063 + xs, 331.722 + zs);
            grc.AddNodePtxz("osm325610119", -619.461 + xs, 329.940 + zs);
            grc.AddNodePtxz("osm325610120", -683.279 + xs, 307.982 + zs);
            grc.AddNodePtxz("osm2671027721", -681.671 + xs, 303.201 + zs);
            grc.AddNodePtxz("osm2671027718", -683.264 + xs, 302.664 + zs);
            grc.AddNodePtxz("osm2671027719", -680.427 + xs, 294.446 + zs);
            grc.AddNodePtxz("osm2671027720", -678.674 + xs, 295.030 + zs);
            grc.AddNodePtxz("osm325610121", -677.058 + xs, 290.158 + zs);
            grc.AddNodePtxz("osm325610122", -667.198 + xs, 293.493 + zs);
            grc.AddNodePtxz("osm2671027724", -666.660 + xs, 292.062 + zs);
            grc.AddNodePtxz("osm2671027723", -667.529 + xs, 291.645 + zs);
            grc.AddNodePtxz("osm2671027728", -667.048 + xs, 290.210 + zs);
            grc.AddNodePtxz("osm2671027727", -663.518 + xs, 279.885 + zs);
            grc.AddNodePtxz("osm2671027722", -663.003 + xs, 278.517 + zs);
            grc.AddNodePtxz("osm2671027725", -662.103 + xs, 278.809 + zs);
            grc.AddNodePtxz("osm325610123", -661.530 + xs, 277.143 + zs);
            grc.AddNodePtxz("osm325610124", -666.582 + xs, 275.438 + zs);
            grc.AddNodePtxz("osm325610126", -665.367 + xs, 271.909 + zs);
            grc.AddNodePtxz("osm2671027730", -667.552 + xs, 271.177 + zs);
            grc.AddNodePtxz("osm2671027729", -667.110 + xs, 269.783 + zs);
            grc.AddNodePtxz("osm2672290044", -705.547 + xs, 256.482 + zs);
            grc.AddNodePtxz("osm325610127", -709.916 + xs, 255.081 + zs);
            grc.AddNodePtxz("osm325610128", -708.156 + xs, 250.099 + zs);
            grc.AddNodePtxz("osm325610131", -709.821 + xs, 249.569 + zs);
            grc.AddNodePtxz("osm325610133", -707.005 + xs, 241.376 + zs);
            grc.AddNodePtxz("osm325610135", -705.404 + xs, 241.924 + zs);
            grc.AddNodePtxz("osm325610137", -703.638 + xs, 236.825 + zs);
            grc.AddNodePtxz("osm325610142", -658.242 + xs, 252.485 + zs);
            grc.AddNodePtxz("osm325610144", -659.859 + xs, 257.326 + zs);
            grc.AddNodePtxz("osm2670280676", -619.816 + xs, 271.264 + zs);
            grc.AddNodePtxz("osm2671035483", -600.978 + xs, 277.856 + zs);
            grc.AddNodePtxz("osm2671035470", -596.255 + xs, 279.322 + zs);
            grc.AddNodePtxz("osm2671027704", -597.913 + xs, 284.046 + zs);
            grc.AddNodePtxz("osm2671035473", -596.130 + xs, 284.648 + zs);
            grc.AddNodePtxz("osm2671035471", -599.031 + xs, 292.979 + zs);
            grc.AddNodePtxz("osm2671027703", -600.843 + xs, 292.327 + zs);
            grc.AddNodePtxz("osm325610146", -602.445 + xs, 296.959 + zs);
            grc.AddNodePtxz("osm2671035453", -612.437 + xs, 293.530 + zs);
            grc.AddNodePtxz("osm2671035451", -613.181 + xs, 295.818 + zs);
            grc.AddNodePtxz("osm2671035449", -611.952 + xs, 296.247 + zs);
            grc.AddNodePtxz("osm2671035431", -616.337 + xs, 309.044 + zs);
            grc.AddNodePtxz("osm2671035434", -617.514 + xs, 308.633 + zs);
            grc.AddNodePtxz("osm2671035436", -618.134 + xs, 310.464 + zs);
            grc.AddNodePtxz("osm2671035447", -613.007 + xs, 312.125 + zs);
            grc.AddNodePtxz("osm2671035438", -614.261 + xs, 315.664 + zs);
            grc.AddNodePtxz("osm2671035440", -612.010 + xs, 316.442 + zs);
            grc.AddNodePtxz("osm2671035429", -612.562 + xs, 317.949 + zs);
            grc.AddNodePtxz("osm325610155", -569.474 + xs, 332.486 + zs);
            grc.AddNodePtxz("osm2671027713", -571.267 + xs, 337.528 + zs);
            grc.AddNodePtxz("osm2671027712", -569.626 + xs, 337.994 + zs);
            grc.AddNodePtxz("osm325618934", -787.212 + xs, 440.603 + zs);
            grc.AddNodePtxz("osm4760407215", -783.086 + xs, 428.343 + zs);
            grc.AddNodePtxz("osm4760407216", -784.912 + xs, 427.797 + zs);
            grc.AddNodePtxz("osm4760407203", -781.569 + xs, 418.375 + zs);
            grc.AddNodePtxz("osm4760407202", -779.468 + xs, 419.078 + zs);
            grc.AddNodePtxz("osm325618935", -777.635 + xs, 414.026 + zs);
            grc.AddNodePtxz("osm325618936", -717.657 + xs, 434.519 + zs);
            grc.AddNodePtxz("osm325618937", -712.034 + xs, 418.400 + zs);
            grc.AddNodePtxz("osm4760408331", -706.316 + xs, 420.191 + zs);
            grc.AddNodePtxz("osm4760408330", -705.634 + xs, 418.452 + zs);
            grc.AddNodePtxz("osm4760408328", -696.273 + xs, 421.458 + zs);
            grc.AddNodePtxz("osm4760408327", -697.050 + xs, 423.537 + zs);
            grc.AddNodePtxz("osm325618938", -685.250 + xs, 427.798 + zs);
            grc.AddNodePtxz("osm325618939", -694.606 + xs, 454.285 + zs);
            grc.AddNodePtxz("osm325618940", -653.923 + xs, 468.078 + zs);
            grc.AddNodePtxz("osm325618941", -654.924 + xs, 471.165 + zs);
            grc.AddNodePtxz("osm4773476253", -652.988 + xs, 471.899 + zs);
            grc.AddNodePtxz("osm4760407208", -651.782 + xs, 472.431 + zs);
            grc.AddNodePtxz("osm7346644190", -652.673 + xs, 474.969 + zs);
            grc.AddNodePtxz("osm7346644189", -651.768 + xs, 475.247 + zs);
            grc.AddNodePtxz("osm7346644188", -655.183 + xs, 485.580 + zs);
            grc.AddNodePtxz("osm7346644187", -656.113 + xs, 485.238 + zs);
            grc.AddNodePtxz("osm325618943", -656.983 + xs, 487.919 + zs);
            grc.AddNodePtxz("osm4753326321", -659.603 + xs, 486.982 + zs);
            grc.AddNodePtxz("osm325618944", -660.554 + xs, 486.633 + zs);
            grc.AddNodePtxz("osm325618945", -661.683 + xs, 489.914 + zs);
            grc.AddNodePtxz("osm4760407207", -695.352 + xs, 478.490 + zs);
            grc.AddNodePtxz("osm325618946", -728.956 + xs, 466.574 + zs);
            grc.AddNodePtxz("osm325618948", -727.177 + xs, 461.171 + zs);
            grc.AddNodePtxz("osm4753326324", -731.261 + xs, 459.733 + zs);
            grc.AddNodePtxz("osm325618949", -737.721 + xs, 457.601 + zs);
            grc.AddNodePtxz("osm325618950", -752.064 + xs, 497.724 + zs);
            grc.AddNodePtxz("osm325618951", -755.145 + xs, 496.653 + zs);
            grc.AddNodePtxz("osm4760407211", -755.589 + xs, 497.919 + zs);
            grc.AddNodePtxz("osm4753385704", -756.274 + xs, 500.037 + zs);
            grc.AddNodePtxz("osm4760407214", -758.609 + xs, 499.230 + zs);
            grc.AddNodePtxz("osm325618952", -758.915 + xs, 500.068 + zs);
            grc.AddNodePtxz("osm325618953", -769.891 + xs, 496.382 + zs);
            grc.AddNodePtxz("osm4760407213", -769.573 + xs, 495.445 + zs);
            grc.AddNodePtxz("osm4753385703", -771.952 + xs, 494.591 + zs);
            grc.AddNodePtxz("osm4760407212", -771.199 + xs, 492.313 + zs);
            grc.AddNodePtxz("osm325618955", -770.728 + xs, 490.938 + zs);
            grc.AddNodePtxz("osm325618956", -773.646 + xs, 489.939 + zs);
            grc.AddNodePtxz("osm325618957", -759.541 + xs, 450.194 + zs);
            grc.AddNodePtxz("osm409798994", -706.014 + xs, 15.228 + zs);
            grc.AddNodePtxz("osm409798995", -726.634 + xs, 25.208 + zs);
            grc.AddNodePtxz("osm6331166445", -729.265 + xs, 33.171 + zs);
            grc.AddNodePtxz("osm409798996", -732.012 + xs, 41.166 + zs);
            grc.AddNodePtxz("osm336768305", -777.030 + xs, 25.572 + zs);
            grc.AddNodePtxz("osm336768301", -778.471 + xs, 29.610 + zs);
            grc.AddNodePtxz("osm4983743928", -777.712 + xs, 29.869 + zs);
            grc.AddNodePtxz("osm4983743927", -778.155 + xs, 31.064 + zs);
            grc.AddNodePtxz("osm7350734412", -779.649 + xs, 30.514 + zs);
            grc.AddNodePtxz("osm7350734411", -779.816 + xs, 30.955 + zs);
            grc.AddNodePtxz("osm7484830129", -782.070 + xs, 30.184 + zs);
            grc.AddNodePtxz("osm7484830240", -784.523 + xs, 37.139 + zs);
            grc.AddNodePtxz("osm7484830245", -783.501 + xs, 37.488 + zs);
            grc.AddNodePtxz("osm7350734410", -782.261 + xs, 37.889 + zs);
            grc.AddNodePtxz("osm7350734409", -782.389 + xs, 38.218 + zs);
            grc.AddNodePtxz("osm4983712060", -781.062 + xs, 38.640 + zs);
            grc.AddNodePtxz("osm336768295", -781.471 + xs, 39.839 + zs);
            grc.AddNodePtxz("osm4983712057", -782.003 + xs, 39.673 + zs);
            grc.AddNodePtxz("osm336768292", -783.439 + xs, 43.799 + zs);
            grc.AddNodePtxz("osm4985583153", -779.039 + xs, 45.377 + zs);
            grc.AddNodePtxz("osm6331167729", -775.591 + xs, 46.613 + zs);
            grc.AddNodePtxz("osm336768291", -767.650 + xs, 49.331 + zs);
            grc.AddNodePtxz("osm336768288", -773.046 + xs, 64.301 + zs);
            grc.AddNodePtxz("osm336768285", -780.836 + xs, 61.689 + zs);
            grc.AddNodePtxz("osm4983712059", -782.201 + xs, 65.745 + zs);
            grc.AddNodePtxz("osm336768282", -781.521 + xs, 66.026 + zs);
            grc.AddNodePtxz("osm4983712058", -781.896 + xs, 67.062 + zs);
            grc.AddNodePtxz("osm7350734407", -783.647 + xs, 66.470 + zs);
            grc.AddNodePtxz("osm7350734408", -783.828 + xs, 66.986 + zs);
            grc.AddNodePtxz("osm336768280", -786.220 + xs, 66.104 + zs);
            grc.AddNodePtxz("osm336768278", -788.586 + xs, 72.946 + zs);
            grc.AddNodePtxz("osm7350734406", -786.485 + xs, 73.681 + zs);
            grc.AddNodePtxz("osm7350734405", -786.661 + xs, 74.184 + zs);
            grc.AddNodePtxz("osm4983712056", -784.780 + xs, 74.772 + zs);
            grc.AddNodePtxz("osm336768275", -785.175 + xs, 75.865 + zs);
            grc.AddNodePtxz("osm4983712055", -785.846 + xs, 75.659 + zs);
            grc.AddNodePtxz("osm336768272", -787.252 + xs, 79.732 + zs);
            grc.AddNodePtxz("osm6331167737", -771.324 + xs, 85.272 + zs);
            grc.AddNodePtxz("osm336768330", -729.640 + xs, 99.542 + zs);
            grc.AddNodePtxz("osm7473295910", -728.355 + xs, 95.847 + zs);
            grc.AddNodePtxz("osm4983712053", -728.196 + xs, 95.395 + zs);
            grc.AddNodePtxz("osm4983712054", -728.770 + xs, 95.214 + zs);
            grc.AddNodePtxz("osm336768329", -728.502 + xs, 94.284 + zs);
            grc.AddNodePtxz("osm7350734404", -726.734 + xs, 94.858 + zs);
            grc.AddNodePtxz("osm7350734403", -726.570 + xs, 94.391 + zs);
            grc.AddNodePtxz("osm336768327", -724.201 + xs, 95.170 + zs);
            grc.AddNodePtxz("osm7473295906", -724.077 + xs, 94.817 + zs);
            grc.AddNodePtxz("osm7473295908", -721.980 + xs, 88.809 + zs);
            grc.AddNodePtxz("osm4983712062", -721.841 + xs, 88.413 + zs);
            grc.AddNodePtxz("osm7350734402", -723.885 + xs, 87.682 + zs);
            grc.AddNodePtxz("osm7350734401", -723.723 + xs, 87.222 + zs);
            grc.AddNodePtxz("osm4983712063", -725.696 + xs, 86.523 + zs);
            grc.AddNodePtxz("osm7350734390", -725.320 + xs, 85.385 + zs);
            grc.AddNodePtxz("osm336768325", -724.760 + xs, 85.537 + zs);
            grc.AddNodePtxz("osm6331167700", -724.203 + xs, 83.850 + zs);
            grc.AddNodePtxz("osm336768323", -723.450 + xs, 81.605 + zs);
            grc.AddNodePtxz("osm336768322", -739.130 + xs, 76.063 + zs);
            grc.AddNodePtxz("osm336768320", -733.684 + xs, 60.817 + zs);
            grc.AddNodePtxz("osm336768318", -717.831 + xs, 66.371 + zs);
            grc.AddNodePtxz("osm6331167699", -716.778 + xs, 63.301 + zs);
            grc.AddNodePtxz("osm7350734391", -716.393 + xs, 62.205 + zs);
            grc.AddNodePtxz("osm7350734392", -717.014 + xs, 61.992 + zs);
            grc.AddNodePtxz("osm4983712068", -716.697 + xs, 61.055 + zs);
            grc.AddNodePtxz("osm7350734400", -715.006 + xs, 61.650 + zs);
            grc.AddNodePtxz("osm7350734399", -714.852 + xs, 61.212 + zs);
            grc.AddNodePtxz("osm336768313", -712.535 + xs, 62.037 + zs);
            grc.AddNodePtxz("osm7473295893", -712.379 + xs, 61.591 + zs);
            grc.AddNodePtxz("osm336768312", -709.982 + xs, 54.966 + zs);
            grc.AddNodePtxz("osm7350734398", -712.498 + xs, 54.168 + zs);
            grc.AddNodePtxz("osm7350734397", -712.323 + xs, 53.602 + zs);
            grc.AddNodePtxz("osm336768309", -713.852 + xs, 53.118 + zs);
            grc.AddNodePtxz("osm7350734394", -713.531 + xs, 52.103 + zs);
            grc.AddNodePtxz("osm7350734393", -712.874 + xs, 52.280 + zs);
            grc.AddNodePtxz("osm336768307", -711.474 + xs, 48.157 + zs);
            grc.AddNodePtxz("osm7473295897", -709.192 + xs, 48.883 + zs);
            grc.AddNodePtxz("osm2675737180", -707.623 + xs, 49.388 + zs);
            grc.AddNodePtxz("osm2675737179", -705.043 + xs, 48.220 + zs);
            grc.AddNodePtxz("osm4983712067", -703.849 + xs, 50.499 + zs);
            grc.AddNodePtxz("osm409798997", -700.133 + xs, 48.752 + zs);
            grc.AddNodePtxz("osm2675737181", -701.214 + xs, 46.354 + zs);
            grc.AddNodePtxz("osm2675737182", -698.417 + xs, 44.904 + zs);
            grc.AddNodePtxz("osm336772832", -697.243 + xs, 41.527 + zs);
            grc.AddNodePtxz("osm2675737186", -693.125 + xs, 42.937 + zs);
            grc.AddNodePtxz("osm336772831", -692.850 + xs, 42.152 + zs);
            grc.AddNodePtxz("osm2675737185", -691.891 + xs, 42.512 + zs);
            grc.AddNodePtxz("osm7350734396", -692.578 + xs, 44.471 + zs);
            grc.AddNodePtxz("osm7350734395", -692.052 + xs, 44.651 + zs);
            grc.AddNodePtxz("osm2675737184", -692.768 + xs, 46.727 + zs);
            grc.AddNodePtxz("osm336772828", -685.945 + xs, 49.031 + zs);
            grc.AddNodePtxz("osm4983712052", -685.307 + xs, 47.182 + zs);
            grc.AddNodePtxz("osm2675737188", -684.965 + xs, 47.283 + zs);
            grc.AddNodePtxz("osm2675737187", -684.174 + xs, 45.162 + zs);
            grc.AddNodePtxz("osm2675737189", -683.005 + xs, 45.562 + zs);
            grc.AddNodePtxz("osm2675737190", -683.190 + xs, 46.124 + zs);
            grc.AddNodePtxz("osm7473295876", -682.193 + xs, 46.442 + zs);
            grc.AddNodePtxz("osm336772824", -678.979 + xs, 47.471 + zs);
            grc.AddNodePtxz("osm336772822", -673.525 + xs, 31.967 + zs);
            grc.AddNodePtxz("osm336772821", -658.307 + xs, 37.176 + zs);
            grc.AddNodePtxz("osm336772820", -663.804 + xs, 52.904 + zs);
            grc.AddNodePtxz("osm7473295875", -660.661 + xs, 53.932 + zs);
            grc.AddNodePtxz("osm4983712041", -659.540 + xs, 54.300 + zs);
            grc.AddNodePtxz("osm4983712040", -659.306 + xs, 53.533 + zs);
            grc.AddNodePtxz("osm4983712039", -658.112 + xs, 53.894 + zs);
            grc.AddNodePtxz("osm7350734424", -658.851 + xs, 56.033 + zs);
            grc.AddNodePtxz("osm7350734423", -658.456 + xs, 56.152 + zs);
            grc.AddNodePtxz("osm336772816", -659.194 + xs, 58.355 + zs);
            grc.AddNodePtxz("osm336772815", -652.447 + xs, 60.776 + zs);
            grc.AddNodePtxz("osm7350734422", -651.553 + xs, 58.064 + zs);
            grc.AddNodePtxz("osm7350734421", -651.156 + xs, 58.176 + zs);
            grc.AddNodePtxz("osm4983712042", -650.577 + xs, 56.426 + zs);
            grc.AddNodePtxz("osm336772812", -649.280 + xs, 56.830 + zs);
            grc.AddNodePtxz("osm4983712043", -649.618 + xs, 57.792 + zs);
            grc.AddNodePtxz("osm336772811", -645.747 + xs, 59.133 + zs);
            grc.AddNodePtxz("osm336772809", -625.212 + xs, 2.143 + zs);
            grc.AddNodePtxz("osm4983712044", -629.440 + xs, 0.711 + zs);
            grc.AddNodePtxz("osm4983712045", -629.643 + xs, 1.291 + zs);
            grc.AddNodePtxz("osm7350734420", -630.750 + xs, 0.849 + zs);
            grc.AddNodePtxz("osm7350734419", -630.121 + xs, -1.011 + zs);
            grc.AddNodePtxz("osm336772807", -630.564 + xs, -1.194 + zs);
            grc.AddNodePtxz("osm336772806", -629.818 + xs, -3.252 + zs);
            grc.AddNodePtxz("osm336772805", -636.562 + xs, -5.616 + zs);
            grc.AddNodePtxz("osm7350734418", -637.301 + xs, -3.509 + zs);
            grc.AddNodePtxz("osm7350734417", -637.723 + xs, -3.653 + zs);
            grc.AddNodePtxz("osm336772800", -638.400 + xs, -1.723 + zs);
            grc.AddNodePtxz("osm4983712047", -639.570 + xs, -2.155 + zs);
            grc.AddNodePtxz("osm4983712046", -639.357 + xs, -2.763 + zs);
            grc.AddNodePtxz("osm7473375080", -639.588 + xs, -2.842 + zs);
            grc.AddNodePtxz("osm336772798", -643.564 + xs, -4.187 + zs);
            grc.AddNodePtxz("osm336772796", -646.275 + xs, 3.638 + zs);
            grc.AddNodePtxz("osm336772795", -661.538 + xs, -1.746 + zs);
            grc.AddNodePtxz("osm336772793", -655.917 + xs, -17.558 + zs);
            grc.AddNodePtxz("osm4983712049", -660.116 + xs, -18.971 + zs);
            grc.AddNodePtxz("osm336772791", -660.328 + xs, -18.300 + zs);
            grc.AddNodePtxz("osm4983712037", -661.450 + xs, -18.699 + zs);
            grc.AddNodePtxz("osm7350734416", -660.756 + xs, -20.711 + zs);
            grc.AddNodePtxz("osm7350734415", -661.248 + xs, -20.888 + zs);
            grc.AddNodePtxz("osm7484830204", -660.781 + xs, -22.185 + zs);
            grc.AddNodePtxz("osm336772790", -660.582 + xs, -22.719 + zs);
            grc.AddNodePtxz("osm336772789", -667.331 + xs, -24.967 + zs);
            grc.AddNodePtxz("osm7350734414", -667.918 + xs, -23.227 + zs);
            grc.AddNodePtxz("osm7350734413", -668.437 + xs, -23.396 + zs);
            grc.AddNodePtxz("osm336772788", -669.308 + xs, -20.780 + zs);
            grc.AddNodePtxz("osm4983712051", -670.796 + xs, -21.313 + zs);
            grc.AddNodePtxz("osm4983712050", -670.436 + xs, -22.306 + zs);
            grc.AddNodePtxz("osm336772786", -674.172 + xs, -23.593 + zs);
            grc.AddNodePtxz("osm6331166457", -687.942 + xs, 14.729 + zs);
            grc.AddNodePtxz("osm409798978", -690.076 + xs, 20.874 + zs);
            grc.AddNodePtxz("osm7484830133", -695.396 + xs, 18.990 + zs);
            grc.AddNodePtxz("osm345261389", -568.458 + xs, 31.521 + zs);
            grc.AddNodePtxz("osm345261390", -549.736 + xs, 37.875 + zs);
            grc.AddNodePtxz("osm345261392", -549.296 + xs, 36.655 + zs);
            grc.AddNodePtxz("osm7473295809", -540.400 + xs, 39.709 + zs);
            grc.AddNodePtxz("osm345261393", -539.747 + xs, 39.933 + zs);
            grc.AddNodePtxz("osm345261394", -540.637 + xs, 42.400 + zs);
            grc.AddNodePtxz("osm345261395", -527.441 + xs, 46.783 + zs);
            grc.AddNodePtxz("osm345261396", -540.255 + xs, 83.659 + zs);
            grc.AddNodePtxz("osm345261397", -554.037 + xs, 79.099 + zs);
            grc.AddNodePtxz("osm345261398", -554.726 + xs, 81.128 + zs);
            grc.AddNodePtxz("osm7472994604", -557.727 + xs, 80.133 + zs);
            grc.AddNodePtxz("osm7350890253", -559.312 + xs, 79.606 + zs);
            grc.AddNodePtxz("osm7350890252", -559.851 + xs, 81.109 + zs);
            grc.AddNodePtxz("osm7350890251", -565.681 + xs, 79.097 + zs);
            grc.AddNodePtxz("osm7350890245", -565.166 + xs, 77.563 + zs);
            grc.AddNodePtxz("osm7350890250", -566.976 + xs, 76.974 + zs);
            grc.AddNodePtxz("osm345261400", -570.014 + xs, 75.982 + zs);
            grc.AddNodePtxz("osm345261401", -568.804 + xs, 72.467 + zs);
            grc.AddNodePtxz("osm345261402", -579.877 + xs, 68.724 + zs);
            grc.AddNodePtxz("osm7350890244", -576.880 + xs, 59.785 + zs);
            grc.AddNodePtxz("osm7350890243", -578.305 + xs, 59.273 + zs);
            grc.AddNodePtxz("osm7350890242", -577.273 + xs, 56.331 + zs);
            grc.AddNodePtxz("osm7350890241", -575.803 + xs, 56.850 + zs);
            grc.AddNodePtxz("osm345261403", -571.980 + xs, 45.857 + zs);
            grc.AddNodePtxz("osm345261404", -573.441 + xs, 45.349 + zs);
            grc.AddNodePtxz("osm7486062633", -571.943 + xs, 41.181 + zs);
            grc.AddNodePtxz("osm7486062637", -571.060 + xs, 38.734 + zs);
            grc.AddNodePtxz("osm345266071", -615.279 + xs, 425.604 + zs);
            grc.AddNodePtxz("osm345266072", -588.033 + xs, 434.963 + zs);
            grc.AddNodePtxz("osm345266073", -589.431 + xs, 438.913 + zs);
            grc.AddNodePtxz("osm7346301662", -569.909 + xs, 445.707 + zs);
            grc.AddNodePtxz("osm7346301661", -570.216 + xs, 446.616 + zs);
            grc.AddNodePtxz("osm345266076", -559.274 + xs, 450.330 + zs);
            grc.AddNodePtxz("osm345266077", -564.782 + xs, 466.893 + zs);
            grc.AddNodePtxz("osm345266080", -560.147 + xs, 468.512 + zs);
            grc.AddNodePtxz("osm4740268535", -562.499 + xs, 475.145 + zs);
            grc.AddNodePtxz("osm4740268533", -566.204 + xs, 473.837 + zs);
            grc.AddNodePtxz("osm345266082", -589.504 + xs, 539.845 + zs);
            grc.AddNodePtxz("osm7132384720", -594.328 + xs, 538.194 + zs);
            grc.AddNodePtxz("osm7346301671", -599.259 + xs, 551.604 + zs);
            grc.AddNodePtxz("osm4758634644", -602.125 + xs, 557.918 + zs);
            grc.AddNodePtxz("osm345266086", -607.346 + xs, 568.995 + zs);
            grc.AddNodePtxz("osm4753578018", -610.997 + xs, 567.634 + zs);
            grc.AddNodePtxz("osm7345287876", -615.028 + xs, 566.246 + zs);
            grc.AddNodePtxz("osm7345287877", -616.584 + xs, 570.847 + zs);
            grc.AddNodePtxz("osm7345287878", -628.605 + xs, 566.644 + zs);
            grc.AddNodePtxz("osm7345287879", -626.993 + xs, 562.087 + zs);
            grc.AddNodePtxz("osm345266093", -646.787 + xs, 555.461 + zs);
            grc.AddNodePtxz("osm345266097", -647.894 + xs, 558.750 + zs);
            grc.AddNodePtxz("osm345266099", -660.677 + xs, 554.366 + zs);
            grc.AddNodePtxz("osm4758634648", -654.374 + xs, 536.276 + zs);
            grc.AddNodePtxz("osm7346301669", -652.354 + xs, 530.655 + zs);
            grc.AddNodePtxz("osm7346301670", -654.808 + xs, 529.783 + zs);
            grc.AddNodePtxz("osm7346301668", -653.561 + xs, 526.297 + zs);
            grc.AddNodePtxz("osm7346301667", -651.098 + xs, 527.179 + zs);
            grc.AddNodePtxz("osm4781654488", -650.619 + xs, 525.846 + zs);
            grc.AddNodePtxz("osm7346301666", -641.104 + xs, 498.337 + zs);
            grc.AddNodePtxz("osm7346301665", -640.412 + xs, 498.582 + zs);
            grc.AddNodePtxz("osm7070870706", -639.560 + xs, 496.157 + zs);
            grc.AddNodePtxz("osm7346301664", -638.550 + xs, 493.247 + zs);
            grc.AddNodePtxz("osm7346301663", -639.155 + xs, 493.087 + zs);
            grc.AddNodePtxz("osm7070870702", -636.572 + xs, 486.066 + zs);
            grc.AddNodePtxz("osm409799024", -796.703 + xs, 103.564 + zs);
            grc.AddNodePtxz("osm6331167730", -808.341 + xs, 135.543 + zs);
            grc.AddNodePtxz("osm6331167764", -820.210 + xs, 170.230 + zs);
            grc.AddNodePtxz("osm6331167765", -815.368 + xs, 172.197 + zs);
            grc.AddNodePtxz("osm409799025", -817.280 + xs, 177.175 + zs);
            grc.AddNodePtxz("osm6331167761", -788.961 + xs, 187.139 + zs);
            grc.AddNodePtxz("osm6331167768", -779.292 + xs, 190.615 + zs);
            grc.AddNodePtxz("osm6331167762", -766.458 + xs, 195.223 + zs);
            grc.AddNodePtxz("osm6331167763", -764.798 + xs, 191.030 + zs);
            grc.AddNodePtxz("osm409799026", -756.967 + xs, 193.624 + zs);
            grc.AddNodePtxz("osm409799027", -732.795 + xs, 123.248 + zs);
            grc.AddNodePtxz("osm6331167751", -737.203 + xs, 121.390 + zs);
            grc.AddNodePtxz("osm6331167742", -738.766 + xs, 120.800 + zs);
            grc.AddNodePtxz("osm6331167766", -751.885 + xs, 116.198 + zs);
            grc.AddNodePtxz("osm4983743924", -750.753 + xs, 113.108 + zs);
            grc.AddNodePtxz("osm4983743925", -788.068 + xs, 100.238 + zs);
            grc.AddNodePtxz("osm4983743926", -790.235 + xs, 105.873 + zs);
            grc.AddNodePtxz("osm2671035478", -587.722 + xs, 268.524 + zs);
            grc.AddNodePtxz("osm2671035479", -591.835 + xs, 270.696 + zs);
            grc.AddNodePtxz("osm2671035476", -590.120 + xs, 274.111 + zs);
            grc.AddNodePtxz("osm2671035475", -593.864 + xs, 275.871 + zs);
            grc.AddNodePtxz("osm2671035480", -595.501 + xs, 272.435 + zs);
            grc.AddNodePtxz("osm2671035482", -599.835 + xs, 274.635 + zs);
            grc.AddNodePtxz("osm2671027633", -618.293 + xs, 268.134 + zs);
            grc.AddNodePtxz("osm2671027631", -616.512 + xs, 264.910 + zs);
            grc.AddNodePtxz("osm2671027632", -614.722 + xs, 262.195 + zs);
            grc.AddNodePtxz("osm2671027630", -612.647 + xs, 259.848 + zs);
            grc.AddNodePtxz("osm2671027635", -610.422 + xs, 257.608 + zs);
            grc.AddNodePtxz("osm2671027634", -607.914 + xs, 255.741 + zs);
            grc.AddNodePtxz("osm2671027636", -605.434 + xs, 254.087 + zs);
            grc.AddNodePtxz("osm2671027628", -602.280 + xs, 252.394 + zs);
            grc.AddNodePtxz("osm2671027638", -599.112 + xs, 251.166 + zs);
            grc.AddNodePtxz("osm2671027637", -596.259 + xs, 250.297 + zs);
            grc.AddNodePtxz("osm2671027640", -593.010 + xs, 249.880 + zs);
            grc.AddNodePtxz("osm2671027629", -590.033 + xs, 249.466 + zs);
            grc.AddNodePtxz("osm2671027639", -584.189 + xs, 249.621 + zs);
            grc.AddNodePtxz("osm3516771343", -832.502 + xs, 217.044 + zs);
            grc.AddNodePtxz("osm6333379830", -834.661 + xs, 222.824 + zs);
            grc.AddNodePtxz("osm3516771344", -836.249 + xs, 227.081 + zs);
            grc.AddNodePtxz("osm3516771341", -830.544 + xs, 238.991 + zs);
            grc.AddNodePtxz("osm7484825441", -841.853 + xs, 244.324 + zs);
            grc.AddNodePtxz("osm3516771345", -842.618 + xs, 244.688 + zs);
            grc.AddNodePtxz("osm3516771346", -846.093 + xs, 254.485 + zs);
            grc.AddNodePtxz("osm7484825440", -837.580 + xs, 257.423 + zs);
            grc.AddNodePtxz("osm4802527987", -836.930 + xs, 257.654 + zs);
            grc.AddNodePtxz("osm3516771340", -840.137 + xs, 266.893 + zs);
            grc.AddNodePtxz("osm3516771335", -830.564 + xs, 270.337 + zs);
            grc.AddNodePtxz("osm3516771328", -817.775 + xs, 264.219 + zs);
            grc.AddNodePtxz("osm7484825472", -816.996 + xs, 261.998 + zs);
            grc.AddNodePtxz("osm3516771327", -814.571 + xs, 255.090 + zs);
            grc.AddNodePtxz("osm3516771315", -801.757 + xs, 249.068 + zs);
            grc.AddNodePtxz("osm7484825468", -794.317 + xs, 251.702 + zs);
            grc.AddNodePtxz("osm3516771306", -793.164 + xs, 252.112 + zs);
            grc.AddNodePtxz("osm7484830121", -790.794 + xs, 251.007 + zs);
            grc.AddNodePtxz("osm7484830115", -781.143 + xs, 246.500 + zs);
            grc.AddNodePtxz("osm3516771296", -780.256 + xs, 246.091 + zs);
            grc.AddNodePtxz("osm7484830103", -779.402 + xs, 243.658 + zs);
            grc.AddNodePtxz("osm3516771294", -776.842 + xs, 236.400 + zs);
            grc.AddNodePtxz("osm7484830102", -778.369 + xs, 235.877 + zs);
            grc.AddNodePtxz("osm4802528011", -786.205 + xs, 233.194 + zs);
            grc.AddNodePtxz("osm3516771307", -782.790 + xs, 224.137 + zs);
            grc.AddNodePtxz("osm3516771317", -792.354 + xs, 220.768 + zs);
            grc.AddNodePtxz("osm7484830093", -798.964 + xs, 223.804 + zs);
            grc.AddNodePtxz("osm3516771324", -804.714 + xs, 226.438 + zs);
            grc.AddNodePtxz("osm7484830094", -807.674 + xs, 220.553 + zs);
            grc.AddNodePtxz("osm3516771334", -810.715 + xs, 214.529 + zs);
            grc.AddNodePtxz("osm3516771339", -820.095 + xs, 211.207 + zs);

            grc.AddLinkByNodeName("osm321406064", "osm321406063", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link1");
            grc.AddLinkByNodeName("osm7473295815", "osm321406064", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link2");
            grc.AddLinkByNodeName("osm7123470523", "osm7473295815", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link3");
            grc.AddLinkByNodeName("osm7473295819", "osm7123470523", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link4");
            grc.AddLinkByNodeName("osm321406065", "osm7473295819", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link5");
            grc.AddLinkByNodeName("osm321406066", "osm321406065", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link6");
            grc.AddLinkByNodeName("osm6323327743", "osm321406066", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link7");
            grc.AddLinkByNodeName("osm7123470544", "osm6323327743", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link8");
            grc.AddLinkByNodeName("osm6323327701", "osm7123470544", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link9");
            grc.AddLinkByNodeName("osm321406067", "osm6323327701", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link10");
            grc.AddLinkByNodeName("osm321406068", "osm321406067", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link11");
            grc.AddLinkByNodeName("osm7472985454", "osm321406068", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link12");
            grc.AddLinkByNodeName("osm321406069", "osm7472985454", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link13");
            grc.AddLinkByNodeName("osm321406070", "osm321406069", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link14");
            grc.AddLinkByNodeName("osm6323327724", "osm321406070", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link15");
            grc.AddLinkByNodeName("osm7065046248", "osm6323327724", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link16");
            grc.AddLinkByNodeName("osm7473295813", "osm7065046248", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link17");
            grc.AddLinkByNodeName("osm321406063", "osm7473295813", usetype: LinkUse.bldwall, comment: "Microsoft Building 19.link18");

            grc.AddLinkByNodeName("osm2660169201", "osm321406158", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link1");
            grc.AddLinkByNodeName("osm2660169203", "osm2660169201", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link2");
            grc.AddLinkByNodeName("osm2660169196", "osm2660169203", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link3");
            grc.AddLinkByNodeName("osm4806537129", "osm2660169196", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link4");
            grc.AddLinkByNodeName("osm2660169206", "osm4806537129", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link5");
            grc.AddLinkByNodeName("osm321406159", "osm2660169206", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link6");
            grc.AddLinkByNodeName("osm321406160", "osm321406159", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link7");
            grc.AddLinkByNodeName("osm321406161", "osm321406160", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link8");
            grc.AddLinkByNodeName("osm2660169277", "osm321406161", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link9");
            grc.AddLinkByNodeName("osm2660169274", "osm2660169277", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link10");
            grc.AddLinkByNodeName("osm2660169269", "osm2660169274", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link11");
            grc.AddLinkByNodeName("osm2660169271", "osm2660169269", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link12");
            grc.AddLinkByNodeName("osm321406162", "osm2660169271", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link13");
            grc.AddLinkByNodeName("osm321406163", "osm321406162", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link14");
            grc.AddLinkByNodeName("osm7469570210", "osm321406163", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link15");
            grc.AddLinkByNodeName("osm321406164", "osm7469570210", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link16");
            grc.AddLinkByNodeName("osm4777391860", "osm321406164", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link17");
            grc.AddLinkByNodeName("osm7469570217", "osm4777391860", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link18");
            grc.AddLinkByNodeName("osm321406165", "osm7469570217", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link19");
            grc.AddLinkByNodeName("osm2660169266", "osm321406165", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link20");
            grc.AddLinkByNodeName("osm2660169264", "osm2660169266", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link21");
            grc.AddLinkByNodeName("osm2671027618", "osm2660169264", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link22");
            grc.AddLinkByNodeName("osm2660169258", "osm2671027618", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link23");
            grc.AddLinkByNodeName("osm2660169261", "osm2660169258", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link24");
            grc.AddLinkByNodeName("osm321406166", "osm2660169261", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link25");
            grc.AddLinkByNodeName("osm7350890235", "osm321406166", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link26");
            grc.AddLinkByNodeName("osm321406167", "osm7350890235", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link27");
            grc.AddLinkByNodeName("osm321406168", "osm321406167", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link28");
            grc.AddLinkByNodeName("osm2670280688", "osm321406168", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link29");
            grc.AddLinkByNodeName("osm321406169", "osm2670280688", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link30");
            grc.AddLinkByNodeName("osm321406170", "osm321406169", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link31");
            grc.AddLinkByNodeName("osm321406171", "osm321406170", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link32");
            grc.AddLinkByNodeName("osm2660169253", "osm321406171", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link33");
            grc.AddLinkByNodeName("osm2660169251", "osm2660169253", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link34");
            grc.AddLinkByNodeName("osm2671027615", "osm2660169251", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link35");
            grc.AddLinkByNodeName("osm2660169248", "osm2671027615", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link36");
            grc.AddLinkByNodeName("osm2660169256", "osm2660169248", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link37");
            grc.AddLinkByNodeName("osm321406172", "osm2660169256", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link38");
            grc.AddLinkByNodeName("osm7469570234", "osm321406172", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link39");
            grc.AddLinkByNodeName("osm7123400113", "osm7469570234", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link40");
            grc.AddLinkByNodeName("osm321406173", "osm7123400113", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link41");
            grc.AddLinkByNodeName("osm7469570224", "osm321406173", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link42");
            grc.AddLinkByNodeName("osm321406174", "osm7469570224", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link43");
            grc.AddLinkByNodeName("osm321406175", "osm321406174", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link44");
            grc.AddLinkByNodeName("osm2660169232", "osm321406175", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link45");
            grc.AddLinkByNodeName("osm2660169230", "osm2660169232", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link46");
            grc.AddLinkByNodeName("osm2660169227", "osm2660169230", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link47");
            grc.AddLinkByNodeName("osm2660169235", "osm2660169227", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link48");
            grc.AddLinkByNodeName("osm321406176", "osm2660169235", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link49");
            grc.AddLinkByNodeName("osm321406177", "osm321406176", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link50");
            grc.AddLinkByNodeName("osm7469570230", "osm321406177", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link51");
            grc.AddLinkByNodeName("osm4781518455", "osm7469570230", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link52");
            grc.AddLinkByNodeName("osm321406178", "osm4781518455", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link53");
            grc.AddLinkByNodeName("osm2660169219", "osm321406178", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link54");
            grc.AddLinkByNodeName("osm2660169216", "osm2660169219", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link55");
            grc.AddLinkByNodeName("osm2660169212", "osm2660169216", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link56");
            grc.AddLinkByNodeName("osm2660169222", "osm2660169212", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link57");
            grc.AddLinkByNodeName("osm321406179", "osm2660169222", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link58");
            grc.AddLinkByNodeName("osm7469570328", "osm321406179", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link59");
            grc.AddLinkByNodeName("osm4806537131", "osm7469570328", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link60");
            grc.AddLinkByNodeName("osm7469570335", "osm4806537131", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link61");
            grc.AddLinkByNodeName("osm321406180", "osm7469570335", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link62");
            grc.AddLinkByNodeName("osm7469570331", "osm321406180", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link63");
            grc.AddLinkByNodeName("osm2675681594", "osm7469570331", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link64");
            grc.AddLinkByNodeName("osm2675681602", "osm2675681594", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link65");
            grc.AddLinkByNodeName("osm2660169245", "osm2675681602", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link66");
            grc.AddLinkByNodeName("osm2660169237", "osm2660169245", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link67");
            grc.AddLinkByNodeName("osm2660169240", "osm2660169237", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link68");
            grc.AddLinkByNodeName("osm2660169243", "osm2660169240", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link69");
            grc.AddLinkByNodeName("osm321406182", "osm2660169243", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link70");
            grc.AddLinkByNodeName("osm7469570252", "osm321406182", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link71");
            grc.AddLinkByNodeName("osm321406183", "osm7469570252", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link72");
            grc.AddLinkByNodeName("osm321406184", "osm321406183", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link73");
            grc.AddLinkByNodeName("osm2660169209", "osm321406184", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link74");
            grc.AddLinkByNodeName("osm2675681636", "osm2660169209", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link75");
            grc.AddLinkByNodeName("osm2675681645", "osm2675681636", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link76");
            grc.AddLinkByNodeName("osm2675681646", "osm2675681645", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link77");
            grc.AddLinkByNodeName("osm321406187", "osm2675681646", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link78");
            grc.AddLinkByNodeName("osm321406188", "osm321406187", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link79");
            grc.AddLinkByNodeName("osm321406189", "osm321406188", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link80");
            grc.AddLinkByNodeName("osm7469570271", "osm321406189", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link81");
            grc.AddLinkByNodeName("osm7469570264", "osm7469570271", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link82");
            grc.AddLinkByNodeName("osm321406190", "osm7469570264", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link83");
            grc.AddLinkByNodeName("osm7469570262", "osm321406190", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link84");
            grc.AddLinkByNodeName("osm2660169284", "osm7469570262", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link85");
            grc.AddLinkByNodeName("osm2660169282", "osm2660169284", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link86");
            grc.AddLinkByNodeName("osm2660169279", "osm2660169282", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link87");
            grc.AddLinkByNodeName("osm2660169287", "osm2660169279", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link88");
            grc.AddLinkByNodeName("osm2675681628", "osm2660169287", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link89");
            grc.AddLinkByNodeName("osm2675681627", "osm2675681628", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link90");
            grc.AddLinkByNodeName("osm7469570245", "osm2675681627", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link91");
            grc.AddLinkByNodeName("osm321406192", "osm7469570245", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link92");
            grc.AddLinkByNodeName("osm7469570241", "osm321406192", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link93");
            grc.AddLinkByNodeName("osm7132371575", "osm7469570241", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link94");
            grc.AddLinkByNodeName("osm7469570189", "osm7132371575", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link95");
            grc.AddLinkByNodeName("osm321406158", "osm7469570189", usetype: LinkUse.bldwall, comment: "Microsoft Building 18.link96");

            grc.AddLinkByNodeName("osm4779937963", "osm321406211", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link1");
            grc.AddLinkByNodeName("osm4779937962", "osm4779937963", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link2");
            grc.AddLinkByNodeName("osm7132304293", "osm4779937962", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link3");
            grc.AddLinkByNodeName("osm4779937961", "osm7132304293", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link4");
            grc.AddLinkByNodeName("osm321406212", "osm4779937961", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link5");
            grc.AddLinkByNodeName("osm4779937960", "osm321406212", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link6");
            grc.AddLinkByNodeName("osm3834803720", "osm4779937960", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link7");
            grc.AddLinkByNodeName("osm321406213", "osm3834803720", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link8");
            grc.AddLinkByNodeName("osm321406214", "osm321406213", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link9");
            grc.AddLinkByNodeName("osm7120384994", "osm321406214", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link10");
            grc.AddLinkByNodeName("osm4779937954", "osm7120384994", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link11");
            grc.AddLinkByNodeName("osm4779937953", "osm4779937954", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link12");
            grc.AddLinkByNodeName("osm4779937952", "osm4779937953", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link13");
            grc.AddLinkByNodeName("osm4779937951", "osm4779937952", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link14");
            grc.AddLinkByNodeName("osm321406215", "osm4779937951", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link15");
            grc.AddLinkByNodeName("osm321406216", "osm321406215", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link16");
            grc.AddLinkByNodeName("osm4781664647", "osm321406216", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link17");
            grc.AddLinkByNodeName("osm321406217", "osm4781664647", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link18");
            grc.AddLinkByNodeName("osm4781664644", "osm321406217", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link19");
            grc.AddLinkByNodeName("osm4781664648", "osm4781664644", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link20");
            grc.AddLinkByNodeName("osm321406218", "osm4781664648", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link21");
            grc.AddLinkByNodeName("osm4781664649", "osm321406218", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link22");
            grc.AddLinkByNodeName("osm321406219", "osm4781664649", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link23");
            grc.AddLinkByNodeName("osm7346635974", "osm321406219", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link24");
            grc.AddLinkByNodeName("osm4781664650", "osm7346635974", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link25");
            grc.AddLinkByNodeName("osm7346635975", "osm4781664650", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link26");
            grc.AddLinkByNodeName("osm4781664643", "osm7346635975", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link27");
            grc.AddLinkByNodeName("osm4781664651", "osm4781664643", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link28");
            grc.AddLinkByNodeName("osm321406220", "osm4781664651", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link29");
            grc.AddLinkByNodeName("osm321406221", "osm321406220", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link30");
            grc.AddLinkByNodeName("osm321406222", "osm321406221", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link31");
            grc.AddLinkByNodeName("osm4779937955", "osm321406222", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link32");
            grc.AddLinkByNodeName("osm321406223", "osm4779937955", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link33");
            grc.AddLinkByNodeName("osm321406224", "osm321406223", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link34");
            grc.AddLinkByNodeName("osm4779937957", "osm321406224", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link35");
            grc.AddLinkByNodeName("osm4779937956", "osm4779937957", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link36");
            grc.AddLinkByNodeName("osm321406225", "osm4779937956", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link37");
            grc.AddLinkByNodeName("osm321406226", "osm321406225", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link38");
            grc.AddLinkByNodeName("osm4779937958", "osm321406226", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link39");
            grc.AddLinkByNodeName("osm321406227", "osm4779937958", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link40");
            grc.AddLinkByNodeName("osm7132304286", "osm321406227", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link41");
            grc.AddLinkByNodeName("osm321406228", "osm7132304286", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link42");
            grc.AddLinkByNodeName("osm321406211", "osm321406228", usetype: LinkUse.bldwall, comment: "Microsoft Building 35.link43");

            grc.AddLinkByNodeName("osm2672290200", "osm325609441", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link1");
            grc.AddLinkByNodeName("osm4806471180", "osm2672290200", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link2");
            grc.AddLinkByNodeName("osm2672290197", "osm4806471180", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link3");
            grc.AddLinkByNodeName("osm2672290193", "osm2672290197", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link4");
            grc.AddLinkByNodeName("osm2672290202", "osm2672290193", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link5");
            grc.AddLinkByNodeName("osm325609443", "osm2672290202", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link6");
            grc.AddLinkByNodeName("osm325609445", "osm325609443", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link7");
            grc.AddLinkByNodeName("osm2671035405", "osm325609445", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link8");
            grc.AddLinkByNodeName("osm2671035407", "osm2671035405", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link9");
            grc.AddLinkByNodeName("osm325609446", "osm2671035407", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link10");
            grc.AddLinkByNodeName("osm325609447", "osm325609446", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link11");
            grc.AddLinkByNodeName("osm2671035411", "osm325609447", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link12");
            grc.AddLinkByNodeName("osm2671035409", "osm2671035411", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link13");
            grc.AddLinkByNodeName("osm2671035420", "osm2671035409", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link14");
            grc.AddLinkByNodeName("osm2671035422", "osm2671035420", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link15");
            grc.AddLinkByNodeName("osm2671035418", "osm2671035422", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link16");
            grc.AddLinkByNodeName("osm2671035414", "osm2671035418", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link17");
            grc.AddLinkByNodeName("osm2671035416", "osm2671035414", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link18");
            grc.AddLinkByNodeName("osm325609450", "osm2671035416", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link19");
            grc.AddLinkByNodeName("osm325609451", "osm325609450", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link20");
            grc.AddLinkByNodeName("osm6326434701", "osm325609451", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link21");
            grc.AddLinkByNodeName("osm2671035403", "osm6326434701", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link22");
            grc.AddLinkByNodeName("osm2671035395", "osm2671035403", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link23");
            grc.AddLinkByNodeName("osm2671035398", "osm2671035395", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link24");
            grc.AddLinkByNodeName("osm2671035401", "osm2671035398", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link25");
            grc.AddLinkByNodeName("osm325609452", "osm2671035401", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link26");
            grc.AddLinkByNodeName("osm325609453", "osm325609452", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link27");
            grc.AddLinkByNodeName("osm2671035390", "osm325609453", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link28");
            grc.AddLinkByNodeName("osm2671035392", "osm2671035390", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link29");
            grc.AddLinkByNodeName("osm325609454", "osm2671035392", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link30");
            grc.AddLinkByNodeName("osm6325521614", "osm325609454", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link31");
            grc.AddLinkByNodeName("osm325609456", "osm6325521614", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link32");
            grc.AddLinkByNodeName("osm2671035386", "osm325609456", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link33");
            grc.AddLinkByNodeName("osm2671035380", "osm2671035386", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link34");
            grc.AddLinkByNodeName("osm2671035383", "osm2671035380", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link35");
            grc.AddLinkByNodeName("osm4806471176", "osm2671035383", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link36");
            grc.AddLinkByNodeName("osm2671035493", "osm4806471176", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link37");
            grc.AddLinkByNodeName("osm2671035491", "osm2671035493", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link38");
            grc.AddLinkByNodeName("osm4098517727", "osm2671035491", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link39");
            grc.AddLinkByNodeName("osm2671035485", "osm4098517727", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link40");
            grc.AddLinkByNodeName("osm2671035487", "osm2671035485", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link41");
            grc.AddLinkByNodeName("osm2671035489", "osm2671035487", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link42");
            grc.AddLinkByNodeName("osm2671035455", "osm2671035489", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link43");
            grc.AddLinkByNodeName("osm2671035468", "osm2671035455", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link44");
            grc.AddLinkByNodeName("osm4806471174", "osm2671035468", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link45");
            grc.AddLinkByNodeName("osm4098517730", "osm4806471174", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link46");
            grc.AddLinkByNodeName("osm4806471175", "osm4098517730", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link47");
            grc.AddLinkByNodeName("osm2671035466", "osm4806471175", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link48");
            grc.AddLinkByNodeName("osm2671035459", "osm2671035466", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link49");
            grc.AddLinkByNodeName("osm2671035374", "osm2671035459", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link50");
            grc.AddLinkByNodeName("osm2671035463", "osm2671035374", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link51");
            grc.AddLinkByNodeName("osm4098517739", "osm2671035463", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link52");
            grc.AddLinkByNodeName("osm2671035461", "osm4098517739", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link53");
            grc.AddLinkByNodeName("osm2671035377", "osm2671035461", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link54");
            grc.AddLinkByNodeName("osm2671035457", "osm2671035377", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link55");
            grc.AddLinkByNodeName("osm2671035477", "osm2671035457", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link56");
            grc.AddLinkByNodeName("osm2671027641", "osm2671035477", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link57");
            grc.AddLinkByNodeName("osm4806471178", "osm2671027641", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link58");
            grc.AddLinkByNodeName("osm4806471179", "osm4806471178", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link59");
            grc.AddLinkByNodeName("osm2671027619", "osm4806471179", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link60");
            grc.AddLinkByNodeName("osm4060068699", "osm2671027619", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link61");
            grc.AddLinkByNodeName("osm325609441", "osm4060068699", usetype: LinkUse.bldwall, comment: "Microsoft Building 16.link62");

            grc.AddLinkByNodeName("osm2671027714", "osm325610115", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link1");
            grc.AddLinkByNodeName("osm325610116", "osm2671027714", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link2");
            grc.AddLinkByNodeName("osm6326434733", "osm325610116", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link3");
            grc.AddLinkByNodeName("osm325610118", "osm6326434733", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link4");
            grc.AddLinkByNodeName("osm2671027716", "osm325610118", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link5");
            grc.AddLinkByNodeName("osm2671027717", "osm2671027716", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link6");
            grc.AddLinkByNodeName("osm325610119", "osm2671027717", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link7");
            grc.AddLinkByNodeName("osm325610120", "osm325610119", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link8");
            grc.AddLinkByNodeName("osm2671027721", "osm325610120", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link9");
            grc.AddLinkByNodeName("osm2671027718", "osm2671027721", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link10");
            grc.AddLinkByNodeName("osm2671027719", "osm2671027718", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link11");
            grc.AddLinkByNodeName("osm2671027720", "osm2671027719", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link12");
            grc.AddLinkByNodeName("osm325610121", "osm2671027720", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link13");
            grc.AddLinkByNodeName("osm325610122", "osm325610121", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link14");
            grc.AddLinkByNodeName("osm2671027724", "osm325610122", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link15");
            grc.AddLinkByNodeName("osm2671027723", "osm2671027724", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link16");
            grc.AddLinkByNodeName("osm2671027728", "osm2671027723", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link17");
            grc.AddLinkByNodeName("osm4775434185", "osm2671027728", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link18");
            grc.AddLinkByNodeName("osm2671027727", "osm4775434185", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link19");
            grc.AddLinkByNodeName("osm2671027722", "osm2671027727", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link20");
            grc.AddLinkByNodeName("osm2671027725", "osm2671027722", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link21");
            grc.AddLinkByNodeName("osm325610123", "osm2671027725", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link22");
            grc.AddLinkByNodeName("osm325610124", "osm325610123", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link23");
            grc.AddLinkByNodeName("osm325610126", "osm325610124", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link24");
            grc.AddLinkByNodeName("osm2671027730", "osm325610126", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link25");
            grc.AddLinkByNodeName("osm2671027729", "osm2671027730", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link26");
            grc.AddLinkByNodeName("osm2672290044", "osm2671027729", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link27");
            grc.AddLinkByNodeName("osm325610127", "osm2672290044", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link28");
            grc.AddLinkByNodeName("osm325610128", "osm325610127", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link29");
            grc.AddLinkByNodeName("osm325610131", "osm325610128", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link30");
            grc.AddLinkByNodeName("osm325610133", "osm325610131", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link31");
            grc.AddLinkByNodeName("osm4779937984", "osm325610133", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link32");
            grc.AddLinkByNodeName("osm325610135", "osm4779937984", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link33");
            grc.AddLinkByNodeName("osm325610137", "osm325610135", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link34");
            grc.AddLinkByNodeName("osm4773476250", "osm325610137", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link35");
            grc.AddLinkByNodeName("osm2671027616", "osm4773476250", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link36");
            grc.AddLinkByNodeName("osm325610142", "osm2671027616", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link37");
            grc.AddLinkByNodeName("osm325610144", "osm325610142", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link38");
            grc.AddLinkByNodeName("osm2670280676", "osm325610144", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link39");
            grc.AddLinkByNodeName("osm2671035483", "osm2670280676", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link40");
            grc.AddLinkByNodeName("osm2671035470", "osm2671035483", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link41");
            grc.AddLinkByNodeName("osm2671027704", "osm2671035470", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link42");
            grc.AddLinkByNodeName("osm2671035473", "osm2671027704", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link43");
            grc.AddLinkByNodeName("osm4098517743", "osm2671035473", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link44");
            grc.AddLinkByNodeName("osm2671035471", "osm4098517743", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link45");
            grc.AddLinkByNodeName("osm2671027703", "osm2671035471", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link46");
            grc.AddLinkByNodeName("osm325610146", "osm2671027703", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link47");
            grc.AddLinkByNodeName("osm2671035453", "osm325610146", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link48");
            grc.AddLinkByNodeName("osm4773452876", "osm2671035453", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link49");
            grc.AddLinkByNodeName("osm2671035451", "osm4773452876", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link50");
            grc.AddLinkByNodeName("osm2671035449", "osm2671035451", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link51");
            grc.AddLinkByNodeName("osm4098517744", "osm2671035449", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link52");
            grc.AddLinkByNodeName("osm4806537128", "osm4098517744", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link53");
            grc.AddLinkByNodeName("osm2671035431", "osm4806537128", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link54");
            grc.AddLinkByNodeName("osm2671035434", "osm2671035431", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link55");
            grc.AddLinkByNodeName("osm2671035436", "osm2671035434", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link56");
            grc.AddLinkByNodeName("osm2671035447", "osm2671035436", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link57");
            grc.AddLinkByNodeName("osm2671035438", "osm2671035447", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link58");
            grc.AddLinkByNodeName("osm2671035440", "osm2671035438", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link59");
            grc.AddLinkByNodeName("osm2671035429", "osm2671035440", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link60");
            grc.AddLinkByNodeName("osm4098517737", "osm2671035429", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link61");
            grc.AddLinkByNodeName("osm325610155", "osm4098517737", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link62");
            grc.AddLinkByNodeName("osm2671027713", "osm325610155", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link63");
            grc.AddLinkByNodeName("osm4773452875", "osm2671027713", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link64");
            grc.AddLinkByNodeName("osm2671027712", "osm4773452875", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link65");
            grc.AddLinkByNodeName("osm325610115", "osm2671027712", usetype: LinkUse.bldwall, comment: "Microsoft Building 17.link66");

            grc.AddLinkByNodeName("osm4760407215", "osm325618934", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link1");
            grc.AddLinkByNodeName("osm4760407216", "osm4760407215", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link2");
            grc.AddLinkByNodeName("osm4753385702", "osm4760407216", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link3");
            grc.AddLinkByNodeName("osm4760407203", "osm4753385702", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link4");
            grc.AddLinkByNodeName("osm4760407202", "osm4760407203", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link5");
            grc.AddLinkByNodeName("osm325618935", "osm4760407202", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link6");
            grc.AddLinkByNodeName("osm4753326326", "osm325618935", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link7");
            grc.AddLinkByNodeName("osm325618936", "osm4753326326", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link8");
            grc.AddLinkByNodeName("osm325618937", "osm325618936", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link9");
            grc.AddLinkByNodeName("osm4760408332", "osm325618937", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link10");
            grc.AddLinkByNodeName("osm4760408331", "osm4760408332", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link11");
            grc.AddLinkByNodeName("osm4760408330", "osm4760408331", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link12");
            grc.AddLinkByNodeName("osm4753326325", "osm4760408330", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link13");
            grc.AddLinkByNodeName("osm4760408328", "osm4753326325", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link14");
            grc.AddLinkByNodeName("osm4760408327", "osm4760408328", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link15");
            grc.AddLinkByNodeName("osm325618938", "osm4760408327", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link16");
            grc.AddLinkByNodeName("osm325618939", "osm325618938", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link17");
            grc.AddLinkByNodeName("osm325618940", "osm325618939", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link18");
            grc.AddLinkByNodeName("osm325618941", "osm325618940", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link19");
            grc.AddLinkByNodeName("osm4773476253", "osm325618941", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link20");
            grc.AddLinkByNodeName("osm4760407208", "osm4773476253", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link21");
            grc.AddLinkByNodeName("osm7346644190", "osm4760407208", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link22");
            grc.AddLinkByNodeName("osm7346644189", "osm7346644190", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link23");
            grc.AddLinkByNodeName("osm7346644188", "osm7346644189", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link24");
            grc.AddLinkByNodeName("osm7346644187", "osm7346644188", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link25");
            grc.AddLinkByNodeName("osm325618943", "osm7346644187", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link26");
            grc.AddLinkByNodeName("osm4753326321", "osm325618943", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link27");
            grc.AddLinkByNodeName("osm325618944", "osm4753326321", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link28");
            grc.AddLinkByNodeName("osm325618945", "osm325618944", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link29");
            grc.AddLinkByNodeName("osm4760407207", "osm325618945", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link30");
            grc.AddLinkByNodeName("osm325618946", "osm4760407207", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link31");
            grc.AddLinkByNodeName("osm325618948", "osm325618946", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link32");
            grc.AddLinkByNodeName("osm4753326324", "osm325618948", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link33");
            grc.AddLinkByNodeName("osm325618949", "osm4753326324", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link34");
            grc.AddLinkByNodeName("osm325618950", "osm325618949", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link35");
            grc.AddLinkByNodeName("osm325618951", "osm325618950", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link36");
            grc.AddLinkByNodeName("osm4760407211", "osm325618951", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link37");
            grc.AddLinkByNodeName("osm4753385704", "osm4760407211", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link38");
            grc.AddLinkByNodeName("osm4760407214", "osm4753385704", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link39");
            grc.AddLinkByNodeName("osm325618952", "osm4760407214", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link40");
            grc.AddLinkByNodeName("osm325618953", "osm325618952", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link41");
            grc.AddLinkByNodeName("osm4760407213", "osm325618953", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link42");
            grc.AddLinkByNodeName("osm4753385703", "osm4760407213", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link43");
            grc.AddLinkByNodeName("osm4760407212", "osm4753385703", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link44");
            grc.AddLinkByNodeName("osm325618955", "osm4760407212", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link45");
            grc.AddLinkByNodeName("osm325618956", "osm325618955", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link46");
            grc.AddLinkByNodeName("osm325618957", "osm325618956", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link47");
            grc.AddLinkByNodeName("osm325618934", "osm325618957", usetype: LinkUse.bldwall, comment: "Microsoft Building 34.link48");

            grc.AddLinkByNodeName("osm4985583151", "osm409798994", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link1");
            grc.AddLinkByNodeName("osm4985583152", "osm4985583151", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link2");
            grc.AddLinkByNodeName("osm409798995", "osm4985583152", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link3");
            grc.AddLinkByNodeName("osm6331166445", "osm409798995", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link4");
            grc.AddLinkByNodeName("osm409798996", "osm6331166445", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link5");
            grc.AddLinkByNodeName("osm336768305", "osm409798996", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link6");
            grc.AddLinkByNodeName("osm336768301", "osm336768305", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link7");
            grc.AddLinkByNodeName("osm4983743928", "osm336768301", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link8");
            grc.AddLinkByNodeName("osm4983743927", "osm4983743928", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link9");
            grc.AddLinkByNodeName("osm7350734412", "osm4983743927", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link10");
            grc.AddLinkByNodeName("osm7350734411", "osm7350734412", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link11");
            grc.AddLinkByNodeName("osm7484830129", "osm7350734411", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link12");
            grc.AddLinkByNodeName("osm7484830240", "osm7484830129", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link13");
            grc.AddLinkByNodeName("osm7484830245", "osm7484830240", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link14");
            grc.AddLinkByNodeName("osm4985583154", "osm7484830245", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link15");
            grc.AddLinkByNodeName("osm7350734410", "osm4985583154", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link16");
            grc.AddLinkByNodeName("osm7350734409", "osm7350734410", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link17");
            grc.AddLinkByNodeName("osm4983712060", "osm7350734409", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link18");
            grc.AddLinkByNodeName("osm336768295", "osm4983712060", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link19");
            grc.AddLinkByNodeName("osm4983712057", "osm336768295", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link20");
            grc.AddLinkByNodeName("osm336768292", "osm4983712057", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link21");
            grc.AddLinkByNodeName("osm4985583153", "osm336768292", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link22");
            grc.AddLinkByNodeName("osm6331167729", "osm4985583153", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link23");
            grc.AddLinkByNodeName("osm336768291", "osm6331167729", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link24");
            grc.AddLinkByNodeName("osm336768288", "osm336768291", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link25");
            grc.AddLinkByNodeName("osm336768285", "osm336768288", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link26");
            grc.AddLinkByNodeName("osm4983712059", "osm336768285", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link27");
            grc.AddLinkByNodeName("osm336768282", "osm4983712059", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link28");
            grc.AddLinkByNodeName("osm4983712058", "osm336768282", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link29");
            grc.AddLinkByNodeName("osm7350734407", "osm4983712058", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link30");
            grc.AddLinkByNodeName("osm7350734408", "osm7350734407", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link31");
            grc.AddLinkByNodeName("osm336768280", "osm7350734408", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link32");
            grc.AddLinkByNodeName("osm336768278", "osm336768280", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link33");
            grc.AddLinkByNodeName("osm7350734406", "osm336768278", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link34");
            grc.AddLinkByNodeName("osm7350734405", "osm7350734406", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link35");
            grc.AddLinkByNodeName("osm4983712056", "osm7350734405", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link36");
            grc.AddLinkByNodeName("osm336768275", "osm4983712056", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link37");
            grc.AddLinkByNodeName("osm4983712055", "osm336768275", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link38");
            grc.AddLinkByNodeName("osm336768272", "osm4983712055", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link39");
            grc.AddLinkByNodeName("osm6331167737", "osm336768272", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link40");
            grc.AddLinkByNodeName("osm336768330", "osm6331167737", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link41");
            grc.AddLinkByNodeName("osm7473295910", "osm336768330", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link42");
            grc.AddLinkByNodeName("osm4983712053", "osm7473295910", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link43");
            grc.AddLinkByNodeName("osm4983712054", "osm4983712053", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link44");
            grc.AddLinkByNodeName("osm336768329", "osm4983712054", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link45");
            grc.AddLinkByNodeName("osm7350734404", "osm336768329", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link46");
            grc.AddLinkByNodeName("osm7350734403", "osm7350734404", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link47");
            grc.AddLinkByNodeName("osm336768327", "osm7350734403", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link48");
            grc.AddLinkByNodeName("osm7473295906", "osm336768327", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link49");
            grc.AddLinkByNodeName("osm7473295908", "osm7473295906", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link50");
            grc.AddLinkByNodeName("osm4983712062", "osm7473295908", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link51");
            grc.AddLinkByNodeName("osm336768326", "osm4983712062", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link52");
            grc.AddLinkByNodeName("osm7350734402", "osm336768326", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link53");
            grc.AddLinkByNodeName("osm7350734401", "osm7350734402", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link54");
            grc.AddLinkByNodeName("osm4983712063", "osm7350734401", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link55");
            grc.AddLinkByNodeName("osm7350734390", "osm4983712063", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link56");
            grc.AddLinkByNodeName("osm336768325", "osm7350734390", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link57");
            grc.AddLinkByNodeName("osm6331167700", "osm336768325", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link58");
            grc.AddLinkByNodeName("osm336768323", "osm6331167700", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link59");
            grc.AddLinkByNodeName("osm336768322", "osm336768323", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link60");
            grc.AddLinkByNodeName("osm336768320", "osm336768322", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link61");
            grc.AddLinkByNodeName("osm336768318", "osm336768320", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link62");
            grc.AddLinkByNodeName("osm6331167699", "osm336768318", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link63");
            grc.AddLinkByNodeName("osm7350734391", "osm6331167699", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link64");
            grc.AddLinkByNodeName("osm7350734392", "osm7350734391", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link65");
            grc.AddLinkByNodeName("osm4983712068", "osm7350734392", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link66");
            grc.AddLinkByNodeName("osm7350734400", "osm4983712068", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link67");
            grc.AddLinkByNodeName("osm7350734399", "osm7350734400", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link68");
            grc.AddLinkByNodeName("osm336768316", "osm7350734399", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link69");
            grc.AddLinkByNodeName("osm336768313", "osm336768316", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link70");
            grc.AddLinkByNodeName("osm7473295893", "osm336768313", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link71");
            grc.AddLinkByNodeName("osm336768312", "osm7473295893", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link72");
            grc.AddLinkByNodeName("osm7350734398", "osm336768312", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link73");
            grc.AddLinkByNodeName("osm7350734397", "osm7350734398", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link74");
            grc.AddLinkByNodeName("osm336768309", "osm7350734397", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link75");
            grc.AddLinkByNodeName("osm7350734394", "osm336768309", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link76");
            grc.AddLinkByNodeName("osm7350734393", "osm7350734394", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link77");
            grc.AddLinkByNodeName("osm336768307", "osm7350734393", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link78");
            grc.AddLinkByNodeName("osm7473295897", "osm336768307", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link79");
            grc.AddLinkByNodeName("osm2675737180", "osm7473295897", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link80");
            grc.AddLinkByNodeName("osm2675737179", "osm2675737180", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link81");
            grc.AddLinkByNodeName("osm4983712067", "osm2675737179", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link82");
            grc.AddLinkByNodeName("osm2675737178", "osm4983712067", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link83");
            grc.AddLinkByNodeName("osm409798997", "osm2675737178", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link84");
            grc.AddLinkByNodeName("osm2675737181", "osm409798997", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link85");
            grc.AddLinkByNodeName("osm2675737182", "osm2675737181", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link86");
            grc.AddLinkByNodeName("osm336772832", "osm2675737182", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link87");
            grc.AddLinkByNodeName("osm2675737186", "osm336772832", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link88");
            grc.AddLinkByNodeName("osm336772831", "osm2675737186", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link89");
            grc.AddLinkByNodeName("osm2675737185", "osm336772831", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link90");
            grc.AddLinkByNodeName("osm7350734396", "osm2675737185", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link91");
            grc.AddLinkByNodeName("osm7350734395", "osm7350734396", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link92");
            grc.AddLinkByNodeName("osm2675737184", "osm7350734395", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link93");
            grc.AddLinkByNodeName("osm336772828", "osm2675737184", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link94");
            grc.AddLinkByNodeName("osm336772826", "osm336772828", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link95");
            grc.AddLinkByNodeName("osm4983712052", "osm336772826", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link96");
            grc.AddLinkByNodeName("osm2675737188", "osm4983712052", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link97");
            grc.AddLinkByNodeName("osm2675737187", "osm2675737188", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link98");
            grc.AddLinkByNodeName("osm2675737189", "osm2675737187", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link99");
            grc.AddLinkByNodeName("osm2675737190", "osm2675737189", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link100");
            grc.AddLinkByNodeName("osm7473295876", "osm2675737190", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link101");
            grc.AddLinkByNodeName("osm336772824", "osm7473295876", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link102");
            grc.AddLinkByNodeName("osm336772822", "osm336772824", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link103");
            grc.AddLinkByNodeName("osm336772821", "osm336772822", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link104");
            grc.AddLinkByNodeName("osm336772820", "osm336772821", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link105");
            grc.AddLinkByNodeName("osm7473295875", "osm336772820", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link106");
            grc.AddLinkByNodeName("osm4983712041", "osm7473295875", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link107");
            grc.AddLinkByNodeName("osm4983712040", "osm4983712041", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link108");
            grc.AddLinkByNodeName("osm4983712039", "osm4983712040", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link109");
            grc.AddLinkByNodeName("osm7350734424", "osm4983712039", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link110");
            grc.AddLinkByNodeName("osm7350734423", "osm7350734424", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link111");
            grc.AddLinkByNodeName("osm336772818", "osm7350734423", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link112");
            grc.AddLinkByNodeName("osm336772816", "osm336772818", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link113");
            grc.AddLinkByNodeName("osm336772815", "osm336772816", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link114");
            grc.AddLinkByNodeName("osm7350734422", "osm336772815", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link115");
            grc.AddLinkByNodeName("osm7350734421", "osm7350734422", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link116");
            grc.AddLinkByNodeName("osm4983712042", "osm7350734421", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link117");
            grc.AddLinkByNodeName("osm336772812", "osm4983712042", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link118");
            grc.AddLinkByNodeName("osm4983712043", "osm336772812", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link119");
            grc.AddLinkByNodeName("osm336772811", "osm4983712043", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link120");
            grc.AddLinkByNodeName("osm336772809", "osm336772811", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link121");
            grc.AddLinkByNodeName("osm4983712044", "osm336772809", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link122");
            grc.AddLinkByNodeName("osm4983712045", "osm4983712044", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link123");
            grc.AddLinkByNodeName("osm7350734420", "osm4983712045", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link124");
            grc.AddLinkByNodeName("osm7350734419", "osm7350734420", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link125");
            grc.AddLinkByNodeName("osm336772807", "osm7350734419", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link126");
            grc.AddLinkByNodeName("osm336772806", "osm336772807", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link127");
            grc.AddLinkByNodeName("osm336772805", "osm336772806", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link128");
            grc.AddLinkByNodeName("osm4983712038", "osm336772805", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link129");
            grc.AddLinkByNodeName("osm7350734418", "osm4983712038", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link130");
            grc.AddLinkByNodeName("osm7350734417", "osm7350734418", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link131");
            grc.AddLinkByNodeName("osm336772800", "osm7350734417", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link132");
            grc.AddLinkByNodeName("osm4983712047", "osm336772800", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link133");
            grc.AddLinkByNodeName("osm4983712046", "osm4983712047", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link134");
            grc.AddLinkByNodeName("osm7473375080", "osm4983712046", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link135");
            grc.AddLinkByNodeName("osm336772798", "osm7473375080", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link136");
            grc.AddLinkByNodeName("osm336772796", "osm336772798", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link137");
            grc.AddLinkByNodeName("osm336772795", "osm336772796", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link138");
            grc.AddLinkByNodeName("osm336772793", "osm336772795", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link139");
            grc.AddLinkByNodeName("osm4983712049", "osm336772793", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link140");
            grc.AddLinkByNodeName("osm336772791", "osm4983712049", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link141");
            grc.AddLinkByNodeName("osm4983712037", "osm336772791", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link142");
            grc.AddLinkByNodeName("osm7350734416", "osm4983712037", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link143");
            grc.AddLinkByNodeName("osm7350734415", "osm7350734416", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link144");
            grc.AddLinkByNodeName("osm4983712048", "osm7350734415", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link145");
            grc.AddLinkByNodeName("osm7484830204", "osm4983712048", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link146");
            grc.AddLinkByNodeName("osm336772790", "osm7484830204", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link147");
            grc.AddLinkByNodeName("osm336772789", "osm336772790", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link148");
            grc.AddLinkByNodeName("osm7350734414", "osm336772789", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link149");
            grc.AddLinkByNodeName("osm7350734413", "osm7350734414", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link150");
            grc.AddLinkByNodeName("osm336772788", "osm7350734413", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link151");
            grc.AddLinkByNodeName("osm4983712051", "osm336772788", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link152");
            grc.AddLinkByNodeName("osm4983712050", "osm4983712051", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link153");
            grc.AddLinkByNodeName("osm336772786", "osm4983712050", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link154");
            grc.AddLinkByNodeName("osm6331166457", "osm336772786", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link155");
            grc.AddLinkByNodeName("osm409798978", "osm6331166457", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link156");
            grc.AddLinkByNodeName("osm7484830133", "osm409798978", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link157");
            grc.AddLinkByNodeName("osm409798994", "osm7484830133", usetype: LinkUse.bldwall, comment: "Microsoft Building 25.link158");

            grc.AddLinkByNodeName("osm345261390", "osm345261389", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link1");
            grc.AddLinkByNodeName("osm345261392", "osm345261390", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link2");
            grc.AddLinkByNodeName("osm7473295809", "osm345261392", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link3");
            grc.AddLinkByNodeName("osm345261393", "osm7473295809", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link4");
            grc.AddLinkByNodeName("osm345261394", "osm345261393", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link5");
            grc.AddLinkByNodeName("osm345261395", "osm345261394", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link6");
            grc.AddLinkByNodeName("osm345261396", "osm345261395", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link7");
            grc.AddLinkByNodeName("osm345261397", "osm345261396", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link8");
            grc.AddLinkByNodeName("osm345261398", "osm345261397", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link9");
            grc.AddLinkByNodeName("osm7472994604", "osm345261398", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link10");
            grc.AddLinkByNodeName("osm7350890253", "osm7472994604", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link11");
            grc.AddLinkByNodeName("osm7350890252", "osm7350890253", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link12");
            grc.AddLinkByNodeName("osm7132371567", "osm7350890252", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link13");
            grc.AddLinkByNodeName("osm7350890251", "osm7132371567", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link14");
            grc.AddLinkByNodeName("osm7350890245", "osm7350890251", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link15");
            grc.AddLinkByNodeName("osm7350890250", "osm7350890245", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link16");
            grc.AddLinkByNodeName("osm345261400", "osm7350890250", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link17");
            grc.AddLinkByNodeName("osm345261401", "osm345261400", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link18");
            grc.AddLinkByNodeName("osm345261402", "osm345261401", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link19");
            grc.AddLinkByNodeName("osm7350890244", "osm345261402", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link20");
            grc.AddLinkByNodeName("osm7350890243", "osm7350890244", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link21");
            grc.AddLinkByNodeName("osm7350890242", "osm7350890243", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link22");
            grc.AddLinkByNodeName("osm7350890241", "osm7350890242", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link23");
            grc.AddLinkByNodeName("osm345261403", "osm7350890241", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link24");
            grc.AddLinkByNodeName("osm345261404", "osm345261403", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link25");
            grc.AddLinkByNodeName("osm7132371562", "osm345261404", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link26");
            grc.AddLinkByNodeName("osm7486062633", "osm7132371562", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link27");
            grc.AddLinkByNodeName("osm7486062637", "osm7486062633", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link28");
            grc.AddLinkByNodeName("osm345261389", "osm7486062637", usetype: LinkUse.bldwall, comment: "Microsoft Building 20.link29");

            grc.AddLinkByNodeName("osm345266072", "osm345266071", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link1");
            grc.AddLinkByNodeName("osm4758568841", "osm345266072", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link2");
            grc.AddLinkByNodeName("osm345266073", "osm4758568841", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link3");
            grc.AddLinkByNodeName("osm7346301662", "osm345266073", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link4");
            grc.AddLinkByNodeName("osm7346301661", "osm7346301662", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link5");
            grc.AddLinkByNodeName("osm4758568844", "osm7346301661", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link6");
            grc.AddLinkByNodeName("osm345266076", "osm4758568844", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link7");
            grc.AddLinkByNodeName("osm345266077", "osm345266076", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link8");
            grc.AddLinkByNodeName("osm345266080", "osm345266077", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link9");
            grc.AddLinkByNodeName("osm7132384722", "osm345266080", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link10");
            grc.AddLinkByNodeName("osm4740268535", "osm7132384722", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link11");
            grc.AddLinkByNodeName("osm7132384717", "osm4740268535", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link12");
            grc.AddLinkByNodeName("osm4740268533", "osm7132384717", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link13");
            grc.AddLinkByNodeName("osm345266082", "osm4740268533", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link14");
            grc.AddLinkByNodeName("osm7132384719", "osm345266082", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link15");
            grc.AddLinkByNodeName("osm7132384720", "osm7132384719", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link16");
            grc.AddLinkByNodeName("osm7346301671", "osm7132384720", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link17");
            grc.AddLinkByNodeName("osm4758634644", "osm7346301671", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link18");
            grc.AddLinkByNodeName("osm345266086", "osm4758634644", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link19");
            grc.AddLinkByNodeName("osm4753578018", "osm345266086", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link20");
            grc.AddLinkByNodeName("osm7345287876", "osm4753578018", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link21");
            grc.AddLinkByNodeName("osm7345287877", "osm7345287876", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link22");
            grc.AddLinkByNodeName("osm7345287878", "osm7345287877", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link23");
            grc.AddLinkByNodeName("osm7345287879", "osm7345287878", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link24");
            grc.AddLinkByNodeName("osm345266093", "osm7345287879", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link25");
            grc.AddLinkByNodeName("osm345266097", "osm345266093", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link26");
            grc.AddLinkByNodeName("osm345266099", "osm345266097", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link27");
            grc.AddLinkByNodeName("osm4758634648", "osm345266099", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link28");
            grc.AddLinkByNodeName("osm7346301669", "osm4758634648", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link29");
            grc.AddLinkByNodeName("osm7346301670", "osm7346301669", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link30");
            grc.AddLinkByNodeName("osm7346301668", "osm7346301670", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link31");
            grc.AddLinkByNodeName("osm7346301667", "osm7346301668", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link32");
            grc.AddLinkByNodeName("osm4781654488", "osm7346301667", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link33");
            grc.AddLinkByNodeName("osm7346301666", "osm4781654488", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link34");
            grc.AddLinkByNodeName("osm7346301665", "osm7346301666", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link35");
            grc.AddLinkByNodeName("osm7070870706", "osm7346301665", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link36");
            grc.AddLinkByNodeName("osm7346301664", "osm7070870706", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link37");
            grc.AddLinkByNodeName("osm7346301663", "osm7346301664", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link38");
            grc.AddLinkByNodeName("osm7070870702", "osm7346301663", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link39");
            grc.AddLinkByNodeName("osm4753326215", "osm7070870702", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link40");
            grc.AddLinkByNodeName("osm4740268536", "osm4753326215", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link41");
            grc.AddLinkByNodeName("osm345266071", "osm4740268536", usetype: LinkUse.bldwall, comment: "Microsoft Building 33.link42");

            grc.AddLinkByNodeName("osm6331167730", "osm409799024", usetype: LinkUse.bldwall, comment: "parking01.link1");
            grc.AddLinkByNodeName("osm6331167764", "osm6331167730", usetype: LinkUse.bldwall, comment: "parking01.link2");
            grc.AddLinkByNodeName("osm6331167765", "osm6331167764", usetype: LinkUse.bldwall, comment: "parking01.link3");
            grc.AddLinkByNodeName("osm409799025", "osm6331167765", usetype: LinkUse.bldwall, comment: "parking01.link4");
            grc.AddLinkByNodeName("osm6331167761", "osm409799025", usetype: LinkUse.bldwall, comment: "parking01.link5");
            grc.AddLinkByNodeName("osm7473295912", "osm6331167761", usetype: LinkUse.bldwall, comment: "parking01.link6");
            grc.AddLinkByNodeName("osm7120525634", "osm7473295912", usetype: LinkUse.bldwall, comment: "parking01.link7");
            grc.AddLinkByNodeName("osm6331167768", "osm7120525634", usetype: LinkUse.bldwall, comment: "parking01.link8");
            grc.AddLinkByNodeName("osm6331167762", "osm6331167768", usetype: LinkUse.bldwall, comment: "parking01.link9");
            grc.AddLinkByNodeName("osm6331167763", "osm6331167762", usetype: LinkUse.bldwall, comment: "parking01.link10");
            grc.AddLinkByNodeName("osm409799026", "osm6331167763", usetype: LinkUse.bldwall, comment: "parking01.link11");
            grc.AddLinkByNodeName("osm409799027", "osm409799026", usetype: LinkUse.bldwall, comment: "parking01.link12");
            grc.AddLinkByNodeName("osm6331167751", "osm409799027", usetype: LinkUse.bldwall, comment: "parking01.link13");
            grc.AddLinkByNodeName("osm409799028", "osm6331167751", usetype: LinkUse.bldwall, comment: "parking01.link14");
            grc.AddLinkByNodeName("osm6331167742", "osm409799028", usetype: LinkUse.bldwall, comment: "parking01.link15");
            grc.AddLinkByNodeName("osm6331167766", "osm6331167742", usetype: LinkUse.bldwall, comment: "parking01.link16");
            grc.AddLinkByNodeName("osm4983743924", "osm6331167766", usetype: LinkUse.bldwall, comment: "parking01.link17");
            grc.AddLinkByNodeName("osm4983743925", "osm4983743924", usetype: LinkUse.bldwall, comment: "parking01.link18");
            grc.AddLinkByNodeName("osm4983743926", "osm4983743925", usetype: LinkUse.bldwall, comment: "parking01.link19");
            grc.AddLinkByNodeName("osm409799024", "osm4983743926", usetype: LinkUse.bldwall, comment: "parking01.link20");

            grc.AddLinkByNodeName("osm2671035478", "osm2671035477", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link1");
            grc.AddLinkByNodeName("osm2671035479", "osm2671035478", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link2");
            grc.AddLinkByNodeName("osm2671035476", "osm2671035479", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link3");
            grc.AddLinkByNodeName("osm2672290205", "osm2671035476", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link4");
            grc.AddLinkByNodeName("osm2671035475", "osm2672290205", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link5");
            grc.AddLinkByNodeName("osm2671035480", "osm2671035475", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link6");
            grc.AddLinkByNodeName("osm2671035482", "osm2671035480", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link7");
            grc.AddLinkByNodeName("osm2671035483", "osm2671035482", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link8");
            grc.AddLinkByNodeName("osm2670280676", "osm2671035483", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link9");
            grc.AddLinkByNodeName("osm2671027633", "osm2670280676", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link10");
            grc.AddLinkByNodeName("osm2671027631", "osm2671027633", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link11");
            grc.AddLinkByNodeName("osm2671027632", "osm2671027631", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link12");
            grc.AddLinkByNodeName("osm2671027630", "osm2671027632", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link13");
            grc.AddLinkByNodeName("osm2671027635", "osm2671027630", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link14");
            grc.AddLinkByNodeName("osm2671027634", "osm2671027635", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link15");
            grc.AddLinkByNodeName("osm2671027636", "osm2671027634", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link16");
            grc.AddLinkByNodeName("osm4773716039", "osm2671027636", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link17");
            grc.AddLinkByNodeName("osm2671027628", "osm4773716039", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link18");
            grc.AddLinkByNodeName("osm2671027638", "osm2671027628", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link19");
            grc.AddLinkByNodeName("osm2671027637", "osm2671027638", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link20");
            grc.AddLinkByNodeName("osm2671027640", "osm2671027637", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link21");
            grc.AddLinkByNodeName("osm2671027629", "osm2671027640", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link22");
            grc.AddLinkByNodeName("osm2671027639", "osm2671027629", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link23");
            grc.AddLinkByNodeName("osm2671027641", "osm2671027639", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link24");
            grc.AddLinkByNodeName("osm2671035477", "osm2671027641", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 16.link25");

            grc.AddLinkByNodeName("osm6333379830", "osm3516771343", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link1");
            grc.AddLinkByNodeName("osm3516771344", "osm6333379830", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link2");
            grc.AddLinkByNodeName("osm3516771341", "osm3516771344", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link3");
            grc.AddLinkByNodeName("osm7484825441", "osm3516771341", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link4");
            grc.AddLinkByNodeName("osm3516771345", "osm7484825441", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link5");
            grc.AddLinkByNodeName("osm3516771346", "osm3516771345", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link6");
            grc.AddLinkByNodeName("osm7484825440", "osm3516771346", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link7");
            grc.AddLinkByNodeName("osm4802527987", "osm7484825440", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link8");
            grc.AddLinkByNodeName("osm7484825433", "osm4802527987", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link9");
            grc.AddLinkByNodeName("osm3516771340", "osm7484825433", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link10");
            grc.AddLinkByNodeName("osm3516771335", "osm3516771340", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link11");
            grc.AddLinkByNodeName("osm3516771328", "osm3516771335", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link12");
            grc.AddLinkByNodeName("osm7484825472", "osm3516771328", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link13");
            grc.AddLinkByNodeName("osm3516771327", "osm7484825472", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link14");
            grc.AddLinkByNodeName("osm3516771316", "osm3516771327", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link15");
            grc.AddLinkByNodeName("osm3516771315", "osm3516771316", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link16");
            grc.AddLinkByNodeName("osm7484825468", "osm3516771315", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link17");
            grc.AddLinkByNodeName("osm3516771306", "osm7484825468", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link18");
            grc.AddLinkByNodeName("osm7484830121", "osm3516771306", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link19");
            grc.AddLinkByNodeName("osm7484830115", "osm7484830121", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link20");
            grc.AddLinkByNodeName("osm3516771296", "osm7484830115", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link21");
            grc.AddLinkByNodeName("osm7484830103", "osm3516771296", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link22");
            grc.AddLinkByNodeName("osm3516771294", "osm7484830103", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link23");
            grc.AddLinkByNodeName("osm7484830102", "osm3516771294", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link24");
            grc.AddLinkByNodeName("osm7484830111", "osm7484830102", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link25");
            grc.AddLinkByNodeName("osm4802528011", "osm7484830111", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link26");
            grc.AddLinkByNodeName("osm3516771307", "osm4802528011", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link27");
            grc.AddLinkByNodeName("osm3516771317", "osm3516771307", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link28");
            grc.AddLinkByNodeName("osm7120525642", "osm3516771317", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link29");
            grc.AddLinkByNodeName("osm7484830093", "osm7120525642", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link30");
            grc.AddLinkByNodeName("osm3516771324", "osm7484830093", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link31");
            grc.AddLinkByNodeName("osm7484830094", "osm3516771324", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link32");
            grc.AddLinkByNodeName("osm3516771334", "osm7484830094", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link33");
            grc.AddLinkByNodeName("osm3516771339", "osm3516771334", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link34");
            grc.AddLinkByNodeName("osm3516771343", "osm3516771339", usetype: LinkUse.bldwall, comment: "Microsoft Living Well Health Center.link35");
            grc.regman.SetRegion("default");
            // Area msftb19area machine generated 638 nodes and 642 links on 2020-06-23 13:25:36.547991
        }


        public void CreateGraphForOsmImport_msftcommons()  // machine generated on 2020-06-23 13:26:41.078867 local time  - do not edit
        {
            grc.regman.NewNodeRegion("Microsoft Commons", "green", saveToFile: true);
            var xs = -2;  // offsets for error correction
            var zs = 0;
            grc.AddNodePtxz("osm408723991", 296.594 + xs, -292.987 + zs);
            grc.AddNodePtxz("osm4809166493", 331.276 + xs, -357.309 + zs);
            grc.AddNodePtxz("osm5159887907", 58.588 + xs, 98.177 + zs);
            grc.AddNodePtxz("osm3934886418", -16.346 + xs, -20.933 + zs);
            grc.AddNodePtxz("osm810301405", 71.167 + xs, -2.824 + zs);
            grc.AddNodePtxz("osm6946491924", -107.125 + xs, -562.858 + zs);
            grc.AddNodePtxz("osm6997351170", -521.980 + xs, -525.993 + zs);
            grc.AddNodePtxz("osm1491011784", -356.174 + xs, -414.779 + zs);
            grc.AddNodePtxz("osm4846295223", -514.286 + xs, -595.301 + zs);
            grc.AddNodePtxz("osm3347106862", -102.873 + xs, -591.004 + zs);
            grc.AddNodePtxz("osm3347107204", -154.497 + xs, -613.319 + zs);
            grc.AddNodePtxz("osm4818775962", -149.560 + xs, -611.621 + zs);
            grc.AddNodePtxz("osm3225793005", -146.150 + xs, -610.446 + zs);
            grc.AddNodePtxz("osm3225789647", -147.461 + xs, -606.443 + zs);
            grc.AddNodePtxz("osm4802534846", -140.273 + xs, -603.697 + zs);
            grc.AddNodePtxz("osm3225792978", -138.945 + xs, -603.179 + zs);
            grc.AddNodePtxz("osm3225792963", -137.404 + xs, -607.436 + zs);
            grc.AddNodePtxz("osm3225789641", -124.197 + xs, -602.883 + zs);
            grc.AddNodePtxz("osm3225792969", -120.506 + xs, -613.700 + zs);
            grc.AddNodePtxz("osm4650086186", -108.807 + xs, -612.142 + zs);
            grc.AddNodePtxz("osm3225793007", -105.164 + xs, -611.600 + zs);
            grc.AddNodePtxz("osm3225789660", -107.993 + xs, -592.044 + zs);
            grc.AddNodePtxz("osm4487603939", -293.354 + xs, -630.882 + zs);
            grc.AddNodePtxz("osm3734072199", -395.654 + xs, -682.214 + zs);
            grc.AddNodePtxz("osm3734072200", -327.932 + xs, -658.000 + zs);
            grc.AddNodePtxz("osm3734071424", -141.680 + xs, -453.158 + zs);
            grc.AddNodePtxz("osm321154629", 115.120 + xs, -588.302 + zs);
            grc.AddNodePtxz("osm3734091508", 55.391 + xs, -598.214 + zs);
            grc.AddNodePtxz("osm6997351099", -454.653 + xs, -646.550 + zs);
            grc.AddNodePtxz("osm3742149264", 81.154 + xs, -523.061 + zs);
            grc.AddNodePtxz("osm3742149276", 130.971 + xs, -535.189 + zs);
            grc.AddNodePtxz("osm3742149277", 82.616 + xs, -578.208 + zs);
            grc.AddNodePtxz("osm6997225354", -246.466 + xs, -317.170 + zs);
            grc.AddNodePtxz("osm3833737984", 77.284 + xs, -2.876 + zs);
            grc.AddNodePtxz("osm3833737898", 24.540 + xs, -26.874 + zs);
            grc.AddNodePtxz("osm3934726679", 170.194 + xs, 89.894 + zs);
            grc.AddNodePtxz("osm5159874251", -194.726 + xs, -12.205 + zs);
            grc.AddNodePtxz("osm3934886402", -85.458 + xs, -18.365 + zs);
            grc.AddNodePtxz("osm5159887891", -101.073 + xs, -18.443 + zs);
            grc.AddNodePtxz("osm4017340415", 296.137 + xs, 180.038 + zs);
            grc.AddNodePtxz("osm4294894962", -167.090 + xs, -221.904 + zs);
            grc.AddNodePtxz("osm4621191643", -483.949 + xs, -480.884 + zs);
            grc.AddNodePtxz("osm1490676089", -479.431 + xs, -475.876 + zs);
            grc.AddNodePtxz("osm4621191651", -386.781 + xs, -424.141 + zs);
            grc.AddNodePtxz("osm4621191654", -391.878 + xs, -425.988 + zs);
            grc.AddNodePtxz("osm4736778518", 16.507 + xs, -543.228 + zs);
            grc.AddNodePtxz("osm4818775952", -292.643 + xs, -350.231 + zs);
            grc.AddNodePtxz("osm4818775957", -151.126 + xs, -646.314 + zs);
            grc.AddNodePtxz("osm7549247126", -248.145 + xs, -273.971 + zs);
            grc.AddNodePtxz("osm4823517539", -320.221 + xs, -326.109 + zs);
            grc.AddNodePtxz("osm4823517540", -313.659 + xs, -325.915 + zs);
            grc.AddNodePtxz("osm6946491923", -89.175 + xs, -560.325 + zs);
            grc.AddNodePtxz("osm4829350835", -362.772 + xs, -211.946 + zs);
            grc.AddNodePtxz("osm4823527356", -150.645 + xs, -288.145 + zs);
            grc.AddNodePtxz("osm4823517527", -149.537 + xs, -301.216 + zs);
            grc.AddNodePtxz("osm4829304117", -353.286 + xs, -522.083 + zs);
            grc.AddNodePtxz("osm4831739751", -448.705 + xs, -304.055 + zs);
            grc.AddNodePtxz("osm4829350219", -398.834 + xs, -243.541 + zs);
            grc.AddNodePtxz("osm6042865916", -593.842 + xs, -387.344 + zs);
            grc.AddNodePtxz("osm4829304112", -498.222 + xs, -437.870 + zs);
            grc.AddNodePtxz("osm4846255771", -415.716 + xs, -199.178 + zs);
            grc.AddNodePtxz("osm7003048438", -440.155 + xs, -231.824 + zs);
            grc.AddNodePtxz("osm6042865810", -490.104 + xs, -586.254 + zs);
            grc.AddNodePtxz("osm4846295227", -483.949 + xs, -468.147 + zs);
            grc.AddNodePtxz("osm4846459977", -237.695 + xs, -602.853 + zs);
            grc.AddNodePtxz("osm6955760133", -302.242 + xs, -598.469 + zs);
            grc.AddNodePtxz("osm4818775963", -168.444 + xs, -618.118 + zs);
            grc.AddNodePtxz("osm4856079633", -568.473 + xs, -367.228 + zs);
            grc.AddNodePtxz("osm4856079632", -567.040 + xs, -360.052 + zs);
            grc.AddNodePtxz("osm4856079660", -540.478 + xs, -374.992 + zs);
            grc.AddNodePtxz("osm4856079654", -587.740 + xs, -308.743 + zs);
            grc.AddNodePtxz("osm6997351091", -494.462 + xs, -580.292 + zs);
            grc.AddNodePtxz("osm4856116766", -564.991 + xs, -575.635 + zs);
            grc.AddNodePtxz("osm4829304113", -550.691 + xs, -524.424 + zs);
            grc.AddNodePtxz("osm6997477469", -571.726 + xs, -503.417 + zs);
            grc.AddNodePtxz("osm4829304088", -420.609 + xs, -387.829 + zs);
            grc.AddNodePtxz("osm7469351337", -284.931 + xs, -358.657 + zs);
            grc.AddNodePtxz("osm4886286152", -239.994 + xs, -715.410 + zs);
            grc.AddNodePtxz("osm4886286157", -251.295 + xs, -683.585 + zs);
            grc.AddNodePtxz("osm4892667580", -380.433 + xs, -736.801 + zs);
            grc.AddNodePtxz("osm4892667586", -440.475 + xs, -747.098 + zs);
            grc.AddNodePtxz("osm1488883261", -606.799 + xs, -313.295 + zs);
            grc.AddNodePtxz("osm5145915623", 160.350 + xs, 181.659 + zs);
            grc.AddNodePtxz("osm5145915626", 232.484 + xs, 196.999 + zs);
            grc.AddNodePtxz("osm5145915627", 252.689 + xs, 117.660 + zs);
            grc.AddNodePtxz("osm5159751031", -163.601 + xs, -13.693 + zs);
            grc.AddNodePtxz("osm7103327057", -148.813 + xs, -8.638 + zs);
            grc.AddNodePtxz("osm5159751038", -127.287 + xs, -0.762 + zs);
            grc.AddNodePtxz("osm5159751039", -127.370 + xs, 5.087 + zs);
            grc.AddNodePtxz("osm5159874264", -125.222 + xs, 5.117 + zs);
            grc.AddNodePtxz("osm809794790", -123.115 + xs, 5.031 + zs);
            grc.AddNodePtxz("osm5159751036", -123.072 + xs, 9.846 + zs);
            grc.AddNodePtxz("osm5159751037", -120.093 + xs, 10.097 + zs);
            grc.AddNodePtxz("osm809793934", -88.566 + xs, 2.354 + zs);
            grc.AddNodePtxz("osm7103240878", -91.665 + xs, 2.379 + zs);
            grc.AddNodePtxz("osm5159874266", -98.964 + xs, 2.367 + zs);
            grc.AddNodePtxz("osm5159874265", -110.450 + xs, 2.356 + zs);
            grc.AddNodePtxz("osm809793935", -119.329 + xs, 2.342 + zs);
            grc.AddNodePtxz("osm5159751051", -119.326 + xs, 1.124 + zs);
            grc.AddNodePtxz("osm5159751052", -124.093 + xs, -0.889 + zs);
            grc.AddNodePtxz("osm5159874263", -125.727 + xs, -0.838 + zs);
            grc.AddNodePtxz("osm5159751055", -138.425 + xs, 49.116 + zs);
            grc.AddNodePtxz("osm5159751053", -106.289 + xs, 41.518 + zs);
            grc.AddNodePtxz("osm5159874236", -10.258 + xs, 25.210 + zs);
            grc.AddNodePtxz("osm5159751029", -245.791 + xs, -11.848 + zs);
            grc.AddNodePtxz("osm809807553", -141.521 + xs, 16.228 + zs);
            grc.AddNodePtxz("osm5159887887", -96.639 + xs, 22.159 + zs);
            grc.AddNodePtxz("osm7103240876", -75.575 + xs, 1.439 + zs);
            grc.AddNodePtxz("osm5159751030", -193.992 + xs, 23.581 + zs);
            grc.AddNodePtxz("osm5159887904", -245.634 + xs, -0.229 + zs);
            grc.AddNodePtxz("osm5159887906", 0.476 + xs, 1.453 + zs);
            grc.AddNodePtxz("osm5159874240", -18.403 + xs, 69.015 + zs);
            grc.AddNodePtxz("osm5159887908", -14.341 + xs, 92.498 + zs);
            grc.AddNodePtxz("osm5159751054", -77.940 + xs, 34.256 + zs);
            grc.AddNodePtxz("osm5161698343", -3.980 + xs, 135.169 + zs);
            grc.AddNodePtxz("osm5434210418", -88.466 + xs, 91.298 + zs);
            grc.AddNodePtxz("osm5916951872", -295.271 + xs, -40.067 + zs);
            grc.AddNodePtxz("osm4829304089", -440.634 + xs, -397.457 + zs);
            grc.AddNodePtxz("osm4829304087", -446.564 + xs, -417.500 + zs);
            grc.AddNodePtxz("osm6042865993", -405.851 + xs, -368.067 + zs);
            grc.AddNodePtxz("osm6042866014", -365.154 + xs, -322.116 + zs);
            grc.AddNodePtxz("osm6997506355", -628.142 + xs, -330.226 + zs);
            grc.AddNodePtxz("osm6301563936", 65.415 + xs, -350.076 + zs);
            grc.AddNodePtxz("osm6937998562", 358.554 + xs, -439.185 + zs);
            grc.AddNodePtxz("osm6937998569", 383.479 + xs, -523.403 + zs);
            grc.AddNodePtxz("osm6937998581", 351.518 + xs, -444.651 + zs);
            grc.AddNodePtxz("osm6937999589", 388.994 + xs, -518.108 + zs);
            grc.AddNodePtxz("osm6938241255", 406.155 + xs, -514.871 + zs);
            grc.AddNodePtxz("osm6938485973", 368.777 + xs, -404.926 + zs);
            grc.AddNodePtxz("osm6938485969", 359.077 + xs, -329.905 + zs);
            grc.AddNodePtxz("osm6946122461", 325.227 + xs, -450.982 + zs);
            grc.AddNodePtxz("osm6946122464", 335.385 + xs, -476.457 + zs);
            grc.AddNodePtxz("osm6946122462", 337.032 + xs, -480.915 + zs);
            grc.AddNodePtxz("osm6946122471", 342.208 + xs, -494.954 + zs);
            grc.AddNodePtxz("osm6946122472", 340.568 + xs, -490.518 + zs);
            grc.AddNodePtxz("osm6946122474", 330.822 + xs, -516.929 + zs);
            grc.AddNodePtxz("osm6946131605", -22.944 + xs, -233.392 + zs);
            grc.AddNodePtxz("osm6946131622", -18.139 + xs, -268.590 + zs);
            grc.AddNodePtxz("osm6946491900", 22.475 + xs, -389.301 + zs);
            grc.AddNodePtxz("osm6946491902", 25.418 + xs, -426.252 + zs);
            grc.AddNodePtxz("osm6946491906", -99.152 + xs, -445.562 + zs);
            grc.AddNodePtxz("osm6946491911", -124.381 + xs, -565.288 + zs);
            grc.AddNodePtxz("osm6946491914", -112.295 + xs, -563.590 + zs);
            grc.AddNodePtxz("osm6946491930", -81.568 + xs, -551.447 + zs);
            grc.AddNodePtxz("osm4846459991", -336.319 + xs, -633.099 + zs);
            grc.AddNodePtxz("osm7529076207", -258.055 + xs, -358.090 + zs);
            grc.AddNodePtxz("osm6946122479", 288.151 + xs, -528.622 + zs);
            grc.AddNodePtxz("osm4835343871", 227.461 + xs, -563.356 + zs);
            grc.AddNodePtxz("osm6978384454", 189.775 + xs, -417.815 + zs);
            grc.AddNodePtxz("osm6978384453", 194.803 + xs, -453.078 + zs);
            grc.AddNodePtxz("osm6042866110", 214.163 + xs, -380.553 + zs);
            grc.AddNodePtxz("osm6978384469", 222.260 + xs, -415.115 + zs);
            grc.AddNodePtxz("osm6978397740", 9.990 + xs, -223.971 + zs);
            grc.AddNodePtxz("osm4049735588", -51.251 + xs, -271.386 + zs);
            grc.AddNodePtxz("osm4802542189", -139.989 + xs, -557.054 + zs);
            grc.AddNodePtxz("osm4835357626", 52.605 + xs, -531.195 + zs);
            grc.AddNodePtxz("osm7462172705", -485.558 + xs, -586.132 + zs);
            grc.AddNodePtxz("osm7462172706", -467.852 + xs, -572.315 + zs);
            grc.AddNodePtxz("osm7462172708", -485.959 + xs, -534.543 + zs);
            grc.AddNodePtxz("osm7462172709", -494.115 + xs, -523.005 + zs);
            grc.AddNodePtxz("osm7462172707", -511.897 + xs, -528.974 + zs);
            grc.AddNodePtxz("osm7462172733", -623.002 + xs, -422.437 + zs);
            grc.AddNodePtxz("osm7462172732", -632.966 + xs, -387.398 + zs);
            grc.AddNodePtxz("osm7462172730", -634.258 + xs, -373.028 + zs);
            grc.AddNodePtxz("osm7462172731", -634.294 + xs, -355.550 + zs);
            grc.AddNodePtxz("osm6997506293", -441.855 + xs, -291.206 + zs);
            grc.AddNodePtxz("osm6997506294", -437.788 + xs, -286.930 + zs);
            grc.AddNodePtxz("osm7516983722", -454.408 + xs, -294.664 + zs);
            grc.AddNodePtxz("osm4829350218", -418.419 + xs, -267.332 + zs);
            grc.AddNodePtxz("osm7462172715", -554.378 + xs, -600.931 + zs);
            grc.AddNodePtxz("osm7462172716", -558.876 + xs, -597.829 + zs);
            grc.AddNodePtxz("osm6042865813", -544.071 + xs, -593.695 + zs);
            grc.AddNodePtxz("osm6047614796", -634.820 + xs, -330.896 + zs);
            grc.AddNodePtxz("osm7462172725", -594.373 + xs, -508.936 + zs);
            grc.AddNodePtxz("osm7469351340", -262.714 + xs, -415.531 + zs);
            grc.AddNodePtxz("osm6997611079", -272.406 + xs, -442.866 + zs);
            grc.AddNodePtxz("osm7469351345", -286.268 + xs, -445.251 + zs);
            grc.AddNodePtxz("osm6997611083", -294.371 + xs, -439.510 + zs);
            grc.AddNodePtxz("osm4823517557", -353.160 + xs, -285.137 + zs);
            grc.AddNodePtxz("osm6997611923", -334.758 + xs, -279.890 + zs);
            grc.AddNodePtxz("osm7469351338", -292.417 + xs, -352.419 + zs);
            grc.AddNodePtxz("osm4829350832", -350.892 + xs, -198.604 + zs);
            grc.AddNodePtxz("osm7529076259", -254.532 + xs, -384.427 + zs);
            grc.AddNodePtxz("osm7529076203", -254.294 + xs, -377.105 + zs);
            grc.AddNodePtxz("osm7529076204", -253.120 + xs, -375.610 + zs);
            grc.AddNodePtxz("osm7529076205", -254.004 + xs, -364.791 + zs);
            grc.AddNodePtxz("osm7529076206", -257.009 + xs, -363.657 + zs);
            grc.AddNodePtxz("osm7529076208", -275.837 + xs, -359.694 + zs);
            grc.AddNodePtxz("osm6997724888", -151.356 + xs, -186.068 + zs);
            grc.AddNodePtxz("osm6997724898", -187.082 + xs, -192.912 + zs);
            grc.AddNodePtxz("osm7003048446", -439.329 + xs, -213.037 + zs);
            grc.AddNodePtxz("osm7003048513", -409.142 + xs, -240.725 + zs);
            grc.AddNodePtxz("osm7003167568", -464.638 + xs, -423.109 + zs);
            grc.AddNodePtxz("osm7003167570", -495.934 + xs, -450.236 + zs);
            grc.AddNodePtxz("osm7003167574", -479.993 + xs, -440.398 + zs);
            grc.AddNodePtxz("osm5159949428", -203.835 + xs, 65.807 + zs);
            grc.AddNodePtxz("osm5159949434", -217.187 + xs, 64.959 + zs);
            grc.AddNodePtxz("osm7103240880", -88.584 + xs, 1.532 + zs);
            grc.AddNodePtxz("osm7103248592", -83.976 + xs, -1.009 + zs);
            grc.AddNodePtxz("osm5159751057", -138.547 + xs, 54.302 + zs);
            grc.AddNodePtxz("osm7103240870", -90.231 + xs, 72.498 + zs);
            grc.AddNodePtxz("osm7103327031", -27.779 + xs, 23.402 + zs);
            grc.AddNodePtxz("osm809805785", -186.390 + xs, 25.518 + zs);
            grc.AddNodePtxz("osm7103512090", 181.796 + xs, 54.489 + zs);
            grc.AddNodePtxz("osm7103512102", 242.525 + xs, -27.810 + zs);
            grc.AddNodePtxz("osm7105644009", 110.887 + xs, 170.025 + zs);
            grc.AddNodePtxz("osm5145915624", 169.778 + xs, 184.847 + zs);
            grc.AddNodePtxz("osm5145915629", 241.702 + xs, 169.966 + zs);
            grc.AddNodePtxz("osm5145915625", 222.864 + xs, 193.721 + zs);
            grc.AddNodePtxz("osm7105997679", 299.921 + xs, 154.908 + zs);
            grc.AddNodePtxz("osm7105997698", 274.721 + xs, 124.933 + zs);
            grc.AddNodePtxz("osm4829304104", -457.094 + xs, -313.430 + zs);
            grc.AddNodePtxz("osm4829350830", -354.003 + xs, -258.572 + zs);
            grc.AddNodePtxz("osm4856079659", -568.187 + xs, -369.016 + zs);
            grc.AddNodePtxz("osm7458590570", -500.315 + xs, -420.043 + zs);
            grc.AddNodePtxz("osm7132698259", -501.904 + xs, -691.774 + zs);
            grc.AddNodePtxz("osm4886343269", -441.401 + xs, -681.042 + zs);
            grc.AddNodePtxz("osm3742149263", -32.465 + xs, -531.191 + zs);
            grc.AddNodePtxz("osm6981460230", 44.834 + xs, -531.875 + zs);
            grc.AddNodePtxz("osm4835343869", 168.593 + xs, -557.036 + zs);
            grc.AddNodePtxz("osm4835354486", 159.597 + xs, -522.434 + zs);
            grc.AddNodePtxz("osm415453464", 294.904 + xs, -299.633 + zs);
            grc.AddNodePtxz("osm4829350846", -239.185 + xs, -283.633 + zs);
            grc.AddNodePtxz("osm1488880299", -348.154 + xs, -350.382 + zs);
            grc.AddNodePtxz("osm7529022860", -352.442 + xs, -377.420 + zs);
            grc.AddNodePtxz("osm7529022859", -351.067 + xs, -391.588 + zs);
            grc.AddNodePtxz("osm7529022858", -330.719 + xs, -394.809 + zs);
            grc.AddNodePtxz("osm4892667568", -430.081 + xs, -778.996 + zs);
            grc.AddNodePtxz("osm7137547762", 423.448 + xs, -472.252 + zs);
            grc.AddNodePtxz("osm7137547773", 102.309 + xs, -365.986 + zs);
            grc.AddNodePtxz("osm7137628046", 73.202 + xs, -457.256 + zs);
            grc.AddNodePtxz("osm3742149266", 64.678 + xs, -523.846 + zs);
            grc.AddNodePtxz("osm3742149270", 195.226 + xs, -543.847 + zs);
            grc.AddNodePtxz("osm7137804866", -474.274 + xs, -729.653 + zs);
            grc.AddNodePtxz("osm7137804868", -407.702 + xs, -698.268 + zs);
            grc.AddNodePtxz("osm4846459990", -318.151 + xs, -604.367 + zs);
            grc.AddNodePtxz("osm4886286153", -233.202 + xs, -648.454 + zs);
            grc.AddNodePtxz("osm4846459976", -306.975 + xs, -664.434 + zs);
            grc.AddNodePtxz("osm4846459994", -256.863 + xs, -623.729 + zs);
            grc.AddNodePtxz("osm4856079653", -638.919 + xs, -357.767 + zs);
            grc.AddNodePtxz("osm4856079644", -597.401 + xs, -415.820 + zs);
            grc.AddNodePtxz("osm6042865915", -598.603 + xs, -392.198 + zs);
            grc.AddNodePtxz("osm4829381871", -478.075 + xs, -294.425 + zs);
            grc.AddNodePtxz("osm6997506291", -447.770 + xs, -297.580 + zs);
            grc.AddNodePtxz("osm4829381867", -517.557 + xs, -322.865 + zs);
            grc.AddNodePtxz("osm4829350209", -445.583 + xs, -330.560 + zs);
            grc.AddNodePtxz("osm7152737866", -413.346 + xs, -330.044 + zs);
            grc.AddNodePtxz("osm4829304108", -477.674 + xs, -370.277 + zs);
            grc.AddNodePtxz("osm4829304106", -473.697 + xs, -333.143 + zs);
            grc.AddNodePtxz("osm4829304109", -463.860 + xs, -407.008 + zs);
            grc.AddNodePtxz("osm1491011803", -294.542 + xs, -437.746 + zs);
            grc.AddNodePtxz("osm4823517529", -184.531 + xs, -278.991 + zs);
            grc.AddNodePtxz("osm6997724812", -327.097 + xs, -402.639 + zs);
            grc.AddNodePtxz("osm4856281084", -320.741 + xs, -356.151 + zs);
            grc.AddNodePtxz("osm6997611926", -306.639 + xs, -354.484 + zs);
            grc.AddNodePtxz("osm4856281085", -263.812 + xs, -385.314 + zs);
            grc.AddNodePtxz("osm4818775932", -281.159 + xs, -388.021 + zs);
            grc.AddNodePtxz("osm4835354485", 100.533 + xs, -515.524 + zs);
            grc.AddNodePtxz("osm4835354484", 93.222 + xs, -516.102 + zs);
            grc.AddNodePtxz("osm7287516732", 203.790 + xs, 61.939 + zs);
            grc.AddNodePtxz("osm7287694148", 135.277 + xs, 99.431 + zs);
            grc.AddNodePtxz("osm7287694151", 175.833 + xs, 91.808 + zs);
            grc.AddNodePtxz("osm7287694159", 269.172 + xs, 123.097 + zs);
            grc.AddNodePtxz("osm3934627723", 195.181 + xs, 98.361 + zs);
            grc.AddNodePtxz("osm7105997694", 263.029 + xs, 153.503 + zs);
            grc.AddNodePtxz("osm7287694181", 162.676 + xs, 121.326 + zs);
            grc.AddNodePtxz("osm7105997662", 294.041 + xs, 186.078 + zs);
            grc.AddNodePtxz("osm7287715300", 272.647 + xs, 233.783 + zs);
            grc.AddNodePtxz("osm5145915630", 172.558 + xs, 145.804 + zs);
            grc.AddNodePtxz("osm7287977459", 192.888 + xs, 143.979 + zs);
            grc.AddNodePtxz("osm7287977454", 227.583 + xs, 156.918 + zs);
            grc.AddNodePtxz("osm5161698340", 1.332 + xs, 134.991 + zs);
            grc.AddNodePtxz("osm5159874255", -179.316 + xs, -19.034 + zs);
            grc.AddNodePtxz("osm7291156677", -34.287 + xs, 62.745 + zs);
            grc.AddNodePtxz("osm7291607555", -583.215 + xs, -533.229 + zs);
            grc.AddNodePtxz("osm7458590567", -499.834 + xs, -429.178 + zs);
            grc.AddNodePtxz("osm7462172696", -77.812 + xs, -616.693 + zs);
            grc.AddNodePtxz("osm6981557567", -84.113 + xs, -592.559 + zs);
            grc.AddNodePtxz("osm7462172701", -90.341 + xs, -675.908 + zs);
            grc.AddNodePtxz("osm4442737419", -111.847 + xs, -671.706 + zs);
            grc.AddNodePtxz("osm4818775964", -112.161 + xs, -684.963 + zs);
            grc.AddNodePtxz("osm7462172714", -568.353 + xs, -586.727 + zs);
            grc.AddNodePtxz("osm7462172712", -567.202 + xs, -577.168 + zs);
            grc.AddNodePtxz("osm7462172724", -597.374 + xs, -513.227 + zs);
            grc.AddNodePtxz("osm7462172745", -647.445 + xs, -358.349 + zs);
            grc.AddNodePtxz("osm7462172744", -648.230 + xs, -351.876 + zs);
            grc.AddNodePtxz("osm7462172742", -648.365 + xs, -336.872 + zs);
            grc.AddNodePtxz("osm7543923628", -381.548 + xs, -310.531 + zs);
            grc.AddNodePtxz("osm7543923629", -377.998 + xs, -300.547 + zs);
            grc.AddNodePtxz("osm7543923665", -226.627 + xs, -287.113 + zs);
            grc.AddNodePtxz("osm7547455774", -142.679 + xs, -221.880 + zs);
            grc.AddNodePtxz("osm7547455773", -130.319 + xs, -221.871 + zs);
            grc.AddNodePtxz("osm6997611913", -155.091 + xs, -307.205 + zs);
            grc.AddNodePtxz("osm7549247132", -243.201 + xs, -276.326 + zs);
            grc.AddNodePtxz("osm320996263", -495.709 + xs, -704.046 + zs);
            grc.AddNodePtxz("osm320996264", -500.196 + xs, -691.229 + zs);
            grc.AddNodePtxz("osm320996265", -508.531 + xs, -694.035 + zs);
            grc.AddNodePtxz("osm320996266", -514.976 + xs, -676.010 + zs);
            grc.AddNodePtxz("osm1738823964", -511.008 + xs, -673.535 + zs);
            grc.AddNodePtxz("osm320996267", -512.242 + xs, -670.155 + zs);
            grc.AddNodePtxz("osm320996268", -467.601 + xs, -654.730 + zs);
            grc.AddNodePtxz("osm320996269", -468.374 + xs, -652.428 + zs);
            grc.AddNodePtxz("osm4848246453", -461.054 + xs, -649.922 + zs);
            grc.AddNodePtxz("osm320996270", -458.524 + xs, -658.308 + zs);
            grc.AddNodePtxz("osm4848246452", -456.253 + xs, -657.618 + zs);
            grc.AddNodePtxz("osm4848246447", -456.953 + xs, -655.624 + zs);
            grc.AddNodePtxz("osm4848246451", -459.485 + xs, -648.141 + zs);
            grc.AddNodePtxz("osm4848246455", -449.928 + xs, -644.988 + zs);
            grc.AddNodePtxz("osm4848246454", -450.712 + xs, -642.888 + zs);
            grc.AddNodePtxz("osm320996271", -428.513 + xs, -636.730 + zs);
            grc.AddNodePtxz("osm320996272", -427.033 + xs, -640.945 + zs);
            grc.AddNodePtxz("osm320996273", -411.871 + xs, -635.643 + zs);
            grc.AddNodePtxz("osm320996274", -393.419 + xs, -688.950 + zs);
            grc.AddNodePtxz("osm320996275", -397.161 + xs, -690.120 + zs);
            grc.AddNodePtxz("osm320996276", -395.925 + xs, -694.244 + zs);
            grc.AddNodePtxz("osm320996277", -423.375 + xs, -703.626 + zs);
            grc.AddNodePtxz("osm4848246446", -430.384 + xs, -691.624 + zs);
            grc.AddNodePtxz("osm320996278", -436.387 + xs, -679.397 + zs);
            grc.AddNodePtxz("osm320996279", -445.715 + xs, -682.432 + zs);
            grc.AddNodePtxz("osm320996280", -444.226 + xs, -686.873 + zs);
            grc.AddNodePtxz("osm320996300", -319.140 + xs, -668.528 + zs);
            grc.AddNodePtxz("osm320996301", -320.428 + xs, -664.422 + zs);
            grc.AddNodePtxz("osm320996302", -325.170 + xs, -665.902 + zs);
            grc.AddNodePtxz("osm320996303", -342.980 + xs, -613.350 + zs);
            grc.AddNodePtxz("osm3735501418", -334.506 + xs, -610.401 + zs);
            grc.AddNodePtxz("osm320996306", -309.136 + xs, -601.043 + zs);
            grc.AddNodePtxz("osm4846459992", -298.654 + xs, -597.130 + zs);
            grc.AddNodePtxz("osm4846459993", -299.679 + xs, -594.074 + zs);
            grc.AddNodePtxz("osm4846459986", -297.779 + xs, -593.337 + zs);
            grc.AddNodePtxz("osm4846459989", -296.727 + xs, -596.470 + zs);
            grc.AddNodePtxz("osm4846459983", -296.425 + xs, -597.396 + zs);
            grc.AddNodePtxz("osm4846459982", -295.179 + xs, -596.946 + zs);
            grc.AddNodePtxz("osm4846459981", -296.216 + xs, -593.824 + zs);
            grc.AddNodePtxz("osm320996307", -288.528 + xs, -591.294 + zs);
            grc.AddNodePtxz("osm320996308", -287.854 + xs, -593.012 + zs);
            grc.AddNodePtxz("osm320996309", -242.707 + xs, -578.729 + zs);
            grc.AddNodePtxz("osm320996310", -241.478 + xs, -582.095 + zs);
            grc.AddNodePtxz("osm320996311", -236.810 + xs, -581.344 + zs);
            grc.AddNodePtxz("osm320996312", -230.171 + xs, -600.427 + zs);
            grc.AddNodePtxz("osm320996313", -239.274 + xs, -603.496 + zs);
            grc.AddNodePtxz("osm320996315", -234.663 + xs, -616.128 + zs);
            grc.AddNodePtxz("osm320996316", -285.997 + xs, -633.489 + zs);
            grc.AddNodePtxz("osm320996317", -287.644 + xs, -628.967 + zs);
            grc.AddNodePtxz("osm320996318", -297.039 + xs, -632.112 + zs);
            grc.AddNodePtxz("osm320996319", -292.269 + xs, -659.479 + zs);
            grc.AddNodePtxz("osm321153936", 354.801 + xs, -412.396 + zs);
            grc.AddNodePtxz("osm4809166497", 335.698 + xs, -358.512 + zs);
            grc.AddNodePtxz("osm4809166496", 332.141 + xs, -359.738 + zs);
            grc.AddNodePtxz("osm4809166495", 330.538 + xs, -355.138 + zs);
            grc.AddNodePtxz("osm4809166494", 334.444 + xs, -353.832 + zs);
            grc.AddNodePtxz("osm415453460", 332.619 + xs, -348.532 + zs);
            grc.AddNodePtxz("osm321153937", 324.743 + xs, -351.165 + zs);
            grc.AddNodePtxz("osm415453462", 291.156 + xs, -324.110 + zs);
            grc.AddNodePtxz("osm415453463", 293.971 + xs, -320.635 + zs);
            grc.AddNodePtxz("osm321153938", 284.144 + xs, -312.735 + zs);
            grc.AddNodePtxz("osm4809166508", 290.802 + xs, -304.515 + zs);
            grc.AddNodePtxz("osm4809166510", 285.605 + xs, -300.329 + zs);
            grc.AddNodePtxz("osm4809166511", 288.862 + xs, -296.299 + zs);
            grc.AddNodePtxz("osm4809166509", 294.165 + xs, -300.551 + zs);
            grc.AddNodePtxz("osm4809166507", 295.667 + xs, -298.714 + zs);
            grc.AddNodePtxz("osm4809166506", 293.398 + xs, -296.853 + zs);
            grc.AddNodePtxz("osm321153939", 302.986 + xs, -285.048 + zs);
            grc.AddNodePtxz("osm4809166503", 360.750 + xs, -331.241 + zs);
            grc.AddNodePtxz("osm4809166504", 362.681 + xs, -328.845 + zs);
            grc.AddNodePtxz("osm4809166505", 367.057 + xs, -332.338 + zs);
            grc.AddNodePtxz("osm4809166502", 365.002 + xs, -334.887 + zs);
            grc.AddNodePtxz("osm321153940", 368.247 + xs, -337.475 + zs);
            grc.AddNodePtxz("osm415453465", 385.530 + xs, -386.208 + zs);
            grc.AddNodePtxz("osm415453466", 380.922 + xs, -387.801 + zs);
            grc.AddNodePtxz("osm321153941", 385.196 + xs, -399.844 + zs);
            grc.AddNodePtxz("osm4809166501", 374.664 + xs, -403.481 + zs);
            grc.AddNodePtxz("osm4809166500", 376.646 + xs, -409.060 + zs);
            grc.AddNodePtxz("osm4809166499", 372.044 + xs, -410.636 + zs);
            grc.AddNodePtxz("osm4809166498", 369.920 + xs, -404.551 + zs);
            grc.AddNodePtxz("osm6938485971", 367.867 + xs, -405.222 + zs);
            grc.AddNodePtxz("osm6938485970", 368.664 + xs, -407.595 + zs);
            grc.AddNodePtxz("osm321154350", -13.017 + xs, -514.370 + zs);
            grc.AddNodePtxz("osm321154351", -12.084 + xs, -524.222 + zs);
            grc.AddNodePtxz("osm4835357625", -14.222 + xs, -524.415 + zs);
            grc.AddNodePtxz("osm321154352", -32.956 + xs, -526.060 + zs);
            grc.AddNodePtxz("osm321154353", -30.806 + xs, -548.787 + zs);
            grc.AddNodePtxz("osm1704771656", 12.511 + xs, -544.984 + zs);
            grc.AddNodePtxz("osm1704771644", 12.377 + xs, -543.596 + zs);
            grc.AddNodePtxz("osm1704771520", 22.447 + xs, -542.708 + zs);
            grc.AddNodePtxz("osm1704771542", 22.584 + xs, -544.142 + zs);
            grc.AddNodePtxz("osm321154354", 44.489 + xs, -542.219 + zs);
            grc.AddNodePtxz("osm321154355", 43.518 + xs, -531.993 + zs);
            grc.AddNodePtxz("osm321154356", 65.263 + xs, -530.085 + zs);
            grc.AddNodePtxz("osm321154357", 63.161 + xs, -507.730 + zs);
            grc.AddNodePtxz("osm1704771464", 19.514 + xs, -511.567 + zs);
            grc.AddNodePtxz("osm1704771503", 19.599 + xs, -512.448 + zs);
            grc.AddNodePtxz("osm1704771636", 9.643 + xs, -513.322 + zs);
            grc.AddNodePtxz("osm1704771631", 9.551 + xs, -512.387 + zs);
            grc.AddNodePtxz("osm321154489", 100.807 + xs, -504.910 + zs);
            grc.AddNodePtxz("osm321154490", 101.715 + xs, -515.428 + zs);
            grc.AddNodePtxz("osm321154492", 80.633 + xs, -517.108 + zs);
            grc.AddNodePtxz("osm321154493", 82.526 + xs, -539.036 + zs);
            grc.AddNodePtxz("osm321154494", 158.170 + xs, -533.022 + zs);
            grc.AddNodePtxz("osm321154495", 157.278 + xs, -522.618 + zs);
            grc.AddNodePtxz("osm321154496", 178.362 + xs, -520.945 + zs);
            grc.AddNodePtxz("osm321154497", 176.474 + xs, -498.897 + zs);
            grc.AddNodePtxz("osm321154627", 127.768 + xs, -560.208 + zs);
            grc.AddNodePtxz("osm321154628", 135.478 + xs, -580.896 + zs);
            grc.AddNodePtxz("osm321154630", 118.885 + xs, -598.388 + zs);
            grc.AddNodePtxz("osm1704768475", 98.100 + xs, -605.955 + zs);
            grc.AddNodePtxz("osm1704768497", 97.771 + xs, -605.085 + zs);
            grc.AddNodePtxz("osm1704769926", 88.492 + xs, -608.460 + zs);
            grc.AddNodePtxz("osm1704769212", 88.801 + xs, -609.273 + zs);
            grc.AddNodePtxz("osm321154631", 47.827 + xs, -624.187 + zs);
            grc.AddNodePtxz("osm321154632", 40.173 + xs, -603.962 + zs);
            grc.AddNodePtxz("osm321154634", 60.459 + xs, -596.352 + zs);
            grc.AddNodePtxz("osm321154635", 56.792 + xs, -586.209 + zs);
            grc.AddNodePtxz("osm1704770015", 77.232 + xs, -578.768 + zs);
            grc.AddNodePtxz("osm1704769994", 77.530 + xs, -580.155 + zs);
            grc.AddNodePtxz("osm1704768504", 87.114 + xs, -576.874 + zs);
            grc.AddNodePtxz("osm1704768516", 86.578 + xs, -575.719 + zs);
            grc.AddNodePtxz("osm321154995", 148.639 + xs, -558.299 + zs);
            grc.AddNodePtxz("osm321154996", 150.333 + xs, -580.231 + zs);
            grc.AddNodePtxz("osm321154997", 225.461 + xs, -573.689 + zs);
            grc.AddNodePtxz("osm321154998", 224.771 + xs, -563.524 + zs);
            grc.AddNodePtxz("osm321155000", 245.489 + xs, -562.254 + zs);
            grc.AddNodePtxz("osm321155001", 244.338 + xs, -540.389 + zs);
            grc.AddNodePtxz("osm321155002", 168.929 + xs, -546.029 + zs);
            grc.AddNodePtxz("osm321155003", 169.989 + xs, -556.946 + zs);
            grc.AddNodePtxz("osm321549713", 184.163 + xs, -365.095 + zs);
            grc.AddNodePtxz("osm6042866082", 187.533 + xs, -412.942 + zs);
            grc.AddNodePtxz("osm6042866084", 189.460 + xs, -412.853 + zs);
            grc.AddNodePtxz("osm6042866083", 190.063 + xs, -422.366 + zs);
            grc.AddNodePtxz("osm6042866081", 188.221 + xs, -422.498 + zs);
            grc.AddNodePtxz("osm321549714", 190.291 + xs, -452.223 + zs);
            grc.AddNodePtxz("osm6042866086", 194.720 + xs, -451.934 + zs);
            grc.AddNodePtxz("osm6042866088", 194.833 + xs, -453.567 + zs);
            grc.AddNodePtxz("osm6042866087", 192.310 + xs, -453.671 + zs);
            grc.AddNodePtxz("osm6042866085", 193.249 + xs, -459.876 + zs);
            grc.AddNodePtxz("osm321549716", 196.034 + xs, -467.811 + zs);
            grc.AddNodePtxz("osm321549717", 199.441 + xs, -473.045 + zs);
            grc.AddNodePtxz("osm6042866089", 199.939 + xs, -472.684 + zs);
            grc.AddNodePtxz("osm6042866090", 197.731 + xs, -469.218 + zs);
            grc.AddNodePtxz("osm6042866091", 202.209 + xs, -469.000 + zs);
            grc.AddNodePtxz("osm6042866092", 202.316 + xs, -469.811 + zs);
            grc.AddNodePtxz("osm321549718", 224.767 + xs, -468.232 + zs);
            grc.AddNodePtxz("osm6042866093", 221.675 + xs, -423.331 + zs);
            grc.AddNodePtxz("osm6042866094", 222.400 + xs, -418.203 + zs);
            grc.AddNodePtxz("osm6042866095", 222.212 + xs, -413.903 + zs);
            grc.AddNodePtxz("osm6042866096", 221.869 + xs, -409.600 + zs);
            grc.AddNodePtxz("osm6042866097", 221.098 + xs, -405.420 + zs);
            grc.AddNodePtxz("osm6042866098", 220.185 + xs, -402.683 + zs);
            grc.AddNodePtxz("osm6042866099", 218.756 + xs, -380.834 + zs);
            grc.AddNodePtxz("osm6042866100", 214.191 + xs, -381.106 + zs);
            grc.AddNodePtxz("osm6042866101", 214.121 + xs, -379.696 + zs);
            grc.AddNodePtxz("osm6042866102", 216.377 + xs, -379.502 + zs);
            grc.AddNodePtxz("osm6042866103", 215.701 + xs, -374.553 + zs);
            grc.AddNodePtxz("osm6042866104", 214.344 + xs, -369.576 + zs);
            grc.AddNodePtxz("osm6042866105", 212.153 + xs, -364.107 + zs);
            grc.AddNodePtxz("osm321549721", 209.961 + xs, -360.350 + zs);
            grc.AddNodePtxz("osm6042866106", 209.274 + xs, -360.744 + zs);
            grc.AddNodePtxz("osm6042866107", 211.326 + xs, -364.272 + zs);
            grc.AddNodePtxz("osm6042866108", 206.813 + xs, -364.454 + zs);
            grc.AddNodePtxz("osm321549723", 206.612 + xs, -363.176 + zs);
            grc.AddNodePtxz("osm321549938", 238.867 + xs, -339.420 + zs);
            grc.AddNodePtxz("osm6306189085", 235.886 + xs, -294.901 + zs);
            grc.AddNodePtxz("osm321549939", 235.890 + xs, -294.812 + zs);
            grc.AddNodePtxz("osm6333359145", 235.186 + xs, -294.855 + zs);
            grc.AddNodePtxz("osm6981461728", 234.343 + xs, -294.907 + zs);
            grc.AddNodePtxz("osm6306188979", 213.698 + xs, -296.152 + zs);
            grc.AddNodePtxz("osm6306188978", 209.126 + xs, -296.434 + zs);
            grc.AddNodePtxz("osm321549940", 193.358 + xs, -297.491 + zs);
            grc.AddNodePtxz("osm321549941", 192.556 + xs, -286.668 + zs);
            grc.AddNodePtxz("osm321549942", 168.585 + xs, -288.284 + zs);
            grc.AddNodePtxz("osm6306188976", 170.674 + xs, -316.719 + zs);
            grc.AddNodePtxz("osm6935972834", 172.395 + xs, -342.627 + zs);
            grc.AddNodePtxz("osm321549943", 172.453 + xs, -343.431 + zs);
            grc.AddNodePtxz("osm6306189090", 101.800 + xs, -360.402 + zs);
            grc.AddNodePtxz("osm6306189091", 105.569 + xs, -402.125 + zs);
            grc.AddNodePtxz("osm6306189093", 107.822 + xs, -429.482 + zs);
            grc.AddNodePtxz("osm321549980", 109.890 + xs, -454.463 + zs);
            grc.AddNodePtxz("osm6306189094", 82.463 + xs, -456.549 + zs);
            grc.AddNodePtxz("osm6306189102", 64.183 + xs, -457.943 + zs);
            grc.AddNodePtxz("osm321549981", 28.161 + xs, -460.682 + zs);
            grc.AddNodePtxz("osm321549982", 19.631 + xs, -353.639 + zs);
            grc.AddNodePtxz("osm6301563926", 44.741 + xs, -351.775 + zs);
            grc.AddNodePtxz("osm6301563925", 63.351 + xs, -350.244 + zs);
            grc.AddNodePtxz("osm6301563922", 88.371 + xs, -348.190 + zs);
            grc.AddNodePtxz("osm6323277624", 95.856 + xs, -347.735 + zs);
            grc.AddNodePtxz("osm6323277625", 100.675 + xs, -347.147 + zs);
            grc.AddNodePtxz("osm321549985", -201.272 + xs, -148.151 + zs);
            grc.AddNodePtxz("osm6997724886", -201.995 + xs, -145.990 + zs);
            grc.AddNodePtxz("osm7464275809", -183.960 + xs, -140.473 + zs);
            grc.AddNodePtxz("osm321549986", -183.523 + xs, -140.339 + zs);
            grc.AddNodePtxz("osm7464276236", -181.331 + xs, -146.013 + zs);
            grc.AddNodePtxz("osm321549987", -180.752 + xs, -147.526 + zs);
            grc.AddNodePtxz("osm321549988", -172.148 + xs, -147.773 + zs);
            grc.AddNodePtxz("osm321549989", -161.762 + xs, -178.136 + zs);
            grc.AddNodePtxz("osm7464276232", -160.397 + xs, -178.192 + zs);
            grc.AddNodePtxz("osm321549990", -153.849 + xs, -178.462 + zs);
            grc.AddNodePtxz("osm7464276229", -150.345 + xs, -189.152 + zs);
            grc.AddNodePtxz("osm321549991", -149.896 + xs, -190.464 + zs);
            grc.AddNodePtxz("osm321549992", -122.753 + xs, -191.097 + zs);
            grc.AddNodePtxz("osm321549993", -120.291 + xs, -197.740 + zs);
            grc.AddNodePtxz("osm321549994", -112.635 + xs, -198.010 + zs);
            grc.AddNodePtxz("osm7464275805", -112.708 + xs, -217.125 + zs);
            grc.AddNodePtxz("osm7464275806", -114.618 + xs, -217.129 + zs);
            grc.AddNodePtxz("osm321549995", -112.782 + xs, -221.856 + zs);
            grc.AddNodePtxz("osm7547455775", -129.529 + xs, -221.870 + zs);
            grc.AddNodePtxz("osm7547455778", -131.321 + xs, -221.873 + zs);
            grc.AddNodePtxz("osm7547455780", -141.311 + xs, -221.879 + zs);
            grc.AddNodePtxz("osm7547455782", -143.681 + xs, -221.883 + zs);
            grc.AddNodePtxz("osm7547455783", -165.463 + xs, -221.902 + zs);
            grc.AddNodePtxz("osm321549996", -175.756 + xs, -221.583 + zs);
            grc.AddNodePtxz("osm321549997", -177.161 + xs, -216.606 + zs);
            grc.AddNodePtxz("osm321549998", -183.103 + xs, -215.876 + zs);
            grc.AddNodePtxz("osm6997724882", -189.673 + xs, -197.261 + zs);
            grc.AddNodePtxz("osm6997724884", -185.929 + xs, -196.264 + zs);
            grc.AddNodePtxz("osm6997724885", -187.962 + xs, -189.902 + zs);
            grc.AddNodePtxz("osm6997724883", -192.026 + xs, -190.018 + zs);
            grc.AddNodePtxz("osm7464275808", -205.148 + xs, -152.535 + zs);
            grc.AddNodePtxz("osm6997724887", -206.215 + xs, -148.052 + zs);
            grc.AddNodePtxz("osm321709206", -149.046 + xs, -306.648 + zs);
            grc.AddNodePtxz("osm7463724241", -150.872 + xs, -285.584 + zs);
            grc.AddNodePtxz("osm321709207", -151.140 + xs, -281.660 + zs);
            grc.AddNodePtxz("osm321709208", -181.455 + xs, -283.182 + zs);
            grc.AddNodePtxz("osm321709209", -181.886 + xs, -278.696 + zs);
            grc.AddNodePtxz("osm7543923679", -184.075 + xs, -278.946 + zs);
            grc.AddNodePtxz("osm7543938895", -185.053 + xs, -279.051 + zs);
            grc.AddNodePtxz("osm321709210", -192.597 + xs, -279.907 + zs);
            grc.AddNodePtxz("osm321709211", -192.263 + xs, -284.490 + zs);
            grc.AddNodePtxz("osm7543923681", -214.300 + xs, -285.966 + zs);
            grc.AddNodePtxz("osm7463724228", -214.622 + xs, -285.990 + zs);
            grc.AddNodePtxz("osm321709212", -238.335 + xs, -288.206 + zs);
            grc.AddNodePtxz("osm321709213", -238.021 + xs, -286.411 + zs);
            grc.AddNodePtxz("osm321709214", -241.895 + xs, -276.957 + zs);
            grc.AddNodePtxz("osm7463723826", -270.681 + xs, -264.014 + zs);
            grc.AddNodePtxz("osm321709215", -273.733 + xs, -262.746 + zs);
            grc.AddNodePtxz("osm7463723799", -309.974 + xs, -272.927 + zs);
            grc.AddNodePtxz("osm7463723794", -340.396 + xs, -281.472 + zs);
            grc.AddNodePtxz("osm7463723790", -346.097 + xs, -283.075 + zs);
            grc.AddNodePtxz("osm7463723697", -359.735 + xs, -287.174 + zs);
            grc.AddNodePtxz("osm321709216", -376.713 + xs, -292.479 + zs);
            grc.AddNodePtxz("osm7463723696", -377.869 + xs, -299.505 + zs);
            grc.AddNodePtxz("osm7463697782", -378.131 + xs, -301.480 + zs);
            grc.AddNodePtxz("osm7463697777", -378.737 + xs, -305.434 + zs);
            grc.AddNodePtxz("osm7463697776", -382.010 + xs, -305.620 + zs);
            grc.AddNodePtxz("osm321709217", -381.070 + xs, -315.659 + zs);
            grc.AddNodePtxz("osm7463697772", -378.048 + xs, -315.361 + zs);
            grc.AddNodePtxz("osm321709218", -375.762 + xs, -322.880 + zs);
            grc.AddNodePtxz("osm7463697771", -366.529 + xs, -322.231 + zs);
            grc.AddNodePtxz("osm7463723840", -345.686 + xs, -320.545 + zs);
            grc.AddNodePtxz("osm321709219", -322.296 + xs, -318.922 + zs);
            grc.AddNodePtxz("osm321709220", -322.457 + xs, -317.084 + zs);
            grc.AddNodePtxz("osm4823517543", -320.788 + xs, -316.932 + zs);
            grc.AddNodePtxz("osm7463723841", -320.353 + xs, -324.657 + zs);
            grc.AddNodePtxz("osm4823517542", -320.057 + xs, -327.954 + zs);
            grc.AddNodePtxz("osm7463723845", -318.538 + xs, -327.878 + zs);
            grc.AddNodePtxz("osm4823517541", -313.500 + xs, -327.745 + zs);
            grc.AddNodePtxz("osm7463723849", -313.737 + xs, -324.888 + zs);
            grc.AddNodePtxz("osm321709221", -314.018 + xs, -321.902 + zs);
            grc.AddNodePtxz("osm4823592289", -308.475 + xs, -321.494 + zs);
            grc.AddNodePtxz("osm4823592288", -307.329 + xs, -335.075 + zs);
            grc.AddNodePtxz("osm1488907738", -294.011 + xs, -334.167 + zs);
            grc.AddNodePtxz("osm4823592287", -294.967 + xs, -320.957 + zs);
            grc.AddNodePtxz("osm321709223", -229.909 + xs, -315.874 + zs);
            grc.AddNodePtxz("osm321709224", -230.092 + xs, -312.832 + zs);
            grc.AddNodePtxz("osm321709225", -204.246 + xs, -311.247 + zs);
            grc.AddNodePtxz("osm321709226", -202.680 + xs, -331.236 + zs);
            grc.AddNodePtxz("osm321709227", -177.730 + xs, -329.253 + zs);
            grc.AddNodePtxz("osm321709228", -178.985 + xs, -309.578 + zs);
            grc.AddNodePtxz("osm352544034", 235.283 + xs, -65.927 + zs);
            grc.AddNodePtxz("osm352544050", 229.329 + xs, -47.283 + zs);
            grc.AddNodePtxz("osm352544061", 237.915 + xs, -29.396 + zs);
            grc.AddNodePtxz("osm352544073", 254.243 + xs, -23.450 + zs);
            grc.AddNodePtxz("osm352544088", 257.302 + xs, -16.707 + zs);
            grc.AddNodePtxz("osm352544099", 263.623 + xs, -14.717 + zs);
            grc.AddNodePtxz("osm352544113", 277.456 + xs, -21.190 + zs);
            grc.AddNodePtxz("osm352544123", 279.695 + xs, -27.601 + zs);
            grc.AddNodePtxz("osm352544133", 260.242 + xs, -66.049 + zs);
            grc.AddNodePtxz("osm352544141", 247.749 + xs, -71.830 + zs);
            grc.AddNodePtxz("osm409460143", 176.382 + xs, 52.604 + zs);
            grc.AddNodePtxz("osm4017339897", 174.582 + xs, 57.801 + zs);
            grc.AddNodePtxz("osm4017339896", 168.817 + xs, 55.741 + zs);
            grc.AddNodePtxz("osm409460145", 160.198 + xs, 80.832 + zs);
            grc.AddNodePtxz("osm4017339895", 165.986 + xs, 82.861 + zs);
            grc.AddNodePtxz("osm4017339894", 164.269 + xs, 87.818 + zs);
            grc.AddNodePtxz("osm409460149", 280.899 + xs, 127.096 + zs);
            grc.AddNodePtxz("osm4017339898", 282.659 + xs, 121.845 + zs);
            grc.AddNodePtxz("osm4017339899", 288.469 + xs, 123.778 + zs);
            grc.AddNodePtxz("osm4017339901", 289.294 + xs, 117.898 + zs);
            grc.AddNodePtxz("osm4017339900", 298.840 + xs, 95.778 + zs);
            grc.AddNodePtxz("osm409460152", 298.957 + xs, 93.497 + zs);
            grc.AddNodePtxz("osm7287715305", 129.789 + xs, 101.322 + zs);
            grc.AddNodePtxz("osm7287715304", 107.517 + xs, 166.384 + zs);
            grc.AddNodePtxz("osm409460161", 108.565 + xs, 169.246 + zs);
            grc.AddNodePtxz("osm7105994662", 111.750 + xs, 170.321 + zs);
            grc.AddNodePtxz("osm7105994663", 111.998 + xs, 172.069 + zs);
            grc.AddNodePtxz("osm409460164", 118.003 + xs, 174.220 + zs);
            grc.AddNodePtxz("osm7105994664", 122.043 + xs, 171.650 + zs);
            grc.AddNodePtxz("osm7105994665", 125.631 + xs, 172.855 + zs);
            grc.AddNodePtxz("osm409460166", 131.083 + xs, 156.819 + zs);
            grc.AddNodePtxz("osm409460169", 146.433 + xs, 162.121 + zs);
            grc.AddNodePtxz("osm409460171", 138.196 + xs, 186.060 + zs);
            grc.AddNodePtxz("osm7105994666", 141.774 + xs, 187.293 + zs);
            grc.AddNodePtxz("osm7105994667", 143.484 + xs, 191.664 + zs);
            grc.AddNodePtxz("osm7105994668", 149.318 + xs, 193.662 + zs);
            grc.AddNodePtxz("osm7105994669", 153.094 + xs, 191.105 + zs);
            grc.AddNodePtxz("osm409460174", 156.727 + xs, 192.317 + zs);
            grc.AddNodePtxz("osm7287977465", 165.857 + xs, 165.499 + zs);
            grc.AddNodePtxz("osm7105994654", 169.642 + xs, 154.414 + zs);
            grc.AddNodePtxz("osm416132267", 178.931 + xs, 127.010 + zs);
            grc.AddNodePtxz("osm409460176", 175.507 + xs, 125.774 + zs);
            grc.AddNodePtxz("osm7105994655", 174.261 + xs, 121.561 + zs);
            grc.AddNodePtxz("osm409460179", 167.653 + xs, 119.347 + zs);
            grc.AddNodePtxz("osm7105994656", 164.697 + xs, 120.577 + zs);
            grc.AddNodePtxz("osm7105994657", 164.214 + xs, 121.885 + zs);
            grc.AddNodePtxz("osm7105994658", 160.626 + xs, 120.648 + zs);
            grc.AddNodePtxz("osm409460180", 157.943 + xs, 128.491 + zs);
            grc.AddNodePtxz("osm409460181", 142.643 + xs, 123.348 + zs);
            grc.AddNodePtxz("osm409460182", 148.234 + xs, 107.589 + zs);
            grc.AddNodePtxz("osm7105994659", 144.774 + xs, 106.421 + zs);
            grc.AddNodePtxz("osm7105994660", 143.422 + xs, 102.274 + zs);
            grc.AddNodePtxz("osm7287977517", 134.585 + xs, 99.186 + zs);
            grc.AddNodePtxz("osm7287715306", 133.653 + xs, 98.851 + zs);
            grc.AddNodePtxz("osm416132288", 248.397 + xs, 149.951 + zs);
            grc.AddNodePtxz("osm7287952120", 233.082 + xs, 195.262 + zs);
            grc.AddNodePtxz("osm416132290", 228.825 + xs, 207.422 + zs);
            grc.AddNodePtxz("osm7287694176", 232.369 + xs, 208.619 + zs);
            grc.AddNodePtxz("osm7287694168", 233.329 + xs, 212.774 + zs);
            grc.AddNodePtxz("osm7287694167", 240.747 + xs, 215.369 + zs);
            grc.AddNodePtxz("osm7287694175", 243.600 + xs, 212.314 + zs);
            grc.AddNodePtxz("osm416132291", 247.106 + xs, 213.419 + zs);
            grc.AddNodePtxz("osm416132292", 252.482 + xs, 197.666 + zs);
            grc.AddNodePtxz("osm416132293", 267.868 + xs, 202.799 + zs);
            grc.AddNodePtxz("osm416132294", 259.591 + xs, 226.581 + zs);
            grc.AddNodePtxz("osm7287694174", 263.232 + xs, 227.804 + zs);
            grc.AddNodePtxz("osm7287694166", 263.621 + xs, 231.771 + zs);
            grc.AddNodePtxz("osm7287694165", 271.001 + xs, 234.170 + zs);
            grc.AddNodePtxz("osm416132295", 278.230 + xs, 232.463 + zs);
            grc.AddNodePtxz("osm7287694164", 303.219 + xs, 159.594 + zs);
            grc.AddNodePtxz("osm416132296", 301.788 + xs, 155.603 + zs);
            grc.AddNodePtxz("osm7287694163", 291.867 + xs, 152.143 + zs);
            grc.AddNodePtxz("osm7287694162", 288.199 + xs, 154.626 + zs);
            grc.AddNodePtxz("osm416132297", 284.895 + xs, 153.519 + zs);
            grc.AddNodePtxz("osm416132298", 279.461 + xs, 169.236 + zs);
            grc.AddNodePtxz("osm416132299", 264.144 + xs, 164.072 + zs);
            grc.AddNodePtxz("osm416132300", 266.765 + xs, 156.303 + zs);
            grc.AddNodePtxz("osm7287694173", 263.553 + xs, 155.203 + zs);
            grc.AddNodePtxz("osm7287694172", 262.191 + xs, 150.983 + zs);
            grc.AddNodePtxz("osm7287694171", 255.462 + xs, 148.711 + zs);
            grc.AddNodePtxz("osm7287694170", 252.090 + xs, 151.160 + zs);
            grc.AddNodePtxz("osm7105997612", 172.205 + xs, 183.610 + zs);
            grc.AddNodePtxz("osm7287715312", 170.401 + xs, 183.072 + zs);
            grc.AddNodePtxz("osm7287715313", 169.246 + xs, 186.463 + zs);
            grc.AddNodePtxz("osm7287715314", 167.192 + xs, 185.760 + zs);
            grc.AddNodePtxz("osm7287977424", 166.862 + xs, 186.700 + zs);
            grc.AddNodePtxz("osm7287977425", 164.139 + xs, 194.593 + zs);
            grc.AddNodePtxz("osm416133861", 163.100 + xs, 197.619 + zs);
            grc.AddNodePtxz("osm7287715322", 182.797 + xs, 204.655 + zs);
            grc.AddNodePtxz("osm7287715321", 182.996 + xs, 204.122 + zs);
            grc.AddNodePtxz("osm7287715320", 185.504 + xs, 204.941 + zs);
            grc.AddNodePtxz("osm7287715319", 185.076 + xs, 206.196 + zs);
            grc.AddNodePtxz("osm7287715318", 194.870 + xs, 209.549 + zs);
            grc.AddNodePtxz("osm7287715317", 195.292 + xs, 208.513 + zs);
            grc.AddNodePtxz("osm7287715316", 202.816 + xs, 211.010 + zs);
            grc.AddNodePtxz("osm7287715315", 202.469 + xs, 211.897 + zs);
            grc.AddNodePtxz("osm416133862", 215.682 + xs, 216.365 + zs);
            grc.AddNodePtxz("osm7287977438", 219.886 + xs, 204.322 + zs);
            grc.AddNodePtxz("osm7287977439", 222.698 + xs, 196.278 + zs);
            grc.AddNodePtxz("osm7287715326", 223.003 + xs, 195.408 + zs);
            grc.AddNodePtxz("osm7287715325", 222.332 + xs, 195.202 + zs);
            grc.AddNodePtxz("osm7287715324", 223.512 + xs, 191.907 + zs);
            grc.AddNodePtxz("osm7287715323", 221.761 + xs, 191.284 + zs);
            grc.AddNodePtxz("osm416133859", 223.751 + xs, 185.549 + zs);
            grc.AddNodePtxz("osm7287977537", 221.115 + xs, 184.654 + zs);
            grc.AddNodePtxz("osm7287977574", 203.607 + xs, 178.708 + zs);
            grc.AddNodePtxz("osm7287715307", 177.025 + xs, 169.679 + zs);
            grc.AddNodePtxz("osm809773219", -27.871 + xs, 30.183 + zs);
            grc.AddNodePtxz("osm809773223", -27.712 + xs, 13.666 + zs);
            grc.AddNodePtxz("osm809773225", -40.217 + xs, 13.868 + zs);
            grc.AddNodePtxz("osm809773227", -40.256 + xs, 1.411 + zs);
            grc.AddNodePtxz("osm809773255", -82.446 + xs, 1.487 + zs);
            grc.AddNodePtxz("osm809773259", -82.504 + xs, -1.068 + zs);
            grc.AddNodePtxz("osm809793930", -88.533 + xs, -1.033 + zs);
            grc.AddNodePtxz("osm809793936", -119.332 + xs, -1.009 + zs);
            grc.AddNodePtxz("osm809793937", -148.897 + xs, -0.904 + zs);
            grc.AddNodePtxz("osm809773281", -148.887 + xs, -18.241 + zs);
            grc.AddNodePtxz("osm809773286", -74.870 + xs, -18.448 + zs);
            grc.AddNodePtxz("osm809773295", -74.908 + xs, -20.861 + zs);
            grc.AddNodePtxz("osm809773298", -10.742 + xs, -21.034 + zs);
            grc.AddNodePtxz("osm809773300", -10.755 + xs, -15.383 + zs);
            grc.AddNodePtxz("osm809773303", -5.448 + xs, -15.546 + zs);
            grc.AddNodePtxz("osm809773305", -5.347 + xs, -6.157 + zs);
            grc.AddNodePtxz("osm809773310", 7.081 + xs, -6.172 + zs);
            grc.AddNodePtxz("osm809773316", 7.103 + xs, -24.114 + zs);
            grc.AddNodePtxz("osm809773323", 10.850 + xs, -24.170 + zs);
            grc.AddNodePtxz("osm809773326", 10.812 + xs, -26.615 + zs);
            grc.AddNodePtxz("osm809773329", 13.414 + xs, -26.635 + zs);
            grc.AddNodePtxz("osm809773332", 13.313 + xs, -29.236 + zs);
            grc.AddNodePtxz("osm809773335", 23.401 + xs, -29.442 + zs);
            grc.AddNodePtxz("osm809773345", 23.463 + xs, -26.830 + zs);
            grc.AddNodePtxz("osm809773350", 25.621 + xs, -26.860 + zs);
            grc.AddNodePtxz("osm809773354", 25.560 + xs, -31.761 + zs);
            grc.AddNodePtxz("osm809773358", 30.026 + xs, -31.848 + zs);
            grc.AddNodePtxz("osm809773359", 29.828 + xs, -15.455 + zs);
            grc.AddNodePtxz("osm809773362", 42.088 + xs, -15.361 + zs);
            grc.AddNodePtxz("osm809773364", 42.015 + xs, -3.021 + zs);
            grc.AddNodePtxz("osm809773368", 84.312 + xs, -2.934 + zs);
            grc.AddNodePtxz("osm809773371", 84.210 + xs, 0.786 + zs);
            grc.AddNodePtxz("osm809773376", 79.122 + xs, 0.930 + zs);
            grc.AddNodePtxz("osm809773380", 79.109 + xs, 3.286 + zs);
            grc.AddNodePtxz("osm809773384", 81.688 + xs, 3.400 + zs);
            grc.AddNodePtxz("osm809773386", 81.623 + xs, 12.725 + zs);
            grc.AddNodePtxz("osm809773388", 79.243 + xs, 12.885 + zs);
            grc.AddNodePtxz("osm809773390", 79.310 + xs, 15.450 + zs);
            grc.AddNodePtxz("osm809773392", 76.449 + xs, 15.501 + zs);
            grc.AddNodePtxz("osm809773393", 76.494 + xs, 19.271 + zs);
            grc.AddNodePtxz("osm809773395", 12.577 + xs, 19.474 + zs);
            grc.AddNodePtxz("osm809773397", 12.531 + xs, 15.640 + zs);
            grc.AddNodePtxz("osm7290856440", 10.862 + xs, 15.655 + zs);
            grc.AddNodePtxz("osm7290856441", 10.793 + xs, 13.936 + zs);
            grc.AddNodePtxz("osm809773401", 7.220 + xs, 14.067 + zs);
            grc.AddNodePtxz("osm7290856442", 7.152 + xs, 12.816 + zs);
            grc.AddNodePtxz("osm7290856443", 5.376 + xs, 12.834 + zs);
            grc.AddNodePtxz("osm809773408", 5.377 + xs, 1.237 + zs);
            grc.AddNodePtxz("osm809773411", -3.225 + xs, 1.612 + zs);
            grc.AddNodePtxz("osm809773415", -3.245 + xs, 12.996 + zs);
            grc.AddNodePtxz("osm809773417", -5.251 + xs, 13.030 + zs);
            grc.AddNodePtxz("osm809773425", -5.269 + xs, 22.894 + zs);
            grc.AddNodePtxz("osm809773428", -9.121 + xs, 23.080 + zs);
            grc.AddNodePtxz("osm809773431", -9.105 + xs, 25.185 + zs);
            grc.AddNodePtxz("osm809773435", -11.576 + xs, 25.234 + zs);
            grc.AddNodePtxz("osm809773437", -11.608 + xs, 27.845 + zs);
            grc.AddNodePtxz("osm809773439", -21.481 + xs, 27.641 + zs);
            grc.AddNodePtxz("osm809773442", -21.591 + xs, 24.895 + zs);
            grc.AddNodePtxz("osm809773443", -23.865 + xs, 24.988 + zs);
            grc.AddNodePtxz("osm809773447", -23.820 + xs, 30.104 + zs);
            grc.AddNodePtxz("osm809787927", -93.438 + xs, 65.839 + zs);
            grc.AddNodePtxz("osm809787931", -53.503 + xs, 79.242 + zs);
            grc.AddNodePtxz("osm809787936", -49.509 + xs, 68.133 + zs);
            grc.AddNodePtxz("osm809787952", -37.562 + xs, 72.175 + zs);
            grc.AddNodePtxz("osm809787956", -32.069 + xs, 56.360 + zs);
            grc.AddNodePtxz("osm809787959", -28.304 + xs, 57.664 + zs);
            grc.AddNodePtxz("osm809787963", -30.006 + xs, 62.381 + zs);
            grc.AddNodePtxz("osm7290746631", -28.227 + xs, 62.990 + zs);
            grc.AddNodePtxz("osm7290746630", -27.391 + xs, 60.678 + zs);
            grc.AddNodePtxz("osm809787966", -17.892 + xs, 63.795 + zs);
            grc.AddNodePtxz("osm809787973", -19.614 + xs, 68.600 + zs);
            grc.AddNodePtxz("osm809787979", -13.222 + xs, 70.590 + zs);
            grc.AddNodePtxz("osm809787987", -16.414 + xs, 79.716 + zs);
            grc.AddNodePtxz("osm809787989", -14.735 + xs, 80.244 + zs);
            grc.AddNodePtxz("osm809787990", -18.519 + xs, 91.123 + zs);
            grc.AddNodePtxz("osm809787991", -10.514 + xs, 93.793 + zs);
            grc.AddNodePtxz("osm809787995", -6.767 + xs, 82.884 + zs);
            grc.AddNodePtxz("osm809788001", 0.289 + xs, 85.434 + zs);
            grc.AddNodePtxz("osm809788010", 2.293 + xs, 79.657 + zs);
            grc.AddNodePtxz("osm809788014", 63.101 + xs, 99.840 + zs);
            grc.AddNodePtxz("osm809788018", 60.954 + xs, 105.854 + zs);
            grc.AddNodePtxz("osm809788022", 65.764 + xs, 107.612 + zs);
            grc.AddNodePtxz("osm809788025", 62.561 + xs, 116.837 + zs);
            grc.AddNodePtxz("osm809788027", 60.089 + xs, 115.983 + zs);
            grc.AddNodePtxz("osm809788031", 59.270 + xs, 118.348 + zs);
            grc.AddNodePtxz("osm809788035", 64.233 + xs, 119.873 + zs);
            grc.AddNodePtxz("osm809788038", 63.057 + xs, 123.391 + zs);
            grc.AddNodePtxz("osm809788043", 22.737 + xs, 110.142 + zs);
            grc.AddNodePtxz("osm809788056", 18.786 + xs, 121.868 + zs);
            grc.AddNodePtxz("osm809788062", 7.109 + xs, 117.997 + zs);
            grc.AddNodePtxz("osm809788065", -1.039 + xs, 141.443 + zs);
            grc.AddNodePtxz("osm7290746626", -5.022 + xs, 140.088 + zs);
            grc.AddNodePtxz("osm7290746627", -3.317 + xs, 135.364 + zs);
            grc.AddNodePtxz("osm7290746629", -5.237 + xs, 134.786 + zs);
            grc.AddNodePtxz("osm7290746628", -6.044 + xs, 137.219 + zs);
            grc.AddNodePtxz("osm809788072", -15.778 + xs, 133.862 + zs);
            grc.AddNodePtxz("osm809788079", -14.029 + xs, 128.980 + zs);
            grc.AddNodePtxz("osm809788086", -20.029 + xs, 127.084 + zs);
            grc.AddNodePtxz("osm809788093", -11.437 + xs, 101.936 + zs);
            grc.AddNodePtxz("osm809788099", -22.852 + xs, 97.989 + zs);
            grc.AddNodePtxz("osm809788101", -25.817 + xs, 106.907 + zs);
            grc.AddNodePtxz("osm809788102", -31.445 + xs, 105.028 + zs);
            grc.AddNodePtxz("osm809788106", -33.136 + xs, 110.248 + zs);
            grc.AddNodePtxz("osm809788113", -93.556 + xs, 89.532 + zs);
            grc.AddNodePtxz("osm809788119", -91.582 + xs, 83.775 + zs);
            grc.AddNodePtxz("osm809788125", -96.502 + xs, 82.130 + zs);
            grc.AddNodePtxz("osm809788131", -93.311 + xs, 72.735 + zs);
            grc.AddNodePtxz("osm809788137", -90.616 + xs, 73.594 + zs);
            grc.AddNodePtxz("osm809788143", -89.859 + xs, 71.437 + zs);
            grc.AddNodePtxz("osm809788149", -94.789 + xs, 69.789 + zs);
            grc.AddNodePtxz("osm809794788", -141.415 + xs, 5.206 + zs);
            grc.AddNodePtxz("osm809794793", -120.087 + xs, 14.250 + zs);
            grc.AddNodePtxz("osm809794795", -80.669 + xs, 27.547 + zs);
            grc.AddNodePtxz("osm809794798", -81.656 + xs, 30.694 + zs);
            grc.AddNodePtxz("osm809794801", -77.202 + xs, 32.155 + zs);
            grc.AddNodePtxz("osm809794802", -78.609 + xs, 36.197 + zs);
            grc.AddNodePtxz("osm809794803", -83.168 + xs, 34.699 + zs);
            grc.AddNodePtxz("osm809794806", -84.227 + xs, 37.514 + zs);
            grc.AddNodePtxz("osm809794808", -97.844 + xs, 32.986 + zs);
            grc.AddNodePtxz("osm809794821", -101.196 + xs, 43.174 + zs);
            grc.AddNodePtxz("osm7291156633", -110.939 + xs, 39.910 + zs);
            grc.AddNodePtxz("osm809794823", -141.620 + xs, 29.280 + zs);
            grc.AddNodePtxz("osm809801820", -172.906 + xs, -18.138 + zs);
            grc.AddNodePtxz("osm809801822", -163.199 + xs, -14.839 + zs);
            grc.AddNodePtxz("osm809801825", -164.045 + xs, -12.498 + zs);
            grc.AddNodePtxz("osm809801827", -161.856 + xs, -11.709 + zs);
            grc.AddNodePtxz("osm809801831", -162.742 + xs, -9.185 + zs);
            grc.AddNodePtxz("osm809801834", -159.482 + xs, -8.053 + zs);
            grc.AddNodePtxz("osm809801838", -169.033 + xs, 19.895 + zs);
            grc.AddNodePtxz("osm7290856430", -172.287 + xs, 18.647 + zs);
            grc.AddNodePtxz("osm809801841", -172.943 + xs, 20.482 + zs);
            grc.AddNodePtxz("osm7290856429", -174.757 + xs, 19.868 + zs);
            grc.AddNodePtxz("osm809801843", -176.014 + xs, 23.383 + zs);
            grc.AddNodePtxz("osm809801846", -184.638 + xs, 20.494 + zs);
            grc.AddNodePtxz("osm809801848", -188.633 + xs, 32.109 + zs);
            grc.AddNodePtxz("osm7291156664", -133.761 + xs, 50.649 + zs);
            grc.AddNodePtxz("osm809801850", -132.271 + xs, 51.143 + zs);
            grc.AddNodePtxz("osm809801853", -133.661 + xs, 54.937 + zs);
            grc.AddNodePtxz("osm809801854", -138.217 + xs, 53.464 + zs);
            grc.AddNodePtxz("osm7290856426", -138.888 + xs, 55.342 + zs);
            grc.AddNodePtxz("osm7290856425", -136.385 + xs, 56.143 + zs);
            grc.AddNodePtxz("osm809801857", -139.666 + xs, 65.658 + zs);
            grc.AddNodePtxz("osm7290856427", -142.312 + xs, 64.792 + zs);
            grc.AddNodePtxz("osm809801860", -143.164 + xs, 67.186 + zs);
            grc.AddNodePtxz("osm7290856428", -145.612 + xs, 66.364 + zs);
            grc.AddNodePtxz("osm809801871", -146.793 + xs, 69.864 + zs);
            grc.AddNodePtxz("osm809801874", -187.564 + xs, 55.883 + zs);
            grc.AddNodePtxz("osm809801882", -191.553 + xs, 67.952 + zs);
            grc.AddNodePtxz("osm809801884", -203.236 + xs, 64.032 + zs);
            grc.AddNodePtxz("osm809801887", -205.821 + xs, 71.496 + zs);
            grc.AddNodePtxz("osm809801890", -209.694 + xs, 70.130 + zs);
            grc.AddNodePtxz("osm809801893", -207.928 + xs, 65.198 + zs);
            grc.AddNodePtxz("osm809801897", -210.217 + xs, 64.493 + zs);
            grc.AddNodePtxz("osm809801900", -211.128 + xs, 66.922 + zs);
            grc.AddNodePtxz("osm809801903", -220.439 + xs, 63.806 + zs);
            grc.AddNodePtxz("osm809801905", -218.758 + xs, 58.916 + zs);
            grc.AddNodePtxz("osm809801906", -224.788 + xs, 56.804 + zs);
            grc.AddNodePtxz("osm809801908", -215.094 + xs, 29.118 + zs);
            grc.AddNodePtxz("osm809801910", -209.147 + xs, 31.099 + zs);
            grc.AddNodePtxz("osm809801912", -206.779 + xs, 24.250 + zs);
            grc.AddNodePtxz("osm809801916", -195.532 + xs, 27.934 + zs);
            grc.AddNodePtxz("osm809801919", -192.689 + xs, 19.599 + zs);
            grc.AddNodePtxz("osm809801922", -203.878 + xs, 15.650 + zs);
            grc.AddNodePtxz("osm809801925", -203.349 + xs, 14.041 + zs);
            grc.AddNodePtxz("osm809801929", -251.729 + xs, -2.292 + zs);
            grc.AddNodePtxz("osm809801931", -250.381 + xs, -6.132 + zs);
            grc.AddNodePtxz("osm809801933", -245.747 + xs, -4.545 + zs);
            grc.AddNodePtxz("osm7290856424", -244.953 + xs, -6.840 + zs);
            grc.AddNodePtxz("osm7290856423", -247.244 + xs, -7.640 + zs);
            grc.AddNodePtxz("osm809801935", -244.126 + xs, -16.760 + zs);
            grc.AddNodePtxz("osm809801936", -241.756 + xs, -15.948 + zs);
            grc.AddNodePtxz("osm809801938", -240.890 + xs, -18.416 + zs);
            grc.AddNodePtxz("osm809801951", -238.402 + xs, -17.572 + zs);
            grc.AddNodePtxz("osm809801954", -237.206 + xs, -21.045 + zs);
            grc.AddNodePtxz("osm809801956", -196.432 + xs, -7.109 + zs);
            grc.AddNodePtxz("osm809801958", -192.502 + xs, -18.842 + zs);
            grc.AddNodePtxz("osm809801959", -180.769 + xs, -14.929 + zs);
            grc.AddNodePtxz("osm809801960", -178.078 + xs, -22.594 + zs);
            grc.AddNodePtxz("osm809801962", -174.101 + xs, -21.288 + zs);
            grc.AddNodePtxz("osm809801963", -175.835 + xs, -16.551 + zs);
            grc.AddNodePtxz("osm809801965", -173.655 + xs, -15.836 + zs);
            grc.AddNodePtxz("osm1086538989", -136.123 + xs, -689.055 + zs);
            grc.AddNodePtxz("osm3225793008", -153.209 + xs, -640.144 + zs);
            grc.AddNodePtxz("osm3225789637", -165.948 + xs, -644.117 + zs);
            grc.AddNodePtxz("osm1086539021", -174.086 + xs, -620.057 + zs);
            grc.AddNodePtxz("osm3225793006", -99.588 + xs, -590.482 + zs);
            grc.AddNodePtxz("osm3225792974", -98.870 + xs, -595.385 + zs);
            grc.AddNodePtxz("osm1086539030", -81.702 + xs, -592.098 + zs);
            grc.AddNodePtxz("osm3225789658", -73.674 + xs, -642.898 + zs);
            grc.AddNodePtxz("osm3225789657", -59.266 + xs, -640.960 + zs);
            grc.AddNodePtxz("osm1086539012", -55.540 + xs, -667.203 + zs);
            grc.AddNodePtxz("osm3225792994", -86.416 + xs, -670.588 + zs);
            grc.AddNodePtxz("osm3225792979", -85.817 + xs, -675.152 + zs);
            grc.AddNodePtxz("osm3225793011", -94.319 + xs, -676.573 + zs);
            grc.AddNodePtxz("osm3225789654", -95.017 + xs, -671.996 + zs);
            grc.AddNodePtxz("osm3225793015", -108.413 + xs, -674.332 + zs);
            grc.AddNodePtxz("osm3225789642", -109.055 + xs, -670.687 + zs);
            grc.AddNodePtxz("osm3225792973", -114.685 + xs, -672.764 + zs);
            grc.AddNodePtxz("osm4844540700", -113.523 + xs, -675.939 + zs);
            grc.AddNodePtxz("osm3225792971", -110.474 + xs, -684.322 + zs);
            grc.AddNodePtxz("osm3225792983", -118.994 + xs, -687.373 + zs);
            grc.AddNodePtxz("osm3225792970", -120.413 + xs, -683.399 + zs);
            grc.AddNodePtxz("osm1086539062", -138.073 + xs, -572.090 + zs);
            grc.AddNodePtxz("osm3347107166", -152.315 + xs, -460.269 + zs);
            grc.AddNodePtxz("osm3347106868", -146.442 + xs, -459.288 + zs);
            grc.AddNodePtxz("osm1086539064", -147.541 + xs, -454.206 + zs);
            grc.AddNodePtxz("osm1086539049", -98.619 + xs, -445.467 + zs);
            grc.AddNodePtxz("osm6946491921", -97.723 + xs, -451.315 + zs);
            grc.AddNodePtxz("osm6946491922", -96.558 + xs, -451.138 + zs);
            grc.AddNodePtxz("osm7149738330", -84.201 + xs, -529.091 + zs);
            grc.AddNodePtxz("osm7149738327", -82.785 + xs, -538.065 + zs);
            grc.AddNodePtxz("osm6946491920", -80.678 + xs, -551.325 + zs);
            grc.AddNodePtxz("osm6946491919", -81.985 + xs, -551.503 + zs);
            grc.AddNodePtxz("osm1086538998", -80.916 + xs, -557.941 + zs);
            grc.AddNodePtxz("osm6946491925", -85.040 + xs, -558.593 + zs);
            grc.AddNodePtxz("osm6946491926", -84.879 + xs, -559.726 + zs);
            grc.AddNodePtxz("osm4781718856", -125.202 + xs, -565.403 + zs);
            grc.AddNodePtxz("osm4781718857", -124.703 + xs, -568.369 + zs);
            grc.AddNodePtxz("osm6946491918", -133.955 + xs, -569.841 + zs);
            grc.AddNodePtxz("osm6946491917", -133.742 + xs, -571.590 + zs);
            grc.AddNodePtxz("osm1488880288", -404.434 + xs, -291.711 + zs);
            grc.AddNodePtxz("osm4829350214", -409.088 + xs, -287.831 + zs);
            grc.AddNodePtxz("osm4829350823", -410.315 + xs, -289.209 + zs);
            grc.AddNodePtxz("osm4829350215", -411.106 + xs, -288.466 + zs);
            grc.AddNodePtxz("osm4829350822", -411.603 + xs, -289.167 + zs);
            grc.AddNodePtxz("osm4829350821", -419.507 + xs, -282.312 + zs);
            grc.AddNodePtxz("osm4829350220", -419.155 + xs, -281.502 + zs);
            grc.AddNodePtxz("osm4829350217", -419.779 + xs, -280.765 + zs);
            grc.AddNodePtxz("osm4829350216", -419.164 + xs, -280.230 + zs);
            grc.AddNodePtxz("osm1488880208", -425.190 + xs, -275.029 + zs);
            grc.AddNodePtxz("osm1488880201", -417.015 + xs, -265.751 + zs);
            grc.AddNodePtxz("osm7463723789", -416.696 + xs, -265.990 + zs);
            grc.AddNodePtxz("osm1488880184", -415.569 + xs, -266.848 + zs);
            grc.AddNodePtxz("osm7463723787", -400.089 + xs, -249.745 + zs);
            grc.AddNodePtxz("osm1488880190", -396.477 + xs, -245.752 + zs);
            grc.AddNodePtxz("osm7516983716", -399.966 + xs, -242.534 + zs);
            grc.AddNodePtxz("osm1488880199", -405.075 + xs, -237.962 + zs);
            grc.AddNodePtxz("osm7516983717", -408.353 + xs, -240.185 + zs);
            grc.AddNodePtxz("osm7245133419", -409.972 + xs, -241.286 + zs);
            grc.AddNodePtxz("osm1488880316", -422.421 + xs, -249.746 + zs);
            grc.AddNodePtxz("osm4829362459", -425.842 + xs, -244.470 + zs);
            grc.AddNodePtxz("osm4829362458", -426.615 + xs, -244.956 + zs);
            grc.AddNodePtxz("osm4829362457", -427.107 + xs, -244.158 + zs);
            grc.AddNodePtxz("osm4829362456", -427.887 + xs, -244.726 + zs);
            grc.AddNodePtxz("osm1488880245", -433.746 + xs, -235.563 + zs);
            grc.AddNodePtxz("osm1488880397", -443.171 + xs, -241.784 + zs);
            grc.AddNodePtxz("osm1488880467", -446.666 + xs, -236.263 + zs);
            grc.AddNodePtxz("osm7543923647", -435.663 + xs, -228.757 + zs);
            grc.AddNodePtxz("osm1488880508", -443.961 + xs, -216.041 + zs);
            grc.AddNodePtxz("osm7543923646", -438.511 + xs, -212.511 + zs);
            grc.AddNodePtxz("osm1488880202", -441.989 + xs, -207.040 + zs);
            grc.AddNodePtxz("osm4846255782", -436.954 + xs, -204.009 + zs);
            grc.AddNodePtxz("osm4846255781", -438.360 + xs, -201.750 + zs);
            grc.AddNodePtxz("osm4846255780", -427.747 + xs, -194.679 + zs);
            grc.AddNodePtxz("osm4846255779", -426.996 + xs, -196.014 + zs);
            grc.AddNodePtxz("osm1488880568", -420.359 + xs, -191.833 + zs);
            grc.AddNodePtxz("osm7463723765", -416.303 + xs, -198.246 + zs);
            grc.AddNodePtxz("osm7463723764", -414.923 + xs, -200.428 + zs);
            grc.AddNodePtxz("osm1488880323", -413.679 + xs, -202.394 + zs);
            grc.AddNodePtxz("osm1488880391", -415.146 + xs, -203.221 + zs);
            grc.AddNodePtxz("osm1488880399", -412.777 + xs, -206.609 + zs);
            grc.AddNodePtxz("osm1488880619", -402.352 + xs, -200.013 + zs);
            grc.AddNodePtxz("osm1488880203", -406.008 + xs, -194.302 + zs);
            grc.AddNodePtxz("osm4846255777", -400.637 + xs, -191.085 + zs);
            grc.AddNodePtxz("osm4846255778", -401.810 + xs, -189.491 + zs);
            grc.AddNodePtxz("osm4846255776", -391.181 + xs, -182.668 + zs);
            grc.AddNodePtxz("osm4846255775", -390.320 + xs, -184.044 + zs);
            grc.AddNodePtxz("osm1488880570", -385.044 + xs, -180.860 + zs);
            grc.AddNodePtxz("osm1488880252", -381.664 + xs, -186.658 + zs);
            grc.AddNodePtxz("osm1488880547", -358.220 + xs, -171.780 + zs);
            grc.AddNodePtxz("osm4846255774", -355.160 + xs, -176.261 + zs);
            grc.AddNodePtxz("osm4846255773", -352.809 + xs, -174.759 + zs);
            grc.AddNodePtxz("osm4829350831", -345.910 + xs, -184.937 + zs);
            grc.AddNodePtxz("osm4846255772", -347.140 + xs, -186.071 + zs);
            grc.AddNodePtxz("osm1488880193", -342.872 + xs, -193.355 + zs);
            grc.AddNodePtxz("osm7543923644", -347.735 + xs, -196.541 + zs);
            grc.AddNodePtxz("osm4829350833", -353.058 + xs, -199.995 + zs);
            grc.AddNodePtxz("osm4829350834", -353.961 + xs, -198.632 + zs);
            grc.AddNodePtxz("osm7463723733", -361.793 + xs, -203.745 + zs);
            grc.AddNodePtxz("osm1488880218", -367.622 + xs, -207.405 + zs);
            grc.AddNodePtxz("osm7463723731", -361.374 + xs, -213.306 + zs);
            grc.AddNodePtxz("osm1488880247", -358.487 + xs, -216.120 + zs);
            grc.AddNodePtxz("osm1488880196", -347.013 + xs, -208.746 + zs);
            grc.AddNodePtxz("osm4829350836", -343.832 + xs, -213.812 + zs);
            grc.AddNodePtxz("osm4829350837", -342.207 + xs, -212.828 + zs);
            grc.AddNodePtxz("osm7463723725", -341.783 + xs, -213.498 + zs);
            grc.AddNodePtxz("osm4829350838", -335.384 + xs, -223.158 + zs);
            grc.AddNodePtxz("osm4829350839", -336.878 + xs, -224.279 + zs);
            grc.AddNodePtxz("osm7463723720", -334.550 + xs, -227.784 + zs);
            grc.AddNodePtxz("osm1488880228", -333.406 + xs, -229.531 + zs);
            grc.AddNodePtxz("osm7463723717", -334.073 + xs, -229.949 + zs);
            grc.AddNodePtxz("osm7463723713", -335.860 + xs, -231.076 + zs);
            grc.AddNodePtxz("osm1488880545", -338.826 + xs, -232.979 + zs);
            grc.AddNodePtxz("osm1488880331", -327.267 + xs, -250.718 + zs);
            grc.AddNodePtxz("osm4829350840", -332.284 + xs, -254.067 + zs);
            grc.AddNodePtxz("osm4829350841", -330.742 + xs, -256.478 + zs);
            grc.AddNodePtxz("osm4829350842", -341.227 + xs, -263.442 + zs);
            grc.AddNodePtxz("osm4829350843", -342.242 + xs, -261.762 + zs);
            grc.AddNodePtxz("osm1488880448", -348.935 + xs, -266.287 + zs);
            grc.AddNodePtxz("osm7463723706", -353.273 + xs, -259.708 + zs);
            grc.AddNodePtxz("osm7245133586", -354.575 + xs, -257.714 + zs);
            grc.AddNodePtxz("osm4829350845", -355.638 + xs, -256.098 + zs);
            grc.AddNodePtxz("osm4829350844", -354.330 + xs, -255.119 + zs);
            grc.AddNodePtxz("osm1488880456", -363.203 + xs, -241.268 + zs);
            grc.AddNodePtxz("osm1488880488", -371.911 + xs, -250.302 + zs);
            grc.AddNodePtxz("osm1488880216", -364.081 + xs, -257.451 + zs);
            grc.AddNodePtxz("osm4829350824", -368.741 + xs, -262.492 + zs);
            grc.AddNodePtxz("osm4829350825", -367.764 + xs, -264.067 + zs);
            grc.AddNodePtxz("osm4829350826", -375.505 + xs, -272.832 + zs);
            grc.AddNodePtxz("osm4829350827", -377.156 + xs, -271.322 + zs);
            grc.AddNodePtxz("osm1488880212", -381.277 + xs, -275.712 + zs);
            grc.AddNodePtxz("osm1488880211", -386.140 + xs, -271.269 + zs);
            grc.AddNodePtxz("osm1488880322", -448.553 + xs, -429.445 + zs);
            grc.AddNodePtxz("osm1488880205", -444.026 + xs, -402.650 + zs);
            grc.AddNodePtxz("osm1488902087", -429.335 + xs, -405.011 + zs);
            grc.AddNodePtxz("osm7528124004", -423.425 + xs, -406.457 + zs);
            grc.AddNodePtxz("osm7528124003", -423.243 + xs, -405.564 + zs);
            grc.AddNodePtxz("osm1488880177", -416.202 + xs, -407.003 + zs);
            grc.AddNodePtxz("osm7528124006", -418.368 + xs, -420.292 + zs);
            grc.AddNodePtxz("osm7528124005", -419.078 + xs, -420.218 + zs);
            grc.AddNodePtxz("osm1488880490", -420.839 + xs, -430.057 + zs);
            grc.AddNodePtxz("osm1488880584", -431.631 + xs, -428.080 + zs);
            grc.AddNodePtxz("osm1488880629", -431.880 + xs, -429.488 + zs);
            grc.AddNodePtxz("osm1488880586", -488.577 + xs, -588.353 + zs);
            grc.AddNodePtxz("osm4846295252", -482.200 + xs, -583.667 + zs);
            grc.AddNodePtxz("osm4846295253", -481.201 + xs, -585.099 + zs);
            grc.AddNodePtxz("osm1488880180", -470.809 + xs, -577.906 + zs);
            grc.AddNodePtxz("osm4846295259", -472.427 + xs, -575.481 + zs);
            grc.AddNodePtxz("osm7230628048", -468.488 + xs, -572.754 + zs);
            grc.AddNodePtxz("osm4846295258", -467.317 + xs, -571.957 + zs);
            grc.AddNodePtxz("osm7462172846", -468.239 + xs, -570.673 + zs);
            grc.AddNodePtxz("osm1488880506", -488.292 + xs, -542.518 + zs);
            grc.AddNodePtxz("osm1488880248", -482.936 + xs, -538.886 + zs);
            grc.AddNodePtxz("osm7469351322", -485.310 + xs, -535.485 + zs);
            grc.AddNodePtxz("osm4846295257", -486.761 + xs, -533.367 + zs);
            grc.AddNodePtxz("osm4846295256", -485.286 + xs, -532.260 + zs);
            grc.AddNodePtxz("osm4846295255", -492.030 + xs, -522.727 + zs);
            grc.AddNodePtxz("osm4846295254", -493.528 + xs, -523.802 + zs);
            grc.AddNodePtxz("osm7469351325", -494.892 + xs, -521.932 + zs);
            grc.AddNodePtxz("osm1488880159", -497.192 + xs, -518.775 + zs);
            grc.AddNodePtxz("osm1488880286", -516.043 + xs, -531.850 + zs);
            grc.AddNodePtxz("osm7230628018", -520.973 + xs, -526.980 + zs);
            grc.AddNodePtxz("osm1488880295", -523.996 + xs, -523.982 + zs);
            grc.AddNodePtxz("osm7230628043", -520.964 + xs, -520.418 + zs);
            grc.AddNodePtxz("osm1488880160", -505.031 + xs, -501.687 + zs);
            grc.AddNodePtxz("osm1488880173", -503.623 + xs, -502.908 + zs);
            grc.AddNodePtxz("osm1488880515", -495.517 + xs, -492.964 + zs);
            grc.AddNodePtxz("osm4846295228", -500.993 + xs, -488.620 + zs);
            grc.AddNodePtxz("osm4846295229", -499.881 + xs, -487.186 + zs);
            grc.AddNodePtxz("osm4846295230", -510.310 + xs, -478.478 + zs);
            grc.AddNodePtxz("osm4846295231", -512.073 + xs, -480.951 + zs);
            grc.AddNodePtxz("osm1488880608", -516.792 + xs, -476.951 + zs);
            grc.AddNodePtxz("osm1488880327", -534.394 + xs, -498.257 + zs);
            grc.AddNodePtxz("osm1488880230", -539.537 + xs, -493.958 + zs);
            grc.AddNodePtxz("osm4846295232", -543.218 + xs, -498.561 + zs);
            grc.AddNodePtxz("osm4846295233", -545.172 + xs, -496.925 + zs);
            grc.AddNodePtxz("osm4846295234", -553.116 + xs, -506.829 + zs);
            grc.AddNodePtxz("osm4846295235", -551.705 + xs, -508.057 + zs);
            grc.AddNodePtxz("osm1488880443", -555.466 + xs, -512.600 + zs);
            grc.AddNodePtxz("osm1488880269", -546.796 + xs, -519.993 + zs);
            grc.AddNodePtxz("osm7230627909", -549.093 + xs, -522.657 + zs);
            grc.AddNodePtxz("osm1488880598", -554.600 + xs, -528.914 + zs);
            grc.AddNodePtxz("osm1488880161", -557.522 + xs, -526.406 + zs);
            grc.AddNodePtxz("osm7230627907", -559.293 + xs, -523.812 + zs);
            grc.AddNodePtxz("osm1488880593", -571.467 + xs, -506.909 + zs);
            grc.AddNodePtxz("osm1488880625", -570.085 + xs, -505.873 + zs);
            grc.AddNodePtxz("osm7230627885", -572.782 + xs, -501.988 + zs);
            grc.AddNodePtxz("osm7462172718", -576.878 + xs, -496.301 + zs);
            grc.AddNodePtxz("osm1488880527", -577.390 + xs, -495.581 + zs);
            grc.AddNodePtxz("osm4846295236", -584.281 + xs, -500.316 + zs);
            grc.AddNodePtxz("osm4846295237", -585.322 + xs, -499.065 + zs);
            grc.AddNodePtxz("osm4846295238", -595.024 + xs, -505.974 + zs);
            grc.AddNodePtxz("osm4846295239", -593.480 + xs, -508.290 + zs);
            grc.AddNodePtxz("osm7458590533", -595.015 + xs, -509.394 + zs);
            grc.AddNodePtxz("osm1488880339", -598.365 + xs, -511.816 + zs);
            grc.AddNodePtxz("osm7230627844", -591.313 + xs, -521.822 + zs);
            grc.AddNodePtxz("osm7230627841", -590.210 + xs, -523.385 + zs);
            grc.AddNodePtxz("osm7458590510", -582.563 + xs, -534.147 + zs);
            grc.AddNodePtxz("osm1488880489", -577.512 + xs, -541.242 + zs);
            grc.AddNodePtxz("osm1488880164", -582.926 + xs, -545.044 + zs);
            grc.AddNodePtxz("osm4846295240", -579.606 + xs, -550.165 + zs);
            grc.AddNodePtxz("osm4846295241", -581.119 + xs, -551.166 + zs);
            grc.AddNodePtxz("osm4846295242", -574.182 + xs, -560.911 + zs);
            grc.AddNodePtxz("osm4846295243", -572.508 + xs, -559.799 + zs);
            grc.AddNodePtxz("osm1488880176", -568.599 + xs, -565.424 + zs);
            grc.AddNodePtxz("osm1488880341", -556.903 + xs, -557.206 + zs);
            grc.AddNodePtxz("osm1488880287", -549.865 + xs, -567.106 + zs);
            grc.AddNodePtxz("osm1488880251", -561.097 + xs, -574.967 + zs);
            grc.AddNodePtxz("osm1488880166", -562.163 + xs, -573.645 + zs);
            grc.AddNodePtxz("osm7458590514", -564.037 + xs, -574.960 + zs);
            grc.AddNodePtxz("osm1488880567", -572.365 + xs, -580.742 + zs);
            grc.AddNodePtxz("osm4846295244", -567.391 + xs, -588.157 + zs);
            grc.AddNodePtxz("osm4846295245", -568.586 + xs, -588.954 + zs);
            grc.AddNodePtxz("osm4846295246", -562.176 + xs, -598.475 + zs);
            grc.AddNodePtxz("osm4846295247", -559.525 + xs, -596.886 + zs);
            grc.AddNodePtxz("osm7458566169", -558.370 + xs, -598.566 + zs);
            grc.AddNodePtxz("osm1488880155", -555.956 + xs, -602.081 + zs);
            grc.AddNodePtxz("osm7230625681", -547.071 + xs, -595.633 + zs);
            grc.AddNodePtxz("osm1488880326", -533.353 + xs, -586.184 + zs);
            grc.AddNodePtxz("osm1488880431", -530.033 + xs, -590.735 + zs);
            grc.AddNodePtxz("osm6042865816", -526.202 + xs, -599.364 + zs);
            grc.AddNodePtxz("osm6042865815", -527.114 + xs, -599.724 + zs);
            grc.AddNodePtxz("osm6042865814", -522.642 + xs, -611.960 + zs);
            grc.AddNodePtxz("osm6042865817", -501.022 + xs, -604.084 + zs);
            grc.AddNodePtxz("osm6042865820", -503.377 + xs, -597.745 + zs);
            grc.AddNodePtxz("osm6042865822", -505.950 + xs, -598.681 + zs);
            grc.AddNodePtxz("osm4846295248", -507.533 + xs, -594.407 + zs);
            grc.AddNodePtxz("osm6042865821", -513.764 + xs, -596.786 + zs);
            grc.AddNodePtxz("osm6042865819", -516.926 + xs, -587.880 + zs);
            grc.AddNodePtxz("osm6042865818", -512.107 + xs, -585.913 + zs);
            grc.AddNodePtxz("osm7230628053", -512.930 + xs, -584.578 + zs);
            grc.AddNodePtxz("osm4846295249", -514.521 + xs, -582.026 + zs);
            grc.AddNodePtxz("osm4846295251", -514.047 + xs, -581.563 + zs);
            grc.AddNodePtxz("osm4846295250", -514.337 + xs, -581.005 + zs);
            grc.AddNodePtxz("osm1488880189", -509.054 + xs, -577.572 + zs);
            grc.AddNodePtxz("osm1488880186", -512.982 + xs, -571.962 + zs);
            grc.AddNodePtxz("osm7458566183", -511.111 + xs, -570.704 + zs);
            grc.AddNodePtxz("osm7458590493", -508.051 + xs, -568.634 + zs);
            grc.AddNodePtxz("osm1488880531", -502.765 + xs, -565.074 + zs);
            grc.AddNodePtxz("osm1488880530", -494.350 + xs, -577.149 + zs);
            grc.AddNodePtxz("osm1488880157", -496.093 + xs, -578.165 + zs);
            grc.AddNodePtxz("osm7458590489", -495.246 + xs, -579.269 + zs);
            grc.AddNodePtxz("osm7458590487", -493.964 + xs, -580.969 + zs);
            grc.AddNodePtxz("osm7458590488", -491.307 + xs, -584.607 + zs);
            grc.AddNodePtxz("osm1488880337", -495.380 + xs, -453.192 + zs);
            grc.AddNodePtxz("osm7549247168", -490.533 + xs, -449.156 + zs);
            grc.AddNodePtxz("osm7462172859", -477.300 + xs, -438.154 + zs);
            grc.AddNodePtxz("osm1488880473", -464.103 + xs, -427.188 + zs);
            grc.AddNodePtxz("osm7245133625", -464.400 + xs, -424.897 + zs);
            grc.AddNodePtxz("osm1488880233", -464.833 + xs, -421.647 + zs);
            grc.AddNodePtxz("osm1488880309", -458.617 + xs, -420.533 + zs);
            grc.AddNodePtxz("osm1488880446", -481.146 + xs, -361.025 + zs);
            grc.AddNodePtxz("osm4823517533", -479.723 + xs, -360.340 + zs);
            grc.AddNodePtxz("osm7462172748", -480.376 + xs, -351.153 + zs);
            grc.AddNodePtxz("osm1488880293", -479.065 + xs, -351.021 + zs);
            grc.AddNodePtxz("osm1488880611", -479.961 + xs, -340.571 + zs);
            grc.AddNodePtxz("osm4829304100", -446.538 + xs, -301.626 + zs);
            grc.AddNodePtxz("osm1488880582", -445.071 + xs, -299.991 + zs);
            grc.AddNodePtxz("osm4829304098", -446.551 + xs, -298.699 + zs);
            grc.AddNodePtxz("osm1491011822", -448.554 + xs, -296.858 + zs);
            grc.AddNodePtxz("osm1488880512", -452.731 + xs, -293.527 + zs);
            grc.AddNodePtxz("osm1488880249", -455.903 + xs, -295.683 + zs);
            grc.AddNodePtxz("osm1488880243", -460.451 + xs, -287.465 + zs);
            grc.AddNodePtxz("osm1488880282", -499.999 + xs, -303.079 + zs);
            grc.AddNodePtxz("osm1488880375", -526.060 + xs, -332.081 + zs);
            grc.AddNodePtxz("osm7245133193", -525.087 + xs, -332.937 + zs);
            grc.AddNodePtxz("osm7245133192", -523.433 + xs, -334.390 + zs);
            grc.AddNodePtxz("osm1488880285", -522.447 + xs, -335.249 + zs);
            grc.AddNodePtxz("osm7462172746", -521.105 + xs, -350.901 + zs);
            grc.AddNodePtxz("osm7462172747", -522.279 + xs, -351.018 + zs);
            grc.AddNodePtxz("osm4829381870", -521.716 + xs, -358.604 + zs);
            grc.AddNodePtxz("osm7245130977", -521.596 + xs, -360.963 + zs);
            grc.AddNodePtxz("osm1488880197", -521.462 + xs, -363.698 + zs);
            grc.AddNodePtxz("osm1488880171", -516.187 + xs, -363.468 + zs);
            grc.AddNodePtxz("osm4829381869", -515.435 + xs, -365.643 + zs);
            grc.AddNodePtxz("osm1488880393", -513.490 + xs, -371.219 + zs);
            grc.AddNodePtxz("osm4829381868", -515.476 + xs, -371.978 + zs);
            grc.AddNodePtxz("osm1488880303", -517.589 + xs, -372.781 + zs);
            grc.AddNodePtxz("osm7245130962", -514.430 + xs, -381.513 + zs);
            grc.AddNodePtxz("osm7245130961", -503.147 + xs, -411.538 + zs);
            grc.AddNodePtxz("osm7458590571", -500.710 + xs, -418.111 + zs);
            grc.AddNodePtxz("osm7458590569", -499.450 + xs, -424.357 + zs);
            grc.AddNodePtxz("osm7458590568", -500.668 + xs, -424.616 + zs);
            grc.AddNodePtxz("osm7549247167", -495.691 + xs, -451.532 + zs);
            grc.AddNodePtxz("osm1488880492", -537.443 + xs, -402.526 + zs);
            grc.AddNodePtxz("osm1488880374", -564.567 + xs, -397.680 + zs);
            grc.AddNodePtxz("osm1488880552", -565.700 + xs, -404.333 + zs);
            grc.AddNodePtxz("osm4846295264", -571.820 + xs, -403.062 + zs);
            grc.AddNodePtxz("osm4856079664", -572.138 + xs, -404.240 + zs);
            grc.AddNodePtxz("osm4856079665", -572.993 + xs, -404.057 + zs);
            grc.AddNodePtxz("osm4846295265", -573.193 + xs, -404.831 + zs);
            grc.AddNodePtxz("osm4856079666", -583.785 + xs, -402.920 + zs);
            grc.AddNodePtxz("osm4856079667", -583.628 + xs, -402.225 + zs);
            grc.AddNodePtxz("osm4846295266", -584.411 + xs, -402.112 + zs);
            grc.AddNodePtxz("osm4846295267", -584.197 + xs, -400.740 + zs);
            grc.AddNodePtxz("osm1488880146", -590.189 + xs, -399.868 + zs);
            grc.AddNodePtxz("osm4856079668", -588.569 + xs, -389.896 + zs);
            grc.AddNodePtxz("osm1488880368", -588.582 + xs, -388.213 + zs);
            grc.AddNodePtxz("osm7239264385", -592.450 + xs, -387.477 + zs);
            grc.AddNodePtxz("osm7291607567", -595.415 + xs, -387.130 + zs);
            grc.AddNodePtxz("osm6042865921", -595.452 + xs, -391.966 + zs);
            grc.AddNodePtxz("osm1488880516", -600.511 + xs, -392.376 + zs);
            grc.AddNodePtxz("osm4856079669", -598.798 + xs, -413.319 + zs);
            grc.AddNodePtxz("osm4856079670", -597.695 + xs, -413.100 + zs);
            grc.AddNodePtxz("osm7239216316", -597.031 + xs, -419.463 + zs);
            grc.AddNodePtxz("osm1488880616", -596.290 + xs, -426.814 + zs);
            grc.AddNodePtxz("osm4846255749", -604.370 + xs, -427.458 + zs);
            grc.AddNodePtxz("osm4846255748", -604.432 + xs, -428.960 + zs);
            grc.AddNodePtxz("osm4846255747", -615.203 + xs, -429.701 + zs);
            grc.AddNodePtxz("osm4856079646", -615.341 + xs, -429.106 + zs);
            grc.AddNodePtxz("osm4856079645", -616.114 + xs, -429.189 + zs);
            grc.AddNodePtxz("osm4846255746", -616.358 + xs, -427.284 + zs);
            grc.AddNodePtxz("osm1488880347", -622.514 + xs, -427.926 + zs);
            grc.AddNodePtxz("osm7462172729", -623.145 + xs, -420.854 + zs);
            grc.AddNodePtxz("osm1488880149", -625.723 + xs, -392.167 + zs);
            grc.AddNodePtxz("osm1488880313", -632.531 + xs, -392.802 + zs);
            grc.AddNodePtxz("osm7458590602", -632.877 + xs, -388.390 + zs);
            grc.AddNodePtxz("osm4856079647", -633.030 + xs, -386.509 + zs);
            grc.AddNodePtxz("osm4856079648", -634.087 + xs, -386.689 + zs);
            grc.AddNodePtxz("osm4846255745", -634.175 + xs, -385.666 + zs);
            grc.AddNodePtxz("osm4846255744", -635.007 + xs, -385.816 + zs);
            grc.AddNodePtxz("osm4846255743", -636.082 + xs, -375.260 + zs);
            grc.AddNodePtxz("osm4846255742", -635.120 + xs, -375.176 + zs);
            grc.AddNodePtxz("osm4856079650", -635.304 + xs, -374.115 + zs);
            grc.AddNodePtxz("osm4856079649", -634.177 + xs, -373.998 + zs);
            grc.AddNodePtxz("osm7458590599", -634.358 + xs, -371.802 + zs);
            grc.AddNodePtxz("osm1488880147", -634.662 + xs, -368.080 + zs);
            grc.AddNodePtxz("osm1488880167", -620.584 + xs, -366.714 + zs);
            grc.AddNodePtxz("osm1488880330", -621.661 + xs, -354.235 + zs);
            grc.AddNodePtxz("osm7458590595", -633.144 + xs, -355.433 + zs);
            grc.AddNodePtxz("osm1488880175", -635.534 + xs, -355.681 + zs);
            grc.AddNodePtxz("osm1488880232", -635.323 + xs, -357.391 + zs);
            grc.AddNodePtxz("osm1488880421", -647.709 + xs, -358.368 + zs);
            grc.AddNodePtxz("osm4846255741", -648.282 + xs, -350.856 + zs);
            grc.AddNodePtxz("osm4846255740", -649.178 + xs, -350.925 + zs);
            grc.AddNodePtxz("osm7462172736", -649.275 + xs, -350.008 + zs);
            grc.AddNodePtxz("osm7462172735", -650.173 + xs, -350.038 + zs);
            grc.AddNodePtxz("osm4846255739", -651.033 + xs, -339.219 + zs);
            grc.AddNodePtxz("osm4846255738", -649.997 + xs, -339.078 + zs);
            grc.AddNodePtxz("osm4856079652", -650.106 + xs, -338.332 + zs);
            grc.AddNodePtxz("osm4856079651", -648.252 + xs, -338.069 + zs);
            grc.AddNodePtxz("osm1488880528", -648.815 + xs, -332.297 + zs);
            grc.AddNodePtxz("osm7458590645", -635.685 + xs, -330.986 + zs);
            grc.AddNodePtxz("osm1488880631", -621.396 + xs, -329.548 + zs);
            grc.AddNodePtxz("osm6047614819", -622.025 + xs, -323.086 + zs);
            grc.AddNodePtxz("osm6047614820", -620.985 + xs, -323.023 + zs);
            grc.AddNodePtxz("osm1488880605", -621.666 + xs, -312.649 + zs);
            grc.AddNodePtxz("osm1488880308", -616.709 + xs, -316.418 + zs);
            grc.AddNodePtxz("osm1488880163", -612.031 + xs, -309.715 + zs);
            grc.AddNodePtxz("osm1488880465", -601.280 + xs, -316.951 + zs);
            grc.AddNodePtxz("osm4846255736", -603.375 + xs, -320.123 + zs);
            grc.AddNodePtxz("osm4846255735", -603.258 + xs, -321.398 + zs);
            grc.AddNodePtxz("osm1488880395", -597.069 + xs, -320.983 + zs);
            grc.AddNodePtxz("osm1488880270", -596.398 + xs, -327.533 + zs);
            grc.AddNodePtxz("osm1488880372", -584.381 + xs, -326.311 + zs);
            grc.AddNodePtxz("osm1488880154", -585.590 + xs, -312.078 + zs);
            grc.AddNodePtxz("osm1488880182", -587.346 + xs, -312.252 + zs);
            grc.AddNodePtxz("osm7239216350", -587.644 + xs, -309.621 + zs);
            grc.AddNodePtxz("osm7239216355", -587.865 + xs, -307.209 + zs);
            grc.AddNodePtxz("osm1488880439", -588.470 + xs, -299.606 + zs);
            grc.AddNodePtxz("osm4274320606", -580.079 + xs, -298.808 + zs);
            grc.AddNodePtxz("osm4274320605", -580.157 + xs, -297.108 + zs);
            grc.AddNodePtxz("osm4846255734", -568.514 + xs, -296.465 + zs);
            grc.AddNodePtxz("osm4846255733", -568.182 + xs, -298.958 + zs);
            grc.AddNodePtxz("osm1488880314", -561.859 + xs, -298.385 + zs);
            grc.AddNodePtxz("osm1488880178", -558.559 + xs, -333.900 + zs);
            grc.AddNodePtxz("osm1488880209", -551.994 + xs, -333.617 + zs);
            grc.AddNodePtxz("osm4856079655", -551.335 + xs, -339.863 + zs);
            grc.AddNodePtxz("osm4846255732", -550.357 + xs, -339.758 + zs);
            grc.AddNodePtxz("osm4856079656", -550.268 + xs, -340.615 + zs);
            grc.AddNodePtxz("osm4846255731", -549.435 + xs, -340.503 + zs);
            grc.AddNodePtxz("osm4856079657", -548.434 + xs, -351.084 + zs);
            grc.AddNodePtxz("osm4856079658", -549.224 + xs, -351.117 + zs);
            grc.AddNodePtxz("osm4846255730", -549.179 + xs, -352.021 + zs);
            grc.AddNodePtxz("osm4846255729", -550.106 + xs, -352.100 + zs);
            grc.AddNodePtxz("osm1488880213", -549.739 + xs, -358.557 + zs);
            grc.AddNodePtxz("osm7516957565", -566.010 + xs, -359.961 + zs);
            grc.AddNodePtxz("osm7516983686", -568.032 + xs, -360.115 + zs);
            grc.AddNodePtxz("osm1488880207", -571.859 + xs, -360.371 + zs);
            grc.AddNodePtxz("osm7291607566", -573.047 + xs, -366.497 + zs);
            grc.AddNodePtxz("osm7516983687", -569.336 + xs, -367.088 + zs);
            grc.AddNodePtxz("osm7291607565", -567.893 + xs, -367.402 + zs);
            grc.AddNodePtxz("osm7516983685", -568.473 + xs, -370.318 + zs);
            grc.AddNodePtxz("osm1488880604", -568.755 + xs, -371.634 + zs);
            grc.AddNodePtxz("osm1488880302", -544.229 + xs, -376.070 + zs);
            grc.AddNodePtxz("osm1488880400", -543.917 + xs, -374.371 + zs);
            grc.AddNodePtxz("osm1488880267", -531.272 + xs, -376.617 + zs);
            grc.AddNodePtxz("osm7239216384", -531.468 + xs, -377.841 + zs);
            grc.AddNodePtxz("osm4846295260", -532.514 + xs, -384.607 + zs);
            grc.AddNodePtxz("osm4856079661", -532.578 + xs, -385.231 + zs);
            grc.AddNodePtxz("osm4846295261", -531.459 + xs, -385.395 + zs);
            grc.AddNodePtxz("osm4856079662", -533.090 + xs, -395.973 + zs);
            grc.AddNodePtxz("osm4856079663", -534.144 + xs, -395.859 + zs);
            grc.AddNodePtxz("osm4846295262", -534.344 + xs, -397.005 + zs);
            grc.AddNodePtxz("osm4846295263", -536.379 + xs, -396.585 + zs);
            grc.AddNodePtxz("osm1488880315", -427.953 + xs, -399.809 + zs);
            grc.AddNodePtxz("osm1488880534", -449.476 + xs, -395.826 + zs);
            grc.AddNodePtxz("osm1488880441", -447.145 + xs, -388.588 + zs);
            grc.AddNodePtxz("osm1488880430", -448.487 + xs, -388.295 + zs);
            grc.AddNodePtxz("osm1488880229", -452.925 + xs, -378.843 + zs);
            grc.AddNodePtxz("osm1488880549", -459.776 + xs, -379.390 + zs);
            grc.AddNodePtxz("osm1488902093", -462.395 + xs, -348.570 + zs);
            grc.AddNodePtxz("osm1488880280", -457.280 + xs, -349.061 + zs);
            grc.AddNodePtxz("osm4829305389", -457.487 + xs, -345.614 + zs);
            grc.AddNodePtxz("osm4829305388", -454.668 + xs, -343.461 + zs);
            grc.AddNodePtxz("osm4829305387", -458.687 + xs, -339.744 + zs);
            grc.AddNodePtxz("osm4829305386", -432.951 + xs, -321.982 + zs);
            grc.AddNodePtxz("osm4829305385", -430.480 + xs, -325.493 + zs);
            grc.AddNodePtxz("osm1488880585", -423.050 + xs, -320.042 + zs);
            grc.AddNodePtxz("osm1488880601", -420.695 + xs, -323.426 + zs);
            grc.AddNodePtxz("osm1488880615", -414.166 + xs, -323.306 + zs);
            grc.AddNodePtxz("osm1488880261", -411.434 + xs, -347.220 + zs);
            grc.AddNodePtxz("osm1488880345", -412.945 + xs, -348.292 + zs);
            grc.AddNodePtxz("osm1538630559", -412.406 + xs, -349.795 + zs);
            grc.AddNodePtxz("osm4829305378", -406.360 + xs, -366.649 + zs);
            grc.AddNodePtxz("osm4829305376", -405.159 + xs, -369.969 + zs);
            grc.AddNodePtxz("osm1488880596", -404.670 + xs, -371.362 + zs);
            grc.AddNodePtxz("osm4829305375", -419.186 + xs, -376.656 + zs);
            grc.AddNodePtxz("osm1488880471", -419.685 + xs, -375.235 + zs);
            grc.AddNodePtxz("osm4829305374", -421.679 + xs, -375.941 + zs);
            grc.AddNodePtxz("osm1488880306", -420.296 + xs, -391.374 + zs);
            grc.AddNodePtxz("osm1488880192", -426.894 + xs, -394.020 + zs);
            grc.AddNodePtxz("osm1488880222", -293.750 + xs, -445.848 + zs);
            grc.AddNodePtxz("osm7469351355", -294.241 + xs, -440.820 + zs);
            grc.AddNodePtxz("osm7469351330", -294.771 + xs, -435.647 + zs);
            grc.AddNodePtxz("osm1488880187", -294.990 + xs, -433.480 + zs);
            grc.AddNodePtxz("osm1488880169", -292.978 + xs, -433.329 + zs);
            grc.AddNodePtxz("osm1488880365", -294.418 + xs, -416.958 + zs);
            grc.AddNodePtxz("osm1488880366", -306.662 + xs, -421.197 + zs);
            grc.AddNodePtxz("osm1488880588", -303.184 + xs, -430.803 + zs);
            grc.AddNodePtxz("osm4856281098", -309.776 + xs, -433.163 + zs);
            grc.AddNodePtxz("osm4856281099", -308.984 + xs, -435.284 + zs);
            grc.AddNodePtxz("osm4856281100", -319.076 + xs, -438.866 + zs);
            grc.AddNodePtxz("osm4856281101", -319.783 + xs, -436.850 + zs);
            grc.AddNodePtxz("osm1488880483", -326.525 + xs, -439.356 + zs);
            grc.AddNodePtxz("osm1488880174", -328.776 + xs, -433.077 + zs);
            grc.AddNodePtxz("osm1488880168", -354.753 + xs, -442.723 + zs);
            grc.AddNodePtxz("osm4823527349", -356.908 + xs, -436.854 + zs);
            grc.AddNodePtxz("osm4823527348", -358.651 + xs, -437.466 + zs);
            grc.AddNodePtxz("osm4823527347", -359.018 + xs, -436.523 + zs);
            grc.AddNodePtxz("osm4823527346", -359.931 + xs, -436.811 + zs);
            grc.AddNodePtxz("osm4823527345", -363.539 + xs, -426.767 + zs);
            grc.AddNodePtxz("osm4823527344", -362.799 + xs, -426.490 + zs);
            grc.AddNodePtxz("osm4823527343", -363.055 + xs, -425.793 + zs);
            grc.AddNodePtxz("osm4823527350", -362.368 + xs, -425.534 + zs);
            grc.AddNodePtxz("osm1488880179", -365.075 + xs, -418.056 + zs);
            grc.AddNodePtxz("osm1488880455", -353.325 + xs, -413.788 + zs);
            grc.AddNodePtxz("osm1488880470", -352.857 + xs, -415.323 + zs);
            grc.AddNodePtxz("osm7529022829", -330.970 + xs, -407.402 + zs);
            grc.AddNodePtxz("osm1488880426", -325.997 + xs, -405.605 + zs);
            grc.AddNodePtxz("osm7227686559", -327.453 + xs, -401.691 + zs);
            grc.AddNodePtxz("osm1488880215", -330.035 + xs, -394.741 + zs);
            grc.AddNodePtxz("osm1488880266", -350.671 + xs, -396.815 + zs);
            grc.AddNodePtxz("osm4856281097", -351.135 + xs, -390.653 + zs);
            grc.AddNodePtxz("osm4856281096", -352.108 + xs, -390.772 + zs);
            grc.AddNodePtxz("osm4856281095", -352.261 + xs, -389.866 + zs);
            grc.AddNodePtxz("osm4856281094", -353.112 + xs, -389.896 + zs);
            grc.AddNodePtxz("osm4856281093", -353.997 + xs, -379.307 + zs);
            grc.AddNodePtxz("osm4856281092", -353.249 + xs, -379.154 + zs);
            grc.AddNodePtxz("osm4856281091", -353.300 + xs, -378.268 + zs);
            grc.AddNodePtxz("osm4856281090", -352.387 + xs, -378.114 + zs);
            grc.AddNodePtxz("osm1488880472", -352.894 + xs, -372.133 + zs);
            grc.AddNodePtxz("osm1488880546", -346.297 + xs, -371.467 + zs);
            grc.AddNodePtxz("osm7529022870", -346.838 + xs, -350.264 + zs);
            grc.AddNodePtxz("osm4856281088", -341.826 + xs, -349.824 + zs);
            grc.AddNodePtxz("osm4856281083", -342.004 + xs, -347.366 + zs);
            grc.AddNodePtxz("osm4856281082", -330.494 + xs, -346.348 + zs);
            grc.AddNodePtxz("osm4856281081", -330.306 + xs, -348.058 + zs);
            grc.AddNodePtxz("osm7529022878", -327.194 + xs, -347.682 + zs);
            grc.AddNodePtxz("osm1488880638", -321.660 + xs, -347.015 + zs);
            grc.AddNodePtxz("osm7529022877", -320.837 + xs, -355.241 + zs);
            grc.AddNodePtxz("osm7463723852", -320.602 + xs, -357.355 + zs);
            grc.AddNodePtxz("osm1488880263", -320.437 + xs, -359.437 + zs);
            grc.AddNodePtxz("osm1488880234", -322.057 + xs, -359.596 + zs);
            grc.AddNodePtxz("osm1488880151", -321.659 + xs, -363.618 + zs);
            grc.AddNodePtxz("osm1488880637", -309.838 + xs, -362.613 + zs);
            grc.AddNodePtxz("osm7463723855", -310.111 + xs, -358.944 + zs);
            grc.AddNodePtxz("osm1488880566", -310.368 + xs, -356.093 + zs);
            grc.AddNodePtxz("osm1488880227", -306.542 + xs, -355.702 + zs);
            grc.AddNodePtxz("osm7463723863", -306.738 + xs, -353.227 + zs);
            grc.AddNodePtxz("osm1488880481", -307.569 + xs, -345.114 + zs);
            grc.AddNodePtxz("osm1488880153", -287.041 + xs, -343.235 + zs);
            grc.AddNodePtxz("osm4823592286", -286.698 + xs, -347.237 + zs);
            grc.AddNodePtxz("osm4823592282", -292.899 + xs, -347.887 + zs);
            grc.AddNodePtxz("osm4823592284", -292.317 + xs, -353.343 + zs);
            grc.AddNodePtxz("osm4856298096", -291.541 + xs, -353.268 + zs);
            grc.AddNodePtxz("osm4856298095", -291.467 + xs, -354.320 + zs);
            grc.AddNodePtxz("osm4823592283", -285.384 + xs, -353.972 + zs);
            grc.AddNodePtxz("osm7469351336", -284.989 + xs, -357.853 + zs);
            grc.AddNodePtxz("osm7529076186", -284.860 + xs, -359.496 + zs);
            grc.AddNodePtxz("osm1488880343", -284.757 + xs, -360.562 + zs);
            grc.AddNodePtxz("osm7529076185", -277.000 + xs, -359.807 + zs);
            grc.AddNodePtxz("osm7227704435", -274.867 + xs, -359.600 + zs);
            grc.AddNodePtxz("osm1488880589", -257.379 + xs, -358.033 + zs);
            grc.AddNodePtxz("osm7529076211", -257.051 + xs, -362.935 + zs);
            grc.AddNodePtxz("osm4856281118", -256.914 + xs, -365.003 + zs);
            grc.AddNodePtxz("osm4856281117", -253.635 + xs, -364.768 + zs);
            grc.AddNodePtxz("osm4856281116", -252.670 + xs, -375.583 + zs);
            grc.AddNodePtxz("osm4856281115", -254.396 + xs, -375.674 + zs);
            grc.AddNodePtxz("osm7529076214", -254.228 + xs, -378.001 + zs);
            grc.AddNodePtxz("osm7529076215", -253.829 + xs, -383.877 + zs);
            grc.AddNodePtxz("osm1488880587", -253.790 + xs, -384.355 + zs);
            grc.AddNodePtxz("osm7529076196", -264.506 + xs, -385.386 + zs);
            grc.AddNodePtxz("osm4856281086", -265.958 + xs, -385.550 + zs);
            grc.AddNodePtxz("osm4856281087", -266.060 + xs, -384.119 + zs);
            grc.AddNodePtxz("osm7529076187", -276.437 + xs, -384.804 + zs);
            grc.AddNodePtxz("osm1488880194", -282.217 + xs, -385.175 + zs);
            grc.AddNodePtxz("osm7227704424", -280.330 + xs, -390.248 + zs);
            grc.AddNodePtxz("osm1488880300", -277.892 + xs, -396.757 + zs);
            grc.AddNodePtxz("osm1488880250", -264.675 + xs, -396.098 + zs);
            grc.AddNodePtxz("osm7227704416", -264.364 + xs, -401.116 + zs);
            grc.AddNodePtxz("osm7469351344", -264.317 + xs, -402.090 + zs);
            grc.AddNodePtxz("osm4856281114", -263.070 + xs, -401.980 + zs);
            grc.AddNodePtxz("osm7469351343", -262.979 + xs, -402.741 + zs);
            grc.AddNodePtxz("osm4856281113", -262.035 + xs, -402.711 + zs);
            grc.AddNodePtxz("osm4856281112", -261.117 + xs, -413.693 + zs);
            grc.AddNodePtxz("osm7469351342", -261.985 + xs, -413.808 + zs);
            grc.AddNodePtxz("osm4856281111", -261.918 + xs, -414.569 + zs);
            grc.AddNodePtxz("osm7469351341", -262.785 + xs, -414.723 + zs);
            grc.AddNodePtxz("osm7469351334", -262.654 + xs, -416.136 + zs);
            grc.AddNodePtxz("osm1488880340", -262.237 + xs, -420.888 + zs);
            grc.AddNodePtxz("osm1488880321", -269.138 + xs, -421.223 + zs);
            grc.AddNodePtxz("osm1488880533", -266.909 + xs, -442.529 + zs);
            grc.AddNodePtxz("osm7469351333", -271.262 + xs, -442.799 + zs);
            grc.AddNodePtxz("osm4856281108", -273.464 + xs, -442.912 + zs);
            grc.AddNodePtxz("osm4856281102", -273.357 + xs, -444.729 + zs);
            grc.AddNodePtxz("osm4856281103", -274.251 + xs, -444.805 + zs);
            grc.AddNodePtxz("osm4856281109", -274.195 + xs, -445.736 + zs);
            grc.AddNodePtxz("osm4856281107", -284.575 + xs, -446.613 + zs);
            grc.AddNodePtxz("osm4856281105", -284.756 + xs, -445.795 + zs);
            grc.AddNodePtxz("osm4856281106", -285.518 + xs, -445.977 + zs);
            grc.AddNodePtxz("osm4856281104", -285.661 + xs, -445.202 + zs);
            grc.AddNodePtxz("osm7469351353", -286.910 + xs, -445.305 + zs);
            grc.AddNodePtxz("osm1491011768", -438.671 + xs, -300.176 + zs);
            grc.AddNodePtxz("osm7516983719", -441.226 + xs, -292.963 + zs);
            grc.AddNodePtxz("osm1491011759", -446.422 + xs, -279.137 + zs);
            grc.AddNodePtxz("osm1491011811", -441.338 + xs, -277.286 + zs);
            grc.AddNodePtxz("osm7245133474", -438.321 + xs, -285.513 + zs);
            grc.AddNodePtxz("osm7516983718", -437.157 + xs, -288.560 + zs);
            grc.AddNodePtxz("osm1491011758", -433.560 + xs, -298.371 + zs);
            grc.AddNodePtxz("osm1491102463", -14.767 + xs, -321.887 + zs);
            grc.AddNodePtxz("osm7609699088", -40.677 + xs, -324.095 + zs);
            grc.AddNodePtxz("osm7609699089", -39.320 + xs, -326.648 + zs);
            grc.AddNodePtxz("osm1491102453", -40.108 + xs, -326.926 + zs);
            grc.AddNodePtxz("osm1491102459", -42.748 + xs, -322.396 + zs);
            grc.AddNodePtxz("osm7609680981", -45.173 + xs, -317.000 + zs);
            grc.AddNodePtxz("osm7609680979", -46.300 + xs, -312.276 + zs);
            grc.AddNodePtxz("osm7609680980", -46.991 + xs, -305.938 + zs);
            grc.AddNodePtxz("osm1491102462", -48.690 + xs, -306.005 + zs);
            grc.AddNodePtxz("osm7609680978", -54.857 + xs, -218.700 + zs);
            grc.AddNodePtxz("osm7609699085", -28.448 + xs, -217.073 + zs);
            grc.AddNodePtxz("osm7609699086", -30.160 + xs, -214.214 + zs);
            grc.AddNodePtxz("osm7609699087", -29.491 + xs, -214.001 + zs);
            grc.AddNodePtxz("osm1491102458", -27.522 + xs, -217.192 + zs);
            grc.AddNodePtxz("osm1491102465", -25.113 + xs, -222.609 + zs);
            grc.AddNodePtxz("osm6946131604", -23.666 + xs, -228.142 + zs);
            grc.AddNodePtxz("osm1491102452", -22.861 + xs, -234.837 + zs);
            grc.AddNodePtxz("osm1491102451", -20.815 + xs, -234.786 + zs);
            grc.AddNodePtxz("osm1738823951", -370.076 + xs, -757.432 + zs);
            grc.AddNodePtxz("osm4886187130", -371.236 + xs, -754.129 + zs);
            grc.AddNodePtxz("osm4886187129", -366.680 + xs, -752.253 + zs);
            grc.AddNodePtxz("osm1738823950", -373.231 + xs, -734.463 + zs);
            grc.AddNodePtxz("osm1738823952", -381.443 + xs, -737.115 + zs);
            grc.AddNodePtxz("osm1738823953", -385.849 + xs, -723.993 + zs);
            grc.AddNodePtxz("osm4892667585", -410.478 + xs, -732.203 + zs);
            grc.AddNodePtxz("osm1738823959", -437.523 + xs, -741.224 + zs);
            grc.AddNodePtxz("osm4886187128", -435.891 + xs, -745.774 + zs);
            grc.AddNodePtxz("osm4886187127", -445.722 + xs, -748.720 + zs);
            grc.AddNodePtxz("osm1738823960", -459.067 + xs, -724.582 + zs);
            grc.AddNodePtxz("osm1738823961", -485.550 + xs, -733.189 + zs);
            grc.AddNodePtxz("osm1738823962", -484.051 + xs, -737.460 + zs);
            grc.AddNodePtxz("osm1738823963", -488.426 + xs, -738.910 + zs);
            grc.AddNodePtxz("osm1738823965", -470.067 + xs, -791.647 + zs);
            grc.AddNodePtxz("osm1738823957", -425.234 + xs, -777.511 + zs);
            grc.AddNodePtxz("osm1738823958", -424.274 + xs, -780.247 + zs);
            grc.AddNodePtxz("osm4886187126", -422.383 + xs, -779.584 + zs);
            grc.AddNodePtxz("osm4886187125", -423.772 + xs, -775.727 + zs);
            grc.AddNodePtxz("osm4886187124", -422.445 + xs, -775.273 + zs);
            grc.AddNodePtxz("osm4886187123", -421.022 + xs, -778.287 + zs);
            grc.AddNodePtxz("osm1738823956", -413.371 + xs, -775.683 + zs);
            grc.AddNodePtxz("osm1738823955", -414.541 + xs, -773.256 + zs);
            grc.AddNodePtxz("osm1738823929", -224.304 + xs, -645.337 + zs);
            grc.AddNodePtxz("osm1738823930", -222.812 + xs, -649.587 + zs);
            grc.AddNodePtxz("osm1738823927", -218.758 + xs, -648.199 + zs);
            grc.AddNodePtxz("osm1738823928", -200.943 + xs, -700.765 + zs);
            grc.AddNodePtxz("osm4886186915", -232.132 + xs, -712.401 + zs);
            grc.AddNodePtxz("osm4886286145", -244.736 + xs, -717.025 + zs);
            grc.AddNodePtxz("osm4886286146", -243.997 + xs, -719.466 + zs);
            grc.AddNodePtxz("osm4886186918", -245.982 + xs, -720.129 + zs);
            grc.AddNodePtxz("osm4886186919", -247.211 + xs, -716.763 + zs);
            grc.AddNodePtxz("osm1738823936", -248.305 + xs, -717.209 + zs);
            grc.AddNodePtxz("osm1738823937", -247.534 + xs, -719.742 + zs);
            grc.AddNodePtxz("osm1738823939", -255.213 + xs, -722.299 + zs);
            grc.AddNodePtxz("osm1738823938", -256.168 + xs, -719.577 + zs);
            grc.AddNodePtxz("osm4886186920", -278.249 + xs, -727.080 + zs);
            grc.AddNodePtxz("osm4886186913", -301.046 + xs, -734.829 + zs);
            grc.AddNodePtxz("osm4886186914", -302.316 + xs, -731.177 + zs);
            grc.AddNodePtxz("osm1738823943", -306.640 + xs, -731.698 + zs);
            grc.AddNodePtxz("osm1738823942", -313.107 + xs, -713.879 + zs);
            grc.AddNodePtxz("osm1738823941", -304.556 + xs, -710.849 + zs);
            grc.AddNodePtxz("osm1738823940", -309.019 + xs, -698.134 + zs);
            grc.AddNodePtxz("osm4886187121", -257.616 + xs, -680.735 + zs);
            grc.AddNodePtxz("osm4886187122", -256.032 + xs, -685.215 + zs);
            grc.AddNodePtxz("osm1738823934", -246.522 + xs, -681.991 + zs);
            grc.AddNodePtxz("osm1738823932", -251.261 + xs, -654.779 + zs);
            grc.AddNodePtxz("osm4017339902", 306.811 + xs, 125.297 + zs);
            grc.AddNodePtxz("osm4017339903", 316.355 + xs, 103.184 + zs);
            grc.AddNodePtxz("osm4049735568", 32.848 + xs, -258.137 + zs);
            grc.AddNodePtxz("osm4049735529", 33.034 + xs, -260.616 + zs);
            grc.AddNodePtxz("osm4049735579", 21.407 + xs, -261.404 + zs);
            grc.AddNodePtxz("osm4049735522", 22.366 + xs, -274.218 + zs);
            grc.AddNodePtxz("osm6301563931", 24.728 + xs, -274.058 + zs);
            grc.AddNodePtxz("osm4049735533", 37.539 + xs, -273.182 + zs);
            grc.AddNodePtxz("osm4049735569", 36.394 + xs, -257.889 + zs);
            grc.AddNodePtxz("osm6301563932", 59.686 + xs, -256.490 + zs);
            grc.AddNodePtxz("osm4049735539", 67.547 + xs, -255.763 + zs);
            grc.AddNodePtxz("osm4049735542", 68.048 + xs, -262.500 + zs);
            grc.AddNodePtxz("osm7184471215", 59.984 + xs, -263.288 + zs);
            grc.AddNodePtxz("osm4049735574", 42.427 + xs, -264.791 + zs);
            grc.AddNodePtxz("osm4049735559", 44.072 + xs, -289.711 + zs);
            grc.AddNodePtxz("osm4049735586", 104.759 + xs, -285.316 + zs);
            grc.AddNodePtxz("osm4049735532", 102.838 + xs, -259.509 + zs);
            grc.AddNodePtxz("osm4049735541", 84.854 + xs, -260.738 + zs);
            grc.AddNodePtxz("osm4049735578", 83.666 + xs, -244.851 + zs);
            grc.AddNodePtxz("osm4049735567", 85.025 + xs, -244.758 + zs);
            grc.AddNodePtxz("osm4049735551", 84.159 + xs, -233.149 + zs);
            grc.AddNodePtxz("osm4049735585", 80.403 + xs, -233.405 + zs);
            grc.AddNodePtxz("osm4823322839", 79.998 + xs, -227.848 + zs);
            grc.AddNodePtxz("osm4823322838", 89.686 + xs, -227.185 + zs);
            grc.AddNodePtxz("osm4823322837", 88.851 + xs, -216.033 + zs);
            grc.AddNodePtxz("osm4823322836", 64.486 + xs, -217.704 + zs);
            grc.AddNodePtxz("osm7184471210", 64.021 + xs, -210.060 + zs);
            grc.AddNodePtxz("osm7184471212", 84.350 + xs, -208.654 + zs);
            grc.AddNodePtxz("osm7184471213", 82.809 + xs, -195.359 + zs);
            grc.AddNodePtxz("osm7184471211", 62.957 + xs, -196.879 + zs);
            grc.AddNodePtxz("osm4049736489", 62.421 + xs, -190.108 + zs);
            grc.AddNodePtxz("osm6306188958", 53.782 + xs, -190.705 + zs);
            grc.AddNodePtxz("osm6306188954", 50.257 + xs, -190.945 + zs);
            grc.AddNodePtxz("osm4049735580", 7.736 + xs, -193.857 + zs);
            grc.AddNodePtxz("osm6306188955", 9.570 + xs, -218.340 + zs);
            grc.AddNodePtxz("osm6306188948", 10.032 + xs, -224.495 + zs);
            grc.AddNodePtxz("osm4049735554", 12.653 + xs, -259.521 + zs);
            grc.AddNodePtxz("osm4621191630", -474.257 + xs, -489.607 + zs);
            grc.AddNodePtxz("osm7230628375", -478.833 + xs, -477.477 + zs);
            grc.AddNodePtxz("osm7245130935", -479.899 + xs, -474.642 + zs);
            grc.AddNodePtxz("osm4621191631", -482.550 + xs, -467.628 + zs);
            grc.AddNodePtxz("osm7245130934", -483.188 + xs, -467.862 + zs);
            grc.AddNodePtxz("osm7245130921", -484.868 + xs, -468.485 + zs);
            grc.AddNodePtxz("osm7245130910", -486.446 + xs, -469.065 + zs);
            grc.AddNodePtxz("osm4621191632", -488.161 + xs, -469.692 + zs);
            grc.AddNodePtxz("osm7245130909", -486.641 + xs, -473.718 + zs);
            grc.AddNodePtxz("osm7245130922", -484.474 + xs, -479.488 + zs);
            grc.AddNodePtxz("osm7230628376", -483.192 + xs, -482.906 + zs);
            grc.AddNodePtxz("osm4621191633", -479.878 + xs, -491.674 + zs);
            grc.AddNodePtxz("osm4621191634", -440.963 + xs, -581.432 + zs);
            grc.AddNodePtxz("osm4621191635", -443.832 + xs, -573.526 + zs);
            grc.AddNodePtxz("osm4621191636", -448.450 + xs, -575.059 + zs);
            grc.AddNodePtxz("osm4621191637", -445.735 + xs, -582.962 + zs);
            grc.AddNodePtxz("osm4621191639", -348.309 + xs, -529.172 + zs);
            grc.AddNodePtxz("osm4621191640", -351.216 + xs, -521.327 + zs);
            grc.AddNodePtxz("osm4621191641", -355.625 + xs, -522.948 + zs);
            grc.AddNodePtxz("osm7230628164", -355.332 + xs, -523.750 + zs);
            grc.AddNodePtxz("osm4621191642", -352.727 + xs, -530.835 + zs);
            grc.AddNodePtxz("osm4621191650", -382.853 + xs, -434.828 + zs);
            grc.AddNodePtxz("osm7227704290", -386.204 + xs, -425.717 + zs);
            grc.AddNodePtxz("osm7227704272", -387.179 + xs, -423.073 + zs);
            grc.AddNodePtxz("osm4621191652", -390.592 + xs, -413.888 + zs);
            grc.AddNodePtxz("osm4621191653", -395.697 + xs, -415.747 + zs);
            grc.AddNodePtxz("osm7227704285", -392.403 + xs, -424.592 + zs);
            grc.AddNodePtxz("osm7227704280", -391.301 + xs, -427.565 + zs);
            grc.AddNodePtxz("osm4621191655", -387.967 + xs, -436.658 + zs);
            grc.AddNodePtxz("osm7227704291", -385.086 + xs, -435.624 + zs);
            grc.AddNodePtxz("osm5818373711", 361.415 + xs, -194.101 + zs);
            grc.AddNodePtxz("osm5818373712", 367.108 + xs, -182.828 + zs);
            grc.AddNodePtxz("osm5818373713", 322.691 + xs, -161.652 + zs);
            grc.AddNodePtxz("osm5818373714", 317.884 + xs, -171.045 + zs);
            grc.AddNodePtxz("osm5916951862", -292.568 + xs, -44.845 + zs);
            grc.AddNodePtxz("osm5916951863", -348.645 + xs, -56.929 + zs);
            grc.AddNodePtxz("osm5916951864", -353.787 + xs, -28.264 + zs);
            grc.AddNodePtxz("osm5916951865", -342.475 + xs, -26.110 + zs);
            grc.AddNodePtxz("osm5916951866", -329.990 + xs, -23.801 + zs);
            grc.AddNodePtxz("osm5916951867", -318.853 + xs, -25.382 + zs);
            grc.AddNodePtxz("osm5916951868", -305.292 + xs, -31.046 + zs);
            grc.AddNodePtxz("osm5916951869", -297.104 + xs, -36.829 + zs);
            grc.AddNodePtxz("osm6042865823", -473.628 + xs, -512.640 + zs);
            grc.AddNodePtxz("osm6042865824", -477.039 + xs, -503.257 + zs);
            grc.AddNodePtxz("osm6042865825", -471.480 + xs, -501.283 + zs);
            grc.AddNodePtxz("osm6042865826", -468.076 + xs, -510.677 + zs);
            grc.AddNodePtxz("osm6042865847", -355.529 + xs, -520.903 + zs);
            grc.AddNodePtxz("osm6042865848", -358.295 + xs, -513.191 + zs);
            grc.AddNodePtxz("osm6042865849", -352.736 + xs, -511.249 + zs);
            grc.AddNodePtxz("osm7230628207", -350.793 + xs, -516.651 + zs);
            grc.AddNodePtxz("osm6042865850", -349.973 + xs, -518.953 + zs);
            grc.AddNodePtxz("osm7230628208", -351.790 + xs, -519.591 + zs);
            grc.AddNodePtxz("osm6042865853", -372.015 + xs, -476.222 + zs);
            grc.AddNodePtxz("osm6042865854", -375.773 + xs, -466.490 + zs);
            grc.AddNodePtxz("osm6042865855", -370.335 + xs, -464.438 + zs);
            grc.AddNodePtxz("osm6042865856", -366.577 + xs, -474.170 + zs);
            grc.AddNodePtxz("osm6323277626", 118.816 + xs, -346.030 + zs);
            grc.AddNodePtxz("osm6323277627", 161.958 + xs, -343.174 + zs);
            grc.AddNodePtxz("osm321549947", 159.186 + xs, -300.896 + zs);
            grc.AddNodePtxz("osm6323277623", 92.676 + xs, -305.874 + zs);
            grc.AddNodePtxz("osm6323443766", 291.536 + xs, -538.434 + zs);
            grc.AddNodePtxz("osm6323443767", 283.499 + xs, -515.101 + zs);
            grc.AddNodePtxz("osm6323443768", 320.968 + xs, -503.073 + zs);
            grc.AddNodePtxz("osm6323443769", 312.290 + xs, -478.351 + zs);
            grc.AddNodePtxz("osm321549340", 333.550 + xs, -471.501 + zs);
            grc.AddNodePtxz("osm6323443770", 348.350 + xs, -511.578 + zs);
            grc.AddNodePtxz("osm6323443771", 326.465 + xs, -518.262 + zs);
            grc.AddNodePtxz("osm6323443772", 328.991 + xs, -525.929 + zs);
            grc.AddNodePtxz("osm6323443773", 285.981 + xs, -502.813 + zs);
            grc.AddNodePtxz("osm6323443774", 301.893 + xs, -497.531 + zs);
            grc.AddNodePtxz("osm6323443775", 293.167 + xs, -473.142 + zs);
            grc.AddNodePtxz("osm4809166490", 325.631 + xs, -461.846 + zs);
            grc.AddNodePtxz("osm6323443776", 328.756 + xs, -460.800 + zs);
            grc.AddNodePtxz("osm6323443777", 321.393 + xs, -440.294 + zs);
            grc.AddNodePtxz("osm6323443778", 278.403 + xs, -455.011 + zs);
            grc.AddNodePtxz("osm6323443779", 279.932 + xs, -459.803 + zs);
            grc.AddNodePtxz("osm6323443780", 275.937 + xs, -461.329 + zs);
            grc.AddNodePtxz("osm6323443781", 281.763 + xs, -479.304 + zs);
            grc.AddNodePtxz("osm6323443782", 278.643 + xs, -480.531 + zs);
            grc.AddNodePtxz("osm6323444289", 380.109 + xs, -524.556 + zs);
            grc.AddNodePtxz("osm6323444302", 389.006 + xs, -521.503 + zs);
            grc.AddNodePtxz("osm6323444301", 387.941 + xs, -518.469 + zs);
            grc.AddNodePtxz("osm6323444299", 392.586 + xs, -516.879 + zs);
            grc.AddNodePtxz("osm6323444300", 393.415 + xs, -519.241 + zs);
            grc.AddNodePtxz("osm6323444290", 416.495 + xs, -511.324 + zs);
            grc.AddNodePtxz("osm6323444291", 415.884 + xs, -509.584 + zs);
            grc.AddNodePtxz("osm6323444306", 420.210 + xs, -508.095 + zs);
            grc.AddNodePtxz("osm6323444305", 420.985 + xs, -510.270 + zs);
            grc.AddNodePtxz("osm6323444304", 430.632 + xs, -506.967 + zs);
            grc.AddNodePtxz("osm6323444303", 427.105 + xs, -496.918 + zs);
            grc.AddNodePtxz("osm6323444292", 432.686 + xs, -495.008 + zs);
            grc.AddNodePtxz("osm6323444293", 424.564 + xs, -471.869 + zs);
            grc.AddNodePtxz("osm6323444294", 418.677 + xs, -473.885 + zs);
            grc.AddNodePtxz("osm6710759980", 411.844 + xs, -454.417 + zs);
            grc.AddNodePtxz("osm6710759981", 408.790 + xs, -455.462 + zs);
            grc.AddNodePtxz("osm6710759982", 401.670 + xs, -435.181 + zs);
            grc.AddNodePtxz("osm6710759983", 399.196 + xs, -436.028 + zs);
            grc.AddNodePtxz("osm6323444295", 396.400 + xs, -428.098 + zs);
            grc.AddNodePtxz("osm6710796286", 388.586 + xs, -430.773 + zs);
            grc.AddNodePtxz("osm6710796287", 390.470 + xs, -436.140 + zs);
            grc.AddNodePtxz("osm6710796285", 387.795 + xs, -437.056 + zs);
            grc.AddNodePtxz("osm6710759984", 385.304 + xs, -429.995 + zs);
            grc.AddNodePtxz("osm6323444296", 350.563 + xs, -441.928 + zs);
            grc.AddNodePtxz("osm6710796289", 354.756 + xs, -453.840 + zs);
            grc.AddNodePtxz("osm6710796288", 352.726 + xs, -454.543 + zs);
            grc.AddNodePtxz("osm6323444297", 373.571 + xs, -513.693 + zs);
            grc.AddNodePtxz("osm6323444298", 375.980 + xs, -512.860 + zs);
            grc.AddNodePtxz("osm6394037164", 460.944 + xs, -162.602 + zs);
            grc.AddNodePtxz("osm6394037165", 451.074 + xs, -134.248 + zs);
            grc.AddNodePtxz("osm6394037166", 378.124 + xs, -159.024 + zs);
            grc.AddNodePtxz("osm6394037167", 383.798 + xs, -175.325 + zs);
            grc.AddNodePtxz("osm6394037168", 391.083 + xs, -172.855 + zs);
            grc.AddNodePtxz("osm6394037169", 395.276 + xs, -184.901 + zs);
            grc.AddNodePtxz("osm6731946651", -560.662 + xs, -63.179 + zs);
            grc.AddNodePtxz("osm6731946652", -610.742 + xs, -89.893 + zs);
            grc.AddNodePtxz("osm6731946653", -611.960 + xs, -87.767 + zs);
            grc.AddNodePtxz("osm6731946654", -668.154 + xs, -116.122 + zs);
            grc.AddNodePtxz("osm7021335915", -650.569 + xs, -152.370 + zs);
            grc.AddNodePtxz("osm7021335916", -541.534 + xs, -100.768 + zs);
            grc.AddNodePtxz("osm6731946656", -528.046 + xs, -101.418 + zs);
            grc.AddNodePtxz("osm6731946657", -525.670 + xs, -105.968 + zs);
            grc.AddNodePtxz("osm5818373709", -543.720 + xs, -114.737 + zs);
            grc.AddNodePtxz("osm7021335914", -546.099 + xs, -109.674 + zs);
            grc.AddNodePtxz("osm7021335926", -534.422 + xs, -104.156 + zs);
            grc.AddNodePtxz("osm7021335927", -536.621 + xs, -99.372 + zs);
            grc.AddNodePtxz("osm7021335928", -540.849 + xs, -101.508 + zs);
            grc.AddNodePtxz("osm7021335925", -545.998 + xs, -91.444 + zs);
            grc.AddNodePtxz("osm7021335932", -528.832 + xs, -82.811 + zs);
            grc.AddNodePtxz("osm7021335933", -526.058 + xs, -88.563 + zs);
            grc.AddNodePtxz("osm7021335934", -529.303 + xs, -90.846 + zs);
            grc.AddNodePtxz("osm7021335935", -528.401 + xs, -93.112 + zs);
            grc.AddNodePtxz("osm7021335936", -531.266 + xs, -94.798 + zs);
            grc.AddNodePtxz("osm7021335929", -530.940 + xs, -95.827 + zs);
            grc.AddNodePtxz("osm7021335931", -532.508 + xs, -96.569 + zs);
            grc.AddNodePtxz("osm7021335930", -529.722 + xs, -102.388 + zs);
            grc.AddNodePtxz("osm7105644029", 93.196 + xs, 182.077 + zs);
            grc.AddNodePtxz("osm7105644030", 92.473 + xs, 184.103 + zs);
            grc.AddNodePtxz("osm7105644031", 95.599 + xs, 185.212 + zs);
            grc.AddNodePtxz("osm7105644032", 96.346 + xs, 183.084 + zs);
            grc.AddNodePtxz("osm7287977451", 232.002 + xs, 158.478 + zs);
            grc.AddNodePtxz("osm7287977452", 229.928 + xs, 164.454 + zs);
            grc.AddNodePtxz("osm7287977453", 225.582 + xs, 162.855 + zs);
            grc.AddNodePtxz("osm7287977455", 212.836 + xs, 147.679 + zs);
            grc.AddNodePtxz("osm7287977456", 210.447 + xs, 154.719 + zs);
            grc.AddNodePtxz("osm7287977457", 205.644 + xs, 153.043 + zs);
            grc.AddNodePtxz("osm7287977495", 205.914 + xs, 152.241 + zs);
            grc.AddNodePtxz("osm7287977458", 208.020 + xs, 146.007 + zs);
            grc.AddNodePtxz("osm7287977473", 190.343 + xs, 151.195 + zs);
            grc.AddNodePtxz("osm7287977472", 184.943 + xs, 149.339 + zs);
            grc.AddNodePtxz("osm7287977479", 187.430 + xs, 142.118 + zs);
            grc.AddNodePtxz("osm7230625679", -531.001 + xs, -596.548 + zs);
            grc.AddNodePtxz("osm7458566173", -534.891 + xs, -591.447 + zs);
            grc.AddNodePtxz("osm7458566174", -544.612 + xs, -598.134 + zs);
            grc.AddNodePtxz("osm7230625680", -540.929 + xs, -603.384 + zs);
            grc.AddNodePtxz("osm7473290619", -425.399 + xs, -15.415 + zs);
            grc.AddNodePtxz("osm7473290620", -438.091 + xs, -19.823 + zs);
            grc.AddNodePtxz("osm7473290621", -437.947 + xs, -20.233 + zs);
            grc.AddNodePtxz("osm7473290622", -440.795 + xs, -21.296 + zs);
            grc.AddNodePtxz("osm7473290623", -440.273 + xs, -23.050 + zs);
            grc.AddNodePtxz("osm7473290624", -436.850 + xs, -21.846 + zs);
            grc.AddNodePtxz("osm7473290625", -437.061 + xs, -21.245 + zs);
            grc.AddNodePtxz("osm7473290626", -424.822 + xs, -16.960 + zs);
            grc.AddNodePtxz("osm7473290627", -525.064 + xs, -44.006 + zs);
            grc.AddNodePtxz("osm7473290628", -525.306 + xs, -42.512 + zs);
            grc.AddNodePtxz("osm7473290629", -528.879 + xs, -43.086 + zs);
            grc.AddNodePtxz("osm7473290630", -528.575 + xs, -44.558 + zs);

            grc.AddLinkByNodeName("osm320996264", "osm320996263", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link1");
            grc.AddLinkByNodeName("osm7132698259", "osm320996264", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link2");
            grc.AddLinkByNodeName("osm320996265", "osm7132698259", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link3");
            grc.AddLinkByNodeName("osm320996266", "osm320996265", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link4");
            grc.AddLinkByNodeName("osm1738823964", "osm320996266", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link5");
            grc.AddLinkByNodeName("osm320996267", "osm1738823964", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link6");
            grc.AddLinkByNodeName("osm320996268", "osm320996267", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link7");
            grc.AddLinkByNodeName("osm320996269", "osm320996268", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link8");
            grc.AddLinkByNodeName("osm4848246453", "osm320996269", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link9");
            grc.AddLinkByNodeName("osm320996270", "osm4848246453", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link10");
            grc.AddLinkByNodeName("osm4848246452", "osm320996270", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link11");
            grc.AddLinkByNodeName("osm4848246447", "osm4848246452", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link12");
            grc.AddLinkByNodeName("osm4848246451", "osm4848246447", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link13");
            grc.AddLinkByNodeName("osm6997351099", "osm4848246451", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link14");
            grc.AddLinkByNodeName("osm4848246455", "osm6997351099", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link15");
            grc.AddLinkByNodeName("osm4848246454", "osm4848246455", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link16");
            grc.AddLinkByNodeName("osm320996271", "osm4848246454", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link17");
            grc.AddLinkByNodeName("osm320996272", "osm320996271", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link18");
            grc.AddLinkByNodeName("osm320996273", "osm320996272", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link19");
            grc.AddLinkByNodeName("osm3734072199", "osm320996273", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link20");
            grc.AddLinkByNodeName("osm320996274", "osm3734072199", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link21");
            grc.AddLinkByNodeName("osm320996275", "osm320996274", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link22");
            grc.AddLinkByNodeName("osm320996276", "osm320996275", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link23");
            grc.AddLinkByNodeName("osm7137804868", "osm320996276", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link24");
            grc.AddLinkByNodeName("osm320996277", "osm7137804868", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link25");
            grc.AddLinkByNodeName("osm4848246446", "osm320996277", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link26");
            grc.AddLinkByNodeName("osm320996278", "osm4848246446", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link27");
            grc.AddLinkByNodeName("osm4886343269", "osm320996278", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link28");
            grc.AddLinkByNodeName("osm320996279", "osm4886343269", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link29");
            grc.AddLinkByNodeName("osm320996280", "osm320996279", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link30");
            grc.AddLinkByNodeName("osm320996263", "osm320996280", usetype: LinkUse.bldwall, comment: "Microsoft Studio E.link31");

            grc.AddLinkByNodeName("osm320996301", "osm320996300", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link1");
            grc.AddLinkByNodeName("osm320996302", "osm320996301", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link2");
            grc.AddLinkByNodeName("osm3734072200", "osm320996302", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link3");
            grc.AddLinkByNodeName("osm4846459991", "osm3734072200", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link4");
            grc.AddLinkByNodeName("osm320996303", "osm4846459991", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link5");
            grc.AddLinkByNodeName("osm3735501418", "osm320996303", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link6");
            grc.AddLinkByNodeName("osm4846459990", "osm3735501418", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link7");
            grc.AddLinkByNodeName("osm320996306", "osm4846459990", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link8");
            grc.AddLinkByNodeName("osm6955760133", "osm320996306", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link9");
            grc.AddLinkByNodeName("osm4846459992", "osm6955760133", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link10");
            grc.AddLinkByNodeName("osm4846459993", "osm4846459992", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link11");
            grc.AddLinkByNodeName("osm4846459986", "osm4846459993", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link12");
            grc.AddLinkByNodeName("osm4846459989", "osm4846459986", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link13");
            grc.AddLinkByNodeName("osm4846459983", "osm4846459989", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link14");
            grc.AddLinkByNodeName("osm4846459982", "osm4846459983", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link15");
            grc.AddLinkByNodeName("osm4846459981", "osm4846459982", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link16");
            grc.AddLinkByNodeName("osm320996307", "osm4846459981", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link17");
            grc.AddLinkByNodeName("osm320996308", "osm320996307", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link18");
            grc.AddLinkByNodeName("osm320996309", "osm320996308", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link19");
            grc.AddLinkByNodeName("osm320996310", "osm320996309", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link20");
            grc.AddLinkByNodeName("osm320996311", "osm320996310", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link21");
            grc.AddLinkByNodeName("osm320996312", "osm320996311", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link22");
            grc.AddLinkByNodeName("osm4846459977", "osm320996312", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link23");
            grc.AddLinkByNodeName("osm320996313", "osm4846459977", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link24");
            grc.AddLinkByNodeName("osm320996315", "osm320996313", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link25");
            grc.AddLinkByNodeName("osm4846459994", "osm320996315", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link26");
            grc.AddLinkByNodeName("osm320996316", "osm4846459994", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link27");
            grc.AddLinkByNodeName("osm320996317", "osm320996316", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link28");
            grc.AddLinkByNodeName("osm4487603939", "osm320996317", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link29");
            grc.AddLinkByNodeName("osm320996318", "osm4487603939", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link30");
            grc.AddLinkByNodeName("osm320996319", "osm320996318", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link31");
            grc.AddLinkByNodeName("osm4846459976", "osm320996319", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link32");
            grc.AddLinkByNodeName("osm320996300", "osm4846459976", usetype: LinkUse.bldwall, comment: "Microsoft Studio H.link33");

            grc.AddLinkByNodeName("osm4809166497", "osm321153936", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link1");
            grc.AddLinkByNodeName("osm4809166496", "osm4809166497", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link2");
            grc.AddLinkByNodeName("osm4809166493", "osm4809166496", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link3");
            grc.AddLinkByNodeName("osm4809166495", "osm4809166493", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link4");
            grc.AddLinkByNodeName("osm4809166494", "osm4809166495", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link5");
            grc.AddLinkByNodeName("osm415453460", "osm4809166494", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link6");
            grc.AddLinkByNodeName("osm321153937", "osm415453460", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link7");
            grc.AddLinkByNodeName("osm415453462", "osm321153937", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link8");
            grc.AddLinkByNodeName("osm415453463", "osm415453462", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link9");
            grc.AddLinkByNodeName("osm321153938", "osm415453463", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link10");
            grc.AddLinkByNodeName("osm4809166508", "osm321153938", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link11");
            grc.AddLinkByNodeName("osm4809166510", "osm4809166508", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link12");
            grc.AddLinkByNodeName("osm4809166511", "osm4809166510", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link13");
            grc.AddLinkByNodeName("osm4809166509", "osm4809166511", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link14");
            grc.AddLinkByNodeName("osm415453464", "osm4809166509", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link15");
            grc.AddLinkByNodeName("osm4809166507", "osm415453464", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link16");
            grc.AddLinkByNodeName("osm4809166506", "osm4809166507", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link17");
            grc.AddLinkByNodeName("osm408723991", "osm4809166506", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link18");
            grc.AddLinkByNodeName("osm321153939", "osm408723991", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link19");
            grc.AddLinkByNodeName("osm6938485969", "osm321153939", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link20");
            grc.AddLinkByNodeName("osm4809166503", "osm6938485969", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link21");
            grc.AddLinkByNodeName("osm4809166504", "osm4809166503", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link22");
            grc.AddLinkByNodeName("osm4809166505", "osm4809166504", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link23");
            grc.AddLinkByNodeName("osm4809166502", "osm4809166505", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link24");
            grc.AddLinkByNodeName("osm321153940", "osm4809166502", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link25");
            grc.AddLinkByNodeName("osm415453465", "osm321153940", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link26");
            grc.AddLinkByNodeName("osm415453466", "osm415453465", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link27");
            grc.AddLinkByNodeName("osm321153941", "osm415453466", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link28");
            grc.AddLinkByNodeName("osm4809166501", "osm321153941", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link29");
            grc.AddLinkByNodeName("osm4809166500", "osm4809166501", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link30");
            grc.AddLinkByNodeName("osm4809166499", "osm4809166500", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link31");
            grc.AddLinkByNodeName("osm4809166498", "osm4809166499", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link32");
            grc.AddLinkByNodeName("osm6938485973", "osm4809166498", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link33");
            grc.AddLinkByNodeName("osm6938485971", "osm6938485973", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link34");
            grc.AddLinkByNodeName("osm6938485970", "osm6938485971", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link35");
            grc.AddLinkByNodeName("osm321153936", "osm6938485970", usetype: LinkUse.bldwall, comment: "Microsoft Building 109.link36");

            grc.AddLinkByNodeName("osm321154351", "osm321154350", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link1");
            grc.AddLinkByNodeName("osm4835357625", "osm321154351", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link2");
            grc.AddLinkByNodeName("osm321154352", "osm4835357625", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link3");
            grc.AddLinkByNodeName("osm3742149263", "osm321154352", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link4");
            grc.AddLinkByNodeName("osm321154353", "osm3742149263", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link5");
            grc.AddLinkByNodeName("osm1704771656", "osm321154353", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link6");
            grc.AddLinkByNodeName("osm1704771644", "osm1704771656", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link7");
            grc.AddLinkByNodeName("osm4736778518", "osm1704771644", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link8");
            grc.AddLinkByNodeName("osm1704771520", "osm4736778518", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link9");
            grc.AddLinkByNodeName("osm1704771542", "osm1704771520", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link10");
            grc.AddLinkByNodeName("osm321154354", "osm1704771542", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link11");
            grc.AddLinkByNodeName("osm321154355", "osm321154354", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link12");
            grc.AddLinkByNodeName("osm6981460230", "osm321154355", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link13");
            grc.AddLinkByNodeName("osm4835357626", "osm6981460230", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link14");
            grc.AddLinkByNodeName("osm321154356", "osm4835357626", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link15");
            grc.AddLinkByNodeName("osm3742149266", "osm321154356", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link16");
            grc.AddLinkByNodeName("osm321154357", "osm3742149266", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link17");
            grc.AddLinkByNodeName("osm1704771464", "osm321154357", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link18");
            grc.AddLinkByNodeName("osm1704771503", "osm1704771464", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link19");
            grc.AddLinkByNodeName("osm1704771636", "osm1704771503", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link20");
            grc.AddLinkByNodeName("osm1704771631", "osm1704771636", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link21");
            grc.AddLinkByNodeName("osm321154350", "osm1704771631", usetype: LinkUse.bldwall, comment: "Microsoft Building 112.link22");

            grc.AddLinkByNodeName("osm321154490", "osm321154489", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link1");
            grc.AddLinkByNodeName("osm4835354485", "osm321154490", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link2");
            grc.AddLinkByNodeName("osm4835354484", "osm4835354485", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link3");
            grc.AddLinkByNodeName("osm321154492", "osm4835354484", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link4");
            grc.AddLinkByNodeName("osm3742149264", "osm321154492", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link5");
            grc.AddLinkByNodeName("osm321154493", "osm3742149264", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link6");
            grc.AddLinkByNodeName("osm3742149276", "osm321154493", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link7");
            grc.AddLinkByNodeName("osm321154494", "osm3742149276", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link8");
            grc.AddLinkByNodeName("osm321154495", "osm321154494", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link9");
            grc.AddLinkByNodeName("osm4835354486", "osm321154495", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link10");
            grc.AddLinkByNodeName("osm321154496", "osm4835354486", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link11");
            grc.AddLinkByNodeName("osm321154497", "osm321154496", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link12");
            grc.AddLinkByNodeName("osm321154489", "osm321154497", usetype: LinkUse.bldwall, comment: "Microsoft Building 113.link13");

            grc.AddLinkByNodeName("osm321154628", "osm321154627", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link1");
            grc.AddLinkByNodeName("osm321154629", "osm321154628", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link2");
            grc.AddLinkByNodeName("osm321154630", "osm321154629", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link3");
            grc.AddLinkByNodeName("osm1704768475", "osm321154630", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link4");
            grc.AddLinkByNodeName("osm1704768497", "osm1704768475", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link5");
            grc.AddLinkByNodeName("osm1704769926", "osm1704768497", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link6");
            grc.AddLinkByNodeName("osm1704769212", "osm1704769926", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link7");
            grc.AddLinkByNodeName("osm321154631", "osm1704769212", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link8");
            grc.AddLinkByNodeName("osm321154632", "osm321154631", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link9");
            grc.AddLinkByNodeName("osm3734091508", "osm321154632", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link10");
            grc.AddLinkByNodeName("osm321154634", "osm3734091508", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link11");
            grc.AddLinkByNodeName("osm321154635", "osm321154634", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link12");
            grc.AddLinkByNodeName("osm1704770015", "osm321154635", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link13");
            grc.AddLinkByNodeName("osm1704769994", "osm1704770015", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link14");
            grc.AddLinkByNodeName("osm3742149277", "osm1704769994", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link15");
            grc.AddLinkByNodeName("osm1704768504", "osm3742149277", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link16");
            grc.AddLinkByNodeName("osm1704768516", "osm1704768504", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link17");
            grc.AddLinkByNodeName("osm321154627", "osm1704768516", usetype: LinkUse.bldwall, comment: "Microsoft Building 115.link18");

            grc.AddLinkByNodeName("osm321154996", "osm321154995", usetype: LinkUse.bldwall, comment: "Microsoft Building 114.link1");
            grc.AddLinkByNodeName("osm321154997", "osm321154996", usetype: LinkUse.bldwall, comment: "Microsoft Building 114.link2");
            grc.AddLinkByNodeName("osm321154998", "osm321154997", usetype: LinkUse.bldwall, comment: "Microsoft Building 114.link3");
            grc.AddLinkByNodeName("osm4835343871", "osm321154998", usetype: LinkUse.bldwall, comment: "Microsoft Building 114.link4");
            grc.AddLinkByNodeName("osm321155000", "osm4835343871", usetype: LinkUse.bldwall, comment: "Microsoft Building 114.link5");
            grc.AddLinkByNodeName("osm321155001", "osm321155000", usetype: LinkUse.bldwall, comment: "Microsoft Building 114.link6");
            grc.AddLinkByNodeName("osm3742149270", "osm321155001", usetype: LinkUse.bldwall, comment: "Microsoft Building 114.link7");
            grc.AddLinkByNodeName("osm321155002", "osm3742149270", usetype: LinkUse.bldwall, comment: "Microsoft Building 114.link8");
            grc.AddLinkByNodeName("osm321155003", "osm321155002", usetype: LinkUse.bldwall, comment: "Microsoft Building 114.link9");
            grc.AddLinkByNodeName("osm4835343869", "osm321155003", usetype: LinkUse.bldwall, comment: "Microsoft Building 114.link10");
            grc.AddLinkByNodeName("osm321154995", "osm4835343869", usetype: LinkUse.bldwall, comment: "Microsoft Building 114.link11");

            grc.AddLinkByNodeName("osm6042866082", "osm321549713", usetype: LinkUse.bldwall, comment: "commercial001.link1");
            grc.AddLinkByNodeName("osm6042866084", "osm6042866082", usetype: LinkUse.bldwall, comment: "commercial001.link2");
            grc.AddLinkByNodeName("osm6978384454", "osm6042866084", usetype: LinkUse.bldwall, comment: "commercial001.link3");
            grc.AddLinkByNodeName("osm6042866083", "osm6978384454", usetype: LinkUse.bldwall, comment: "commercial001.link4");
            grc.AddLinkByNodeName("osm6042866081", "osm6042866083", usetype: LinkUse.bldwall, comment: "commercial001.link5");
            grc.AddLinkByNodeName("osm321549714", "osm6042866081", usetype: LinkUse.bldwall, comment: "commercial001.link6");
            grc.AddLinkByNodeName("osm6042866086", "osm321549714", usetype: LinkUse.bldwall, comment: "commercial001.link7");
            grc.AddLinkByNodeName("osm6978384453", "osm6042866086", usetype: LinkUse.bldwall, comment: "commercial001.link8");
            grc.AddLinkByNodeName("osm6042866088", "osm6978384453", usetype: LinkUse.bldwall, comment: "commercial001.link9");
            grc.AddLinkByNodeName("osm6042866087", "osm6042866088", usetype: LinkUse.bldwall, comment: "commercial001.link10");
            grc.AddLinkByNodeName("osm6042866085", "osm6042866087", usetype: LinkUse.bldwall, comment: "commercial001.link11");
            grc.AddLinkByNodeName("osm321549716", "osm6042866085", usetype: LinkUse.bldwall, comment: "commercial001.link12");
            grc.AddLinkByNodeName("osm321549717", "osm321549716", usetype: LinkUse.bldwall, comment: "commercial001.link13");
            grc.AddLinkByNodeName("osm6042866089", "osm321549717", usetype: LinkUse.bldwall, comment: "commercial001.link14");
            grc.AddLinkByNodeName("osm6042866090", "osm6042866089", usetype: LinkUse.bldwall, comment: "commercial001.link15");
            grc.AddLinkByNodeName("osm6042866091", "osm6042866090", usetype: LinkUse.bldwall, comment: "commercial001.link16");
            grc.AddLinkByNodeName("osm6042866092", "osm6042866091", usetype: LinkUse.bldwall, comment: "commercial001.link17");
            grc.AddLinkByNodeName("osm321549718", "osm6042866092", usetype: LinkUse.bldwall, comment: "commercial001.link18");
            grc.AddLinkByNodeName("osm6042866093", "osm321549718", usetype: LinkUse.bldwall, comment: "commercial001.link19");
            grc.AddLinkByNodeName("osm6042866094", "osm6042866093", usetype: LinkUse.bldwall, comment: "commercial001.link20");
            grc.AddLinkByNodeName("osm6978384469", "osm6042866094", usetype: LinkUse.bldwall, comment: "commercial001.link21");
            grc.AddLinkByNodeName("osm6042866095", "osm6978384469", usetype: LinkUse.bldwall, comment: "commercial001.link22");
            grc.AddLinkByNodeName("osm6042866096", "osm6042866095", usetype: LinkUse.bldwall, comment: "commercial001.link23");
            grc.AddLinkByNodeName("osm6042866097", "osm6042866096", usetype: LinkUse.bldwall, comment: "commercial001.link24");
            grc.AddLinkByNodeName("osm6042866098", "osm6042866097", usetype: LinkUse.bldwall, comment: "commercial001.link25");
            grc.AddLinkByNodeName("osm6042866099", "osm6042866098", usetype: LinkUse.bldwall, comment: "commercial001.link26");
            grc.AddLinkByNodeName("osm6042866100", "osm6042866099", usetype: LinkUse.bldwall, comment: "commercial001.link27");
            grc.AddLinkByNodeName("osm6042866110", "osm6042866100", usetype: LinkUse.bldwall, comment: "commercial001.link28");
            grc.AddLinkByNodeName("osm6042866101", "osm6042866110", usetype: LinkUse.bldwall, comment: "commercial001.link29");
            grc.AddLinkByNodeName("osm6042866102", "osm6042866101", usetype: LinkUse.bldwall, comment: "commercial001.link30");
            grc.AddLinkByNodeName("osm6042866103", "osm6042866102", usetype: LinkUse.bldwall, comment: "commercial001.link31");
            grc.AddLinkByNodeName("osm6042866104", "osm6042866103", usetype: LinkUse.bldwall, comment: "commercial001.link32");
            grc.AddLinkByNodeName("osm6042866105", "osm6042866104", usetype: LinkUse.bldwall, comment: "commercial001.link33");
            grc.AddLinkByNodeName("osm321549721", "osm6042866105", usetype: LinkUse.bldwall, comment: "commercial001.link34");
            grc.AddLinkByNodeName("osm6042866106", "osm321549721", usetype: LinkUse.bldwall, comment: "commercial001.link35");
            grc.AddLinkByNodeName("osm6042866107", "osm6042866106", usetype: LinkUse.bldwall, comment: "commercial001.link36");
            grc.AddLinkByNodeName("osm6042866108", "osm6042866107", usetype: LinkUse.bldwall, comment: "commercial001.link37");
            grc.AddLinkByNodeName("osm321549723", "osm6042866108", usetype: LinkUse.bldwall, comment: "commercial001.link38");
            grc.AddLinkByNodeName("osm321549713", "osm321549723", usetype: LinkUse.bldwall, comment: "commercial001.link39");

            grc.AddLinkByNodeName("osm6306189085", "osm321549938", usetype: LinkUse.bldwall, comment: "commercial002.link1");
            grc.AddLinkByNodeName("osm321549939", "osm6306189085", usetype: LinkUse.bldwall, comment: "commercial002.link2");
            grc.AddLinkByNodeName("osm6333359145", "osm321549939", usetype: LinkUse.bldwall, comment: "commercial002.link3");
            grc.AddLinkByNodeName("osm6981461728", "osm6333359145", usetype: LinkUse.bldwall, comment: "commercial002.link4");
            grc.AddLinkByNodeName("osm6306188979", "osm6981461728", usetype: LinkUse.bldwall, comment: "commercial002.link5");
            grc.AddLinkByNodeName("osm6306188978", "osm6306188979", usetype: LinkUse.bldwall, comment: "commercial002.link6");
            grc.AddLinkByNodeName("osm321549940", "osm6306188978", usetype: LinkUse.bldwall, comment: "commercial002.link7");
            grc.AddLinkByNodeName("osm321549941", "osm321549940", usetype: LinkUse.bldwall, comment: "commercial002.link8");
            grc.AddLinkByNodeName("osm321549942", "osm321549941", usetype: LinkUse.bldwall, comment: "commercial002.link9");
            grc.AddLinkByNodeName("osm6306188976", "osm321549942", usetype: LinkUse.bldwall, comment: "commercial002.link10");
            grc.AddLinkByNodeName("osm6935972834", "osm6306188976", usetype: LinkUse.bldwall, comment: "commercial002.link11");
            grc.AddLinkByNodeName("osm321549943", "osm6935972834", usetype: LinkUse.bldwall, comment: "commercial002.link12");
            grc.AddLinkByNodeName("osm321549938", "osm321549943", usetype: LinkUse.bldwall, comment: "commercial002.link13");

            grc.AddLinkByNodeName("osm7137547773", "osm6306189090", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link1");
            grc.AddLinkByNodeName("osm6306189091", "osm7137547773", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link2");
            grc.AddLinkByNodeName("osm6306189093", "osm6306189091", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link3");
            grc.AddLinkByNodeName("osm321549980", "osm6306189093", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link4");
            grc.AddLinkByNodeName("osm6306189094", "osm321549980", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link5");
            grc.AddLinkByNodeName("osm7137628046", "osm6306189094", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link6");
            grc.AddLinkByNodeName("osm6306189102", "osm7137628046", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link7");
            grc.AddLinkByNodeName("osm321549981", "osm6306189102", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link8");
            grc.AddLinkByNodeName("osm6946491902", "osm321549981", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link9");
            grc.AddLinkByNodeName("osm6946491900", "osm6946491902", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link10");
            grc.AddLinkByNodeName("osm321549982", "osm6946491900", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link11");
            grc.AddLinkByNodeName("osm6301563926", "osm321549982", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link12");
            grc.AddLinkByNodeName("osm6301563925", "osm6301563926", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link13");
            grc.AddLinkByNodeName("osm6301563936", "osm6301563925", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link14");
            grc.AddLinkByNodeName("osm6301563922", "osm6301563936", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link15");
            grc.AddLinkByNodeName("osm6323277624", "osm6301563922", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link16");
            grc.AddLinkByNodeName("osm6323277625", "osm6323277624", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link17");
            grc.AddLinkByNodeName("osm6306189090", "osm6323277625", usetype: LinkUse.bldwall, comment: "Honeywell Building 1.link18");

            grc.AddLinkByNodeName("osm6997724886", "osm321549985", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link1");
            grc.AddLinkByNodeName("osm7464275809", "osm6997724886", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link2");
            grc.AddLinkByNodeName("osm321549986", "osm7464275809", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link3");
            grc.AddLinkByNodeName("osm7464276236", "osm321549986", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link4");
            grc.AddLinkByNodeName("osm321549987", "osm7464276236", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link5");
            grc.AddLinkByNodeName("osm321549988", "osm321549987", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link6");
            grc.AddLinkByNodeName("osm321549989", "osm321549988", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link7");
            grc.AddLinkByNodeName("osm7464276232", "osm321549989", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link8");
            grc.AddLinkByNodeName("osm321549990", "osm7464276232", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link9");
            grc.AddLinkByNodeName("osm6997724888", "osm321549990", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link10");
            grc.AddLinkByNodeName("osm7464276229", "osm6997724888", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link11");
            grc.AddLinkByNodeName("osm321549991", "osm7464276229", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link12");
            grc.AddLinkByNodeName("osm321549992", "osm321549991", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link13");
            grc.AddLinkByNodeName("osm321549993", "osm321549992", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link14");
            grc.AddLinkByNodeName("osm321549994", "osm321549993", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link15");
            grc.AddLinkByNodeName("osm7464275805", "osm321549994", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link16");
            grc.AddLinkByNodeName("osm7464275806", "osm7464275805", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link17");
            grc.AddLinkByNodeName("osm321549995", "osm7464275806", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link18");
            grc.AddLinkByNodeName("osm7547455775", "osm321549995", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link19");
            grc.AddLinkByNodeName("osm7547455773", "osm7547455775", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link20");
            grc.AddLinkByNodeName("osm7547455778", "osm7547455773", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link21");
            grc.AddLinkByNodeName("osm7547455780", "osm7547455778", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link22");
            grc.AddLinkByNodeName("osm7547455774", "osm7547455780", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link23");
            grc.AddLinkByNodeName("osm7547455782", "osm7547455774", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link24");
            grc.AddLinkByNodeName("osm7547455783", "osm7547455782", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link25");
            grc.AddLinkByNodeName("osm4294894962", "osm7547455783", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link26");
            grc.AddLinkByNodeName("osm321549996", "osm4294894962", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link27");
            grc.AddLinkByNodeName("osm321549997", "osm321549996", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link28");
            grc.AddLinkByNodeName("osm321549998", "osm321549997", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link29");
            grc.AddLinkByNodeName("osm6997724882", "osm321549998", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link30");
            grc.AddLinkByNodeName("osm6997724884", "osm6997724882", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link31");
            grc.AddLinkByNodeName("osm6997724898", "osm6997724884", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link32");
            grc.AddLinkByNodeName("osm6997724885", "osm6997724898", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link33");
            grc.AddLinkByNodeName("osm6997724883", "osm6997724885", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link34");
            grc.AddLinkByNodeName("osm7464275808", "osm6997724883", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link35");
            grc.AddLinkByNodeName("osm6997724887", "osm7464275808", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link36");
            grc.AddLinkByNodeName("osm321549985", "osm6997724887", usetype: LinkUse.bldwall, comment: "Microsoft Studio X.link37");

            grc.AddLinkByNodeName("osm4823517527", "osm321709206", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link1");
            grc.AddLinkByNodeName("osm4823527356", "osm4823517527", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link2");
            grc.AddLinkByNodeName("osm7463724241", "osm4823527356", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link3");
            grc.AddLinkByNodeName("osm321709207", "osm7463724241", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link4");
            grc.AddLinkByNodeName("osm321709208", "osm321709207", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link5");
            grc.AddLinkByNodeName("osm321709209", "osm321709208", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link6");
            grc.AddLinkByNodeName("osm7543923679", "osm321709209", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link7");
            grc.AddLinkByNodeName("osm4823517529", "osm7543923679", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link8");
            grc.AddLinkByNodeName("osm7543938895", "osm4823517529", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link9");
            grc.AddLinkByNodeName("osm321709210", "osm7543938895", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link10");
            grc.AddLinkByNodeName("osm321709211", "osm321709210", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link11");
            grc.AddLinkByNodeName("osm7543923681", "osm321709211", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link12");
            grc.AddLinkByNodeName("osm7463724228", "osm7543923681", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link13");
            grc.AddLinkByNodeName("osm7543923665", "osm7463724228", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link14");
            grc.AddLinkByNodeName("osm321709212", "osm7543923665", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link15");
            grc.AddLinkByNodeName("osm321709213", "osm321709212", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link16");
            grc.AddLinkByNodeName("osm4829350846", "osm321709213", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link17");
            grc.AddLinkByNodeName("osm321709214", "osm4829350846", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link18");
            grc.AddLinkByNodeName("osm7549247132", "osm321709214", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link19");
            grc.AddLinkByNodeName("osm7549247126", "osm7549247132", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link20");
            grc.AddLinkByNodeName("osm7463723826", "osm7549247126", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link21");
            grc.AddLinkByNodeName("osm321709215", "osm7463723826", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link22");
            grc.AddLinkByNodeName("osm7463723799", "osm321709215", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link23");
            grc.AddLinkByNodeName("osm6997611923", "osm7463723799", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link24");
            grc.AddLinkByNodeName("osm7463723794", "osm6997611923", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link25");
            grc.AddLinkByNodeName("osm7463723790", "osm7463723794", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link26");
            grc.AddLinkByNodeName("osm4823517557", "osm7463723790", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link27");
            grc.AddLinkByNodeName("osm7463723697", "osm4823517557", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link28");
            grc.AddLinkByNodeName("osm321709216", "osm7463723697", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link29");
            grc.AddLinkByNodeName("osm7463723696", "osm321709216", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link30");
            grc.AddLinkByNodeName("osm7543923629", "osm7463723696", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link31");
            grc.AddLinkByNodeName("osm7463697782", "osm7543923629", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link32");
            grc.AddLinkByNodeName("osm7463697777", "osm7463697782", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link33");
            grc.AddLinkByNodeName("osm7463697776", "osm7463697777", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link34");
            grc.AddLinkByNodeName("osm7543923628", "osm7463697776", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link35");
            grc.AddLinkByNodeName("osm321709217", "osm7543923628", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link36");
            grc.AddLinkByNodeName("osm7463697772", "osm321709217", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link37");
            grc.AddLinkByNodeName("osm321709218", "osm7463697772", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link38");
            grc.AddLinkByNodeName("osm7463697771", "osm321709218", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link39");
            grc.AddLinkByNodeName("osm6042866014", "osm7463697771", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link40");
            grc.AddLinkByNodeName("osm7463723840", "osm6042866014", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link41");
            grc.AddLinkByNodeName("osm321709219", "osm7463723840", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link42");
            grc.AddLinkByNodeName("osm321709220", "osm321709219", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link43");
            grc.AddLinkByNodeName("osm4823517543", "osm321709220", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link44");
            grc.AddLinkByNodeName("osm7463723841", "osm4823517543", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link45");
            grc.AddLinkByNodeName("osm4823517539", "osm7463723841", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link46");
            grc.AddLinkByNodeName("osm4823517542", "osm4823517539", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link47");
            grc.AddLinkByNodeName("osm7463723845", "osm4823517542", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link48");
            grc.AddLinkByNodeName("osm4823517541", "osm7463723845", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link49");
            grc.AddLinkByNodeName("osm4823517540", "osm4823517541", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link50");
            grc.AddLinkByNodeName("osm7463723849", "osm4823517540", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link51");
            grc.AddLinkByNodeName("osm321709221", "osm7463723849", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link52");
            grc.AddLinkByNodeName("osm4823592289", "osm321709221", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link53");
            grc.AddLinkByNodeName("osm4823592288", "osm4823592289", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link54");
            grc.AddLinkByNodeName("osm1488907738", "osm4823592288", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link55");
            grc.AddLinkByNodeName("osm4823592287", "osm1488907738", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link56");
            grc.AddLinkByNodeName("osm6997225354", "osm4823592287", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link57");
            grc.AddLinkByNodeName("osm321709223", "osm6997225354", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link58");
            grc.AddLinkByNodeName("osm321709224", "osm321709223", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link59");
            grc.AddLinkByNodeName("osm321709225", "osm321709224", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link60");
            grc.AddLinkByNodeName("osm321709226", "osm321709225", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link61");
            grc.AddLinkByNodeName("osm321709227", "osm321709226", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link62");
            grc.AddLinkByNodeName("osm321709228", "osm321709227", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link63");
            grc.AddLinkByNodeName("osm6997611913", "osm321709228", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link64");
            grc.AddLinkByNodeName("osm321709206", "osm6997611913", usetype: LinkUse.bldwall, comment: "Microsoft Building 92.link65");

            grc.AddLinkByNodeName("osm352544050", "osm352544034", usetype: LinkUse.bldwall, comment: "Microsoft Building 22.link1");
            grc.AddLinkByNodeName("osm352544061", "osm352544050", usetype: LinkUse.bldwall, comment: "Microsoft Building 22.link2");
            grc.AddLinkByNodeName("osm7103512102", "osm352544061", usetype: LinkUse.bldwall, comment: "Microsoft Building 22.link3");
            grc.AddLinkByNodeName("osm352544073", "osm7103512102", usetype: LinkUse.bldwall, comment: "Microsoft Building 22.link4");
            grc.AddLinkByNodeName("osm352544088", "osm352544073", usetype: LinkUse.bldwall, comment: "Microsoft Building 22.link5");
            grc.AddLinkByNodeName("osm352544099", "osm352544088", usetype: LinkUse.bldwall, comment: "Microsoft Building 22.link6");
            grc.AddLinkByNodeName("osm352544113", "osm352544099", usetype: LinkUse.bldwall, comment: "Microsoft Building 22.link7");
            grc.AddLinkByNodeName("osm352544123", "osm352544113", usetype: LinkUse.bldwall, comment: "Microsoft Building 22.link8");
            grc.AddLinkByNodeName("osm352544133", "osm352544123", usetype: LinkUse.bldwall, comment: "Microsoft Building 22.link9");
            grc.AddLinkByNodeName("osm352544141", "osm352544133", usetype: LinkUse.bldwall, comment: "Microsoft Building 22.link10");
            grc.AddLinkByNodeName("osm352544034", "osm352544141", usetype: LinkUse.bldwall, comment: "Microsoft Building 22.link11");

            grc.AddLinkByNodeName("osm4017339897", "osm409460143", usetype: LinkUse.bldwall, comment: "bld001.link1");
            grc.AddLinkByNodeName("osm4017339896", "osm4017339897", usetype: LinkUse.bldwall, comment: "bld001.link2");
            grc.AddLinkByNodeName("osm409460145", "osm4017339896", usetype: LinkUse.bldwall, comment: "bld001.link3");
            grc.AddLinkByNodeName("osm4017339895", "osm409460145", usetype: LinkUse.bldwall, comment: "bld001.link4");
            grc.AddLinkByNodeName("osm4017339894", "osm4017339895", usetype: LinkUse.bldwall, comment: "bld001.link5");
            grc.AddLinkByNodeName("osm3934726679", "osm4017339894", usetype: LinkUse.bldwall, comment: "bld001.link6");
            grc.AddLinkByNodeName("osm7287694151", "osm3934726679", usetype: LinkUse.bldwall, comment: "bld001.link7");
            grc.AddLinkByNodeName("osm3934627723", "osm7287694151", usetype: LinkUse.bldwall, comment: "bld001.link8");
            grc.AddLinkByNodeName("osm5145915627", "osm3934627723", usetype: LinkUse.bldwall, comment: "bld001.link9");
            grc.AddLinkByNodeName("osm7287694159", "osm5145915627", usetype: LinkUse.bldwall, comment: "bld001.link10");
            grc.AddLinkByNodeName("osm7105997698", "osm7287694159", usetype: LinkUse.bldwall, comment: "bld001.link11");
            grc.AddLinkByNodeName("osm409460149", "osm7105997698", usetype: LinkUse.bldwall, comment: "bld001.link12");
            grc.AddLinkByNodeName("osm4017339898", "osm409460149", usetype: LinkUse.bldwall, comment: "bld001.link13");
            grc.AddLinkByNodeName("osm4017339899", "osm4017339898", usetype: LinkUse.bldwall, comment: "bld001.link14");
            grc.AddLinkByNodeName("osm4017339901", "osm4017339899", usetype: LinkUse.bldwall, comment: "bld001.link15");
            grc.AddLinkByNodeName("osm4017339900", "osm4017339901", usetype: LinkUse.bldwall, comment: "bld001.link16");
            grc.AddLinkByNodeName("osm409460152", "osm4017339900", usetype: LinkUse.bldwall, comment: "bld001.link17");
            grc.AddLinkByNodeName("osm7287516732", "osm409460152", usetype: LinkUse.bldwall, comment: "bld001.link18");
            grc.AddLinkByNodeName("osm7103512090", "osm7287516732", usetype: LinkUse.bldwall, comment: "bld001.link19");
            grc.AddLinkByNodeName("osm409460143", "osm7103512090", usetype: LinkUse.bldwall, comment: "bld001.link20");

            grc.AddLinkByNodeName("osm7287715304", "osm7287715305", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link1");
            grc.AddLinkByNodeName("osm409460161", "osm7287715304", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link2");
            grc.AddLinkByNodeName("osm7105644009", "osm409460161", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link3");
            grc.AddLinkByNodeName("osm7105994662", "osm7105644009", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link4");
            grc.AddLinkByNodeName("osm7105994663", "osm7105994662", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link5");
            grc.AddLinkByNodeName("osm409460164", "osm7105994663", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link6");
            grc.AddLinkByNodeName("osm7105994664", "osm409460164", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link7");
            grc.AddLinkByNodeName("osm7105994665", "osm7105994664", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link8");
            grc.AddLinkByNodeName("osm409460166", "osm7105994665", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link9");
            grc.AddLinkByNodeName("osm409460169", "osm409460166", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link10");
            grc.AddLinkByNodeName("osm409460171", "osm409460169", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link11");
            grc.AddLinkByNodeName("osm7105994666", "osm409460171", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link12");
            grc.AddLinkByNodeName("osm7105994667", "osm7105994666", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link13");
            grc.AddLinkByNodeName("osm7105994668", "osm7105994667", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link14");
            grc.AddLinkByNodeName("osm7105994669", "osm7105994668", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link15");
            grc.AddLinkByNodeName("osm409460174", "osm7105994669", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link16");
            grc.AddLinkByNodeName("osm5145915623", "osm409460174", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link17");
            grc.AddLinkByNodeName("osm7287977465", "osm5145915623", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link18");
            grc.AddLinkByNodeName("osm7105994654", "osm7287977465", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link19");
            grc.AddLinkByNodeName("osm5145915630", "osm7105994654", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link20");
            grc.AddLinkByNodeName("osm416132267", "osm5145915630", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link21");
            grc.AddLinkByNodeName("osm409460176", "osm416132267", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link22");
            grc.AddLinkByNodeName("osm7105994655", "osm409460176", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link23");
            grc.AddLinkByNodeName("osm409460179", "osm7105994655", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link24");
            grc.AddLinkByNodeName("osm7105994656", "osm409460179", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link25");
            grc.AddLinkByNodeName("osm7105994657", "osm7105994656", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link26");
            grc.AddLinkByNodeName("osm7287694181", "osm7105994657", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link27");
            grc.AddLinkByNodeName("osm7105994658", "osm7287694181", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link28");
            grc.AddLinkByNodeName("osm409460180", "osm7105994658", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link29");
            grc.AddLinkByNodeName("osm409460181", "osm409460180", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link30");
            grc.AddLinkByNodeName("osm409460182", "osm409460181", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link31");
            grc.AddLinkByNodeName("osm7105994659", "osm409460182", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link32");
            grc.AddLinkByNodeName("osm7105994660", "osm7105994659", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link33");
            grc.AddLinkByNodeName("osm7287694148", "osm7105994660", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link34");
            grc.AddLinkByNodeName("osm7287977517", "osm7287694148", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link35");
            grc.AddLinkByNodeName("osm7287715306", "osm7287977517", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link36");
            grc.AddLinkByNodeName("osm7287715305", "osm7287715306", usetype: LinkUse.bldwall, comment: "Microsoft Building 41.link37");

            grc.AddLinkByNodeName("osm5145915629", "osm416132288", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link1");
            grc.AddLinkByNodeName("osm7287952120", "osm5145915629", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link2");
            grc.AddLinkByNodeName("osm5145915626", "osm7287952120", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link3");
            grc.AddLinkByNodeName("osm416132290", "osm5145915626", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link4");
            grc.AddLinkByNodeName("osm7287694176", "osm416132290", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link5");
            grc.AddLinkByNodeName("osm7287694168", "osm7287694176", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link6");
            grc.AddLinkByNodeName("osm7287694167", "osm7287694168", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link7");
            grc.AddLinkByNodeName("osm7287694175", "osm7287694167", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link8");
            grc.AddLinkByNodeName("osm416132291", "osm7287694175", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link9");
            grc.AddLinkByNodeName("osm416132292", "osm416132291", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link10");
            grc.AddLinkByNodeName("osm416132293", "osm416132292", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link11");
            grc.AddLinkByNodeName("osm416132294", "osm416132293", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link12");
            grc.AddLinkByNodeName("osm7287694174", "osm416132294", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link13");
            grc.AddLinkByNodeName("osm7287694166", "osm7287694174", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link14");
            grc.AddLinkByNodeName("osm7287694165", "osm7287694166", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link15");
            grc.AddLinkByNodeName("osm7287715300", "osm7287694165", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link16");
            grc.AddLinkByNodeName("osm416132295", "osm7287715300", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link17");
            grc.AddLinkByNodeName("osm7105997662", "osm416132295", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link18");
            grc.AddLinkByNodeName("osm4017340415", "osm7105997662", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link19");
            grc.AddLinkByNodeName("osm7287694164", "osm4017340415", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link20");
            grc.AddLinkByNodeName("osm416132296", "osm7287694164", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link21");
            grc.AddLinkByNodeName("osm7105997679", "osm416132296", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link22");
            grc.AddLinkByNodeName("osm7287694163", "osm7105997679", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link23");
            grc.AddLinkByNodeName("osm7287694162", "osm7287694163", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link24");
            grc.AddLinkByNodeName("osm416132297", "osm7287694162", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link25");
            grc.AddLinkByNodeName("osm416132298", "osm416132297", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link26");
            grc.AddLinkByNodeName("osm416132299", "osm416132298", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link27");
            grc.AddLinkByNodeName("osm416132300", "osm416132299", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link28");
            grc.AddLinkByNodeName("osm7287694173", "osm416132300", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link29");
            grc.AddLinkByNodeName("osm7105997694", "osm7287694173", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link30");
            grc.AddLinkByNodeName("osm7287694172", "osm7105997694", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link31");
            grc.AddLinkByNodeName("osm7287694171", "osm7287694172", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link32");
            grc.AddLinkByNodeName("osm7287694170", "osm7287694171", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link33");
            grc.AddLinkByNodeName("osm416132288", "osm7287694170", usetype: LinkUse.bldwall, comment: "Microsoft Building 40.link34");

            grc.AddLinkByNodeName("osm7287715312", "osm7105997612", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link1");
            grc.AddLinkByNodeName("osm5145915624", "osm7287715312", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link2");
            grc.AddLinkByNodeName("osm7287715313", "osm5145915624", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link3");
            grc.AddLinkByNodeName("osm7287715314", "osm7287715313", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link4");
            grc.AddLinkByNodeName("osm7287977424", "osm7287715314", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link5");
            grc.AddLinkByNodeName("osm7287977425", "osm7287977424", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link6");
            grc.AddLinkByNodeName("osm416133861", "osm7287977425", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link7");
            grc.AddLinkByNodeName("osm7287715322", "osm416133861", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link8");
            grc.AddLinkByNodeName("osm7287715321", "osm7287715322", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link9");
            grc.AddLinkByNodeName("osm7287715320", "osm7287715321", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link10");
            grc.AddLinkByNodeName("osm7287715319", "osm7287715320", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link11");
            grc.AddLinkByNodeName("osm7287715318", "osm7287715319", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link12");
            grc.AddLinkByNodeName("osm7287715317", "osm7287715318", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link13");
            grc.AddLinkByNodeName("osm7287715316", "osm7287715317", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link14");
            grc.AddLinkByNodeName("osm7287715315", "osm7287715316", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link15");
            grc.AddLinkByNodeName("osm416133862", "osm7287715315", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link16");
            grc.AddLinkByNodeName("osm7287977438", "osm416133862", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link17");
            grc.AddLinkByNodeName("osm7287977439", "osm7287977438", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link18");
            grc.AddLinkByNodeName("osm7287715326", "osm7287977439", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link19");
            grc.AddLinkByNodeName("osm7287715325", "osm7287715326", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link20");
            grc.AddLinkByNodeName("osm5145915625", "osm7287715325", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link21");
            grc.AddLinkByNodeName("osm7287715324", "osm5145915625", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link22");
            grc.AddLinkByNodeName("osm7287715323", "osm7287715324", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link23");
            grc.AddLinkByNodeName("osm416133859", "osm7287715323", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link24");
            grc.AddLinkByNodeName("osm7287977537", "osm416133859", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link25");
            grc.AddLinkByNodeName("osm7287977574", "osm7287977537", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link26");
            grc.AddLinkByNodeName("osm7287715307", "osm7287977574", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link27");
            grc.AddLinkByNodeName("osm7105997612", "osm7287715307", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 40/41.link28");

            grc.AddLinkByNodeName("osm7103327031", "osm809773219", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link1");
            grc.AddLinkByNodeName("osm809773223", "osm7103327031", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link2");
            grc.AddLinkByNodeName("osm809773225", "osm809773223", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link3");
            grc.AddLinkByNodeName("osm809773227", "osm809773225", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link4");
            grc.AddLinkByNodeName("osm7103240876", "osm809773227", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link5");
            grc.AddLinkByNodeName("osm809773255", "osm7103240876", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link6");
            grc.AddLinkByNodeName("osm809773259", "osm809773255", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link7");
            grc.AddLinkByNodeName("osm7103248592", "osm809773259", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link8");
            grc.AddLinkByNodeName("osm809793930", "osm7103248592", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link9");
            grc.AddLinkByNodeName("osm7103240880", "osm809793930", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link10");
            grc.AddLinkByNodeName("osm809793934", "osm7103240880", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link11");
            grc.AddLinkByNodeName("osm7103240878", "osm809793934", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link12");
            grc.AddLinkByNodeName("osm5159874266", "osm7103240878", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link13");
            grc.AddLinkByNodeName("osm5159874265", "osm5159874266", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link14");
            grc.AddLinkByNodeName("osm809793935", "osm5159874265", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link15");
            grc.AddLinkByNodeName("osm5159751051", "osm809793935", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link16");
            grc.AddLinkByNodeName("osm809793936", "osm5159751051", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link17");
            grc.AddLinkByNodeName("osm5159751052", "osm809793936", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link18");
            grc.AddLinkByNodeName("osm5159874263", "osm5159751052", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link19");
            grc.AddLinkByNodeName("osm5159751038", "osm5159874263", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link20");
            grc.AddLinkByNodeName("osm809793937", "osm5159751038", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link21");
            grc.AddLinkByNodeName("osm7103327057", "osm809793937", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link22");
            grc.AddLinkByNodeName("osm809773281", "osm7103327057", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link23");
            grc.AddLinkByNodeName("osm5159887891", "osm809773281", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link24");
            grc.AddLinkByNodeName("osm3934886402", "osm5159887891", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link25");
            grc.AddLinkByNodeName("osm809773286", "osm3934886402", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link26");
            grc.AddLinkByNodeName("osm809773295", "osm809773286", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link27");
            grc.AddLinkByNodeName("osm3934886418", "osm809773295", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link28");
            grc.AddLinkByNodeName("osm809773298", "osm3934886418", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link29");
            grc.AddLinkByNodeName("osm809773300", "osm809773298", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link30");
            grc.AddLinkByNodeName("osm809773303", "osm809773300", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link31");
            grc.AddLinkByNodeName("osm809773305", "osm809773303", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link32");
            grc.AddLinkByNodeName("osm809773310", "osm809773305", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link33");
            grc.AddLinkByNodeName("osm809773316", "osm809773310", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link34");
            grc.AddLinkByNodeName("osm809773323", "osm809773316", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link35");
            grc.AddLinkByNodeName("osm809773326", "osm809773323", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link36");
            grc.AddLinkByNodeName("osm809773329", "osm809773326", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link37");
            grc.AddLinkByNodeName("osm809773332", "osm809773329", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link38");
            grc.AddLinkByNodeName("osm809773335", "osm809773332", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link39");
            grc.AddLinkByNodeName("osm809773345", "osm809773335", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link40");
            grc.AddLinkByNodeName("osm3833737898", "osm809773345", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link41");
            grc.AddLinkByNodeName("osm809773350", "osm3833737898", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link42");
            grc.AddLinkByNodeName("osm809773354", "osm809773350", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link43");
            grc.AddLinkByNodeName("osm809773358", "osm809773354", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link44");
            grc.AddLinkByNodeName("osm809773359", "osm809773358", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link45");
            grc.AddLinkByNodeName("osm809773362", "osm809773359", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link46");
            grc.AddLinkByNodeName("osm809773364", "osm809773362", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link47");
            grc.AddLinkByNodeName("osm810301405", "osm809773364", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link48");
            grc.AddLinkByNodeName("osm3833737984", "osm810301405", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link49");
            grc.AddLinkByNodeName("osm809773368", "osm3833737984", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link50");
            grc.AddLinkByNodeName("osm809773371", "osm809773368", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link51");
            grc.AddLinkByNodeName("osm809773376", "osm809773371", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link52");
            grc.AddLinkByNodeName("osm809773380", "osm809773376", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link53");
            grc.AddLinkByNodeName("osm809773384", "osm809773380", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link54");
            grc.AddLinkByNodeName("osm809773386", "osm809773384", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link55");
            grc.AddLinkByNodeName("osm809773388", "osm809773386", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link56");
            grc.AddLinkByNodeName("osm809773390", "osm809773388", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link57");
            grc.AddLinkByNodeName("osm809773392", "osm809773390", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link58");
            grc.AddLinkByNodeName("osm809773393", "osm809773392", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link59");
            grc.AddLinkByNodeName("osm809773395", "osm809773393", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link60");
            grc.AddLinkByNodeName("osm809773397", "osm809773395", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link61");
            grc.AddLinkByNodeName("osm7290856440", "osm809773397", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link62");
            grc.AddLinkByNodeName("osm7290856441", "osm7290856440", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link63");
            grc.AddLinkByNodeName("osm809773401", "osm7290856441", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link64");
            grc.AddLinkByNodeName("osm7290856442", "osm809773401", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link65");
            grc.AddLinkByNodeName("osm7290856443", "osm7290856442", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link66");
            grc.AddLinkByNodeName("osm809773408", "osm7290856443", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link67");
            grc.AddLinkByNodeName("osm5159887906", "osm809773408", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link68");
            grc.AddLinkByNodeName("osm809773411", "osm5159887906", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link69");
            grc.AddLinkByNodeName("osm809773415", "osm809773411", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link70");
            grc.AddLinkByNodeName("osm809773417", "osm809773415", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link71");
            grc.AddLinkByNodeName("osm809773425", "osm809773417", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link72");
            grc.AddLinkByNodeName("osm809773428", "osm809773425", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link73");
            grc.AddLinkByNodeName("osm809773431", "osm809773428", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link74");
            grc.AddLinkByNodeName("osm5159874236", "osm809773431", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link75");
            grc.AddLinkByNodeName("osm809773435", "osm5159874236", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link76");
            grc.AddLinkByNodeName("osm809773437", "osm809773435", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link77");
            grc.AddLinkByNodeName("osm809773439", "osm809773437", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link78");
            grc.AddLinkByNodeName("osm809773442", "osm809773439", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link79");
            grc.AddLinkByNodeName("osm809773443", "osm809773442", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link80");
            grc.AddLinkByNodeName("osm809773447", "osm809773443", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link81");
            grc.AddLinkByNodeName("osm809773219", "osm809773447", usetype: LinkUse.bldwall, comment: "Microsoft Building 43.link82");

            grc.AddLinkByNodeName("osm809787931", "osm809787927", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link1");
            grc.AddLinkByNodeName("osm809787936", "osm809787931", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link2");
            grc.AddLinkByNodeName("osm809787952", "osm809787936", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link3");
            grc.AddLinkByNodeName("osm7291156677", "osm809787952", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link4");
            grc.AddLinkByNodeName("osm809787956", "osm7291156677", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link5");
            grc.AddLinkByNodeName("osm809787959", "osm809787956", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link6");
            grc.AddLinkByNodeName("osm809787963", "osm809787959", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link7");
            grc.AddLinkByNodeName("osm7290746631", "osm809787963", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link8");
            grc.AddLinkByNodeName("osm7290746630", "osm7290746631", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link9");
            grc.AddLinkByNodeName("osm809787966", "osm7290746630", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link10");
            grc.AddLinkByNodeName("osm809787973", "osm809787966", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link11");
            grc.AddLinkByNodeName("osm5159874240", "osm809787973", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link12");
            grc.AddLinkByNodeName("osm809787979", "osm5159874240", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link13");
            grc.AddLinkByNodeName("osm809787987", "osm809787979", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link14");
            grc.AddLinkByNodeName("osm809787989", "osm809787987", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link15");
            grc.AddLinkByNodeName("osm809787990", "osm809787989", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link16");
            grc.AddLinkByNodeName("osm5159887908", "osm809787990", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link17");
            grc.AddLinkByNodeName("osm809787991", "osm5159887908", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link18");
            grc.AddLinkByNodeName("osm809787995", "osm809787991", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link19");
            grc.AddLinkByNodeName("osm809788001", "osm809787995", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link20");
            grc.AddLinkByNodeName("osm809788010", "osm809788001", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link21");
            grc.AddLinkByNodeName("osm5159887907", "osm809788010", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link22");
            grc.AddLinkByNodeName("osm809788014", "osm5159887907", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link23");
            grc.AddLinkByNodeName("osm809788018", "osm809788014", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link24");
            grc.AddLinkByNodeName("osm809788022", "osm809788018", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link25");
            grc.AddLinkByNodeName("osm809788025", "osm809788022", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link26");
            grc.AddLinkByNodeName("osm809788027", "osm809788025", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link27");
            grc.AddLinkByNodeName("osm809788031", "osm809788027", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link28");
            grc.AddLinkByNodeName("osm809788035", "osm809788031", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link29");
            grc.AddLinkByNodeName("osm809788038", "osm809788035", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link30");
            grc.AddLinkByNodeName("osm809788043", "osm809788038", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link31");
            grc.AddLinkByNodeName("osm809788056", "osm809788043", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link32");
            grc.AddLinkByNodeName("osm809788062", "osm809788056", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link33");
            grc.AddLinkByNodeName("osm5161698340", "osm809788062", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link34");
            grc.AddLinkByNodeName("osm809788065", "osm5161698340", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link35");
            grc.AddLinkByNodeName("osm7290746626", "osm809788065", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link36");
            grc.AddLinkByNodeName("osm7290746627", "osm7290746626", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link37");
            grc.AddLinkByNodeName("osm5161698343", "osm7290746627", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link38");
            grc.AddLinkByNodeName("osm7290746629", "osm5161698343", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link39");
            grc.AddLinkByNodeName("osm7290746628", "osm7290746629", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link40");
            grc.AddLinkByNodeName("osm809788072", "osm7290746628", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link41");
            grc.AddLinkByNodeName("osm809788079", "osm809788072", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link42");
            grc.AddLinkByNodeName("osm809788086", "osm809788079", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link43");
            grc.AddLinkByNodeName("osm809788093", "osm809788086", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link44");
            grc.AddLinkByNodeName("osm809788099", "osm809788093", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link45");
            grc.AddLinkByNodeName("osm809788101", "osm809788099", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link46");
            grc.AddLinkByNodeName("osm809788102", "osm809788101", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link47");
            grc.AddLinkByNodeName("osm809788106", "osm809788102", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link48");
            grc.AddLinkByNodeName("osm5434210418", "osm809788106", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link49");
            grc.AddLinkByNodeName("osm809788113", "osm5434210418", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link50");
            grc.AddLinkByNodeName("osm809788119", "osm809788113", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link51");
            grc.AddLinkByNodeName("osm809788125", "osm809788119", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link52");
            grc.AddLinkByNodeName("osm809788131", "osm809788125", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link53");
            grc.AddLinkByNodeName("osm809788137", "osm809788131", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link54");
            grc.AddLinkByNodeName("osm7103240870", "osm809788137", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link55");
            grc.AddLinkByNodeName("osm809788143", "osm7103240870", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link56");
            grc.AddLinkByNodeName("osm809788149", "osm809788143", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link57");
            grc.AddLinkByNodeName("osm809787927", "osm809788149", usetype: LinkUse.bldwall, comment: "Microsoft Building 42.link58");

            grc.AddLinkByNodeName("osm5159751039", "osm809794788", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link1");
            grc.AddLinkByNodeName("osm5159874264", "osm5159751039", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link2");
            grc.AddLinkByNodeName("osm809794790", "osm5159874264", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link3");
            grc.AddLinkByNodeName("osm5159751036", "osm809794790", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link4");
            grc.AddLinkByNodeName("osm5159751037", "osm5159751036", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link5");
            grc.AddLinkByNodeName("osm809794793", "osm5159751037", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link6");
            grc.AddLinkByNodeName("osm5159887887", "osm809794793", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link7");
            grc.AddLinkByNodeName("osm809794795", "osm5159887887", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link8");
            grc.AddLinkByNodeName("osm809794798", "osm809794795", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link9");
            grc.AddLinkByNodeName("osm809794801", "osm809794798", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link10");
            grc.AddLinkByNodeName("osm5159751054", "osm809794801", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link11");
            grc.AddLinkByNodeName("osm809794802", "osm5159751054", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link12");
            grc.AddLinkByNodeName("osm809794803", "osm809794802", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link13");
            grc.AddLinkByNodeName("osm809794806", "osm809794803", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link14");
            grc.AddLinkByNodeName("osm809794808", "osm809794806", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link15");
            grc.AddLinkByNodeName("osm809794821", "osm809794808", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link16");
            grc.AddLinkByNodeName("osm5159751053", "osm809794821", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link17");
            grc.AddLinkByNodeName("osm7291156633", "osm5159751053", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link18");
            grc.AddLinkByNodeName("osm809794823", "osm7291156633", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link19");
            grc.AddLinkByNodeName("osm809807553", "osm809794823", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link20");
            grc.AddLinkByNodeName("osm809794788", "osm809807553", usetype: LinkUse.bldwall, comment: "Microsoft Cafe 43.link21");

            grc.AddLinkByNodeName("osm809801822", "osm809801820", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link1");
            grc.AddLinkByNodeName("osm5159751031", "osm809801822", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link2");
            grc.AddLinkByNodeName("osm809801825", "osm5159751031", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link3");
            grc.AddLinkByNodeName("osm809801827", "osm809801825", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link4");
            grc.AddLinkByNodeName("osm809801831", "osm809801827", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link5");
            grc.AddLinkByNodeName("osm809801834", "osm809801831", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link6");
            grc.AddLinkByNodeName("osm809801838", "osm809801834", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link7");
            grc.AddLinkByNodeName("osm7290856430", "osm809801838", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link8");
            grc.AddLinkByNodeName("osm809801841", "osm7290856430", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link9");
            grc.AddLinkByNodeName("osm7290856429", "osm809801841", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link10");
            grc.AddLinkByNodeName("osm809801843", "osm7290856429", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link11");
            grc.AddLinkByNodeName("osm809801846", "osm809801843", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link12");
            grc.AddLinkByNodeName("osm809805785", "osm809801846", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link13");
            grc.AddLinkByNodeName("osm809801848", "osm809805785", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link14");
            grc.AddLinkByNodeName("osm5159751055", "osm809801848", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link15");
            grc.AddLinkByNodeName("osm7291156664", "osm5159751055", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link16");
            grc.AddLinkByNodeName("osm809801850", "osm7291156664", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link17");
            grc.AddLinkByNodeName("osm809801853", "osm809801850", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link18");
            grc.AddLinkByNodeName("osm809801854", "osm809801853", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link19");
            grc.AddLinkByNodeName("osm5159751057", "osm809801854", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link20");
            grc.AddLinkByNodeName("osm7290856426", "osm5159751057", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link21");
            grc.AddLinkByNodeName("osm7290856425", "osm7290856426", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link22");
            grc.AddLinkByNodeName("osm809801857", "osm7290856425", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link23");
            grc.AddLinkByNodeName("osm7290856427", "osm809801857", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link24");
            grc.AddLinkByNodeName("osm809801860", "osm7290856427", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link25");
            grc.AddLinkByNodeName("osm7290856428", "osm809801860", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link26");
            grc.AddLinkByNodeName("osm809801871", "osm7290856428", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link27");
            grc.AddLinkByNodeName("osm809801874", "osm809801871", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link28");
            grc.AddLinkByNodeName("osm809801882", "osm809801874", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link29");
            grc.AddLinkByNodeName("osm809801884", "osm809801882", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link30");
            grc.AddLinkByNodeName("osm5159949428", "osm809801884", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link31");
            grc.AddLinkByNodeName("osm809801887", "osm5159949428", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link32");
            grc.AddLinkByNodeName("osm809801890", "osm809801887", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link33");
            grc.AddLinkByNodeName("osm809801893", "osm809801890", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link34");
            grc.AddLinkByNodeName("osm809801897", "osm809801893", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link35");
            grc.AddLinkByNodeName("osm809801900", "osm809801897", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link36");
            grc.AddLinkByNodeName("osm5159949434", "osm809801900", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link37");
            grc.AddLinkByNodeName("osm809801903", "osm5159949434", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link38");
            grc.AddLinkByNodeName("osm809801905", "osm809801903", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link39");
            grc.AddLinkByNodeName("osm809801906", "osm809801905", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link40");
            grc.AddLinkByNodeName("osm809801908", "osm809801906", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link41");
            grc.AddLinkByNodeName("osm809801910", "osm809801908", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link42");
            grc.AddLinkByNodeName("osm809801912", "osm809801910", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link43");
            grc.AddLinkByNodeName("osm809801916", "osm809801912", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link44");
            grc.AddLinkByNodeName("osm5159751030", "osm809801916", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link45");
            grc.AddLinkByNodeName("osm809801919", "osm5159751030", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link46");
            grc.AddLinkByNodeName("osm809801922", "osm809801919", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link47");
            grc.AddLinkByNodeName("osm809801925", "osm809801922", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link48");
            grc.AddLinkByNodeName("osm5159887904", "osm809801925", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link49");
            grc.AddLinkByNodeName("osm809801929", "osm5159887904", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link50");
            grc.AddLinkByNodeName("osm809801931", "osm809801929", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link51");
            grc.AddLinkByNodeName("osm809801933", "osm809801931", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link52");
            grc.AddLinkByNodeName("osm7290856424", "osm809801933", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link53");
            grc.AddLinkByNodeName("osm7290856423", "osm7290856424", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link54");
            grc.AddLinkByNodeName("osm5159751029", "osm7290856423", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link55");
            grc.AddLinkByNodeName("osm809801935", "osm5159751029", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link56");
            grc.AddLinkByNodeName("osm809801936", "osm809801935", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link57");
            grc.AddLinkByNodeName("osm809801938", "osm809801936", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link58");
            grc.AddLinkByNodeName("osm809801951", "osm809801938", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link59");
            grc.AddLinkByNodeName("osm809801954", "osm809801951", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link60");
            grc.AddLinkByNodeName("osm809801956", "osm809801954", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link61");
            grc.AddLinkByNodeName("osm5159874251", "osm809801956", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link62");
            grc.AddLinkByNodeName("osm809801958", "osm5159874251", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link63");
            grc.AddLinkByNodeName("osm809801959", "osm809801958", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link64");
            grc.AddLinkByNodeName("osm5159874255", "osm809801959", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link65");
            grc.AddLinkByNodeName("osm809801960", "osm5159874255", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link66");
            grc.AddLinkByNodeName("osm809801962", "osm809801960", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link67");
            grc.AddLinkByNodeName("osm809801963", "osm809801962", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link68");
            grc.AddLinkByNodeName("osm809801965", "osm809801963", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link69");
            grc.AddLinkByNodeName("osm809801820", "osm809801965", usetype: LinkUse.bldwall, comment: "Microsoft Building 44.link70");

            grc.AddLinkByNodeName("osm4818775957", "osm1086538989", usetype: LinkUse.bldwall, comment: "Building 99.link1");
            grc.AddLinkByNodeName("osm3225793008", "osm4818775957", usetype: LinkUse.bldwall, comment: "Building 99.link2");
            grc.AddLinkByNodeName("osm3225789637", "osm3225793008", usetype: LinkUse.bldwall, comment: "Building 99.link3");
            grc.AddLinkByNodeName("osm1086539021", "osm3225789637", usetype: LinkUse.bldwall, comment: "Building 99.link4");
            grc.AddLinkByNodeName("osm4818775963", "osm1086539021", usetype: LinkUse.bldwall, comment: "Building 99.link5");
            grc.AddLinkByNodeName("osm3347107204", "osm4818775963", usetype: LinkUse.bldwall, comment: "Building 99.link6");
            grc.AddLinkByNodeName("osm4818775962", "osm3347107204", usetype: LinkUse.bldwall, comment: "Building 99.link7");
            grc.AddLinkByNodeName("osm3225793005", "osm4818775962", usetype: LinkUse.bldwall, comment: "Building 99.link8");
            grc.AddLinkByNodeName("osm3225789647", "osm3225793005", usetype: LinkUse.bldwall, comment: "Building 99.link9");
            grc.AddLinkByNodeName("osm4802534846", "osm3225789647", usetype: LinkUse.bldwall, comment: "Building 99.link10");
            grc.AddLinkByNodeName("osm3225792978", "osm4802534846", usetype: LinkUse.bldwall, comment: "Building 99.link11");
            grc.AddLinkByNodeName("osm3225792963", "osm3225792978", usetype: LinkUse.bldwall, comment: "Building 99.link12");
            grc.AddLinkByNodeName("osm3225789641", "osm3225792963", usetype: LinkUse.bldwall, comment: "Building 99.link13");
            grc.AddLinkByNodeName("osm3225792969", "osm3225789641", usetype: LinkUse.bldwall, comment: "Building 99.link14");
            grc.AddLinkByNodeName("osm4650086186", "osm3225792969", usetype: LinkUse.bldwall, comment: "Building 99.link15");
            grc.AddLinkByNodeName("osm3225793007", "osm4650086186", usetype: LinkUse.bldwall, comment: "Building 99.link16");
            grc.AddLinkByNodeName("osm3225789660", "osm3225793007", usetype: LinkUse.bldwall, comment: "Building 99.link17");
            grc.AddLinkByNodeName("osm3347106862", "osm3225789660", usetype: LinkUse.bldwall, comment: "Building 99.link18");
            grc.AddLinkByNodeName("osm3225793006", "osm3347106862", usetype: LinkUse.bldwall, comment: "Building 99.link19");
            grc.AddLinkByNodeName("osm3225792974", "osm3225793006", usetype: LinkUse.bldwall, comment: "Building 99.link20");
            grc.AddLinkByNodeName("osm6981557567", "osm3225792974", usetype: LinkUse.bldwall, comment: "Building 99.link21");
            grc.AddLinkByNodeName("osm1086539030", "osm6981557567", usetype: LinkUse.bldwall, comment: "Building 99.link22");
            grc.AddLinkByNodeName("osm7462172696", "osm1086539030", usetype: LinkUse.bldwall, comment: "Building 99.link23");
            grc.AddLinkByNodeName("osm3225789658", "osm7462172696", usetype: LinkUse.bldwall, comment: "Building 99.link24");
            grc.AddLinkByNodeName("osm3225789657", "osm3225789658", usetype: LinkUse.bldwall, comment: "Building 99.link25");
            grc.AddLinkByNodeName("osm1086539012", "osm3225789657", usetype: LinkUse.bldwall, comment: "Building 99.link26");
            grc.AddLinkByNodeName("osm3225792994", "osm1086539012", usetype: LinkUse.bldwall, comment: "Building 99.link27");
            grc.AddLinkByNodeName("osm3225792979", "osm3225792994", usetype: LinkUse.bldwall, comment: "Building 99.link28");
            grc.AddLinkByNodeName("osm7462172701", "osm3225792979", usetype: LinkUse.bldwall, comment: "Building 99.link29");
            grc.AddLinkByNodeName("osm3225793011", "osm7462172701", usetype: LinkUse.bldwall, comment: "Building 99.link30");
            grc.AddLinkByNodeName("osm3225789654", "osm3225793011", usetype: LinkUse.bldwall, comment: "Building 99.link31");
            grc.AddLinkByNodeName("osm3225793015", "osm3225789654", usetype: LinkUse.bldwall, comment: "Building 99.link32");
            grc.AddLinkByNodeName("osm3225789642", "osm3225793015", usetype: LinkUse.bldwall, comment: "Building 99.link33");
            grc.AddLinkByNodeName("osm4442737419", "osm3225789642", usetype: LinkUse.bldwall, comment: "Building 99.link34");
            grc.AddLinkByNodeName("osm3225792973", "osm4442737419", usetype: LinkUse.bldwall, comment: "Building 99.link35");
            grc.AddLinkByNodeName("osm4844540700", "osm3225792973", usetype: LinkUse.bldwall, comment: "Building 99.link36");
            grc.AddLinkByNodeName("osm3225792971", "osm4844540700", usetype: LinkUse.bldwall, comment: "Building 99.link37");
            grc.AddLinkByNodeName("osm4818775964", "osm3225792971", usetype: LinkUse.bldwall, comment: "Building 99.link38");
            grc.AddLinkByNodeName("osm3225792983", "osm4818775964", usetype: LinkUse.bldwall, comment: "Building 99.link39");
            grc.AddLinkByNodeName("osm3225792970", "osm3225792983", usetype: LinkUse.bldwall, comment: "Building 99.link40");
            grc.AddLinkByNodeName("osm1086538989", "osm3225792970", usetype: LinkUse.bldwall, comment: "Building 99.link41");

            grc.AddLinkByNodeName("osm4802542189", "osm1086539062", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link1");
            grc.AddLinkByNodeName("osm3347107166", "osm4802542189", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link2");
            grc.AddLinkByNodeName("osm3347106868", "osm3347107166", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link3");
            grc.AddLinkByNodeName("osm1086539064", "osm3347106868", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link4");
            grc.AddLinkByNodeName("osm3734071424", "osm1086539064", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link5");
            grc.AddLinkByNodeName("osm6946491906", "osm3734071424", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link6");
            grc.AddLinkByNodeName("osm1086539049", "osm6946491906", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link7");
            grc.AddLinkByNodeName("osm6946491921", "osm1086539049", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link8");
            grc.AddLinkByNodeName("osm6946491922", "osm6946491921", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link9");
            grc.AddLinkByNodeName("osm7149738330", "osm6946491922", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link10");
            grc.AddLinkByNodeName("osm7149738327", "osm7149738330", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link11");
            grc.AddLinkByNodeName("osm6946491920", "osm7149738327", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link12");
            grc.AddLinkByNodeName("osm6946491930", "osm6946491920", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link13");
            grc.AddLinkByNodeName("osm6946491919", "osm6946491930", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link14");
            grc.AddLinkByNodeName("osm1086538998", "osm6946491919", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link15");
            grc.AddLinkByNodeName("osm6946491925", "osm1086538998", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link16");
            grc.AddLinkByNodeName("osm6946491926", "osm6946491925", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link17");
            grc.AddLinkByNodeName("osm6946491923", "osm6946491926", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link18");
            grc.AddLinkByNodeName("osm6946491924", "osm6946491923", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link19");
            grc.AddLinkByNodeName("osm6946491914", "osm6946491924", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link20");
            grc.AddLinkByNodeName("osm6946491911", "osm6946491914", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link21");
            grc.AddLinkByNodeName("osm4781718856", "osm6946491911", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link22");
            grc.AddLinkByNodeName("osm4781718857", "osm4781718856", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link23");
            grc.AddLinkByNodeName("osm6946491918", "osm4781718857", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link24");
            grc.AddLinkByNodeName("osm6946491917", "osm6946491918", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link25");
            grc.AddLinkByNodeName("osm1086539062", "osm6946491917", usetype: LinkUse.bldwall, comment: "Building 99 Parking Garage.link26");

            grc.AddLinkByNodeName("osm4829350214", "osm1488880288", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link1");
            grc.AddLinkByNodeName("osm4829350823", "osm4829350214", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link2");
            grc.AddLinkByNodeName("osm4829350215", "osm4829350823", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link3");
            grc.AddLinkByNodeName("osm4829350822", "osm4829350215", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link4");
            grc.AddLinkByNodeName("osm4829350821", "osm4829350822", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link5");
            grc.AddLinkByNodeName("osm4829350220", "osm4829350821", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link6");
            grc.AddLinkByNodeName("osm4829350217", "osm4829350220", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link7");
            grc.AddLinkByNodeName("osm4829350216", "osm4829350217", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link8");
            grc.AddLinkByNodeName("osm1488880208", "osm4829350216", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link9");
            grc.AddLinkByNodeName("osm4829350218", "osm1488880208", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link10");
            grc.AddLinkByNodeName("osm1488880201", "osm4829350218", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link11");
            grc.AddLinkByNodeName("osm7463723789", "osm1488880201", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link12");
            grc.AddLinkByNodeName("osm1488880184", "osm7463723789", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link13");
            grc.AddLinkByNodeName("osm7463723787", "osm1488880184", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link14");
            grc.AddLinkByNodeName("osm1488880190", "osm7463723787", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link15");
            grc.AddLinkByNodeName("osm4829350219", "osm1488880190", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link16");
            grc.AddLinkByNodeName("osm7516983716", "osm4829350219", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link17");
            grc.AddLinkByNodeName("osm1488880199", "osm7516983716", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link18");
            grc.AddLinkByNodeName("osm7516983717", "osm1488880199", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link19");
            grc.AddLinkByNodeName("osm7003048513", "osm7516983717", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link20");
            grc.AddLinkByNodeName("osm7245133419", "osm7003048513", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link21");
            grc.AddLinkByNodeName("osm1488880316", "osm7245133419", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link22");
            grc.AddLinkByNodeName("osm4829362459", "osm1488880316", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link23");
            grc.AddLinkByNodeName("osm4829362458", "osm4829362459", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link24");
            grc.AddLinkByNodeName("osm4829362457", "osm4829362458", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link25");
            grc.AddLinkByNodeName("osm4829362456", "osm4829362457", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link26");
            grc.AddLinkByNodeName("osm1488880245", "osm4829362456", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link27");
            grc.AddLinkByNodeName("osm1488880397", "osm1488880245", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link28");
            grc.AddLinkByNodeName("osm1488880467", "osm1488880397", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link29");
            grc.AddLinkByNodeName("osm7003048438", "osm1488880467", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link30");
            grc.AddLinkByNodeName("osm7543923647", "osm7003048438", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link31");
            grc.AddLinkByNodeName("osm1488880508", "osm7543923647", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link32");
            grc.AddLinkByNodeName("osm7003048446", "osm1488880508", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link33");
            grc.AddLinkByNodeName("osm7543923646", "osm7003048446", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link34");
            grc.AddLinkByNodeName("osm1488880202", "osm7543923646", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link35");
            grc.AddLinkByNodeName("osm4846255782", "osm1488880202", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link36");
            grc.AddLinkByNodeName("osm4846255781", "osm4846255782", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link37");
            grc.AddLinkByNodeName("osm4846255780", "osm4846255781", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link38");
            grc.AddLinkByNodeName("osm4846255779", "osm4846255780", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link39");
            grc.AddLinkByNodeName("osm1488880568", "osm4846255779", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link40");
            grc.AddLinkByNodeName("osm7463723765", "osm1488880568", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link41");
            grc.AddLinkByNodeName("osm4846255771", "osm7463723765", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link42");
            grc.AddLinkByNodeName("osm7463723764", "osm4846255771", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link43");
            grc.AddLinkByNodeName("osm1488880323", "osm7463723764", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link44");
            grc.AddLinkByNodeName("osm1488880391", "osm1488880323", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link45");
            grc.AddLinkByNodeName("osm1488880399", "osm1488880391", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link46");
            grc.AddLinkByNodeName("osm1488880619", "osm1488880399", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link47");
            grc.AddLinkByNodeName("osm1488880203", "osm1488880619", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link48");
            grc.AddLinkByNodeName("osm4846255777", "osm1488880203", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link49");
            grc.AddLinkByNodeName("osm4846255778", "osm4846255777", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link50");
            grc.AddLinkByNodeName("osm4846255776", "osm4846255778", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link51");
            grc.AddLinkByNodeName("osm4846255775", "osm4846255776", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link52");
            grc.AddLinkByNodeName("osm1488880570", "osm4846255775", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link53");
            grc.AddLinkByNodeName("osm1488880252", "osm1488880570", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link54");
            grc.AddLinkByNodeName("osm1488880547", "osm1488880252", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link55");
            grc.AddLinkByNodeName("osm4846255774", "osm1488880547", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link56");
            grc.AddLinkByNodeName("osm4846255773", "osm4846255774", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link57");
            grc.AddLinkByNodeName("osm4829350831", "osm4846255773", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link58");
            grc.AddLinkByNodeName("osm4846255772", "osm4829350831", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link59");
            grc.AddLinkByNodeName("osm1488880193", "osm4846255772", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link60");
            grc.AddLinkByNodeName("osm7543923644", "osm1488880193", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link61");
            grc.AddLinkByNodeName("osm4829350832", "osm7543923644", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link62");
            grc.AddLinkByNodeName("osm4829350833", "osm4829350832", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link63");
            grc.AddLinkByNodeName("osm4829350834", "osm4829350833", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link64");
            grc.AddLinkByNodeName("osm7463723733", "osm4829350834", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link65");
            grc.AddLinkByNodeName("osm1488880218", "osm7463723733", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link66");
            grc.AddLinkByNodeName("osm4829350835", "osm1488880218", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link67");
            grc.AddLinkByNodeName("osm7463723731", "osm4829350835", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link68");
            grc.AddLinkByNodeName("osm1488880247", "osm7463723731", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link69");
            grc.AddLinkByNodeName("osm1488880196", "osm1488880247", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link70");
            grc.AddLinkByNodeName("osm4829350836", "osm1488880196", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link71");
            grc.AddLinkByNodeName("osm4829350837", "osm4829350836", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link72");
            grc.AddLinkByNodeName("osm7463723725", "osm4829350837", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link73");
            grc.AddLinkByNodeName("osm4829350838", "osm7463723725", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link74");
            grc.AddLinkByNodeName("osm4829350839", "osm4829350838", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link75");
            grc.AddLinkByNodeName("osm7463723720", "osm4829350839", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link76");
            grc.AddLinkByNodeName("osm1488880228", "osm7463723720", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link77");
            grc.AddLinkByNodeName("osm7463723717", "osm1488880228", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link78");
            grc.AddLinkByNodeName("osm7463723713", "osm7463723717", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link79");
            grc.AddLinkByNodeName("osm1488880545", "osm7463723713", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link80");
            grc.AddLinkByNodeName("osm1488880331", "osm1488880545", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link81");
            grc.AddLinkByNodeName("osm4829350840", "osm1488880331", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link82");
            grc.AddLinkByNodeName("osm4829350841", "osm4829350840", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link83");
            grc.AddLinkByNodeName("osm4829350842", "osm4829350841", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link84");
            grc.AddLinkByNodeName("osm4829350843", "osm4829350842", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link85");
            grc.AddLinkByNodeName("osm1488880448", "osm4829350843", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link86");
            grc.AddLinkByNodeName("osm7463723706", "osm1488880448", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link87");
            grc.AddLinkByNodeName("osm4829350830", "osm7463723706", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link88");
            grc.AddLinkByNodeName("osm7245133586", "osm4829350830", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link89");
            grc.AddLinkByNodeName("osm4829350845", "osm7245133586", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link90");
            grc.AddLinkByNodeName("osm4829350844", "osm4829350845", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link91");
            grc.AddLinkByNodeName("osm1488880456", "osm4829350844", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link92");
            grc.AddLinkByNodeName("osm1488880488", "osm1488880456", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link93");
            grc.AddLinkByNodeName("osm1488880216", "osm1488880488", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link94");
            grc.AddLinkByNodeName("osm4829350824", "osm1488880216", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link95");
            grc.AddLinkByNodeName("osm4829350825", "osm4829350824", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link96");
            grc.AddLinkByNodeName("osm4829350826", "osm4829350825", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link97");
            grc.AddLinkByNodeName("osm4829350827", "osm4829350826", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link98");
            grc.AddLinkByNodeName("osm1488880212", "osm4829350827", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link99");
            grc.AddLinkByNodeName("osm1488880211", "osm1488880212", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link100");
            grc.AddLinkByNodeName("osm1488880288", "osm1488880211", usetype: LinkUse.bldwall, comment: "Microsoft Studio D.link101");

            grc.AddLinkByNodeName("osm4829304087", "osm1488880322", usetype: LinkUse.bldwall, comment: "The Boardwalk.link1");
            grc.AddLinkByNodeName("osm1488880205", "osm4829304087", usetype: LinkUse.bldwall, comment: "The Boardwalk.link2");
            grc.AddLinkByNodeName("osm1488902087", "osm1488880205", usetype: LinkUse.bldwall, comment: "The Boardwalk.link3");
            grc.AddLinkByNodeName("osm7528124004", "osm1488902087", usetype: LinkUse.bldwall, comment: "The Boardwalk.link4");
            grc.AddLinkByNodeName("osm7528124003", "osm7528124004", usetype: LinkUse.bldwall, comment: "The Boardwalk.link5");
            grc.AddLinkByNodeName("osm1488880177", "osm7528124003", usetype: LinkUse.bldwall, comment: "The Boardwalk.link6");
            grc.AddLinkByNodeName("osm7528124006", "osm1488880177", usetype: LinkUse.bldwall, comment: "The Boardwalk.link7");
            grc.AddLinkByNodeName("osm7528124005", "osm7528124006", usetype: LinkUse.bldwall, comment: "The Boardwalk.link8");
            grc.AddLinkByNodeName("osm1488880490", "osm7528124005", usetype: LinkUse.bldwall, comment: "The Boardwalk.link9");
            grc.AddLinkByNodeName("osm1488880584", "osm1488880490", usetype: LinkUse.bldwall, comment: "The Boardwalk.link10");
            grc.AddLinkByNodeName("osm1488880629", "osm1488880584", usetype: LinkUse.bldwall, comment: "The Boardwalk.link11");
            grc.AddLinkByNodeName("osm1488880322", "osm1488880629", usetype: LinkUse.bldwall, comment: "The Boardwalk.link12");

            grc.AddLinkByNodeName("osm7462172705", "osm1488880586", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link1");
            grc.AddLinkByNodeName("osm4846295252", "osm7462172705", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link2");
            grc.AddLinkByNodeName("osm4846295253", "osm4846295252", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link3");
            grc.AddLinkByNodeName("osm1488880180", "osm4846295253", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link4");
            grc.AddLinkByNodeName("osm4846295259", "osm1488880180", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link5");
            grc.AddLinkByNodeName("osm7230628048", "osm4846295259", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link6");
            grc.AddLinkByNodeName("osm7462172706", "osm7230628048", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link7");
            grc.AddLinkByNodeName("osm4846295258", "osm7462172706", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link8");
            grc.AddLinkByNodeName("osm7462172846", "osm4846295258", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link9");
            grc.AddLinkByNodeName("osm1488880506", "osm7462172846", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link10");
            grc.AddLinkByNodeName("osm1488880248", "osm1488880506", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link11");
            grc.AddLinkByNodeName("osm7469351322", "osm1488880248", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link12");
            grc.AddLinkByNodeName("osm7462172708", "osm7469351322", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link13");
            grc.AddLinkByNodeName("osm4846295257", "osm7462172708", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link14");
            grc.AddLinkByNodeName("osm4846295256", "osm4846295257", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link15");
            grc.AddLinkByNodeName("osm4846295255", "osm4846295256", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link16");
            grc.AddLinkByNodeName("osm4846295254", "osm4846295255", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link17");
            grc.AddLinkByNodeName("osm7462172709", "osm4846295254", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link18");
            grc.AddLinkByNodeName("osm7469351325", "osm7462172709", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link19");
            grc.AddLinkByNodeName("osm1488880159", "osm7469351325", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link20");
            grc.AddLinkByNodeName("osm7462172707", "osm1488880159", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link21");
            grc.AddLinkByNodeName("osm1488880286", "osm7462172707", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link22");
            grc.AddLinkByNodeName("osm7230628018", "osm1488880286", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link23");
            grc.AddLinkByNodeName("osm6997351170", "osm7230628018", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link24");
            grc.AddLinkByNodeName("osm1488880295", "osm6997351170", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link25");
            grc.AddLinkByNodeName("osm7230628043", "osm1488880295", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link26");
            grc.AddLinkByNodeName("osm1488880160", "osm7230628043", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link27");
            grc.AddLinkByNodeName("osm1488880173", "osm1488880160", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link28");
            grc.AddLinkByNodeName("osm1488880515", "osm1488880173", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link29");
            grc.AddLinkByNodeName("osm4846295228", "osm1488880515", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link30");
            grc.AddLinkByNodeName("osm4846295229", "osm4846295228", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link31");
            grc.AddLinkByNodeName("osm4846295230", "osm4846295229", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link32");
            grc.AddLinkByNodeName("osm4846295231", "osm4846295230", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link33");
            grc.AddLinkByNodeName("osm1488880608", "osm4846295231", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link34");
            grc.AddLinkByNodeName("osm1488880327", "osm1488880608", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link35");
            grc.AddLinkByNodeName("osm1488880230", "osm1488880327", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link36");
            grc.AddLinkByNodeName("osm4846295232", "osm1488880230", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link37");
            grc.AddLinkByNodeName("osm4846295233", "osm4846295232", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link38");
            grc.AddLinkByNodeName("osm4846295234", "osm4846295233", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link39");
            grc.AddLinkByNodeName("osm4846295235", "osm4846295234", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link40");
            grc.AddLinkByNodeName("osm1488880443", "osm4846295235", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link41");
            grc.AddLinkByNodeName("osm1488880269", "osm1488880443", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link42");
            grc.AddLinkByNodeName("osm7230627909", "osm1488880269", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link43");
            grc.AddLinkByNodeName("osm4829304113", "osm7230627909", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link44");
            grc.AddLinkByNodeName("osm1488880598", "osm4829304113", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link45");
            grc.AddLinkByNodeName("osm1488880161", "osm1488880598", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link46");
            grc.AddLinkByNodeName("osm7230627907", "osm1488880161", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link47");
            grc.AddLinkByNodeName("osm1488880593", "osm7230627907", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link48");
            grc.AddLinkByNodeName("osm1488880625", "osm1488880593", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link49");
            grc.AddLinkByNodeName("osm6997477469", "osm1488880625", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link50");
            grc.AddLinkByNodeName("osm7230627885", "osm6997477469", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link51");
            grc.AddLinkByNodeName("osm7462172718", "osm7230627885", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link52");
            grc.AddLinkByNodeName("osm1488880527", "osm7462172718", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link53");
            grc.AddLinkByNodeName("osm4846295236", "osm1488880527", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link54");
            grc.AddLinkByNodeName("osm4846295237", "osm4846295236", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link55");
            grc.AddLinkByNodeName("osm4846295238", "osm4846295237", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link56");
            grc.AddLinkByNodeName("osm4846295239", "osm4846295238", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link57");
            grc.AddLinkByNodeName("osm7462172725", "osm4846295239", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link58");
            grc.AddLinkByNodeName("osm7458590533", "osm7462172725", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link59");
            grc.AddLinkByNodeName("osm1488880339", "osm7458590533", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link60");
            grc.AddLinkByNodeName("osm7462172724", "osm1488880339", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link61");
            grc.AddLinkByNodeName("osm7230627844", "osm7462172724", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link62");
            grc.AddLinkByNodeName("osm7230627841", "osm7230627844", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link63");
            grc.AddLinkByNodeName("osm7291607555", "osm7230627841", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link64");
            grc.AddLinkByNodeName("osm7458590510", "osm7291607555", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link65");
            grc.AddLinkByNodeName("osm1488880489", "osm7458590510", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link66");
            grc.AddLinkByNodeName("osm1488880164", "osm1488880489", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link67");
            grc.AddLinkByNodeName("osm4846295240", "osm1488880164", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link68");
            grc.AddLinkByNodeName("osm4846295241", "osm4846295240", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link69");
            grc.AddLinkByNodeName("osm4846295242", "osm4846295241", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link70");
            grc.AddLinkByNodeName("osm4846295243", "osm4846295242", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link71");
            grc.AddLinkByNodeName("osm1488880176", "osm4846295243", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link72");
            grc.AddLinkByNodeName("osm1488880341", "osm1488880176", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link73");
            grc.AddLinkByNodeName("osm1488880287", "osm1488880341", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link74");
            grc.AddLinkByNodeName("osm1488880251", "osm1488880287", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link75");
            grc.AddLinkByNodeName("osm1488880166", "osm1488880251", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link76");
            grc.AddLinkByNodeName("osm7458590514", "osm1488880166", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link77");
            grc.AddLinkByNodeName("osm4856116766", "osm7458590514", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link78");
            grc.AddLinkByNodeName("osm7462172712", "osm4856116766", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link79");
            grc.AddLinkByNodeName("osm1488880567", "osm7462172712", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link80");
            grc.AddLinkByNodeName("osm7462172714", "osm1488880567", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link81");
            grc.AddLinkByNodeName("osm4846295244", "osm7462172714", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link82");
            grc.AddLinkByNodeName("osm4846295245", "osm4846295244", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link83");
            grc.AddLinkByNodeName("osm4846295246", "osm4846295245", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link84");
            grc.AddLinkByNodeName("osm4846295247", "osm4846295246", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link85");
            grc.AddLinkByNodeName("osm7462172716", "osm4846295247", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link86");
            grc.AddLinkByNodeName("osm7458566169", "osm7462172716", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link87");
            grc.AddLinkByNodeName("osm1488880155", "osm7458566169", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link88");
            grc.AddLinkByNodeName("osm7462172715", "osm1488880155", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link89");
            grc.AddLinkByNodeName("osm7230625681", "osm7462172715", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link90");
            grc.AddLinkByNodeName("osm6042865813", "osm7230625681", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link91");
            grc.AddLinkByNodeName("osm1488880326", "osm6042865813", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link92");
            grc.AddLinkByNodeName("osm1488880431", "osm1488880326", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link93");
            grc.AddLinkByNodeName("osm6042865816", "osm1488880431", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link94");
            grc.AddLinkByNodeName("osm6042865815", "osm6042865816", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link95");
            grc.AddLinkByNodeName("osm6042865814", "osm6042865815", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link96");
            grc.AddLinkByNodeName("osm6042865817", "osm6042865814", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link97");
            grc.AddLinkByNodeName("osm6042865820", "osm6042865817", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link98");
            grc.AddLinkByNodeName("osm6042865822", "osm6042865820", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link99");
            grc.AddLinkByNodeName("osm4846295248", "osm6042865822", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link100");
            grc.AddLinkByNodeName("osm6042865821", "osm4846295248", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link101");
            grc.AddLinkByNodeName("osm4846295223", "osm6042865821", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link102");
            grc.AddLinkByNodeName("osm6042865819", "osm4846295223", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link103");
            grc.AddLinkByNodeName("osm6042865818", "osm6042865819", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link104");
            grc.AddLinkByNodeName("osm7230628053", "osm6042865818", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link105");
            grc.AddLinkByNodeName("osm4846295249", "osm7230628053", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link106");
            grc.AddLinkByNodeName("osm4846295251", "osm4846295249", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link107");
            grc.AddLinkByNodeName("osm4846295250", "osm4846295251", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link108");
            grc.AddLinkByNodeName("osm1488880189", "osm4846295250", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link109");
            grc.AddLinkByNodeName("osm1488880186", "osm1488880189", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link110");
            grc.AddLinkByNodeName("osm7458566183", "osm1488880186", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link111");
            grc.AddLinkByNodeName("osm7458590493", "osm7458566183", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link112");
            grc.AddLinkByNodeName("osm1488880531", "osm7458590493", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link113");
            grc.AddLinkByNodeName("osm1488880530", "osm1488880531", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link114");
            grc.AddLinkByNodeName("osm1488880157", "osm1488880530", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link115");
            grc.AddLinkByNodeName("osm7458590489", "osm1488880157", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link116");
            grc.AddLinkByNodeName("osm6997351091", "osm7458590489", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link117");
            grc.AddLinkByNodeName("osm7458590487", "osm6997351091", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link118");
            grc.AddLinkByNodeName("osm7458590488", "osm7458590487", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link119");
            grc.AddLinkByNodeName("osm6042865810", "osm7458590488", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link120");
            grc.AddLinkByNodeName("osm1488880586", "osm6042865810", usetype: LinkUse.bldwall, comment: "Microsoft Studio B.link121");

            grc.AddLinkByNodeName("osm7549247168", "osm1488880337", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link1");
            grc.AddLinkByNodeName("osm7003167574", "osm7549247168", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link2");
            grc.AddLinkByNodeName("osm7462172859", "osm7003167574", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link3");
            grc.AddLinkByNodeName("osm1488880473", "osm7462172859", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link4");
            grc.AddLinkByNodeName("osm7245133625", "osm1488880473", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link5");
            grc.AddLinkByNodeName("osm7003167568", "osm7245133625", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link6");
            grc.AddLinkByNodeName("osm1488880233", "osm7003167568", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link7");
            grc.AddLinkByNodeName("osm1488880309", "osm1488880233", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link8");
            grc.AddLinkByNodeName("osm4829304109", "osm1488880309", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link9");
            grc.AddLinkByNodeName("osm4829304108", "osm4829304109", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link10");
            grc.AddLinkByNodeName("osm1488880446", "osm4829304108", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link11");
            grc.AddLinkByNodeName("osm4823517533", "osm1488880446", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link12");
            grc.AddLinkByNodeName("osm7462172748", "osm4823517533", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link13");
            grc.AddLinkByNodeName("osm1488880293", "osm7462172748", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link14");
            grc.AddLinkByNodeName("osm1488880611", "osm1488880293", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link15");
            grc.AddLinkByNodeName("osm4829304106", "osm1488880611", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link16");
            grc.AddLinkByNodeName("osm4829304104", "osm4829304106", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link17");
            grc.AddLinkByNodeName("osm4831739751", "osm4829304104", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link18");
            grc.AddLinkByNodeName("osm4829304100", "osm4831739751", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link19");
            grc.AddLinkByNodeName("osm1488880582", "osm4829304100", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link20");
            grc.AddLinkByNodeName("osm4829304098", "osm1488880582", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link21");
            grc.AddLinkByNodeName("osm6997506291", "osm4829304098", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link22");
            grc.AddLinkByNodeName("osm1491011822", "osm6997506291", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link23");
            grc.AddLinkByNodeName("osm1488880512", "osm1491011822", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link24");
            grc.AddLinkByNodeName("osm7516983722", "osm1488880512", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link25");
            grc.AddLinkByNodeName("osm1488880249", "osm7516983722", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link26");
            grc.AddLinkByNodeName("osm1488880243", "osm1488880249", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link27");
            grc.AddLinkByNodeName("osm4829381871", "osm1488880243", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link28");
            grc.AddLinkByNodeName("osm1488880282", "osm4829381871", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link29");
            grc.AddLinkByNodeName("osm4829381867", "osm1488880282", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link30");
            grc.AddLinkByNodeName("osm1488880375", "osm4829381867", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link31");
            grc.AddLinkByNodeName("osm7245133193", "osm1488880375", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link32");
            grc.AddLinkByNodeName("osm7245133192", "osm7245133193", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link33");
            grc.AddLinkByNodeName("osm1488880285", "osm7245133192", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link34");
            grc.AddLinkByNodeName("osm7462172746", "osm1488880285", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link35");
            grc.AddLinkByNodeName("osm7462172747", "osm7462172746", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link36");
            grc.AddLinkByNodeName("osm4829381870", "osm7462172747", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link37");
            grc.AddLinkByNodeName("osm7245130977", "osm4829381870", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link38");
            grc.AddLinkByNodeName("osm1488880197", "osm7245130977", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link39");
            grc.AddLinkByNodeName("osm1488880171", "osm1488880197", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link40");
            grc.AddLinkByNodeName("osm4829381869", "osm1488880171", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link41");
            grc.AddLinkByNodeName("osm1488880393", "osm4829381869", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link42");
            grc.AddLinkByNodeName("osm4829381868", "osm1488880393", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link43");
            grc.AddLinkByNodeName("osm1488880303", "osm4829381868", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link44");
            grc.AddLinkByNodeName("osm7245130962", "osm1488880303", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link45");
            grc.AddLinkByNodeName("osm7245130961", "osm7245130962", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link46");
            grc.AddLinkByNodeName("osm7458590571", "osm7245130961", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link47");
            grc.AddLinkByNodeName("osm7458590570", "osm7458590571", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link48");
            grc.AddLinkByNodeName("osm7458590569", "osm7458590570", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link49");
            grc.AddLinkByNodeName("osm7458590568", "osm7458590569", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link50");
            grc.AddLinkByNodeName("osm7458590567", "osm7458590568", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link51");
            grc.AddLinkByNodeName("osm4829304112", "osm7458590567", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link52");
            grc.AddLinkByNodeName("osm7003167570", "osm4829304112", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link53");
            grc.AddLinkByNodeName("osm7549247167", "osm7003167570", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link54");
            grc.AddLinkByNodeName("osm1488880337", "osm7549247167", usetype: LinkUse.bldwall, comment: "Microsoft Mixer.link55");

            grc.AddLinkByNodeName("osm1488880374", "osm1488880492", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link1");
            grc.AddLinkByNodeName("osm1488880552", "osm1488880374", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link2");
            grc.AddLinkByNodeName("osm4846295264", "osm1488880552", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link3");
            grc.AddLinkByNodeName("osm4856079664", "osm4846295264", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link4");
            grc.AddLinkByNodeName("osm4856079665", "osm4856079664", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link5");
            grc.AddLinkByNodeName("osm4846295265", "osm4856079665", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link6");
            grc.AddLinkByNodeName("osm4856079666", "osm4846295265", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link7");
            grc.AddLinkByNodeName("osm4856079667", "osm4856079666", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link8");
            grc.AddLinkByNodeName("osm4846295266", "osm4856079667", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link9");
            grc.AddLinkByNodeName("osm4846295267", "osm4846295266", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link10");
            grc.AddLinkByNodeName("osm1488880146", "osm4846295267", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link11");
            grc.AddLinkByNodeName("osm4856079668", "osm1488880146", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link12");
            grc.AddLinkByNodeName("osm1488880368", "osm4856079668", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link13");
            grc.AddLinkByNodeName("osm7239264385", "osm1488880368", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link14");
            grc.AddLinkByNodeName("osm6042865916", "osm7239264385", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link15");
            grc.AddLinkByNodeName("osm7291607567", "osm6042865916", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link16");
            grc.AddLinkByNodeName("osm6042865921", "osm7291607567", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link17");
            grc.AddLinkByNodeName("osm6042865915", "osm6042865921", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link18");
            grc.AddLinkByNodeName("osm1488880516", "osm6042865915", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link19");
            grc.AddLinkByNodeName("osm4856079669", "osm1488880516", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link20");
            grc.AddLinkByNodeName("osm4856079670", "osm4856079669", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link21");
            grc.AddLinkByNodeName("osm4856079644", "osm4856079670", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link22");
            grc.AddLinkByNodeName("osm7239216316", "osm4856079644", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link23");
            grc.AddLinkByNodeName("osm1488880616", "osm7239216316", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link24");
            grc.AddLinkByNodeName("osm4846255749", "osm1488880616", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link25");
            grc.AddLinkByNodeName("osm4846255748", "osm4846255749", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link26");
            grc.AddLinkByNodeName("osm4846255747", "osm4846255748", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link27");
            grc.AddLinkByNodeName("osm4856079646", "osm4846255747", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link28");
            grc.AddLinkByNodeName("osm4856079645", "osm4856079646", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link29");
            grc.AddLinkByNodeName("osm4846255746", "osm4856079645", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link30");
            grc.AddLinkByNodeName("osm1488880347", "osm4846255746", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link31");
            grc.AddLinkByNodeName("osm7462172733", "osm1488880347", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link32");
            grc.AddLinkByNodeName("osm7462172729", "osm7462172733", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link33");
            grc.AddLinkByNodeName("osm1488880149", "osm7462172729", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link34");
            grc.AddLinkByNodeName("osm1488880313", "osm1488880149", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link35");
            grc.AddLinkByNodeName("osm7458590602", "osm1488880313", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link36");
            grc.AddLinkByNodeName("osm7462172732", "osm7458590602", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link37");
            grc.AddLinkByNodeName("osm4856079647", "osm7462172732", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link38");
            grc.AddLinkByNodeName("osm4856079648", "osm4856079647", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link39");
            grc.AddLinkByNodeName("osm4846255745", "osm4856079648", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link40");
            grc.AddLinkByNodeName("osm4846255744", "osm4846255745", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link41");
            grc.AddLinkByNodeName("osm4846255743", "osm4846255744", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link42");
            grc.AddLinkByNodeName("osm4846255742", "osm4846255743", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link43");
            grc.AddLinkByNodeName("osm4856079650", "osm4846255742", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link44");
            grc.AddLinkByNodeName("osm4856079649", "osm4856079650", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link45");
            grc.AddLinkByNodeName("osm7462172730", "osm4856079649", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link46");
            grc.AddLinkByNodeName("osm7458590599", "osm7462172730", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link47");
            grc.AddLinkByNodeName("osm1488880147", "osm7458590599", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link48");
            grc.AddLinkByNodeName("osm1488880167", "osm1488880147", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link49");
            grc.AddLinkByNodeName("osm1488880330", "osm1488880167", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link50");
            grc.AddLinkByNodeName("osm7458590595", "osm1488880330", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link51");
            grc.AddLinkByNodeName("osm7462172731", "osm7458590595", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link52");
            grc.AddLinkByNodeName("osm1488880175", "osm7462172731", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link53");
            grc.AddLinkByNodeName("osm1488880232", "osm1488880175", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link54");
            grc.AddLinkByNodeName("osm4856079653", "osm1488880232", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link55");
            grc.AddLinkByNodeName("osm7462172745", "osm4856079653", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link56");
            grc.AddLinkByNodeName("osm1488880421", "osm7462172745", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link57");
            grc.AddLinkByNodeName("osm7462172744", "osm1488880421", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link58");
            grc.AddLinkByNodeName("osm4846255741", "osm7462172744", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link59");
            grc.AddLinkByNodeName("osm4846255740", "osm4846255741", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link60");
            grc.AddLinkByNodeName("osm7462172736", "osm4846255740", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link61");
            grc.AddLinkByNodeName("osm7462172735", "osm7462172736", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link62");
            grc.AddLinkByNodeName("osm4846255739", "osm7462172735", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link63");
            grc.AddLinkByNodeName("osm4846255738", "osm4846255739", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link64");
            grc.AddLinkByNodeName("osm4856079652", "osm4846255738", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link65");
            grc.AddLinkByNodeName("osm4856079651", "osm4856079652", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link66");
            grc.AddLinkByNodeName("osm7462172742", "osm4856079651", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link67");
            grc.AddLinkByNodeName("osm1488880528", "osm7462172742", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link68");
            grc.AddLinkByNodeName("osm7458590645", "osm1488880528", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link69");
            grc.AddLinkByNodeName("osm6047614796", "osm7458590645", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link70");
            grc.AddLinkByNodeName("osm6997506355", "osm6047614796", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link71");
            grc.AddLinkByNodeName("osm1488880631", "osm6997506355", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link72");
            grc.AddLinkByNodeName("osm6047614819", "osm1488880631", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link73");
            grc.AddLinkByNodeName("osm6047614820", "osm6047614819", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link74");
            grc.AddLinkByNodeName("osm1488880605", "osm6047614820", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link75");
            grc.AddLinkByNodeName("osm1488880308", "osm1488880605", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link76");
            grc.AddLinkByNodeName("osm1488880163", "osm1488880308", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link77");
            grc.AddLinkByNodeName("osm1488883261", "osm1488880163", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link78");
            grc.AddLinkByNodeName("osm1488880465", "osm1488883261", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link79");
            grc.AddLinkByNodeName("osm4846255736", "osm1488880465", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link80");
            grc.AddLinkByNodeName("osm4846255735", "osm4846255736", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link81");
            grc.AddLinkByNodeName("osm1488880395", "osm4846255735", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link82");
            grc.AddLinkByNodeName("osm1488880270", "osm1488880395", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link83");
            grc.AddLinkByNodeName("osm1488880372", "osm1488880270", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link84");
            grc.AddLinkByNodeName("osm1488880154", "osm1488880372", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link85");
            grc.AddLinkByNodeName("osm1488880182", "osm1488880154", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link86");
            grc.AddLinkByNodeName("osm7239216350", "osm1488880182", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link87");
            grc.AddLinkByNodeName("osm4856079654", "osm7239216350", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link88");
            grc.AddLinkByNodeName("osm7239216355", "osm4856079654", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link89");
            grc.AddLinkByNodeName("osm1488880439", "osm7239216355", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link90");
            grc.AddLinkByNodeName("osm4274320606", "osm1488880439", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link91");
            grc.AddLinkByNodeName("osm4274320605", "osm4274320606", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link92");
            grc.AddLinkByNodeName("osm4846255734", "osm4274320605", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link93");
            grc.AddLinkByNodeName("osm4846255733", "osm4846255734", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link94");
            grc.AddLinkByNodeName("osm1488880314", "osm4846255733", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link95");
            grc.AddLinkByNodeName("osm1488880178", "osm1488880314", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link96");
            grc.AddLinkByNodeName("osm1488880209", "osm1488880178", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link97");
            grc.AddLinkByNodeName("osm4856079655", "osm1488880209", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link98");
            grc.AddLinkByNodeName("osm4846255732", "osm4856079655", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link99");
            grc.AddLinkByNodeName("osm4856079656", "osm4846255732", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link100");
            grc.AddLinkByNodeName("osm4846255731", "osm4856079656", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link101");
            grc.AddLinkByNodeName("osm4856079657", "osm4846255731", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link102");
            grc.AddLinkByNodeName("osm4856079658", "osm4856079657", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link103");
            grc.AddLinkByNodeName("osm4846255730", "osm4856079658", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link104");
            grc.AddLinkByNodeName("osm4846255729", "osm4846255730", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link105");
            grc.AddLinkByNodeName("osm1488880213", "osm4846255729", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link106");
            grc.AddLinkByNodeName("osm7516957565", "osm1488880213", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link107");
            grc.AddLinkByNodeName("osm4856079632", "osm7516957565", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link108");
            grc.AddLinkByNodeName("osm7516983686", "osm4856079632", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link109");
            grc.AddLinkByNodeName("osm1488880207", "osm7516983686", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link110");
            grc.AddLinkByNodeName("osm7291607566", "osm1488880207", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link111");
            grc.AddLinkByNodeName("osm7516983687", "osm7291607566", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link112");
            grc.AddLinkByNodeName("osm4856079633", "osm7516983687", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link113");
            grc.AddLinkByNodeName("osm7291607565", "osm4856079633", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link114");
            grc.AddLinkByNodeName("osm4856079659", "osm7291607565", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link115");
            grc.AddLinkByNodeName("osm7516983685", "osm4856079659", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link116");
            grc.AddLinkByNodeName("osm1488880604", "osm7516983685", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link117");
            grc.AddLinkByNodeName("osm1488880302", "osm1488880604", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link118");
            grc.AddLinkByNodeName("osm1488880400", "osm1488880302", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link119");
            grc.AddLinkByNodeName("osm4856079660", "osm1488880400", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link120");
            grc.AddLinkByNodeName("osm1488880267", "osm4856079660", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link121");
            grc.AddLinkByNodeName("osm7239216384", "osm1488880267", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link122");
            grc.AddLinkByNodeName("osm4846295260", "osm7239216384", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link123");
            grc.AddLinkByNodeName("osm4856079661", "osm4846295260", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link124");
            grc.AddLinkByNodeName("osm4846295261", "osm4856079661", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link125");
            grc.AddLinkByNodeName("osm4856079662", "osm4846295261", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link126");
            grc.AddLinkByNodeName("osm4856079663", "osm4856079662", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link127");
            grc.AddLinkByNodeName("osm4846295262", "osm4856079663", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link128");
            grc.AddLinkByNodeName("osm4846295263", "osm4846295262", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link129");
            grc.AddLinkByNodeName("osm1488880492", "osm4846295263", usetype: LinkUse.bldwall, comment: "Microsoft Studio A.link130");

            grc.AddLinkByNodeName("osm4829304089", "osm1488880315", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link1");
            grc.AddLinkByNodeName("osm1488880534", "osm4829304089", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link2");
            grc.AddLinkByNodeName("osm1488880441", "osm1488880534", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link3");
            grc.AddLinkByNodeName("osm1488880430", "osm1488880441", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link4");
            grc.AddLinkByNodeName("osm1488880229", "osm1488880430", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link5");
            grc.AddLinkByNodeName("osm1488880549", "osm1488880229", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link6");
            grc.AddLinkByNodeName("osm1488902093", "osm1488880549", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link7");
            grc.AddLinkByNodeName("osm1488880280", "osm1488902093", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link8");
            grc.AddLinkByNodeName("osm4829305389", "osm1488880280", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link9");
            grc.AddLinkByNodeName("osm4829305388", "osm4829305389", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link10");
            grc.AddLinkByNodeName("osm4829305387", "osm4829305388", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link11");
            grc.AddLinkByNodeName("osm4829350209", "osm4829305387", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link12");
            grc.AddLinkByNodeName("osm4829305386", "osm4829350209", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link13");
            grc.AddLinkByNodeName("osm4829305385", "osm4829305386", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link14");
            grc.AddLinkByNodeName("osm1488880585", "osm4829305385", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link15");
            grc.AddLinkByNodeName("osm1488880601", "osm1488880585", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link16");
            grc.AddLinkByNodeName("osm1488880615", "osm1488880601", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link17");
            grc.AddLinkByNodeName("osm7152737866", "osm1488880615", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link18");
            grc.AddLinkByNodeName("osm1488880261", "osm7152737866", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link19");
            grc.AddLinkByNodeName("osm1488880345", "osm1488880261", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link20");
            grc.AddLinkByNodeName("osm1538630559", "osm1488880345", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link21");
            grc.AddLinkByNodeName("osm4829305378", "osm1538630559", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link22");
            grc.AddLinkByNodeName("osm6042865993", "osm4829305378", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link23");
            grc.AddLinkByNodeName("osm4829305376", "osm6042865993", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link24");
            grc.AddLinkByNodeName("osm1488880596", "osm4829305376", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link25");
            grc.AddLinkByNodeName("osm4829305375", "osm1488880596", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link26");
            grc.AddLinkByNodeName("osm1488880471", "osm4829305375", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link27");
            grc.AddLinkByNodeName("osm4829305374", "osm1488880471", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link28");
            grc.AddLinkByNodeName("osm4829304088", "osm4829305374", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link29");
            grc.AddLinkByNodeName("osm1488880306", "osm4829304088", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link30");
            grc.AddLinkByNodeName("osm1488880192", "osm1488880306", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link31");
            grc.AddLinkByNodeName("osm1488880315", "osm1488880192", usetype: LinkUse.bldwall, comment: "Microsoft Submixer.link32");

            grc.AddLinkByNodeName("osm7469351355", "osm1488880222", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link1");
            grc.AddLinkByNodeName("osm6997611083", "osm7469351355", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link2");
            grc.AddLinkByNodeName("osm1491011803", "osm6997611083", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link3");
            grc.AddLinkByNodeName("osm7469351330", "osm1491011803", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link4");
            grc.AddLinkByNodeName("osm1488880187", "osm7469351330", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link5");
            grc.AddLinkByNodeName("osm1488880169", "osm1488880187", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link6");
            grc.AddLinkByNodeName("osm1488880365", "osm1488880169", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link7");
            grc.AddLinkByNodeName("osm1488880366", "osm1488880365", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link8");
            grc.AddLinkByNodeName("osm1488880588", "osm1488880366", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link9");
            grc.AddLinkByNodeName("osm4856281098", "osm1488880588", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link10");
            grc.AddLinkByNodeName("osm4856281099", "osm4856281098", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link11");
            grc.AddLinkByNodeName("osm4856281100", "osm4856281099", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link12");
            grc.AddLinkByNodeName("osm4856281101", "osm4856281100", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link13");
            grc.AddLinkByNodeName("osm1488880483", "osm4856281101", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link14");
            grc.AddLinkByNodeName("osm1488880174", "osm1488880483", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link15");
            grc.AddLinkByNodeName("osm1488880168", "osm1488880174", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link16");
            grc.AddLinkByNodeName("osm4823527349", "osm1488880168", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link17");
            grc.AddLinkByNodeName("osm4823527348", "osm4823527349", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link18");
            grc.AddLinkByNodeName("osm4823527347", "osm4823527348", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link19");
            grc.AddLinkByNodeName("osm4823527346", "osm4823527347", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link20");
            grc.AddLinkByNodeName("osm4823527345", "osm4823527346", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link21");
            grc.AddLinkByNodeName("osm4823527344", "osm4823527345", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link22");
            grc.AddLinkByNodeName("osm4823527343", "osm4823527344", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link23");
            grc.AddLinkByNodeName("osm4823527350", "osm4823527343", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link24");
            grc.AddLinkByNodeName("osm1488880179", "osm4823527350", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link25");
            grc.AddLinkByNodeName("osm1491011784", "osm1488880179", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link26");
            grc.AddLinkByNodeName("osm1488880455", "osm1491011784", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link27");
            grc.AddLinkByNodeName("osm1488880470", "osm1488880455", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link28");
            grc.AddLinkByNodeName("osm7529022829", "osm1488880470", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link29");
            grc.AddLinkByNodeName("osm1488880426", "osm7529022829", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link30");
            grc.AddLinkByNodeName("osm6997724812", "osm1488880426", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link31");
            grc.AddLinkByNodeName("osm7227686559", "osm6997724812", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link32");
            grc.AddLinkByNodeName("osm1488880215", "osm7227686559", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link33");
            grc.AddLinkByNodeName("osm7529022858", "osm1488880215", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link34");
            grc.AddLinkByNodeName("osm1488880266", "osm7529022858", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link35");
            grc.AddLinkByNodeName("osm7529022859", "osm1488880266", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link36");
            grc.AddLinkByNodeName("osm4856281097", "osm7529022859", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link37");
            grc.AddLinkByNodeName("osm4856281096", "osm4856281097", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link38");
            grc.AddLinkByNodeName("osm4856281095", "osm4856281096", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link39");
            grc.AddLinkByNodeName("osm4856281094", "osm4856281095", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link40");
            grc.AddLinkByNodeName("osm4856281093", "osm4856281094", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link41");
            grc.AddLinkByNodeName("osm4856281092", "osm4856281093", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link42");
            grc.AddLinkByNodeName("osm4856281091", "osm4856281092", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link43");
            grc.AddLinkByNodeName("osm4856281090", "osm4856281091", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link44");
            grc.AddLinkByNodeName("osm7529022860", "osm4856281090", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link45");
            grc.AddLinkByNodeName("osm1488880472", "osm7529022860", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link46");
            grc.AddLinkByNodeName("osm1488880546", "osm1488880472", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link47");
            grc.AddLinkByNodeName("osm1488880299", "osm1488880546", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link48");
            grc.AddLinkByNodeName("osm7529022870", "osm1488880299", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link49");
            grc.AddLinkByNodeName("osm4856281088", "osm7529022870", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link50");
            grc.AddLinkByNodeName("osm4856281083", "osm4856281088", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link51");
            grc.AddLinkByNodeName("osm4856281082", "osm4856281083", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link52");
            grc.AddLinkByNodeName("osm4856281081", "osm4856281082", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link53");
            grc.AddLinkByNodeName("osm7529022878", "osm4856281081", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link54");
            grc.AddLinkByNodeName("osm1488880638", "osm7529022878", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link55");
            grc.AddLinkByNodeName("osm7529022877", "osm1488880638", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link56");
            grc.AddLinkByNodeName("osm4856281084", "osm7529022877", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link57");
            grc.AddLinkByNodeName("osm7463723852", "osm4856281084", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link58");
            grc.AddLinkByNodeName("osm1488880263", "osm7463723852", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link59");
            grc.AddLinkByNodeName("osm1488880234", "osm1488880263", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link60");
            grc.AddLinkByNodeName("osm1488880151", "osm1488880234", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link61");
            grc.AddLinkByNodeName("osm1488880637", "osm1488880151", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link62");
            grc.AddLinkByNodeName("osm7463723855", "osm1488880637", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link63");
            grc.AddLinkByNodeName("osm1488880566", "osm7463723855", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link64");
            grc.AddLinkByNodeName("osm1488880227", "osm1488880566", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link65");
            grc.AddLinkByNodeName("osm6997611926", "osm1488880227", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link66");
            grc.AddLinkByNodeName("osm7463723863", "osm6997611926", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link67");
            grc.AddLinkByNodeName("osm1488880481", "osm7463723863", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link68");
            grc.AddLinkByNodeName("osm1488880153", "osm1488880481", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link69");
            grc.AddLinkByNodeName("osm4823592286", "osm1488880153", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link70");
            grc.AddLinkByNodeName("osm4823592282", "osm4823592286", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link71");
            grc.AddLinkByNodeName("osm4818775952", "osm4823592282", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link72");
            grc.AddLinkByNodeName("osm7469351338", "osm4818775952", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link73");
            grc.AddLinkByNodeName("osm4823592284", "osm7469351338", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link74");
            grc.AddLinkByNodeName("osm4856298096", "osm4823592284", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link75");
            grc.AddLinkByNodeName("osm4856298095", "osm4856298096", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link76");
            grc.AddLinkByNodeName("osm4823592283", "osm4856298095", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link77");
            grc.AddLinkByNodeName("osm7469351336", "osm4823592283", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link78");
            grc.AddLinkByNodeName("osm7469351337", "osm7469351336", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link79");
            grc.AddLinkByNodeName("osm7529076186", "osm7469351337", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link80");
            grc.AddLinkByNodeName("osm1488880343", "osm7529076186", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link81");
            grc.AddLinkByNodeName("osm7529076185", "osm1488880343", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link82");
            grc.AddLinkByNodeName("osm7529076208", "osm7529076185", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link83");
            grc.AddLinkByNodeName("osm7227704435", "osm7529076208", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link84");
            grc.AddLinkByNodeName("osm7529076207", "osm7227704435", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link85");
            grc.AddLinkByNodeName("osm1488880589", "osm7529076207", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link86");
            grc.AddLinkByNodeName("osm7529076211", "osm1488880589", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link87");
            grc.AddLinkByNodeName("osm7529076206", "osm7529076211", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link88");
            grc.AddLinkByNodeName("osm4856281118", "osm7529076206", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link89");
            grc.AddLinkByNodeName("osm7529076205", "osm4856281118", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link90");
            grc.AddLinkByNodeName("osm4856281117", "osm7529076205", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link91");
            grc.AddLinkByNodeName("osm4856281116", "osm4856281117", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link92");
            grc.AddLinkByNodeName("osm7529076204", "osm4856281116", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link93");
            grc.AddLinkByNodeName("osm4856281115", "osm7529076204", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link94");
            grc.AddLinkByNodeName("osm7529076203", "osm4856281115", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link95");
            grc.AddLinkByNodeName("osm7529076214", "osm7529076203", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link96");
            grc.AddLinkByNodeName("osm7529076215", "osm7529076214", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link97");
            grc.AddLinkByNodeName("osm1488880587", "osm7529076215", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link98");
            grc.AddLinkByNodeName("osm7529076259", "osm1488880587", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link99");
            grc.AddLinkByNodeName("osm4856281085", "osm7529076259", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link100");
            grc.AddLinkByNodeName("osm7529076196", "osm4856281085", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link101");
            grc.AddLinkByNodeName("osm4856281086", "osm7529076196", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link102");
            grc.AddLinkByNodeName("osm4856281087", "osm4856281086", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link103");
            grc.AddLinkByNodeName("osm7529076187", "osm4856281087", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link104");
            grc.AddLinkByNodeName("osm1488880194", "osm7529076187", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link105");
            grc.AddLinkByNodeName("osm4818775932", "osm1488880194", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link106");
            grc.AddLinkByNodeName("osm7227704424", "osm4818775932", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link107");
            grc.AddLinkByNodeName("osm1488880300", "osm7227704424", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link108");
            grc.AddLinkByNodeName("osm1488880250", "osm1488880300", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link109");
            grc.AddLinkByNodeName("osm7227704416", "osm1488880250", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link110");
            grc.AddLinkByNodeName("osm7469351344", "osm7227704416", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link111");
            grc.AddLinkByNodeName("osm4856281114", "osm7469351344", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link112");
            grc.AddLinkByNodeName("osm7469351343", "osm4856281114", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link113");
            grc.AddLinkByNodeName("osm4856281113", "osm7469351343", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link114");
            grc.AddLinkByNodeName("osm4856281112", "osm4856281113", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link115");
            grc.AddLinkByNodeName("osm7469351342", "osm4856281112", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link116");
            grc.AddLinkByNodeName("osm4856281111", "osm7469351342", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link117");
            grc.AddLinkByNodeName("osm7469351341", "osm4856281111", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link118");
            grc.AddLinkByNodeName("osm7469351340", "osm7469351341", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link119");
            grc.AddLinkByNodeName("osm7469351334", "osm7469351340", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link120");
            grc.AddLinkByNodeName("osm1488880340", "osm7469351334", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link121");
            grc.AddLinkByNodeName("osm1488880321", "osm1488880340", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link122");
            grc.AddLinkByNodeName("osm1488880533", "osm1488880321", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link123");
            grc.AddLinkByNodeName("osm7469351333", "osm1488880533", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link124");
            grc.AddLinkByNodeName("osm6997611079", "osm7469351333", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link125");
            grc.AddLinkByNodeName("osm4856281108", "osm6997611079", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link126");
            grc.AddLinkByNodeName("osm4856281102", "osm4856281108", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link127");
            grc.AddLinkByNodeName("osm4856281103", "osm4856281102", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link128");
            grc.AddLinkByNodeName("osm4856281109", "osm4856281103", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link129");
            grc.AddLinkByNodeName("osm4856281107", "osm4856281109", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link130");
            grc.AddLinkByNodeName("osm4856281105", "osm4856281107", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link131");
            grc.AddLinkByNodeName("osm4856281106", "osm4856281105", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link132");
            grc.AddLinkByNodeName("osm4856281104", "osm4856281106", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link133");
            grc.AddLinkByNodeName("osm7469351345", "osm4856281104", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link134");
            grc.AddLinkByNodeName("osm7469351353", "osm7469351345", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link135");
            grc.AddLinkByNodeName("osm1488880222", "osm7469351353", usetype: LinkUse.bldwall, comment: "Microsoft Studio C.link136");

            grc.AddLinkByNodeName("osm7516983719", "osm1491011768", usetype: LinkUse.bldwall, comment: "bld002.link1");
            grc.AddLinkByNodeName("osm6997506293", "osm7516983719", usetype: LinkUse.bldwall, comment: "bld002.link2");
            grc.AddLinkByNodeName("osm1491011759", "osm6997506293", usetype: LinkUse.bldwall, comment: "bld002.link3");
            grc.AddLinkByNodeName("osm1491011811", "osm1491011759", usetype: LinkUse.bldwall, comment: "bld002.link4");
            grc.AddLinkByNodeName("osm7245133474", "osm1491011811", usetype: LinkUse.bldwall, comment: "bld002.link5");
            grc.AddLinkByNodeName("osm6997506294", "osm7245133474", usetype: LinkUse.bldwall, comment: "bld002.link6");
            grc.AddLinkByNodeName("osm7516983718", "osm6997506294", usetype: LinkUse.bldwall, comment: "bld002.link7");
            grc.AddLinkByNodeName("osm1491011758", "osm7516983718", usetype: LinkUse.bldwall, comment: "bld002.link8");
            grc.AddLinkByNodeName("osm1491011768", "osm1491011758", usetype: LinkUse.bldwall, comment: "bld002.link9");

            grc.AddLinkByNodeName("osm7609699088", "osm1491102463", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link1");
            grc.AddLinkByNodeName("osm7609699089", "osm7609699088", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link2");
            grc.AddLinkByNodeName("osm1491102453", "osm7609699089", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link3");
            grc.AddLinkByNodeName("osm1491102459", "osm1491102453", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link4");
            grc.AddLinkByNodeName("osm7609680981", "osm1491102459", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link5");
            grc.AddLinkByNodeName("osm7609680979", "osm7609680981", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link6");
            grc.AddLinkByNodeName("osm7609680980", "osm7609680979", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link7");
            grc.AddLinkByNodeName("osm1491102462", "osm7609680980", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link8");
            grc.AddLinkByNodeName("osm4049735588", "osm1491102462", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link9");
            grc.AddLinkByNodeName("osm7609680978", "osm4049735588", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link10");
            grc.AddLinkByNodeName("osm7609699085", "osm7609680978", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link11");
            grc.AddLinkByNodeName("osm7609699086", "osm7609699085", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link12");
            grc.AddLinkByNodeName("osm7609699087", "osm7609699086", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link13");
            grc.AddLinkByNodeName("osm1491102458", "osm7609699087", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link14");
            grc.AddLinkByNodeName("osm1491102465", "osm1491102458", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link15");
            grc.AddLinkByNodeName("osm6946131604", "osm1491102465", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link16");
            grc.AddLinkByNodeName("osm6946131605", "osm6946131604", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link17");
            grc.AddLinkByNodeName("osm1491102452", "osm6946131605", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link18");
            grc.AddLinkByNodeName("osm1491102451", "osm1491102452", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link19");
            grc.AddLinkByNodeName("osm6946131622", "osm1491102451", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link20");
            grc.AddLinkByNodeName("osm1491102463", "osm6946131622", usetype: LinkUse.bldwall, comment: "Microsoft Building 111.link21");

            grc.AddLinkByNodeName("osm4886187130", "osm1738823951", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link1");
            grc.AddLinkByNodeName("osm4886187129", "osm4886187130", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link2");
            grc.AddLinkByNodeName("osm1738823950", "osm4886187129", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link3");
            grc.AddLinkByNodeName("osm4892667580", "osm1738823950", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link4");
            grc.AddLinkByNodeName("osm1738823952", "osm4892667580", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link5");
            grc.AddLinkByNodeName("osm1738823953", "osm1738823952", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link6");
            grc.AddLinkByNodeName("osm4892667585", "osm1738823953", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link7");
            grc.AddLinkByNodeName("osm1738823959", "osm4892667585", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link8");
            grc.AddLinkByNodeName("osm4886187128", "osm1738823959", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link9");
            grc.AddLinkByNodeName("osm4892667586", "osm4886187128", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link10");
            grc.AddLinkByNodeName("osm4886187127", "osm4892667586", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link11");
            grc.AddLinkByNodeName("osm1738823960", "osm4886187127", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link12");
            grc.AddLinkByNodeName("osm7137804866", "osm1738823960", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link13");
            grc.AddLinkByNodeName("osm1738823961", "osm7137804866", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link14");
            grc.AddLinkByNodeName("osm1738823962", "osm1738823961", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link15");
            grc.AddLinkByNodeName("osm1738823963", "osm1738823962", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link16");
            grc.AddLinkByNodeName("osm1738823965", "osm1738823963", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link17");
            grc.AddLinkByNodeName("osm4892667568", "osm1738823965", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link18");
            grc.AddLinkByNodeName("osm1738823957", "osm4892667568", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link19");
            grc.AddLinkByNodeName("osm1738823958", "osm1738823957", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link20");
            grc.AddLinkByNodeName("osm4886187126", "osm1738823958", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link21");
            grc.AddLinkByNodeName("osm4886187125", "osm4886187126", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link22");
            grc.AddLinkByNodeName("osm4886187124", "osm4886187125", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link23");
            grc.AddLinkByNodeName("osm4886187123", "osm4886187124", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link24");
            grc.AddLinkByNodeName("osm1738823956", "osm4886187123", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link25");
            grc.AddLinkByNodeName("osm1738823955", "osm1738823956", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link26");
            grc.AddLinkByNodeName("osm1738823951", "osm1738823955", usetype: LinkUse.bldwall, comment: "Microsoft Studio F.link27");

            grc.AddLinkByNodeName("osm1738823930", "osm1738823929", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link1");
            grc.AddLinkByNodeName("osm1738823927", "osm1738823930", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link2");
            grc.AddLinkByNodeName("osm1738823928", "osm1738823927", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link3");
            grc.AddLinkByNodeName("osm4886186915", "osm1738823928", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link4");
            grc.AddLinkByNodeName("osm4886286152", "osm4886186915", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link5");
            grc.AddLinkByNodeName("osm4886286145", "osm4886286152", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link6");
            grc.AddLinkByNodeName("osm4886286146", "osm4886286145", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link7");
            grc.AddLinkByNodeName("osm4886186918", "osm4886286146", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link8");
            grc.AddLinkByNodeName("osm4886186919", "osm4886186918", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link9");
            grc.AddLinkByNodeName("osm1738823936", "osm4886186919", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link10");
            grc.AddLinkByNodeName("osm1738823937", "osm1738823936", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link11");
            grc.AddLinkByNodeName("osm1738823939", "osm1738823937", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link12");
            grc.AddLinkByNodeName("osm1738823938", "osm1738823939", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link13");
            grc.AddLinkByNodeName("osm4886186920", "osm1738823938", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link14");
            grc.AddLinkByNodeName("osm4886186913", "osm4886186920", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link15");
            grc.AddLinkByNodeName("osm4886186914", "osm4886186913", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link16");
            grc.AddLinkByNodeName("osm1738823943", "osm4886186914", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link17");
            grc.AddLinkByNodeName("osm1738823942", "osm1738823943", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link18");
            grc.AddLinkByNodeName("osm1738823941", "osm1738823942", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link19");
            grc.AddLinkByNodeName("osm1738823940", "osm1738823941", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link20");
            grc.AddLinkByNodeName("osm4886187121", "osm1738823940", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link21");
            grc.AddLinkByNodeName("osm4886187122", "osm4886187121", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link22");
            grc.AddLinkByNodeName("osm4886286157", "osm4886187122", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link23");
            grc.AddLinkByNodeName("osm1738823934", "osm4886286157", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link24");
            grc.AddLinkByNodeName("osm1738823932", "osm1738823934", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link25");
            grc.AddLinkByNodeName("osm4886286153", "osm1738823932", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link26");
            grc.AddLinkByNodeName("osm1738823929", "osm4886286153", usetype: LinkUse.bldwall, comment: "Microsoft Studio G.link27");

            grc.AddLinkByNodeName("osm4017339901", "osm4017339900", usetype: LinkUse.bldwall, comment: "bld003.link1");
            grc.AddLinkByNodeName("osm4017339902", "osm4017339901", usetype: LinkUse.bldwall, comment: "bld003.link2");
            grc.AddLinkByNodeName("osm4017339903", "osm4017339902", usetype: LinkUse.bldwall, comment: "bld003.link3");
            grc.AddLinkByNodeName("osm4017339900", "osm4017339903", usetype: LinkUse.bldwall, comment: "bld003.link4");

            grc.AddLinkByNodeName("osm4049735529", "osm4049735568", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link1");
            grc.AddLinkByNodeName("osm4049735579", "osm4049735529", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link2");
            grc.AddLinkByNodeName("osm4049735522", "osm4049735579", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link3");
            grc.AddLinkByNodeName("osm6301563931", "osm4049735522", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link4");
            grc.AddLinkByNodeName("osm4049735533", "osm6301563931", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link5");
            grc.AddLinkByNodeName("osm4049735569", "osm4049735533", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link6");
            grc.AddLinkByNodeName("osm6301563932", "osm4049735569", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link7");
            grc.AddLinkByNodeName("osm4049735539", "osm6301563932", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link8");
            grc.AddLinkByNodeName("osm4049735542", "osm4049735539", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link9");
            grc.AddLinkByNodeName("osm7184471215", "osm4049735542", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link10");
            grc.AddLinkByNodeName("osm4049735574", "osm7184471215", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link11");
            grc.AddLinkByNodeName("osm4049735559", "osm4049735574", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link12");
            grc.AddLinkByNodeName("osm4049735586", "osm4049735559", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link13");
            grc.AddLinkByNodeName("osm4049735532", "osm4049735586", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link14");
            grc.AddLinkByNodeName("osm4049735541", "osm4049735532", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link15");
            grc.AddLinkByNodeName("osm4049735578", "osm4049735541", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link16");
            grc.AddLinkByNodeName("osm4049735567", "osm4049735578", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link17");
            grc.AddLinkByNodeName("osm4049735551", "osm4049735567", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link18");
            grc.AddLinkByNodeName("osm4049735585", "osm4049735551", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link19");
            grc.AddLinkByNodeName("osm4823322839", "osm4049735585", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link20");
            grc.AddLinkByNodeName("osm4823322838", "osm4823322839", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link21");
            grc.AddLinkByNodeName("osm4823322837", "osm4823322838", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link22");
            grc.AddLinkByNodeName("osm4823322836", "osm4823322837", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link23");
            grc.AddLinkByNodeName("osm7184471210", "osm4823322836", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link24");
            grc.AddLinkByNodeName("osm7184471212", "osm7184471210", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link25");
            grc.AddLinkByNodeName("osm7184471213", "osm7184471212", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link26");
            grc.AddLinkByNodeName("osm7184471211", "osm7184471213", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link27");
            grc.AddLinkByNodeName("osm4049736489", "osm7184471211", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link28");
            grc.AddLinkByNodeName("osm6306188958", "osm4049736489", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link29");
            grc.AddLinkByNodeName("osm6306188954", "osm6306188958", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link30");
            grc.AddLinkByNodeName("osm4049735580", "osm6306188954", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link31");
            grc.AddLinkByNodeName("osm6306188955", "osm4049735580", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link32");
            grc.AddLinkByNodeName("osm6978397740", "osm6306188955", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link33");
            grc.AddLinkByNodeName("osm6306188948", "osm6978397740", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link34");
            grc.AddLinkByNodeName("osm4049735554", "osm6306188948", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link35");
            grc.AddLinkByNodeName("osm4049735568", "osm4049735554", usetype: LinkUse.bldwall, comment: "Honeywell Building 3.link36");

            grc.AddLinkByNodeName("osm7230628375", "osm4621191630", usetype: LinkUse.bldwall, comment: "bld004.link1");
            grc.AddLinkByNodeName("osm1490676089", "osm7230628375", usetype: LinkUse.bldwall, comment: "bld004.link2");
            grc.AddLinkByNodeName("osm7245130935", "osm1490676089", usetype: LinkUse.bldwall, comment: "bld004.link3");
            grc.AddLinkByNodeName("osm4621191631", "osm7245130935", usetype: LinkUse.bldwall, comment: "bld004.link4");
            grc.AddLinkByNodeName("osm7245130934", "osm4621191631", usetype: LinkUse.bldwall, comment: "bld004.link5");
            grc.AddLinkByNodeName("osm4846295227", "osm7245130934", usetype: LinkUse.bldwall, comment: "bld004.link6");
            grc.AddLinkByNodeName("osm7245130921", "osm4846295227", usetype: LinkUse.bldwall, comment: "bld004.link7");
            grc.AddLinkByNodeName("osm7245130910", "osm7245130921", usetype: LinkUse.bldwall, comment: "bld004.link8");
            grc.AddLinkByNodeName("osm4621191632", "osm7245130910", usetype: LinkUse.bldwall, comment: "bld004.link9");
            grc.AddLinkByNodeName("osm7245130909", "osm4621191632", usetype: LinkUse.bldwall, comment: "bld004.link10");
            grc.AddLinkByNodeName("osm7245130922", "osm7245130909", usetype: LinkUse.bldwall, comment: "bld004.link11");
            grc.AddLinkByNodeName("osm4621191643", "osm7245130922", usetype: LinkUse.bldwall, comment: "bld004.link12");
            grc.AddLinkByNodeName("osm7230628376", "osm4621191643", usetype: LinkUse.bldwall, comment: "bld004.link13");
            grc.AddLinkByNodeName("osm4621191633", "osm7230628376", usetype: LinkUse.bldwall, comment: "bld004.link14");
            grc.AddLinkByNodeName("osm4621191630", "osm4621191633", usetype: LinkUse.bldwall, comment: "bld004.link15");

            grc.AddLinkByNodeName("osm4621191635", "osm4621191634", usetype: LinkUse.bldwall, comment: "bld005.link1");
            grc.AddLinkByNodeName("osm4621191636", "osm4621191635", usetype: LinkUse.bldwall, comment: "bld005.link2");
            grc.AddLinkByNodeName("osm4621191637", "osm4621191636", usetype: LinkUse.bldwall, comment: "bld005.link3");
            grc.AddLinkByNodeName("osm4621191634", "osm4621191637", usetype: LinkUse.bldwall, comment: "bld005.link4");

            grc.AddLinkByNodeName("osm4621191640", "osm4621191639", usetype: LinkUse.bldwall, comment: "bld006.link1");
            grc.AddLinkByNodeName("osm4829304117", "osm4621191640", usetype: LinkUse.bldwall, comment: "bld006.link2");
            grc.AddLinkByNodeName("osm4621191641", "osm4829304117", usetype: LinkUse.bldwall, comment: "bld006.link3");
            grc.AddLinkByNodeName("osm7230628164", "osm4621191641", usetype: LinkUse.bldwall, comment: "bld006.link4");
            grc.AddLinkByNodeName("osm4621191642", "osm7230628164", usetype: LinkUse.bldwall, comment: "bld006.link5");
            grc.AddLinkByNodeName("osm4621191639", "osm4621191642", usetype: LinkUse.bldwall, comment: "bld006.link6");

            grc.AddLinkByNodeName("osm7227704290", "osm4621191650", usetype: LinkUse.bldwall, comment: "bld007.link1");
            grc.AddLinkByNodeName("osm4621191651", "osm7227704290", usetype: LinkUse.bldwall, comment: "bld007.link2");
            grc.AddLinkByNodeName("osm7227704272", "osm4621191651", usetype: LinkUse.bldwall, comment: "bld007.link3");
            grc.AddLinkByNodeName("osm4621191652", "osm7227704272", usetype: LinkUse.bldwall, comment: "bld007.link4");
            grc.AddLinkByNodeName("osm4621191653", "osm4621191652", usetype: LinkUse.bldwall, comment: "bld007.link5");
            grc.AddLinkByNodeName("osm7227704285", "osm4621191653", usetype: LinkUse.bldwall, comment: "bld007.link6");
            grc.AddLinkByNodeName("osm4621191654", "osm7227704285", usetype: LinkUse.bldwall, comment: "bld007.link7");
            grc.AddLinkByNodeName("osm7227704280", "osm4621191654", usetype: LinkUse.bldwall, comment: "bld007.link8");
            grc.AddLinkByNodeName("osm4621191655", "osm7227704280", usetype: LinkUse.bldwall, comment: "bld007.link9");
            grc.AddLinkByNodeName("osm7227704291", "osm4621191655", usetype: LinkUse.bldwall, comment: "bld007.link10");
            grc.AddLinkByNodeName("osm4621191650", "osm7227704291", usetype: LinkUse.bldwall, comment: "bld007.link11");

            grc.AddLinkByNodeName("osm5818373712", "osm5818373711", usetype: LinkUse.bldwall, comment: "Overlake Village Station.link1");
            grc.AddLinkByNodeName("osm5818373713", "osm5818373712", usetype: LinkUse.bldwall, comment: "Overlake Village Station.link2");
            grc.AddLinkByNodeName("osm5818373714", "osm5818373713", usetype: LinkUse.bldwall, comment: "Overlake Village Station.link3");
            grc.AddLinkByNodeName("osm5818373711", "osm5818373714", usetype: LinkUse.bldwall, comment: "Overlake Village Station.link4");

            grc.AddLinkByNodeName("osm5916951863", "osm5916951862", usetype: LinkUse.bldwall, comment: "bld008.link1");
            grc.AddLinkByNodeName("osm5916951864", "osm5916951863", usetype: LinkUse.bldwall, comment: "bld008.link2");
            grc.AddLinkByNodeName("osm5916951865", "osm5916951864", usetype: LinkUse.bldwall, comment: "bld008.link3");
            grc.AddLinkByNodeName("osm5916951866", "osm5916951865", usetype: LinkUse.bldwall, comment: "bld008.link4");
            grc.AddLinkByNodeName("osm5916951867", "osm5916951866", usetype: LinkUse.bldwall, comment: "bld008.link5");
            grc.AddLinkByNodeName("osm5916951868", "osm5916951867", usetype: LinkUse.bldwall, comment: "bld008.link6");
            grc.AddLinkByNodeName("osm5916951869", "osm5916951868", usetype: LinkUse.bldwall, comment: "bld008.link7");
            grc.AddLinkByNodeName("osm5916951872", "osm5916951869", usetype: LinkUse.bldwall, comment: "bld008.link8");
            grc.AddLinkByNodeName("osm5916951862", "osm5916951872", usetype: LinkUse.bldwall, comment: "bld008.link9");

            grc.AddLinkByNodeName("osm6042865824", "osm6042865823", usetype: LinkUse.bldwall, comment: "bld009.link1");
            grc.AddLinkByNodeName("osm6042865825", "osm6042865824", usetype: LinkUse.bldwall, comment: "bld009.link2");
            grc.AddLinkByNodeName("osm6042865826", "osm6042865825", usetype: LinkUse.bldwall, comment: "bld009.link3");
            grc.AddLinkByNodeName("osm6042865823", "osm6042865826", usetype: LinkUse.bldwall, comment: "bld009.link4");

            grc.AddLinkByNodeName("osm6042865848", "osm6042865847", usetype: LinkUse.bldwall, comment: "bld010.link1");
            grc.AddLinkByNodeName("osm6042865849", "osm6042865848", usetype: LinkUse.bldwall, comment: "bld010.link2");
            grc.AddLinkByNodeName("osm7230628207", "osm6042865849", usetype: LinkUse.bldwall, comment: "bld010.link3");
            grc.AddLinkByNodeName("osm6042865850", "osm7230628207", usetype: LinkUse.bldwall, comment: "bld010.link4");
            grc.AddLinkByNodeName("osm7230628208", "osm6042865850", usetype: LinkUse.bldwall, comment: "bld010.link5");
            grc.AddLinkByNodeName("osm6042865847", "osm7230628208", usetype: LinkUse.bldwall, comment: "bld010.link6");

            grc.AddLinkByNodeName("osm6042865854", "osm6042865853", usetype: LinkUse.bldwall, comment: "bld011.link1");
            grc.AddLinkByNodeName("osm6042865855", "osm6042865854", usetype: LinkUse.bldwall, comment: "bld011.link2");
            grc.AddLinkByNodeName("osm6042865856", "osm6042865855", usetype: LinkUse.bldwall, comment: "bld011.link3");
            grc.AddLinkByNodeName("osm6042865853", "osm6042865856", usetype: LinkUse.bldwall, comment: "bld011.link4");

            grc.AddLinkByNodeName("osm6323277625", "osm6323277624", usetype: LinkUse.bldwall, comment: "Honeywell Building 4.link1");
            grc.AddLinkByNodeName("osm6323277626", "osm6323277625", usetype: LinkUse.bldwall, comment: "Honeywell Building 4.link2");
            grc.AddLinkByNodeName("osm6323277627", "osm6323277626", usetype: LinkUse.bldwall, comment: "Honeywell Building 4.link3");
            grc.AddLinkByNodeName("osm321549947", "osm6323277627", usetype: LinkUse.bldwall, comment: "Honeywell Building 4.link4");
            grc.AddLinkByNodeName("osm6323277623", "osm321549947", usetype: LinkUse.bldwall, comment: "Honeywell Building 4.link5");
            grc.AddLinkByNodeName("osm6323277624", "osm6323277623", usetype: LinkUse.bldwall, comment: "Honeywell Building 4.link6");

            grc.AddLinkByNodeName("osm6946122479", "osm6323443766", usetype: LinkUse.bldwall, comment: "bld012.link1");
            grc.AddLinkByNodeName("osm6323443767", "osm6946122479", usetype: LinkUse.bldwall, comment: "bld012.link2");
            grc.AddLinkByNodeName("osm6323443768", "osm6323443767", usetype: LinkUse.bldwall, comment: "bld012.link3");
            grc.AddLinkByNodeName("osm6323443769", "osm6323443768", usetype: LinkUse.bldwall, comment: "bld012.link4");
            grc.AddLinkByNodeName("osm321549340", "osm6323443769", usetype: LinkUse.bldwall, comment: "bld012.link5");
            grc.AddLinkByNodeName("osm6946122464", "osm321549340", usetype: LinkUse.bldwall, comment: "bld012.link6");
            grc.AddLinkByNodeName("osm6946122462", "osm6946122464", usetype: LinkUse.bldwall, comment: "bld012.link7");
            grc.AddLinkByNodeName("osm6946122472", "osm6946122462", usetype: LinkUse.bldwall, comment: "bld012.link8");
            grc.AddLinkByNodeName("osm6946122471", "osm6946122472", usetype: LinkUse.bldwall, comment: "bld012.link9");
            grc.AddLinkByNodeName("osm6323443770", "osm6946122471", usetype: LinkUse.bldwall, comment: "bld012.link10");
            grc.AddLinkByNodeName("osm6946122474", "osm6323443770", usetype: LinkUse.bldwall, comment: "bld012.link11");
            grc.AddLinkByNodeName("osm6323443771", "osm6946122474", usetype: LinkUse.bldwall, comment: "bld012.link12");
            grc.AddLinkByNodeName("osm6323443772", "osm6323443771", usetype: LinkUse.bldwall, comment: "bld012.link13");
            grc.AddLinkByNodeName("osm6323443766", "osm6323443772", usetype: LinkUse.bldwall, comment: "bld012.link14");

            grc.AddLinkByNodeName("osm6323443774", "osm6323443773", usetype: LinkUse.bldwall, comment: "bld013.link1");
            grc.AddLinkByNodeName("osm6323443775", "osm6323443774", usetype: LinkUse.bldwall, comment: "bld013.link2");
            grc.AddLinkByNodeName("osm4809166490", "osm6323443775", usetype: LinkUse.bldwall, comment: "bld013.link3");
            grc.AddLinkByNodeName("osm6323443776", "osm4809166490", usetype: LinkUse.bldwall, comment: "bld013.link4");
            grc.AddLinkByNodeName("osm6946122461", "osm6323443776", usetype: LinkUse.bldwall, comment: "bld013.link5");
            grc.AddLinkByNodeName("osm6323443777", "osm6946122461", usetype: LinkUse.bldwall, comment: "bld013.link6");
            grc.AddLinkByNodeName("osm6323443778", "osm6323443777", usetype: LinkUse.bldwall, comment: "bld013.link7");
            grc.AddLinkByNodeName("osm6323443779", "osm6323443778", usetype: LinkUse.bldwall, comment: "bld013.link8");
            grc.AddLinkByNodeName("osm6323443780", "osm6323443779", usetype: LinkUse.bldwall, comment: "bld013.link9");
            grc.AddLinkByNodeName("osm6323443781", "osm6323443780", usetype: LinkUse.bldwall, comment: "bld013.link10");
            grc.AddLinkByNodeName("osm6323443782", "osm6323443781", usetype: LinkUse.bldwall, comment: "bld013.link11");
            grc.AddLinkByNodeName("osm6323443773", "osm6323443782", usetype: LinkUse.bldwall, comment: "bld013.link12");

            grc.AddLinkByNodeName("osm6937998569", "osm6323444289", usetype: LinkUse.bldwall, comment: "3040 Apartments.link1");
            grc.AddLinkByNodeName("osm6323444302", "osm6937998569", usetype: LinkUse.bldwall, comment: "3040 Apartments.link2");
            grc.AddLinkByNodeName("osm6323444301", "osm6323444302", usetype: LinkUse.bldwall, comment: "3040 Apartments.link3");
            grc.AddLinkByNodeName("osm6937999589", "osm6323444301", usetype: LinkUse.bldwall, comment: "3040 Apartments.link4");
            grc.AddLinkByNodeName("osm6323444299", "osm6937999589", usetype: LinkUse.bldwall, comment: "3040 Apartments.link5");
            grc.AddLinkByNodeName("osm6323444300", "osm6323444299", usetype: LinkUse.bldwall, comment: "3040 Apartments.link6");
            grc.AddLinkByNodeName("osm6938241255", "osm6323444300", usetype: LinkUse.bldwall, comment: "3040 Apartments.link7");
            grc.AddLinkByNodeName("osm6323444290", "osm6938241255", usetype: LinkUse.bldwall, comment: "3040 Apartments.link8");
            grc.AddLinkByNodeName("osm6323444291", "osm6323444290", usetype: LinkUse.bldwall, comment: "3040 Apartments.link9");
            grc.AddLinkByNodeName("osm6323444306", "osm6323444291", usetype: LinkUse.bldwall, comment: "3040 Apartments.link10");
            grc.AddLinkByNodeName("osm6323444305", "osm6323444306", usetype: LinkUse.bldwall, comment: "3040 Apartments.link11");
            grc.AddLinkByNodeName("osm6323444304", "osm6323444305", usetype: LinkUse.bldwall, comment: "3040 Apartments.link12");
            grc.AddLinkByNodeName("osm6323444303", "osm6323444304", usetype: LinkUse.bldwall, comment: "3040 Apartments.link13");
            grc.AddLinkByNodeName("osm6323444292", "osm6323444303", usetype: LinkUse.bldwall, comment: "3040 Apartments.link14");
            grc.AddLinkByNodeName("osm6323444293", "osm6323444292", usetype: LinkUse.bldwall, comment: "3040 Apartments.link15");
            grc.AddLinkByNodeName("osm7137547762", "osm6323444293", usetype: LinkUse.bldwall, comment: "3040 Apartments.link16");
            grc.AddLinkByNodeName("osm6323444294", "osm7137547762", usetype: LinkUse.bldwall, comment: "3040 Apartments.link17");
            grc.AddLinkByNodeName("osm6710759980", "osm6323444294", usetype: LinkUse.bldwall, comment: "3040 Apartments.link18");
            grc.AddLinkByNodeName("osm6710759981", "osm6710759980", usetype: LinkUse.bldwall, comment: "3040 Apartments.link19");
            grc.AddLinkByNodeName("osm6710759982", "osm6710759981", usetype: LinkUse.bldwall, comment: "3040 Apartments.link20");
            grc.AddLinkByNodeName("osm6710759983", "osm6710759982", usetype: LinkUse.bldwall, comment: "3040 Apartments.link21");
            grc.AddLinkByNodeName("osm6323444295", "osm6710759983", usetype: LinkUse.bldwall, comment: "3040 Apartments.link22");
            grc.AddLinkByNodeName("osm6710796286", "osm6323444295", usetype: LinkUse.bldwall, comment: "3040 Apartments.link23");
            grc.AddLinkByNodeName("osm6710796287", "osm6710796286", usetype: LinkUse.bldwall, comment: "3040 Apartments.link24");
            grc.AddLinkByNodeName("osm6710796285", "osm6710796287", usetype: LinkUse.bldwall, comment: "3040 Apartments.link25");
            grc.AddLinkByNodeName("osm6710759984", "osm6710796285", usetype: LinkUse.bldwall, comment: "3040 Apartments.link26");
            grc.AddLinkByNodeName("osm6937998562", "osm6710759984", usetype: LinkUse.bldwall, comment: "3040 Apartments.link27");
            grc.AddLinkByNodeName("osm6323444296", "osm6937998562", usetype: LinkUse.bldwall, comment: "3040 Apartments.link28");
            grc.AddLinkByNodeName("osm6937998581", "osm6323444296", usetype: LinkUse.bldwall, comment: "3040 Apartments.link29");
            grc.AddLinkByNodeName("osm6710796289", "osm6937998581", usetype: LinkUse.bldwall, comment: "3040 Apartments.link30");
            grc.AddLinkByNodeName("osm6710796288", "osm6710796289", usetype: LinkUse.bldwall, comment: "3040 Apartments.link31");
            grc.AddLinkByNodeName("osm6323444297", "osm6710796288", usetype: LinkUse.bldwall, comment: "3040 Apartments.link32");
            grc.AddLinkByNodeName("osm6323444298", "osm6323444297", usetype: LinkUse.bldwall, comment: "3040 Apartments.link33");
            grc.AddLinkByNodeName("osm6323444289", "osm6323444298", usetype: LinkUse.bldwall, comment: "3040 Apartments.link34");

            grc.AddLinkByNodeName("osm6394037165", "osm6394037164", usetype: LinkUse.bldwall, comment: "bld014.link1");
            grc.AddLinkByNodeName("osm6394037166", "osm6394037165", usetype: LinkUse.bldwall, comment: "bld014.link2");
            grc.AddLinkByNodeName("osm6394037167", "osm6394037166", usetype: LinkUse.bldwall, comment: "bld014.link3");
            grc.AddLinkByNodeName("osm6394037168", "osm6394037167", usetype: LinkUse.bldwall, comment: "bld014.link4");
            grc.AddLinkByNodeName("osm6394037169", "osm6394037168", usetype: LinkUse.bldwall, comment: "bld014.link5");
            grc.AddLinkByNodeName("osm6394037164", "osm6394037169", usetype: LinkUse.bldwall, comment: "bld014.link6");

            grc.AddLinkByNodeName("osm6731946652", "osm6731946651", usetype: LinkUse.bldwall, comment: "parking001.link1");
            grc.AddLinkByNodeName("osm6731946653", "osm6731946652", usetype: LinkUse.bldwall, comment: "parking001.link2");
            grc.AddLinkByNodeName("osm6731946654", "osm6731946653", usetype: LinkUse.bldwall, comment: "parking001.link3");
            grc.AddLinkByNodeName("osm7021335915", "osm6731946654", usetype: LinkUse.bldwall, comment: "parking001.link4");
            grc.AddLinkByNodeName("osm7021335916", "osm7021335915", usetype: LinkUse.bldwall, comment: "parking001.link5");
            grc.AddLinkByNodeName("osm6731946651", "osm7021335916", usetype: LinkUse.bldwall, comment: "parking001.link6");

            grc.AddLinkByNodeName("osm6731946657", "osm6731946656", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link1");
            grc.AddLinkByNodeName("osm5818373709", "osm6731946657", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link2");
            grc.AddLinkByNodeName("osm7021335914", "osm5818373709", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link3");
            grc.AddLinkByNodeName("osm7021335926", "osm7021335914", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link4");
            grc.AddLinkByNodeName("osm7021335927", "osm7021335926", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link5");
            grc.AddLinkByNodeName("osm7021335928", "osm7021335927", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link6");
            grc.AddLinkByNodeName("osm7021335925", "osm7021335928", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link7");
            grc.AddLinkByNodeName("osm7021335932", "osm7021335925", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link8");
            grc.AddLinkByNodeName("osm7021335933", "osm7021335932", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link9");
            grc.AddLinkByNodeName("osm7021335934", "osm7021335933", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link10");
            grc.AddLinkByNodeName("osm7021335935", "osm7021335934", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link11");
            grc.AddLinkByNodeName("osm7021335936", "osm7021335935", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link12");
            grc.AddLinkByNodeName("osm7021335929", "osm7021335936", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link13");
            grc.AddLinkByNodeName("osm7021335931", "osm7021335929", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link14");
            grc.AddLinkByNodeName("osm7021335930", "osm7021335931", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link15");
            grc.AddLinkByNodeName("osm6731946656", "osm7021335930", usetype: LinkUse.bldwall, comment: "Redmond Technology Station.link16");

            grc.AddLinkByNodeName("osm7105644030", "osm7105644029", usetype: LinkUse.bldwall, comment: "bld015.link1");
            grc.AddLinkByNodeName("osm7105644031", "osm7105644030", usetype: LinkUse.bldwall, comment: "bld015.link2");
            grc.AddLinkByNodeName("osm7105644032", "osm7105644031", usetype: LinkUse.bldwall, comment: "bld015.link3");
            grc.AddLinkByNodeName("osm7105644029", "osm7105644032", usetype: LinkUse.bldwall, comment: "bld015.link4");

            grc.AddLinkByNodeName("osm7287977452", "osm7287977451", usetype: LinkUse.bldwall, comment: "bld016.link1");
            grc.AddLinkByNodeName("osm7287977453", "osm7287977452", usetype: LinkUse.bldwall, comment: "bld016.link2");
            grc.AddLinkByNodeName("osm7287977454", "osm7287977453", usetype: LinkUse.bldwall, comment: "bld016.link3");
            grc.AddLinkByNodeName("osm7287977451", "osm7287977454", usetype: LinkUse.bldwall, comment: "bld016.link4");

            grc.AddLinkByNodeName("osm7287977456", "osm7287977455", usetype: LinkUse.bldwall, comment: "bld017.link1");
            grc.AddLinkByNodeName("osm7287977457", "osm7287977456", usetype: LinkUse.bldwall, comment: "bld017.link2");
            grc.AddLinkByNodeName("osm7287977495", "osm7287977457", usetype: LinkUse.bldwall, comment: "bld017.link3");
            grc.AddLinkByNodeName("osm7287977458", "osm7287977495", usetype: LinkUse.bldwall, comment: "bld017.link4");
            grc.AddLinkByNodeName("osm7287977455", "osm7287977458", usetype: LinkUse.bldwall, comment: "bld017.link5");

            grc.AddLinkByNodeName("osm7287977473", "osm7287977459", usetype: LinkUse.bldwall, comment: "bld018.link1");
            grc.AddLinkByNodeName("osm7287977472", "osm7287977473", usetype: LinkUse.bldwall, comment: "bld018.link2");
            grc.AddLinkByNodeName("osm7287977479", "osm7287977472", usetype: LinkUse.bldwall, comment: "bld018.link3");
            grc.AddLinkByNodeName("osm7287977459", "osm7287977479", usetype: LinkUse.bldwall, comment: "bld018.link4");

            grc.AddLinkByNodeName("osm7458566173", "osm7230625679", usetype: LinkUse.bldwall, comment: "bld019.link1");
            grc.AddLinkByNodeName("osm7458566174", "osm7458566173", usetype: LinkUse.bldwall, comment: "bld019.link2");
            grc.AddLinkByNodeName("osm7230625680", "osm7458566174", usetype: LinkUse.bldwall, comment: "bld019.link3");
            grc.AddLinkByNodeName("osm7230625679", "osm7230625680", usetype: LinkUse.bldwall, comment: "bld019.link4");

            grc.AddLinkByNodeName("osm7473290620", "osm7473290619", usetype: LinkUse.bldwall, comment: "bld020.link1");
            grc.AddLinkByNodeName("osm7473290621", "osm7473290620", usetype: LinkUse.bldwall, comment: "bld020.link2");
            grc.AddLinkByNodeName("osm7473290622", "osm7473290621", usetype: LinkUse.bldwall, comment: "bld020.link3");
            grc.AddLinkByNodeName("osm7473290623", "osm7473290622", usetype: LinkUse.bldwall, comment: "bld020.link4");
            grc.AddLinkByNodeName("osm7473290624", "osm7473290623", usetype: LinkUse.bldwall, comment: "bld020.link5");
            grc.AddLinkByNodeName("osm7473290625", "osm7473290624", usetype: LinkUse.bldwall, comment: "bld020.link6");
            grc.AddLinkByNodeName("osm7473290626", "osm7473290625", usetype: LinkUse.bldwall, comment: "bld020.link7");
            grc.AddLinkByNodeName("osm7473290619", "osm7473290626", usetype: LinkUse.bldwall, comment: "bld020.link8");

            grc.AddLinkByNodeName("osm7473290628", "osm7473290627", usetype: LinkUse.bldwall, comment: "bld021.link1");
            grc.AddLinkByNodeName("osm7473290629", "osm7473290628", usetype: LinkUse.bldwall, comment: "bld021.link2");
            grc.AddLinkByNodeName("osm7473290630", "osm7473290629", usetype: LinkUse.bldwall, comment: "bld021.link3");
            grc.AddLinkByNodeName("osm7473290627", "osm7473290630", usetype: LinkUse.bldwall, comment: "bld021.link4");
            grc.regman.SetRegion("default");
            // Area msftcommons machine generated 1661 nodes and 1665 links on 2020-06-23 13:26:41.078867
        }

        public void CreateGraphForOsmImport_msftredwest()  // machine generated on 2020-06-23 12:58:22.113967 local time  - do not edit
        {
            grc.regman.NewNodeRegion("Microsoft Redwest", "green", saveToFile: true);
            var xs = 8.5;  // offsets for error correction
            var zs = 10.0;
            grc.AddNodePtxz("osm335766940", -1899.108 + xs, -917.067 + zs);
            grc.AddNodePtxz("osm7213747649", -1930.995 + xs, -1167.715 + zs);
            grc.AddNodePtxz("osm1491834340", -1968.730 + xs, -1145.209 + zs);
            grc.AddNodePtxz("osm6882828264", -1953.384 + xs, -1140.296 + zs);
            grc.AddNodePtxz("osm335765565", -1947.042 + xs, -1138.267 + zs);
            grc.AddNodePtxz("osm335765564", -1946.625 + xs, -1144.462 + zs);
            grc.AddNodePtxz("osm335765563", -1941.729 + xs, -1141.843 + zs);
            grc.AddNodePtxz("osm335765562", -1933.944 + xs, -1164.827 + zs);
            grc.AddNodePtxz("osm5173096233", -1858.337 + xs, -1168.086 + zs);
            grc.AddNodePtxz("osm5173096269", -1871.623 + xs, -1087.520 + zs);
            grc.AddNodePtxz("osm7209647493", -1842.240 + xs, -1086.736 + zs);
            grc.AddNodePtxz("osm6882937913", -2008.092 + xs, -1052.665 + zs);
            grc.AddNodePtxz("osm6882937914", -2005.742 + xs, -1080.433 + zs);
            grc.AddNodePtxz("osm7209647564", -1989.199 + xs, -934.720 + zs);
            grc.AddNodePtxz("osm6882946808", -1910.574 + xs, -935.686 + zs);
            grc.AddNodePtxz("osm6882946816", -1952.066 + xs, -1042.658 + zs);
            grc.AddNodePtxz("osm6882946817", -1964.767 + xs, -1047.980 + zs);
            grc.AddNodePtxz("osm7191950148", -1836.149 + xs, -1080.025 + zs);
            grc.AddNodePtxz("osm7191950150", -2029.712 + xs, -1083.498 + zs);
            grc.AddNodePtxz("osm7191950154", -2069.977 + xs, -1097.037 + zs);
            grc.AddNodePtxz("osm7191950164", -1930.810 + xs, -1009.882 + zs);
            grc.AddNodePtxz("osm7191950167", -2035.978 + xs, -984.582 + zs);
            grc.AddNodePtxz("osm7209647538", -1849.811 + xs, -1031.962 + zs);
            grc.AddNodePtxz("osm7209647548", -1877.957 + xs, -1030.793 + zs);
            grc.AddNodePtxz("osm7209647559", -2024.085 + xs, -963.718 + zs);
            grc.AddNodePtxz("osm7209647560", -2002.533 + xs, -994.599 + zs);
            grc.AddNodePtxz("osm7209690428", -1833.064 + xs, -1149.643 + zs);
            grc.AddNodePtxz("osm7209690431", -1818.546 + xs, -1162.369 + zs);
            grc.AddNodePtxz("osm7209690432", -1844.934 + xs, -1164.123 + zs);
            grc.AddNodePtxz("osm7209690436", -1874.160 + xs, -1011.092 + zs);
            grc.AddNodePtxz("osm7209690437", -1988.502 + xs, -978.580 + zs);
            grc.AddNodePtxz("osm7209690453", -1802.418 + xs, -1158.979 + zs);
            grc.AddNodePtxz("osm7209690454", -1893.056 + xs, -1206.699 + zs);
            grc.AddNodePtxz("osm7209690456", -1879.918 + xs, -1190.153 + zs);
            grc.AddNodePtxz("osm7209690458", -1878.484 + xs, -1219.176 + zs);
            grc.AddNodePtxz("osm6882937946", -1878.977 + xs, -997.975 + zs);
            grc.AddNodePtxz("osm7209755270", -1874.187 + xs, -1232.122 + zs);
            grc.AddNodePtxz("osm7209775492", -2060.672 + xs, -1142.734 + zs);
            grc.AddNodePtxz("osm7209775497", -2056.991 + xs, -1124.554 + zs);
            grc.AddNodePtxz("osm7209775526", -2082.716 + xs, -1105.913 + zs);
            grc.AddNodePtxz("osm7209775532", -2078.755 + xs, -1119.314 + zs);
            grc.AddNodePtxz("osm5173096266", -1844.478 + xs, -1045.812 + zs);
            grc.AddNodePtxz("osm7213677047", -1960.918 + xs, -1202.618 + zs);
            grc.AddNodePtxz("osm7213677048", -1966.420 + xs, -1186.877 + zs);
            grc.AddNodePtxz("osm7213735607", -1934.783 + xs, -1031.600 + zs);
            grc.AddNodePtxz("osm3413319587", -2045.164 + xs, -922.923 + zs);
            grc.AddNodePtxz("osm7213682293", -1994.934 + xs, -934.647 + zs);
            grc.AddNodePtxz("osm5173096221", -1950.919 + xs, -1258.193 + zs);
            grc.AddNodePtxz("osm7213682297", -1883.824 + xs, -1176.740 + zs);
            grc.AddNodePtxz("osm7213682298", -1955.249 + xs, -1244.815 + zs);
            grc.AddNodePtxz("osm7213682300", -1979.587 + xs, -1129.875 + zs);
            grc.AddNodePtxz("osm7213682344", -1993.009 + xs, -1048.919 + zs);
            grc.AddNodePtxz("osm6882946814", -1899.219 + xs, -933.185 + zs);
            grc.AddNodePtxz("osm7213735608", -1925.776 + xs, -1057.461 + zs);
            grc.AddNodePtxz("osm7213747671", -1884.627 + xs, -1092.518 + zs);
            grc.AddNodePtxz("osm323546805", -1875.664 + xs, -1188.728 + zs);
            grc.AddNodePtxz("osm323546806", -1880.932 + xs, -1190.492 + zs);
            grc.AddNodePtxz("osm323546807", -1879.460 + xs, -1194.820 + zs);
            grc.AddNodePtxz("osm323546808", -1895.348 + xs, -1200.172 + zs);
            grc.AddNodePtxz("osm323546809", -1889.191 + xs, -1217.677 + zs);
            grc.AddNodePtxz("osm323546811", -1881.775 + xs, -1215.344 + zs);
            grc.AddNodePtxz("osm323546812", -1880.226 + xs, -1219.757 + zs);
            grc.AddNodePtxz("osm323546813", -1874.891 + xs, -1217.986 + zs);
            grc.AddNodePtxz("osm323546814", -1870.591 + xs, -1230.907 + zs);
            grc.AddNodePtxz("osm323546815", -1875.390 + xs, -1232.526 + zs);
            grc.AddNodePtxz("osm323546816", -1873.900 + xs, -1237.007 + zs);
            grc.AddNodePtxz("osm7209647496", -1890.832 + xs, -1242.811 + zs);
            grc.AddNodePtxz("osm7209647497", -1891.204 + xs, -1241.584 + zs);
            grc.AddNodePtxz("osm7209647499", -1899.482 + xs, -1244.283 + zs);
            grc.AddNodePtxz("osm7209647498", -1899.047 + xs, -1245.623 + zs);
            grc.AddNodePtxz("osm323546818", -1948.163 + xs, -1262.446 + zs);
            grc.AddNodePtxz("osm323546819", -1949.800 + xs, -1257.818 + zs);
            grc.AddNodePtxz("osm323546822", -1954.923 + xs, -1259.524 + zs);
            grc.AddNodePtxz("osm323546824", -1959.367 + xs, -1246.225 + zs);
            grc.AddNodePtxz("osm323546825", -1954.112 + xs, -1244.425 + zs);
            grc.AddNodePtxz("osm323546826", -1955.595 + xs, -1240.133 + zs);
            grc.AddNodePtxz("osm323546827", -1923.377 + xs, -1229.143 + zs);
            grc.AddNodePtxz("osm323546828", -1929.545 + xs, -1211.538 + zs);
            grc.AddNodePtxz("osm323546829", -1953.363 + xs, -1219.740 + zs);
            grc.AddNodePtxz("osm323546831", -1954.765 + xs, -1215.475 + zs);
            grc.AddNodePtxz("osm323546841", -1960.446 + xs, -1217.206 + zs);
            grc.AddNodePtxz("osm323546842", -1965.115 + xs, -1204.039 + zs);
            grc.AddNodePtxz("osm323546844", -1959.781 + xs, -1202.229 + zs);
            grc.AddNodePtxz("osm323546845", -1961.268 + xs, -1197.755 + zs);
            grc.AddNodePtxz("osm323546846", -1887.700 + xs, -1172.958 + zs);
            grc.AddNodePtxz("osm323546847", -1886.098 + xs, -1177.487 + zs);
            grc.AddNodePtxz("osm323546851", -1880.250 + xs, -1175.564 + zs);
            grc.AddNodePtxz("osm334982882", -1898.162 + xs, -1000.891 + zs);
            grc.AddNodePtxz("osm334983078", -1898.673 + xs, -999.569 + zs);
            grc.AddNodePtxz("osm334983079", -1881.798 + xs, -993.871 + zs);
            grc.AddNodePtxz("osm334983080", -1880.273 + xs, -998.483 + zs);
            grc.AddNodePtxz("osm334983081", -1874.987 + xs, -996.435 + zs);
            grc.AddNodePtxz("osm334983082", -1870.539 + xs, -1009.915 + zs);
            grc.AddNodePtxz("osm334983083", -1875.908 + xs, -1011.658 + zs);
            grc.AddNodePtxz("osm334983084", -1874.312 + xs, -1016.340 + zs);
            grc.AddNodePtxz("osm334983086", -1882.026 + xs, -1018.561 + zs);
            grc.AddNodePtxz("osm334983087", -1876.150 + xs, -1036.210 + zs);
            grc.AddNodePtxz("osm334983088", -1852.411 + xs, -1028.084 + zs);
            grc.AddNodePtxz("osm334983089", -1850.917 + xs, -1032.341 + zs);
            grc.AddNodePtxz("osm334982584", -1845.433 + xs, -1030.455 + zs);
            grc.AddNodePtxz("osm334982585", -1840.533 + xs, -1044.414 + zs);
            grc.AddNodePtxz("osm334982586", -1845.784 + xs, -1046.260 + zs);
            grc.AddNodePtxz("osm334982587", -1844.376 + xs, -1050.269 + zs);
            grc.AddNodePtxz("osm334982588", -1877.466 + xs, -1061.597 + zs);
            grc.AddNodePtxz("osm334982590", -1878.037 + xs, -1059.971 + zs);
            grc.AddNodePtxz("osm334982591", -1885.757 + xs, -1062.614 + zs);
            grc.AddNodePtxz("osm334982592", -1885.330 + xs, -1063.964 + zs);
            grc.AddNodePtxz("osm334982593", -1918.399 + xs, -1074.913 + zs);
            grc.AddNodePtxz("osm334982867", -1919.768 + xs, -1071.184 + zs);
            grc.AddNodePtxz("osm334982868", -1925.053 + xs, -1072.898 + zs);
            grc.AddNodePtxz("osm334982869", -1929.769 + xs, -1058.891 + zs);
            grc.AddNodePtxz("osm334982870", -1924.749 + xs, -1057.094 + zs);
            grc.AddNodePtxz("osm334982871", -1926.248 + xs, -1052.822 + zs);
            grc.AddNodePtxz("osm334982872", -1909.961 + xs, -1047.667 + zs);
            grc.AddNodePtxz("osm334982873", -1916.103 + xs, -1029.768 + zs);
            grc.AddNodePtxz("osm334982874", -1931.965 + xs, -1035.293 + zs);
            grc.AddNodePtxz("osm334982875", -1933.388 + xs, -1031.138 + zs);
            grc.AddNodePtxz("osm334982876", -1938.576 + xs, -1032.859 + zs);
            grc.AddNodePtxz("osm334982877", -1943.062 + xs, -1019.843 + zs);
            grc.AddNodePtxz("osm334982878", -1937.864 + xs, -1018.151 + zs);
            grc.AddNodePtxz("osm334982879", -1939.618 + xs, -1013.119 + zs);
            grc.AddNodePtxz("osm334982880", -1906.648 + xs, -1002.022 + zs);
            grc.AddNodePtxz("osm334982881", -1905.879 + xs, -1003.810 + zs);
            grc.AddNodePtxz("osm335764627", -2037.756 + xs, -964.564 + zs);
            grc.AddNodePtxz("osm335764629", -2035.933 + xs, -969.857 + zs);
            grc.AddNodePtxz("osm335764631", -2040.524 + xs, -971.397 + zs);
            grc.AddNodePtxz("osm335764632", -2026.588 + xs, -1011.873 + zs);
            grc.AddNodePtxz("osm335764633", -2025.240 + xs, -1011.443 + zs);
            grc.AddNodePtxz("osm335764634", -2022.383 + xs, -1019.717 + zs);
            grc.AddNodePtxz("osm335764636", -2023.789 + xs, -1020.214 + zs);
            grc.AddNodePtxz("osm335764639", -2012.642 + xs, -1052.710 + zs);
            grc.AddNodePtxz("osm335764640", -2008.561 + xs, -1051.297 + zs);
            grc.AddNodePtxz("osm335764643", -2006.683 + xs, -1056.714 + zs);
            grc.AddNodePtxz("osm335764644", -1993.425 + xs, -1052.238 + zs);
            grc.AddNodePtxz("osm335764646", -1994.102 + xs, -1050.276 + zs);
            grc.AddNodePtxz("osm335764647", -1992.699 + xs, -1049.803 + zs);
            grc.AddNodePtxz("osm335764648", -1993.791 + xs, -1046.660 + zs);
            grc.AddNodePtxz("osm335764649", -1990.424 + xs, -1045.531 + zs);
            grc.AddNodePtxz("osm335764650", -1996.035 + xs, -1029.209 + zs);
            grc.AddNodePtxz("osm335764651", -1978.576 + xs, -1023.359 + zs);
            grc.AddNodePtxz("osm335764652", -1970.144 + xs, -1047.381 + zs);
            grc.AddNodePtxz("osm335764655", -1965.495 + xs, -1045.837 + zs);
            grc.AddNodePtxz("osm335764656", -1963.643 + xs, -1051.247 + zs);
            grc.AddNodePtxz("osm335764658", -1950.576 + xs, -1047.003 + zs);
            grc.AddNodePtxz("osm335764659", -1952.385 + xs, -1041.713 + zs);
            grc.AddNodePtxz("osm335764660", -1947.795 + xs, -1040.071 + zs);
            grc.AddNodePtxz("osm335764662", -1961.455 + xs, -1000.079 + zs);
            grc.AddNodePtxz("osm335764664", -1963.143 + xs, -1000.546 + zs);
            grc.AddNodePtxz("osm335764665", -1966.112 + xs, -991.787 + zs);
            grc.AddNodePtxz("osm335764667", -1964.696 + xs, -991.350 + zs);
            grc.AddNodePtxz("osm335764669", -1970.583 + xs, -974.243 + zs);
            grc.AddNodePtxz("osm335764671", -1974.918 + xs, -975.775 + zs);
            grc.AddNodePtxz("osm335764672", -1976.520 + xs, -971.143 + zs);
            grc.AddNodePtxz("osm335764673", -1989.464 + xs, -975.471 + zs);
            grc.AddNodePtxz("osm335764674", -1987.925 + xs, -980.426 + zs);
            grc.AddNodePtxz("osm335764675", -1992.672 + xs, -981.924 + zs);
            grc.AddNodePtxz("osm335764677", -1989.722 + xs, -990.364 + zs);
            grc.AddNodePtxz("osm335764679", -2007.903 + xs, -996.374 + zs);
            grc.AddNodePtxz("osm335764680", -2018.697 + xs, -964.717 + zs);
            grc.AddNodePtxz("osm335764681", -2023.225 + xs, -966.235 + zs);
            grc.AddNodePtxz("osm335764682", -2025.235 + xs, -960.373 + zs);
            grc.AddNodePtxz("osm335765396", -1975.916 + xs, -1128.737 + zs);
            grc.AddNodePtxz("osm335765397", -1980.315 + xs, -1115.802 + zs);
            grc.AddNodePtxz("osm335765398", -1985.712 + xs, -1117.499 + zs);
            grc.AddNodePtxz("osm5173096317", -1987.212 + xs, -1113.125 + zs);
            grc.AddNodePtxz("osm335765400", -2019.407 + xs, -1123.474 + zs);
            grc.AddNodePtxz("osm335765401", -2025.362 + xs, -1106.375 + zs);
            grc.AddNodePtxz("osm335765402", -2001.538 + xs, -1098.290 + zs);
            grc.AddNodePtxz("osm335765403", -2003.155 + xs, -1093.853 + zs);
            grc.AddNodePtxz("osm335765404", -1997.495 + xs, -1091.796 + zs);
            grc.AddNodePtxz("osm335765405", -2001.855 + xs, -1079.173 + zs);
            grc.AddNodePtxz("osm335765406", -2007.484 + xs, -1080.982 + zs);
            grc.AddNodePtxz("osm335765407", -2009.146 + xs, -1076.449 + zs);
            grc.AddNodePtxz("osm335765408", -2049.445 + xs, -1090.095 + zs);
            grc.AddNodePtxz("osm335765409", -2049.013 + xs, -1091.357 + zs);
            grc.AddNodePtxz("osm335765410", -2057.529 + xs, -1094.185 + zs);
            grc.AddNodePtxz("osm335765411", -2057.999 + xs, -1092.881 + zs);
            grc.AddNodePtxz("osm335765412", -2082.329 + xs, -1101.035 + zs);
            grc.AddNodePtxz("osm335765413", -2080.828 + xs, -1105.243 + zs);
            grc.AddNodePtxz("osm335765414", -2086.430 + xs, -1107.232 + zs);
            grc.AddNodePtxz("osm335765415", -2081.981 + xs, -1120.276 + zs);
            grc.AddNodePtxz("osm335765418", -2076.440 + xs, -1118.617 + zs);
            grc.AddNodePtxz("osm335765419", -2074.935 + xs, -1122.973 + zs);
            grc.AddNodePtxz("osm335765420", -2059.292 + xs, -1117.832 + zs);
            grc.AddNodePtxz("osm335765421", -2053.387 + xs, -1135.392 + zs);
            grc.AddNodePtxz("osm335765423", -2060.339 + xs, -1137.835 + zs);
            grc.AddNodePtxz("osm335765424", -2058.905 + xs, -1142.121 + zs);
            grc.AddNodePtxz("osm335765425", -2064.741 + xs, -1144.150 + zs);
            grc.AddNodePtxz("osm335765427", -2060.322 + xs, -1157.007 + zs);
            grc.AddNodePtxz("osm335765428", -2055.030 + xs, -1155.211 + zs);
            grc.AddNodePtxz("osm335765429", -2053.407 + xs, -1159.836 + zs);
            grc.AddNodePtxz("osm335765430", -2036.473 + xs, -1154.205 + zs);
            grc.AddNodePtxz("osm335765431", -2036.839 + xs, -1153.095 + zs);
            grc.AddNodePtxz("osm335765432", -2029.133 + xs, -1150.512 + zs);
            grc.AddNodePtxz("osm335765433", -2028.702 + xs, -1151.640 + zs);
            grc.AddNodePtxz("osm335765434", -1979.431 + xs, -1134.653 + zs);
            grc.AddNodePtxz("osm335765435", -1980.979 + xs, -1130.312 + zs);
            grc.AddNodePtxz("osm335765554", -1978.080 + xs, -1187.771 + zs);
            grc.AddNodePtxz("osm335765555", -1975.456 + xs, -1186.778 + zs);
            grc.AddNodePtxz("osm335765557", -1974.554 + xs, -1189.550 + zs);
            grc.AddNodePtxz("osm335765559", -1946.392 + xs, -1180.281 + zs);
            grc.AddNodePtxz("osm335765561", -1929.467 + xs, -1169.212 + zs);
            grc.AddNodePtxz("osm335765567", -1977.124 + xs, -1147.845 + zs);
            grc.AddNodePtxz("osm335765568", -1976.095 + xs, -1150.376 + zs);
            grc.AddNodePtxz("osm335765569", -1987.612 + xs, -1154.501 + zs);
            grc.AddNodePtxz("osm335765570", -1982.093 + xs, -1170.759 + zs);
            grc.AddNodePtxz("osm335765571", -1984.961 + xs, -1171.765 + zs);
            grc.AddNodePtxz("osm335765572", -1982.154 + xs, -1180.064 + zs);
            grc.AddNodePtxz("osm335765573", -1980.806 + xs, -1179.603 + zs);
            grc.AddNodePtxz("osm335766392", -1814.454 + xs, -1166.735 + zs);
            grc.AddNodePtxz("osm335766393", -1801.232 + xs, -1162.391 + zs);
            grc.AddNodePtxz("osm335766394", -1803.036 + xs, -1157.186 + zs);
            grc.AddNodePtxz("osm335766397", -1798.288 + xs, -1155.656 + zs);
            grc.AddNodePtxz("osm335766398", -1806.760 + xs, -1130.681 + zs);
            grc.AddNodePtxz("osm335766399", -1808.315 + xs, -1131.190 + zs);
            grc.AddNodePtxz("osm335766400", -1810.889 + xs, -1123.587 + zs);
            grc.AddNodePtxz("osm335766401", -1809.341 + xs, -1123.057 + zs);
            grc.AddNodePtxz("osm335766402", -1823.617 + xs, -1082.254 + zs);
            grc.AddNodePtxz("osm335766403", -1828.354 + xs, -1083.915 + zs);
            grc.AddNodePtxz("osm335766404", -1830.264 + xs, -1078.137 + zs);
            grc.AddNodePtxz("osm335766405", -1843.690 + xs, -1082.639 + zs);
            grc.AddNodePtxz("osm335766406", -1841.793 + xs, -1088.009 + zs);
            grc.AddNodePtxz("osm335766407", -1846.311 + xs, -1089.556 + zs);
            grc.AddNodePtxz("osm335766408", -1837.818 + xs, -1113.819 + zs);
            grc.AddNodePtxz("osm335766409", -1855.437 + xs, -1119.850 + zs);
            grc.AddNodePtxz("osm335766410", -1866.576 + xs, -1087.748 + zs);
            grc.AddNodePtxz("osm335766411", -1871.000 + xs, -1089.326 + zs);
            grc.AddNodePtxz("osm335766412", -1872.924 + xs, -1083.711 + zs);
            grc.AddNodePtxz("osm335766413", -1886.140 + xs, -1087.903 + zs);
            grc.AddNodePtxz("osm335766414", -1884.359 + xs, -1093.313 + zs);
            grc.AddNodePtxz("osm321710561", -1888.459 + xs, -1094.741 + zs);
            grc.AddNodePtxz("osm335766415", -1871.833 + xs, -1143.651 + zs);
            grc.AddNodePtxz("osm335766416", -1870.380 + xs, -1143.288 + zs);
            grc.AddNodePtxz("osm335766417", -1867.613 + xs, -1151.237 + zs);
            grc.AddNodePtxz("osm335766418", -1868.977 + xs, -1151.719 + zs);
            grc.AddNodePtxz("osm335766419", -1863.264 + xs, -1168.299 + zs);
            grc.AddNodePtxz("osm335766421", -1858.771 + xs, -1166.848 + zs);
            grc.AddNodePtxz("osm335766423", -1856.911 + xs, -1172.113 + zs);
            grc.AddNodePtxz("osm335766424", -1843.685 + xs, -1167.815 + zs);
            grc.AddNodePtxz("osm335766427", -1845.399 + xs, -1162.730 + zs);
            grc.AddNodePtxz("osm335766428", -1841.227 + xs, -1161.310 + zs);
            grc.AddNodePtxz("osm335766429", -1843.812 + xs, -1153.339 + zs);
            grc.AddNodePtxz("osm335766430", -1826.011 + xs, -1147.221 + zs);
            grc.AddNodePtxz("osm335766431", -1820.679 + xs, -1163.115 + zs);
            grc.AddNodePtxz("osm335766432", -1816.203 + xs, -1161.551 + zs);
            grc.AddNodePtxz("osm2363328703", -2045.203 + xs, -928.861 + zs);
            grc.AddNodePtxz("osm4220218971", -2039.777 + xs, -928.928 + zs);
            grc.AddNodePtxz("osm4220218972", -2039.814 + xs, -934.098 + zs);
            grc.AddNodePtxz("osm2363328704", -1899.237 + xs, -935.821 + zs);
            grc.AddNodePtxz("osm2363328706", -1898.987 + xs, -898.355 + zs);
            grc.AddNodePtxz("osm2363328705", -2044.991 + xs, -896.564 + zs);

            grc.AddLinkByNodeName("osm7209690456", "osm323546805", usetype: LinkUse.bldwall, comment: "RedWest-A.link1");
            grc.AddLinkByNodeName("osm323546806", "osm7209690456", usetype: LinkUse.bldwall, comment: "RedWest-A.link2");
            grc.AddLinkByNodeName("osm323546807", "osm323546806", usetype: LinkUse.bldwall, comment: "RedWest-A.link3");
            grc.AddLinkByNodeName("osm323546808", "osm323546807", usetype: LinkUse.bldwall, comment: "RedWest-A.link4");
            grc.AddLinkByNodeName("osm7209690454", "osm323546808", usetype: LinkUse.bldwall, comment: "RedWest-A.link5");
            grc.AddLinkByNodeName("osm323546809", "osm7209690454", usetype: LinkUse.bldwall, comment: "RedWest-A.link6");
            grc.AddLinkByNodeName("osm323546811", "osm323546809", usetype: LinkUse.bldwall, comment: "RedWest-A.link7");
            grc.AddLinkByNodeName("osm323546812", "osm323546811", usetype: LinkUse.bldwall, comment: "RedWest-A.link8");
            grc.AddLinkByNodeName("osm7209690458", "osm323546812", usetype: LinkUse.bldwall, comment: "RedWest-A.link9");
            grc.AddLinkByNodeName("osm323546813", "osm7209690458", usetype: LinkUse.bldwall, comment: "RedWest-A.link10");
            grc.AddLinkByNodeName("osm323546814", "osm323546813", usetype: LinkUse.bldwall, comment: "RedWest-A.link11");
            grc.AddLinkByNodeName("osm7209755270", "osm323546814", usetype: LinkUse.bldwall, comment: "RedWest-A.link12");
            grc.AddLinkByNodeName("osm323546815", "osm7209755270", usetype: LinkUse.bldwall, comment: "RedWest-A.link13");
            grc.AddLinkByNodeName("osm323546816", "osm323546815", usetype: LinkUse.bldwall, comment: "RedWest-A.link14");
            grc.AddLinkByNodeName("osm7209647496", "osm323546816", usetype: LinkUse.bldwall, comment: "RedWest-A.link15");
            grc.AddLinkByNodeName("osm7209647497", "osm7209647496", usetype: LinkUse.bldwall, comment: "RedWest-A.link16");
            grc.AddLinkByNodeName("osm7209647499", "osm7209647497", usetype: LinkUse.bldwall, comment: "RedWest-A.link17");
            grc.AddLinkByNodeName("osm7209647498", "osm7209647499", usetype: LinkUse.bldwall, comment: "RedWest-A.link18");
            grc.AddLinkByNodeName("osm323546818", "osm7209647498", usetype: LinkUse.bldwall, comment: "RedWest-A.link19");
            grc.AddLinkByNodeName("osm323546819", "osm323546818", usetype: LinkUse.bldwall, comment: "RedWest-A.link20");
            grc.AddLinkByNodeName("osm5173096221", "osm323546819", usetype: LinkUse.bldwall, comment: "RedWest-A.link21");
            grc.AddLinkByNodeName("osm323546822", "osm5173096221", usetype: LinkUse.bldwall, comment: "RedWest-A.link22");
            grc.AddLinkByNodeName("osm323546824", "osm323546822", usetype: LinkUse.bldwall, comment: "RedWest-A.link23");
            grc.AddLinkByNodeName("osm7213682298", "osm323546824", usetype: LinkUse.bldwall, comment: "RedWest-A.link24");
            grc.AddLinkByNodeName("osm323546825", "osm7213682298", usetype: LinkUse.bldwall, comment: "RedWest-A.link25");
            grc.AddLinkByNodeName("osm323546826", "osm323546825", usetype: LinkUse.bldwall, comment: "RedWest-A.link26");
            grc.AddLinkByNodeName("osm323546827", "osm323546826", usetype: LinkUse.bldwall, comment: "RedWest-A.link27");
            grc.AddLinkByNodeName("osm323546828", "osm323546827", usetype: LinkUse.bldwall, comment: "RedWest-A.link28");
            grc.AddLinkByNodeName("osm323546829", "osm323546828", usetype: LinkUse.bldwall, comment: "RedWest-A.link29");
            grc.AddLinkByNodeName("osm323546831", "osm323546829", usetype: LinkUse.bldwall, comment: "RedWest-A.link30");
            grc.AddLinkByNodeName("osm323546841", "osm323546831", usetype: LinkUse.bldwall, comment: "RedWest-A.link31");
            grc.AddLinkByNodeName("osm323546842", "osm323546841", usetype: LinkUse.bldwall, comment: "RedWest-A.link32");
            grc.AddLinkByNodeName("osm7213677047", "osm323546842", usetype: LinkUse.bldwall, comment: "RedWest-A.link33");
            grc.AddLinkByNodeName("osm323546844", "osm7213677047", usetype: LinkUse.bldwall, comment: "RedWest-A.link34");
            grc.AddLinkByNodeName("osm323546845", "osm323546844", usetype: LinkUse.bldwall, comment: "RedWest-A.link35");
            grc.AddLinkByNodeName("osm323546846", "osm323546845", usetype: LinkUse.bldwall, comment: "RedWest-A.link36");
            grc.AddLinkByNodeName("osm323546847", "osm323546846", usetype: LinkUse.bldwall, comment: "RedWest-A.link37");
            grc.AddLinkByNodeName("osm7213682297", "osm323546847", usetype: LinkUse.bldwall, comment: "RedWest-A.link38");
            grc.AddLinkByNodeName("osm323546851", "osm7213682297", usetype: LinkUse.bldwall, comment: "RedWest-A.link39");
            grc.AddLinkByNodeName("osm323546805", "osm323546851", usetype: LinkUse.bldwall, comment: "RedWest-A.link40");

            grc.AddLinkByNodeName("osm334983078", "osm334982882", usetype: LinkUse.bldwall, comment: "RedWest-D.link1");
            grc.AddLinkByNodeName("osm334983079", "osm334983078", usetype: LinkUse.bldwall, comment: "RedWest-D.link2");
            grc.AddLinkByNodeName("osm334983080", "osm334983079", usetype: LinkUse.bldwall, comment: "RedWest-D.link3");
            grc.AddLinkByNodeName("osm6882937946", "osm334983080", usetype: LinkUse.bldwall, comment: "RedWest-D.link4");
            grc.AddLinkByNodeName("osm334983081", "osm6882937946", usetype: LinkUse.bldwall, comment: "RedWest-D.link5");
            grc.AddLinkByNodeName("osm334983082", "osm334983081", usetype: LinkUse.bldwall, comment: "RedWest-D.link6");
            grc.AddLinkByNodeName("osm7209690436", "osm334983082", usetype: LinkUse.bldwall, comment: "RedWest-D.link7");
            grc.AddLinkByNodeName("osm334983083", "osm7209690436", usetype: LinkUse.bldwall, comment: "RedWest-D.link8");
            grc.AddLinkByNodeName("osm334983084", "osm334983083", usetype: LinkUse.bldwall, comment: "RedWest-D.link9");
            grc.AddLinkByNodeName("osm334983086", "osm334983084", usetype: LinkUse.bldwall, comment: "RedWest-D.link10");
            grc.AddLinkByNodeName("osm7209647548", "osm334983086", usetype: LinkUse.bldwall, comment: "RedWest-D.link11");
            grc.AddLinkByNodeName("osm334983087", "osm7209647548", usetype: LinkUse.bldwall, comment: "RedWest-D.link12");
            grc.AddLinkByNodeName("osm334983088", "osm334983087", usetype: LinkUse.bldwall, comment: "RedWest-D.link13");
            grc.AddLinkByNodeName("osm334983089", "osm334983088", usetype: LinkUse.bldwall, comment: "RedWest-D.link14");
            grc.AddLinkByNodeName("osm7209647538", "osm334983089", usetype: LinkUse.bldwall, comment: "RedWest-D.link15");
            grc.AddLinkByNodeName("osm334982584", "osm7209647538", usetype: LinkUse.bldwall, comment: "RedWest-D.link16");
            grc.AddLinkByNodeName("osm334982585", "osm334982584", usetype: LinkUse.bldwall, comment: "RedWest-D.link17");
            grc.AddLinkByNodeName("osm5173096266", "osm334982585", usetype: LinkUse.bldwall, comment: "RedWest-D.link18");
            grc.AddLinkByNodeName("osm334982586", "osm5173096266", usetype: LinkUse.bldwall, comment: "RedWest-D.link19");
            grc.AddLinkByNodeName("osm334982587", "osm334982586", usetype: LinkUse.bldwall, comment: "RedWest-D.link20");
            grc.AddLinkByNodeName("osm334982588", "osm334982587", usetype: LinkUse.bldwall, comment: "RedWest-D.link21");
            grc.AddLinkByNodeName("osm334982590", "osm334982588", usetype: LinkUse.bldwall, comment: "RedWest-D.link22");
            grc.AddLinkByNodeName("osm334982591", "osm334982590", usetype: LinkUse.bldwall, comment: "RedWest-D.link23");
            grc.AddLinkByNodeName("osm334982592", "osm334982591", usetype: LinkUse.bldwall, comment: "RedWest-D.link24");
            grc.AddLinkByNodeName("osm334982593", "osm334982592", usetype: LinkUse.bldwall, comment: "RedWest-D.link25");
            grc.AddLinkByNodeName("osm334982867", "osm334982593", usetype: LinkUse.bldwall, comment: "RedWest-D.link26");
            grc.AddLinkByNodeName("osm334982868", "osm334982867", usetype: LinkUse.bldwall, comment: "RedWest-D.link27");
            grc.AddLinkByNodeName("osm334982869", "osm334982868", usetype: LinkUse.bldwall, comment: "RedWest-D.link28");
            grc.AddLinkByNodeName("osm7213735608", "osm334982869", usetype: LinkUse.bldwall, comment: "RedWest-D.link29");
            grc.AddLinkByNodeName("osm334982870", "osm7213735608", usetype: LinkUse.bldwall, comment: "RedWest-D.link30");
            grc.AddLinkByNodeName("osm334982871", "osm334982870", usetype: LinkUse.bldwall, comment: "RedWest-D.link31");
            grc.AddLinkByNodeName("osm334982872", "osm334982871", usetype: LinkUse.bldwall, comment: "RedWest-D.link32");
            grc.AddLinkByNodeName("osm334982873", "osm334982872", usetype: LinkUse.bldwall, comment: "RedWest-D.link33");
            grc.AddLinkByNodeName("osm334982874", "osm334982873", usetype: LinkUse.bldwall, comment: "RedWest-D.link34");
            grc.AddLinkByNodeName("osm334982875", "osm334982874", usetype: LinkUse.bldwall, comment: "RedWest-D.link35");
            grc.AddLinkByNodeName("osm7213735607", "osm334982875", usetype: LinkUse.bldwall, comment: "RedWest-D.link36");
            grc.AddLinkByNodeName("osm334982876", "osm7213735607", usetype: LinkUse.bldwall, comment: "RedWest-D.link37");
            grc.AddLinkByNodeName("osm334982877", "osm334982876", usetype: LinkUse.bldwall, comment: "RedWest-D.link38");
            grc.AddLinkByNodeName("osm334982878", "osm334982877", usetype: LinkUse.bldwall, comment: "RedWest-D.link39");
            grc.AddLinkByNodeName("osm334982879", "osm334982878", usetype: LinkUse.bldwall, comment: "RedWest-D.link40");
            grc.AddLinkByNodeName("osm7191950164", "osm334982879", usetype: LinkUse.bldwall, comment: "RedWest-D.link41");
            grc.AddLinkByNodeName("osm334982880", "osm7191950164", usetype: LinkUse.bldwall, comment: "RedWest-D.link42");
            grc.AddLinkByNodeName("osm334982881", "osm334982880", usetype: LinkUse.bldwall, comment: "RedWest-D.link43");
            grc.AddLinkByNodeName("osm334982882", "osm334982881", usetype: LinkUse.bldwall, comment: "RedWest-D.link44");

            grc.AddLinkByNodeName("osm335764629", "osm335764627", usetype: LinkUse.bldwall, comment: "RedWest-E.link1");
            grc.AddLinkByNodeName("osm335764631", "osm335764629", usetype: LinkUse.bldwall, comment: "RedWest-E.link2");
            grc.AddLinkByNodeName("osm7191950167", "osm335764631", usetype: LinkUse.bldwall, comment: "RedWest-E.link3");
            grc.AddLinkByNodeName("osm335764632", "osm7191950167", usetype: LinkUse.bldwall, comment: "RedWest-E.link4");
            grc.AddLinkByNodeName("osm335764633", "osm335764632", usetype: LinkUse.bldwall, comment: "RedWest-E.link5");
            grc.AddLinkByNodeName("osm335764634", "osm335764633", usetype: LinkUse.bldwall, comment: "RedWest-E.link6");
            grc.AddLinkByNodeName("osm335764636", "osm335764634", usetype: LinkUse.bldwall, comment: "RedWest-E.link7");
            grc.AddLinkByNodeName("osm335764639", "osm335764636", usetype: LinkUse.bldwall, comment: "RedWest-E.link8");
            grc.AddLinkByNodeName("osm335764640", "osm335764639", usetype: LinkUse.bldwall, comment: "RedWest-E.link9");
            grc.AddLinkByNodeName("osm6882937913", "osm335764640", usetype: LinkUse.bldwall, comment: "RedWest-E.link10");
            grc.AddLinkByNodeName("osm335764643", "osm6882937913", usetype: LinkUse.bldwall, comment: "RedWest-E.link11");
            grc.AddLinkByNodeName("osm335764644", "osm335764643", usetype: LinkUse.bldwall, comment: "RedWest-E.link12");
            grc.AddLinkByNodeName("osm335764646", "osm335764644", usetype: LinkUse.bldwall, comment: "RedWest-E.link13");
            grc.AddLinkByNodeName("osm335764647", "osm335764646", usetype: LinkUse.bldwall, comment: "RedWest-E.link14");
            grc.AddLinkByNodeName("osm7213682344", "osm335764647", usetype: LinkUse.bldwall, comment: "RedWest-E.link15");
            grc.AddLinkByNodeName("osm335764648", "osm7213682344", usetype: LinkUse.bldwall, comment: "RedWest-E.link16");
            grc.AddLinkByNodeName("osm335764649", "osm335764648", usetype: LinkUse.bldwall, comment: "RedWest-E.link17");
            grc.AddLinkByNodeName("osm335764650", "osm335764649", usetype: LinkUse.bldwall, comment: "RedWest-E.link18");
            grc.AddLinkByNodeName("osm335764651", "osm335764650", usetype: LinkUse.bldwall, comment: "RedWest-E.link19");
            grc.AddLinkByNodeName("osm335764652", "osm335764651", usetype: LinkUse.bldwall, comment: "RedWest-E.link20");
            grc.AddLinkByNodeName("osm335764655", "osm335764652", usetype: LinkUse.bldwall, comment: "RedWest-E.link21");
            grc.AddLinkByNodeName("osm6882946817", "osm335764655", usetype: LinkUse.bldwall, comment: "RedWest-E.link22");
            grc.AddLinkByNodeName("osm335764656", "osm6882946817", usetype: LinkUse.bldwall, comment: "RedWest-E.link23");
            grc.AddLinkByNodeName("osm335764658", "osm335764656", usetype: LinkUse.bldwall, comment: "RedWest-E.link24");
            grc.AddLinkByNodeName("osm6882946816", "osm335764658", usetype: LinkUse.bldwall, comment: "RedWest-E.link25");
            grc.AddLinkByNodeName("osm335764659", "osm6882946816", usetype: LinkUse.bldwall, comment: "RedWest-E.link26");
            grc.AddLinkByNodeName("osm335764660", "osm335764659", usetype: LinkUse.bldwall, comment: "RedWest-E.link27");
            grc.AddLinkByNodeName("osm335764662", "osm335764660", usetype: LinkUse.bldwall, comment: "RedWest-E.link28");
            grc.AddLinkByNodeName("osm335764664", "osm335764662", usetype: LinkUse.bldwall, comment: "RedWest-E.link29");
            grc.AddLinkByNodeName("osm335764665", "osm335764664", usetype: LinkUse.bldwall, comment: "RedWest-E.link30");
            grc.AddLinkByNodeName("osm335764667", "osm335764665", usetype: LinkUse.bldwall, comment: "RedWest-E.link31");
            grc.AddLinkByNodeName("osm335764669", "osm335764667", usetype: LinkUse.bldwall, comment: "RedWest-E.link32");
            grc.AddLinkByNodeName("osm335764671", "osm335764669", usetype: LinkUse.bldwall, comment: "RedWest-E.link33");
            grc.AddLinkByNodeName("osm335764672", "osm335764671", usetype: LinkUse.bldwall, comment: "RedWest-E.link34");
            grc.AddLinkByNodeName("osm335764673", "osm335764672", usetype: LinkUse.bldwall, comment: "RedWest-E.link35");
            grc.AddLinkByNodeName("osm7209690437", "osm335764673", usetype: LinkUse.bldwall, comment: "RedWest-E.link36");
            grc.AddLinkByNodeName("osm335764674", "osm7209690437", usetype: LinkUse.bldwall, comment: "RedWest-E.link37");
            grc.AddLinkByNodeName("osm335764675", "osm335764674", usetype: LinkUse.bldwall, comment: "RedWest-E.link38");
            grc.AddLinkByNodeName("osm335764677", "osm335764675", usetype: LinkUse.bldwall, comment: "RedWest-E.link39");
            grc.AddLinkByNodeName("osm7209647560", "osm335764677", usetype: LinkUse.bldwall, comment: "RedWest-E.link40");
            grc.AddLinkByNodeName("osm335764679", "osm7209647560", usetype: LinkUse.bldwall, comment: "RedWest-E.link41");
            grc.AddLinkByNodeName("osm335764680", "osm335764679", usetype: LinkUse.bldwall, comment: "RedWest-E.link42");
            grc.AddLinkByNodeName("osm335764681", "osm335764680", usetype: LinkUse.bldwall, comment: "RedWest-E.link43");
            grc.AddLinkByNodeName("osm7209647559", "osm335764681", usetype: LinkUse.bldwall, comment: "RedWest-E.link44");
            grc.AddLinkByNodeName("osm335764682", "osm7209647559", usetype: LinkUse.bldwall, comment: "RedWest-E.link45");
            grc.AddLinkByNodeName("osm335764627", "osm335764682", usetype: LinkUse.bldwall, comment: "RedWest-E.link46");

            grc.AddLinkByNodeName("osm335765397", "osm335765396", usetype: LinkUse.bldwall, comment: "RedWest-B.link1");
            grc.AddLinkByNodeName("osm335765398", "osm335765397", usetype: LinkUse.bldwall, comment: "RedWest-B.link2");
            grc.AddLinkByNodeName("osm5173096317", "osm335765398", usetype: LinkUse.bldwall, comment: "RedWest-B.link3");
            grc.AddLinkByNodeName("osm335765400", "osm5173096317", usetype: LinkUse.bldwall, comment: "RedWest-B.link4");
            grc.AddLinkByNodeName("osm335765401", "osm335765400", usetype: LinkUse.bldwall, comment: "RedWest-B.link5");
            grc.AddLinkByNodeName("osm335765402", "osm335765401", usetype: LinkUse.bldwall, comment: "RedWest-B.link6");
            grc.AddLinkByNodeName("osm335765403", "osm335765402", usetype: LinkUse.bldwall, comment: "RedWest-B.link7");
            grc.AddLinkByNodeName("osm335765404", "osm335765403", usetype: LinkUse.bldwall, comment: "RedWest-B.link8");
            grc.AddLinkByNodeName("osm335765405", "osm335765404", usetype: LinkUse.bldwall, comment: "RedWest-B.link9");
            grc.AddLinkByNodeName("osm6882937914", "osm335765405", usetype: LinkUse.bldwall, comment: "RedWest-B.link10");
            grc.AddLinkByNodeName("osm335765406", "osm6882937914", usetype: LinkUse.bldwall, comment: "RedWest-B.link11");
            grc.AddLinkByNodeName("osm335765407", "osm335765406", usetype: LinkUse.bldwall, comment: "RedWest-B.link12");
            grc.AddLinkByNodeName("osm7191950150", "osm335765407", usetype: LinkUse.bldwall, comment: "RedWest-B.link13");
            grc.AddLinkByNodeName("osm335765408", "osm7191950150", usetype: LinkUse.bldwall, comment: "RedWest-B.link14");
            grc.AddLinkByNodeName("osm335765409", "osm335765408", usetype: LinkUse.bldwall, comment: "RedWest-B.link15");
            grc.AddLinkByNodeName("osm335765410", "osm335765409", usetype: LinkUse.bldwall, comment: "RedWest-B.link16");
            grc.AddLinkByNodeName("osm335765411", "osm335765410", usetype: LinkUse.bldwall, comment: "RedWest-B.link17");
            grc.AddLinkByNodeName("osm7191950154", "osm335765411", usetype: LinkUse.bldwall, comment: "RedWest-B.link18");
            grc.AddLinkByNodeName("osm335765412", "osm7191950154", usetype: LinkUse.bldwall, comment: "RedWest-B.link19");
            grc.AddLinkByNodeName("osm335765413", "osm335765412", usetype: LinkUse.bldwall, comment: "RedWest-B.link20");
            grc.AddLinkByNodeName("osm7209775526", "osm335765413", usetype: LinkUse.bldwall, comment: "RedWest-B.link21");
            grc.AddLinkByNodeName("osm335765414", "osm7209775526", usetype: LinkUse.bldwall, comment: "RedWest-B.link22");
            grc.AddLinkByNodeName("osm335765415", "osm335765414", usetype: LinkUse.bldwall, comment: "RedWest-B.link23");
            grc.AddLinkByNodeName("osm7209775532", "osm335765415", usetype: LinkUse.bldwall, comment: "RedWest-B.link24");
            grc.AddLinkByNodeName("osm335765418", "osm7209775532", usetype: LinkUse.bldwall, comment: "RedWest-B.link25");
            grc.AddLinkByNodeName("osm335765419", "osm335765418", usetype: LinkUse.bldwall, comment: "RedWest-B.link26");
            grc.AddLinkByNodeName("osm335765420", "osm335765419", usetype: LinkUse.bldwall, comment: "RedWest-B.link27");
            grc.AddLinkByNodeName("osm7209775497", "osm335765420", usetype: LinkUse.bldwall, comment: "RedWest-B.link28");
            grc.AddLinkByNodeName("osm335765421", "osm7209775497", usetype: LinkUse.bldwall, comment: "RedWest-B.link29");
            grc.AddLinkByNodeName("osm335765423", "osm335765421", usetype: LinkUse.bldwall, comment: "RedWest-B.link30");
            grc.AddLinkByNodeName("osm335765424", "osm335765423", usetype: LinkUse.bldwall, comment: "RedWest-B.link31");
            grc.AddLinkByNodeName("osm7209775492", "osm335765424", usetype: LinkUse.bldwall, comment: "RedWest-B.link32");
            grc.AddLinkByNodeName("osm335765425", "osm7209775492", usetype: LinkUse.bldwall, comment: "RedWest-B.link33");
            grc.AddLinkByNodeName("osm335765427", "osm335765425", usetype: LinkUse.bldwall, comment: "RedWest-B.link34");
            grc.AddLinkByNodeName("osm335765428", "osm335765427", usetype: LinkUse.bldwall, comment: "RedWest-B.link35");
            grc.AddLinkByNodeName("osm335765429", "osm335765428", usetype: LinkUse.bldwall, comment: "RedWest-B.link36");
            grc.AddLinkByNodeName("osm335765430", "osm335765429", usetype: LinkUse.bldwall, comment: "RedWest-B.link37");
            grc.AddLinkByNodeName("osm335765431", "osm335765430", usetype: LinkUse.bldwall, comment: "RedWest-B.link38");
            grc.AddLinkByNodeName("osm335765432", "osm335765431", usetype: LinkUse.bldwall, comment: "RedWest-B.link39");
            grc.AddLinkByNodeName("osm335765433", "osm335765432", usetype: LinkUse.bldwall, comment: "RedWest-B.link40");
            grc.AddLinkByNodeName("osm335765434", "osm335765433", usetype: LinkUse.bldwall, comment: "RedWest-B.link41");
            grc.AddLinkByNodeName("osm335765435", "osm335765434", usetype: LinkUse.bldwall, comment: "RedWest-B.link42");
            grc.AddLinkByNodeName("osm7213682300", "osm335765435", usetype: LinkUse.bldwall, comment: "RedWest-B.link43");
            grc.AddLinkByNodeName("osm335765396", "osm7213682300", usetype: LinkUse.bldwall, comment: "RedWest-B.link44");

            grc.AddLinkByNodeName("osm335765555", "osm335765554", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link1");
            grc.AddLinkByNodeName("osm335765557", "osm335765555", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link2");
            grc.AddLinkByNodeName("osm7213677048", "osm335765557", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link3");
            grc.AddLinkByNodeName("osm335765559", "osm7213677048", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link4");
            grc.AddLinkByNodeName("osm335765561", "osm335765559", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link5");
            grc.AddLinkByNodeName("osm7213747649", "osm335765561", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link6");
            grc.AddLinkByNodeName("osm335765562", "osm7213747649", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link7");
            grc.AddLinkByNodeName("osm335765563", "osm335765562", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link8");
            grc.AddLinkByNodeName("osm335765564", "osm335765563", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link9");
            grc.AddLinkByNodeName("osm335765565", "osm335765564", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link10");
            grc.AddLinkByNodeName("osm6882828264", "osm335765565", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link11");
            grc.AddLinkByNodeName("osm1491834340", "osm6882828264", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link12");
            grc.AddLinkByNodeName("osm335765567", "osm1491834340", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link13");
            grc.AddLinkByNodeName("osm335765568", "osm335765567", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link14");
            grc.AddLinkByNodeName("osm335765569", "osm335765568", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link15");
            grc.AddLinkByNodeName("osm335765570", "osm335765569", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link16");
            grc.AddLinkByNodeName("osm335765571", "osm335765570", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link17");
            grc.AddLinkByNodeName("osm335765572", "osm335765571", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link18");
            grc.AddLinkByNodeName("osm335765573", "osm335765572", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link19");
            grc.AddLinkByNodeName("osm335765554", "osm335765573", usetype: LinkUse.bldwall, comment: "Microsoft Cafe RedW-F.link20");

            grc.AddLinkByNodeName("osm335766393", "osm335766392", usetype: LinkUse.bldwall, comment: "RedWest-C.link1");
            grc.AddLinkByNodeName("osm7209690453", "osm335766393", usetype: LinkUse.bldwall, comment: "RedWest-C.link2");
            grc.AddLinkByNodeName("osm335766394", "osm7209690453", usetype: LinkUse.bldwall, comment: "RedWest-C.link3");
            grc.AddLinkByNodeName("osm335766397", "osm335766394", usetype: LinkUse.bldwall, comment: "RedWest-C.link4");
            grc.AddLinkByNodeName("osm335766398", "osm335766397", usetype: LinkUse.bldwall, comment: "RedWest-C.link5");
            grc.AddLinkByNodeName("osm335766399", "osm335766398", usetype: LinkUse.bldwall, comment: "RedWest-C.link6");
            grc.AddLinkByNodeName("osm335766400", "osm335766399", usetype: LinkUse.bldwall, comment: "RedWest-C.link7");
            grc.AddLinkByNodeName("osm335766401", "osm335766400", usetype: LinkUse.bldwall, comment: "RedWest-C.link8");
            grc.AddLinkByNodeName("osm335766402", "osm335766401", usetype: LinkUse.bldwall, comment: "RedWest-C.link9");
            grc.AddLinkByNodeName("osm335766403", "osm335766402", usetype: LinkUse.bldwall, comment: "RedWest-C.link10");
            grc.AddLinkByNodeName("osm335766404", "osm335766403", usetype: LinkUse.bldwall, comment: "RedWest-C.link11");
            grc.AddLinkByNodeName("osm7191950148", "osm335766404", usetype: LinkUse.bldwall, comment: "RedWest-C.link12");
            grc.AddLinkByNodeName("osm335766405", "osm7191950148", usetype: LinkUse.bldwall, comment: "RedWest-C.link13");
            grc.AddLinkByNodeName("osm7209647493", "osm335766405", usetype: LinkUse.bldwall, comment: "RedWest-C.link14");
            grc.AddLinkByNodeName("osm335766406", "osm7209647493", usetype: LinkUse.bldwall, comment: "RedWest-C.link15");
            grc.AddLinkByNodeName("osm335766407", "osm335766406", usetype: LinkUse.bldwall, comment: "RedWest-C.link16");
            grc.AddLinkByNodeName("osm335766408", "osm335766407", usetype: LinkUse.bldwall, comment: "RedWest-C.link17");
            grc.AddLinkByNodeName("osm335766409", "osm335766408", usetype: LinkUse.bldwall, comment: "RedWest-C.link18");
            grc.AddLinkByNodeName("osm335766410", "osm335766409", usetype: LinkUse.bldwall, comment: "RedWest-C.link19");
            grc.AddLinkByNodeName("osm335766411", "osm335766410", usetype: LinkUse.bldwall, comment: "RedWest-C.link20");
            grc.AddLinkByNodeName("osm5173096269", "osm335766411", usetype: LinkUse.bldwall, comment: "RedWest-C.link21");
            grc.AddLinkByNodeName("osm335766412", "osm5173096269", usetype: LinkUse.bldwall, comment: "RedWest-C.link22");
            grc.AddLinkByNodeName("osm335766413", "osm335766412", usetype: LinkUse.bldwall, comment: "RedWest-C.link23");
            grc.AddLinkByNodeName("osm7213747671", "osm335766413", usetype: LinkUse.bldwall, comment: "RedWest-C.link24");
            grc.AddLinkByNodeName("osm335766414", "osm7213747671", usetype: LinkUse.bldwall, comment: "RedWest-C.link25");
            grc.AddLinkByNodeName("osm321710561", "osm335766414", usetype: LinkUse.bldwall, comment: "RedWest-C.link26");
            grc.AddLinkByNodeName("osm335766415", "osm321710561", usetype: LinkUse.bldwall, comment: "RedWest-C.link27");
            grc.AddLinkByNodeName("osm335766416", "osm335766415", usetype: LinkUse.bldwall, comment: "RedWest-C.link28");
            grc.AddLinkByNodeName("osm335766417", "osm335766416", usetype: LinkUse.bldwall, comment: "RedWest-C.link29");
            grc.AddLinkByNodeName("osm335766418", "osm335766417", usetype: LinkUse.bldwall, comment: "RedWest-C.link30");
            grc.AddLinkByNodeName("osm335766419", "osm335766418", usetype: LinkUse.bldwall, comment: "RedWest-C.link31");
            grc.AddLinkByNodeName("osm335766421", "osm335766419", usetype: LinkUse.bldwall, comment: "RedWest-C.link32");
            grc.AddLinkByNodeName("osm5173096233", "osm335766421", usetype: LinkUse.bldwall, comment: "RedWest-C.link33");
            grc.AddLinkByNodeName("osm335766423", "osm5173096233", usetype: LinkUse.bldwall, comment: "RedWest-C.link34");
            grc.AddLinkByNodeName("osm335766424", "osm335766423", usetype: LinkUse.bldwall, comment: "RedWest-C.link35");
            grc.AddLinkByNodeName("osm7209690432", "osm335766424", usetype: LinkUse.bldwall, comment: "RedWest-C.link36");
            grc.AddLinkByNodeName("osm335766427", "osm7209690432", usetype: LinkUse.bldwall, comment: "RedWest-C.link37");
            grc.AddLinkByNodeName("osm335766428", "osm335766427", usetype: LinkUse.bldwall, comment: "RedWest-C.link38");
            grc.AddLinkByNodeName("osm335766429", "osm335766428", usetype: LinkUse.bldwall, comment: "RedWest-C.link39");
            grc.AddLinkByNodeName("osm7209690428", "osm335766429", usetype: LinkUse.bldwall, comment: "RedWest-C.link40");
            grc.AddLinkByNodeName("osm335766430", "osm7209690428", usetype: LinkUse.bldwall, comment: "RedWest-C.link41");
            grc.AddLinkByNodeName("osm335766431", "osm335766430", usetype: LinkUse.bldwall, comment: "RedWest-C.link42");
            grc.AddLinkByNodeName("osm7209690431", "osm335766431", usetype: LinkUse.bldwall, comment: "RedWest-C.link43");
            grc.AddLinkByNodeName("osm335766432", "osm7209690431", usetype: LinkUse.bldwall, comment: "RedWest-C.link44");
            grc.AddLinkByNodeName("osm335766392", "osm335766432", usetype: LinkUse.bldwall, comment: "RedWest-C.link45");

            grc.AddLinkByNodeName("osm4220218971", "osm2363328703", usetype: LinkUse.bldwall, comment: "bld001.link1");
            grc.AddLinkByNodeName("osm4220218972", "osm4220218971", usetype: LinkUse.bldwall, comment: "bld001.link2");
            grc.AddLinkByNodeName("osm7213682293", "osm4220218972", usetype: LinkUse.bldwall, comment: "bld001.link3");
            grc.AddLinkByNodeName("osm7209647564", "osm7213682293", usetype: LinkUse.bldwall, comment: "bld001.link4");
            grc.AddLinkByNodeName("osm6882946808", "osm7209647564", usetype: LinkUse.bldwall, comment: "bld001.link5");
            grc.AddLinkByNodeName("osm2363328704", "osm6882946808", usetype: LinkUse.bldwall, comment: "bld001.link6");
            grc.AddLinkByNodeName("osm6882946814", "osm2363328704", usetype: LinkUse.bldwall, comment: "bld001.link7");
            grc.AddLinkByNodeName("osm335766940", "osm6882946814", usetype: LinkUse.bldwall, comment: "bld001.link8");
            grc.AddLinkByNodeName("osm2363328706", "osm335766940", usetype: LinkUse.bldwall, comment: "bld001.link9");
            grc.AddLinkByNodeName("osm2363328705", "osm2363328706", usetype: LinkUse.bldwall, comment: "bld001.link10");
            grc.AddLinkByNodeName("osm3413319587", "osm2363328705", usetype: LinkUse.bldwall, comment: "bld001.link11");
            grc.AddLinkByNodeName("osm2363328703", "osm3413319587", usetype: LinkUse.bldwall, comment: "bld001.link12");
            grc.regman.SetRegion("default");
            // Area msftredwest machine generated 251 nodes and 251 links on 2020-06-23 12:58:22.113967
        }


    




        public void createPointsFor_msft_b40()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-b40", "purple", saveToFile: true);
            grc.AddNodePtxyz("b40-f01-lobby", 243.700, 0.000, 175.500, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b40-f01-lobby", "b40-os1-o01", 234.800, 0.000, 170.000, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b40-os1-o01", "b40-os1-o02", 242.200, 0.000, 144.200, LinkUse.walkway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("b40-os1-o02", "b40-os1-o03", 249.250, 0.000, 121.260, LinkUse.walkway, comment: ""); //  4 nn:1 nl:1
            grc.AddNodePtxyz("dw-B40-c01", 194.330, 0.000, 90.500, comment: ""); //  5 nn:1 nl:0
            grc.LinkToPtxyz("dw-B40-c01", "dw-B40-c02", 169.910, 0.000, 90.650, LinkUse.road, comment: ""); //  6 nn:1 nl:1
            grc.AddLinkByNodeName("dw-B40-c02", "reg:msft-campus", LinkUse.driveway); //  7 nn:0 nl:1
            grc.regman.SetRegion("default");
        }


        public void createPointsFor_msft_b43()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-b43", "purple", saveToFile: true);
            grc.AddNodePtxyz("dw-B43-c01", 89.800, 0.000, 74.800, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("dw-B43-c01", "dw-B43-c02", 64.600, 0.000, 62.300, LinkUse.driveway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("dw-B43-c02", "dw-B43-c03", 53.900, 0.000, 57.500, LinkUse.driveway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("dw-B43-c03", "dw-B43-c04", 50.180, 0.000, 49.740, LinkUse.driveway, comment: ""); //  4 nn:1 nl:1
            grc.LinkToPtxyz("dw-B43-c04", "dw-B43-c05", 62.850, 0.000, 55.200, LinkUse.driveway, comment: ""); //  5 nn:1 nl:1
            grc.AddLinkByNodeName("dw-B43-c05", "reg:msft-campus", LinkUse.driveway); //  6 nn:0 nl:1
            grc.AddLinkByNodeName("dw-B43-c01", "reg:msft-campus", LinkUse.driveway); //  7 nn:0 nl:1
            grc.regman.SetRegion("default");
        }


        public void createPointsFor_msft_b43_f1()
        {
            grc.regman.NewNodeRegion("msft-b43-f1", "purple", saveToFile: true);
            grc.AddNodePtxyz("b43-f01-lobby", 0.000, 0.000, 0.000, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b43-f01-lobby", "b43-f01-c01", 6.520, 0.000, 0.000, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c01", "b43-f01-c02", 8.740, 0.000, 0.000, LinkUse.walkway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c02", "b43-f01-c03", 10.840, 0.000, 0.000, LinkUse.walkway, comment: ""); //  4 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c03", "b43-f01-c04", 14.340, 0.000, 0.000, LinkUse.walkway, comment: ""); //  5 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c04", "b43-f01-c05", 17.800, 0.000, 0.000, LinkUse.walkway, comment: ""); //  6 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c05", "b43-f01-c06", 21.530, 0.000, -0.110, LinkUse.walkway, comment: ""); //  7 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c06", "b43-f01-c07", 23.250, 0.000, 1.920, LinkUse.walkway, comment: ""); //  8 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c07", "b43-f01-c08", 29.150, 0.000, 1.920, LinkUse.walkway, comment: ""); //  9 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c08", "b43-f01-c09", 32.760, 0.000, 1.920, LinkUse.walkway, comment: ""); //  10 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c09", "b43-f01-c10", 33.220, 0.000, 4.430, LinkUse.walkway, comment: ""); //  11 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c10", "b43-f01-c11", 33.220, 0.000, 5.970, LinkUse.walkway, comment: ""); //  12 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c11", "b43-f01-c12", 33.220, 0.000, 8.300, LinkUse.walkway, comment: ""); //  13 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c12", "b43-f01-c13", 29.440, 0.000, 8.630, LinkUse.walkway, comment: ""); //  14 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c13", "b43-f01-c14", 29.440, 0.000, 11.910, LinkUse.walkway, comment: ""); //  15 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c14", "b43-f01-c15", 27.550, 0.000, 11.910, LinkUse.walkway, comment: ""); //  16 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c15", "b43-f01-c16", 27.550, 0.000, 9.040, LinkUse.walkway, comment: ""); //  17 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c01", "b43-f01-rm1001", 6.290, 0.000, -3.470, LinkUse.walkway, comment: ""); //  18 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c02", "b43-f01-rm1002", 8.470, 0.000, -3.470, LinkUse.walkway, comment: ""); //  19 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c03", "b43-f01-rm1003", 10.530, 0.000, -3.470, LinkUse.walkway, comment: ""); //  20 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c04", "b43-f01-k01", 14.150, 0.000, 5.040, LinkUse.walkway, comment: ""); //  21 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c05", "b43-f01-rm1004", 17.460, 0.000, 4.310, LinkUse.walkway, comment: ""); //  22 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c08", "b43-f01-rm1005", 29.680, 0.000, -1.660, LinkUse.walkway, comment: ""); //  23 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c09", "b43-f01-rm1006", 32.760, 0.000, -0.600, LinkUse.walkway, comment: ""); //  24 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c10", "b43-f01-rm1007", 30.350, 0.000, 4.430, LinkUse.walkway, comment: ""); //  25 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c10", "b43-f01-rm1008", 36.440, 0.000, 4.430, LinkUse.walkway, comment: ""); //  26 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c11", "b43-f01-rm1009", 30.200, 0.000, 5.970, LinkUse.walkway, comment: ""); //  27 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c16", "b43-f01-rm1012", 25.030, 0.000, 9.170, LinkUse.walkway, comment: ""); //  28 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c15", "b43-f01-rm1013", 24.490, 0.000, 11.910, LinkUse.walkway, comment: ""); //  29 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c15", "b43-f01-rm1014", 27.550, 0.000, 14.970, LinkUse.walkway, comment: ""); //  30 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c03", "b43-f01-c20", 10.840, 0.000, 12.630, LinkUse.walkway, comment: ""); //  31 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c20", "b43-f01-c21", 14.150, 0.000, 12.630, LinkUse.walkway, comment: ""); //  32 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c21", "b43-f01-c22", 14.150, 0.000, 9.660, LinkUse.walkway, comment: ""); //  33 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c22", "b43-f01-c23", 17.740, 0.000, 9.660, LinkUse.walkway, comment: ""); //  34 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c23", "b43-f01-c24", 21.730, 0.000, 8.730, LinkUse.walkway, comment: ""); //  35 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c24", "b43-f01-c25", 21.730, 0.000, 4.680, LinkUse.walkway, comment: ""); //  36 nn:1 nl:1
            grc.LinkToPtxyz("b43-f01-c23", "b43-f01-rm1015", 18.270, 0.000, 12.370, LinkUse.walkway, comment: ""); //  37 nn:1 nl:1
            grc.AddLinkByNodeName("b43-f01-rm1004", "b43-f01-c25", LinkUse.walkway); //  38 nn:0 nl:1
            grc.AddLinkByNodeName("b43-f01-rm1012", "b43-f01-c24", LinkUse.walkway); //  39 nn:0 nl:1
            grc.LinkToPtxyz("b43-f01-lobby", "b43-os1-o01", 0.000, 0.000, 8.000, LinkUse.walkway, comment: ""); //  40 nn:1 nl:1
            grc.LinkToPtxyz("b43-os1-o01", "b43-os1-o02", -1.500, 0.000, 11.500, LinkUse.walkway, comment: ""); //  41 nn:1 nl:1
            grc.LinkToPtxyz("b43-os1-o02", "b43-os1-o03", -1.500, 0.000, 27.500, LinkUse.walkway, comment: ""); //  42 nn:1 nl:1
            grc.LinkToPtxyz("b43-os1-o03", "b43-os1-o04", 1.800, 0.000, 32.000, LinkUse.walkway, comment: ""); //  43 nn:1 nl:1
            grc.LinkToPtxyz("b43-os1-o04", "b43-os1-o05", 4.000, 0.000, 33.300, LinkUse.walkway, comment: ""); //  44 nn:1 nl:1
            grc.LinkToPtxyz("b43-os1-o05", "b43-os1-o06", 10.400, 0.000, 30.310, LinkUse.walkway, comment: ""); //  45 nn:1 nl:1
            grc.regman.SetRegion("default");
        }


        public void createPointsFor_msft_b99()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-b99", "purple", saveToFile: true);
            grc.AddNodePtxyz("b99-f01-lobby", -113.000, 0.000, -612.700, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b99-f01-lobby", "b99-os1-o00", -114.630, 0.000, -588.610, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b99-os1-o00", "b99-os1-o01", -116.940, 0.000, -573.640, LinkUse.walkway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("b99-os1-o01", "b99-os1-o02", -126.610, 0.000, -570.150, LinkUse.walkway, comment: ""); //  4 nn:1 nl:1
            grc.LinkToPtxyz("b99-os1-o02", "b99-os1-o03", -139.820, 0.000, -570.660, LinkUse.walkway, comment: ""); //  5 nn:1 nl:1
            grc.LinkToPtxyz("b99-os1-o03", "b99-os1-o04", -139.820, 0.000, -561.610, LinkUse.walkway, comment: ""); //  6 nn:1 nl:1
            grc.AddNodePtxyz("dw-b99-o00", -88.200, 0.000, -569.810, comment: ""); //  7 nn:1 nl:0
            grc.AddLinkByNodeName("dw-b99-o00", "reg:msft-campus", LinkUse.driveway); //  8 nn:0 nl:1
            grc.regman.SetRegion("default");
        }

    
        public void createPointsFor_msft_bredwb()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-bredwb", "purple", saveToFile: true);
            grc.gm.setmodxyz_off(grc.redwestNewMapXoffset, 0, grc.redwestNewMapZoffset);
            grc.AddNodePtxyz("bRWB-f01-lobby", -2044.300, 0.000, -1119.600, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("bRWB-f01-lobby", "bRWB-os1-o00", -2059.240, 0.000, -1124.150, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os1-o00", "bRWB-os1-o01", -2063.060, 0.000, -1138.260, LinkUse.walkway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os1-o01", "bRWB-os1-o02", -2056.220, 0.000, -1160.760, LinkUse.walkway, comment: ""); //  4 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os1-o02", "bRWB-os1-o04", -2045.160, 0.000, -1172.130, LinkUse.walkway, comment: ""); //  5 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os1-o04", "bRWB-os1-o05", -2034.560, 0.000, -1177.550, LinkUse.walkway, comment: ""); //  6 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os1-o05", "bRWB-os1-o06", -2018.320, 0.000, -1173.510, LinkUse.walkway, comment: ""); //  7 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os1-o06", "bRWB-os1-o07", -1999.220, 0.000, -1167.800, LinkUse.walkway, comment: ""); //  8 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os1-o07", "bRWB-os1-o08", -1970.220, 0.000, -1254.200, LinkUse.walkway, comment: ""); //  9 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os1-o08", "bRWB-os1-o09", -1989.300, 0.000, -1258.400, LinkUse.walkway, comment: ""); //  10 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os1-o09", "bRWB-os1-o10", -2005.600, 0.000, -1261.800, LinkUse.walkway, comment: ""); //  11 nn:1 nl:1
            grc.AddLinkByNodeName("bRWB-os1-o10", "bRWB-os1-o05", LinkUse.walkway); //  12 nn:0 nl:1
            grc.LinkToPtxyz("bRWB-os1-o02", "bRWB-os2-o01", -1967.500, 0.000, -1128.800, LinkUse.walkway, comment: ""); //  13 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os2-o01", "bRWB-os2-o02", -1969.700, 0.000, -1119.000, LinkUse.walkway, comment: ""); //  14 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os2-o02", "bRWB-os2-o03", -1965.800, 0.000, -1117.200, LinkUse.walkway, comment: ""); //  15 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os2-o03", "bRWB-os2-o04", -1989.200, 0.000, -1065.300, LinkUse.walkway, comment: ""); //  16 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os1-o01", "bRWB-os3-o01", -2072.600, 0.000, -1113.300, LinkUse.walkway, comment: ""); //  17 nn:1 nl:1
            grc.LinkToPtxyz("bRWB-os3-o01", "bRWB-os3-o02", -2080.500, 0.000, -1092.100, LinkUse.walkway, comment: ""); //  18 nn:1 nl:1
            grc.AddNodePtxyz("dw-RWB-c00", -1797.560, 0.000, -1227.460, comment: ""); //  19 nn:1 nl:0
            grc.LinkToPtxyz("dw-RWB-c00", "dw-RWB-c01", -1812.540, 0.000, -1229.800, LinkUse.driveway, comment: ""); //  20 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c01", "dw-RWB-c02", -1847.720, 0.000, -1242.200, LinkUse.driveway, comment: ""); //  21 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c02", "dw-RWB-c03", -1896.080, 0.000, -1258.700, LinkUse.driveway, comment: ""); //  22 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c03", "dw-RWB-c04", -1950.610, 0.000, -1276.100, LinkUse.driveway, comment: ""); //  23 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c04", "dw-RWB-c05", -1981.340, 0.000, -1286.900, LinkUse.driveway, comment: ""); //  24 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c05", "dw-RWB-c06", -1988.200, 0.000, -1263.600, LinkUse.driveway, comment: ""); //  25 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c06", "dw-RWB-c07", -1980.400, 0.000, -1258.200, LinkUse.driveway, comment: ""); //  26 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c07", "dw-RWB-c11", -1971.900, 0.000, -1254.200, LinkUse.driveway, comment: ""); //  27 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c11", "dw-RWB-c12", -1973.400, 0.000, -1249.500, LinkUse.driveway, comment: ""); //  28 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c12", "dw-RWB-c14", -1977.500, 0.000, -1237.500, LinkUse.driveway, comment: ""); //  29 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c14", "dw-RWB-c16", -1987.800, 0.000, -1208.400, LinkUse.driveway, comment: ""); //  30 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c16", "dw-RWB-c18", -1998.000, 0.000, -1179.400, LinkUse.driveway, comment: ""); //  31 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c06", "dw-RWB-c21", -1989.200, 0.000, -1258.700, LinkUse.driveway, comment: ""); //  32 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c21", "dw-RWB-c22", -1990.500, 0.000, -1254.000, LinkUse.driveway, comment: ""); //  33 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c22", "dw-RWB-c24", -1994.600, 0.000, -1242.000, LinkUse.driveway, comment: ""); //  34 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c24", "dw-RWB-c26", -2004.900, 0.000, -1212.900, LinkUse.driveway, comment: ""); //  35 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c26", "dw-RWB-c28", -2015.100, 0.000, -1183.900, LinkUse.driveway, comment: ""); //  36 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c06", "dw-RWB-c31", -2005.000, 0.000, -1265.000, LinkUse.driveway, comment: ""); //  37 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c31", "dw-RWB-c32", -2007.400, 0.000, -1258.500, LinkUse.driveway, comment: ""); //  38 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c32", "dw-RWB-c34", -2011.500, 0.000, -1246.500, LinkUse.driveway, comment: ""); //  39 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c34", "dw-RWB-c36", -2021.000, 0.000, -1219.000, LinkUse.driveway, comment: ""); //  40 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c36", "dw-RWB-c38", -2030.300, 0.000, -1190.700, LinkUse.driveway, comment: ""); //  41 nn:1 nl:1
            grc.AddLinkByNodeName("dw-RWB-c00", "reg:msft-campus", LinkUse.driveway); //  42 nn:0 nl:1
            grc.gm.setmodxyz_off(0,0,0);
            grc.regman.SetRegion("default");
        }


        public void createPointsFor_msft_bredwb_f3()    // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-bredwb-f3", "purple", saveToFile: true);
            grc.gm.setmodxyz_off(grc.redwestNewMapXoffset, 0, grc.redwestNewMapZoffset);
            grc.AddNodePtxyz("rwb-f03-cv0-s", -1971.357, 9.000, -1118.202, comment: ""); //  1 nn:1 nl:0
            grc.AddNodePtxyz("rwb-f03-cv0-e", -2048.843, 9.000, -1143.539, comment: ""); //  2 nn:1 nl:0
            grc.AddNodePtxyz("rwb-f03-cv1-s", -1975.537, 9.000, -1106.327, comment: ""); //  3 nn:1 nl:0
            grc.AddNodePtxyz("rwb-f03-cv1-e", -2053.023, 9.000, -1131.664, comment: ""); //  4 nn:1 nl:0
            grc.AddNodePtxyz("rwb-f03-cv2-s", -1993.661, 9.000, -1081.687, comment: ""); //  5 nn:1 nl:0
            grc.AddNodePtxyz("rwb-f03-cv2-e", -2070.555, 9.000, -1107.426, comment: ""); //  6 nn:1 nl:0
            grc.AddNodePtxyz("rwb-f03-cv3-s", -1997.841, 9.000, -1069.812, comment: ""); //  7 nn:1 nl:0
            grc.AddNodePtxyz("rwb-f03-cv3-e", -2074.926, 9.000, -1095.011, comment: ""); //  8 nn:1 nl:0
            grc.AddNodePtxyz("rwb-f03-ch01-0", -1978.753, 9.000, -1120.621, comment: ""); //  9 nn:1 nl:0
                                                                                          // ( empty ); //  10 nn:0 nl:0
                                                                                          // ( empty ); //  11 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch01-1", -1982.665, 9.000, -1108.658, comment: ""); //  12 nn:1 nl:0
                                                                                          // ( empty ); //  13 nn:0 nl:0
                                                                                          // ( empty ); //  14 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch02-0", -1986.822, 9.000, -1123.259, comment: ""); //  15 nn:1 nl:0
                                                                                          // ( empty ); //  16 nn:0 nl:0
                                                                                          // ( empty ); //  17 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch02-1", -1990.734, 9.000, -1111.296, comment: ""); //  18 nn:1 nl:0
                                                                                          // ( empty ); //  19 nn:0 nl:0
                                                                                          // ( empty ); //  20 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch03-0", -1994.499, 9.000, -1125.770, comment: ""); //  21 nn:1 nl:0
                                                                                          // ( empty ); //  22 nn:0 nl:0
                                                                                          // ( empty ); //  23 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch03-1", -1998.411, 9.000, -1113.807, comment: ""); //  24 nn:1 nl:0
                                                                                          // ( empty ); //  25 nn:0 nl:0
                                                                                          // ( empty ); //  26 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch04-0", -2002.568, 9.000, -1128.408, comment: ""); //  27 nn:1 nl:0
                                                                                          // ( empty ); //  28 nn:0 nl:0
                                                                                          // ( empty ); //  29 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch04-1", -2006.480, 9.000, -1116.445, comment: ""); //  30 nn:1 nl:0
                                                                                          // ( empty ); //  31 nn:0 nl:0
                                                                                          // ( empty ); //  32 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch05-0", -2010.637, 9.000, -1131.046, comment: ""); //  33 nn:1 nl:0
                                                                                          // ( empty ); //  34 nn:0 nl:0
                                                                                          // ( empty ); //  35 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch05-1", -2014.549, 9.000, -1119.083, comment: ""); //  36 nn:1 nl:0
                                                                                          // ( empty ); //  37 nn:0 nl:0
                                                                                          // ( empty ); //  38 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch06-0", -2023.547, 9.000, -1135.268, comment: ""); //  39 nn:1 nl:0
                                                                                          // ( empty ); //  40 nn:0 nl:0
                                                                                          // ( empty ); //  41 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch06-1", -2027.459, 9.000, -1123.305, comment: ""); //  42 nn:1 nl:0
                                                                                          // ( empty ); //  43 nn:0 nl:0
                                                                                          // ( empty ); //  44 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch07-0", -2034.037, 9.000, -1138.698, comment: ""); //  45 nn:1 nl:0
                                                                                          // ( empty ); //  46 nn:0 nl:0
                                                                                          // ( empty ); //  47 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch07-1", -2037.949, 9.000, -1126.735, comment: ""); //  48 nn:1 nl:0
                                                                                          // ( empty ); //  49 nn:0 nl:0
                                                                                          // ( empty ); //  50 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch08-0", -2042.118, 9.000, -1141.340, comment: ""); //  51 nn:1 nl:0
                                                                                          // ( empty ); //  52 nn:0 nl:0
                                                                                          // ( empty ); //  53 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch08-1", -2046.030, 9.000, -1129.377, comment: ""); //  54 nn:1 nl:0
                                                                                          // ( empty ); //  55 nn:0 nl:0
                                                                                          // ( empty ); //  56 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch09-1", -2052.888, 9.000, -1131.620, comment: ""); //  57 nn:1 nl:0
                                                                                          // ( empty ); //  58 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-ch09-1", "rwb-f03-cv1-e", LinkUse.legacy); //  59 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-ch10-0", -2014.988, 9.000, -1119.227, comment: ""); //  60 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-cv0-e", "rwb-f03-ch09-1", LinkUse.legacy); //  60 nn:1 nl:1
                                                                                        // ( empty ); //  61 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-ch10-0", "rwb-f03-ch05-1", LinkUse.legacy); //  62 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-ch10-1", -2024.044, 9.000, -1091.858, comment: ""); //  63 nn:1 nl:0
                                                                                          // ( empty ); //  64 nn:0 nl:0
                                                                                          // ( empty ); //  65 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch11-0", -2027.899, 9.000, -1123.449, comment: ""); //  66 nn:1 nl:0
                                                                                          // ( empty ); //  67 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-ch11-0", "rwb-f03-ch06-1", LinkUse.legacy); //  68 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-ch11-1", -2036.926, 9.000, -1096.170, comment: ""); //  69 nn:1 nl:0
                                                                                          // ( empty ); //  70 nn:0 nl:0
                                                                                          // ( empty ); //  71 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch12-0", -2038.401, 9.000, -1126.883, comment: ""); //  72 nn:1 nl:0
                                                                                          // ( empty ); //  73 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-ch12-0", "rwb-f03-ch07-1", LinkUse.legacy); //  74 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-ch12-1", -2047.400, 9.000, -1099.676, comment: ""); //  75 nn:1 nl:0
                                                                                          // ( empty ); //  76 nn:0 nl:0
                                                                                          // ( empty ); //  77 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch20-0", -1993.753, 9.000, -1081.718, comment: ""); //  78 nn:1 nl:0
                                                                                          // ( empty ); //  79 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-ch20-0", "rwb-f03-cv2-s", LinkUse.legacy); //  80 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-ch21-0", -2000.596, 9.000, -1084.009, comment: ""); //  81 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-ch20-0", "rwb-f03-cv3-s", LinkUse.legacy); //  81 nn:1 nl:1
                                                                                        // ( empty ); //  82 nn:0 nl:0
                                                                                        // ( empty ); //  83 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch21-1", -2004.565, 9.000, -1072.010, comment: ""); //  84 nn:1 nl:0
                                                                                          // ( empty ); //  85 nn:0 nl:0
                                                                                          // ( empty ); //  86 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch22-0", -2008.647, 9.000, -1086.704, comment: ""); //  87 nn:1 nl:0
                                                                                          // ( empty ); //  88 nn:0 nl:0
                                                                                          // ( empty ); //  89 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch22-1", -2012.634, 9.000, -1074.648, comment: ""); //  90 nn:1 nl:0
                                                                                          // ( empty ); //  91 nn:0 nl:0
                                                                                          // ( empty ); //  92 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch23-0", -2016.296, 9.000, -1089.264, comment: ""); //  93 nn:1 nl:0
                                                                                          // ( empty ); //  94 nn:0 nl:0
                                                                                          // ( empty ); //  95 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch23-1", -2020.300, 9.000, -1077.154, comment: ""); //  96 nn:1 nl:0
                                                                                          // ( empty ); //  97 nn:0 nl:0
                                                                                          // ( empty ); //  98 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch24-0", -2024.347, 9.000, -1091.959, comment: ""); //  99 nn:1 nl:0
                                                                                          // ( empty ); //  100 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-ch24-0", "rwb-f03-ch10-1", LinkUse.legacy); //  101 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-ch24-1", -2028.369, 9.000, -1079.792, comment: ""); //  102 nn:1 nl:0
                                                                                          // ( empty ); //  103 nn:0 nl:0
                                                                                          // ( empty ); //  104 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch25-0", -2037.236, 9.000, -1096.274, comment: ""); //  105 nn:1 nl:0
                                                                                          // ( empty ); //  106 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-ch25-0", "rwb-f03-ch11-1", LinkUse.legacy); //  107 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-ch25-1", -2041.292, 9.000, -1084.016, comment: ""); //  108 nn:1 nl:0
                                                                                          // ( empty ); //  109 nn:0 nl:0
                                                                                          // ( empty ); //  110 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch26-0", -2047.702, 9.000, -1099.777, comment: ""); //  111 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-ch26-0", "rwb-f03-ch12-1", LinkUse.legacy); //  112 nn:0 nl:1
                                                                                         // ( empty ); //  113 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch26-1", -2051.781, 9.000, -1087.446, comment: ""); //  114 nn:1 nl:0
                                                                                          // ( empty ); //  115 nn:0 nl:0
                                                                                          // ( empty ); //  116 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch27-0", -2055.753, 9.000, -1102.472, comment: ""); //  117 nn:1 nl:0
                                                                                          // ( empty ); //  118 nn:0 nl:0
                                                                                          // ( empty ); //  119 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch27-1", -2059.851, 9.000, -1090.083, comment: ""); //  120 nn:1 nl:0
                                                                                          // ( empty ); //  121 nn:0 nl:0
                                                                                          // ( empty ); //  122 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch28-0", -2063.804, 9.000, -1105.167, comment: ""); //  123 nn:1 nl:0
                                                                                          // ( empty ); //  124 nn:0 nl:0
                                                                                          // ( empty ); //  125 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch28-1", -2067.920, 9.000, -1092.721, comment: ""); //  126 nn:1 nl:0
                                                                                          // ( empty ); //  127 nn:0 nl:0
                                                                                          // ( empty ); //  128 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-ch29-1", -2074.779, 9.000, -1094.963, comment: ""); //  129 nn:1 nl:0
                                                                                          // ( empty ); //  130 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-ch29-1", "rwb-f03-cv3-e", LinkUse.legacy); //  131 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3261", -1978.836, 9.000, -1112.296, comment: "NA"); //  132 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-cv2-e", "rwb-f03-ch29-1", LinkUse.legacy); //  132 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3261", -1981.220, 9.000, -1113.076, comment: ""); //  133 nn:1 nl:0
                                                                                           // ( empty ); //  134 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3261", "rwb-f03-ch01-1", LinkUse.legacy); //  135 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3215", -2019.181, 9.000, -1114.021, comment: "BAPERRY"); //  136 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3261", "rwb-f03-cor3261", LinkUse.legacy); //  136 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3215", -2016.955, 9.000, -1113.284, comment: ""); //  137 nn:1 nl:0
                                                                                           // ( empty ); //  138 nn:0 nl:0
                                                                                           // ( empty ); //  139 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3377", -2041.265, 9.000, -1110.094, comment: "KIWATANA"); //  140 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3215", "rwb-f03-cor3215", LinkUse.legacy); //  140 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3377", -2043.689, 9.000, -1110.896, comment: ""); //  141 nn:1 nl:0
                                                                                           // ( empty ); //  142 nn:0 nl:0
                                                                                           // ( empty ); //  143 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3267", -1981.755, 9.000, -1119.345, comment: "MNARANJO"); //  144 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3377", "rwb-f03-cor3377", LinkUse.legacy); //  144 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3267", -1981.088, 9.000, -1121.384, comment: ""); //  145 nn:1 nl:0
                                                                                           // ( empty ); //  146 nn:0 nl:0
                                                                                           // ( empty ); //  147 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3381", -2043.165, 9.000, -1104.696, comment: "KABYSTRO,ALCARDEN"); //  148 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3267", "rwb-f03-cor3267", LinkUse.legacy); //  148 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3381", -2045.486, 9.000, -1105.464, comment: ""); //  149 nn:1 nl:0
                                                                                           // ( empty ); //  150 nn:0 nl:0
                                                                                           // ( empty ); //  151 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3375", -2040.505, 9.000, -1112.253, comment: "AMITAGRA"); //  152 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3381", "rwb-f03-cor3381", LinkUse.legacy); //  152 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3375", -2042.970, 9.000, -1113.069, comment: ""); //  153 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3375", "rwb-f03-cor3377", LinkUse.legacy); //  154 nn:0 nl:1
                                                                                           // ( empty ); //  155 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3359", -2047.845, 9.000, -1132.309, comment: "ABOCZAR"); //  156 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3375", "rwb-f03-cor3375", LinkUse.legacy); //  156 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3359", -2048.536, 9.000, -1130.197, comment: ""); //  157 nn:1 nl:0
                                                                                           // ( empty ); //  158 nn:0 nl:0
                                                                                           // ( empty ); //  159 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3353", -2044.995, 9.000, -1140.406, comment: "PETERYI"); //  160 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3359", "rwb-f03-cor3359", LinkUse.legacy); //  160 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3353", -2044.441, 9.000, -1142.100, comment: ""); //  161 nn:1 nl:0
                                                                                           // ( empty ); //  162 nn:0 nl:0
                                                                                           // ( empty ); //  163 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3173", -1998.839, 9.000, -1081.042, comment: "PKHANNA"); //  164 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3353", "rwb-f03-cor3353", LinkUse.legacy); //  164 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3173", -1998.122, 9.000, -1083.181, comment: ""); //  165 nn:1 nl:0
                                                                                           // ( empty ); //  166 nn:0 nl:0
                                                                                           // ( empty ); //  167 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3169", -2001.499, 9.000, -1073.485, comment: "BALUS"); //  168 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3173", "rwb-f03-cor3173", LinkUse.legacy); //  168 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3169", -2002.230, 9.000, -1071.247, comment: ""); //  169 nn:1 nl:0
                                                                                           // ( empty ); //  170 nn:0 nl:0
                                                                                           // ( empty ); //  171 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3374", -2045.725, 9.000, -1114.042, comment: "BLAIRSH"); //  172 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3169", "rwb-f03-cor3169", LinkUse.legacy); //  172 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3374", -2042.952, 9.000, -1113.124, comment: ""); //  173 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3374", "rwb-f03-cor3375", LinkUse.legacy); //  174 nn:0 nl:1
                                                                                           // ( empty ); //  175 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3257", -1976.936, 9.000, -1117.694, comment: "KATHLEES,OMASEK"); //  176 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3374", "rwb-f03-cor3374", LinkUse.legacy); //  176 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3257", -1976.247, 9.000, -1119.801, comment: ""); //  177 nn:1 nl:0
                                                                                           // ( empty ); //  178 nn:0 nl:0
                                                                                           // ( empty ); //  179 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3376", -2046.675, 9.000, -1111.343, comment: "MPIGGOTT"); //  180 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3257", "rwb-f03-cor3257", LinkUse.legacy); //  180 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3376", -2043.850, 9.000, -1110.408, comment: ""); //  181 nn:1 nl:0
                                                                                           // ( empty ); //  182 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3376", "rwb-f03-cor3377", LinkUse.legacy); //  183 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3129", -2028.682, 9.000, -1087.032, comment: "MARIANAQ"); //  184 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3376", "rwb-f03-cor3376", LinkUse.legacy); //  184 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3129", -2026.242, 9.000, -1086.225, comment: ""); //  185 nn:1 nl:0
                                                                                           // ( empty ); //  186 nn:0 nl:0
                                                                                           // ( empty ); //  187 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3205", -2024.691, 9.000, -1098.367, comment: "MATTPE"); //  188 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3129", "rwb-f03-cor3129", LinkUse.legacy); //  188 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3205", -2022.167, 9.000, -1097.532, comment: ""); //  189 nn:1 nl:0
                                                                                           // ( empty ); //  190 nn:0 nl:0
                                                                                           // ( empty ); //  191 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3282", -1990.486, 9.000, -1127.780, comment: "LAUPRES"); //  192 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3205", "rwb-f03-cor3205", LinkUse.legacy); //  192 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3282", -1991.468, 9.000, -1124.778, comment: ""); //  193 nn:1 nl:0
                                                                                           // ( empty ); //  194 nn:0 nl:0
                                                                                           // ( empty ); //  195 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3184", -2012.389, 9.000, -1091.128, comment: "GILPETTE"); //  196 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3282", "rwb-f03-cor3282", LinkUse.legacy); //  196 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3184", -2013.344, 9.000, -1088.276, comment: ""); //  197 nn:1 nl:0
                                                                                           // ( empty ); //  198 nn:0 nl:0
                                                                                           // ( empty ); //  199 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3207", -2023.741, 9.000, -1101.066, comment: "WENDYJ"); //  200 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3184", "rwb-f03-cor3184", LinkUse.legacy); //  200 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3207", -2021.268, 9.000, -1100.248, comment: ""); //  201 nn:1 nl:0
                                                                                           // ( empty ); //  202 nn:0 nl:0
                                                                                           // ( empty ); //  203 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3372", -2044.775, 9.000, -1116.741, comment: "FPACE"); //  204 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3207", "rwb-f03-cor3207", LinkUse.legacy); //  204 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3372", -2042.053, 9.000, -1115.840, comment: ""); //  205 nn:1 nl:0
                                                                                           // ( empty ); //  206 nn:0 nl:0
                                                                                           // ( empty ); //  207 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3069", -2066.898, 9.000, -1103.754, comment: "FAYEB"); //  208 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3372", "rwb-f03-cor3372", LinkUse.legacy); //  208 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3069", -2066.161, 9.000, -1105.955, comment: ""); //  209 nn:1 nl:0
                                                                                           // ( empty ); //  210 nn:0 nl:0
                                                                                           // ( empty ); //  211 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3335", -2032.736, 9.000, -1135.601, comment: "JEPEARSO,EUNICES"); //  212 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3069", "rwb-f03-cor3069", LinkUse.legacy); //  212 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3335", -2034.826, 9.000, -1136.285, comment: ""); //  213 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3335", "rwb-f03-ch07-0", LinkUse.legacy); //  214 nn:0 nl:1
                                                                                          // ( empty ); //  215 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3221", -2021.953, 9.000, -1124.044, comment: "PHILIBRI"); //  216 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3335", "rwb-f03-cor3335", LinkUse.legacy); //  216 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3221", -2022.703, 9.000, -1121.750, comment: ""); //  217 nn:1 nl:0
                                                                                           // ( empty ); //  218 nn:0 nl:0
                                                                                           // ( empty ); //  219 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3253", -1979.786, 9.000, -1109.597, comment: "PAGUNASH"); //  220 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3221", "rwb-f03-cor3221", LinkUse.legacy); //  220 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3253", -1980.342, 9.000, -1107.898, comment: ""); //  221 nn:1 nl:0
                                                                                           // ( empty ); //  222 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3253", "rwb-f03-cv1-s", LinkUse.legacy); //  223 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3385", -2035.206, 9.000, -1128.584, comment: "EVANI"); //  224 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3253", "rwb-f03-cor3253", LinkUse.legacy); //  224 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3385", -2037.138, 9.000, -1129.216, comment: ""); //  225 nn:1 nl:0
                                                                                           // ( empty ); //  226 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3385", "rwb-f03-ch07-1", LinkUse.legacy); //  227 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3371", -2038.604, 9.000, -1117.651, comment: "NINDYHU"); //  228 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3385", "rwb-f03-cor3385", LinkUse.legacy); //  228 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3371", -2041.173, 9.000, -1118.501, comment: ""); //  229 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3371", "rwb-f03-cor3372", LinkUse.legacy); //  230 nn:0 nl:1
                                                                                           // ( empty ); //  231 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3073", -2069.748, 9.000, -1095.657, comment: "NA"); //  232 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3371", "rwb-f03-cor3371", LinkUse.legacy); //  232 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3073", -2070.438, 9.000, -1093.545, comment: ""); //  233 nn:1 nl:0
                                                                                           // ( empty ); //  234 nn:0 nl:0
                                                                                           // ( empty ); //  235 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3105", -2048.887, 9.000, -1089.720, comment: "SENTHILC,MKRANZ"); //  236 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3073", "rwb-f03-cor3073", LinkUse.legacy); //  236 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3105", -2050.818, 9.000, -1090.359, comment: ""); //  237 nn:1 nl:0
                                                                                           // ( empty ); //  238 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3105", "rwb-f03-ch26-1", LinkUse.legacy); //  239 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3199", -2033.164, 9.000, -1092.197, comment: "ROSALYNV"); //  240 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3105", "rwb-f03-cor3105", LinkUse.legacy); //  240 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3199", -2032.347, 9.000, -1094.637, comment: ""); //  241 nn:1 nl:0
                                                                                           // ( empty ); //  242 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3199", "rwb-f03-ch11-1", LinkUse.legacy); //  243 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3063", -2059.056, 9.000, -1100.462, comment: "NA"); //  244 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3199", "rwb-f03-cor3199", LinkUse.legacy); //  244 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3063", -2056.678, 9.000, -1099.676, comment: ""); //  245 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3063", "rwb-f03-ch27-0", LinkUse.legacy); //  246 nn:0 nl:1
                                                                                          // ( empty ); //  247 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3378", -2047.625, 9.000, -1108.644, comment: "TOMFREE"); //  248 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3063", "rwb-f03-cor3063", LinkUse.legacy); //  248 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3378", -2044.749, 9.000, -1107.692, comment: ""); //  249 nn:1 nl:0
                                                                                           // ( empty ); //  250 nn:0 nl:0
                                                                                           // ( empty ); //  251 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3337", -2033.876, 9.000, -1132.363, comment: "NA"); //  252 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3378", "rwb-f03-cor3378", LinkUse.legacy); //  252 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3337", -2035.893, 9.000, -1133.022, comment: ""); //  253 nn:1 nl:0
                                                                                           // ( empty ); //  254 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3337", "rwb-f03-cor3335", LinkUse.legacy); //  255 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3103", -2047.747, 9.000, -1092.958, comment: "ANKURT,SIMRANS"); //  256 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3337", "rwb-f03-cor3337", LinkUse.legacy); //  256 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3103", -2049.740, 9.000, -1093.618, comment: ""); //  257 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3103", "rwb-f03-cor3105", LinkUse.legacy); //  258 nn:0 nl:1
                                                                                           // ( empty ); //  259 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3141", -2021.980, 9.000, -1080.502, comment: "THOKRAKU,SAWEAVER"); //  260 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3103", "rwb-f03-cor3103", LinkUse.legacy); //  260 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3141", -2019.468, 9.000, -1079.671, comment: ""); //  261 nn:1 nl:0
                                                                                           // ( empty ); //  262 nn:0 nl:0
                                                                                           // ( empty ); //  263 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3234", -2007.600, 9.000, -1113.682, comment: "NA"); //  264 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3141", "rwb-f03-cor3141", LinkUse.legacy); //  264 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3234", -2006.675, 9.000, -1116.509, comment: ""); //  265 nn:1 nl:0
                                                                                           // ( empty ); //  266 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3234", "rwb-f03-ch04-1", LinkUse.legacy); //  267 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3155", -2009.531, 9.000, -1076.236, comment: "SACHAA"); //  268 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3234", "rwb-f03-cor3234", LinkUse.legacy); //  268 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3155", -2011.855, 9.000, -1077.005, comment: ""); //  269 nn:1 nl:0
                                                                                           // ( empty ); //  270 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3155", "rwb-f03-ch22-1", LinkUse.legacy); //  271 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3179", -2007.060, 9.000, -1083.254, comment: "ROBERH"); //  272 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3155", "rwb-f03-cor3155", LinkUse.legacy); //  272 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3179", -2009.519, 9.000, -1084.067, comment: ""); //  273 nn:1 nl:0
                                                                                           // ( empty ); //  274 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3179", "rwb-f03-ch22-0", LinkUse.legacy); //  275 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3370", -2043.825, 9.000, -1119.439, comment: "MARKKOTT"); //  276 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3179", "rwb-f03-cor3179", LinkUse.legacy); //  276 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3370", -2041.155, 9.000, -1118.556, comment: ""); //  277 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3370", "rwb-f03-cor3371", LinkUse.legacy); //  278 nn:0 nl:1
                                                                                           // ( empty ); //  279 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3089", -2060.196, 9.000, -1097.224, comment: "KRMARCHB"); //  280 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3370", "rwb-f03-cor3370", LinkUse.legacy); //  280 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3089", -2057.756, 9.000, -1096.417, comment: ""); //  281 nn:1 nl:0
                                                                                           // ( empty ); //  282 nn:0 nl:0
                                                                                           // ( empty ); //  283 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3185", -2016.232, 9.000, -1082.767, comment: "JOEGURA,LANAMAY"); //  284 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3089", "rwb-f03-cor3089", LinkUse.legacy); //  284 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3185", -2018.226, 9.000, -1083.426, comment: ""); //  285 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3185", "rwb-f03-cor3141", LinkUse.legacy); //  286 nn:0 nl:1
                                                                                           // ( empty ); //  287 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3097", -2053.304, 9.000, -1091.233, comment: "PURNAG"); //  288 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3185", "rwb-f03-cor3185", LinkUse.legacy); //  288 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3223", -2018.740, 9.000, -1122.943, comment: "KAVENK"); //  289 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3097", "rwb-f03-cor3105", LinkUse.legacy); //  289 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3223", -2019.476, 9.000, -1120.694, comment: ""); //  290 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3223", "rwb-f03-cor3221", LinkUse.legacy); //  291 nn:0 nl:1
                                                                                           // ( empty ); //  292 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3087", -2061.526, 9.000, -1093.445, comment: "NA"); //  293 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3223", "rwb-f03-cor3223", LinkUse.legacy); //  293 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3087", -2059.014, 9.000, -1092.614, comment: ""); //  294 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3087", "rwb-f03-cor3089", LinkUse.legacy); //  295 nn:0 nl:1
                                                                                           // ( empty ); //  296 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3123", -2035.634, 9.000, -1085.180, comment: "SHTANYA"); //  297 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3087", "rwb-f03-cor3087", LinkUse.legacy); //  297 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3123", -2036.524, 9.000, -1082.458, comment: ""); //  298 nn:1 nl:0
                                                                                           // ( empty ); //  299 nn:0 nl:0
                                                                                           // ( empty ); //  300 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3236", -2004.788, 9.000, -1112.719, comment: "EMILYM"); //  301 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3123", "rwb-f03-cor3123", LinkUse.legacy); //  301 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3236", -2003.851, 9.000, -1115.585, comment: ""); //  302 nn:1 nl:0
                                                                                           // ( empty ); //  303 nn:0 nl:0
                                                                                           // ( empty ); //  304 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3238", -2001.977, 9.000, -1111.756, comment: "SHYATT"); //  305 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3236", "rwb-f03-cor3236", LinkUse.legacy); //  305 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3238", -2001.027, 9.000, -1114.662, comment: ""); //  306 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3238", "rwb-f03-cor3236", LinkUse.legacy); //  307 nn:0 nl:1
                                                                                           // ( empty ); //  308 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3244", -1993.945, 9.000, -1109.004, comment: "LUCYHUR"); //  309 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3238", "rwb-f03-cor3238", LinkUse.legacy); //  309 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3244", -1992.958, 9.000, -1112.024, comment: ""); //  310 nn:1 nl:0
                                                                                           // ( empty ); //  311 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3244", "rwb-f03-ch02-1", LinkUse.legacy); //  312 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3140", -2018.240, 9.000, -1083.455, comment: "NA"); //  313 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3244", "rwb-f03-cor3244", LinkUse.legacy); //  313 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3240", -1999.568, 9.000, -1110.931, comment: "NA"); //  314 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3140", "rwb-f03-cor3185", LinkUse.legacy); //  314 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3240", -1998.606, 9.000, -1113.870, comment: ""); //  315 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3240", "rwb-f03-cor3238", LinkUse.legacy); //  316 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3240", "rwb-f03-ch03-1", LinkUse.legacy); //  317 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3348", -2044.105, 9.000, -1135.262, comment: "NA"); //  318 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3240", "rwb-f03-cor3240", LinkUse.legacy); //  318 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3348", -2044.105, 9.000, -1135.262, comment: ""); //  319 nn:1 nl:0
                                                                                           // ( empty ); //  320 nn:0 nl:0
                                                                                           // ( empty ); //  321 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3321", -2021.448, 9.000, -1129.315, comment: "ANIDH"); //  322 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3348", "rwb-f03-cor3348", LinkUse.legacy); //  322 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3321", -2025.103, 9.000, -1130.510, comment: ""); //  323 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3321", "rwb-f03-ch06-0", LinkUse.legacy); //  324 nn:0 nl:1
                                                                                          // ( empty ); //  325 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3252", -1986.125, 9.000, -1106.930, comment: "SUSANNEV"); //  326 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3321", "rwb-f03-cor3321", LinkUse.legacy); //  326 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3252", -1985.281, 9.000, -1109.513, comment: ""); //  327 nn:1 nl:0
                                                                                           // ( empty ); //  328 nn:0 nl:0
                                                                                           // ( empty ); //  329 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3248", -1988.535, 9.000, -1107.756, comment: "TOMURPHY"); //  330 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3252", "rwb-f03-cor3252", LinkUse.legacy); //  330 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3248", -1987.701, 9.000, -1110.305, comment: ""); //  331 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3248", "rwb-f03-cor3252", LinkUse.legacy); //  332 nn:0 nl:1
                                                                                           // ( empty ); //  333 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3296", -2004.559, 9.000, -1122.319, comment: "NA"); //  334 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3248", "rwb-f03-cor3248", LinkUse.legacy); //  334 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3296", -2004.559, 9.000, -1122.319, comment: ""); //  335 nn:1 nl:0
                                                                                           // ( empty ); //  336 nn:0 nl:0
                                                                                           // ( empty ); //  337 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3306", -2012.591, 9.000, -1125.071, comment: "NA"); //  338 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3296", "rwb-f03-cor3296", LinkUse.legacy); //  338 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3306", -2012.591, 9.000, -1125.071, comment: ""); //  339 nn:1 nl:0
                                                                                           // ( empty ); //  340 nn:0 nl:0
                                                                                           // ( empty ); //  341 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3326", -2025.252, 9.000, -1130.013, comment: "NA"); //  342 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3306", "rwb-f03-cor3306", LinkUse.legacy); //  342 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3326", -2025.264, 9.000, -1130.017, comment: ""); //  343 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3326", "rwb-f03-cor3321", LinkUse.legacy); //  344 nn:0 nl:1
                                                                                           // ( empty ); //  345 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3112", -2039.905, 9.000, -1089.667, comment: "NA"); //  346 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3326", "rwb-f03-cor3326", LinkUse.legacy); //  346 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3112", -2039.470, 9.000, -1089.523, comment: ""); //  347 nn:1 nl:0
                                                                                           // ( empty ); //  348 nn:0 nl:0
                                                                                           // ( empty ); //  349 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3274", -1988.496, 9.000, -1116.815, comment: "NA"); //  350 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3112", "rwb-f03-cor3112", LinkUse.legacy); //  350 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3274", -1988.887, 9.000, -1116.943, comment: ""); //  351 nn:1 nl:0
                                                                                           // ( empty ); //  352 nn:0 nl:0
                                                                                           // ( empty ); //  353 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3246", -1991.346, 9.000, -1108.719, comment: "MODEME"); //  354 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3274", "rwb-f03-cor3274", LinkUse.legacy); //  354 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3246", -1990.525, 9.000, -1111.228, comment: ""); //  355 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3246", "rwb-f03-cor3248", LinkUse.legacy); //  356 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3246", "rwb-f03-ch02-1", LinkUse.legacy); //  357 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3284", -1996.527, 9.000, -1119.567, comment: "NA"); //  358 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3246", "rwb-f03-cor3246", LinkUse.legacy); //  358 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3284", -1996.527, 9.000, -1119.567, comment: ""); //  359 nn:1 nl:0
                                                                                           // ( empty ); //  360 nn:0 nl:0
                                                                                           // ( empty ); //  361 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3264", -1980.675, 9.000, -1114.741, comment: "NA"); //  362 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3284", "rwb-f03-cor3284", LinkUse.legacy); //  362 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3264", -1980.675, 9.000, -1114.741, comment: ""); //  363 nn:1 nl:0
                                                                                           // ( empty ); //  364 nn:0 nl:0
                                                                                           // ( empty ); //  365 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3242", -1996.757, 9.000, -1109.968, comment: "ERIKAH"); //  366 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3264", "rwb-f03-cor3264", LinkUse.legacy); //  366 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3242", -1995.782, 9.000, -1112.947, comment: ""); //  367 nn:1 nl:0
                                                                                           // ( empty ); //  368 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3242", "rwb-f03-ch03-1", LinkUse.legacy); //  369 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3360", -2047.547, 9.000, -1126.764, comment: "NABINK"); //  370 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3242", "rwb-f03-cor3242", LinkUse.legacy); //  370 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3360", -2046.629, 9.000, -1129.573, comment: ""); //  371 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3360", "rwb-f03-cor3359", LinkUse.legacy); //  372 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3360", "rwb-f03-ch08-1", LinkUse.legacy); //  373 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3168", -2005.217, 9.000, -1069.315, comment: "RICKOL"); //  374 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3360", "rwb-f03-cor3360", LinkUse.legacy); //  374 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3168", -2004.358, 9.000, -1071.942, comment: ""); //  375 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3168", "rwb-f03-cor3169", LinkUse.legacy); //  376 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3168", "rwb-f03-ch21-1", LinkUse.legacy); //  377 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3158", -2007.626, 9.000, -1070.140, comment: "JALLEN"); //  378 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3168", "rwb-f03-cor3168", LinkUse.legacy); //  378 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3158", -2006.778, 9.000, -1072.734, comment: ""); //  379 nn:1 nl:0
                                                                                           // ( empty ); //  380 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3158", "rwb-f03-ch21-1", LinkUse.legacy); //  381 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3156", -2010.437, 9.000, -1071.103, comment: "RLONGDEN"); //  382 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3158", "rwb-f03-cor3158", LinkUse.legacy); //  382 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3156", -2009.603, 9.000, -1073.657, comment: ""); //  383 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3156", "rwb-f03-cor3158", LinkUse.legacy); //  384 nn:0 nl:1
                                                                                           // ( empty ); //  385 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3152", -2010.208, 9.000, -1080.703, comment: "NA"); //  386 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3156", "rwb-f03-cor3156", LinkUse.legacy); //  386 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3152", -2010.590, 9.000, -1080.829, comment: ""); //  387 nn:1 nl:0
                                                                                           // ( empty ); //  388 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3152", "rwb-f03-cor3155", LinkUse.legacy); //  389 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3148", -2013.249, 9.000, -1072.066, comment: "AMBROSEW"); //  390 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3152", "rwb-f03-cor3152", LinkUse.legacy); //  390 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3148", -2012.427, 9.000, -1074.580, comment: ""); //  391 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3148", "rwb-f03-cor3156", LinkUse.legacy); //  392 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3148", "rwb-f03-ch22-1", LinkUse.legacy); //  393 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3340", -2036.285, 9.000, -1133.188, comment: "NA"); //  394 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3148", "rwb-f03-cor3148", LinkUse.legacy); //  394 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3146", -2015.658, 9.000, -1072.892, comment: "ALEXMUK"); //  395 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3340", "rwb-f03-cor3337", LinkUse.legacy); //  395 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3146", -2014.847, 9.000, -1075.372, comment: ""); //  396 nn:1 nl:0
                                                                                           // ( empty ); //  397 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3146", "rwb-f03-ch22-1", LinkUse.legacy); //  398 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3144", -2018.469, 9.000, -1073.855, comment: "SHAUNH"); //  399 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3146", "rwb-f03-cor3146", LinkUse.legacy); //  399 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3144", -2017.672, 9.000, -1076.295, comment: ""); //  400 nn:1 nl:0
                                                                                           // ( empty ); //  401 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3144", "rwb-f03-ch23-1", LinkUse.legacy); //  402 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3115", -2035.129, 9.000, -1090.450, comment: "SAIEMA"); //  403 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3144", "rwb-f03-cor3144", LinkUse.legacy); //  403 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3115", -2038.765, 9.000, -1091.653, comment: ""); //  404 nn:1 nl:0
                                                                                           // ( empty ); //  405 nn:0 nl:0
                                                                                           // ( empty ); //  406 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3090", -2058.188, 9.000, -1096.536, comment: "NA"); //  407 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3115", "rwb-f03-cor3115", LinkUse.legacy); //  407 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3142", -2021.280, 9.000, -1074.818, comment: "LUISTO"); //  408 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3090", "rwb-f03-cor3089", LinkUse.legacy); //  408 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3142", -2020.496, 9.000, -1077.218, comment: ""); //  409 nn:1 nl:0
                                                                                           // ( empty ); //  410 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3142", "rwb-f03-ch23-1", LinkUse.legacy); //  411 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3080", -2065.818, 9.000, -1099.150, comment: "NA"); //  412 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3142", "rwb-f03-cor3142", LinkUse.legacy); //  412 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3080", -2065.796, 9.000, -1099.143, comment: ""); //  413 nn:1 nl:0
                                                                                           // ( empty ); //  414 nn:0 nl:0
                                                                                           // ( empty ); //  415 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3102", -2050.156, 9.000, -1093.784, comment: "NA"); //  416 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3080", "rwb-f03-cor3080", LinkUse.legacy); //  416 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3166", -2002.578, 9.000, -1078.089, comment: "NA"); //  417 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3102", "rwb-f03-cor3103", LinkUse.legacy); //  417 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3166", -2002.557, 9.000, -1078.082, comment: ""); //  418 nn:1 nl:0
                                                                                           // ( empty ); //  419 nn:0 nl:0
                                                                                           // ( empty ); //  420 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3310", -2026.272, 9.000, -1086.206, comment: "NA"); //  421 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3166", "rwb-f03-cor3166", LinkUse.legacy); //  421 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3391", -2030.300, 9.000, -1122.064, comment: "NA"); //  422 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3310", "rwb-f03-cor3129", LinkUse.legacy); //  422 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3391", -2028.548, 9.000, -1121.485, comment: ""); //  423 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3391", "rwb-f03-ch11-0", LinkUse.legacy); //  424 nn:0 nl:1
                                                                                          // ( empty ); //  425 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3100", -2053.196, 9.000, -1085.148, comment: "CARLACAS"); //  426 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3391", "rwb-f03-cor3391", LinkUse.legacy); //  426 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3100", -2052.381, 9.000, -1087.642, comment: ""); //  427 nn:1 nl:0
                                                                                           // ( empty ); //  428 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3100", "rwb-f03-ch26-1", LinkUse.legacy); //  429 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3134", -2029.312, 9.000, -1077.570, comment: "LISAOL"); //  430 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3100", "rwb-f03-cor3100", LinkUse.legacy); //  430 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3134", -2028.565, 9.000, -1079.856, comment: ""); //  431 nn:1 nl:0
                                                                                           // ( empty ); //  432 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3134", "rwb-f03-ch24-1", LinkUse.legacy); //  433 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3075", -2068.798, 9.000, -1098.356, comment: "NA"); //  434 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3134", "rwb-f03-cor3134", LinkUse.legacy); //  434 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3075", -2066.326, 9.000, -1097.539, comment: ""); //  435 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3075", "rwb-f03-cor3080", LinkUse.legacy); //  436 nn:0 nl:1
                                                                                           // ( empty ); //  437 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3401", -2022.752, 9.000, -1112.825, comment: "NA"); //  438 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3075", "rwb-f03-cor3075", LinkUse.legacy); //  438 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3401", -2017.664, 9.000, -1111.141, comment: ""); //  439 nn:1 nl:0
                                                                                           // ( empty ); //  440 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3401", "rwb-f03-cor3215", LinkUse.legacy); //  441 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3136", -2026.501, 9.000, -1076.607, comment: "BKRAFFT"); //  442 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3401", "rwb-f03-cor3401", LinkUse.legacy); //  442 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3136", -2025.741, 9.000, -1078.933, comment: ""); //  443 nn:1 nl:0
                                                                                           // ( empty ); //  444 nn:0 nl:0
                                                                                           // ( empty ); //  445 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3138", -2023.690, 9.000, -1075.644, comment: "DOTTIES"); //  446 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3136", "rwb-f03-cor3136", LinkUse.legacy); //  446 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3138", -2022.917, 9.000, -1078.010, comment: ""); //  447 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3138", "rwb-f03-cor3136", LinkUse.legacy); //  448 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3138", "rwb-f03-cor3142", LinkUse.legacy); //  449 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3037", -2026.552, 9.000, -1102.029, comment: "NA"); //  450 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3138", "rwb-f03-cor3138", LinkUse.legacy); //  450 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3167", -2000.549, 9.000, -1076.184, comment: "KOBELL"); //  451 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3037", "rwb-f03-cor3207", LinkUse.legacy); //  451 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3167", -2002.925, 9.000, -1076.970, comment: ""); //  452 nn:1 nl:0
                                                                                           // ( empty ); //  453 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3167", "rwb-f03-ch21-1", LinkUse.legacy); //  454 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3096", -2058.819, 9.000, -1087.074, comment: "SQUINN"); //  455 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3167", "rwb-f03-cor3167", LinkUse.legacy); //  455 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3096", -2058.029, 9.000, -1089.488, comment: ""); //  456 nn:1 nl:0
                                                                                           // ( empty ); //  457 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3096", "rwb-f03-ch27-1", LinkUse.legacy); //  458 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3259", -1977.886, 9.000, -1114.995, comment: "KERAINES"); //  459 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3096", "rwb-f03-cor3096", LinkUse.legacy); //  459 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3259", -1980.331, 9.000, -1115.795, comment: ""); //  460 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3259", "rwb-f03-cor3264", LinkUse.legacy); //  461 nn:0 nl:1
                                                                                           // ( empty ); //  462 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3351", -2045.945, 9.000, -1137.707, comment: "GORKEMY"); //  463 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3259", "rwb-f03-cor3259", LinkUse.legacy); //  463 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3351", -2043.561, 9.000, -1136.928, comment: ""); //  464 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3351", "rwb-f03-cor3348", LinkUse.legacy); //  465 nn:0 nl:1
                                                                                           // ( empty ); //  466 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3098", -2056.007, 9.000, -1086.111, comment: "SCHUMA"); //  467 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3351", "rwb-f03-cor3351", LinkUse.legacy); //  467 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3098", -2055.205, 9.000, -1088.565, comment: ""); //  468 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3098", "rwb-f03-cor3096", LinkUse.legacy); //  469 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3098", "rwb-f03-cor3100", LinkUse.legacy); //  470 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3027", -2027.420, 9.000, -1105.956, comment: "ConfRoom3027"); //  471 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3098", "rwb-f03-cor3098", LinkUse.legacy); //  471 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3027", -2033.069, 9.000, -1107.825, comment: ""); //  472 nn:1 nl:0
                                                                                           // ( empty ); //  473 nn:0 nl:0
                                                                                           // ( empty ); //  474 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3403", -2026.090, 9.000, -1109.734, comment: "ConfRoom3403"); //  475 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3027", "rwb-f03-cor3027", LinkUse.legacy); //  475 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3403", -2031.811, 9.000, -1111.627, comment: ""); //  476 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3403", "rwb-f03-cor3027", LinkUse.legacy); //  477 nn:0 nl:1
                                                                                           // ( empty ); //  478 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3108", -2044.974, 9.000, -1082.936, comment: "NA"); //  479 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3403", "rwb-f03-cor3403", LinkUse.legacy); //  479 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3108", -2044.300, 9.000, -1085.000, comment: ""); //  480 nn:1 nl:0
                                                                                           // ( empty ); //  481 nn:0 nl:0
                                                                                           // ( empty ); //  482 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3327", -2029.458, 9.000, -1130.849, comment: "NA"); //  483 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3108", "rwb-f03-cor3108", LinkUse.legacy); //  483 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3327", -2025.424, 9.000, -1129.530, comment: ""); //  484 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3327", "rwb-f03-cor3326", LinkUse.legacy); //  485 nn:0 nl:1
                                                                                           // ( empty ); //  486 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3094", -2061.228, 9.000, -1087.899, comment: "MARCBAX"); //  487 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3327", "rwb-f03-cor3327", LinkUse.legacy); //  487 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3094", -2060.450, 9.000, -1090.279, comment: ""); //  488 nn:1 nl:0
                                                                                           // ( empty ); //  489 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3094", "rwb-f03-ch27-1", LinkUse.legacy); //  490 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3111", -2043.329, 9.000, -1091.445, comment: "NA"); //  491 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3094", "rwb-f03-cor3094", LinkUse.legacy); //  491 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3111", -2039.277, 9.000, -1090.104, comment: ""); //  492 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3111", "rwb-f03-cor3115", LinkUse.legacy); //  493 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3111", "rwb-f03-cor3112", LinkUse.legacy); //  494 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3086", -2064.039, 9.000, -1088.862, comment: "ADRIENR"); //  495 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3111", "rwb-f03-cor3111", LinkUse.legacy); //  495 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3086", -2063.274, 9.000, -1091.203, comment: ""); //  496 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3086", "rwb-f03-cor3094", LinkUse.legacy); //  497 nn:0 nl:1
                                                                                           // ( empty ); //  498 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3254", -1982.109, 9.000, -1105.554, comment: "ANANDE"); //  499 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3086", "rwb-f03-cor3086", LinkUse.legacy); //  499 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3254", -1981.246, 9.000, -1108.194, comment: ""); //  500 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3254", "rwb-f03-cor3253", LinkUse.legacy); //  501 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3254", "rwb-f03-ch01-1", LinkUse.legacy); //  502 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3041", -2040.289, 9.000, -1100.082, comment: "NA"); //  503 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3254", "rwb-f03-cor3254", LinkUse.legacy); //  503 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3041", -2041.127, 9.000, -1097.576, comment: ""); //  504 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3041", "rwb-f03-ch25-0", LinkUse.legacy); //  505 nn:0 nl:1
                                                                                          // ( empty ); //  506 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3178", -2004.357, 9.000, -1088.376, comment: "DREWG"); //  507 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3041", "rwb-f03-cor3041", LinkUse.legacy); //  507 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3178", -2005.293, 9.000, -1085.581, comment: ""); //  508 nn:1 nl:0
                                                                                           // ( empty ); //  509 nn:0 nl:0
                                                                                           // ( empty ); //  510 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3186", -2015.200, 9.000, -1092.091, comment: "TIMTHO"); //  511 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3178", "rwb-f03-cor3178", LinkUse.legacy); //  511 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3186", -2016.161, 9.000, -1089.219, comment: ""); //  512 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3186", "rwb-f03-cor3184", LinkUse.legacy); //  513 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3186", "rwb-f03-ch23-0", LinkUse.legacy); //  514 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3074", -2069.260, 9.000, -1090.651, comment: "MIKEPAL"); //  515 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3186", "rwb-f03-cor3186", LinkUse.legacy); //  515 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3074", -2068.519, 9.000, -1092.917, comment: ""); //  516 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3074", "rwb-f03-cor3073", LinkUse.legacy); //  517 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3074", "rwb-f03-ch28-1", LinkUse.legacy); //  518 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3084", -2066.449, 9.000, -1089.688, comment: "ERICDAI"); //  519 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3074", "rwb-f03-cor3074", LinkUse.legacy); //  519 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3084", -2065.695, 9.000, -1091.994, comment: ""); //  520 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3084", "rwb-f03-cor3086", LinkUse.legacy); //  521 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3084", "rwb-f03-ch28-1", LinkUse.legacy); //  522 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3174", -1999.136, 9.000, -1086.588, comment: "MARLAB"); //  523 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3084", "rwb-f03-cor3084", LinkUse.legacy); //  523 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3174", -2000.060, 9.000, -1083.829, comment: ""); //  524 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3174", "rwb-f03-cor3173", LinkUse.legacy); //  525 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3174", "rwb-f03-ch21-0", LinkUse.legacy); //  526 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3062", -2055.148, 9.000, -1105.172, comment: "ANGELACO"); //  527 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3174", "rwb-f03-cor3174", LinkUse.legacy); //  527 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3062", -2056.021, 9.000, -1102.562, comment: ""); //  528 nn:1 nl:0
                                                                                           // ( empty ); //  529 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3062", "rwb-f03-ch27-0", LinkUse.legacy); //  530 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3180", -2007.168, 9.000, -1089.339, comment: "LCOZZENS"); //  531 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3062", "rwb-f03-cor3062", LinkUse.legacy); //  531 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3180", -2008.111, 9.000, -1086.524, comment: ""); //  532 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3180", "rwb-f03-cor3178", LinkUse.legacy); //  533 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3180", "rwb-f03-ch22-0", LinkUse.legacy); //  534 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3176", -2001.546, 9.000, -1087.413, comment: "JUANCOL"); //  535 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3180", "rwb-f03-cor3180", LinkUse.legacy); //  535 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3176", -2002.475, 9.000, -1084.638, comment: ""); //  536 nn:1 nl:0
                                                                                           // ( empty ); //  537 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3176", "rwb-f03-ch21-0", LinkUse.legacy); //  538 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3043", -2042.591, 9.000, -1094.821, comment: "NA"); //  539 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3176", "rwb-f03-cor3176", LinkUse.legacy); //  539 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3043", -2041.614, 9.000, -1097.739, comment: ""); //  540 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3043", "rwb-f03-cor3041", LinkUse.legacy); //  541 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3043", "rwb-f03-ch12-1", LinkUse.legacy); //  542 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3389", -2031.190, 9.000, -1127.208, comment: "NA"); //  543 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3043", "rwb-f03-cor3043", LinkUse.legacy); //  543 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3389", -2031.983, 9.000, -1124.784, comment: ""); //  544 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3389", "rwb-f03-ch11-0", LinkUse.legacy); //  545 nn:0 nl:1
                                                                                          // ( empty ); //  546 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3399", -2026.367, 9.000, -1114.063, comment: "CopyRoom"); //  547 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3389", "rwb-f03-cor3389", LinkUse.legacy); //  547 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3399", -2030.547, 9.000, -1115.446, comment: ""); //  548 nn:1 nl:0
                                                                                           // ( empty ); //  549 nn:0 nl:0
                                                                                           // ( empty ); //  550 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3999", -2032.179, 9.000, -1115.450, comment: "Stairs"); //  551 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3399", "rwb-f03-cor3399", LinkUse.legacy); //  551 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3999", -2030.707, 9.000, -1114.962, comment: ""); //  552 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3999", "rwb-f03-cor3399", LinkUse.legacy); //  553 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3999", "rwb-f03-cor3403", LinkUse.legacy); //  554 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3033", -2030.167, 9.000, -1103.267, comment: "Kitchen"); //  555 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3999", "rwb-f03-cor3999", LinkUse.legacy); //  555 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3033", -2034.142, 9.000, -1104.583, comment: ""); //  556 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3033", "rwb-f03-cor3027", LinkUse.legacy); //  557 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3033", "rwb-f03-ch11-1", LinkUse.legacy); //  558 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3064", -2057.959, 9.000, -1106.135, comment: "RGUSTAFS"); //  559 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3033", "rwb-f03-cor3033", LinkUse.legacy); //  559 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3064", -2058.840, 9.000, -1103.505, comment: ""); //  560 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3064", "rwb-f03-cor3062", LinkUse.legacy); //  561 nn:0 nl:1
                                                                                           // ( empty ); //  562 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3288", -1995.897, 9.000, -1129.029, comment: "LPAPPS"); //  563 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3064", "rwb-f03-cor3064", LinkUse.legacy); //  563 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3288", -1996.725, 9.000, -1126.497, comment: ""); //  564 nn:1 nl:0
                                                                                           // ( empty ); //  565 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3288", "rwb-f03-ch03-0", LinkUse.legacy); //  566 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3270", -1982.454, 9.000, -1125.029, comment: "DALEW"); //  567 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3288", "rwb-f03-cor3288", LinkUse.legacy); //  567 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3270", -1983.399, 9.000, -1122.140, comment: ""); //  568 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3270", "rwb-f03-cor3267", LinkUse.legacy); //  569 nn:0 nl:1
                                                                                           // ( empty ); //  570 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3258", -1977.234, 9.000, -1123.240, comment: "BRUJO"); //  571 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3270", "rwb-f03-cor3270", LinkUse.legacy); //  571 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3258", -1978.154, 9.000, -1120.425, comment: ""); //  572 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3258", "rwb-f03-cor3257", LinkUse.legacy); //  573 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3258", "rwb-f03-ch01-0", LinkUse.legacy); //  574 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3278", -1985.266, 9.000, -1125.992, comment: "WFONG"); //  575 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3258", "rwb-f03-cor3258", LinkUse.legacy); //  575 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3278", -1986.223, 9.000, -1123.063, comment: ""); //  576 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3278", "rwb-f03-cor3270", LinkUse.legacy); //  577 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3278", "rwb-f03-ch02-0", LinkUse.legacy); //  578 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3039", -2031.074, 9.000, -1098.134, comment: "NA"); //  579 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3278", "rwb-f03-cor3278", LinkUse.legacy); //  579 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3039", -2032.255, 9.000, -1094.606, comment: ""); //  580 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3039", "rwb-f03-cor3199", LinkUse.legacy); //  581 nn:0 nl:1
                                                                                           // ( empty ); //  582 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3268", -1980.045, 9.000, -1124.203, comment: "MMERCURI"); //  583 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3039", "rwb-f03-cor3039", LinkUse.legacy); //  583 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3268", -1980.978, 9.000, -1121.348, comment: ""); //  584 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3268", "rwb-f03-cor3267", LinkUse.legacy); //  585 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3268", "rwb-f03-ch01-0", LinkUse.legacy); //  586 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3290", -1998.708, 9.000, -1129.992, comment: "KLEADER"); //  587 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3268", "rwb-f03-cor3268", LinkUse.legacy); //  587 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3290", -1999.549, 9.000, -1127.421, comment: ""); //  588 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3290", "rwb-f03-cor3288", LinkUse.legacy); //  589 nn:0 nl:1
                                                                                           // ( empty ); //  590 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3334", -2010.099, 9.000, -1130.871, comment: "NA"); //  591 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3290", "rwb-f03-cor3290", LinkUse.legacy); //  591 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3334", -2010.099, 9.000, -1130.871, comment: ""); //  592 nn:1 nl:0
                                                                                           // ( empty ); //  593 nn:0 nl:0
                                                                                           // ( empty ); //  594 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3314", -2014.772, 9.000, -1135.496, comment: "KFILE"); //  595 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3334", "rwb-f03-cor3334", LinkUse.legacy); //  595 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3314", -2015.687, 9.000, -1132.698, comment: ""); //  596 nn:1 nl:0
                                                                                           // ( empty ); //  597 nn:0 nl:0
                                                                                           // ( empty ); //  598 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3143", -2036.584, 9.000, -1082.481, comment: "NA"); //  599 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3314", "rwb-f03-cor3314", LinkUse.legacy); //  599 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3143", -2036.585, 9.000, -1082.478, comment: ""); //  600 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3143", "rwb-f03-cor3123", LinkUse.legacy); //  601 nn:0 nl:1
                                                                                           // ( empty ); //  602 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3286", -1993.487, 9.000, -1128.204, comment: "MERTB"); //  603 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3143", "rwb-f03-cor3143", LinkUse.legacy); //  603 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3286", -1994.304, 9.000, -1125.706, comment: ""); //  604 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3286", "rwb-f03-cor3282", LinkUse.legacy); //  605 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3286", "rwb-f03-ch03-0", LinkUse.legacy); //  606 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3233", -2015.484, 9.000, -1119.408, comment: "NA"); //  607 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3286", "rwb-f03-cor3286", LinkUse.legacy); //  607 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3233", -2015.490, 9.000, -1119.391, comment: ""); //  608 nn:1 nl:0
                                                                                           // ( empty ); //  609 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3233", "rwb-f03-ch10-0", LinkUse.legacy); //  610 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3393", -2023.853, 9.000, -1118.646, comment: "NA"); //  611 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3233", "rwb-f03-cor3233", LinkUse.legacy); //  611 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3393", -2022.825, 9.000, -1121.790, comment: ""); //  612 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3393", "rwb-f03-cor3221", LinkUse.legacy); //  613 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3393", "rwb-f03-ch06-1", LinkUse.legacy); //  614 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3304", -2009.551, 9.000, -1133.707, comment: "DMOREH"); //  615 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3393", "rwb-f03-cor3393", LinkUse.legacy); //  615 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3304", -2010.442, 9.000, -1130.982, comment: ""); //  616 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3304", "rwb-f03-cor3334", LinkUse.legacy); //  617 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3304", "rwb-f03-ch05-0", LinkUse.legacy); //  618 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3313", -2019.081, 9.000, -1130.923, comment: "HALBER"); //  619 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3304", "rwb-f03-cor3304", LinkUse.legacy); //  619 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3313", -2018.229, 9.000, -1133.529, comment: ""); //  620 nn:1 nl:0
                                                                                           // ( empty ); //  621 nn:0 nl:0
                                                                                           // ( empty ); //  622 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3312", -2011.961, 9.000, -1134.533, comment: "MHOISECK"); //  623 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3313", "rwb-f03-cor3313", LinkUse.legacy); //  623 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3312", -2012.863, 9.000, -1131.774, comment: ""); //  624 nn:1 nl:0
                                                                                           // ( empty ); //  625 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3312", "rwb-f03-ch05-0", LinkUse.legacy); //  626 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3316", -2017.181, 9.000, -1136.321, comment: "CORINMAR"); //  627 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3312", "rwb-f03-cor3312", LinkUse.legacy); //  627 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3316", -2018.107, 9.000, -1133.489, comment: ""); //  628 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3316", "rwb-f03-cor3313", LinkUse.legacy); //  629 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3316", "rwb-f03-cor3314", LinkUse.legacy); //  630 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3298", -2001.519, 9.000, -1130.955, comment: "NICOLM"); //  631 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3316", "rwb-f03-cor3316", LinkUse.legacy); //  631 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3298", -2002.373, 9.000, -1128.344, comment: ""); //  632 nn:1 nl:0
                                                                                           // ( empty ); //  633 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3298", "rwb-f03-ch04-0", LinkUse.legacy); //  634 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3300", -2003.929, 9.000, -1131.781, comment: "XAVIERP"); //  635 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3298", "rwb-f03-cor3298", LinkUse.legacy); //  635 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3300", -2004.794, 9.000, -1129.136, comment: ""); //  636 nn:1 nl:0
                                                                                           // ( empty ); //  637 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3300", "rwb-f03-ch04-0", LinkUse.legacy); //  638 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3302", -2006.740, 9.000, -1132.744, comment: "MARKCROF"); //  639 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3300", "rwb-f03-cor3300", LinkUse.legacy); //  639 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3302", -2007.618, 9.000, -1130.059, comment: ""); //  640 nn:1 nl:0
                                                                                           // ( empty ); //  641 nn:0 nl:0
                                                                                           // ( empty ); //  642 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3068", -2063.180, 9.000, -1107.924, comment: "CARRIEAM"); //  643 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3302", "rwb-f03-cor3302", LinkUse.legacy); //  643 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3068", -2064.073, 9.000, -1105.256, comment: ""); //  644 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3068", "rwb-f03-cor3069", LinkUse.legacy); //  645 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3068", "rwb-f03-ch28-0", LinkUse.legacy); //  646 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3066", -2060.368, 9.000, -1106.961, comment: "MSELIN"); //  647 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3068", "rwb-f03-cor3068", LinkUse.legacy); //  647 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3066", -2061.255, 9.000, -1104.313, comment: ""); //  648 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3066", "rwb-f03-cor3064", LinkUse.legacy); //  649 nn:0 nl:1
                                                                                           // ( empty ); //  650 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3342", -2033.245, 9.000, -1141.825, comment: "LAURALON"); //  651 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3066", "rwb-f03-cor3066", LinkUse.legacy); //  651 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3342", -2034.245, 9.000, -1138.766, comment: ""); //  652 nn:1 nl:0
                                                                                           // ( empty ); //  653 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3342", "rwb-f03-ch07-0", LinkUse.legacy); //  654 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3099", -2043.316, 9.000, -1113.216, comment: "NA"); //  655 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3342", "rwb-f03-cor3342", LinkUse.legacy); //  655 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3308", -2019.432, 9.000, -1105.638, comment: "NA"); //  656 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3099", "rwb-f03-cor3374", LinkUse.legacy); //  656 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3308", -2019.479, 9.000, -1105.654, comment: ""); //  657 nn:1 nl:0
                                                                                           // ( empty ); //  658 nn:0 nl:0
                                                                                           // ( empty ); //  659 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3128", -2031.912, 9.000, -1077.855, comment: "MPEREZ"); //  660 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3308", "rwb-f03-cor3308", LinkUse.legacy); //  660 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3128", -2030.998, 9.000, -1080.651, comment: ""); //  661 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3128", "rwb-f03-cor3134", LinkUse.legacy); //  662 nn:0 nl:1
                                                                                           // ( empty ); //  663 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3354", -2041.467, 9.000, -1144.036, comment: "TERRIM"); //  664 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3128", "rwb-f03-cor3128", LinkUse.legacy); //  664 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3354", -2042.326, 9.000, -1141.408, comment: ""); //  665 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3354", "rwb-f03-cor3353", LinkUse.legacy); //  666 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3354", "rwb-f03-ch08-0", LinkUse.legacy); //  667 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3346", -2038.466, 9.000, -1143.613, comment: "MIKEMOL"); //  668 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3354", "rwb-f03-cor3354", LinkUse.legacy); //  668 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3346", -2039.490, 9.000, -1140.481, comment: ""); //  669 nn:1 nl:0
                                                                                           // ( empty ); //  670 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3346", "rwb-f03-ch08-0", LinkUse.legacy); //  671 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3344", -2036.056, 9.000, -1142.788, comment: "THDRELLE"); //  672 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3346", "rwb-f03-cor3346", LinkUse.legacy); //  672 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3344", -2037.069, 9.000, -1139.689, comment: ""); //  673 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3344", "rwb-f03-cor3346", LinkUse.legacy); //  674 nn:0 nl:1
                                                                                           // ( empty ); //  675 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3153", -2008.200, 9.000, -1080.015, comment: "MANDLAM,KSBAFNA"); //  676 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3344", "rwb-f03-cor3344", LinkUse.legacy); //  676 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3060", -2052.337, 9.000, -1104.209, comment: "TSCHMIDT"); //  677 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3153", "rwb-f03-cor3152", LinkUse.legacy); //  677 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3060", -2053.204, 9.000, -1101.618, comment: ""); //  678 nn:1 nl:0
                                                                                           // ( empty ); //  679 nn:0 nl:0
                                                                                           // ( empty ); //  680 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3362", -2044.736, 9.000, -1125.800, comment: "TSTORCH"); //  681 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3060", "rwb-f03-cor3060", LinkUse.legacy); //  681 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3362", -2043.804, 9.000, -1128.650, comment: ""); //  682 nn:1 nl:0
                                                                                           // ( empty ); //  683 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3362", "rwb-f03-ch08-1", LinkUse.legacy); //  684 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3145", -2017.562, 9.000, -1078.988, comment: "RADEOK"); //  685 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3362", "rwb-f03-cor3362", LinkUse.legacy); //  685 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3145", -2019.483, 9.000, -1079.623, comment: ""); //  686 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3145", "rwb-f03-cor3141", LinkUse.legacy); //  687 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3145", "rwb-f03-ch23-1", LinkUse.legacy); //  688 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3122", -2037.534, 9.000, -1079.782, comment: "TODDGAR"); //  689 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3145", "rwb-f03-cor3145", LinkUse.legacy); //  689 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3122", -2036.646, 9.000, -1082.498, comment: ""); //  690 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3122", "rwb-f03-cor3143", LinkUse.legacy); //  691 nn:0 nl:1
                                                                                           // ( empty ); //  692 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3237", -2000.077, 9.000, -1117.154, comment: "KRISTENQ"); //  693 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3122", "rwb-f03-cor3122", LinkUse.legacy); //  693 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3237", -1997.583, 9.000, -1116.338, comment: ""); //  694 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3237", "rwb-f03-cor3284", LinkUse.legacy); //  695 nn:0 nl:1
                                                                                           // ( empty ); //  696 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3188", -2017.610, 9.000, -1092.917, comment: "SBUCHAN"); //  697 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3237", "rwb-f03-cor3237", LinkUse.legacy); //  697 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3188", -2018.577, 9.000, -1090.028, comment: ""); //  698 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3188", "rwb-f03-ch23-0", LinkUse.legacy); //  699 nn:0 nl:1
                                                                                          // ( empty ); //  700 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3124", -2034.723, 9.000, -1078.819, comment: "DEREKMO"); //  701 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3188", "rwb-f03-cor3188", LinkUse.legacy); //  701 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3124", -2033.822, 9.000, -1081.574, comment: ""); //  702 nn:1 nl:0
                                                                                           // ( empty ); //  703 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3124", "rwb-f03-cor3123", LinkUse.legacy); //  704 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3101", -2052.164, 9.000, -1094.472, comment: "PABLOJB"); //  705 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3124", "rwb-f03-cor3124", LinkUse.legacy); //  705 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3232", -2010.009, 9.000, -1114.508, comment: "LUZJARA"); //  706 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3101", "rwb-f03-cor3103", LinkUse.legacy); //  706 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3232", -2009.096, 9.000, -1117.300, comment: ""); //  707 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3232", "rwb-f03-cor3234", LinkUse.legacy); //  708 nn:0 nl:1
                                                                                           // ( empty ); //  709 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3225", -2016.331, 9.000, -1122.118, comment: "SUSKA,PABHANDA"); //  710 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3232", "rwb-f03-cor3232", LinkUse.legacy); //  710 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3225", -2017.055, 9.000, -1119.903, comment: ""); //  711 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3225", "rwb-f03-cor3233", LinkUse.legacy); //  712 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3225", "rwb-f03-cor3223", LinkUse.legacy); //  713 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3231", -2008.109, 9.000, -1119.906, comment: "EVANW,BIBARF"); //  714 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3225", "rwb-f03-cor3225", LinkUse.legacy); //  714 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3231", -2005.615, 9.000, -1119.090, comment: ""); //  715 nn:1 nl:0
                                                                                           // ( empty ); //  716 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3231", "rwb-f03-ch04-1", LinkUse.legacy); //  717 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3247", -1987.628, 9.000, -1112.889, comment: "JANC"); //  718 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3231", "rwb-f03-cor3231", LinkUse.legacy); //  718 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3247", -1989.963, 9.000, -1113.652, comment: ""); //  719 nn:1 nl:0
                                                                                           // ( empty ); //  720 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3247", "rwb-f03-ch02-1", LinkUse.legacy); //  721 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3218", -2014.172, 9.000, -1112.910, comment: "ALICEC"); //  722 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3247", "rwb-f03-cor3247", LinkUse.legacy); //  722 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3218", -2016.792, 9.000, -1113.777, comment: ""); //  723 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3218", "rwb-f03-cor3215", LinkUse.legacy); //  724 nn:0 nl:1
                                                                                           // ( empty ); //  725 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3204", -2019.872, 9.000, -1096.716, comment: "JASONLEE"); //  726 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3218", "rwb-f03-cor3218", LinkUse.legacy); //  726 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3204", -2022.184, 9.000, -1097.481, comment: ""); //  727 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3204", "rwb-f03-cor3205", LinkUse.legacy); //  728 nn:0 nl:1
                                                                                           // ( empty ); //  729 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3297", -2006.969, 9.000, -1123.144, comment: "ROBESM"); //  730 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3204", "rwb-f03-cor3204", LinkUse.legacy); //  730 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3309", -2015.001, 9.000, -1125.896, comment: "AKANGAW,PGURU"); //  731 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3297", "rwb-f03-cor3296", LinkUse.legacy); //  731 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3285", -1998.937, 9.000, -1120.393, comment: "DOHAMI"); //  732 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3309", "rwb-f03-cor3306", LinkUse.legacy); //  732 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3206", -2018.922, 9.000, -1099.415, comment: "GREGGPI"); //  733 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3285", "rwb-f03-cor3284", LinkUse.legacy); //  733 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3206", -2021.285, 9.000, -1100.197, comment: ""); //  734 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3206", "rwb-f03-cor3207", LinkUse.legacy); //  735 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3206", "rwb-f03-cor3205", LinkUse.legacy); //  736 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3208", -2017.972, 9.000, -1102.114, comment: "CSLOTTA"); //  737 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3206", "rwb-f03-cor3206", LinkUse.legacy); //  737 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3208", -2020.387, 9.000, -1102.913, comment: ""); //  738 nn:1 nl:0
                                                                                           // ( empty ); //  739 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3208", "rwb-f03-cor3207", LinkUse.legacy); //  740 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3210", -2017.022, 9.000, -1104.813, comment: "SPYROS"); //  741 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3208", "rwb-f03-cor3208", LinkUse.legacy); //  741 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3273", -1986.298, 9.000, -1116.667, comment: "NA"); //  742 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3210", "rwb-f03-cor3308", LinkUse.legacy); //  742 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3273", -1988.718, 9.000, -1117.459, comment: ""); //  743 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3273", "rwb-f03-cor3274", LinkUse.legacy); //  744 nn:0 nl:1
                                                                                           // ( empty ); //  745 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3271", -1985.158, 9.000, -1119.906, comment: "BSMIT"); //  746 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3273", "rwb-f03-cor3273", LinkUse.legacy); //  746 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3271", -1987.651, 9.000, -1120.722, comment: ""); //  747 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3271", "rwb-f03-cor3273", LinkUse.legacy); //  748 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3271", "rwb-f03-ch02-0", LinkUse.legacy); //  749 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3212", -2016.072, 9.000, -1107.512, comment: "ALIHOB"); //  750 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3271", "rwb-f03-cor3271", LinkUse.legacy); //  750 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3212", -2018.589, 9.000, -1108.345, comment: ""); //  751 nn:1 nl:0
                                                                                           // ( empty ); //  752 nn:0 nl:0
                                                                                           // ( empty ); //  753 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3216", -2015.122, 9.000, -1110.211, comment: "PUVITH"); //  754 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3212", "rwb-f03-cor3212", LinkUse.legacy); //  754 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3216", -2017.691, 9.000, -1111.061, comment: ""); //  755 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3216", "rwb-f03-cor3212", LinkUse.legacy); //  756 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3216", "rwb-f03-cor3401", LinkUse.legacy); //  757 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3182", -2009.578, 9.000, -1090.165, comment: "JMEIER"); //  758 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3216", "rwb-f03-cor3216", LinkUse.legacy); //  758 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3182", -2010.526, 9.000, -1087.333, comment: ""); //  759 nn:1 nl:0
                                                                                           // ( empty ); //  760 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3182", "rwb-f03-ch22-0", LinkUse.legacy); //  761 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3280", -1987.675, 9.000, -1126.817, comment: "SHINOY"); //  762 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3182", "rwb-f03-cor3182", LinkUse.legacy); //  762 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3280", -1988.644, 9.000, -1123.855, comment: ""); //  763 nn:1 nl:0
                                                                                           // ( empty ); //  764 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3280", "rwb-f03-ch02-0", LinkUse.legacy); //  765 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3287", -1997.607, 9.000, -1124.171, comment: "SPATHANI"); //  766 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3280", "rwb-f03-cor3280", LinkUse.legacy); //  766 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3287", -1995.272, 9.000, -1123.408, comment: ""); //  767 nn:1 nl:0
                                                                                           // ( empty ); //  768 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3287", "rwb-f03-ch03-0", LinkUse.legacy); //  769 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3301", -2005.639, 9.000, -1126.923, comment: "RODOLPHD"); //  770 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3287", "rwb-f03-cor3287", LinkUse.legacy); //  770 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3301", -2004.903, 9.000, -1129.172, comment: ""); //  771 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3301", "rwb-f03-cor3302", LinkUse.legacy); //  772 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3301", "rwb-f03-cor3300", LinkUse.legacy); //  773 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3311", -2013.671, 9.000, -1129.675, comment: "TACRIS,BRITTB"); //  774 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3301", "rwb-f03-cor3301", LinkUse.legacy); //  774 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3311", -2012.972, 9.000, -1131.810, comment: ""); //  775 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3311", "rwb-f03-cor3312", LinkUse.legacy); //  776 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3311", "rwb-f03-cor3314", LinkUse.legacy); //  777 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3293", -2001.580, 9.000, -1123.113, comment: "NICONS,JANEENS"); //  778 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3311", "rwb-f03-cor3311", LinkUse.legacy); //  778 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3293", -2004.037, 9.000, -1123.916, comment: ""); //  779 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3293", "rwb-f03-cor3296", LinkUse.legacy); //  780 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3293", "rwb-f03-ch04-0", LinkUse.legacy); //  781 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3121", -2038.445, 9.000, -1086.143, comment: "ISABELF"); //  782 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3293", "rwb-f03-cor3293", LinkUse.legacy); //  782 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3121", -2040.377, 9.000, -1086.782, comment: ""); //  783 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3121", "rwb-f03-cor3112", LinkUse.legacy); //  784 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3121", "rwb-f03-ch25-1", LinkUse.legacy); //  785 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3235", -2003.480, 9.000, -1117.715, comment: "LANIO"); //  786 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3121", "rwb-f03-cor3121", LinkUse.legacy); //  786 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3235", -2004.145, 9.000, -1115.681, comment: ""); //  787 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3235", "rwb-f03-cor3236", LinkUse.legacy); //  788 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3235", "rwb-f03-ch04-1", LinkUse.legacy); //  789 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3245", -1992.637, 9.000, -1114.000, comment: "AHANSON"); //  790 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3235", "rwb-f03-cor3235", LinkUse.legacy); //  790 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3245", -1993.252, 9.000, -1112.120, comment: ""); //  791 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3245", "rwb-f03-cor3242", LinkUse.legacy); //  792 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3245", "rwb-f03-cor3244", LinkUse.legacy); //  793 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3291", -2000.630, 9.000, -1125.812, comment: "RSHARPL"); //  794 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3245", "rwb-f03-cor3245", LinkUse.legacy); //  794 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3291", -2000.050, 9.000, -1127.584, comment: ""); //  795 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3291", "rwb-f03-cor3298", LinkUse.legacy); //  796 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3291", "rwb-f03-cor3290", LinkUse.legacy); //  797 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3227", -2011.512, 9.000, -1120.467, comment: "MLALL"); //  798 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3291", "rwb-f03-cor3291", LinkUse.legacy); //  798 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3227", -2012.214, 9.000, -1118.320, comment: ""); //  799 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3227", "rwb-f03-cor3232", LinkUse.legacy); //  800 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3227", "rwb-f03-ch05-1", LinkUse.legacy); //  801 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3307", -2010.562, 9.000, -1123.166, comment: "PKHODAK,JELIPE"); //  802 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3227", "rwb-f03-cor3227", LinkUse.legacy); //  802 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3307", -2012.958, 9.000, -1123.949, comment: ""); //  803 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3307", "rwb-f03-cor3306", LinkUse.legacy); //  804 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3307", "rwb-f03-ch05-1", LinkUse.legacy); //  805 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3281", -1993.189, 9.000, -1122.658, comment: "SUSANJA"); //  806 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3307", "rwb-f03-cor3307", LinkUse.legacy); //  806 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3281", -1995.292, 9.000, -1123.345, comment: ""); //  807 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3281", "rwb-f03-cor3287", LinkUse.legacy); //  808 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3281", "rwb-f03-cor3284", LinkUse.legacy); //  809 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3305", -2009.612, 9.000, -1125.864, comment: "VAIBHAVA,JOEMRICK"); //  810 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3281", "rwb-f03-cor3281", LinkUse.legacy); //  810 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3305", -2012.069, 9.000, -1126.668, comment: ""); //  811 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3305", "rwb-f03-cor3306", LinkUse.legacy); //  812 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3305", "rwb-f03-ch05-0", LinkUse.legacy); //  813 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3295", -2002.530, 9.000, -1120.414, comment: "STFRANK,JONSAMP"); //  814 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3305", "rwb-f03-cor3305", LinkUse.legacy); //  814 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3295", -2004.926, 9.000, -1121.197, comment: ""); //  815 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3295", "rwb-f03-cor3231", LinkUse.legacy); //  816 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3295", "rwb-f03-cor3296", LinkUse.legacy); //  817 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3197", -2030.353, 9.000, -1091.234, comment: "DDECATUR"); //  818 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3295", "rwb-f03-cor3295", LinkUse.legacy); //  818 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3197", -2029.529, 9.000, -1093.694, comment: ""); //  819 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3197", "rwb-f03-cor3039", LinkUse.legacy); //  820 nn:0 nl:1
                                                                                           // ( empty ); //  821 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3201", -2035.975, 9.000, -1093.160, comment: "ALEXISC"); //  822 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3197", "rwb-f03-cor3197", LinkUse.legacy); //  822 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3201", -2038.040, 9.000, -1093.843, comment: ""); //  823 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3201", "rwb-f03-cor3115", LinkUse.legacy); //  824 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3201", "rwb-f03-ch25-0", LinkUse.legacy); //  825 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3181", -2011.689, 9.000, -1085.444, comment: "CHBARRET,ANDYEUN"); //  826 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3201", "rwb-f03-cor3201", LinkUse.legacy); //  826 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3181", -2011.004, 9.000, -1087.493, comment: ""); //  827 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3181", "rwb-f03-cor3182", LinkUse.legacy); //  828 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3181", "rwb-f03-cor3184", LinkUse.legacy); //  829 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3195", -2027.542, 9.000, -1090.271, comment: "ROBSIMP,BEROMO"); //  830 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3181", "rwb-f03-cor3181", LinkUse.legacy); //  830 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3195", -2025.165, 9.000, -1089.485, comment: ""); //  831 nn:1 nl:0
                                                                                           // ( empty ); //  832 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3195", "rwb-f03-ch24-0", LinkUse.legacy); //  833 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3059", -2054.047, 9.000, -1099.351, comment: "DASCHWIE"); //  834 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3195", "rwb-f03-cor3195", LinkUse.legacy); //  834 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3059", -2053.279, 9.000, -1101.644, comment: ""); //  835 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3059", "rwb-f03-cor3060", LinkUse.legacy); //  836 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3059", "rwb-f03-ch27-0", LinkUse.legacy); //  837 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3183", -2015.092, 9.000, -1086.005, comment: "VINELAP"); //  838 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3059", "rwb-f03-cor3059", LinkUse.legacy); //  838 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3183", -2017.148, 9.000, -1086.685, comment: ""); //  839 nn:1 nl:0
                                                                                           // ( empty ); //  840 nn:0 nl:0
                                                                                           // ( empty ); //  841 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3131", -2023.483, 9.000, -1086.460, comment: "FCORTES"); //  842 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3183", "rwb-f03-cor3183", LinkUse.legacy); //  842 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3131", -2025.900, 9.000, -1087.260, comment: ""); //  843 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3131", "rwb-f03-cor3195", LinkUse.legacy); //  844 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3131", "rwb-f03-cor3129", LinkUse.legacy); //  845 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3133", -2024.433, 9.000, -1083.761, comment: "PABERNAL"); //  846 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3131", "rwb-f03-cor3131", LinkUse.legacy); //  846 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3133", -2026.798, 9.000, -1084.544, comment: ""); //  847 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3133", "rwb-f03-cor3129", LinkUse.legacy); //  848 nn:0 nl:1
                                                                                           // ( empty ); //  849 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3135", -2025.383, 9.000, -1081.063, comment: "DILIPSIN"); //  850 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3133", "rwb-f03-cor3133", LinkUse.legacy); //  850 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3135", -2026.046, 9.000, -1079.033, comment: ""); //  851 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3135", "rwb-f03-cor3136", LinkUse.legacy); //  852 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3135", "rwb-f03-ch24-1", LinkUse.legacy); //  853 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3243", -1995.660, 9.000, -1115.641, comment: "KEROSH"); //  854 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3135", "rwb-f03-cor3135", LinkUse.legacy); //  854 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3243", -1997.604, 9.000, -1116.276, comment: ""); //  855 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3243", "rwb-f03-cor3237", LinkUse.legacy); //  856 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3243", "rwb-f03-ch03-1", LinkUse.legacy); //  857 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3367", -2040.215, 9.000, -1129.695, comment: "FRANKP"); //  858 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3243", "rwb-f03-cor3243", LinkUse.legacy); //  858 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3367", -2040.870, 9.000, -1127.690, comment: ""); //  859 nn:1 nl:0
                                                                                           // ( empty ); //  860 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3367", "rwb-f03-ch12-0", LinkUse.legacy); //  861 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3051", -2046.417, 9.000, -1096.737, comment: "YVISHWA"); //  862 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3367", "rwb-f03-cor3367", LinkUse.legacy); //  862 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3051", -2048.482, 9.000, -1097.420, comment: ""); //  863 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3051", "rwb-f03-cor3103", LinkUse.legacy); //  864 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3051", "rwb-f03-ch26-0", LinkUse.legacy); //  865 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3191", -2022.532, 9.000, -1089.159, comment: "JOLLYK,BREULAND"); //  866 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3051", "rwb-f03-cor3051", LinkUse.legacy); //  866 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3191", -2021.873, 9.000, -1091.131, comment: ""); //  867 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3191", "rwb-f03-cor3188", LinkUse.legacy); //  868 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3191", "rwb-f03-ch10-1", LinkUse.legacy); //  869 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3190", -2020.650, 9.000, -1084.280, comment: "JOMANNIN,ILOSTFEL"); //  870 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3191", "rwb-f03-cor3191", LinkUse.legacy); //  870 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3190", -2018.210, 9.000, -1083.473, comment: ""); //  871 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3190", "rwb-f03-cor3183", LinkUse.legacy); //  872 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3190", "rwb-f03-cor3185", LinkUse.legacy); //  873 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3125", -2032.823, 9.000, -1084.216, comment: "CALVIND"); //  874 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3190", "rwb-f03-cor3190", LinkUse.legacy); //  874 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3125", -2033.700, 9.000, -1081.534, comment: ""); //  875 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3125", "rwb-f03-cor3124", LinkUse.legacy); //  876 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3125", "rwb-f03-cor3128", LinkUse.legacy); //  877 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3187", -2019.510, 9.000, -1087.519, comment: "JAYANG"); //  878 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3125", "rwb-f03-cor3125", LinkUse.legacy); //  878 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3187", -2017.133, 9.000, -1086.733, comment: ""); //  879 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3187", "rwb-f03-cor3183", LinkUse.legacy); //  880 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3187", "rwb-f03-ch23-0", LinkUse.legacy); //  881 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3127", -2030.012, 9.000, -1083.253, comment: "ALESCURE"); //  882 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3187", "rwb-f03-cor3187", LinkUse.legacy); //  882 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3127", -2027.499, 9.000, -1082.423, comment: ""); //  883 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3127", "rwb-f03-cor3133", LinkUse.legacy); //  884 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3127", "rwb-f03-ch24-1", LinkUse.legacy); //  885 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3163", -2004.608, 9.000, -1079.994, comment: "ALISONLU"); //  886 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3127", "rwb-f03-cor3127", LinkUse.legacy); //  886 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3163", -2002.189, 9.000, -1079.194, comment: ""); //  887 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3163", "rwb-f03-cor3166", LinkUse.legacy); //  888 nn:0 nl:1
                                                                                           // ( empty ); //  889 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3161", -2005.368, 9.000, -1077.835, comment: "GARRETTD,PASEHG"); //  890 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3163", "rwb-f03-cor3163", LinkUse.legacy); //  890 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3161", -2002.908, 9.000, -1077.021, comment: ""); //  891 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3161", "rwb-f03-cor3167", LinkUse.legacy); //  892 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3161", "rwb-f03-cor3166", LinkUse.legacy); //  893 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3175", -2003.658, 9.000, -1082.693, comment: "MARKBES"); //  894 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3161", "rwb-f03-cor3161", LinkUse.legacy); //  894 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3175", -2002.953, 9.000, -1084.798, comment: ""); //  895 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3175", "rwb-f03-cor3176", LinkUse.legacy); //  896 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3175", "rwb-f03-cor3178", LinkUse.legacy); //  897 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3363", -2043.238, 9.000, -1131.336, comment: "UFUKT"); //  898 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3175", "rwb-f03-cor3175", LinkUse.legacy); //  898 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3363", -2045.182, 9.000, -1131.972, comment: ""); //  899 nn:1 nl:0
                                                                                           // ( empty ); //  900 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3363", "rwb-f03-ch08-1", LinkUse.legacy); //  901 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3256", -1974.422, 9.000, -1122.277, comment: "RIMESM"); //  902 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3363", "rwb-f03-cor3363", LinkUse.legacy); //  902 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3256", -1975.330, 9.000, -1119.501, comment: ""); //  903 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3256", "rwb-f03-cor3257", LinkUse.legacy); //  904 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3256", "rwb-f03-cv0-s", LinkUse.legacy); //  905 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3072", -2072.071, 9.000, -1091.614, comment: "SCOTTCLA"); //  906 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3256", "rwb-f03-cor3256", LinkUse.legacy); //  906 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3072", -2071.343, 9.000, -1093.840, comment: ""); //  907 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3072", "rwb-f03-cor3073", LinkUse.legacy); //  908 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3072", "rwb-f03-ch29-1", LinkUse.legacy); //  909 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3279", -1989.787, 9.000, -1122.097, comment: "BRENTSIN"); //  910 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3072", "rwb-f03-cor3072", LinkUse.legacy); //  910 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3279", -1989.157, 9.000, -1124.023, comment: ""); //  911 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3279", "rwb-f03-cor3280", LinkUse.legacy); //  912 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3279", "rwb-f03-cor3282", LinkUse.legacy); //  913 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3172", -1996.325, 9.000, -1085.625, comment: "FRANKPET"); //  914 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3279", "rwb-f03-cor3279", LinkUse.legacy); //  914 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3172", -1997.242, 9.000, -1082.886, comment: ""); //  915 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3172", "rwb-f03-cor3173", LinkUse.legacy); //  916 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3172", "rwb-f03-ch20-0", LinkUse.legacy); //  917 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3070", -2065.991, 9.000, -1108.887, comment: "ACORLEY"); //  918 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3172", "rwb-f03-cor3172", LinkUse.legacy); //  918 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3070", -2066.890, 9.000, -1106.200, comment: ""); //  919 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3070", "rwb-f03-cor3069", LinkUse.legacy); //  920 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3070", "rwb-f03-cv2-e", LinkUse.legacy); //  921 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3055", -2050.834, 9.000, -1098.250, comment: "YAMAGDI,MAKASIEW"); //  922 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3070", "rwb-f03-cor3070", LinkUse.legacy); //  922 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3055", -2050.059, 9.000, -1100.566, comment: ""); //  923 nn:1 nl:0
                                                                                           // ( empty ); //  924 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3055", "rwb-f03-ch26-0", LinkUse.legacy); //  925 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3219", -2024.764, 9.000, -1125.007, comment: "YELENAK"); //  926 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3055", "rwb-f03-cor3055", LinkUse.legacy); //  926 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3219", -2026.696, 9.000, -1125.639, comment: ""); //  927 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3219", "rwb-f03-cor3327", LinkUse.legacy); //  928 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3219", "rwb-f03-ch06-1", LinkUse.legacy); //  929 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3275", -1991.687, 9.000, -1116.699, comment: "JOCLARKE"); //  930 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3219", "rwb-f03-cor3219", LinkUse.legacy); //  930 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3275", -1989.230, 9.000, -1115.896, comment: ""); //  931 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3275", "rwb-f03-cor3247", LinkUse.legacy); //  932 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3275", "rwb-f03-cor3274", LinkUse.legacy); //  933 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3380", -2048.385, 9.000, -1106.485, comment: "LIZD"); //  934 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3275", "rwb-f03-cor3275", LinkUse.legacy); //  934 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3380", -2045.467, 9.000, -1105.520, comment: ""); //  935 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3380", "rwb-f03-cor3378", LinkUse.legacy); //  936 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3380", "rwb-f03-cor3381", LinkUse.legacy); //  937 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3170", -2002.406, 9.000, -1068.352, comment: "RSIVA"); //  938 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3380", "rwb-f03-cor3380", LinkUse.legacy); //  938 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3170", -2001.533, 9.000, -1071.019, comment: ""); //  939 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3170", "rwb-f03-cor3169", LinkUse.legacy); //  940 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3170", "rwb-f03-cv3-s", LinkUse.legacy); //  941 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3368", -2042.875, 9.000, -1122.138, comment: "MARCOAL"); //  942 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3170", "rwb-f03-cor3170", LinkUse.legacy); //  942 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3368", -2040.256, 9.000, -1121.272, comment: ""); //  943 nn:1 nl:0
                                                                                           // ( empty ); //  944 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3368", "rwb-f03-ch12-0", LinkUse.legacy); //  945 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3356", -2044.278, 9.000, -1145.000, comment: "JJESTER"); //  946 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3368", "rwb-f03-cor3368", LinkUse.legacy); //  946 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3356", -2045.150, 9.000, -1142.332, comment: ""); //  947 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3356", "rwb-f03-cor3353", LinkUse.legacy); //  948 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3356", "rwb-f03-cv0-e", LinkUse.legacy); //  949 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3095", -2056.707, 9.000, -1091.794, comment: "MIRST"); //  950 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3356", "rwb-f03-cor3356", LinkUse.legacy); //  950 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3095", -2059.031, 9.000, -1092.563, comment: ""); //  951 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3095", "rwb-f03-cor3087", LinkUse.legacy); //  952 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3095", "rwb-f03-ch27-1", LinkUse.legacy); //  953 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3104", -2050.787, 9.000, -1084.322, comment: "RDIXIT"); //  954 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3095", "rwb-f03-cor3095", LinkUse.legacy); //  954 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3104", -2049.960, 9.000, -1086.850, comment: ""); //  955 nn:1 nl:0
                                                                                           // ( empty ); //  956 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3104", "rwb-f03-ch26-1", LinkUse.legacy); //  957 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3343", -2037.365, 9.000, -1137.792, comment: "GVERSTER"); //  958 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3104", "rwb-f03-cor3104", LinkUse.legacy); //  958 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3343", -2036.776, 9.000, -1139.593, comment: ""); //  959 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3343", "rwb-f03-cor3344", LinkUse.legacy); //  960 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3343", "rwb-f03-cor3342", LinkUse.legacy); //  961 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3147", -2014.540, 9.000, -1077.348, comment: "GREGVAR"); //  962 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3343", "rwb-f03-cor3343", LinkUse.legacy); //  962 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3147", -2015.153, 9.000, -1075.471, comment: ""); //  963 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3147", "rwb-f03-cor3144", LinkUse.legacy); //  964 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3147", "rwb-f03-cor3146", LinkUse.legacy); //  965 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3091", -2054.807, 9.000, -1097.192, comment: "NA"); //  966 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3147", "rwb-f03-cor3147", LinkUse.legacy); //  966 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3091", -2057.234, 9.000, -1097.995, comment: ""); //  967 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3091", "rwb-f03-cor3089", LinkUse.legacy); //  968 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3091", "rwb-f03-cor3063", LinkUse.legacy); //  969 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3339", -2039.265, 9.000, -1132.394, comment: "LISATHOM"); //  970 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3091", "rwb-f03-cor3091", LinkUse.legacy); //  970 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3339", -2036.404, 9.000, -1131.459, comment: ""); //  971 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3339", "rwb-f03-cor3337", LinkUse.legacy); //  972 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3339", "rwb-f03-cor3385", LinkUse.legacy); //  973 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3151", -2012.640, 9.000, -1082.745, comment: "JIMSMI"); //  974 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3339", "rwb-f03-cor3339", LinkUse.legacy); //  974 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3151", -2010.221, 9.000, -1081.946, comment: ""); //  975 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3151", "rwb-f03-cor3152", LinkUse.legacy); //  976 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3151", "rwb-f03-cor3179", LinkUse.legacy); //  977 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3283", -1994.520, 9.000, -1118.879, comment: "VINGU"); //  978 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3151", "rwb-f03-cor3151", LinkUse.legacy); //  978 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3336", -2030.835, 9.000, -1140.999, comment: "SIMONBOO"); //  979 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3283", "rwb-f03-cor3284", LinkUse.legacy); //  979 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3336", -2031.824, 9.000, -1137.974, comment: ""); //  980 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3336", "rwb-f03-ch07-0", LinkUse.legacy); //  981 nn:0 nl:1
                                                                                          // ( empty ); //  982 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3318", -2019.992, 9.000, -1137.284, comment: "MAZENS"); //  983 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3336", "rwb-f03-cor3336", LinkUse.legacy); //  983 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3318", -2020.932, 9.000, -1134.412, comment: ""); //  984 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3318", "rwb-f03-cor3313", LinkUse.legacy); //  985 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3318", "rwb-f03-ch06-0", LinkUse.legacy); //  986 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3120", -2039.944, 9.000, -1080.607, comment: "STHENRY,CAROU"); //  987 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3318", "rwb-f03-cor3318", LinkUse.legacy); //  987 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3120", -2039.067, 9.000, -1083.289, comment: ""); //  988 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3120", "rwb-f03-cor3122", LinkUse.legacy); //  989 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3120", "rwb-f03-ch25-1", LinkUse.legacy); //  990 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3358", -2050.358, 9.000, -1127.727, comment: "TGERBER"); //  991 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3120", "rwb-f03-cor3120", LinkUse.legacy); //  991 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3358", -2049.453, 9.000, -1130.496, comment: ""); //  992 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3358", "rwb-f03-cor3359", LinkUse.legacy); //  993 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3358", "rwb-f03-ch09-1", LinkUse.legacy); //  994 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3303", -2008.852, 9.000, -1128.024, comment: "SKOSTED"); //  995 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3358", "rwb-f03-cor3358", LinkUse.legacy); //  995 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3303", -2008.131, 9.000, -1130.227, comment: ""); //  996 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3303", "rwb-f03-cor3302", LinkUse.legacy); //  997 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3303", "rwb-f03-cor3334", LinkUse.legacy); //  998 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3379", -2042.215, 9.000, -1107.395, comment: "GRARCHIB,KABABBAR"); //  999 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3303", "rwb-f03-cor3303", LinkUse.legacy); //  999 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3379", -2044.587, 9.000, -1108.180, comment: ""); //  1000 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3379", "rwb-f03-cor3378", LinkUse.legacy); //  1001 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3379", "rwb-f03-cor3376", LinkUse.legacy); //  1002 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3369", -2037.654, 9.000, -1120.350, comment: "JESAM"); //  1003 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3379", "rwb-f03-cor3379", LinkUse.legacy); //  1003 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3369", -2040.275, 9.000, -1121.217, comment: ""); //  1004 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3369", "rwb-f03-cor3368", LinkUse.legacy); //  1005 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3369", "rwb-f03-cor3370", LinkUse.legacy); //  1006 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3373", -2039.554, 9.000, -1114.952, comment: "MARVINQ,DASCHMID"); //  1007 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3369", "rwb-f03-cor3369", LinkUse.legacy); //  1007 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3373", -2042.072, 9.000, -1115.785, comment: ""); //  1008 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3373", "rwb-f03-cor3372", LinkUse.legacy); //  1009 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3373", "rwb-f03-cor3374", LinkUse.legacy); //  1010 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3083", -2064.739, 9.000, -1094.546, comment: "DMANI"); //  1011 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3373", "rwb-f03-cor3373", LinkUse.legacy); //  1011 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3083", -2067.062, 9.000, -1095.314, comment: ""); //  1012 nn:1 nl:0
                                                                                           // ( empty ); //  1013 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3083", "rwb-f03-ch28-1", LinkUse.legacy); //  1014 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3107", -2046.075, 9.000, -1088.757, comment: "SANAIR"); //  1015 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3083", "rwb-f03-cor3083", LinkUse.legacy); //  1015 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3107", -2047.014, 9.000, -1085.887, comment: ""); //  1016 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3107", "rwb-f03-cor3104", LinkUse.legacy); //  1017 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3107", "rwb-f03-cor3108", LinkUse.legacy); //  1018 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3213", -2019.941, 9.000, -1111.862, comment: "WAELA"); //  1019 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3107", "rwb-f03-cor3107", LinkUse.legacy); //  1019 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3077", -2067.848, 9.000, -1101.055, comment: "NA"); //  1020 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3213", "rwb-f03-cor3401", LinkUse.legacy); //  1020 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3077", -2065.428, 9.000, -1100.255, comment: ""); //  1021 nn:1 nl:0
                                                                                           // ( empty ); //  1022 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3077", "rwb-f03-ch28-0", LinkUse.legacy); //  1023 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3211", -2020.870, 9.000, -1107.946, comment: "GUANGW"); //  1024 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3077", "rwb-f03-cor3077", LinkUse.legacy); //  1024 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3211", -2018.933, 9.000, -1107.305, comment: ""); //  1025 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3211", "rwb-f03-cor3212", LinkUse.legacy); //  1026 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3211", "rwb-f03-cor3308", LinkUse.legacy); //  1027 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3209", -2022.200, 9.000, -1104.167, comment: "MANIR"); //  1028 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3211", "rwb-f03-cor3211", LinkUse.legacy); //  1028 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3209", -2020.191, 9.000, -1103.503, comment: ""); //  1029 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3209", "rwb-f03-cor3208", LinkUse.legacy); //  1030 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3209", "rwb-f03-cor3308", LinkUse.legacy); //  1031 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3331", -2027.113, 9.000, -1133.675, comment: "TINALANG"); //  1032 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3209", "rwb-f03-cor3209", LinkUse.legacy); //  1032 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3331", -2026.298, 9.000, -1136.167, comment: ""); //  1033 nn:1 nl:0
                                                                                           // ( empty ); //  1034 nn:0 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3331", "rwb-f03-ch06-0", LinkUse.legacy); //  1035 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3109", -2043.264, 9.000, -1087.794, comment: "JIMEPES"); //  1036 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3331", "rwb-f03-cor3331", LinkUse.legacy); //  1036 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3109", -2044.189, 9.000, -1084.964, comment: ""); //  1037 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3109", "rwb-f03-cor3108", LinkUse.legacy); //  1038 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3109", "rwb-f03-ch25-1", LinkUse.legacy); //  1039 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3349", -2046.895, 9.000, -1135.008, comment: "SAMESHS"); //  1040 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3109", "rwb-f03-cor3109", LinkUse.legacy); //  1040 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3349", -2044.450, 9.000, -1134.209, comment: ""); //  1041 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3349", "rwb-f03-cor3363", LinkUse.legacy); //  1042 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3349", "rwb-f03-cor3348", LinkUse.legacy); //  1043 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3333", -2029.924, 9.000, -1134.638, comment: "STLEIGH"); //  1044 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3349", "rwb-f03-cor3349", LinkUse.legacy); //  1044 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3333", -2029.122, 9.000, -1137.091, comment: ""); //  1045 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3333", "rwb-f03-cor3331", LinkUse.legacy); //  1046 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3333", "rwb-f03-cor3336", LinkUse.legacy); //  1047 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3165", -1999.599, 9.000, -1078.883, comment: "WIRIVERA,BMJ"); //  1048 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3333", "rwb-f03-cor3333", LinkUse.legacy); //  1048 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3165", -2002.026, 9.000, -1079.686, comment: ""); //  1049 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3165", "rwb-f03-cor3163", LinkUse.legacy); //  1050 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3165", "rwb-f03-ch21-0", LinkUse.legacy); //  1051 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3347", -2042.098, 9.000, -1134.574, comment: "FLORENTR"); //  1052 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3165", "rwb-f03-cor3165", LinkUse.legacy); //  1052 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3263", -1983.655, 9.000, -1113.947, comment: "RACHELHA"); //  1053 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3347", "rwb-f03-cor3348", LinkUse.legacy); //  1053 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3263", -1981.198, 9.000, -1113.144, comment: ""); //  1054 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3263", "rwb-f03-cor3264", LinkUse.legacy); //  1055 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3263", "rwb-f03-cor3261", LinkUse.legacy); //  1056 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3056", -2049.525, 9.000, -1103.246, comment: "PABA,VIRAN"); //  1057 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3263", "rwb-f03-cor3263", LinkUse.legacy); //  1057 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3056", -2050.386, 9.000, -1100.675, comment: ""); //  1058 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3056", "rwb-f03-cor3055", LinkUse.legacy); //  1059 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3056", "rwb-f03-cor3060", LinkUse.legacy); //  1060 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3265", -1982.705, 9.000, -1116.646, comment: "NA"); //  1061 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3056", "rwb-f03-cor3056", LinkUse.legacy); //  1061 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3265", -1980.309, 9.000, -1115.863, comment: ""); //  1062 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3265", "rwb-f03-cor3259", LinkUse.legacy); //  1063 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3265", "rwb-f03-ch01-0", LinkUse.legacy); //  1064 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3383", -2036.514, 9.000, -1123.589, comment: "PRITHAB,TMCCANTS"); //  1065 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3265", "rwb-f03-cor3265", LinkUse.legacy); //  1065 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3383", -2035.723, 9.000, -1126.007, comment: ""); //  1066 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3383", "rwb-f03-cor3389", LinkUse.legacy); //  1067 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3383", "rwb-f03-ch07-1", LinkUse.legacy); //  1068 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3251", -1984.605, 9.000, -1111.248, comment: "SAMFO"); //  1069 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3383", "rwb-f03-cor3383", LinkUse.legacy); //  1069 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3251", -1985.183, 9.000, -1109.481, comment: ""); //  1070 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3251", "rwb-f03-cor3252", LinkUse.legacy); //  1071 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3251", "rwb-f03-ch01-1", LinkUse.legacy); //  1072 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3067", -2062.079, 9.000, -1102.103, comment: "NDEREUCK"); //  1073 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3251", "rwb-f03-cor3251", LinkUse.legacy); //  1073 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3067", -2061.330, 9.000, -1104.339, comment: ""); //  1074 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3067", "rwb-f03-cor3066", LinkUse.legacy); //  1075 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3067", "rwb-f03-ch28-0", LinkUse.legacy); //  1076 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3189", -2021.012, 9.000, -1093.478, comment: "DINAG"); //  1077 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3067", "rwb-f03-cor3067", LinkUse.legacy); //  1077 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3189", -2023.262, 9.000, -1094.222, comment: ""); //  1078 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3189", "rwb-f03-cor3204", LinkUse.legacy); //  1079 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3189", "rwb-f03-ch10-1", LinkUse.legacy); //  1080 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3365", -2041.735, 9.000, -1125.377, comment: "GEETUM,JABELL"); //  1081 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3189", "rwb-f03-cor3189", LinkUse.legacy); //  1081 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3365", -2040.968, 9.000, -1127.722, comment: ""); //  1082 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3365", "rwb-f03-cor3367", LinkUse.legacy); //  1083 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3365", "rwb-f03-cor3362", LinkUse.legacy); //  1084 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3081", -2063.979, 9.000, -1096.705, comment: "GERMYONG,JAPAG"); //  1085 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3365", "rwb-f03-cor3365", LinkUse.legacy); //  1085 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3081", -2066.344, 9.000, -1097.487, comment: ""); //  1086 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3081", "rwb-f03-cor3083", LinkUse.legacy); //  1087 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3081", "rwb-f03-cor3075", LinkUse.legacy); //  1088 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3395", -2033.258, 9.000, -1120.053, comment: "NA"); //  1089 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3081", "rwb-f03-cor3081", LinkUse.legacy); //  1089 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3395", -2029.440, 9.000, -1118.790, comment: ""); //  1090 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3395", "rwb-f03-cor3399", LinkUse.legacy); //  1091 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3395", "rwb-f03-cor3391", LinkUse.legacy); //  1092 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3079", -2063.029, 9.000, -1099.404, comment: "YVETTEW"); //  1093 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3395", "rwb-f03-cor3395", LinkUse.legacy); //  1093 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3079", -2065.446, 9.000, -1100.203, comment: ""); //  1094 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3079", "rwb-f03-cor3077", LinkUse.legacy); //  1095 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3079", "rwb-f03-cor3080", LinkUse.legacy); //  1096 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3345", -2040.767, 9.000, -1138.353, comment: "TREYFLY,DAKING"); //  1097 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3079", "rwb-f03-cor3079", LinkUse.legacy); //  1097 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3345", -2042.870, 9.000, -1139.041, comment: ""); //  1098 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3345", "rwb-f03-cor3351", LinkUse.legacy); //  1099 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3345", "rwb-f03-ch08-0", LinkUse.legacy); //  1100 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3229", -2013.222, 9.000, -1115.609, comment: "BJORNJ,BRTINK"); //  1101 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3345", "rwb-f03-cor3345", LinkUse.legacy); //  1101 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3229", -2015.893, 9.000, -1116.492, comment: ""); //  1102 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3229", "rwb-f03-cor3218", LinkUse.legacy); //  1103 nn:0 nl:1
                                                                                           // ( empty ); //  1104 nn:0 nl:0
            grc.AddNodePtxyz("rwb-f03-rm3217", -2018.041, 9.000, -1117.260, comment: "NA"); //  1105 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3229", "rwb-f03-cor3229", LinkUse.legacy); //  1105 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3217", -2015.876, 9.000, -1116.543, comment: ""); //  1106 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3217", "rwb-f03-cor3229", LinkUse.legacy); //  1107 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3217", "rwb-f03-ch10-0", LinkUse.legacy); //  1108 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3193", -2025.831, 9.000, -1095.129, comment: "ALVEISEH,JEPOUTON"); //  1109 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3217", "rwb-f03-cor3217", LinkUse.legacy); //  1109 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3193", -2026.636, 9.000, -1092.725, comment: ""); //  1110 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3193", "rwb-f03-cor3197", LinkUse.legacy); //  1111 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3193", "rwb-f03-ch24-0", LinkUse.legacy); //  1112 nn:0 nl:1
            grc.AddNodePtxyz("rwb-f03-rm3049", -2044.305, 9.000, -1101.457, comment: "CHENMLIU,SABINEM"); //  1113 nn:1 nl:1
            grc.AddLinkByNodeName("rwb-f03-rm3193", "rwb-f03-cor3193", LinkUse.legacy); //  1113 nn:1 nl:1
            grc.AddNodePtxyz("rwb-f03-cor3049", -2046.564, 9.000, -1102.205, comment: ""); //  1114 nn:1 nl:0
            grc.AddLinkByNodeName("rwb-f03-cor3049", "rwb-f03-cor3381", LinkUse.legacy); //  1115 nn:0 nl:1
            grc.AddLinkByNodeName("rwb-f03-cor3049", "rwb-f03-ch12-1", LinkUse.legacy); //  1116 nn:0 nl:1
            grc.regman.SetRegion("default");
            grc.gm.setmodxyz_off(0,0,0);
        }

        public void createPointsFor_msft_bsx()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-bsx", "purple", saveToFile: true);
            grc.AddNodePtxyz("bSX-f01-lobby", -157.200, 0.000, -180.000, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("bSX-f01-lobby", "bSX-os1-o00", -154.040, 0.000, -176.210, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.AddNodePtxyz("dw-SX-o00", -85.560, 0.000, -171.520, comment: ""); //  3 nn:1 nl:0
            grc.LinkToPtxyz("dw-SX-o00", "dw-SX-o01", -102.470, 0.000, -172.000, LinkUse.driveway, comment: ""); //  4 nn:1 nl:1
            grc.AddLinkByNodeName("dw-SX-o00", "reg:msft-campus", LinkUse.driveway); //  5 nn:0 nl:1
            grc.regman.SetRegion("default");
        }


    }
}
