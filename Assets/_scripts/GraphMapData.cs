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


        public void createPointsFor_eb12_streets()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("eb12-streets", "blue", saveToFile: true);
            grc.AddNodePtxyz("eb12-st02", -6.000, 0.000, 24.000, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("eb12-st02", "eb12-st01", -6.000, 0.000, 8.000, LinkUse.road, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("eb12-st02", "eb12-st03", -6.000, 0.000, 60.000, LinkUse.slowroad, comment: "streets start"); //  3 nn:1 nl:1
            grc.LinkToPtxyz("eb12-st03", "eb12-st04", -25.000, 0.000, 118.000, LinkUse.slowroad, comment: ""); //  4 nn:1 nl:1
            grc.LinkToPtxyz("eb12-st04", "eb12-st05", 60.000, 0.000, 182.000, LinkUse.road, comment: ""); //  5 nn:1 nl:1
            grc.LinkToPtxyz("eb12-st05", "eb12-nr01", 134.000, 0.000, 182.000, LinkUse.road, comment: ""); //  6 nn:1 nl:1
            grc.LinkToPtxyz("eb12-nr01", "eb12-es01", 229.000, 0.000, 186.000, LinkUse.slowroad, comment: ""); //  7 nn:1 nl:1
            grc.LinkToPtxyz("eb12-es01", "eb12-es02", 252.300, 0.000, 195.300, LinkUse.slowroad, comment: ""); //  8 nn:1 nl:1
            grc.regman.SetRegion("default");
        }


        public void CreateGraphForOsmImport_eb12_small()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("eb12-streets", "blue", saveToFile: true);
            grc.AddNodePtxz("osm248731300", 486.785, 689.415);
            grc.AddNodePtxz("osm738281714", 482.976, 675.254);
            grc.AddNodePtxz("osm6373715031", 467.601, 618.183);
            grc.AddNodePtxz("osm3666999699", 460.006, 587.372);
            grc.AddNodePtxz("osm243312270", 452.050, 548.475);
            grc.AddNodePtxz("osm2769223913", 448.763, 530.137);
            grc.AddNodePtxz("osm3666999698", 441.305, 490.564);
            grc.AddNodePtxz("osm243312208", 434.233, 459.484);
            grc.AddNodePtxz("osm2769223901", 425.987, 425.026);
            grc.AddNodePtxz("osm243312276", 418.358, 403.073);
            grc.AddNodePtxz("osm2769404079", 409.477, 384.859);
            grc.AddNodePtxz("osm243312283", 392.679, 351.386);
            grc.AddNodePtxz("osm2769404063", 369.810, 312.880);
            grc.AddNodePtxz("osm243312291", 347.719, 280.766);
            grc.AddNodePtxz("osm2769404025", 325.084, 252.452);
            grc.AddNodePtxz("osm6373714855", 311.282, 238.097);
            grc.AddNodePtxz("osm243312239", 296.634, 222.860);
            grc.AddNodePtxz("osm3666040458", 286.466, 214.495);
            grc.AddNodePtxz("osm5443078096", 280.256, 209.644);
            grc.AddNodePtxz("osm243312210", 276.705, 206.874);
            grc.AddNodePtxz("osm3666040648", 267.884, 200.966);
            grc.AddNodePtxz("osm3666040647", 256.509, 195.042);
            grc.AddNodePtxz("osm3666040645", 244.601, 189.846);
            grc.AddNodePtxz("osm33702006", 150.972, 72.428);
            grc.AddNodePtxz("osm33702008", 161.524, 15.423);
            grc.AddNodePtxz("osm3662352904", 163.727, 6.561);
            grc.AddNodePtxz("osm3662353689", 166.267, -3.066);
            grc.AddNodePtxz("osm456054460", 170.455, -14.782);
            grc.AddNodePtxz("osm2761659548", 172.311, -17.552);
            grc.AddNodePtxz("osm33701942", 322.411, 22.504);
            grc.AddNodePtxz("osm2347271301", 313.426, 9.692);
            grc.AddNodePtxz("osm3662352910", 308.679, 3.463);
            grc.AddNodePtxz("osm33701943", 302.364, -2.203);
            grc.AddNodePtxz("osm3662353589", 297.083, -6.157);
            grc.AddNodePtxz("osm3662353587", 291.907, -9.101);
            grc.AddNodePtxz("osm266520730", 285.802, -11.411);
            grc.AddNodePtxz("osm33482004", 259.038, -20.358);
            grc.AddNodePtxz("osm33702044", 146.845, 96.352);
            grc.AddNodePtxz("osm3662352902", 137.422, 173.585);
            grc.AddNodePtxz("osm3666040550", 139.229, 153.635);
            grc.AddNodePtxz("osm243312243", 171.555, 183.541);
            grc.AddNodePtxz("osm2245330484", 225.533, 185.353);
            grc.AddNodePtxz("osm1587776905", 362.490, 123.362);
            grc.AddNodePtxz("osm6638749507", 351.553, 97.401);
            grc.AddNodePtxz("osm2347271303", 315.723, 2.618);
            grc.AddNodePtxz("osm2347271302", 310.590, -18.036);
            grc.AddNodePtxz("osm3662352908", 305.212, -43.411);
            grc.AddNodePtxz("osm33702434", 299.509, -73.589);
            grc.AddNodePtxz("osm616247", 405.339, -146.452);
            grc.AddNodePtxz("osm2347271310", 405.854, -117.270);
            grc.AddNodePtxz("osm6638749506", 405.090, -107.983);
            grc.AddNodePtxz("osm33482006", 403.617, -98.787);
            grc.AddNodePtxz("osm3662353711", 401.599, -91.625);
            grc.AddNodePtxz("osm33701937", 398.839, -83.791);
            grc.AddNodePtxz("osm3662353710", 394.465, -74.239);
            grc.AddNodePtxz("osm1881642050", 389.371, -65.790);
            grc.AddNodePtxz("osm3662353708", 384.255, -59.031);
            grc.AddNodePtxz("osm33702330", 378.047, -51.931);
            grc.AddNodePtxz("osm33701936", 363.298, -40.668);
            grc.AddNodePtxz("osm2347271307", 342.782, -27.085);
            grc.AddNodePtxz("osm2347271306", 333.731, -18.701);
            grc.AddNodePtxz("osm33701950", 329.728, -11.974);
            grc.AddNodePtxz("osm33701935", 327.699, -4.101);
            grc.AddNodePtxz("osm3662353700", 326.435, 2.783);
            grc.AddNodePtxz("osm33701944", 326.158, 12.610);
            grc.AddNodePtxz("osm2245330467", 148.050, 88.510);
            grc.AddNodePtxz("osm33701960", 307.201, -87.297);
            grc.AddNodePtxz("osm449011090", 310.606, -63.218);
            grc.AddNodePtxz("osm3662352911", 314.300, -38.553);
            grc.AddNodePtxz("osm2347271304", 318.365, -20.660);
            grc.AddNodePtxz("osm3662352915", 322.639, -2.436);
            grc.AddNodePtxz("osm1587776903", 336.308, 55.917);
            grc.AddNodePtxz("osm268560288", 233.692, 186.868);
            grc.AddNodePtxz("osm2137895182", 206.105, 183.632);
            grc.AddNodePtxz("osm5891573270", 136.809, 183.218);
            grc.AddNodePtxz("osm6638749509", 343.356, 76.298);
            grc.AddNodePtxz("osm2137895149", 103.989, 45.544);
            grc.AddNodePtxz("osm2137895151", 104.521, 37.133);
            grc.AddNodePtxz("osm2137895137", 81.426, 35.814);
            grc.AddNodePtxz("osm2137895138", 81.693, 31.669);
            grc.AddNodePtxz("osm2137895129", 74.671, 31.268);
            grc.AddNodePtxz("osm2137895130", 75.424, 19.581);
            grc.AddNodePtxz("osm2137895147", 102.755, 21.145);
            grc.AddNodePtxz("osm2137895148", 103.113, 15.543);
            grc.AddNodePtxz("osm2137895154", 106.259, 15.727);
            grc.AddNodePtxz("osm2137895155", 106.872, 6.154);
            grc.AddNodePtxz("osm2137895135", 79.622, 4.606);
            grc.AddNodePtxz("osm2137895136", 80.745, -12.864);
            grc.AddNodePtxz("osm2137895150", 104.409, -11.519);
            grc.AddNodePtxz("osm2137895153", 104.733, -16.736);
            grc.AddNodePtxz("osm2137895156", 108.006, -16.545);
            grc.AddNodePtxz("osm2137895157", 108.608, -26.065);
            grc.AddNodePtxz("osm2137895133", 78.155, -27.797);
            grc.AddNodePtxz("osm2137895134", 79.081, -42.270);
            grc.AddNodePtxz("osm2137895131", 76.028, -42.440);
            grc.AddNodePtxz("osm2137895121", 47.838, -44.049);
            grc.AddNodePtxz("osm2137895120", 47.491, -38.613);
            grc.AddNodePtxz("osm2137895119", 43.754, -38.823);
            grc.AddNodePtxz("osm2137895118", 43.118, -28.751);
            grc.AddNodePtxz("osm2137895128", 70.286, -27.195);
            grc.AddNodePtxz("osm3666029366", 70.032, -23.337);
            grc.AddNodePtxz("osm3666040376", 65.320, -23.606);
            grc.AddNodePtxz("osm3666040373", 64.660, -13.301);
            grc.AddNodePtxz("osm3666029365", 69.349, -13.031);
            grc.AddNodePtxz("osm2137895127", 69.152, -10.079);
            grc.AddNodePtxz("osm2137895117", 42.308, -11.616);
            grc.AddNodePtxz("osm2137895116", 41.313, 3.958);
            grc.AddNodePtxz("osm2137895126", 68.249, 5.502);
            grc.AddNodePtxz("osm2137895125", 67.809, 12.267);
            grc.AddNodePtxz("osm2137895124", 61.090, 11.886);
            grc.AddNodePtxz("osm2137895122", 59.099, 42.976);
            grc.AddNodePtxz("osm3177096959", 113.234, 87.131);
            grc.AddNodePtxz("osm3177096960", 113.626, 70.430);
            grc.AddNodePtxz("osm3177098461", 79.111, 69.901);
            grc.AddNodePtxz("osm3177098462", 78.719, 86.603);
            grc.AddNodePtxz("osm3177098463", 131.718, 69.619);
            grc.AddNodePtxz("osm3666040533", 134.084, 61.284);
            grc.AddNodePtxz("osm3666040528", 131.438, 60.537);
            grc.AddNodePtxz("osm3666040532", 132.946, 55.227);
            grc.AddNodePtxz("osm3666040538", 135.604, 55.974);
            grc.AddNodePtxz("osm3177098464", 137.599, 48.970);
            grc.AddNodePtxz("osm3177098465", 135.011, 48.245);
            grc.AddNodePtxz("osm3666040541", 137.353, 38.620);
            grc.AddNodePtxz("osm3177098466", 138.548, 33.727);
            grc.AddNodePtxz("osm3666040527", 130.737, 31.968);
            grc.AddNodePtxz("osm3666040525", 129.519, 31.692);
            grc.AddNodePtxz("osm3177098467", 125.935, 48.232);
            grc.AddNodePtxz("osm3666040397", 121.806, 62.830);
            grc.AddNodePtxz("osm3666040400", 123.663, 63.350);
            grc.AddNodePtxz("osm3177098468", 122.619, 67.056);
            grc.AddNodePtxz("osm3472027587", 209.090, 58.434);
            grc.AddNodePtxz("osm344604967", 220.023, 60.326);
            grc.AddNodePtxz("osm3472027591", 218.550, 68.608);
            grc.AddNodePtxz("osm3472027593", 244.152, 73.038);
            grc.AddNodePtxz("osm3472027592", 242.645, 81.585);
            grc.AddNodePtxz("osm3472027596", 256.073, 83.908);
            grc.AddNodePtxz("osm3472027597", 257.511, 75.807);
            grc.AddNodePtxz("osm3472027598", 275.534, 78.921);
            grc.AddNodePtxz("osm3472027599", 280.346, 51.754);
            grc.AddNodePtxz("osm3472027594", 247.502, 46.072);
            grc.AddNodePtxz("osm3472027595", 248.557, 40.117);
            grc.AddNodePtxz("osm3472027590", 214.366, 34.199);
            grc.AddNodePtxz("osm3472027589", 213.427, 39.511);
            grc.AddNodePtxz("osm3472027588", 212.476, 39.346);
            grc.AddNodePtxz("osm3472027603", 306.900, 193.511);
            grc.AddNodePtxz("osm3472027608", 336.210, 160.069);
            grc.AddNodePtxz("osm3472027609", 346.785, 179.936);
            grc.AddNodePtxz("osm3472027606", 322.256, 208.230);
            grc.AddNodePtxz("osm344604976", 259.963, 167.750);
            grc.AddNodePtxz("osm3472027600", 285.091, 181.526);
            grc.AddNodePtxz("osm3472027602", 299.420, 155.085);
            grc.AddNodePtxz("osm3472027604", 311.502, 161.698);
            grc.AddNodePtxz("osm3666040459", 326.991, 136.590);
            grc.AddNodePtxz("osm3472027607", 324.218, 138.244);
            grc.AddNodePtxz("osm3472027601", 286.996, 117.833);
            grc.AddNodePtxz("osm2320845707", 305.008, 192.471);
            grc.AddNodePtxz("osm3472027605", 319.394, 166.052);
            grc.AddNodePtxz("osm3634590166", 214.325, -6.833);
            grc.AddNodePtxz("osm3634590167", 183.917, -13.041);
            grc.AddNodePtxz("osm5891559543", 182.086, -2.145);
            grc.AddNodePtxz("osm5891559542", 176.642, -3.366);
            grc.AddNodePtxz("osm3634590168", 173.779, 12.753);
            grc.AddNodePtxz("osm3634590169", 210.290, 19.814);
            grc.AddNodePtxz("osm3666040572", 149.462, -4.734);
            grc.AddNodePtxz("osm3666040574", 151.215, -4.161);
            grc.AddNodePtxz("osm3666040577", 153.442, -11.076);
            grc.AddNodePtxz("osm3666040565", 145.898, -13.509);
            grc.AddNodePtxz("osm3666040563", 144.750, -9.953);
            grc.AddNodePtxz("osm3666040559", 142.579, -10.652);
            grc.AddNodePtxz("osm3666040553", 140.967, -5.658);
            grc.AddNodePtxz("osm3666040558", 142.545, -5.913);
            grc.AddNodePtxz("osm3666040557", 141.780, -4.246);
            grc.AddNodePtxz("osm3666040570", 148.313, -3.985);
            grc.AddNodePtxz("osm3666040641", 225.987, 126.856);
            grc.AddNodePtxz("osm3666040640", 224.560, 126.612);
            grc.AddNodePtxz("osm3666040639", 224.235, 128.395);
            grc.AddNodePtxz("osm3666040635", 218.328, 127.367);
            grc.AddNodePtxz("osm3666040636", 219.070, 123.203);
            grc.AddNodePtxz("osm3666040633", 214.207, 122.399);
            grc.AddNodePtxz("osm3666040634", 216.630, 108.155);
            grc.AddNodePtxz("osm3666040644", 229.733, 110.451);
            grc.AddNodePtxz("osm3666040643", 227.565, 122.640);
            grc.AddNodePtxz("osm3666040642", 226.764, 122.496);
            grc.AddNodePtxz("osm3666040545", 138.614, 11.724);
            grc.AddNodePtxz("osm3666040537", 135.367, 25.673);
            grc.AddNodePtxz("osm3666040535", 134.961, 27.382);
            grc.AddNodePtxz("osm3666040556", 141.332, 28.867);
            grc.AddNodePtxz("osm3666040560", 143.503, 29.362);
            grc.AddNodePtxz("osm3666040569", 147.341, 12.880);
            grc.AddNodePtxz("osm3666040549", 139.192, -4.353);
            grc.AddNodePtxz("osm3666040546", 138.787, 6.758);
            grc.AddNodePtxz("osm3666039920", -56.795, 33.927);
            grc.AddNodePtxz("osm3666039952", -68.969, 33.276);
            grc.AddNodePtxz("osm3666039901", -68.807, 30.634);
            grc.AddNodePtxz("osm3666039891", -75.654, 30.262);
            grc.AddNodePtxz("osm3666039742", -80.401, 30.008);
            grc.AddNodePtxz("osm3666039747", -79.579, 16.532);
            grc.AddNodePtxz("osm3666039957", -63.250, 17.412);
            grc.AddNodePtxz("osm3666039956", -63.447, 20.666);
            grc.AddNodePtxz("osm3666039973", -47.745, 21.513);
            grc.AddNodePtxz("osm3666039972", -48.705, 37.254);
            grc.AddNodePtxz("osm3666033019", -52.814, 36.194);
            grc.AddNodePtxz("osm3666033012", -55.553, 34.218);
            grc.AddNodePtxz("osm3666040151", -17.758, 81.267);
            grc.AddNodePtxz("osm3666040003", -27.611, 81.087);
            grc.AddNodePtxz("osm3666040132", -27.334, 70.762);
            grc.AddNodePtxz("osm3666039986", -32.058, 70.674);
            grc.AddNodePtxz("osm3666039988", -31.838, 62.335);
            grc.AddNodePtxz("osm3666039992", -31.014, 62.350);
            grc.AddNodePtxz("osm3666039993", -30.888, 57.663);
            grc.AddNodePtxz("osm3666040007", -22.358, 57.825);
            grc.AddNodePtxz("osm3666040023", -15.081, 57.944);
            grc.AddNodePtxz("osm3666040158", -13.619, 57.977);
            grc.AddNodePtxz("osm3666040155", -13.838, 66.407);
            grc.AddNodePtxz("osm3666040022", -15.462, 66.375);
            grc.AddNodePtxz("osm3666040021", -15.693, 75.205);
            grc.AddNodePtxz("osm3666040014", -17.596, 75.169);
            grc.AddNodePtxz("osm3666040195", 8.950, 103.646);
            grc.AddNodePtxz("osm3666040278", 18.322, 73.105);
            grc.AddNodePtxz("osm3666040193", 8.376, 70.058);
            grc.AddNodePtxz("osm3666040194", 8.851, 68.492);
            grc.AddNodePtxz("osm3666040184", 1.808, 73.193);
            grc.AddNodePtxz("osm3666040042", 3.955, 73.854);
            grc.AddNodePtxz("osm3666040186", 2.226, 79.459);
            grc.AddNodePtxz("osm3666040253", 0.311, 78.872);
            grc.AddNodePtxz("osm3666040249", -1.185, 83.737);
            grc.AddNodePtxz("osm3666040252", 0.208, 84.155);
            grc.AddNodePtxz("osm3666040250", -0.662, 87.007);
            grc.AddNodePtxz("osm3666040180", -2.299, 86.508);
            grc.AddNodePtxz("osm3666040174", -3.458, 90.313);
            grc.AddNodePtxz("osm3666040247", -1.718, 90.841);
            grc.AddNodePtxz("osm3666040244", -2.089, 92.052);
            grc.AddNodePtxz("osm3666040173", -3.818, 91.516);
            grc.AddNodePtxz("osm3666040241", -5.036, 95.495);
            grc.AddNodePtxz("osm3666040176", -3.225, 96.046);
            grc.AddNodePtxz("osm3666040171", -6.752, 107.575);
            grc.AddNodePtxz("osm3666040239", -5.230, 113.131);
            grc.AddNodePtxz("osm3666040183", 1.293, 118.455);
            grc.AddNodePtxz("osm3666040258", 11.260, 105.626);
            grc.AddNodePtxz("osm3666040161", -11.856, 48.703);
            grc.AddNodePtxz("osm3666040135", -24.959, 48.468);
            grc.AddNodePtxz("osm3666040138", -24.764, 35.767);
            grc.AddNodePtxz("osm3666040024", -11.510, 35.979);
            grc.AddNodePtxz("osm3666040337", 32.677, -3.830);
            grc.AddNodePtxz("osm3666040200", 9.942, -4.059);
            grc.AddNodePtxz("osm3666040201", 10.057, -10.632);
            grc.AddNodePtxz("osm3666040339", 32.792, -10.403);
            grc.AddNodePtxz("osm3666039991", -31.069, 83.508);
            grc.AddNodePtxz("osm3666040012", -21.912, 83.551);
            grc.AddNodePtxz("osm3666040011", -21.992, 89.648);
            grc.AddNodePtxz("osm3666039990", -31.149, 89.613);
            grc.AddNodePtxz("osm3666040368", 48.027, 45.650);
            grc.AddNodePtxz("osm3666040367", 47.958, 48.813);
            grc.AddNodePtxz("osm3666040318", 36.840, 48.651);
            grc.AddNodePtxz("osm3666040319", 36.909, 45.489);
            grc.AddNodePtxz("osm3666040009", -22.208, 51.787);
            grc.AddNodePtxz("osm3666040152", -14.931, 51.906);
            grc.AddNodePtxz("osm3666039968", -50.714, 102.720);
            grc.AddNodePtxz("osm3666039958", -62.192, 102.486);
            grc.AddNodePtxz("osm3666039959", -61.730, 86.312);
            grc.AddNodePtxz("osm3666039969", -50.252, 86.554);
            grc.AddNodePtxz("osm3666040452", 106.742, 58.589);
            grc.AddNodePtxz("osm3666040391", 100.765, 58.285);
            grc.AddNodePtxz("osm3666040448", 101.089, 52.556);
            grc.AddNodePtxz("osm3666040453", 107.066, 52.859);
            grc.AddNodePtxz("osm3666040124", 128.433, -4.827);
            grc.AddNodePtxz("osm3666040122", 127.866, 6.210);
            grc.AddNodePtxz("osm3666040016", -17.038, 13.510);
            grc.AddNodePtxz("osm3666040039", -33.541, 13.462);
            grc.AddNodePtxz("osm3666040040", -33.472, 7.297);
            grc.AddNodePtxz("osm3666040017", -16.969, 7.345);
            grc.AddNodePtxz("osm3666040191", 3.843, 27.623);
            grc.AddNodePtxz("osm3666040182", 0.338, 27.532);
            grc.AddNodePtxz("osm3666040251", 0.141, 33.623);
            grc.AddNodePtxz("osm3666040189", 3.635, 33.714);
            grc.AddNodePtxz("osm3666040120", 126.883, 24.380);
            grc.AddNodePtxz("osm3666040454", 112.121, 23.525);
            grc.AddNodePtxz("osm3666040456", 113.128, 7.980);
            grc.AddNodePtxz("osm3666040123", 127.890, 8.835);
            grc.AddNodePtxz("osm3666040381", 68.935, 79.857);
            grc.AddNodePtxz("osm3666040344", 35.244, 79.661);
            grc.AddNodePtxz("osm3666040345", 35.462, 63.980);
            grc.AddNodePtxz("osm3666029364", 69.152, 64.176);
            grc.AddNodePtxz("osm3666040139", -24.429, 21.503);
            grc.AddNodePtxz("osm3666040225", -11.164, 21.715);
            grc.AddNodePtxz("osm3666040631", 209.001, 150.090);
            grc.AddNodePtxz("osm3666040628", 203.859, 149.349);
            grc.AddNodePtxz("osm3666040626", 202.167, 160.644);
            grc.AddNodePtxz("osm3666040630", 207.366, 161.400);
            grc.AddNodePtxz("osm3666040392", 113.510, 5.577);
            grc.AddNodePtxz("osm3666040393", 114.077, -5.459);
            grc.AddNodePtxz("osm3666040035", -34.965, 103.092);
            grc.AddNodePtxz("osm3666040029", -44.435, 102.991);
            grc.AddNodePtxz("osm3666040030", -44.205, 90.607);
            grc.AddNodePtxz("osm3666039982", -39.377, 90.664);
            grc.AddNodePtxz("osm3666039983", -39.320, 87.887);
            grc.AddNodePtxz("osm3666040037", -34.666, 87.945);
            grc.AddNodePtxz("osm3666040637", 219.345, 172.948);
            grc.AddNodePtxz("osm3666040629", 205.964, 171.085);
            grc.AddNodePtxz("osm3666040632", 210.148, 142.090);
            grc.AddNodePtxz("osm3666040638", 223.530, 143.953);
            grc.AddNodePtxz("osm3666040238", -5.319, -0.157);
            grc.AddNodePtxz("osm3666040144", -20.104, -0.695);
            grc.AddNodePtxz("osm3666040145", -19.919, -4.892);
            grc.AddNodePtxz("osm3666040006", -22.542, -4.990);
            grc.AddNodePtxz("osm3666040010", -22.195, -12.810);
            grc.AddNodePtxz("osm3666040243", -4.787, -12.174);
            grc.AddNodePtxz("osm5891623046", 335.383, 141.355);
            grc.AddNodePtxz("osm3666040460", 328.108, 154.011);
            grc.AddNodePtxz("osm3666040461", 332.994, 157.123);
            grc.AddNodePtxz("osm3666040261", 13.225, 128.472);
            grc.AddNodePtxz("osm3666040196", 9.441, 125.471);
            grc.AddNodePtxz("osm3666040255", 10.358, 124.293);
            grc.AddNodePtxz("osm3666040048", 6.423, 121.180);
            grc.AddNodePtxz("osm3666040044", 5.773, 122.008);
            grc.AddNodePtxz("osm3666040288", 23.470, 115.286);
            grc.AddNodePtxz("osm3666040298", 26.892, 31.554);
            grc.AddNodePtxz("osm3666040299", 27.007, 28.256);
            grc.AddNodePtxz("osm3666040188", 3.346, 41.775);
            grc.AddNodePtxz("osm3666040215", 25.164, 42.382);
            grc.AddNodePtxz("osm3666040219", 25.384, 36.313);
            grc.AddNodePtxz("osm3666040297", 26.718, 36.355);
            grc.AddNodePtxz("osm3666040214", 25.118, 45.242);
            grc.AddNodePtxz("osm3666040369", 48.420, 31.967);
            grc.AddNodePtxz("osm3666040547", 138.943, 38.991);
            grc.AddNodePtxz("osm3666040531", 132.384, 24.974);
            grc.AddNodePtxz("osm3666040627", 202.183, 120.404);
            grc.AddNodePtxz("osm3666040625", 201.696, 123.222);
            grc.AddNodePtxz("osm3666040620", 190.868, 121.428);
            grc.AddNodePtxz("osm3666040621", 191.332, 118.731);
            grc.AddNodePtxz("osm3666040618", 184.125, 117.532);
            grc.AddNodePtxz("osm3666040619", 186.571, 103.160);
            grc.AddNodePtxz("osm3666431790", -49.309, 174.760);
            grc.AddNodePtxz("osm3666431794", -48.555, 171.826);
            grc.AddNodePtxz("osm3666431678", -47.615, 172.067);
            grc.AddNodePtxz("osm3666431899", -46.525, 167.840);
            grc.AddNodePtxz("osm3666431681", -47.268, 167.657);
            grc.AddNodePtxz("osm3666431897", -46.665, 165.328);
            grc.AddNodePtxz("osm3666431907", -45.620, 165.591);
            grc.AddNodePtxz("osm3666431914", -44.982, 163.148);
            grc.AddNodePtxz("osm3666431801", -44.414, 163.302);
            grc.AddNodePtxz("osm3666431917", -43.718, 160.602);
            grc.AddNodePtxz("osm3666431912", -45.308, 160.193);
            grc.AddNodePtxz("osm3666431919", -43.533, 153.289);
            grc.AddNodePtxz("osm3666431805", -44.102, 153.136);
            grc.AddNodePtxz("osm3666431771", -55.986, 150.113);
            grc.AddNodePtxz("osm3666431875", -57.309, 149.762);
            grc.AddNodePtxz("osm3666431853", -62.772, 170.944);
            grc.AddNodePtxz("osm3666431884", -54.177, 143.043);
            grc.AddNodePtxz("osm3666431924", -42.316, 146.156);
            grc.AddNodePtxz("osm3666431744", -66.703, 189.886);
            grc.AddNodePtxz("osm3666431635", -76.092, 187.778);
            grc.AddNodePtxz("osm3666430514", -74.678, 181.571);
            grc.AddNodePtxz("osm3666431828", -65.300, 183.679);
            grc.AddNodePtxz("osm3666431768", -56.859, 208.439);
            grc.AddNodePtxz("osm3666431642", -70.496, 205.085);
            grc.AddNodePtxz("osm3666430524", -68.605, 197.161);
            grc.AddNodePtxz("osm3666431882", -54.876, 200.590);
            grc.AddNodePtxz("osm3666431669", -61.248, 191.198);
            grc.AddNodePtxz("osm3666431757", -59.776, 185.315);
            grc.AddNodePtxz("osm3666431785", -50.212, 187.686);
            grc.AddNodePtxz("osm3666431893", -51.674, 193.568);
            grc.AddNodePtxz("osm3666428305", -53.020, 193.233);
            grc.AddNodePtxz("osm3666431645", -70.279, 251.163);
            grc.AddNodePtxz("osm3666431826", -68.110, 243.011);
            grc.AddNodePtxz("osm3666430495", -79.310, 240.110);
            grc.AddNodePtxz("osm3666430483", -80.680, 239.730);
            grc.AddNodePtxz("osm3666431009", -82.837, 247.837);
            grc.AddNodePtxz("osm3666428292", -73.914, 167.809);
            grc.AddNodePtxz("osm3666431684", -47.034, 175.397);
            grc.AddNodePtxz("osm3666431793", -48.751, 181.456);
            grc.AddNodePtxz("osm3666430509", -75.630, 173.860);
            grc.AddNodePtxz("osm3666431650", -65.963, 243.558);
            grc.AddNodePtxz("osm3666431839", -63.887, 235.603);
            grc.AddNodePtxz("osm3666428293", -73.741, 233.016);
            grc.AddNodePtxz("osm3666430504", -77.234, 232.140);
            grc.AddNodePtxz("osm3666431809", -41.492, 146.368);
            grc.AddNodePtxz("osm3666431934", -37.027, 129.413);
            grc.AddNodePtxz("osm3666431782", -50.698, 125.832);
            grc.AddNodePtxz("osm3666431879", -55.175, 142.779);
            grc.AddNodePtxz("osm3666466070", 26.603, 178.022);
            grc.AddNodePtxz("osm3666466823", 20.836, 185.081);
            grc.AddNodePtxz("osm3666466820", 18.630, 183.236);
            grc.AddNodePtxz("osm3666466817", 17.250, 184.915);
            grc.AddNodePtxz("osm3666466818", 17.760, 185.334);
            grc.AddNodePtxz("osm3666466814", 14.987, 188.730);
            grc.AddNodePtxz("osm3666466812", 14.372, 188.222);
            grc.AddNodePtxz("osm3666466810", 12.028, 191.079);
            grc.AddNodePtxz("osm3666466791", 4.681, 184.955);
            grc.AddNodePtxz("osm3666466803", 6.468, 182.751);
            grc.AddNodePtxz("osm3666466801", 5.853, 182.236);
            grc.AddNodePtxz("osm3666466806", 8.997, 178.391);
            grc.AddNodePtxz("osm3666466804", 8.742, 178.189);
            grc.AddNodePtxz("osm3666466808", 10.494, 176.047);
            grc.AddNodePtxz("osm3666466807", 9.287, 175.189);
            grc.AddNodePtxz("osm3666466813", 14.821, 168.223);
            grc.AddNodePtxz("osm3666466802", 6.408, 172.860);
            grc.AddNodePtxz("osm3666466794", 4.842, 174.820);
            grc.AddNodePtxz("osm3666466800", 5.318, 175.200);
            grc.AddNodePtxz("osm3666466787", 2.591, 178.634);
            grc.AddNodePtxz("osm3666468623", 1.929, 178.104);
            grc.AddNodePtxz("osm3666468618", -0.322, 180.938);
            grc.AddNodePtxz("osm3666468595", -7.773, 174.912);
            grc.AddNodePtxz("osm3666468605", -5.963, 172.625);
            grc.AddNodePtxz("osm3666468602", -6.544, 172.155);
            grc.AddNodePtxz("osm3666467905", -3.457, 168.258);
            grc.AddNodePtxz("osm3666468613", -3.654, 168.093);
            grc.AddNodePtxz("osm3666467907", -1.937, 165.921);
            grc.AddNodePtxz("osm3666467906", -3.063, 165.002);
            grc.AddNodePtxz("osm3666466786", 2.367, 158.150);
            grc.AddNodePtxz("osm3666468606", -5.965, 162.771);
            grc.AddNodePtxz("osm3666468596", -7.531, 164.731);
            grc.AddNodePtxz("osm3666468599", -7.055, 165.119);
            grc.AddNodePtxz("osm3666468589", -9.782, 168.546);
            grc.AddNodePtxz("osm3666468584", -10.444, 168.015);
            grc.AddNodePtxz("osm3666467902", -12.706, 170.857);
            grc.AddNodePtxz("osm3666467881", -20.135, 164.808);
            grc.AddNodePtxz("osm3666467886", -18.325, 162.544);
            grc.AddNodePtxz("osm3666467883", -18.917, 162.059);
            grc.AddNodePtxz("osm3666467889", -15.819, 158.177);
            grc.AddNodePtxz("osm3666467888", -16.028, 158.005);
            grc.AddNodePtxz("osm3666467897", -14.206, 155.711);
            grc.AddNodePtxz("osm3666467891", -15.320, 154.792);
            grc.AddNodePtxz("osm3666468587", -9.994, 148.122);
            grc.AddNodePtxz("osm3666468607", -5.588, 193.893);
            grc.AddNodePtxz("osm3666468608", -5.390, 200.501);
            grc.AddNodePtxz("osm3666468600", -6.851, 205.667);
            grc.AddNodePtxz("osm3666468604", -6.016, 205.901);
            grc.AddNodePtxz("osm3666468597", -7.419, 210.886);
            grc.AddNodePtxz("osm3666468588", -9.880, 210.197);
            grc.AddNodePtxz("osm3666468585", -10.251, 211.498);
            grc.AddNodePtxz("osm3666467890", -15.787, 209.938);
            grc.AddNodePtxz("osm3666467896", -14.244, 204.493);
            grc.AddNodePtxz("osm3666467882", -19.827, 202.918);
            grc.AddNodePtxz("osm3666467887", -16.069, 189.621);
            grc.AddNodePtxz("osm3666467900", -13.597, 190.317);
            grc.AddNodePtxz("osm3666467901", -13.110, 188.569);
            grc.AddNodePtxz("osm3666468586", -10.127, 189.412);
            grc.AddNodePtxz("osm3666467903", -10.533, 190.826);
            grc.AddNodePtxz("osm3666468601", -6.830, 191.866);
            grc.AddNodePtxz("osm3666468598", -7.271, 193.424);
            grc.AddNodePtxz("osm3666466098", 90.114, 215.843);
            grc.AddNodePtxz("osm3666466079", 82.721, 215.709);
            grc.AddNodePtxz("osm3666466078", 82.664, 218.072);
            grc.AddNodePtxz("osm3666469265", 78.126, 217.990);
            grc.AddNodePtxz("osm3666469266", 78.160, 216.510);
            grc.AddNodePtxz("osm3666469335", 67.089, 216.318);
            grc.AddNodePtxz("osm3666469334", 67.054, 217.578);
            grc.AddNodePtxz("osm3666469247", 61.344, 217.476);
            grc.AddNodePtxz("osm3666469248", 61.390, 215.627);
            grc.AddNodePtxz("osm3666469239", 55.321, 215.520);
            grc.AddNodePtxz("osm3666469238", 55.286, 216.849);
            grc.AddNodePtxz("osm3666469328", 51.120, 216.778);
            grc.AddNodePtxz("osm3666469329", 51.154, 215.344);
            grc.AddNodePtxz("osm3666469232", 45.769, 215.247);
            grc.AddNodePtxz("osm3666469230", 45.723, 217.141);
            grc.AddNodePtxz("osm3666469136", 38.377, 217.008);
            grc.AddNodePtxz("osm3666469139", 38.527, 210.985);
            grc.AddNodePtxz("osm3666469144", 40.082, 211.017);
            grc.AddNodePtxz("osm3666469145", 40.382, 199.432);
            grc.AddNodePtxz("osm3666466099", 90.401, 200.327);
            grc.AddNodePtxz("osm3666469280", 103.736, 198.440);
            grc.AddNodePtxz("osm3666469286", 105.837, 201.516);
            grc.AddNodePtxz("osm3666469285", 105.733, 207.666);
            grc.AddNodePtxz("osm3666469290", 106.256, 207.669);
            grc.AddNodePtxz("osm3666469289", 106.152, 213.480);
            grc.AddNodePtxz("osm3666469284", 105.491, 213.478);
            grc.AddNodePtxz("osm3666469169", 105.410, 218.089);
            grc.AddNodePtxz("osm3666469170", 106.768, 218.108);
            grc.AddNodePtxz("osm3666469293", 106.653, 224.379);
            grc.AddNodePtxz("osm3666469166", 104.831, 224.357);
            grc.AddNodePtxz("osm3666469165", 104.727, 229.896);
            grc.AddNodePtxz("osm3666469168", 105.412, 229.905);
            grc.AddNodePtxz("osm3666469167", 105.320, 235.150);
            grc.AddNodePtxz("osm3666469164", 104.589, 235.142);
            grc.AddNodePtxz("osm3666469162", 104.520, 239.020);
            grc.AddNodePtxz("osm3666469288", 106.006, 239.038);
            grc.AddNodePtxz("osm3666469287", 105.914, 244.057);
            grc.AddNodePtxz("osm3666469163", 104.556, 244.045);
            grc.AddNodePtxz("osm3666469161", 104.521, 246.257);
            grc.AddNodePtxz("osm3666466085", 86.011, 246.067);
            grc.AddNodePtxz("osm3666466087", 86.298, 230.061);
            grc.AddNodePtxz("osm3666466094", 88.886, 230.084);
            grc.AddNodePtxz("osm3666466095", 88.978, 224.703);
            grc.AddNodePtxz("osm3666466097", 89.953, 224.710);
            grc.AddNodePtxz("osm3666466100", 90.436, 198.304);
            grc.AddNodePtxz("osm3666467912", -1.113, 237.875);
            grc.AddNodePtxz("osm3666467911", -1.184, 228.731);
            grc.AddNodePtxz("osm3666466796", 5.036, 228.632);
            grc.AddNodePtxz("osm3666466797", 5.108, 237.769);
            grc.AddNodePtxz("osm3666467916", 35.157, 185.163);
            grc.AddNodePtxz("osm3666467915", 34.996, 193.585);
            grc.AddNodePtxz("osm3666467923", 38.280, 193.617);
            grc.AddNodePtxz("osm3666469138", 38.441, 185.203);
            grc.AddNodePtxz("osm3666467892", -14.618, 259.970);
            grc.AddNodePtxz("osm3666467893", -14.481, 246.123);
            grc.AddNodePtxz("osm3666467894", -14.413, 238.434);
            grc.AddNodePtxz("osm3666468594", -7.937, 238.476);
            grc.AddNodePtxz("osm3666468593", -8.235, 260.006);
            grc.AddNodePtxz("osm3666467895", -14.344, 230.593);
            grc.AddNodePtxz("osm3666467880", -25.045, 230.586);
            grc.AddNodePtxz("osm3666467879", -25.192, 249.127);
            grc.AddNodePtxz("osm3666467884", -18.473, 249.130);
            grc.AddNodePtxz("osm3666467885", -18.438, 246.119);
            grc.AddNodePtxz("osm3666467874", -31.413, 177.037);
            grc.AddNodePtxz("osm3666466785", -32.805, 181.848);
            grc.AddNodePtxz("osm3666466784", -33.908, 181.533);
            grc.AddNodePtxz("osm3666466783", -36.691, 191.124);
            grc.AddNodePtxz("osm3666467875", -29.252, 193.279);
            grc.AddNodePtxz("osm3666467877", -26.515, 183.885);
            grc.AddNodePtxz("osm3666467876", -27.048, 183.731);
            grc.AddNodePtxz("osm3666467878", -25.599, 178.723);
            grc.AddNodePtxz("osm3666999124", 216.716, 208.396);
            grc.AddNodePtxz("osm3666999332", 219.581, 196.224);
            grc.AddNodePtxz("osm3666999116", 213.964, 194.913);
            grc.AddNodePtxz("osm3666999110", 211.099, 207.086);
            grc.AddNodePtxz("osm3666999086", 191.984, 201.831);
            grc.AddNodePtxz("osm3666999088", 192.423, 191.686);
            grc.AddNodePtxz("osm3666999078", 186.145, 191.460);
            grc.AddNodePtxz("osm3666999077", 185.706, 201.613);
            grc.AddNodePtxz("osm3666999052", 165.316, 206.955);
            grc.AddNodePtxz("osm3666999043", 152.944, 206.389);
            grc.AddNodePtxz("osm3666999044", 153.546, 194.303);
            grc.AddNodePtxz("osm3666999053", 165.952, 194.869);
            grc.AddNodePtxz("osm3666999065", 177.738, 233.757);
            grc.AddNodePtxz("osm3666999153", 179.114, 201.382);
            grc.AddNodePtxz("osm3666999082", 190.643, 234.205);
            grc.AddNodePtxz("osm3666999111", 211.278, 234.444);
            grc.AddNodePtxz("osm3666999095", 198.709, 231.827);
            grc.AddNodePtxz("osm3666999185", 204.217, 205.726);
            grc.AddNodePtxz("osm3666999031", 144.971, 206.049);
            grc.AddNodePtxz("osm3666999033", 145.226, 200.977);
            grc.AddNodePtxz("osm3666999039", 146.142, 201.014);
            grc.AddNodePtxz("osm3666997221", 146.570, 192.537);
            grc.AddNodePtxz("osm3666999046", 153.627, 192.839);
            grc.AddNodePtxz("osm3666991854", 163.056, 228.502);
            grc.AddNodePtxz("osm3666999129", 144.058, 228.392);
            grc.AddNodePtxz("osm3666999128", 143.989, 233.440);
            grc.AddNodePtxz("osm3666998822", 143.026, 233.433);
            grc.AddNodePtxz("osm3666999029", 142.946, 238.776);
            grc.AddNodePtxz("osm3666999127", 143.688, 238.785);
            grc.AddNodePtxz("osm3666999125", 143.620, 243.864);
            grc.AddNodePtxz("osm3666991853", 162.838, 243.972);
            grc.AddNodePtxz("osm5455089557", 196.436, 173.671);
            grc.AddNodePtxz("osm5455089558", 156.211, 172.550);
            grc.AddNodePtxz("osm5455089559", 156.859, 157.121);
            grc.AddNodePtxz("osm5455089560", 196.817, 159.316);
            grc.AddNodePtxz("osm5730170647", 297.805, 285.983);
            grc.AddNodePtxz("osm5730170648", 319.782, 266.253);
            grc.AddNodePtxz("osm5730170649", 290.845, 236.581);
            grc.AddNodePtxz("osm5730170650", 274.078, 256.025);
            grc.AddNodePtxz("osm5730170651", 282.389, 263.742);
            grc.AddNodePtxz("osm5730170652", 290.454, 255.290);
            grc.AddNodePtxz("osm5730170653", 300.610, 265.141);
            grc.AddNodePtxz("osm5730170654", 288.902, 276.151);
            grc.AddNodePtxz("osm5730170655", 262.611, 246.193);
            grc.AddNodePtxz("osm5730170656", 277.335, 227.310);
            grc.AddNodePtxz("osm5730170657", 243.153, 206.187);
            grc.AddNodePtxz("osm5730170658", 227.606, 229.687);
            grc.AddNodePtxz("osm5730170659", 237.762, 235.283);
            grc.AddNodePtxz("osm5730170660", 245.361, 221.636);
            grc.AddNodePtxz("osm5730170661", 258.859, 228.780);
            grc.AddNodePtxz("osm5730170662", 250.946, 239.532);
            grc.AddNodePtxz("osm5891566774", 128.300, 169.913);
            grc.AddNodePtxz("osm5891566775", 98.683, 169.561);
            grc.AddNodePtxz("osm5891566776", 98.680, 154.380);
            grc.AddNodePtxz("osm5891566777", 128.297, 154.331);
            grc.AddNodePtxz("osm5891566778", 87.681, 169.451);
            grc.AddNodePtxz("osm5891566779", 72.675, 169.171);
            grc.AddNodePtxz("osm5891566780", 73.063, 133.757);
            grc.AddNodePtxz("osm5891566781", 88.081, 134.029);
            grc.AddNodePtxz("osm5891566782", 102.283, 118.123);
            grc.AddNodePtxz("osm5891566783", 57.451, 117.901);
            grc.AddNodePtxz("osm5891566784", 57.449, 103.935);
            grc.AddNodePtxz("osm5891567185", 102.281, 103.757);
            grc.AddNodePtxz("osm5891567186", 50.854, 153.980);
            grc.AddNodePtxz("osm5891567187", 59.661, 142.368);
            grc.AddNodePtxz("osm5891567188", 35.240, 124.361);
            grc.AddNodePtxz("osm5891567189", 27.245, 134.955);
            grc.AddNodePtxz("osm5891567190", 130.691, 103.311);
            grc.AddNodePtxz("osm5891567191", 116.683, 103.023);
            grc.AddNodePtxz("osm5891567192", 116.690, 141.678);
            grc.AddNodePtxz("osm5891567193", 130.303, 141.359);
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
            grc.AddLinkByNodeName("osm3666040550", "osm3662352902", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse02.link1");
            grc.AddLinkByNodeName("osm33702044", "osm3666040550", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse02.link2");
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
            grc.AddLinkByNodeName("osm2245330467", "osm33702044", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse03.link1");
            grc.AddLinkByNodeName("osm33702006", "osm2245330467", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse03.link2");
            grc.AddLinkByNodeName("osm449011090", "osm33701960", usetype: LinkUse.road, comment: "primary03.link1");
            grc.AddLinkByNodeName("osm3662352911", "osm449011090", usetype: LinkUse.road, comment: "primary03.link2");
            grc.AddLinkByNodeName("osm2347271304", "osm3662352911", usetype: LinkUse.road, comment: "primary03.link3");
            grc.AddLinkByNodeName("osm3662352915", "osm2347271304", usetype: LinkUse.road, comment: "primary03.link4");
            grc.AddLinkByNodeName("osm33701944", "osm3662352915", usetype: LinkUse.road, comment: "primary03.link5");
            grc.AddLinkByNodeName("osm1587776903", "osm33701944", usetype: LinkUse.road, comment: "primary03.link6");
            grc.AddLinkByNodeName("osm33701942", "osm1587776903", usetype: LinkUse.road, comment: "primary04.link1");
            grc.AddLinkByNodeName("osm268560288", "osm3666040645", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee01.link1");
            grc.AddLinkByNodeName("osm2245330484", "osm268560288", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee01.link2");
            grc.AddLinkByNodeName("osm2137895182", "osm2245330484", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee01.link3");
            grc.AddLinkByNodeName("osm243312243", "osm2137895182", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee01.link4");
            grc.AddLinkByNodeName("osm5891573270", "osm3662352902", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse05.link1");
            grc.AddLinkByNodeName("osm5891573270", "osm243312243", usetype: LinkUse.road, comment: "Elisabeth-Selbert-Allee02.link1");
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
            grc.AddLinkByNodeName("osm3666040533", "osm3177098463", usetype: LinkUse.bldwall, comment: "yes01.link1");
            grc.AddLinkByNodeName("osm3666040528", "osm3666040533", usetype: LinkUse.bldwall, comment: "yes01.link2");
            grc.AddLinkByNodeName("osm3666040532", "osm3666040528", usetype: LinkUse.bldwall, comment: "yes01.link3");
            grc.AddLinkByNodeName("osm3666040538", "osm3666040532", usetype: LinkUse.bldwall, comment: "yes01.link4");
            grc.AddLinkByNodeName("osm3177098464", "osm3666040538", usetype: LinkUse.bldwall, comment: "yes01.link5");
            grc.AddLinkByNodeName("osm3177098465", "osm3177098464", usetype: LinkUse.bldwall, comment: "yes01.link6");
            grc.AddLinkByNodeName("osm3666040541", "osm3177098465", usetype: LinkUse.bldwall, comment: "yes01.link7");
            grc.AddLinkByNodeName("osm3177098466", "osm3666040541", usetype: LinkUse.bldwall, comment: "yes01.link8");
            grc.AddLinkByNodeName("osm3666040527", "osm3177098466", usetype: LinkUse.bldwall, comment: "yes01.link9");
            grc.AddLinkByNodeName("osm3666040525", "osm3666040527", usetype: LinkUse.bldwall, comment: "yes01.link10");
            grc.AddLinkByNodeName("osm3177098467", "osm3666040525", usetype: LinkUse.bldwall, comment: "yes01.link11");
            grc.AddLinkByNodeName("osm3666040397", "osm3177098467", usetype: LinkUse.bldwall, comment: "yes01.link12");
            grc.AddLinkByNodeName("osm3666040400", "osm3666040397", usetype: LinkUse.bldwall, comment: "yes01.link13");
            grc.AddLinkByNodeName("osm3177098468", "osm3666040400", usetype: LinkUse.bldwall, comment: "yes01.link14");
            grc.AddLinkByNodeName("osm3177098463", "osm3177098468", usetype: LinkUse.bldwall, comment: "yes01.link15");
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
            grc.AddLinkByNodeName("osm3666040574", "osm3666040572", usetype: LinkUse.bldwall, comment: "yes02.link1");
            grc.AddLinkByNodeName("osm3666040577", "osm3666040574", usetype: LinkUse.bldwall, comment: "yes02.link2");
            grc.AddLinkByNodeName("osm3666040565", "osm3666040577", usetype: LinkUse.bldwall, comment: "yes02.link3");
            grc.AddLinkByNodeName("osm3666040563", "osm3666040565", usetype: LinkUse.bldwall, comment: "yes02.link4");
            grc.AddLinkByNodeName("osm3666040559", "osm3666040563", usetype: LinkUse.bldwall, comment: "yes02.link5");
            grc.AddLinkByNodeName("osm3666040553", "osm3666040559", usetype: LinkUse.bldwall, comment: "yes02.link6");
            grc.AddLinkByNodeName("osm3666040558", "osm3666040553", usetype: LinkUse.bldwall, comment: "yes02.link7");
            grc.AddLinkByNodeName("osm3666040557", "osm3666040558", usetype: LinkUse.bldwall, comment: "yes02.link8");
            grc.AddLinkByNodeName("osm3666040570", "osm3666040557", usetype: LinkUse.bldwall, comment: "yes02.link9");
            grc.AddLinkByNodeName("osm3666040572", "osm3666040570", usetype: LinkUse.bldwall, comment: "yes02.link10");
            grc.AddLinkByNodeName("osm3666040640", "osm3666040641", usetype: LinkUse.bldwall, comment: "yes03.link1");
            grc.AddLinkByNodeName("osm3666040639", "osm3666040640", usetype: LinkUse.bldwall, comment: "yes03.link2");
            grc.AddLinkByNodeName("osm3666040635", "osm3666040639", usetype: LinkUse.bldwall, comment: "yes03.link3");
            grc.AddLinkByNodeName("osm3666040636", "osm3666040635", usetype: LinkUse.bldwall, comment: "yes03.link4");
            grc.AddLinkByNodeName("osm3666040633", "osm3666040636", usetype: LinkUse.bldwall, comment: "yes03.link5");
            grc.AddLinkByNodeName("osm3666040634", "osm3666040633", usetype: LinkUse.bldwall, comment: "yes03.link6");
            grc.AddLinkByNodeName("osm3666040644", "osm3666040634", usetype: LinkUse.bldwall, comment: "yes03.link7");
            grc.AddLinkByNodeName("osm3666040643", "osm3666040644", usetype: LinkUse.bldwall, comment: "yes03.link8");
            grc.AddLinkByNodeName("osm3666040642", "osm3666040643", usetype: LinkUse.bldwall, comment: "yes03.link9");
            grc.AddLinkByNodeName("osm3666040641", "osm3666040642", usetype: LinkUse.bldwall, comment: "yes03.link10");
            grc.AddLinkByNodeName("osm3666040537", "osm3666040545", usetype: LinkUse.bldwall, comment: "yes04.link1");
            grc.AddLinkByNodeName("osm3666040535", "osm3666040537", usetype: LinkUse.bldwall, comment: "yes04.link2");
            grc.AddLinkByNodeName("osm3666040556", "osm3666040535", usetype: LinkUse.bldwall, comment: "yes04.link3");
            grc.AddLinkByNodeName("osm3666040560", "osm3666040556", usetype: LinkUse.bldwall, comment: "yes04.link4");
            grc.AddLinkByNodeName("osm3666040569", "osm3666040560", usetype: LinkUse.bldwall, comment: "yes04.link5");
            grc.AddLinkByNodeName("osm3666040570", "osm3666040569", usetype: LinkUse.bldwall, comment: "yes04.link6");
            grc.AddLinkByNodeName("osm3666040557", "osm3666040570", usetype: LinkUse.bldwall, comment: "yes04.link7");
            grc.AddLinkByNodeName("osm3666040549", "osm3666040557", usetype: LinkUse.bldwall, comment: "yes04.link8");
            grc.AddLinkByNodeName("osm3666040546", "osm3666040549", usetype: LinkUse.bldwall, comment: "yes04.link9");
            grc.AddLinkByNodeName("osm3666040545", "osm3666040546", usetype: LinkUse.bldwall, comment: "yes04.link10");
            grc.AddLinkByNodeName("osm3666039952", "osm3666039920", usetype: LinkUse.bldwall, comment: "yes05.link1");
            grc.AddLinkByNodeName("osm3666039901", "osm3666039952", usetype: LinkUse.bldwall, comment: "yes05.link2");
            grc.AddLinkByNodeName("osm3666039891", "osm3666039901", usetype: LinkUse.bldwall, comment: "yes05.link3");
            grc.AddLinkByNodeName("osm3666039742", "osm3666039891", usetype: LinkUse.bldwall, comment: "yes05.link4");
            grc.AddLinkByNodeName("osm3666039747", "osm3666039742", usetype: LinkUse.bldwall, comment: "yes05.link5");
            grc.AddLinkByNodeName("osm3666039957", "osm3666039747", usetype: LinkUse.bldwall, comment: "yes05.link6");
            grc.AddLinkByNodeName("osm3666039956", "osm3666039957", usetype: LinkUse.bldwall, comment: "yes05.link7");
            grc.AddLinkByNodeName("osm3666039973", "osm3666039956", usetype: LinkUse.bldwall, comment: "yes05.link8");
            grc.AddLinkByNodeName("osm3666039972", "osm3666039973", usetype: LinkUse.bldwall, comment: "yes05.link9");
            grc.AddLinkByNodeName("osm3666033019", "osm3666039972", usetype: LinkUse.bldwall, comment: "yes05.link10");
            grc.AddLinkByNodeName("osm3666033012", "osm3666033019", usetype: LinkUse.bldwall, comment: "yes05.link11");
            grc.AddLinkByNodeName("osm3666039920", "osm3666033012", usetype: LinkUse.bldwall, comment: "yes05.link12");
            grc.AddLinkByNodeName("osm3666040003", "osm3666040151", usetype: LinkUse.bldwall, comment: "yes06.link1");
            grc.AddLinkByNodeName("osm3666040132", "osm3666040003", usetype: LinkUse.bldwall, comment: "yes06.link2");
            grc.AddLinkByNodeName("osm3666039986", "osm3666040132", usetype: LinkUse.bldwall, comment: "yes06.link3");
            grc.AddLinkByNodeName("osm3666039988", "osm3666039986", usetype: LinkUse.bldwall, comment: "yes06.link4");
            grc.AddLinkByNodeName("osm3666039992", "osm3666039988", usetype: LinkUse.bldwall, comment: "yes06.link5");
            grc.AddLinkByNodeName("osm3666039993", "osm3666039992", usetype: LinkUse.bldwall, comment: "yes06.link6");
            grc.AddLinkByNodeName("osm3666040007", "osm3666039993", usetype: LinkUse.bldwall, comment: "yes06.link7");
            grc.AddLinkByNodeName("osm3666040023", "osm3666040007", usetype: LinkUse.bldwall, comment: "yes06.link8");
            grc.AddLinkByNodeName("osm3666040158", "osm3666040023", usetype: LinkUse.bldwall, comment: "yes06.link9");
            grc.AddLinkByNodeName("osm3666040155", "osm3666040158", usetype: LinkUse.bldwall, comment: "yes06.link10");
            grc.AddLinkByNodeName("osm3666040022", "osm3666040155", usetype: LinkUse.bldwall, comment: "yes06.link11");
            grc.AddLinkByNodeName("osm3666040021", "osm3666040022", usetype: LinkUse.bldwall, comment: "yes06.link12");
            grc.AddLinkByNodeName("osm3666040014", "osm3666040021", usetype: LinkUse.bldwall, comment: "yes06.link13");
            grc.AddLinkByNodeName("osm3666040151", "osm3666040014", usetype: LinkUse.bldwall, comment: "yes06.link14");
            grc.AddLinkByNodeName("osm3666040278", "osm3666040195", usetype: LinkUse.bldwall, comment: "yes07.link1");
            grc.AddLinkByNodeName("osm3666040193", "osm3666040278", usetype: LinkUse.bldwall, comment: "yes07.link2");
            grc.AddLinkByNodeName("osm3666040194", "osm3666040193", usetype: LinkUse.bldwall, comment: "yes07.link3");
            grc.AddLinkByNodeName("osm3666040190", "osm3666040194", usetype: LinkUse.bldwall, comment: "yes07.link4");
            grc.AddLinkByNodeName("osm3666040184", "osm3666040190", usetype: LinkUse.bldwall, comment: "yes07.link5");
            grc.AddLinkByNodeName("osm3666040042", "osm3666040184", usetype: LinkUse.bldwall, comment: "yes07.link6");
            grc.AddLinkByNodeName("osm3666040186", "osm3666040042", usetype: LinkUse.bldwall, comment: "yes07.link7");
            grc.AddLinkByNodeName("osm3666040253", "osm3666040186", usetype: LinkUse.bldwall, comment: "yes07.link8");
            grc.AddLinkByNodeName("osm3666040249", "osm3666040253", usetype: LinkUse.bldwall, comment: "yes07.link9");
            grc.AddLinkByNodeName("osm3666040252", "osm3666040249", usetype: LinkUse.bldwall, comment: "yes07.link10");
            grc.AddLinkByNodeName("osm3666040250", "osm3666040252", usetype: LinkUse.bldwall, comment: "yes07.link11");
            grc.AddLinkByNodeName("osm3666040180", "osm3666040250", usetype: LinkUse.bldwall, comment: "yes07.link12");
            grc.AddLinkByNodeName("osm3666040174", "osm3666040180", usetype: LinkUse.bldwall, comment: "yes07.link13");
            grc.AddLinkByNodeName("osm3666040247", "osm3666040174", usetype: LinkUse.bldwall, comment: "yes07.link14");
            grc.AddLinkByNodeName("osm3666040244", "osm3666040247", usetype: LinkUse.bldwall, comment: "yes07.link15");
            grc.AddLinkByNodeName("osm3666040173", "osm3666040244", usetype: LinkUse.bldwall, comment: "yes07.link16");
            grc.AddLinkByNodeName("osm3666040241", "osm3666040173", usetype: LinkUse.bldwall, comment: "yes07.link17");
            grc.AddLinkByNodeName("osm3666040176", "osm3666040241", usetype: LinkUse.bldwall, comment: "yes07.link18");
            grc.AddLinkByNodeName("osm3666040171", "osm3666040176", usetype: LinkUse.bldwall, comment: "yes07.link19");
            grc.AddLinkByNodeName("osm3666040239", "osm3666040171", usetype: LinkUse.bldwall, comment: "yes07.link20");
            grc.AddLinkByNodeName("osm3666040183", "osm3666040239", usetype: LinkUse.bldwall, comment: "yes07.link21");
            grc.AddLinkByNodeName("osm3666040258", "osm3666040183", usetype: LinkUse.bldwall, comment: "yes07.link22");
            grc.AddLinkByNodeName("osm3666040195", "osm3666040258", usetype: LinkUse.bldwall, comment: "yes07.link23");
            grc.AddLinkByNodeName("osm3666040135", "osm3666040161", usetype: LinkUse.bldwall, comment: "yes08.link1");
            grc.AddLinkByNodeName("osm3666040138", "osm3666040135", usetype: LinkUse.bldwall, comment: "yes08.link2");
            grc.AddLinkByNodeName("osm3666040024", "osm3666040138", usetype: LinkUse.bldwall, comment: "yes08.link3");
            grc.AddLinkByNodeName("osm3666040161", "osm3666040024", usetype: LinkUse.bldwall, comment: "yes08.link4");
            grc.AddLinkByNodeName("osm3666040200", "osm3666040337", usetype: LinkUse.bldwall, comment: "yes09.link1");
            grc.AddLinkByNodeName("osm3666040201", "osm3666040200", usetype: LinkUse.bldwall, comment: "yes09.link2");
            grc.AddLinkByNodeName("osm3666040339", "osm3666040201", usetype: LinkUse.bldwall, comment: "yes09.link3");
            grc.AddLinkByNodeName("osm3666040337", "osm3666040339", usetype: LinkUse.bldwall, comment: "yes09.link4");
            grc.AddLinkByNodeName("osm3666040012", "osm3666039991", usetype: LinkUse.bldwall, comment: "yes10.link1");
            grc.AddLinkByNodeName("osm3666040011", "osm3666040012", usetype: LinkUse.bldwall, comment: "yes10.link2");
            grc.AddLinkByNodeName("osm3666039990", "osm3666040011", usetype: LinkUse.bldwall, comment: "yes10.link3");
            grc.AddLinkByNodeName("osm3666039991", "osm3666039990", usetype: LinkUse.bldwall, comment: "yes10.link4");
            grc.AddLinkByNodeName("osm3666040367", "osm3666040368", usetype: LinkUse.bldwall, comment: "yes11.link1");
            grc.AddLinkByNodeName("osm3666040318", "osm3666040367", usetype: LinkUse.bldwall, comment: "yes11.link2");
            grc.AddLinkByNodeName("osm3666040319", "osm3666040318", usetype: LinkUse.bldwall, comment: "yes11.link3");
            grc.AddLinkByNodeName("osm3666040368", "osm3666040319", usetype: LinkUse.bldwall, comment: "yes11.link4");
            grc.AddLinkByNodeName("osm3666040009", "osm3666040007", usetype: LinkUse.bldwall, comment: "yes12.link1");
            grc.AddLinkByNodeName("osm3666040152", "osm3666040009", usetype: LinkUse.bldwall, comment: "yes12.link2");
            grc.AddLinkByNodeName("osm3666040023", "osm3666040152", usetype: LinkUse.bldwall, comment: "yes12.link3");
            grc.AddLinkByNodeName("osm3666040007", "osm3666040023", usetype: LinkUse.bldwall, comment: "yes12.link4");
            grc.AddLinkByNodeName("osm3666039958", "osm3666039968", usetype: LinkUse.bldwall, comment: "yes13.link1");
            grc.AddLinkByNodeName("osm3666039959", "osm3666039958", usetype: LinkUse.bldwall, comment: "yes13.link2");
            grc.AddLinkByNodeName("osm3666039969", "osm3666039959", usetype: LinkUse.bldwall, comment: "yes13.link3");
            grc.AddLinkByNodeName("osm3666039968", "osm3666039969", usetype: LinkUse.bldwall, comment: "yes13.link4");
            grc.AddLinkByNodeName("osm3666040391", "osm3666040452", usetype: LinkUse.bldwall, comment: "yes14.link1");
            grc.AddLinkByNodeName("osm3666040448", "osm3666040391", usetype: LinkUse.bldwall, comment: "yes14.link2");
            grc.AddLinkByNodeName("osm3666040453", "osm3666040448", usetype: LinkUse.bldwall, comment: "yes14.link3");
            grc.AddLinkByNodeName("osm3666040452", "osm3666040453", usetype: LinkUse.bldwall, comment: "yes14.link4");
            grc.AddLinkByNodeName("osm3666040124", "osm3666040549", usetype: LinkUse.bldwall, comment: "yes15.link1");
            grc.AddLinkByNodeName("osm3666040122", "osm3666040124", usetype: LinkUse.bldwall, comment: "yes15.link2");
            grc.AddLinkByNodeName("osm3666040546", "osm3666040122", usetype: LinkUse.bldwall, comment: "yes15.link3");
            grc.AddLinkByNodeName("osm3666040549", "osm3666040546", usetype: LinkUse.bldwall, comment: "yes15.link4");
            grc.AddLinkByNodeName("osm3666040039", "osm3666040016", usetype: LinkUse.bldwall, comment: "yes16.link1");
            grc.AddLinkByNodeName("osm3666040040", "osm3666040039", usetype: LinkUse.bldwall, comment: "yes16.link2");
            grc.AddLinkByNodeName("osm3666040017", "osm3666040040", usetype: LinkUse.bldwall, comment: "yes16.link3");
            grc.AddLinkByNodeName("osm3666040016", "osm3666040017", usetype: LinkUse.bldwall, comment: "yes16.link4");
            grc.AddLinkByNodeName("osm3666040182", "osm3666040191", usetype: LinkUse.bldwall, comment: "yes17.link1");
            grc.AddLinkByNodeName("osm3666040251", "osm3666040182", usetype: LinkUse.bldwall, comment: "yes17.link2");
            grc.AddLinkByNodeName("osm3666040189", "osm3666040251", usetype: LinkUse.bldwall, comment: "yes17.link3");
            grc.AddLinkByNodeName("osm3666040191", "osm3666040189", usetype: LinkUse.bldwall, comment: "yes17.link4");
            grc.AddLinkByNodeName("osm3666040454", "osm3666040120", usetype: LinkUse.bldwall, comment: "yes18.link1");
            grc.AddLinkByNodeName("osm3666040456", "osm3666040454", usetype: LinkUse.bldwall, comment: "yes18.link2");
            grc.AddLinkByNodeName("osm3666040123", "osm3666040456", usetype: LinkUse.bldwall, comment: "yes18.link3");
            grc.AddLinkByNodeName("osm3666040120", "osm3666040123", usetype: LinkUse.bldwall, comment: "yes18.link4");
            grc.AddLinkByNodeName("osm3666040344", "osm3666040381", usetype: LinkUse.bldwall, comment: "yes19.link1");
            grc.AddLinkByNodeName("osm3666040345", "osm3666040344", usetype: LinkUse.bldwall, comment: "yes19.link2");
            grc.AddLinkByNodeName("osm3666029364", "osm3666040345", usetype: LinkUse.bldwall, comment: "yes19.link3");
            grc.AddLinkByNodeName("osm3666040381", "osm3666029364", usetype: LinkUse.bldwall, comment: "yes19.link4");
            grc.AddLinkByNodeName("osm3666040139", "osm3666040138", usetype: LinkUse.bldwall, comment: "yes20.link1");
            grc.AddLinkByNodeName("osm3666040225", "osm3666040139", usetype: LinkUse.bldwall, comment: "yes20.link2");
            grc.AddLinkByNodeName("osm3666040024", "osm3666040225", usetype: LinkUse.bldwall, comment: "yes20.link3");
            grc.AddLinkByNodeName("osm3666040138", "osm3666040024", usetype: LinkUse.bldwall, comment: "yes20.link4");
            grc.AddLinkByNodeName("osm3666040628", "osm3666040631", usetype: LinkUse.bldwall, comment: "yes21.link1");
            grc.AddLinkByNodeName("osm3666040626", "osm3666040628", usetype: LinkUse.bldwall, comment: "yes21.link2");
            grc.AddLinkByNodeName("osm3666040630", "osm3666040626", usetype: LinkUse.bldwall, comment: "yes21.link3");
            grc.AddLinkByNodeName("osm3666040631", "osm3666040630", usetype: LinkUse.bldwall, comment: "yes21.link4");
            grc.AddLinkByNodeName("osm3666040392", "osm3666040122", usetype: LinkUse.bldwall, comment: "yes22.link1");
            grc.AddLinkByNodeName("osm3666040393", "osm3666040392", usetype: LinkUse.bldwall, comment: "yes22.link2");
            grc.AddLinkByNodeName("osm3666040124", "osm3666040393", usetype: LinkUse.bldwall, comment: "yes22.link3");
            grc.AddLinkByNodeName("osm3666040122", "osm3666040124", usetype: LinkUse.bldwall, comment: "yes22.link4");
            grc.AddLinkByNodeName("osm3666040029", "osm3666040035", usetype: LinkUse.bldwall, comment: "yes23.link1");
            grc.AddLinkByNodeName("osm3666040030", "osm3666040029", usetype: LinkUse.bldwall, comment: "yes23.link2");
            grc.AddLinkByNodeName("osm3666039982", "osm3666040030", usetype: LinkUse.bldwall, comment: "yes23.link3");
            grc.AddLinkByNodeName("osm3666039983", "osm3666039982", usetype: LinkUse.bldwall, comment: "yes23.link4");
            grc.AddLinkByNodeName("osm3666040037", "osm3666039983", usetype: LinkUse.bldwall, comment: "yes23.link5");
            grc.AddLinkByNodeName("osm3666040035", "osm3666040037", usetype: LinkUse.bldwall, comment: "yes23.link6");
            grc.AddLinkByNodeName("osm3666040629", "osm3666040637", usetype: LinkUse.bldwall, comment: "yes24.link1");
            grc.AddLinkByNodeName("osm3666040630", "osm3666040629", usetype: LinkUse.bldwall, comment: "yes24.link2");
            grc.AddLinkByNodeName("osm3666040631", "osm3666040630", usetype: LinkUse.bldwall, comment: "yes24.link3");
            grc.AddLinkByNodeName("osm3666040632", "osm3666040631", usetype: LinkUse.bldwall, comment: "yes24.link4");
            grc.AddLinkByNodeName("osm3666040638", "osm3666040632", usetype: LinkUse.bldwall, comment: "yes24.link5");
            grc.AddLinkByNodeName("osm3666040637", "osm3666040638", usetype: LinkUse.bldwall, comment: "yes24.link6");
            grc.AddLinkByNodeName("osm3666040144", "osm3666040238", usetype: LinkUse.bldwall, comment: "yes25.link1");
            grc.AddLinkByNodeName("osm3666040145", "osm3666040144", usetype: LinkUse.bldwall, comment: "yes25.link2");
            grc.AddLinkByNodeName("osm3666040006", "osm3666040145", usetype: LinkUse.bldwall, comment: "yes25.link3");
            grc.AddLinkByNodeName("osm3666040010", "osm3666040006", usetype: LinkUse.bldwall, comment: "yes25.link4");
            grc.AddLinkByNodeName("osm3666040243", "osm3666040010", usetype: LinkUse.bldwall, comment: "yes25.link5");
            grc.AddLinkByNodeName("osm3666040238", "osm3666040243", usetype: LinkUse.bldwall, comment: "yes25.link6");
            grc.AddLinkByNodeName("osm2320845707", "osm3472027603", usetype: LinkUse.bldwall, comment: "yes26.link1");
            grc.AddLinkByNodeName("osm3472027605", "osm2320845707", usetype: LinkUse.bldwall, comment: "yes26.link2");
            grc.AddLinkByNodeName("osm3472027604", "osm3472027605", usetype: LinkUse.bldwall, comment: "yes26.link3");
            grc.AddLinkByNodeName("osm3666040459", "osm3472027604", usetype: LinkUse.bldwall, comment: "yes26.link4");
            grc.AddLinkByNodeName("osm5891623046", "osm3666040459", usetype: LinkUse.bldwall, comment: "yes26.link5");
            grc.AddLinkByNodeName("osm3666040460", "osm5891623046", usetype: LinkUse.bldwall, comment: "yes26.link6");
            grc.AddLinkByNodeName("osm3666040461", "osm3666040460", usetype: LinkUse.bldwall, comment: "yes26.link7");
            grc.AddLinkByNodeName("osm3472027608", "osm3666040461", usetype: LinkUse.bldwall, comment: "yes26.link8");
            grc.AddLinkByNodeName("osm3472027603", "osm3472027608", usetype: LinkUse.bldwall, comment: "yes26.link9");
            grc.AddLinkByNodeName("osm3666040196", "osm3666040261", usetype: LinkUse.bldwall, comment: "yes27.link1");
            grc.AddLinkByNodeName("osm3666040255", "osm3666040196", usetype: LinkUse.bldwall, comment: "yes27.link2");
            grc.AddLinkByNodeName("osm3666040048", "osm3666040255", usetype: LinkUse.bldwall, comment: "yes27.link3");
            grc.AddLinkByNodeName("osm3666040044", "osm3666040048", usetype: LinkUse.bldwall, comment: "yes27.link4");
            grc.AddLinkByNodeName("osm3666040183", "osm3666040044", usetype: LinkUse.bldwall, comment: "yes27.link5");
            grc.AddLinkByNodeName("osm3666040258", "osm3666040183", usetype: LinkUse.bldwall, comment: "yes27.link6");
            grc.AddLinkByNodeName("osm3666040288", "osm3666040258", usetype: LinkUse.bldwall, comment: "yes27.link7");
            grc.AddLinkByNodeName("osm3666040261", "osm3666040288", usetype: LinkUse.bldwall, comment: "yes27.link8");
            grc.AddLinkByNodeName("osm3666040299", "osm3666040298", usetype: LinkUse.bldwall, comment: "yes28.link1");
            grc.AddLinkByNodeName("osm3666040191", "osm3666040299", usetype: LinkUse.bldwall, comment: "yes28.link2");
            grc.AddLinkByNodeName("osm3666040189", "osm3666040191", usetype: LinkUse.bldwall, comment: "yes28.link3");
            grc.AddLinkByNodeName("osm3666040188", "osm3666040189", usetype: LinkUse.bldwall, comment: "yes28.link4");
            grc.AddLinkByNodeName("osm3666040215", "osm3666040188", usetype: LinkUse.bldwall, comment: "yes28.link5");
            grc.AddLinkByNodeName("osm3666040219", "osm3666040215", usetype: LinkUse.bldwall, comment: "yes28.link6");
            grc.AddLinkByNodeName("osm3666040297", "osm3666040219", usetype: LinkUse.bldwall, comment: "yes28.link7");
            grc.AddLinkByNodeName("osm3666040298", "osm3666040297", usetype: LinkUse.bldwall, comment: "yes28.link8");
            grc.AddLinkByNodeName("osm3666040319", "osm3666040368", usetype: LinkUse.bldwall, comment: "yes29.link1");
            grc.AddLinkByNodeName("osm3666040214", "osm3666040319", usetype: LinkUse.bldwall, comment: "yes29.link2");
            grc.AddLinkByNodeName("osm3666040215", "osm3666040214", usetype: LinkUse.bldwall, comment: "yes29.link3");
            grc.AddLinkByNodeName("osm3666040219", "osm3666040215", usetype: LinkUse.bldwall, comment: "yes29.link4");
            grc.AddLinkByNodeName("osm3666040297", "osm3666040219", usetype: LinkUse.bldwall, comment: "yes29.link5");
            grc.AddLinkByNodeName("osm3666040298", "osm3666040297", usetype: LinkUse.bldwall, comment: "yes29.link6");
            grc.AddLinkByNodeName("osm3666040369", "osm3666040298", usetype: LinkUse.bldwall, comment: "yes29.link7");
            grc.AddLinkByNodeName("osm3666040368", "osm3666040369", usetype: LinkUse.bldwall, comment: "yes29.link8");
            grc.AddLinkByNodeName("osm3666040547", "osm3666040541", usetype: LinkUse.bldwall, comment: "yes30.link1");
            grc.AddLinkByNodeName("osm3666040556", "osm3666040547", usetype: LinkUse.bldwall, comment: "yes30.link2");
            grc.AddLinkByNodeName("osm3666040535", "osm3666040556", usetype: LinkUse.bldwall, comment: "yes30.link3");
            grc.AddLinkByNodeName("osm3666040537", "osm3666040535", usetype: LinkUse.bldwall, comment: "yes30.link4");
            grc.AddLinkByNodeName("osm3666040531", "osm3666040537", usetype: LinkUse.bldwall, comment: "yes30.link5");
            grc.AddLinkByNodeName("osm3666040527", "osm3666040531", usetype: LinkUse.bldwall, comment: "yes30.link6");
            grc.AddLinkByNodeName("osm3177098466", "osm3666040527", usetype: LinkUse.bldwall, comment: "yes30.link7");
            grc.AddLinkByNodeName("osm3666040541", "osm3177098466", usetype: LinkUse.bldwall, comment: "yes30.link8");
            grc.AddLinkByNodeName("osm3666040627", "osm3666040633", usetype: LinkUse.bldwall, comment: "yes31.link1");
            grc.AddLinkByNodeName("osm3666040625", "osm3666040627", usetype: LinkUse.bldwall, comment: "yes31.link2");
            grc.AddLinkByNodeName("osm3666040620", "osm3666040625", usetype: LinkUse.bldwall, comment: "yes31.link3");
            grc.AddLinkByNodeName("osm3666040621", "osm3666040620", usetype: LinkUse.bldwall, comment: "yes31.link4");
            grc.AddLinkByNodeName("osm3666040618", "osm3666040621", usetype: LinkUse.bldwall, comment: "yes31.link5");
            grc.AddLinkByNodeName("osm3666040619", "osm3666040618", usetype: LinkUse.bldwall, comment: "yes31.link6");
            grc.AddLinkByNodeName("osm3666040634", "osm3666040619", usetype: LinkUse.bldwall, comment: "yes31.link7");
            grc.AddLinkByNodeName("osm3666040633", "osm3666040634", usetype: LinkUse.bldwall, comment: "yes31.link8");
            grc.AddLinkByNodeName("osm3666431794", "osm3666431790", usetype: LinkUse.bldwall, comment: "yes32.link1");
            grc.AddLinkByNodeName("osm3666431678", "osm3666431794", usetype: LinkUse.bldwall, comment: "yes32.link2");
            grc.AddLinkByNodeName("osm3666431899", "osm3666431678", usetype: LinkUse.bldwall, comment: "yes32.link3");
            grc.AddLinkByNodeName("osm3666431681", "osm3666431899", usetype: LinkUse.bldwall, comment: "yes32.link4");
            grc.AddLinkByNodeName("osm3666431897", "osm3666431681", usetype: LinkUse.bldwall, comment: "yes32.link5");
            grc.AddLinkByNodeName("osm3666431907", "osm3666431897", usetype: LinkUse.bldwall, comment: "yes32.link6");
            grc.AddLinkByNodeName("osm3666431914", "osm3666431907", usetype: LinkUse.bldwall, comment: "yes32.link7");
            grc.AddLinkByNodeName("osm3666431801", "osm3666431914", usetype: LinkUse.bldwall, comment: "yes32.link8");
            grc.AddLinkByNodeName("osm3666431917", "osm3666431801", usetype: LinkUse.bldwall, comment: "yes32.link9");
            grc.AddLinkByNodeName("osm3666431912", "osm3666431917", usetype: LinkUse.bldwall, comment: "yes32.link10");
            grc.AddLinkByNodeName("osm3666431919", "osm3666431912", usetype: LinkUse.bldwall, comment: "yes32.link11");
            grc.AddLinkByNodeName("osm3666431805", "osm3666431919", usetype: LinkUse.bldwall, comment: "yes32.link12");
            grc.AddLinkByNodeName("osm3666431771", "osm3666431805", usetype: LinkUse.bldwall, comment: "yes32.link13");
            grc.AddLinkByNodeName("osm3666431875", "osm3666431771", usetype: LinkUse.bldwall, comment: "yes32.link14");
            grc.AddLinkByNodeName("osm3666431853", "osm3666431875", usetype: LinkUse.bldwall, comment: "yes32.link15");
            grc.AddLinkByNodeName("osm3666431790", "osm3666431853", usetype: LinkUse.bldwall, comment: "yes32.link16");
            grc.AddLinkByNodeName("osm3666431884", "osm3666431771", usetype: LinkUse.bldwall, comment: "yes33.link1");
            grc.AddLinkByNodeName("osm3666431924", "osm3666431884", usetype: LinkUse.bldwall, comment: "yes33.link2");
            grc.AddLinkByNodeName("osm3666431805", "osm3666431924", usetype: LinkUse.bldwall, comment: "yes33.link3");
            grc.AddLinkByNodeName("osm3666431771", "osm3666431805", usetype: LinkUse.bldwall, comment: "yes33.link4");
            grc.AddLinkByNodeName("osm3666431635", "osm3666431744", usetype: LinkUse.bldwall, comment: "yes34.link1");
            grc.AddLinkByNodeName("osm3666430514", "osm3666431635", usetype: LinkUse.bldwall, comment: "yes34.link2");
            grc.AddLinkByNodeName("osm3666431828", "osm3666430514", usetype: LinkUse.bldwall, comment: "yes34.link3");
            grc.AddLinkByNodeName("osm3666431744", "osm3666431828", usetype: LinkUse.bldwall, comment: "yes34.link4");
            grc.AddLinkByNodeName("osm3666431642", "osm3666431768", usetype: LinkUse.bldwall, comment: "yes35.link1");
            grc.AddLinkByNodeName("osm3666430524", "osm3666431642", usetype: LinkUse.bldwall, comment: "yes35.link2");
            grc.AddLinkByNodeName("osm3666431882", "osm3666430524", usetype: LinkUse.bldwall, comment: "yes35.link3");
            grc.AddLinkByNodeName("osm3666431768", "osm3666431882", usetype: LinkUse.bldwall, comment: "yes35.link4");
            grc.AddLinkByNodeName("osm3666431757", "osm3666431669", usetype: LinkUse.bldwall, comment: "yes36.link1");
            grc.AddLinkByNodeName("osm3666431785", "osm3666431757", usetype: LinkUse.bldwall, comment: "yes36.link2");
            grc.AddLinkByNodeName("osm3666431893", "osm3666431785", usetype: LinkUse.bldwall, comment: "yes36.link3");
            grc.AddLinkByNodeName("osm3666428305", "osm3666431893", usetype: LinkUse.bldwall, comment: "yes36.link4");
            grc.AddLinkByNodeName("osm3666431669", "osm3666428305", usetype: LinkUse.bldwall, comment: "yes36.link5");
            grc.AddLinkByNodeName("osm3666431826", "osm3666431645", usetype: LinkUse.bldwall, comment: "yes37.link1");
            grc.AddLinkByNodeName("osm3666430495", "osm3666431826", usetype: LinkUse.bldwall, comment: "yes37.link2");
            grc.AddLinkByNodeName("osm3666430483", "osm3666430495", usetype: LinkUse.bldwall, comment: "yes37.link3");
            grc.AddLinkByNodeName("osm3666431009", "osm3666430483", usetype: LinkUse.bldwall, comment: "yes37.link4");
            grc.AddLinkByNodeName("osm3666431645", "osm3666431009", usetype: LinkUse.bldwall, comment: "yes37.link5");
            grc.AddLinkByNodeName("osm3666431744", "osm3666430524", usetype: LinkUse.bldwall, comment: "yes38.link1");
            grc.AddLinkByNodeName("osm3666431669", "osm3666431744", usetype: LinkUse.bldwall, comment: "yes38.link2");
            grc.AddLinkByNodeName("osm3666428305", "osm3666431669", usetype: LinkUse.bldwall, comment: "yes38.link3");
            grc.AddLinkByNodeName("osm3666431882", "osm3666428305", usetype: LinkUse.bldwall, comment: "yes38.link4");
            grc.AddLinkByNodeName("osm3666430524", "osm3666431882", usetype: LinkUse.bldwall, comment: "yes38.link5");
            grc.AddLinkByNodeName("osm3666431853", "osm3666428292", usetype: LinkUse.bldwall, comment: "yes39.link1");
            grc.AddLinkByNodeName("osm3666431790", "osm3666431853", usetype: LinkUse.bldwall, comment: "yes39.link2");
            grc.AddLinkByNodeName("osm3666431684", "osm3666431790", usetype: LinkUse.bldwall, comment: "yes39.link3");
            grc.AddLinkByNodeName("osm3666431793", "osm3666431684", usetype: LinkUse.bldwall, comment: "yes39.link4");
            grc.AddLinkByNodeName("osm3666430509", "osm3666431793", usetype: LinkUse.bldwall, comment: "yes39.link5");
            grc.AddLinkByNodeName("osm3666428292", "osm3666430509", usetype: LinkUse.bldwall, comment: "yes39.link6");
            grc.AddLinkByNodeName("osm3666431650", "osm3666431826", usetype: LinkUse.bldwall, comment: "yes40.link1");
            grc.AddLinkByNodeName("osm3666431839", "osm3666431650", usetype: LinkUse.bldwall, comment: "yes40.link2");
            grc.AddLinkByNodeName("osm3666428293", "osm3666431839", usetype: LinkUse.bldwall, comment: "yes40.link3");
            grc.AddLinkByNodeName("osm3666430504", "osm3666428293", usetype: LinkUse.bldwall, comment: "yes40.link4");
            grc.AddLinkByNodeName("osm3666430495", "osm3666430504", usetype: LinkUse.bldwall, comment: "yes40.link5");
            grc.AddLinkByNodeName("osm3666431826", "osm3666430495", usetype: LinkUse.bldwall, comment: "yes40.link6");
            grc.AddLinkByNodeName("osm3666431809", "osm3666431924", usetype: LinkUse.bldwall, comment: "yes41.link1");
            grc.AddLinkByNodeName("osm3666431934", "osm3666431809", usetype: LinkUse.bldwall, comment: "yes41.link2");
            grc.AddLinkByNodeName("osm3666431782", "osm3666431934", usetype: LinkUse.bldwall, comment: "yes41.link3");
            grc.AddLinkByNodeName("osm3666431879", "osm3666431782", usetype: LinkUse.bldwall, comment: "yes41.link4");
            grc.AddLinkByNodeName("osm3666431884", "osm3666431879", usetype: LinkUse.bldwall, comment: "yes41.link5");
            grc.AddLinkByNodeName("osm3666431924", "osm3666431884", usetype: LinkUse.bldwall, comment: "yes41.link6");
            grc.AddLinkByNodeName("osm3666466823", "osm3666466070", usetype: LinkUse.bldwall, comment: "yes42.link1");
            grc.AddLinkByNodeName("osm3666466820", "osm3666466823", usetype: LinkUse.bldwall, comment: "yes42.link2");
            grc.AddLinkByNodeName("osm3666466817", "osm3666466820", usetype: LinkUse.bldwall, comment: "yes42.link3");
            grc.AddLinkByNodeName("osm3666466818", "osm3666466817", usetype: LinkUse.bldwall, comment: "yes42.link4");
            grc.AddLinkByNodeName("osm3666466814", "osm3666466818", usetype: LinkUse.bldwall, comment: "yes42.link5");
            grc.AddLinkByNodeName("osm3666466812", "osm3666466814", usetype: LinkUse.bldwall, comment: "yes42.link6");
            grc.AddLinkByNodeName("osm3666466810", "osm3666466812", usetype: LinkUse.bldwall, comment: "yes42.link7");
            grc.AddLinkByNodeName("osm3666466791", "osm3666466810", usetype: LinkUse.bldwall, comment: "yes42.link8");
            grc.AddLinkByNodeName("osm3666466803", "osm3666466791", usetype: LinkUse.bldwall, comment: "yes42.link9");
            grc.AddLinkByNodeName("osm3666466801", "osm3666466803", usetype: LinkUse.bldwall, comment: "yes42.link10");
            grc.AddLinkByNodeName("osm3666466806", "osm3666466801", usetype: LinkUse.bldwall, comment: "yes42.link11");
            grc.AddLinkByNodeName("osm3666466804", "osm3666466806", usetype: LinkUse.bldwall, comment: "yes42.link12");
            grc.AddLinkByNodeName("osm3666466808", "osm3666466804", usetype: LinkUse.bldwall, comment: "yes42.link13");
            grc.AddLinkByNodeName("osm3666466807", "osm3666466808", usetype: LinkUse.bldwall, comment: "yes42.link14");
            grc.AddLinkByNodeName("osm3666466813", "osm3666466807", usetype: LinkUse.bldwall, comment: "yes42.link15");
            grc.AddLinkByNodeName("osm3666466070", "osm3666466813", usetype: LinkUse.bldwall, comment: "yes42.link16");
            grc.AddLinkByNodeName("osm3666466807", "osm3666466813", usetype: LinkUse.bldwall, comment: "yes43.link1");
            grc.AddLinkByNodeName("osm3666466802", "osm3666466807", usetype: LinkUse.bldwall, comment: "yes43.link2");
            grc.AddLinkByNodeName("osm3666466794", "osm3666466802", usetype: LinkUse.bldwall, comment: "yes43.link3");
            grc.AddLinkByNodeName("osm3666466800", "osm3666466794", usetype: LinkUse.bldwall, comment: "yes43.link4");
            grc.AddLinkByNodeName("osm3666466787", "osm3666466800", usetype: LinkUse.bldwall, comment: "yes43.link5");
            grc.AddLinkByNodeName("osm3666468623", "osm3666466787", usetype: LinkUse.bldwall, comment: "yes43.link6");
            grc.AddLinkByNodeName("osm3666468618", "osm3666468623", usetype: LinkUse.bldwall, comment: "yes43.link7");
            grc.AddLinkByNodeName("osm3666468595", "osm3666468618", usetype: LinkUse.bldwall, comment: "yes43.link8");
            grc.AddLinkByNodeName("osm3666468605", "osm3666468595", usetype: LinkUse.bldwall, comment: "yes43.link9");
            grc.AddLinkByNodeName("osm3666468602", "osm3666468605", usetype: LinkUse.bldwall, comment: "yes43.link10");
            grc.AddLinkByNodeName("osm3666467905", "osm3666468602", usetype: LinkUse.bldwall, comment: "yes43.link11");
            grc.AddLinkByNodeName("osm3666468613", "osm3666467905", usetype: LinkUse.bldwall, comment: "yes43.link12");
            grc.AddLinkByNodeName("osm3666467907", "osm3666468613", usetype: LinkUse.bldwall, comment: "yes43.link13");
            grc.AddLinkByNodeName("osm3666467906", "osm3666467907", usetype: LinkUse.bldwall, comment: "yes43.link14");
            grc.AddLinkByNodeName("osm3666466786", "osm3666467906", usetype: LinkUse.bldwall, comment: "yes43.link15");
            grc.AddLinkByNodeName("osm3666466813", "osm3666466786", usetype: LinkUse.bldwall, comment: "yes43.link16");
            grc.AddLinkByNodeName("osm3666467906", "osm3666466786", usetype: LinkUse.bldwall, comment: "yes44.link1");
            grc.AddLinkByNodeName("osm3666468606", "osm3666467906", usetype: LinkUse.bldwall, comment: "yes44.link2");
            grc.AddLinkByNodeName("osm3666468596", "osm3666468606", usetype: LinkUse.bldwall, comment: "yes44.link3");
            grc.AddLinkByNodeName("osm3666468599", "osm3666468596", usetype: LinkUse.bldwall, comment: "yes44.link4");
            grc.AddLinkByNodeName("osm3666468589", "osm3666468599", usetype: LinkUse.bldwall, comment: "yes44.link5");
            grc.AddLinkByNodeName("osm3666468584", "osm3666468589", usetype: LinkUse.bldwall, comment: "yes44.link6");
            grc.AddLinkByNodeName("osm3666467902", "osm3666468584", usetype: LinkUse.bldwall, comment: "yes44.link7");
            grc.AddLinkByNodeName("osm3666467881", "osm3666467902", usetype: LinkUse.bldwall, comment: "yes44.link8");
            grc.AddLinkByNodeName("osm3666467886", "osm3666467881", usetype: LinkUse.bldwall, comment: "yes44.link9");
            grc.AddLinkByNodeName("osm3666467883", "osm3666467886", usetype: LinkUse.bldwall, comment: "yes44.link10");
            grc.AddLinkByNodeName("osm3666467889", "osm3666467883", usetype: LinkUse.bldwall, comment: "yes44.link11");
            grc.AddLinkByNodeName("osm3666467888", "osm3666467889", usetype: LinkUse.bldwall, comment: "yes44.link12");
            grc.AddLinkByNodeName("osm3666467897", "osm3666467888", usetype: LinkUse.bldwall, comment: "yes44.link13");
            grc.AddLinkByNodeName("osm3666467891", "osm3666467897", usetype: LinkUse.bldwall, comment: "yes44.link14");
            grc.AddLinkByNodeName("osm3666468587", "osm3666467891", usetype: LinkUse.bldwall, comment: "yes44.link15");
            grc.AddLinkByNodeName("osm3666466786", "osm3666468587", usetype: LinkUse.bldwall, comment: "yes44.link16");
            grc.AddLinkByNodeName("osm3666468608", "osm3666468607", usetype: LinkUse.bldwall, comment: "yes45.link1");
            grc.AddLinkByNodeName("osm3666468600", "osm3666468608", usetype: LinkUse.bldwall, comment: "yes45.link2");
            grc.AddLinkByNodeName("osm3666468604", "osm3666468600", usetype: LinkUse.bldwall, comment: "yes45.link3");
            grc.AddLinkByNodeName("osm3666468597", "osm3666468604", usetype: LinkUse.bldwall, comment: "yes45.link4");
            grc.AddLinkByNodeName("osm3666468588", "osm3666468597", usetype: LinkUse.bldwall, comment: "yes45.link5");
            grc.AddLinkByNodeName("osm3666468585", "osm3666468588", usetype: LinkUse.bldwall, comment: "yes45.link6");
            grc.AddLinkByNodeName("osm3666467890", "osm3666468585", usetype: LinkUse.bldwall, comment: "yes45.link7");
            grc.AddLinkByNodeName("osm3666467896", "osm3666467890", usetype: LinkUse.bldwall, comment: "yes45.link8");
            grc.AddLinkByNodeName("osm3666467882", "osm3666467896", usetype: LinkUse.bldwall, comment: "yes45.link9");
            grc.AddLinkByNodeName("osm3666467887", "osm3666467882", usetype: LinkUse.bldwall, comment: "yes45.link10");
            grc.AddLinkByNodeName("osm3666467900", "osm3666467887", usetype: LinkUse.bldwall, comment: "yes45.link11");
            grc.AddLinkByNodeName("osm3666467901", "osm3666467900", usetype: LinkUse.bldwall, comment: "yes45.link12");
            grc.AddLinkByNodeName("osm3666468586", "osm3666467901", usetype: LinkUse.bldwall, comment: "yes45.link13");
            grc.AddLinkByNodeName("osm3666467903", "osm3666468586", usetype: LinkUse.bldwall, comment: "yes45.link14");
            grc.AddLinkByNodeName("osm3666468601", "osm3666467903", usetype: LinkUse.bldwall, comment: "yes45.link15");
            grc.AddLinkByNodeName("osm3666468598", "osm3666468601", usetype: LinkUse.bldwall, comment: "yes45.link16");
            grc.AddLinkByNodeName("osm3666468607", "osm3666468598", usetype: LinkUse.bldwall, comment: "yes45.link17");
            grc.AddLinkByNodeName("osm3666466079", "osm3666466098", usetype: LinkUse.bldwall, comment: "yes46.link1");
            grc.AddLinkByNodeName("osm3666466078", "osm3666466079", usetype: LinkUse.bldwall, comment: "yes46.link2");
            grc.AddLinkByNodeName("osm3666469265", "osm3666466078", usetype: LinkUse.bldwall, comment: "yes46.link3");
            grc.AddLinkByNodeName("osm3666469266", "osm3666469265", usetype: LinkUse.bldwall, comment: "yes46.link4");
            grc.AddLinkByNodeName("osm3666469335", "osm3666469266", usetype: LinkUse.bldwall, comment: "yes46.link5");
            grc.AddLinkByNodeName("osm3666469334", "osm3666469335", usetype: LinkUse.bldwall, comment: "yes46.link6");
            grc.AddLinkByNodeName("osm3666469247", "osm3666469334", usetype: LinkUse.bldwall, comment: "yes46.link7");
            grc.AddLinkByNodeName("osm3666469248", "osm3666469247", usetype: LinkUse.bldwall, comment: "yes46.link8");
            grc.AddLinkByNodeName("osm3666469239", "osm3666469248", usetype: LinkUse.bldwall, comment: "yes46.link9");
            grc.AddLinkByNodeName("osm3666469238", "osm3666469239", usetype: LinkUse.bldwall, comment: "yes46.link10");
            grc.AddLinkByNodeName("osm3666469328", "osm3666469238", usetype: LinkUse.bldwall, comment: "yes46.link11");
            grc.AddLinkByNodeName("osm3666469329", "osm3666469328", usetype: LinkUse.bldwall, comment: "yes46.link12");
            grc.AddLinkByNodeName("osm3666469232", "osm3666469329", usetype: LinkUse.bldwall, comment: "yes46.link13");
            grc.AddLinkByNodeName("osm3666469230", "osm3666469232", usetype: LinkUse.bldwall, comment: "yes46.link14");
            grc.AddLinkByNodeName("osm3666469136", "osm3666469230", usetype: LinkUse.bldwall, comment: "yes46.link15");
            grc.AddLinkByNodeName("osm3666469139", "osm3666469136", usetype: LinkUse.bldwall, comment: "yes46.link16");
            grc.AddLinkByNodeName("osm3666469144", "osm3666469139", usetype: LinkUse.bldwall, comment: "yes46.link17");
            grc.AddLinkByNodeName("osm3666469145", "osm3666469144", usetype: LinkUse.bldwall, comment: "yes46.link18");
            grc.AddLinkByNodeName("osm3666466099", "osm3666469145", usetype: LinkUse.bldwall, comment: "yes46.link19");
            grc.AddLinkByNodeName("osm3666466098", "osm3666466099", usetype: LinkUse.bldwall, comment: "yes46.link20");
            grc.AddLinkByNodeName("osm3666469286", "osm3666469280", usetype: LinkUse.bldwall, comment: "yes47.link1");
            grc.AddLinkByNodeName("osm3666469285", "osm3666469286", usetype: LinkUse.bldwall, comment: "yes47.link2");
            grc.AddLinkByNodeName("osm3666469290", "osm3666469285", usetype: LinkUse.bldwall, comment: "yes47.link3");
            grc.AddLinkByNodeName("osm3666469289", "osm3666469290", usetype: LinkUse.bldwall, comment: "yes47.link4");
            grc.AddLinkByNodeName("osm3666469284", "osm3666469289", usetype: LinkUse.bldwall, comment: "yes47.link5");
            grc.AddLinkByNodeName("osm3666469169", "osm3666469284", usetype: LinkUse.bldwall, comment: "yes47.link6");
            grc.AddLinkByNodeName("osm3666469170", "osm3666469169", usetype: LinkUse.bldwall, comment: "yes47.link7");
            grc.AddLinkByNodeName("osm3666469293", "osm3666469170", usetype: LinkUse.bldwall, comment: "yes47.link8");
            grc.AddLinkByNodeName("osm3666469166", "osm3666469293", usetype: LinkUse.bldwall, comment: "yes47.link9");
            grc.AddLinkByNodeName("osm3666469165", "osm3666469166", usetype: LinkUse.bldwall, comment: "yes47.link10");
            grc.AddLinkByNodeName("osm3666469168", "osm3666469165", usetype: LinkUse.bldwall, comment: "yes47.link11");
            grc.AddLinkByNodeName("osm3666469167", "osm3666469168", usetype: LinkUse.bldwall, comment: "yes47.link12");
            grc.AddLinkByNodeName("osm3666469164", "osm3666469167", usetype: LinkUse.bldwall, comment: "yes47.link13");
            grc.AddLinkByNodeName("osm3666469162", "osm3666469164", usetype: LinkUse.bldwall, comment: "yes47.link14");
            grc.AddLinkByNodeName("osm3666469288", "osm3666469162", usetype: LinkUse.bldwall, comment: "yes47.link15");
            grc.AddLinkByNodeName("osm3666469287", "osm3666469288", usetype: LinkUse.bldwall, comment: "yes47.link16");
            grc.AddLinkByNodeName("osm3666469163", "osm3666469287", usetype: LinkUse.bldwall, comment: "yes47.link17");
            grc.AddLinkByNodeName("osm3666469161", "osm3666469163", usetype: LinkUse.bldwall, comment: "yes47.link18");
            grc.AddLinkByNodeName("osm3666466085", "osm3666469161", usetype: LinkUse.bldwall, comment: "yes47.link19");
            grc.AddLinkByNodeName("osm3666466087", "osm3666466085", usetype: LinkUse.bldwall, comment: "yes47.link20");
            grc.AddLinkByNodeName("osm3666466094", "osm3666466087", usetype: LinkUse.bldwall, comment: "yes47.link21");
            grc.AddLinkByNodeName("osm3666466095", "osm3666466094", usetype: LinkUse.bldwall, comment: "yes47.link22");
            grc.AddLinkByNodeName("osm3666466097", "osm3666466095", usetype: LinkUse.bldwall, comment: "yes47.link23");
            grc.AddLinkByNodeName("osm3666466098", "osm3666466097", usetype: LinkUse.bldwall, comment: "yes47.link24");
            grc.AddLinkByNodeName("osm3666466099", "osm3666466098", usetype: LinkUse.bldwall, comment: "yes47.link25");
            grc.AddLinkByNodeName("osm3666466100", "osm3666466099", usetype: LinkUse.bldwall, comment: "yes47.link26");
            grc.AddLinkByNodeName("osm3666469280", "osm3666466100", usetype: LinkUse.bldwall, comment: "yes47.link27");
            grc.AddLinkByNodeName("osm3666467911", "osm3666467912", usetype: LinkUse.bldwall, comment: "yes48.link1");
            grc.AddLinkByNodeName("osm3666466796", "osm3666467911", usetype: LinkUse.bldwall, comment: "yes48.link2");
            grc.AddLinkByNodeName("osm3666466797", "osm3666466796", usetype: LinkUse.bldwall, comment: "yes48.link3");
            grc.AddLinkByNodeName("osm3666467912", "osm3666466797", usetype: LinkUse.bldwall, comment: "yes48.link4");
            grc.AddLinkByNodeName("osm3666467915", "osm3666467916", usetype: LinkUse.bldwall, comment: "yes49.link1");
            grc.AddLinkByNodeName("osm3666467923", "osm3666467915", usetype: LinkUse.bldwall, comment: "yes49.link2");
            grc.AddLinkByNodeName("osm3666469138", "osm3666467923", usetype: LinkUse.bldwall, comment: "yes49.link3");
            grc.AddLinkByNodeName("osm3666467916", "osm3666469138", usetype: LinkUse.bldwall, comment: "yes49.link4");
            grc.AddLinkByNodeName("osm3666467893", "osm3666467892", usetype: LinkUse.bldwall, comment: "yes50.link1");
            grc.AddLinkByNodeName("osm3666467894", "osm3666467893", usetype: LinkUse.bldwall, comment: "yes50.link2");
            grc.AddLinkByNodeName("osm3666468594", "osm3666467894", usetype: LinkUse.bldwall, comment: "yes50.link3");
            grc.AddLinkByNodeName("osm3666468593", "osm3666468594", usetype: LinkUse.bldwall, comment: "yes50.link4");
            grc.AddLinkByNodeName("osm3666467892", "osm3666468593", usetype: LinkUse.bldwall, comment: "yes50.link5");
            grc.AddLinkByNodeName("osm3666467895", "osm3666467894", usetype: LinkUse.bldwall, comment: "yes51.link1");
            grc.AddLinkByNodeName("osm3666467880", "osm3666467895", usetype: LinkUse.bldwall, comment: "yes51.link2");
            grc.AddLinkByNodeName("osm3666467879", "osm3666467880", usetype: LinkUse.bldwall, comment: "yes51.link3");
            grc.AddLinkByNodeName("osm3666467884", "osm3666467879", usetype: LinkUse.bldwall, comment: "yes51.link4");
            grc.AddLinkByNodeName("osm3666467885", "osm3666467884", usetype: LinkUse.bldwall, comment: "yes51.link5");
            grc.AddLinkByNodeName("osm3666467893", "osm3666467885", usetype: LinkUse.bldwall, comment: "yes51.link6");
            grc.AddLinkByNodeName("osm3666467894", "osm3666467893", usetype: LinkUse.bldwall, comment: "yes51.link7");
            grc.AddLinkByNodeName("osm3666466785", "osm3666467874", usetype: LinkUse.bldwall, comment: "yes52.link1");
            grc.AddLinkByNodeName("osm3666466784", "osm3666466785", usetype: LinkUse.bldwall, comment: "yes52.link2");
            grc.AddLinkByNodeName("osm3666466783", "osm3666466784", usetype: LinkUse.bldwall, comment: "yes52.link3");
            grc.AddLinkByNodeName("osm3666467875", "osm3666466783", usetype: LinkUse.bldwall, comment: "yes52.link4");
            grc.AddLinkByNodeName("osm3666467877", "osm3666467875", usetype: LinkUse.bldwall, comment: "yes52.link5");
            grc.AddLinkByNodeName("osm3666467876", "osm3666467877", usetype: LinkUse.bldwall, comment: "yes52.link6");
            grc.AddLinkByNodeName("osm3666467878", "osm3666467876", usetype: LinkUse.bldwall, comment: "yes52.link7");
            grc.AddLinkByNodeName("osm3666467874", "osm3666467878", usetype: LinkUse.bldwall, comment: "yes52.link8");
            grc.AddLinkByNodeName("osm3666999332", "osm3666999124", usetype: LinkUse.bldwall, comment: "yes53.link1");
            grc.AddLinkByNodeName("osm3666999116", "osm3666999332", usetype: LinkUse.bldwall, comment: "yes53.link2");
            grc.AddLinkByNodeName("osm3666999110", "osm3666999116", usetype: LinkUse.bldwall, comment: "yes53.link3");
            grc.AddLinkByNodeName("osm3666999124", "osm3666999110", usetype: LinkUse.bldwall, comment: "yes53.link4");
            grc.AddLinkByNodeName("osm3666999088", "osm3666999086", usetype: LinkUse.bldwall, comment: "yes54.link1");
            grc.AddLinkByNodeName("osm3666999078", "osm3666999088", usetype: LinkUse.bldwall, comment: "yes54.link2");
            grc.AddLinkByNodeName("osm3666999077", "osm3666999078", usetype: LinkUse.bldwall, comment: "yes54.link3");
            grc.AddLinkByNodeName("osm3666999086", "osm3666999077", usetype: LinkUse.bldwall, comment: "yes54.link4");
            grc.AddLinkByNodeName("osm3666999043", "osm3666999052", usetype: LinkUse.bldwall, comment: "terrace01.link1");
            grc.AddLinkByNodeName("osm3666999044", "osm3666999043", usetype: LinkUse.bldwall, comment: "terrace01.link2");
            grc.AddLinkByNodeName("osm3666999053", "osm3666999044", usetype: LinkUse.bldwall, comment: "terrace01.link3");
            grc.AddLinkByNodeName("osm3666999052", "osm3666999053", usetype: LinkUse.bldwall, comment: "terrace01.link4");
            grc.AddLinkByNodeName("osm3666999153", "osm3666999065", usetype: LinkUse.bldwall, comment: "terrace02.link1");
            grc.AddLinkByNodeName("osm3666999077", "osm3666999153", usetype: LinkUse.bldwall, comment: "terrace02.link2");
            grc.AddLinkByNodeName("osm3666999086", "osm3666999077", usetype: LinkUse.bldwall, comment: "terrace02.link3");
            grc.AddLinkByNodeName("osm3666999082", "osm3666999086", usetype: LinkUse.bldwall, comment: "terrace02.link4");
            grc.AddLinkByNodeName("osm3666999065", "osm3666999082", usetype: LinkUse.bldwall, comment: "terrace02.link5");
            grc.AddLinkByNodeName("osm3666999095", "osm3666999111", usetype: LinkUse.bldwall, comment: "yes55.link1");
            grc.AddLinkByNodeName("osm3666999185", "osm3666999095", usetype: LinkUse.bldwall, comment: "yes55.link2");
            grc.AddLinkByNodeName("osm3666999110", "osm3666999185", usetype: LinkUse.bldwall, comment: "yes55.link3");
            grc.AddLinkByNodeName("osm3666999124", "osm3666999110", usetype: LinkUse.bldwall, comment: "yes55.link4");
            grc.AddLinkByNodeName("osm3666999111", "osm3666999124", usetype: LinkUse.bldwall, comment: "yes55.link5");
            grc.AddLinkByNodeName("osm3666999031", "osm3666999043", usetype: LinkUse.bldwall, comment: "terrace03.link1");
            grc.AddLinkByNodeName("osm3666999033", "osm3666999031", usetype: LinkUse.bldwall, comment: "terrace03.link2");
            grc.AddLinkByNodeName("osm3666999039", "osm3666999033", usetype: LinkUse.bldwall, comment: "terrace03.link3");
            grc.AddLinkByNodeName("osm3666997221", "osm3666999039", usetype: LinkUse.bldwall, comment: "terrace03.link4");
            grc.AddLinkByNodeName("osm3666999046", "osm3666997221", usetype: LinkUse.bldwall, comment: "terrace03.link5");
            grc.AddLinkByNodeName("osm3666999044", "osm3666999046", usetype: LinkUse.bldwall, comment: "terrace03.link6");
            grc.AddLinkByNodeName("osm3666999043", "osm3666999044", usetype: LinkUse.bldwall, comment: "terrace03.link7");
            grc.AddLinkByNodeName("osm3666999129", "osm3666991854", usetype: LinkUse.bldwall, comment: "yes56.link1");
            grc.AddLinkByNodeName("osm3666999128", "osm3666999129", usetype: LinkUse.bldwall, comment: "yes56.link2");
            grc.AddLinkByNodeName("osm3666998822", "osm3666999128", usetype: LinkUse.bldwall, comment: "yes56.link3");
            grc.AddLinkByNodeName("osm3666999029", "osm3666998822", usetype: LinkUse.bldwall, comment: "yes56.link4");
            grc.AddLinkByNodeName("osm3666999127", "osm3666999029", usetype: LinkUse.bldwall, comment: "yes56.link5");
            grc.AddLinkByNodeName("osm3666999125", "osm3666999127", usetype: LinkUse.bldwall, comment: "yes56.link6");
            grc.AddLinkByNodeName("osm3666991853", "osm3666999125", usetype: LinkUse.bldwall, comment: "yes56.link7");
            grc.AddLinkByNodeName("osm3666991854", "osm3666991853", usetype: LinkUse.bldwall, comment: "yes56.link8");
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
        }


        public void CreateGraphForOsmImport_eb12_orig()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("eb12-streets", "blue", saveToFile: true);
            grc.AddNodePtxz("osm33702042", 130.814, 284.477);
            grc.AddNodePtxz("osm738283752", 124.605, 284.326);
            grc.AddNodePtxz("osm5457326852", 110.423, 284.070);
            grc.AddNodePtxz("osm33702932", 21.873, 282.462);
            grc.AddNodePtxz("osm1347958012", 9.142, 281.016);
            grc.AddNodePtxz("osm5467434859", 5.950, 280.500);
            grc.AddNodePtxz("osm3662353680", 1.610, 279.797);
            grc.AddNodePtxz("osm3666468611", -4.437, 278.181);
            grc.AddNodePtxz("osm473651436", -7.872, 277.260);
            grc.AddNodePtxz("osm3662352895", -15.637, 273.938);
            grc.AddNodePtxz("osm3662352894", -24.191, 269.280);
            grc.AddNodePtxz("osm33702933", -31.596, 263.367);
            grc.AddNodePtxz("osm3662352893", -40.638, 254.525);
            grc.AddNodePtxz("osm3662352892", -47.382, 245.920);
            grc.AddNodePtxz("osm33702934", -50.923, 238.541);
            grc.AddNodePtxz("osm473651438", -51.876, 232.535);
            grc.AddNodePtxz("osm3662352891", -51.831, 224.597);
            grc.AddNodePtxz("osm33702935", -50.161, 215.302);
            grc.AddNodePtxz("osm5474088800", -46.508, 201.817);
            grc.AddNodePtxz("osm3666466781", -46.229, 200.781);
            grc.AddNodePtxz("osm5474088796", -36.058, 163.163);
            grc.AddNodePtxz("osm5467434854", -34.643, 157.952);
            grc.AddNodePtxz("osm33702925", -23.102, 115.297);
            grc.AddNodePtxz("osm248731300", 485.288, 688.832);
            grc.AddNodePtxz("osm738281714", 481.758, 675.597);
            grc.AddNodePtxz("osm6373715031", 467.601, 618.183);
            grc.AddNodePtxz("osm3666999699", 460.006, 587.372);
            grc.AddNodePtxz("osm243312270", 452.050, 548.475);
            grc.AddNodePtxz("osm2769223913", 448.763, 530.137);
            grc.AddNodePtxz("osm3666999698", 441.305, 490.564);
            grc.AddNodePtxz("osm243312208", 434.233, 459.484);
            grc.AddNodePtxz("osm2769223901", 425.987, 425.026);
            grc.AddNodePtxz("osm243312276", 418.358, 403.073);
            grc.AddNodePtxz("osm2769404079", 409.477, 384.859);
            grc.AddNodePtxz("osm243312283", 392.679, 351.386);
            grc.AddNodePtxz("osm2769404063", 369.810, 312.880);
            grc.AddNodePtxz("osm243312291", 347.719, 280.766);
            grc.AddNodePtxz("osm2769404025", 325.084, 252.452);
            grc.AddNodePtxz("osm6373714855", 311.282, 238.097);
            grc.AddNodePtxz("osm243312239", 296.634, 222.860);
            grc.AddNodePtxz("osm3666040458", 286.466, 214.495);
            grc.AddNodePtxz("osm5443078096", 280.256, 209.644);
            grc.AddNodePtxz("osm243312210", 276.705, 206.874);
            grc.AddNodePtxz("osm3666040648", 267.884, 200.966);
            grc.AddNodePtxz("osm3666040647", 256.509, 195.042);
            grc.AddNodePtxz("osm3666040645", 244.601, 189.846);
            grc.AddNodePtxz("osm33702006", 150.972, 72.428);
            grc.AddNodePtxz("osm2245330472", 194.656, 79.330);
            grc.AddNodePtxz("osm2697503323", 240.174, 87.484);
            grc.AddNodePtxz("osm5455174268", 271.324, 92.553);
            grc.AddNodePtxz("osm243312298", 276.024, 93.321);
            grc.AddNodePtxz("osm33702008", 161.524, 15.423);
            grc.AddNodePtxz("osm3662352904", 163.727, 6.561);
            grc.AddNodePtxz("osm3662353689", 166.267, -3.066);
            grc.AddNodePtxz("osm456054460", 170.455, -14.782);
            grc.AddNodePtxz("osm2761659548", 172.311, -17.552);
            grc.AddNodePtxz("osm33701942", 324.770, 37.808);
            grc.AddNodePtxz("osm3662352913", 316.666, 19.119);
            grc.AddNodePtxz("osm2347271301", 312.742, 11.788);
            grc.AddNodePtxz("osm3662352910", 309.027, 6.131);
            grc.AddNodePtxz("osm33701943", 302.365, -1.154);
            grc.AddNodePtxz("osm3662353589", 296.735, -5.573);
            grc.AddNodePtxz("osm3662353587", 291.907, -8.286);
            grc.AddNodePtxz("osm266520730", 285.802, -11.411);
            grc.AddNodePtxz("osm33482004", 259.038, -20.358);
            grc.AddNodePtxz("osm33702044", 146.845, 96.352);
            grc.AddNodePtxz("osm5891568362", 139.939, 95.883);
            grc.AddNodePtxz("osm434631893", -5.761, 60.671);
            grc.AddNodePtxz("osm434631896", -4.528, 12.113);
            grc.AddNodePtxz("osm3662352902", 137.422, 173.585);
            grc.AddNodePtxz("osm3666040550", 139.229, 153.635);
            grc.AddNodePtxz("osm1106475589", 168.626, 225.164);
            grc.AddNodePtxz("osm1881642037", 141.643, 224.519);
            grc.AddNodePtxz("osm243312243", 171.555, 183.541);
            grc.AddNodePtxz("osm2245330484", 225.533, 185.353);
            grc.AddNodePtxz("osm1587776905", 361.109, 121.978);
            grc.AddNodePtxz("osm1587776903", 352.866, 104.015);
            grc.AddNodePtxz("osm2347271303", 315.723, 2.618);
            grc.AddNodePtxz("osm2347271302", 310.590, -18.036);
            grc.AddNodePtxz("osm3662352908", 305.212, -43.411);
            grc.AddNodePtxz("osm33702434", 299.509, -73.589);
            grc.AddNodePtxz("osm616247", 405.432, -145.660);
            grc.AddNodePtxz("osm2347271310", 404.661, -106.734);
            grc.AddNodePtxz("osm33482006", 403.118, -98.481);
            grc.AddNodePtxz("osm3662353711", 401.599, -91.625);
            grc.AddNodePtxz("osm33701937", 398.839, -83.791);
            grc.AddNodePtxz("osm3662353710", 394.465, -74.239);
            grc.AddNodePtxz("osm1881642050", 389.371, -65.790);
            grc.AddNodePtxz("osm3662353708", 384.255, -59.031);
            grc.AddNodePtxz("osm33702330", 378.047, -51.931);
            grc.AddNodePtxz("osm33701936", 363.298, -40.668);
            grc.AddNodePtxz("osm2347271307", 342.782, -27.085);
            grc.AddNodePtxz("osm2347271306", 333.731, -18.701);
            grc.AddNodePtxz("osm33701950", 329.728, -11.974);
            grc.AddNodePtxz("osm33701935", 327.699, -4.101);
            grc.AddNodePtxz("osm3662353700", 327.282, 2.776);
            grc.AddNodePtxz("osm3662353701", 328.073, 11.741);
            grc.AddNodePtxz("osm33701944", 329.479, 25.733);
            grc.AddNodePtxz("osm456054459", 48.616, 94.216);
            grc.AddNodePtxz("osm3666040363", 45.134, 93.876);
            grc.AddNodePtxz("osm434631885", 42.430, 93.069);
            grc.AddNodePtxz("osm3666040353", 38.901, 90.601);
            grc.AddNodePtxz("osm3666040300", 27.120, 79.519);
            grc.AddNodePtxz("osm3662353685", 25.588, 76.718);
            grc.AddNodePtxz("osm3666040294", 25.854, 73.048);
            grc.AddNodePtxz("osm3662353686", 27.188, 66.435);
            grc.AddNodePtxz("osm434631889", 26.665, 63.934);
            grc.AddNodePtxz("osm3666040217", 25.226, 62.520);
            grc.AddNodePtxz("osm3662353683", 23.148, 61.730);
            grc.AddNodePtxz("osm2245330467", 148.050, 88.510);
            grc.AddNodePtxz("osm738283754", 130.054, 183.449);
            grc.AddNodePtxz("osm5457326850", 116.406, 183.339);
            grc.AddNodePtxz("osm3665957604", 65.760, 182.940);
            grc.AddNodePtxz("osm3665957603", 61.431, 182.427);
            grc.AddNodePtxz("osm33702924", 57.369, 180.703);
            grc.AddNodePtxz("osm5548868468", 45.344, 170.928);
            grc.AddNodePtxz("osm3665957584", -98.050, 114.464);
            grc.AddNodePtxz("osm33702899", -105.907, 115.074);
            grc.AddNodePtxz("osm33701960", 304.471, -103.074);
            grc.AddNodePtxz("osm449011090", 310.456, -56.622);
            grc.AddNodePtxz("osm3662352911", 313.697, -38.397);
            grc.AddNodePtxz("osm2347271304", 317.785, -19.493);
            grc.AddNodePtxz("osm3662352915", 323.708, 5.372);
            grc.AddNodePtxz("osm3662353703", 336.493, 50.596);
            grc.AddNodePtxz("osm266520556", 343.553, 72.916);
            grc.AddNodePtxz("osm355190528", 338.957, 73.438);
            grc.AddNodePtxz("osm2347271305", 326.534, 42.909);
            grc.AddNodePtxz("osm268560288", 233.692, 186.868);
            grc.AddNodePtxz("osm3662352900", 125.786, 335.082);
            grc.AddNodePtxz("osm3662352901", 129.888, 300.481);
            grc.AddNodePtxz("osm1881642018", 130.883, 280.673);
            grc.AddNodePtxz("osm667020999", 134.480, 208.516);
            grc.AddNodePtxz("osm2137895182", 206.105, 183.632);
            grc.AddNodePtxz("osm5926244886", 136.137, 191.343);
            grc.AddNodePtxz("osm5891573270", 136.809, 183.218);
            grc.AddNodePtxz("osm6373714848", 409.120, 258.316);
            grc.AddNodePtxz("osm6373715030", 543.357, 520.050);
            grc.AddNodePtxz("osm6373714863", 545.851, 512.137);
            grc.AddNodePtxz("osm6373714864", 547.645, 483.388);
            grc.AddNodePtxz("osm6373714865", 557.657, 460.832);
            grc.AddNodePtxz("osm6373714866", 560.046, 453.931);
            grc.AddNodePtxz("osm6373714867", 559.245, 449.086);
            grc.AddNodePtxz("osm6373714862", 514.021, 397.860);
            grc.AddNodePtxz("osm6373714868", 495.007, 372.322);
            grc.AddNodePtxz("osm6373714861", 464.188, 329.273);
            grc.AddNodePtxz("osm6373714860", 399.741, 246.233);
            grc.AddNodePtxz("osm6373714859", 376.316, 218.506);
            grc.AddNodePtxz("osm6373714858", 357.708, 190.128);
            grc.AddNodePtxz("osm6373714857", 354.505, 188.940);
            grc.AddNodePtxz("osm6373714856", 350.501, 192.619);
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
            grc.AddLinkByNodeName("osm3662352913", "osm33701942", usetype: LinkUse.road, comment: "primary_link01.link1");
            grc.AddLinkByNodeName("osm2347271301", "osm3662352913", usetype: LinkUse.road, comment: "primary_link01.link2");
            grc.AddLinkByNodeName("osm3662352910", "osm2347271301", usetype: LinkUse.road, comment: "primary_link01.link3");
            grc.AddLinkByNodeName("osm33701943", "osm3662352910", usetype: LinkUse.road, comment: "primary_link01.link4");
            grc.AddLinkByNodeName("osm3662353589", "osm33701943", usetype: LinkUse.road, comment: "primary_link01.link5");
            grc.AddLinkByNodeName("osm3662353587", "osm3662353589", usetype: LinkUse.road, comment: "primary_link01.link6");
            grc.AddLinkByNodeName("osm266520730", "osm3662353587", usetype: LinkUse.road, comment: "primary_link01.link7");
            grc.AddLinkByNodeName("osm33482004", "osm266520730", usetype: LinkUse.road, comment: "primary_link01.link8");
            grc.AddLinkByNodeName("osm5891568362", "osm33702044", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse.link1");
            grc.AddLinkByNodeName("osm434631896", "osm434631893", usetype: LinkUse.slowroad, comment: "Elsa-Braendstroem-Strasse01.link1");
            grc.AddLinkByNodeName("osm3666040550", "osm3662352902", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse02.link1");
            grc.AddLinkByNodeName("osm33702044", "osm3666040550", usetype: LinkUse.road, comment: "Noerdliche Ringstrasse02.link2");
            grc.AddLinkByNodeName("osm1881642037", "osm1106475589", usetype: LinkUse.slowroad, comment: "Anne-Frank-Strasse.link1");
            grc.AddLinkByNodeName("osm1587776903", "osm1587776905", usetype: LinkUse.road, comment: "primary01.link1");
            grc.AddLinkByNodeName("osm2347271303", "osm33701942", usetype: LinkUse.road, comment: "primary02.link1");
            grc.AddLinkByNodeName("osm2347271302", "osm2347271303", usetype: LinkUse.road, comment: "primary02.link2");
            grc.AddLinkByNodeName("osm3662352908", "osm2347271302", usetype: LinkUse.road, comment: "primary02.link3");
            grc.AddLinkByNodeName("osm33702434", "osm3662352908", usetype: LinkUse.road, comment: "primary02.link4");
            grc.AddLinkByNodeName("osm2347271310", "osm616247", usetype: LinkUse.road, comment: "primary03.link1");
            grc.AddLinkByNodeName("osm33482006", "osm2347271310", usetype: LinkUse.road, comment: "primary03.link2");
            grc.AddLinkByNodeName("osm3662353711", "osm33482006", usetype: LinkUse.road, comment: "primary03.link3");
            grc.AddLinkByNodeName("osm33701937", "osm3662353711", usetype: LinkUse.road, comment: "primary03.link4");
            grc.AddLinkByNodeName("osm3662353710", "osm33701937", usetype: LinkUse.road, comment: "primary03.link5");
            grc.AddLinkByNodeName("osm1881642050", "osm3662353710", usetype: LinkUse.road, comment: "primary03.link6");
            grc.AddLinkByNodeName("osm3662353708", "osm1881642050", usetype: LinkUse.road, comment: "primary03.link7");
            grc.AddLinkByNodeName("osm33702330", "osm3662353708", usetype: LinkUse.road, comment: "primary03.link8");
            grc.AddLinkByNodeName("osm33701936", "osm33702330", usetype: LinkUse.road, comment: "primary03.link9");
            grc.AddLinkByNodeName("osm2347271307", "osm33701936", usetype: LinkUse.road, comment: "primary03.link10");
            grc.AddLinkByNodeName("osm2347271306", "osm2347271307", usetype: LinkUse.road, comment: "primary03.link11");
            grc.AddLinkByNodeName("osm33701950", "osm2347271306", usetype: LinkUse.road, comment: "primary03.link12");
            grc.AddLinkByNodeName("osm33701935", "osm33701950", usetype: LinkUse.road, comment: "primary03.link13");
            grc.AddLinkByNodeName("osm3662353700", "osm33701935", usetype: LinkUse.road, comment: "primary03.link14");
            grc.AddLinkByNodeName("osm3662353701", "osm3662353700", usetype: LinkUse.road, comment: "primary03.link15");
            grc.AddLinkByNodeName("osm33701944", "osm3662353701", usetype: LinkUse.road, comment: "primary03.link16");
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
            grc.AddLinkByNodeName("osm449011090", "osm33701960", usetype: LinkUse.road, comment: "primary04.link1");
            grc.AddLinkByNodeName("osm3662352911", "osm449011090", usetype: LinkUse.road, comment: "primary04.link2");
            grc.AddLinkByNodeName("osm2347271304", "osm3662352911", usetype: LinkUse.road, comment: "primary04.link3");
            grc.AddLinkByNodeName("osm3662352915", "osm2347271304", usetype: LinkUse.road, comment: "primary04.link4");
            grc.AddLinkByNodeName("osm33701944", "osm3662352915", usetype: LinkUse.road, comment: "primary04.link5");
            grc.AddLinkByNodeName("osm3662353703", "osm33701944", usetype: LinkUse.road, comment: "primary04.link6");
            grc.AddLinkByNodeName("osm266520556", "osm3662353703", usetype: LinkUse.road, comment: "primary04.link7");
            grc.AddLinkByNodeName("osm1587776903", "osm266520556", usetype: LinkUse.road, comment: "primary04.link8");
            grc.AddLinkByNodeName("osm355190528", "osm1587776903", usetype: LinkUse.road, comment: "primary05.link1");
            grc.AddLinkByNodeName("osm2347271305", "osm355190528", usetype: LinkUse.road, comment: "primary05.link2");
            grc.AddLinkByNodeName("osm33701942", "osm2347271305", usetype: LinkUse.road, comment: "primary05.link3");
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
            grc.regman.SetRegion("default");
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
                var bld = GameObject.Find(bldname);
                var llm = bld.GetComponent<LatLongMap>();
                grc.gm.initmods();
                grc.gm.setmapper(llm);
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
        // =================== generated code
        public void createPointsFor_msft_b11o()    // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-b11", "purple", saveToFile: true);
            grc.AddNodePtxyz("b11-f01-lobby", -123.670, 0.000, 219.400, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b11-f01-lobby", "b11-os1-o01", -123.670, 0.000, 225.850, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b11-os1-o01", "b11-os1-o02", -106.900, 0.000, 232.940, LinkUse.walkway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("b11-os1-o02", "b11-os1-o03", -105.600, 0.000, 236.400, LinkUse.walkway, comment: ""); //  4 nn:1 nl:1

            grc.AddNodePtxyz("dw-B11-c01", -103.230, 0.000, 241.700, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("dw-B11-c01", "st-B11-c02", -112.310, 0.000, 238.830, LinkUse.driveway, comment: ""); //  2 nn:1 nl:1
            grc.AddLinkByNodeName("st-B11-c02", "st-B11-c02", LinkUse.driveway); //  3 nn:0 nl:1
            grc.LinkToPtxyz("st-B11-c02", "st-B11-c04", -128.940, 0.000, 243.850, LinkUse.driveway, comment: ""); //  4 nn:1 nl:1
            grc.AddLinkByNodeName("st-B11-c04", "reg:msft-campus", LinkUse.driveway); //  30 nn:0 nl:1
            grc.regman.SetRegion("default");
        }
        public void createPointsFor_msft_b11()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-b11", "purple", saveToFile: true);
            grc.AddNodePtxyz("b11-f01-lobby", -123.670, 0.000, 219.400, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b11-f01-lobby", "b11-os1-o01", -123.670, 0.000, 225.850, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b11-os1-o01", "b11-os1-o02", -106.900, 0.000, 232.940, LinkUse.walkway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("b11-os1-o02", "b11-os1-o03", -105.600, 0.000, 236.400, LinkUse.walkway, comment: ""); //  4 nn:1 nl:1
            grc.AddNodePtxyz("dw-B11-c01", -103.230, 0.000, 241.700, comment: ""); //  5 nn:1 nl:0
            grc.LinkToPtxyz("dw-B11-c01", "st-B11-c02", -112.310, 0.000, 238.830, LinkUse.driveway, comment: ""); //  6 nn:1 nl:1
            grc.AddLinkByNodeName("st-B11-c02", "st-B11-c02", LinkUse.driveway); //  7 nn:0 nl:1
            grc.LinkToPtxyz("st-B11-c02", "st-B11-c04", -128.940, 0.000, 243.850, LinkUse.driveway, comment: ""); //  8 nn:1 nl:1
            grc.AddLinkByNodeName("st-B11-c04", "reg:msft-campus", LinkUse.driveway); //  9 nn:0 nl:1
            grc.regman.SetRegion("default");
        }

        public void createPointsFor_msft_b19()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-b19", "purple", saveToFile: true);
            grc.AddNodePtxyz("b19-f01-lobby", -474.400, 0.000, 95.700, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b19-f01-lobby", "b19-os1-o00b", -471.000, 0.000, 98.900, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b19-os1-o00b", "b19-os1-o00a", -467.400, 0.000, 99.700, LinkUse.walkway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("b19-os1-o00a", "b19-os1-o00", -459.500, 0.000, 105.600, LinkUse.walkway, comment: ""); //  4 nn:1 nl:1
            grc.LinkToPtxyz("b19-os1-o00", "b19-os1-o01", -458.300, 0.000, 112.900, LinkUse.walkway, comment: ""); //  5 nn:1 nl:1
            grc.LinkToPtxyz("b19-os1-o01", "b19-os1-o02", -462.000, 0.000, 118.400, LinkUse.walkway, comment: ""); //  6 nn:1 nl:1
            grc.LinkToPtxyz("b19-os1-o02", "b19-os1-o03", -459.400, 0.000, 132.300, LinkUse.walkway, comment: ""); //  7 nn:1 nl:1
            grc.LinkToPtxyz("b19-os1-o00", "b19-os2-o01", -450.400, 0.000, 101.100, LinkUse.walkway, comment: ""); //  8 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-lobby", "b19-f01-lbba", -469.000, 0.000, 92.900, LinkUse.walkway, comment: ""); //  9 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-lbba", "b19-f01-cp00", -467.100, 0.000, 93.400, LinkUse.walkway, comment: ""); //  10 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-lbba", "b19-f01-cp001", -465.900, 0.000, 93.700, LinkUse.walkway, comment: ""); //  11 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-lobby", "b19-f01-rm1003", -483.400, 0.000, 93.900, LinkUse.walkway, comment: ""); //  12 nn:1 nl:1
            grc.AddLinkByNodeName("b19-os1-o00b", "b19-f01-lbba", LinkUse.walkway); //  13 nn:0 nl:1
            grc.LinkToPtxyz("b19-os1-o00b", "b19-f01-cp0b0", -471.200, 0.000, 99.800, LinkUse.walkway, comment: ""); //  14 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp0b0", "b19-f01-cp0b1", -471.600, 0.000, 101.200, LinkUse.walkway, comment: ""); //  15 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp0b0", "b19-f01-cp0b2", -474.000, 0.000, 99.500, LinkUse.walkway, comment: ""); //  16 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp001", "b19-f01-cp01", -463.400, 0.000, 94.940, LinkUse.walkway, comment: ""); //  17 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp01", "b19-f01-cp02", -462.560, 0.000, 95.300, LinkUse.walkway, comment: ""); //  18 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp001", "b19-f01-rm1004", -467.600, 0.000, 96.500, LinkUse.walkway, comment: ""); //  19 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp01", "b19-f01-rm1005", -465.100, 0.000, 97.400, LinkUse.walkway, comment: ""); //  20 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp02", "b19-f01-rm1006", -462.000, 0.000, 98.100, LinkUse.walkway, comment: ""); //  21 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp00", "b19-f01-cp021", -465.100, 0.000, 87.880, LinkUse.walkway, comment: ""); //  22 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp021", "b19-f01-cp031", -468.100, 0.000, 86.900, LinkUse.walkway, comment: ""); //  23 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp031", "b19-f01-rm1001", -469.000, 0.000, 89.800, LinkUse.walkway, comment: ""); //  24 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp031", "b19-f01-cp032", -472.150, 0.000, 85.670, LinkUse.walkway, comment: ""); //  25 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp032", "b19-f01-rm1002", -472.900, 0.000, 88.500, LinkUse.walkway, comment: ""); //  26 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp021", "b19-f01-cp022", -464.060, 0.000, 84.800, LinkUse.walkway, comment: ""); //  27 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp022", "b19-f01-cp023", -463.800, 0.000, 84.000, LinkUse.walkway, comment: ""); //  28 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp023", "b19-f01-cp024", -462.700, 0.000, 80.800, LinkUse.walkway, comment: ""); //  29 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp024", "b19-f01-cp025", -461.700, 0.000, 78.000, LinkUse.walkway, comment: ""); //  30 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp025", "b19-f01-cp026", -461.000, 0.000, 76.100, LinkUse.walkway, comment: ""); //  31 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp026", "b19-f01-cp027", -461.000, 0.000, 74.140, LinkUse.walkway, comment: ""); //  32 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp027", "b19-f01-cp028", -458.100, 0.000, 68.000, LinkUse.walkway, comment: ""); //  33 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp028", "b19-f01-cp029", -457.900, 0.000, 67.200, LinkUse.walkway, comment: ""); //  34 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp029", "b19-f01-cp041", -456.500, 0.000, 68.300, LinkUse.walkway, comment: ""); //  35 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp029", "b19-f01-cp029a", -456.100, 0.000, 64.800, LinkUse.walkway, comment: ""); //  36 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp024", "b19-f01-cp051", -458.000, 0.000, 82.700, LinkUse.walkway, comment: ""); //  37 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp051", "b19-f01-cp052", -456.900, 0.000, 82.800, LinkUse.walkway, comment: ""); //  38 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp052", "b19-f01-cp053", -451.600, 0.000, 84.800, LinkUse.walkway, comment: ""); //  39 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp053", "b19-f01-cp054", -450.200, 0.000, 85.100, LinkUse.walkway, comment: ""); //  40 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp054", "b19-f01-cp054a", -447.300, 0.000, 86.100, LinkUse.walkway, comment: ""); //  41 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp054", "b19-f01-cp055", -449.700, 0.000, 87.100, LinkUse.walkway, comment: ""); //  42 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp055", "b19-f01-cp056", -451.000, 0.000, 90.400, LinkUse.walkway, comment: ""); //  43 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp056", "b19-f01-cp057", -452.500, 0.000, 91.740, LinkUse.walkway, comment: ""); //  44 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp057", "b19-f01-cp058", -457.600, 0.000, 94.300, LinkUse.walkway, comment: ""); //  45 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp058", "b19-f01-cp059", -458.250, 0.000, 94.620, LinkUse.walkway, comment: ""); //  46 nn:1 nl:1
            grc.AddLinkByNodeName("b19-f01-cp059", "b19-f01-cp02", LinkUse.walkway); //  47 nn:0 nl:1
            grc.LinkToPtxyz("b19-f01-cp051", "b19-f01-cp051a", -458.850, 0.000, 85.050, LinkUse.walkway, comment: ""); //  48 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp051a", "b19-f01-cp051b", -460.200, 0.000, 88.840, LinkUse.walkway, comment: ""); //  49 nn:1 nl:1
            grc.AddLinkByNodeName("b19-f01-cp051b", "b19-f01-cp02", LinkUse.walkway); //  50 nn:0 nl:1
            grc.LinkToPtxyz("b19-f01-cp022", "b19-f01-rm1012", -467.100, 0.000, 84.900, LinkUse.walkway, comment: ""); //  51 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-rm1012", "b19-f01-rm1012a", -471.000, 0.000, 83.800, LinkUse.walkway, comment: ""); //  52 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp023", "b19-f01-rm1013", -466.400, 0.000, 82.300, LinkUse.walkway, comment: ""); //  53 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp024", "b19-f01-rm1014", -466.100, 0.000, 79.900, LinkUse.walkway, comment: ""); //  54 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp025", "b19-f01-rm1015", -465.100, 0.000, 78.000, LinkUse.walkway, comment: ""); //  55 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp026", "b19-f01-rm1016", -464.000, 0.000, 75.300, LinkUse.walkway, comment: ""); //  56 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp027", "b19-f01-rm1017", -462.500, 0.000, 70.400, LinkUse.walkway, comment: ""); //  57 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp029", "b19-f01-rm1018", -461.000, 0.000, 67.200, LinkUse.walkway, comment: ""); //  58 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp029", "b19-f01-rm1019", -460.000, 0.000, 63.900, LinkUse.walkway, comment: ""); //  59 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp052", "b19-f01-rm1021", -454.300, 0.000, 80.400, LinkUse.walkway, comment: ""); //  60 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp053", "b19-f01-rm1022", -450.900, 0.000, 81.600, LinkUse.walkway, comment: ""); //  61 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp054", "b19-f01-rm1023", -448.200, 0.000, 82.800, LinkUse.walkway, comment: ""); //  62 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp054a", "b19-f01-rm1024", -445.600, 0.000, 83.500, LinkUse.walkway, comment: ""); //  63 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp055", "b19-f01-rm1025", -447.900, 0.000, 89.100, LinkUse.walkway, comment: ""); //  64 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp056", "b19-f01-rm1026", -449.200, 0.000, 92.600, LinkUse.walkway, comment: ""); //  65 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp057", "b19-f01-rm1027", -452.300, 0.000, 94.700, LinkUse.walkway, comment: ""); //  66 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp058", "b19-f01-rm1028", -455.300, 0.000, 96.400, LinkUse.walkway, comment: ""); //  67 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp059", "b19-f01-rm1029", -458.200, 0.000, 97.600, LinkUse.walkway, comment: ""); //  68 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp051", "b19-f01-cp061", -455.600, 0.000, 75.900, LinkUse.walkway, comment: ""); //  69 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp061", "b19-f01-cp062", -455.110, 0.000, 74.440, LinkUse.walkway, comment: ""); //  70 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp061", "b19-f01-cp061a", -460.200, 0.000, 74.300, LinkUse.walkway, comment: ""); //  71 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp062", "b19-f01-cp063", -453.400, 0.000, 69.600, LinkUse.walkway, comment: ""); //  72 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp063", "b19-f01-cp064", -451.300, 0.000, 69.600, LinkUse.walkway, comment: ""); //  73 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp064", "b19-f01-cp065", -448.200, 0.000, 68.400, LinkUse.walkway, comment: ""); //  74 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp065", "b19-f01-cp066", -445.400, 0.000, 73.600, LinkUse.walkway, comment: ""); //  75 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp066", "b19-f01-cp067a", -445.700, 0.000, 77.600, LinkUse.walkway, comment: ""); //  76 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp066", "b19-f01-cp067b", -446.600, 0.000, 78.000, LinkUse.walkway, comment: ""); //  77 nn:1 nl:1
            grc.AddLinkByNodeName("b19-f01-cp067a", "b19-f01-cp067b", LinkUse.walkway); //  78 nn:0 nl:1
            grc.AddLinkByNodeName("b19-f01-cp063", "b19-f01-cp041", LinkUse.walkway); //  79 nn:0 nl:1
            grc.AddLinkByNodeName("b19-f01-cp061a", "b19-f01-cp027", LinkUse.walkway); //  80 nn:0 nl:1
            grc.LinkToPtxyz("b19-f01-cp029a", "b19-f01-rm1030", -456.100, 0.000, 62.200, LinkUse.walkway, comment: ""); //  81 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp041", "b19-f01-rm1031", -454.400, 0.000, 65.900, LinkUse.walkway, comment: ""); //  82 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp064", "b19-f01-rm1032", -451.300, 0.000, 67.000, LinkUse.walkway, comment: ""); //  83 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp065", "b19-f01-rm1033", -448.700, 0.000, 64.500, LinkUse.walkway, comment: ""); //  84 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-rm1033", "b19-f01-rm1033a", -452.200, 0.000, 63.600, LinkUse.walkway, comment: ""); //  85 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp067a", "b19-f01-rm1034", -443.500, 0.000, 77.100, LinkUse.walkway, comment: ""); //  86 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp067a", "b19-f01-rm1035", -444.400, 0.000, 79.900, LinkUse.walkway, comment: ""); //  87 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp067b", "b19-f01-rm1036", -450.000, 0.000, 78.500, LinkUse.walkway, comment: ""); //  88 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp067b", "b19-f01-rm1037", -448.700, 0.000, 75.900, LinkUse.walkway, comment: ""); //  89 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp061", "b19-f01-rm1038", -453.100, 0.000, 77.400, LinkUse.walkway, comment: ""); //  90 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp061", "b19-f01-rm1039", -452.300, 0.000, 74.800, LinkUse.walkway, comment: ""); //  91 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp021", "b19-f01-sp1003", -463.735, 0.180, 88.964, LinkUse.walkway, comment: ""); //  92 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp058", "b19-f01-sp1030", -457.491, 0.180, 92.681, LinkUse.walkway, comment: ""); //  93 nn:1 nl:1
            grc.LinkToPtxyz("b19-f01-cp052", "b19-f01-sp1029", -456.760, 0.180, 85.280, LinkUse.walkway, comment: ""); //  94 nn:1 nl:1
            grc.AddNodePtxyz("dw-B19-c01", -525.500, 0.000, 106.400, comment: ""); //  95 nn:1 nl:0
            grc.LinkToPtxyz("dw-B19-c01", "dw-B19-c02", -520.260, 0.000, 105.260, LinkUse.driveway, comment: ""); //  96 nn:1 nl:1
            grc.AddLinkByNodeName("dw-B19-c01", "reg:msft-campus", LinkUse.driveway); //  97 nn:0 nl:1
            grc.regman.SetRegion("default");
        }

        public void createPointsFor_msft_b40o()    // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-b40", "purple", saveToFile: true);
            grc.AddNodePtxyz("b40-f01-lobby", 243.700, 0.000, 175.500, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b40-f01-lobby", "b40-os1-o01", 234.800, 0.000, 170.000, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b40-os1-o01", "b40-os1-o02", 242.200, 0.000, 144.200, LinkUse.walkway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("b40-os1-o02", "b40-os1-o03", 249.250, 0.000, 121.260, LinkUse.walkway, comment: ""); //  4 nn:1 nl:1
            grc.AddNodePtxyz("dw-B40-c01", 194.330, 0.000, 90.500); //  39 nn:1 nl:1
            grc.LinkToPtxyz("dw-B40-c01", "dw-B40-c02", 169.910, 0.000, 90.650, LinkUse.road, comment: ""); //  38 nn:1 nl:1
            grc.AddLinkByNodeName("dw-B40-c02", "reg:msft-campus",  LinkUse.driveway); //  38 nn:1 nl:1
            grc.regman.SetRegion("default");
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


        public void createPointsFor_msft_b43o()    // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-b43", "purple", saveToFile: true);
            grc.AddNodePtxyz("dw-B43-c01", 89.80, 0.000, 74.800, comment: ""); //  26 nn:1 nl:0
            grc.LinkToPtxyz("dw-B43-c01", "dw-B43-c02", 64.600, 0.000, 62.300, LinkUse.driveway, comment: ""); //  27 nn:1 nl:1
            grc.LinkToPtxyz("dw-B43-c02", "dw-B43-c03", 53.900, 0.000, 57.500, LinkUse.driveway, comment: ""); //  28 nn:1 nl:1
            grc.LinkToPtxyz("dw-B43-c03", "dw-B43-c04", 50.180, 0.000, 49.740, LinkUse.driveway, comment: ""); //  29 nn:1 nl:1
            grc.LinkToPtxyz("dw-B43-c04", "dw-B43-c05", 62.850, 0.000, 55.200, LinkUse.driveway, comment: ""); //  31 nn:1 nl:1
            grc.AddLinkByNodeName("dw-B43-c05", "reg:msft-campus", LinkUse.driveway); //  31 nn:1 nl:1
            grc.AddLinkByNodeName("dw-B43-c01", "reg:msft-campus", LinkUse.driveway); //  31 nn:1 nl:1
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

        public void createPointsFor_msft_b99o()    // machine generated - do not edit
        { 
            grc.regman.NewNodeRegion("msft-b99", "purple", saveToFile: true);
            grc.AddNodePtxyz("b99-f01-lobby", -113.000, 0.000, -612.700, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("b99-f01-lobby", "b99-os1-o00", -114.630, 0.000, -588.610, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("b99-os1-o00", "b99-os1-o01", -116.940, 0.000, -573.640, LinkUse.walkway, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("b99-os1-o01", "b99-os1-o02", -126.610, 0.000, -570.150, LinkUse.walkway, comment: ""); //  4 nn:1 nl:1
            grc.LinkToPtxyz("b99-os1-o02", "b99-os1-o03", -139.820, 0.000, -570.660, LinkUse.walkway, comment: ""); //  5 nn:1 nl:1
            grc.LinkToPtxyz("b99-os1-o03", "b99-os1-o04", -139.820, 0.000, -561.610, LinkUse.walkway, comment: ""); //  6 nn:1 nl:1
            grc.AddNodePtxyz("dw-b99-o00", -88.200, 0.000, -569.810);
            //grc.LinkToPtxyz("st-NE36-c14", "dw-b99-o00", -88.200, 0.000, -569.810, LinkUse.driveway, comment: "");
            grc.AddLinkByNodeName("dw-b99-o00","reg:msft-campus", LinkUse.driveway); //  78 nn:1 nl:1

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

        public void createPointsFor_msft_bredwbo()    // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-bredwb", "purple", saveToFile: true);
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

            grc.AddNodePtxyz("dw-RWB-c00", -1797.560, 0.000, -1227.460); //  96 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c00", "dw-RWB-c01", -1812.540, 0.000, -1229.800, LinkUse.driveway, comment: ""); //  97 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c01", "dw-RWB-c02", -1847.720, 0.000, -1242.200, LinkUse.driveway, comment: ""); //  98 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c02", "dw-RWB-c03", -1896.080, 0.000, -1258.700, LinkUse.driveway, comment: ""); //  99 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c03", "dw-RWB-c04", -1950.610, 0.000, -1276.100, LinkUse.driveway, comment: ""); //  100 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c04", "dw-RWB-c05", -1981.340, 0.000, -1286.900, LinkUse.driveway, comment: ""); //  101 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c05", "dw-RWB-c06", -1988.200, 0.000, -1263.600, LinkUse.driveway, comment: ""); //  102 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c06", "dw-RWB-c07", -1980.400, 0.000, -1258.200, LinkUse.driveway, comment: ""); //  103 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c07", "dw-RWB-c11", -1971.900, 0.000, -1254.200, LinkUse.driveway, comment: ""); //  104 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c11", "dw-RWB-c12", -1973.400, 0.000, -1249.500, LinkUse.driveway, comment: ""); //  105 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c12", "dw-RWB-c14", -1977.500, 0.000, -1237.500, LinkUse.driveway, comment: ""); //  106 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c14", "dw-RWB-c16", -1987.800, 0.000, -1208.400, LinkUse.driveway, comment: ""); //  107 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c16", "dw-RWB-c18", -1998.000, 0.000, -1179.400, LinkUse.driveway, comment: ""); //  108 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c06", "dw-RWB-c21", -1989.200, 0.000, -1258.700, LinkUse.driveway, comment: ""); //  109 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c21", "dw-RWB-c22", -1990.500, 0.000, -1254.000, LinkUse.driveway, comment: ""); //  110 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c22", "dw-RWB-c24", -1994.600, 0.000, -1242.000, LinkUse.driveway, comment: ""); //  111 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c24", "dw-RWB-c26", -2004.900, 0.000, -1212.900, LinkUse.driveway, comment: ""); //  112 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c26", "dw-RWB-c28", -2015.100, 0.000, -1183.900, LinkUse.driveway, comment: ""); //  113 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c06", "dw-RWB-c31", -2005.000, 0.000, -1265.000, LinkUse.driveway, comment: ""); //  114 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c31", "dw-RWB-c32", -2007.400, 0.000, -1258.500, LinkUse.driveway, comment: ""); //  115 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c32", "dw-RWB-c34", -2011.500, 0.000, -1246.500, LinkUse.driveway, comment: ""); //  116 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c34", "dw-RWB-c36", -2021.000, 0.000, -1219.000, LinkUse.driveway, comment: ""); //  117 nn:1 nl:1
            grc.LinkToPtxyz("dw-RWB-c36", "dw-RWB-c38", -2030.300, 0.000, -1190.700, LinkUse.driveway, comment: ""); //  118 nn:1 nl:1

            grc.AddLinkByNodeName("dw-RWB-c00", "reg:msft-campus", LinkUse.driveway); 

            grc.regman.SetRegion("default");
        }

        public void createPointsFor_msft_bredwb()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-bredwb", "purple", saveToFile: true);
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
            grc.regman.SetRegion("default");
        }


        public void createPointsFor_msft_bredwb_f3()    // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-bredwb-f3", "purple", saveToFile: true);
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
        }

        public void createPointsFor_msft_bsxo()    // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-bsx", "purple", saveToFile: true);
            grc.AddNodePtxyz("bSX-f01-lobby", -157.200, 0.000, -180.000, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("bSX-f01-lobby", "bSX-os1-o00", -154.040, 0.000, -176.210, LinkUse.walkway, comment: ""); //  2 nn:1 nl:1
            grc.AddNodePtxyz("dw-SX-o00", -85.560, 0.000, -171.520); //  75 nn:1 nl:1
            grc.LinkToPtxyz("dw-SX-o00", "dw-SX-o01", -102.470, 0.000, -172.000, LinkUse.driveway, comment: ""); //  76 nn:1 nl:1
            grc.AddLinkByNodeName("dw-SX-o00", "reg:msft-campus", LinkUse.driveway); //  77 nn:0 nl:1
            grc.regman.SetRegion("default");
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

        public void createPointsFor_msft_campuso()    // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-campus", "blue", saveToFile: true);
            grc.AddNodePtxyz("st-157NE-c02", -529.800, 0.000, 121.400, comment: ""); //  5 nn:1 nl:0
            grc.LinkToPtxyz("st-157NE-c02", "st-157NE-c03", -503.000, 0.000, 132.400, LinkUse.road, comment: ""); //  6 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c03", "st-157NE-c04", -440.000, 0.000, 154.200, LinkUse.road, comment: ""); //  7 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c04", "st-157NE-c05", -381.300, 0.000, 174.200, LinkUse.road, comment: ""); //  8 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c05", "st-157NE-c06", -219.700, 0.000, 226.600, LinkUse.road, comment: ""); //  9 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c06", "st-157NE-c07", -127.000, 0.000, 256.700, LinkUse.road, comment: ""); //  10 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c07", "st-157NE-c08", -86.400, 0.000, 270.200, LinkUse.road, comment: ""); //  11 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c08", "st-157NE-c09", -55.550, 0.000, 279.240, LinkUse.road, comment: ""); //  12 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c09", "st-157NE-c10", -27.140, 0.000, 279.240, LinkUse.road, comment: ""); //  13 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c10", "st-157NE-c11", -0.320, 0.000, 270.290, LinkUse.road, comment: ""); //  14 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c11", "st-157NE-c12", 17.750, 0.000, 256.890, LinkUse.road, comment: ""); //  15 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c12", "st-157NE-c13", 32.950, 0.000, 239.450, LinkUse.road, comment: ""); //  16 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c13", "st-157NE-c14", 46.270, 0.000, 209.200, LinkUse.road, comment: ""); //  17 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c14", "st-157NE-c15", 49.290, 0.000, 199.000, LinkUse.road, comment: ""); //  18 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c15", "st-NE31-c24", 65.100, 0.000, 161.700, LinkUse.road, comment: ""); //  19 nn:1 nl:1
            grc.LinkToPtxyz("st-NE31-c24", "st-NE31-c23", 79.670, 0.000, 116.900, LinkUse.road, comment: ""); //  20 nn:1 nl:1
            grc.LinkToPtxyz("st-NE31-c23", "st-NE31-c22", 95.510, 0.000, 81.630, LinkUse.road, comment: ""); //  21 nn:1 nl:1
            grc.LinkToPtxyz("st-NE31-c22", "st-NE31-c21", 98.000, 0.000, 75.000, LinkUse.road, comment: ""); //  22 nn:1 nl:1
            grc.AddNodePtxyz("st-NE33-c02", 71.390, 0.000, 56.570); //  32 nn:1 nl:1
            grc.LinkToPtxyz("st-NE33-c02", "st-NE33-c03", 86.440, 0.000, 61.510, LinkUse.road, comment: ""); //  33 nn:1 nl:1
            grc.LinkToPtxyz("st-NE33-c03", "st-NE33-c04", 97.420, 0.000, 61.510, LinkUse.road, comment: ""); //  34 nn:1 nl:1
            grc.LinkToPtxyz("st-NE33-c04", "st-NE33-c05", 108.330, 0.000, 73.140, LinkUse.road, comment: ""); //  35 nn:1 nl:1
            grc.LinkToPtxyz("st-NE33-c05", "st-NE33-c06", 137.000, 0.000, 85.200, LinkUse.road, comment: ""); //  36 nn:1 nl:1
            grc.LinkToPtxyz("st-NE33-c06", "st-NE33-c07", 165.550, 0.000, 102.960, LinkUse.road, comment: ""); //  37 nn:1 nl:1
            grc.AddLinkByNodeName("st-NE31-c21", "st-NE33-c05", LinkUse.road); //  40 nn:0 nl:1
            grc.LinkToPtxyz("st-NE33-c04", "st-NE31-c00", 106.190, 0.000, 52.900, LinkUse.road, comment: ""); //  41 nn:1 nl:1
            grc.AddLinkByNodeName("st-NE31-c21", "st-NE33-c04", LinkUse.road); //  42 nn:0 nl:1
            grc.LinkToPtxyz("st-NE31-c00", "st-NE31-c01", 110.640, 0.000, 40.560, LinkUse.road, comment: ""); //  43 nn:1 nl:1
            grc.LinkToPtxyz("st-NE31-c01", "st-NE31-c02", 122.010, 0.000, 12.740, LinkUse.road, comment: ""); //  44 nn:1 nl:1
            grc.LinkToPtxyz("st-NE31-c02", "st-NE31-c03", 125.010, 0.000, -10.060, LinkUse.road, comment: ""); //  45 nn:1 nl:1
            grc.LinkToPtxyz("st-NE31-c03", "st-CRC1-c01", 124.690, 0.000, -27.370, LinkUse.road, comment: ""); //  46 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c01", "st-CRC1-c02", 116.540, 0.000, -30.700, LinkUse.road, comment: ""); //  47 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c02", "st-CRC1-c03", 110.460, 0.000, -37.780, LinkUse.road, comment: ""); //  48 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c03", "st-CRC1-c04", 110.460, 0.000, -45.590, LinkUse.road, comment: ""); //  49 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c04", "st-CRC1-c05", 113.160, 0.000, -52.910, LinkUse.road, comment: ""); //  50 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c05", "st-CRC1-c06", 120.330, 0.000, -56.930, LinkUse.road, comment: ""); //  51 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c06", "st-CRC1-c07", 129.710, 0.000, -56.930, LinkUse.road, comment: ""); //  52 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c07", "st-CRC1-c08", 138.230, 0.000, -47.430, LinkUse.road, comment: ""); //  53 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c08", "st-CRC1-c09", 138.230, 0.000, -37.780, LinkUse.road, comment: ""); //  54 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c09", "st-CRC1-c10", 134.190, 0.000, -31.350, LinkUse.road, comment: ""); //  55 nn:1 nl:1
            grc.AddLinkByNodeName("st-CRC1-c01", "st-CRC1-c10", LinkUse.road); //  56 nn:0 nl:1
            grc.LinkToPtxyz("st-CRC1-c04", "st-NE36-c00", 94.280, 0.000, -51.490, LinkUse.road, comment: ""); //  57 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c00", "st-NE36-c01", 62.460, 0.000, -72.410, LinkUse.road, comment: ""); //  58 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c01", "st-NE36-c02", 27.870, 0.000, -95.410, LinkUse.road, comment: ""); //  59 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c02", "st-NE36-c03", -24.020, 0.000, -129.850, LinkUse.road, comment: ""); //  60 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c03", "st-NE36-c04", -56.480, 0.000, -155.650, LinkUse.road, comment: ""); //  61 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c04", "st-NE36-c05", -67.570, 0.000, -170.630, LinkUse.road, comment: ""); //  62 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c05", "st-NE36-c06", -72.350, 0.000, -180.420, LinkUse.road, comment: ""); //  63 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c06", "st-NE36-c07", -77.100, 0.000, -193.340, LinkUse.road, comment: ""); //  64 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c07", "st-NE36-c08", -81.120, 0.000, -229.020, LinkUse.road, comment: ""); //  65 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c08", "st-NE36-c09", -82.380, 0.000, -270.390, LinkUse.road, comment: ""); //  66 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c09", "st-NE36-c10", -83.110, 0.000, -324.970, LinkUse.road, comment: ""); //  67 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c10", "st-NE36-c11", -80.950, 0.000, -350.820, LinkUse.road, comment: ""); //  68 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c11", "st-NE36-c12", -75.850, 0.000, -412.220, LinkUse.road, comment: ""); //  69 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c12", "st-NE36-c13", -67.250, 0.000, -494.420, LinkUse.road, comment: ""); //  70 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c13", "st-NE36-c14", -62.450, 0.000, -565.420, LinkUse.road, comment: ""); //  71 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c14", "st-NE36-c15", -56.690, 0.000, -595.290, LinkUse.road, comment: ""); //  72 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c15", "st-NE36-c16", -45.770, 0.000, -632.880, LinkUse.road, comment: ""); //  73 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c16", "st-NE36-c17", -31.470, 0.000, -675.780, LinkUse.road, comment: ""); //  74 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c17", "st-148NE-c00", -112.470, 0.000, -703.110, LinkUse.road, comment: ""); //  79 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c00", "st-148NE-c01", -180.080, 0.000, -726.270, LinkUse.road, comment: ""); //  80 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c01", "st-148NE-c02", -336.080, 0.000, -780.270, LinkUse.road, comment: ""); //  81 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c02", "st-148NE-c03", -500.780, 0.000, -835.270, LinkUse.road, comment: ""); //  82 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c03", "st-148NE-c04", -633.880, 0.000, -885.770, LinkUse.road, comment: ""); //  83 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c04", "st-148NE-c05", -784.680, 0.000, -941.970, LinkUse.road, comment: ""); //  84 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c05", "st-148NE-c06", -809.900, 0.000, -951.860, LinkUse.road, comment: ""); //  85 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c06", "st-148NE-c07", -870.160, 0.000, -975.180, LinkUse.road, comment: ""); //  86 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c07", "st-148NE-c08", -899.060, 0.000, -986.520, LinkUse.road, comment: ""); //  87 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c08", "st-148NE-c09", -973.360, 0.000, -1014.920, LinkUse.road, comment: ""); //  88 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c09", "st-148NE-c10", -1162.660, 0.000, -1087.620, LinkUse.road, comment: ""); //  89 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c10", "st-148NE-c11", -1289.760, 0.000, -1133.820, LinkUse.road, comment: ""); //  90 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c11", "st-148NE-c12", -1444.260, 0.000, -1181.920, LinkUse.road, comment: ""); //  91 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c12", "st-148NE-c13", -1628.860, 0.000, -1244.520, LinkUse.road, comment: ""); //  92 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c13", "st-148NE-c14", -1658.860, 0.000, -1255.520, LinkUse.road, comment: ""); //  93 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c14", "st-148NE-c15", -1741.400, 0.000, -1283.900, LinkUse.road, comment: ""); //  94 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c15", "st-148NE-c16", -1791.360, 0.000, -1301.220, LinkUse.road, comment: ""); //  95 nn:1 nl:1

            grc.regman.SetRegion("default");
        }
        public void createPointsFor_msft_campus()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-campus", "blue", saveToFile: true);
            grc.AddNodePtxyz("st-157NE-c02", -529.800, 0.000, 121.400, comment: ""); //  1 nn:1 nl:0
            grc.LinkToPtxyz("st-157NE-c02", "st-157NE-c03", -503.000, 0.000, 132.400, LinkUse.road, comment: ""); //  2 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c03", "st-157NE-c04", -440.000, 0.000, 154.200, LinkUse.road, comment: ""); //  3 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c04", "st-157NE-c05", -381.300, 0.000, 174.200, LinkUse.road, comment: ""); //  4 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c05", "st-157NE-c06", -219.700, 0.000, 226.600, LinkUse.road, comment: ""); //  5 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c06", "st-157NE-c07", -127.000, 0.000, 256.700, LinkUse.road, comment: ""); //  6 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c07", "st-157NE-c08", -86.400, 0.000, 270.200, LinkUse.road, comment: ""); //  7 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c08", "st-157NE-c09", -55.550, 0.000, 279.240, LinkUse.road, comment: ""); //  8 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c09", "st-157NE-c10", -27.140, 0.000, 279.240, LinkUse.road, comment: ""); //  9 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c10", "st-157NE-c11", -0.320, 0.000, 270.290, LinkUse.road, comment: ""); //  10 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c11", "st-157NE-c12", 17.750, 0.000, 256.890, LinkUse.road, comment: ""); //  11 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c12", "st-157NE-c13", 32.950, 0.000, 239.450, LinkUse.road, comment: ""); //  12 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c13", "st-157NE-c14", 46.270, 0.000, 209.200, LinkUse.road, comment: ""); //  13 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c14", "st-157NE-c15", 49.290, 0.000, 199.000, LinkUse.road, comment: ""); //  14 nn:1 nl:1
            grc.LinkToPtxyz("st-157NE-c15", "st-NE31-c24", 65.100, 0.000, 161.700, LinkUse.road, comment: ""); //  15 nn:1 nl:1
            grc.LinkToPtxyz("st-NE31-c24", "st-NE31-c23", 79.670, 0.000, 116.900, LinkUse.road, comment: ""); //  16 nn:1 nl:1
            grc.LinkToPtxyz("st-NE31-c23", "st-NE31-c22", 95.510, 0.000, 81.630, LinkUse.road, comment: ""); //  17 nn:1 nl:1
            grc.LinkToPtxyz("st-NE31-c22", "st-NE31-c21", 98.000, 0.000, 75.000, LinkUse.road, comment: ""); //  18 nn:1 nl:1
            grc.AddNodePtxyz("st-NE33-c02", 71.390, 0.000, 56.570, comment: ""); //  19 nn:1 nl:0
            grc.LinkToPtxyz("st-NE33-c02", "st-NE33-c03", 86.440, 0.000, 61.510, LinkUse.road, comment: ""); //  20 nn:1 nl:1
            grc.LinkToPtxyz("st-NE33-c03", "st-NE33-c04", 97.420, 0.000, 61.510, LinkUse.road, comment: ""); //  21 nn:1 nl:1
            grc.LinkToPtxyz("st-NE33-c04", "st-NE33-c05", 108.330, 0.000, 73.140, LinkUse.road, comment: ""); //  22 nn:1 nl:1
            grc.LinkToPtxyz("st-NE33-c05", "st-NE33-c06", 137.000, 0.000, 85.200, LinkUse.road, comment: ""); //  23 nn:1 nl:1
            grc.LinkToPtxyz("st-NE33-c06", "st-NE33-c07", 165.550, 0.000, 102.960, LinkUse.road, comment: ""); //  24 nn:1 nl:1
            grc.AddLinkByNodeName("st-NE31-c21", "st-NE33-c05", LinkUse.road); //  25 nn:0 nl:1
            grc.LinkToPtxyz("st-NE33-c04", "st-NE31-c00", 106.190, 0.000, 52.900, LinkUse.road, comment: ""); //  26 nn:1 nl:1
            grc.AddLinkByNodeName("st-NE31-c21", "st-NE33-c04", LinkUse.road); //  27 nn:0 nl:1
            grc.LinkToPtxyz("st-NE31-c00", "st-NE31-c01", 110.640, 0.000, 40.560, LinkUse.road, comment: ""); //  28 nn:1 nl:1
            grc.LinkToPtxyz("st-NE31-c01", "st-NE31-c02", 122.010, 0.000, 12.740, LinkUse.road, comment: ""); //  29 nn:1 nl:1
            grc.LinkToPtxyz("st-NE31-c02", "st-NE31-c03", 125.010, 0.000, -10.060, LinkUse.road, comment: ""); //  30 nn:1 nl:1
            grc.LinkToPtxyz("st-NE31-c03", "st-CRC1-c01", 124.690, 0.000, -27.370, LinkUse.road, comment: ""); //  31 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c01", "st-CRC1-c02", 116.540, 0.000, -30.700, LinkUse.road, comment: ""); //  32 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c02", "st-CRC1-c03", 110.460, 0.000, -37.780, LinkUse.road, comment: ""); //  33 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c03", "st-CRC1-c04", 110.460, 0.000, -45.590, LinkUse.road, comment: ""); //  34 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c04", "st-CRC1-c05", 113.160, 0.000, -52.910, LinkUse.road, comment: ""); //  35 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c05", "st-CRC1-c06", 120.330, 0.000, -56.930, LinkUse.road, comment: ""); //  36 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c06", "st-CRC1-c07", 129.710, 0.000, -56.930, LinkUse.road, comment: ""); //  37 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c07", "st-CRC1-c08", 138.230, 0.000, -47.430, LinkUse.road, comment: ""); //  38 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c08", "st-CRC1-c09", 138.230, 0.000, -37.780, LinkUse.road, comment: ""); //  39 nn:1 nl:1
            grc.LinkToPtxyz("st-CRC1-c09", "st-CRC1-c10", 134.190, 0.000, -31.350, LinkUse.road, comment: ""); //  40 nn:1 nl:1
            grc.AddLinkByNodeName("st-CRC1-c01", "st-CRC1-c10", LinkUse.road); //  41 nn:0 nl:1
            grc.LinkToPtxyz("st-CRC1-c04", "st-NE36-c00", 94.280, 0.000, -51.490, LinkUse.road, comment: ""); //  42 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c00", "st-NE36-c01", 62.460, 0.000, -72.410, LinkUse.road, comment: ""); //  43 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c01", "st-NE36-c02", 27.870, 0.000, -95.410, LinkUse.road, comment: ""); //  44 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c02", "st-NE36-c03", -24.020, 0.000, -129.850, LinkUse.road, comment: ""); //  45 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c03", "st-NE36-c04", -56.480, 0.000, -155.650, LinkUse.road, comment: ""); //  46 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c04", "st-NE36-c05", -67.570, 0.000, -170.630, LinkUse.road, comment: ""); //  47 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c05", "st-NE36-c06", -72.350, 0.000, -180.420, LinkUse.road, comment: ""); //  48 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c06", "st-NE36-c07", -77.100, 0.000, -193.340, LinkUse.road, comment: ""); //  49 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c07", "st-NE36-c08", -81.120, 0.000, -229.020, LinkUse.road, comment: ""); //  50 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c08", "st-NE36-c09", -82.380, 0.000, -270.390, LinkUse.road, comment: ""); //  51 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c09", "st-NE36-c10", -83.110, 0.000, -324.970, LinkUse.road, comment: ""); //  52 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c10", "st-NE36-c11", -80.950, 0.000, -350.820, LinkUse.road, comment: ""); //  53 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c11", "st-NE36-c12", -75.850, 0.000, -412.220, LinkUse.road, comment: ""); //  54 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c12", "st-NE36-c13", -67.250, 0.000, -494.420, LinkUse.road, comment: ""); //  55 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c13", "st-NE36-c14", -62.450, 0.000, -565.420, LinkUse.road, comment: ""); //  56 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c14", "st-NE36-c15", -56.690, 0.000, -595.290, LinkUse.road, comment: ""); //  57 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c15", "st-NE36-c16", -45.770, 0.000, -632.880, LinkUse.road, comment: ""); //  58 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c16", "st-NE36-c17", -31.470, 0.000, -675.780, LinkUse.road, comment: ""); //  59 nn:1 nl:1
            grc.LinkToPtxyz("st-NE36-c17", "st-148NE-c00", -112.470, 0.000, -703.110, LinkUse.road, comment: ""); //  60 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c00", "st-148NE-c01", -180.080, 0.000, -726.270, LinkUse.road, comment: ""); //  61 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c01", "st-148NE-c02", -336.080, 0.000, -780.270, LinkUse.road, comment: ""); //  62 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c02", "st-148NE-c03", -500.780, 0.000, -835.270, LinkUse.road, comment: ""); //  63 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c03", "st-148NE-c04", -633.880, 0.000, -885.770, LinkUse.road, comment: ""); //  64 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c04", "st-148NE-c05", -784.680, 0.000, -941.970, LinkUse.road, comment: ""); //  65 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c05", "st-148NE-c06", -809.900, 0.000, -951.860, LinkUse.road, comment: ""); //  66 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c06", "st-148NE-c07", -870.160, 0.000, -975.180, LinkUse.road, comment: ""); //  67 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c07", "st-148NE-c08", -899.060, 0.000, -986.520, LinkUse.road, comment: ""); //  68 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c08", "st-148NE-c09", -973.360, 0.000, -1014.920, LinkUse.road, comment: ""); //  69 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c09", "st-148NE-c10", -1162.660, 0.000, -1087.620, LinkUse.road, comment: ""); //  70 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c10", "st-148NE-c11", -1289.760, 0.000, -1133.820, LinkUse.road, comment: ""); //  71 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c11", "st-148NE-c12", -1444.260, 0.000, -1181.920, LinkUse.road, comment: ""); //  72 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c12", "st-148NE-c13", -1628.860, 0.000, -1244.520, LinkUse.road, comment: ""); //  73 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c13", "st-148NE-c14", -1658.860, 0.000, -1255.520, LinkUse.road, comment: ""); //  74 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c14", "st-148NE-c15", -1741.400, 0.000, -1283.900, LinkUse.road, comment: ""); //  75 nn:1 nl:1
            grc.LinkToPtxyz("st-148NE-c15", "st-148NE-c16", -1791.360, 0.000, -1301.220, LinkUse.road, comment: ""); //  76 nn:1 nl:1
            grc.regman.SetRegion("default");
        }
        public void CreateGraphForOsmImport_msft()  // machine generated - do not edit
        {
            grc.regman.NewNodeRegion("msft-campus", "blue", saveToFile: true);
            grc.AddNodePtxz("osm3801669054", 540.528, -490.249);
            grc.AddNodePtxz("osm53124320", -1951.347, 42.480);
            grc.AddNodePtxz("osm53036753", 505.473, -544.677);
            grc.AddNodePtxz("osm346082665", 552.518, -527.969);
            grc.AddNodePtxz("osm3801669564", 794.001, -406.366);
            grc.AddNodePtxz("osm53051520", 569.997, -491.156);
            grc.AddNodePtxz("osm53048880", 907.174, -364.366);
            grc.AddNodePtxz("osm6199263532", 935.136, -69.197);
            grc.AddNodePtxz("osm53070318", -1875.681, 730.339);
            grc.AddNodePtxz("osm53081274", -434.546, 951.398);
            grc.AddNodePtxz("osm53081337", -667.563, 1041.405);
            grc.AddNodePtxz("osm53084592", -1429.459, 1019.038);
            grc.AddNodePtxz("osm53089852", 22.984, 1020.484);
            grc.AddNodePtxz("osm53091684", -1487.041, 975.482);
            grc.AddNodePtxz("osm53097858", -1680.829, -421.273);
            grc.AddNodePtxz("osm53098139", 310.146, 1118.190);
            grc.AddNodePtxz("osm53100935", -1556.218, -546.158);
            grc.AddNodePtxz("osm4272141026", -1886.033, -1354.015);
            grc.AddNodePtxz("osm53102800", -1890.886, -1340.896);
            grc.AddNodePtxz("osm6199263533", 927.620, -71.612);
            grc.AddNodePtxz("osm53116727", 404.232, 1150.709);
            grc.AddNodePtxz("osm53124370", -2145.240, 149.445);
            grc.AddNodePtxz("osm53124375", -970.746, 469.120);
            grc.AddNodePtxz("osm53133391", -2398.386, 61.102);
            grc.AddNodePtxz("osm2298864238", -446.151, -991.862);
            grc.AddNodePtxz("osm4272218341", -581.162, -884.939);
            grc.AddNodePtxz("osm4272203606", 112.617, -647.143);
            grc.AddNodePtxz("osm53152233", -2063.838, -557.068);
            grc.AddNodePtxz("osm53152869", -2124.898, 490.151);
            grc.AddNodePtxz("osm53162445", -1669.591, -319.360);
            grc.AddNodePtxz("osm53162576", -2210.350, 365.484);
            grc.AddNodePtxz("osm53174314", -1604.199, 885.248);
            grc.AddNodePtxz("osm53176109", -1823.154, -45.588);
            grc.AddNodePtxz("osm53135404", 214.968, 1086.328);
            grc.AddNodePtxz("osm53190554", -2117.465, -575.728);
            grc.AddNodePtxz("osm53191528", -1188.258, 1076.581);
            grc.AddNodePtxz("osm53135409", -74.992, 988.796);
            grc.AddNodePtxz("osm53195739", -927.645, 344.483);
            grc.AddNodePtxz("osm53195788", 631.411, 804.168);
            grc.AddNodePtxz("osm53191552", -1894.142, -497.064);
            grc.AddNodePtxz("osm4272203617", -328.779, -794.893);
            grc.AddNodePtxz("osm53200311", -331.736, -784.048);
            grc.AddNodePtxz("osm53200804", -1165.160, -1092.448);
            grc.AddNodePtxz("osm4272141003", -1160.117, -1105.503);
            grc.AddNodePtxz("osm53217134", -1091.484, 808.312);
            grc.AddNodePtxz("osm53222541", -1004.798, 566.333);
            grc.AddNodePtxz("osm53227633", 662.030, 706.120);
            grc.AddNodePtxz("osm407651372", -902.006, 274.705);
            grc.AddNodePtxz("osm1738648109", -883.715, 218.831);
            grc.AddNodePtxz("osm53227661", -1774.743, -130.740);
            grc.AddNodePtxz("osm53135406", 122.214, 1054.281);
            grc.AddNodePtxz("osm2502193874", -2197.963, -605.654);
            grc.AddNodePtxz("osm4272141009", -1494.878, -926.889);
            grc.AddNodePtxz("osm1052709790", -1500.705, -891.401);
            grc.AddNodePtxz("osm53052387", -1502.320, -881.624);
            grc.AddNodePtxz("osm4272203603", 257.336, -596.910);
            grc.AddNodePtxz("osm53220870", -784.716, -954.117);
            grc.AddNodePtxz("osm4272218348", -915.067, -1012.312);
            grc.AddNodePtxz("osm53222823", -1656.902, 1106.303);
            grc.AddNodePtxz("osm53237531", -1721.205, -224.919);
            grc.AddNodePtxz("osm53191556", -2243.003, -623.537);
            grc.AddNodePtxz("osm53220861", 356.645, -558.500);
            grc.AddNodePtxz("osm53191553", -1975.351, -525.603);
            grc.AddNodePtxz("osm53135596", -1222.760, 1175.272);
            grc.AddNodePtxz("osm796674146", -1233.001, 1168.455);
            grc.AddNodePtxz("osm796660850", -1658.703, 845.898);
            grc.AddNodePtxz("osm53252643", -1682.499, 830.678);
            grc.AddNodePtxz("osm4272203612", -121.779, -723.870);
            grc.AddNodePtxz("osm53048846", 672.841, -455.623);
            grc.AddNodePtxz("osm3801669662", 766.083, -424.296);
            grc.AddNodePtxz("osm321378847", 696.985, 595.480);
            grc.AddNodePtxz("osm690687732", -1655.602, 950.793);
            grc.AddNodePtxz("osm321549405", 271.059, -582.065);
            grc.AddNodePtxz("osm327748939", -62.848, -495.181);
            grc.AddNodePtxz("osm1738823908", -79.571, -232.817);
            grc.AddNodePtxz("osm4294894960", -165.545, -239.515);
            grc.AddNodePtxz("osm2500883983", -66.854, -172.055);
            grc.AddNodePtxz("osm321548679", -70.359, -413.557);
            grc.AddNodePtxz("osm3227263344", -175.693, -730.587);
            grc.AddNodePtxz("osm53033470", -949.996, -158.672);
            grc.AddNodePtxz("osm1036683207", -743.058, -164.269);
            grc.AddNodePtxz("osm321550409", -1009.594, -179.749);
            grc.AddNodePtxz("osm2671019418", -809.020, 16.387);
            grc.AddNodePtxz("osm674168908", 1003.331, -252.281);
            grc.AddNodePtxz("osm321709193", -686.951, -316.749);
            grc.AddNodePtxz("osm4272180373", -1017.682, 602.298);
            grc.AddNodePtxz("osm2501227138", -1039.313, 662.675);
            grc.AddNodePtxz("osm6127378392", -1061.937, 725.818);
            grc.AddNodePtxz("osm2408047912", -1115.140, 874.697);
            grc.AddNodePtxz("osm2501224454", -1142.049, 949.610);
            grc.AddNodePtxz("osm1632149759", -1163.006, 1007.969);
            grc.AddNodePtxz("osm53141528", -1167.593, 1020.768);
            grc.AddNodePtxz("osm4272180374", -1192.386, 1088.372);
            grc.AddNodePtxz("osm740159601", 496.498, -509.933);
            grc.AddNodePtxz("osm739212836", 819.425, -406.201);
            grc.AddNodePtxz("osm3801669768", 816.824, -398.489);
            grc.AddNodePtxz("osm4735590835", 1009.498, -319.355);
            grc.AddNodePtxz("osm3218977982", 1018.586, -318.089);
            grc.AddNodePtxz("osm741922215", 1026.513, -313.451);
            grc.AddNodePtxz("osm332158830", 951.345, -112.483);
            grc.AddNodePtxz("osm332159041", 920.411, -27.447);
            grc.AddNodePtxz("osm3682698107", -1542.090, -541.638);
            grc.AddNodePtxz("osm6097094640", -1531.455, -538.496);
            grc.AddNodePtxz("osm3735501408", -1529.136, -537.877);
            grc.AddNodePtxz("osm332178519", -1499.921, -531.408);
            grc.AddNodePtxz("osm332178520", -1491.488, -527.737);
            grc.AddNodePtxz("osm2493133614", -1485.497, -523.096);
            grc.AddNodePtxz("osm332178521", -1479.754, -516.939);
            grc.AddNodePtxz("osm2493133611", -1473.939, -518.481);
            grc.AddNodePtxz("osm5916810770", -1463.018, -524.692);
            grc.AddNodePtxz("osm5916810769", -1456.243, -531.221);
            grc.AddNodePtxz("osm332178893", -1450.499, -537.635);
            grc.AddNodePtxz("osm332178895", -1445.385, -543.299);
            grc.AddNodePtxz("osm5916810768", -1440.304, -546.447);
            grc.AddNodePtxz("osm2493133616", -1435.828, -548.645);
            grc.AddNodePtxz("osm5916810767", -1430.275, -549.342);
            grc.AddNodePtxz("osm332178897", -1425.510, -549.105);
            grc.AddNodePtxz("osm5916810766", -1420.523, -548.792);
            grc.AddNodePtxz("osm332178899", -1415.449, -547.150);
            grc.AddNodePtxz("osm6074673255", -1409.315, -543.720);
            grc.AddNodePtxz("osm332178901", -1406.732, -542.273);
            grc.AddNodePtxz("osm2493133618", -1402.522, -537.093);
            grc.AddNodePtxz("osm332178903", -1394.708, -524.706);
            grc.AddNodePtxz("osm332178905", -1386.223, -514.260);
            grc.AddNodePtxz("osm332178907", -1377.396, -506.034);
            grc.AddNodePtxz("osm5916652901", -1367.484, -500.328);
            grc.AddNodePtxz("osm332178909", -1360.242, -497.064);
            grc.AddNodePtxz("osm2493133609", -1344.842, -491.198);
            grc.AddNodePtxz("osm332178911", -1331.098, -490.762);
            grc.AddNodePtxz("osm332178913", -1302.768, -493.231);
            grc.AddNodePtxz("osm1100843196", -1293.011, -494.509);
            grc.AddNodePtxz("osm332178915", -1281.144, -492.624);
            grc.AddNodePtxz("osm332178917", -1265.793, -488.803);
            grc.AddNodePtxz("osm2493133619", -1254.757, -483.005);
            grc.AddNodePtxz("osm332178919", -1242.699, -471.985);
            grc.AddNodePtxz("osm5916652958", -1238.906, -466.758);
            grc.AddNodePtxz("osm332178921", -1233.497, -459.314);
            grc.AddNodePtxz("osm6047169084", -1229.148, -448.549);
            grc.AddNodePtxz("osm332178923", -1226.347, -437.506);
            grc.AddNodePtxz("osm5916652961", -1225.511, -432.594);
            grc.AddNodePtxz("osm2493133606", -1224.101, -423.707);
            grc.AddNodePtxz("osm6047169085", -1222.470, -419.481);
            grc.AddNodePtxz("osm332178925", -1220.143, -416.062);
            grc.AddNodePtxz("osm6047169086", -1216.983, -412.224);
            grc.AddNodePtxz("osm332178927", -1213.276, -409.006);
            grc.AddNodePtxz("osm6047169087", -1210.872, -407.351);
            grc.AddNodePtxz("osm5916720781", -1207.132, -405.572);
            grc.AddNodePtxz("osm332178929", -1202.444, -404.307);
            grc.AddNodePtxz("osm6047169088", -1198.743, -403.492);
            grc.AddNodePtxz("osm6047169089", -1196.449, -403.776);
            grc.AddNodePtxz("osm332178931", -1194.061, -404.226);
            grc.AddNodePtxz("osm6047169091", -1189.560, -405.354);
            grc.AddNodePtxz("osm332178933", -1185.461, -407.183);
            grc.AddNodePtxz("osm332178935", -1176.968, -412.997);
            grc.AddNodePtxz("osm332178937", -1168.400, -419.356);
            grc.AddNodePtxz("osm332178939", -1160.738, -424.448);
            grc.AddNodePtxz("osm332178941", -1151.659, -425.712);
            grc.AddNodePtxz("osm2493133621", -1144.982, -424.670);
            grc.AddNodePtxz("osm332178943", -1139.350, -422.029);
            grc.AddNodePtxz("osm332178945", -1131.868, -415.214);
            grc.AddNodePtxz("osm6097094800", -1127.123, -410.683);
            grc.AddNodePtxz("osm332178947", -1122.181, -407.050);
            grc.AddNodePtxz("osm4274320609", -1115.008, -403.826);
            grc.AddNodePtxz("osm332178949", -1107.156, -400.686);
            grc.AddNodePtxz("osm334984185", -1741.467, -1289.030);
            grc.AddNodePtxz("osm335782985", -1363.655, -306.766);
            grc.AddNodePtxz("osm1100843195", -1415.199, -325.275);
            grc.AddNodePtxz("osm336497626", -1660.093, -1261.196);
            grc.AddNodePtxz("osm4272141020", -1655.787, -1272.824);
            grc.AddNodePtxz("osm2671019405", 376.786, 294.126);
            grc.AddNodePtxz("osm345259229", -866.822, -980.269);
            grc.AddNodePtxz("osm345259333", -808.775, -958.908);
            grc.AddNodePtxz("osm4272219831", -667.185, -372.790);
            grc.AddNodePtxz("osm766934115", -681.881, -330.452);
            grc.AddNodePtxz("osm53101051", -683.070, -327.033);
            grc.AddNodePtxz("osm4272203602", 277.641, -590.331);
            grc.AddNodePtxz("osm346502680", 273.786, -581.028);
            grc.AddNodePtxz("osm346508486", 573.577, -515.706);
            grc.AddNodePtxz("osm3801669788", 968.443, -355.312);
            grc.AddNodePtxz("osm346516376", 995.143, -346.616);
            grc.AddNodePtxz("osm3218977984", 1039.933, -380.450);
            grc.AddNodePtxz("osm2672560741", 335.628, -143.456);
            grc.AddNodePtxz("osm324749908", 815.792, 22.803);
            grc.AddNodePtxz("osm352544253", 398.355, -121.181);
            grc.AddNodePtxz("osm5429902641", 384.730, -126.020);
            grc.AddNodePtxz("osm352588051", 711.870, 338.958);
            grc.AddNodePtxz("osm3810659583", 707.641, 332.218);
            grc.AddNodePtxz("osm352588095", 741.284, 314.245);
            grc.AddNodePtxz("osm357040781", -57.500, -567.684);
            grc.AddNodePtxz("osm387552332", -686.805, -916.899);
            grc.AddNodePtxz("osm4272218342", -595.564, -890.289);
            grc.AddNodePtxz("osm387552346", -600.666, -878.039);
            grc.AddNodePtxz("osm828422475", 499.907, 1183.273);
            grc.AddNodePtxz("osm2563978903", 127.586, 9.496);
            grc.AddNodePtxz("osm748632244", -12.154, 755.503);
            grc.AddNodePtxz("osm3801669779", 867.644, -390.050);
            grc.AddNodePtxz("osm53206031", -1524.058, -745.119);
            grc.AddNodePtxz("osm53052405", -1531.668, -702.232);
            grc.AddNodePtxz("osm602854096", -1510.999, -828.702);
            grc.AddNodePtxz("osm4272141007", -1515.245, -801.718);
            grc.AddNodePtxz("osm690687786", -1918.433, 704.795);
            grc.AddNodePtxz("osm3810659585", 743.710, 433.230);
            grc.AddNodePtxz("osm3810659598", 751.143, 436.186);
            grc.AddNodePtxz("osm708968737", 762.160, 425.502);
            grc.AddNodePtxz("osm740159652", -1777.465, 779.457);
            grc.AddNodePtxz("osm740155369", -2196.397, 187.872);
            grc.AddNodePtxz("osm740155215", -1218.515, 1162.910);
            grc.AddNodePtxz("osm740155200", 1036.910, -343.272);
            grc.AddNodePtxz("osm3218977983", 1028.444, -346.376);
            grc.AddNodePtxz("osm741922201", 1019.524, -338.205);
            grc.AddNodePtxz("osm3801669596", 1016.217, -327.843);
            grc.AddNodePtxz("osm741885619", 793.664, 290.312);
            grc.AddNodePtxz("osm6193462230", 802.723, 289.175);
            grc.AddNodePtxz("osm321372391", 806.409, 300.014);
            grc.AddNodePtxz("osm6193462229", 795.025, 311.675);
            grc.AddNodePtxz("osm741885590", 784.549, 315.978);
            grc.AddNodePtxz("osm741885662", 779.554, 305.103);
            grc.AddNodePtxz("osm741885710", 887.929, 58.937);
            grc.AddNodePtxz("osm6196674550", 880.862, 55.947);
            grc.AddNodePtxz("osm6199263530", 930.930, -57.282);
            grc.AddNodePtxz("osm6199263531", 923.495, -59.962);
            grc.AddNodePtxz("osm741922180", 889.014, 33.667);
            grc.AddNodePtxz("osm6215037916", 896.555, 36.146);
            grc.AddNodePtxz("osm741922213", 874.265, 42.781);
            grc.AddNodePtxz("osm741922198", 932.325, -84.378);
            grc.AddNodePtxz("osm6199263529", 939.696, -81.380);
            grc.AddNodePtxz("osm743394852", -637.412, -458.517);
            grc.AddNodePtxz("osm53220872", -1294.787, -1140.302);
            grc.AddNodePtxz("osm1036683205", 75.047, 192.475);
            grc.AddNodePtxz("osm747690834", 716.157, 531.955);
            grc.AddNodePtxz("osm6193202163", 707.613, 560.565);
            grc.AddNodePtxz("osm747467298", 544.630, 428.605);
            grc.AddNodePtxz("osm747467301", 512.591, 340.008);
            grc.AddNodePtxz("osm752198079", 270.237, 591.684);
            grc.AddNodePtxz("osm752197940", 438.611, 319.442);
            grc.AddNodePtxz("osm752197849", 538.744, 436.365);
            grc.AddNodePtxz("osm752198034", 286.860, 581.398);
            grc.AddNodePtxz("osm752197846", 369.161, 533.829);
            grc.AddNodePtxz("osm752197967", 518.592, 447.463);
            grc.AddNodePtxz("osm752198074", 497.697, 459.535);
            grc.AddNodePtxz("osm752197997", 718.659, 523.956);
            grc.AddNodePtxz("osm752197888", 725.855, 491.827);
            grc.AddNodePtxz("osm752197903", 412.425, 306.358);
            grc.AddNodePtxz("osm752198142", 404.236, 513.557);
            grc.AddNodePtxz("osm3810659609", 774.158, 371.427);
            grc.AddNodePtxz("osm3810659579", 759.302, 412.102);
            grc.AddNodePtxz("osm3810659586", 751.477, 409.558);
            grc.AddNodePtxz("osm6193024932", 740.694, 413.424);
            grc.AddNodePtxz("osm708968749", 737.355, 422.935);
            grc.AddNodePtxz("osm752198041", 493.979, 461.692);
            grc.AddNodePtxz("osm752210780", 698.879, -17.649);
            grc.AddNodePtxz("osm752210775", 670.443, 362.203);
            grc.AddNodePtxz("osm752210733", 667.921, 371.741);
            grc.AddNodePtxz("osm752210691", 667.495, 377.995);
            grc.AddNodePtxz("osm6199263535", 668.729, 382.109);
            grc.AddNodePtxz("osm752210663", 672.420, 393.908);
            grc.AddNodePtxz("osm752198130", 384.999, 296.977);
            grc.AddNodePtxz("osm752210658", 776.584, 339.677);
            grc.AddNodePtxz("osm752210687", 752.785, 313.746);
            grc.AddNodePtxz("osm708983296", 614.469, 389.080);
            grc.AddNodePtxz("osm6196828183", 622.970, 392.220);
            grc.AddNodePtxz("osm767507601", 648.359, 385.964);
            grc.AddNodePtxz("osm6196828181", 649.105, 374.393);
            grc.AddNodePtxz("osm708983284", 642.788, 372.326);
            grc.AddNodePtxz("osm6193024934", 709.393, 402.074);
            grc.AddNodePtxz("osm752210770", 768.745, 362.547);
            grc.AddNodePtxz("osm3810659613", 667.001, 357.255);
            grc.AddNodePtxz("osm752210675", 714.972, -12.076);
            grc.AddNodePtxz("osm53135585", -1.886, 749.306);
            grc.AddNodePtxz("osm1738648104", -773.972, -78.687);
            grc.AddNodePtxz("osm2192655194", -416.952, 25.618);
            grc.AddNodePtxz("osm767541796", -786.637, -100.007);
            grc.AddNodePtxz("osm767541804", -762.964, -108.870);
            grc.AddNodePtxz("osm796660790", -1684.419, 841.792);
            grc.AddNodePtxz("osm690687879", -1684.350, 860.217);
            grc.AddNodePtxz("osm53252644", -1742.811, 796.010);
            grc.AddNodePtxz("osm796660876", -1660.119, 922.591);
            grc.AddNodePtxz("osm796660783", -1656.431, 943.340);
            grc.AddNodePtxz("osm796674160", -1211.602, 1182.672);
            grc.AddNodePtxz("osm796674175", -1227.187, 1187.080);
            grc.AddNodePtxz("osm829661270", -469.073, -924.005);
            grc.AddNodePtxz("osm829661281", -485.644, -834.416);
            grc.AddNodePtxz("osm4272203623", -483.469, -845.553);
            grc.AddNodePtxz("osm4272203622", -455.340, -837.334);
            grc.AddNodePtxz("osm829661304", -476.545, -901.611);
            grc.AddNodePtxz("osm829661224", 736.100, 459.379);
            grc.AddNodePtxz("osm878385178", -69.175, 990.741);
            grc.AddNodePtxz("osm878385128", 114.907, 1051.772);
            grc.AddNodePtxz("osm1036690323", -1039.522, -1051.140);
            grc.AddNodePtxz("osm3940750553", -1034.881, -1063.959);
            grc.AddNodePtxz("osm2298864452", -1025.468, -1097.160);
            grc.AddNodePtxz("osm2298864462", -1020.709, -1110.415);
            grc.AddNodePtxz("osm809706774", -1006.614, -1151.477);
            grc.AddNodePtxz("osm1063428302", -641.734, 1031.173);
            grc.AddNodePtxz("osm1082877364", -29.870, -134.212);
            grc.AddNodePtxz("osm1117301838", -48.059, -147.964);
            grc.AddNodePtxz("osm1082877387", -54.944, -154.797);
            grc.AddNodePtxz("osm1082881764", 113.937, -33.357);
            grc.AddNodePtxz("osm1082877367", 112.089, -36.762);
            grc.AddNodePtxz("osm4488084017", 111.165, -40.516);
            grc.AddNodePtxz("osm2563978829", 111.218, -44.396);
            grc.AddNodePtxz("osm4488084018", 112.238, -48.142);
            grc.AddNodePtxz("osm1488907729", 114.178, -51.517);
            grc.AddNodePtxz("osm1082877399", 116.903, -54.307);
            grc.AddNodePtxz("osm346078654", -716.299, -238.956);
            grc.AddNodePtxz("osm1105703434", -690.563, -307.165);
            grc.AddNodePtxz("osm1082877435", 80.516, -62.091);
            grc.AddNodePtxz("osm1835913814", -8.254, -120.007);
            grc.AddNodePtxz("osm3218977987", 976.970, -205.413);
            grc.AddNodePtxz("osm3218977985", 995.236, -254.862);
            grc.AddNodePtxz("osm3810659588", 957.764, -153.354);
            grc.AddNodePtxz("osm3801669633", 795.591, -414.559);
            grc.AddNodePtxz("osm6219028620", 815.388, -407.639);
            grc.AddNodePtxz("osm281301770", -534.474, -735.639);
            grc.AddNodePtxz("osm53183073", -294.514, -771.352);
            grc.AddNodePtxz("osm4272203616", -290.478, -783.017);
            grc.AddNodePtxz("osm2920682248", 1049.938, -409.827);
            grc.AddNodePtxz("osm2155615939", 689.830, -529.868);
            grc.AddNodePtxz("osm2298864385", -987.972, -1032.177);
            grc.AddNodePtxz("osm6199662240", 454.097, -102.296);
            grc.AddNodePtxz("osm5147868528", 414.594, -115.685);
            grc.AddNodePtxz("osm6323984645", 346.296, -139.669);
            grc.AddNodePtxz("osm2500980951", 321.069, -146.444);
            grc.AddNodePtxz("osm1082877423", 312.036, -146.352);
            grc.AddNodePtxz("osm1488907744", 304.506, -143.083);
            grc.AddNodePtxz("osm53091621", 294.509, -137.792);
            grc.AddNodePtxz("osm53091623", 273.243, -124.699);
            grc.AddNodePtxz("osm6046905082", 262.093, -118.274);
            grc.AddNodePtxz("osm4272141015", -1450.518, -1202.416);
            grc.AddNodePtxz("osm2493126713", -973.284, -1026.935);
            grc.AddNodePtxz("osm53247733", -563.673, -656.655);
            grc.AddNodePtxz("osm415837860", 383.396, -548.471);
            grc.AddNodePtxz("osm752210744", 603.851, -50.712);
            grc.AddNodePtxz("osm347249273", 613.390, -47.304);
            grc.AddNodePtxz("osm347249342", 626.799, -42.587);
            grc.AddNodePtxz("osm6199662234", 639.406, -38.342);
            grc.AddNodePtxz("osm2563978831", 94.280, -54.788);
            grc.AddNodePtxz("osm2563978833", 98.204, -53.263);
            grc.AddNodePtxz("osm4274827327", 100.724, -52.780);
            grc.AddNodePtxz("osm2563978835", 102.130, -52.283);
            grc.AddNodePtxz("osm2563978837", 106.617, -51.856);
            grc.AddNodePtxz("osm2563978839", 110.291, -52.579);
            grc.AddNodePtxz("osm1082881763", 123.515, -57.383);
            grc.AddNodePtxz("osm2563978841", 129.691, -61.534);
            grc.AddNodePtxz("osm2563978843", 136.623, -66.695);
            grc.AddNodePtxz("osm3934726146", 139.865, -69.276);
            grc.AddNodePtxz("osm2563978845", 144.936, -73.172);
            grc.AddNodePtxz("osm2563978847", 150.504, -76.700);
            grc.AddNodePtxz("osm2563978848", 156.389, -79.684);
            grc.AddNodePtxz("osm2563978850", 162.532, -81.422);
            grc.AddNodePtxz("osm2563978852", 170.186, -82.256);
            grc.AddNodePtxz("osm2563978827", 177.412, -83.283);
            grc.AddNodePtxz("osm2563978855", 161.937, -76.200);
            grc.AddNodePtxz("osm2563978856", 155.729, -73.335);
            grc.AddNodePtxz("osm2563978859", 152.310, -70.988);
            grc.AddNodePtxz("osm2563978861", 149.440, -68.089);
            grc.AddNodePtxz("osm2563978863", 145.521, -64.084);
            grc.AddNodePtxz("osm2563978865", 143.262, -60.033);
            grc.AddNodePtxz("osm2563978867", 142.043, -56.561);
            grc.AddNodePtxz("osm2563978869", 141.514, -53.273);
            grc.AddNodePtxz("osm1082881766", 141.359, -46.513);
            grc.AddNodePtxz("osm1082877406", 140.639, -36.328);
            grc.AddNodePtxz("osm2563978870", 135.464, -24.039);
            grc.AddNodePtxz("osm2563978871", 133.814, -17.759);
            grc.AddNodePtxz("osm3934726738", 133.260, -15.407);
            grc.AddNodePtxz("osm2563978872", 131.970, -9.883);
            grc.AddNodePtxz("osm2563978873", 130.517, -1.509);
            grc.AddNodePtxz("osm2563978874", 128.740, 6.208);
            grc.AddNodePtxz("osm2563978875", 127.174, 10.670);
            grc.AddNodePtxz("osm2563978876", 124.023, 16.990);
            grc.AddNodePtxz("osm1082877429", 85.958, 110.105);
            grc.AddNodePtxz("osm6198997576", 88.740, 91.024);
            grc.AddNodePtxz("osm6198997574", 91.965, 82.306);
            grc.AddNodePtxz("osm409460061", 96.528, 69.340);
            grc.AddNodePtxz("osm6198997570", 99.518, 61.460);
            grc.AddNodePtxz("osm2563978878", 112.632, 23.800);
            grc.AddNodePtxz("osm2563978879", 122.247, 7.162);
            grc.AddNodePtxz("osm2563978880", 124.091, 2.985);
            grc.AddNodePtxz("osm2563978881", 125.255, -0.870);
            grc.AddNodePtxz("osm2563978882", 125.655, -5.169);
            grc.AddNodePtxz("osm2563978883", 125.726, -10.143);
            grc.AddNodePtxz("osm2563978884", 124.747, -15.287);
            grc.AddNodePtxz("osm2563978885", 123.100, -20.105);
            grc.AddNodePtxz("osm2563978886", 120.882, -24.373);
            grc.AddNodePtxz("osm2563978888", 119.524, -26.319);
            grc.AddNodePtxz("osm1082877433", 117.234, -29.440);
            grc.AddNodePtxz("osm2563978893", 109.965, -37.196);
            grc.AddNodePtxz("osm2563978889", 105.951, -40.986);
            grc.AddNodePtxz("osm4274827329", 98.133, -47.449);
            grc.AddNodePtxz("osm2563978891", 91.421, -52.995);
            grc.AddNodePtxz("osm1491102454", -55.231, -581.776);
            grc.AddNodePtxz("osm321548681", -50.078, -601.867);
            grc.AddNodePtxz("osm3679402919", -30.269, -667.780);
            grc.AddNodePtxz("osm321548682", -26.339, -680.621);
            grc.AddNodePtxz("osm2614085260", -480.461, -889.881);
            grc.AddNodePtxz("osm2493133613", -1568.350, -513.041);
            grc.AddNodePtxz("osm3222406596", -1575.759, -497.074);
            grc.AddNodePtxz("osm334967225", -1579.635, -488.721);
            grc.AddNodePtxz("osm3682699014", -1622.740, -409.681);
            grc.AddNodePtxz("osm53191551", -1627.437, -401.070);
            grc.AddNodePtxz("osm3682699013", -1617.196, -397.311);
            grc.AddNodePtxz("osm53191550", -1156.647, -232.103);
            grc.AddNodePtxz("osm321550408", -1031.291, -188.008);
            grc.AddNodePtxz("osm2300480674", -2005.145, 637.689);
            grc.AddNodePtxz("osm6577715947", -2022.974, 619.585);
            grc.AddNodePtxz("osm53252647", -2035.803, 606.559);
            grc.AddNodePtxz("osm53252648", -2088.311, 541.459);
            grc.AddNodePtxz("osm53252650", -2452.396, -34.336);
            grc.AddNodePtxz("osm53252651", -2490.364, -101.135);
            grc.AddNodePtxz("osm3163410722", -2519.708, -143.366);
            grc.AddNodePtxz("osm740159704", -2535.433, -165.986);
            grc.AddNodePtxz("osm740159647", -2571.986, -209.155);
            grc.AddNodePtxz("osm53083965", -2581.552, -218.704);
            grc.AddNodePtxz("osm4049735544", -69.039, -427.870);
            grc.AddNodePtxz("osm321548680", -59.073, -540.585);
            grc.AddNodePtxz("osm3731157589", -58.126, -556.960);
            grc.AddNodePtxz("osm2657798420", 165.469, 652.141);
            grc.AddNodePtxz("osm53135584", 141.831, 665.943);
            grc.AddNodePtxz("osm4272190807", 70.103, 707.555);
            grc.AddNodePtxz("osm2657798417", -592.411, 1011.311);
            grc.AddNodePtxz("osm740159575", -853.288, 1114.815);
            grc.AddNodePtxz("osm740159694", -960.858, 1153.107);
            grc.AddNodePtxz("osm281302479", -1034.534, 1175.230);
            grc.AddNodePtxz("osm2501221678", -1125.454, 1197.914);
            grc.AddNodePtxz("osm2501221677", -1141.067, 1199.880);
            grc.AddNodePtxz("osm3054311154", -1420.112, -1180.886);
            grc.AddNodePtxz("osm3054311158", -1469.077, -1084.175);
            grc.AddNodePtxz("osm3054311140", -1399.388, -1174.694);
            grc.AddNodePtxz("osm3054311159", -1459.020, -1145.426);
            grc.AddNodePtxz("osm3218977981", 1025.345, -336.268);
            grc.AddNodePtxz("osm53220860", 1033.740, -333.164);
            grc.AddNodePtxz("osm3801669809", 1000.246, -268.127);
            grc.AddNodePtxz("osm6217633462", 1018.004, -316.498);
            grc.AddNodePtxz("osm3801669691", 1021.680, -326.029);
            grc.AddNodePtxz("osm4272164139", 730.204, 478.059);
            grc.AddNodePtxz("osm6193024942", 743.184, 434.761);
            grc.AddNodePtxz("osm6199821193", 745.967, 425.994);
            grc.AddNodePtxz("osm4272203609", -10.142, -687.038);
            grc.AddNodePtxz("osm3225792975", -13.737, -676.695);
            grc.AddNodePtxz("osm4272203605", 200.185, -617.394);
            grc.AddNodePtxz("osm3225789655", 195.761, -605.934);
            grc.AddNodePtxz("osm3227263347", -501.249, -831.164);
            grc.AddNodePtxz("osm4272203611", -35.035, -694.261);
            grc.AddNodePtxz("osm3227264069", -38.681, -683.975);
            grc.AddNodePtxz("osm327750040", -73.224, -185.666);
            grc.AddNodePtxz("osm1488907728", -77.745, -201.623);
            grc.AddNodePtxz("osm4049735526", -79.550, -252.034);
            grc.AddNodePtxz("osm321548678", -78.824, -270.670);
            grc.AddNodePtxz("osm1491102457", -77.387, -342.081);
            grc.AddNodePtxz("osm4049735528", -71.513, -401.832);
            grc.AddNodePtxz("osm53237534", -2286.029, 255.554);
            grc.AddNodePtxz("osm3516771379", -908.162, 289.620);
            grc.AddNodePtxz("osm3543342011", -1015.775, -182.102);
            grc.AddNodePtxz("osm3588045954", -1801.043, -81.863);
            grc.AddNodePtxz("osm3801669737", 514.831, -509.431);
            grc.AddNodePtxz("osm3682699015", -1632.945, -390.353);
            grc.AddNodePtxz("osm6577673585", -1644.751, -367.407);
            grc.AddNodePtxz("osm3682698110", -1702.074, -260.162);
            grc.AddNodePtxz("osm2493146411", -1813.200, -59.259);
            grc.AddNodePtxz("osm2493146434", -1836.296, -36.145);
            grc.AddNodePtxz("osm53237532", -1855.881, -22.730);
            grc.AddNodePtxz("osm53237533", -1882.180, -5.949);
            grc.AddNodePtxz("osm6122409163", -1910.398, 13.810);
            grc.AddNodePtxz("osm6122409166", -1930.670, 28.005);
            grc.AddNodePtxz("osm6577716007", -2014.610, 84.613);
            grc.AddNodePtxz("osm690687066", -2042.125, 102.942);
            grc.AddNodePtxz("osm2493194112", -2059.923, 110.996);
            grc.AddNodePtxz("osm2493194059", -2134.157, 144.288);
            grc.AddNodePtxz("osm6122409136", -2206.749, 195.687);
            grc.AddNodePtxz("osm4272285441", -2236.349, 218.039);
            grc.AddNodePtxz("osm3682685796", -1534.000, -683.560);
            grc.AddNodePtxz("osm3682698109", -1539.333, -651.023);
            grc.AddNodePtxz("osm53237530", -1551.290, -575.150);
            grc.AddNodePtxz("osm4272190808", -53.511, 778.717);
            grc.AddNodePtxz("osm878302217", -137.681, 826.399);
            grc.AddNodePtxz("osm2657798422", -177.887, 846.736);
            grc.AddNodePtxz("osm53135587", -233.359, 869.800);
            grc.AddNodePtxz("osm53135589", -296.925, 895.250);
            grc.AddNodePtxz("osm52987393", -505.630, 976.556);
            grc.AddNodePtxz("osm3722441489", 1171.653, -870.673);
            grc.AddNodePtxz("osm1724480327", 1159.898, -865.920);
            grc.AddNodePtxz("osm2500812148", 1146.658, -857.406);
            grc.AddNodePtxz("osm1724480343", 1136.182, -847.020);
            grc.AddNodePtxz("osm2500812146", 1128.701, -835.790);
            grc.AddNodePtxz("osm1724480377", 1123.055, -820.850);
            grc.AddNodePtxz("osm1724480347", 1117.882, -802.651);
            grc.AddNodePtxz("osm1724480331", 1107.956, -750.679);
            grc.AddNodePtxz("osm1724480340", 1103.517, -737.964);
            grc.AddNodePtxz("osm2500812153", 1096.610, -724.438);
            grc.AddNodePtxz("osm2500812145", 1088.180, -711.917);
            grc.AddNodePtxz("osm1724480381", 1076.119, -699.403);
            grc.AddNodePtxz("osm2500812152", 1061.217, -690.556);
            grc.AddNodePtxz("osm1724480386", 1028.894, -672.344);
            grc.AddNodePtxz("osm1724480389", 992.049, -655.633);
            grc.AddNodePtxz("osm3377549101", 940.016, -641.966);
            grc.AddNodePtxz("osm53130846", 915.124, -634.772);
            grc.AddNodePtxz("osm1738783629", 867.387, -615.936);
            grc.AddNodePtxz("osm2155615936", 857.762, -611.436);
            grc.AddNodePtxz("osm3731157286", 770.086, -568.853);
            grc.AddNodePtxz("osm1835922428", 641.715, -510.559);
            grc.AddNodePtxz("osm1835922410", 630.418, -507.646);
            grc.AddNodePtxz("osm53130848", 618.277, -506.162);
            grc.AddNodePtxz("osm53130849", 602.657, -507.002);
            grc.AddNodePtxz("osm1738771461", 585.667, -510.926);
            grc.AddNodePtxz("osm53130850", 540.780, -535.766);
            grc.AddNodePtxz("osm2500881974", 530.669, -542.317);
            grc.AddNodePtxz("osm1738771468", 523.800, -545.096);
            grc.AddNodePtxz("osm2500881948", 517.044, -546.554);
            grc.AddNodePtxz("osm2500881972", 510.271, -546.179);
            grc.AddNodePtxz("osm2500881961", 499.239, -541.234);
            grc.AddNodePtxz("osm346508489", 494.007, -536.712);
            grc.AddNodePtxz("osm2500881969", 489.878, -530.799);
            grc.AddNodePtxz("osm740159768", 488.131, -528.141);
            grc.AddNodePtxz("osm53059230", 481.228, -515.097);
            grc.AddNodePtxz("osm4272203614", -251.131, -769.452);
            grc.AddNodePtxz("osm331738691", -255.797, -757.971);
            grc.AddNodePtxz("osm3801669622", 1008.933, -311.493);
            grc.AddNodePtxz("osm3801669020", 1007.037, -324.475);
            grc.AddNodePtxz("osm3801669680", 984.503, -338.218);
            grc.AddNodePtxz("osm3801669748", 510.921, -500.845);
            grc.AddNodePtxz("osm4045186106", -1202.632, -1106.179);
            grc.AddNodePtxz("osm53040038", -1258.734, -1126.930);
            grc.AddNodePtxz("osm4045186108", -1411.005, -1178.164);
            grc.AddNodePtxz("osm3682699441", -1435.402, -1185.051);
            grc.AddNodePtxz("osm53220873", -1452.081, -1189.596);
            grc.AddNodePtxz("osm3801669764", 760.085, -418.198);
            grc.AddNodePtxz("osm3801669574", 667.778, -450.409);
            grc.AddNodePtxz("osm3801669799", 1030.084, -322.883);
            grc.AddNodePtxz("osm767541807", -758.269, -89.947);
            grc.AddNodePtxz("osm3810659612", 967.704, -156.162);
            grc.AddNodePtxz("osm3940718876", 702.379, 344.287);
            grc.AddNodePtxz("osm6196828178", 652.770, 372.154);
            grc.AddNodePtxz("osm3810659590", 637.722, 382.323);
            grc.AddNodePtxz("osm321546603", 631.117, 379.697);
            grc.AddNodePtxz("osm3810659617", 665.409, 357.993);
            grc.AddNodePtxz("osm3810659618", 750.931, 314.355);
            grc.AddNodePtxz("osm53135573", 263.683, 594.795);
            grc.AddNodePtxz("osm6199821195", 749.350, 416.086);
            grc.AddNodePtxz("osm752197878", 766.418, 369.244);
            grc.AddNodePtxz("osm4272164140", 772.352, 352.304);
            grc.AddNodePtxz("osm6215037915", 884.341, 46.239);
            grc.AddNodePtxz("osm4272164136", 916.735, -40.872);
            grc.AddNodePtxz("osm3218977989", 836.064, 176.882);
            grc.AddNodePtxz("osm3810659599", 928.053, -49.117);
            grc.AddNodePtxz("osm4272164127", 913.344, -7.417);
            grc.AddNodePtxz("osm6199821192", 753.787, 428.719);
            grc.AddNodePtxz("osm4584498739", 739.186, 472.064);
            grc.AddNodePtxz("osm4272164133", 735.272, 484.895);
            grc.AddNodePtxz("osm3810659600", 869.589, 108.631);
            grc.AddNodePtxz("osm6193462233", 798.812, 301.224);
            grc.AddNodePtxz("osm4272164135", 765.477, 394.777);
            grc.AddNodePtxz("osm3810659594", 851.839, 156.712);
            grc.AddNodePtxz("osm3222664596", -2041.128, -1391.356);
            grc.AddNodePtxz("osm740159624", 472.633, -518.000);
            grc.AddNodePtxz("osm4278382985", 288.993, 259.642);
            grc.AddNodePtxz("osm4881717531", 498.966, -87.150);
            grc.AddNodePtxz("osm3934726662", 98.115, 84.546);
            grc.AddNodePtxz("osm4275697402", 214.088, 234.015);
            grc.AddNodePtxz("osm4017340409", 211.096, 242.805);
            grc.AddNodePtxz("osm4272203620", -418.638, -812.063);
            grc.AddNodePtxz("osm53220868", -497.441, -842.114);
            grc.AddNodePtxz("osm347253787", 891.662, 48.840);
            grc.AddNodePtxz("osm741885671", 901.954, 52.355);
            grc.AddNodePtxz("osm322979488", 975.511, 76.412);
            grc.AddNodePtxz("osm4280806663", 994.278, 82.433);
            grc.AddNodePtxz("osm3054684636", 1030.342, 93.995);
            grc.AddNodePtxz("osm741885588", 1091.586, 115.120);
            grc.AddNodePtxz("osm741885728", 1121.947, 125.585);
            grc.AddNodePtxz("osm3054684633", 1139.372, 131.598);
            grc.AddNodePtxz("osm53074772", 1145.201, 133.610);
            grc.AddNodePtxz("osm3054683928", 1148.980, 134.911);
            grc.AddNodePtxz("osm3054683903", 1190.776, 149.331);
            grc.AddNodePtxz("osm741885667", 1200.795, 152.784);
            grc.AddNodePtxz("osm741599962", 1204.598, 153.912);
            grc.AddNodePtxz("osm347260128", 707.667, -14.656);
            grc.AddNodePtxz("osm4488084036", 730.815, -6.597);
            grc.AddNodePtxz("osm6199662231", 843.669, 32.212);
            grc.AddNodePtxz("osm53183285", 59.320, 187.003);
            grc.AddNodePtxz("osm4045186101", 6.669, 169.224);
            grc.AddNodePtxz("osm5434210419", -101.446, 132.544);
            grc.AddNodePtxz("osm53146535", -103.407, 131.881);
            grc.AddNodePtxz("osm5434223623", -139.112, 119.768);
            grc.AddNodePtxz("osm3807446933", -182.563, 105.020);
            grc.AddNodePtxz("osm767541773", -383.455, 36.864);
            grc.AddNodePtxz("osm2671019420", -401.329, 30.784);
            grc.AddNodePtxz("osm1738648032", 363.751, 290.225);
            grc.AddNodePtxz("osm4275697397", 335.368, 281.451);
            grc.AddNodePtxz("osm4045186098", 80.976, 122.888);
            grc.AddNodePtxz("osm1036683210", 63.090, 175.121);
            grc.AddNodePtxz("osm4272236132", -751.456, -140.814);
            grc.AddNodePtxz("osm5916914821", -744.501, -160.224);
            grc.AddNodePtxz("osm4272236131", -735.014, -186.713);
            grc.AddNodePtxz("osm829661249", -436.895, -1018.533);
            grc.AddNodePtxz("osm4272219827", -485.124, -876.530);
            grc.AddNodePtxz("osm345518571", -579.699, -29.717);
            grc.AddNodePtxz("osm53135569", 788.839, 303.220);
            grc.AddNodePtxz("osm6193462231", 778.012, 305.430);
            grc.AddNodePtxz("osm4267453636", 599.630, 384.404);
            grc.AddNodePtxz("osm708983283", 616.686, 375.002);
            grc.AddNodePtxz("osm4267453637", 588.966, 403.693);
            grc.AddNodePtxz("osm4267453634", 599.674, 389.520);
            grc.AddNodePtxz("osm6199263534", 598.991, 381.587);
            grc.AddNodePtxz("osm4267453640", 595.154, 367.781);
            grc.AddNodePtxz("osm4272218339", -557.634, -866.634);
            grc.AddNodePtxz("osm4272218340", -585.047, -871.955);
            grc.AddNodePtxz("osm4045186102", -596.484, -876.409);
            grc.AddNodePtxz("osm4302836459", -644.369, -895.060);
            grc.AddNodePtxz("osm4272218343", -662.418, -902.086);
            grc.AddNodePtxz("osm4272141024", -1814.979, -1327.599);
            grc.AddNodePtxz("osm4608804269", -1787.691, -1318.059);
            grc.AddNodePtxz("osm4272141023", -1737.098, -1300.367);
            grc.AddNodePtxz("osm4272141021", -1677.597, -1267.054);
            grc.AddNodePtxz("osm4608804262", -1794.245, -1307.352);
            grc.AddNodePtxz("osm4272141025", -1849.675, -1326.589);
            grc.AddNodePtxz("osm3805839899", -1721.061, -1281.593);
            grc.AddNodePtxz("osm4272141004", -1201.025, -1120.505);
            grc.AddNodePtxz("osm4272140996", -1197.705, -1119.274);
            grc.AddNodePtxz("osm4272141018", -1632.330, -1251.193);
            grc.AddNodePtxz("osm53220874", -1646.134, -1256.164);
            grc.AddNodePtxz("osm3805839898", -2029.905, -1388.108);
            grc.AddNodePtxz("osm4613004707", -995.104, -1034.745);
            grc.AddNodePtxz("osm53220871", -1012.455, -1041.002);
            grc.AddNodePtxz("osm4272141002", -1104.625, -1069.403);
            grc.AddNodePtxz("osm4272141017", -1551.625, -1236.982);
            grc.AddNodePtxz("osm4272140998", -1514.910, -1223.748);
            grc.AddNodePtxz("osm4272141016", -1460.837, -1205.149);
            grc.AddNodePtxz("osm4272141028", -2036.412, -1404.792);
            grc.AddNodePtxz("osm4272141027", -2025.481, -1401.383);
            grc.AddNodePtxz("osm3682699443", -1462.803, -1192.522);
            grc.AddNodePtxz("osm4045186110", -1517.262, -1210.493);
            grc.AddNodePtxz("osm4272140999", -1052.706, -1050.013);
            grc.AddNodePtxz("osm6372504741", -1077.626, -1059.408);
            grc.AddNodePtxz("osm53079445", -1080.751, -1060.588);
            grc.AddNodePtxz("osm4272140995", -1124.239, -1091.596);
            grc.AddNodePtxz("osm4272141001", -1075.751, -1073.658);
            grc.AddNodePtxz("osm4272141000", -1050.277, -1064.058);
            grc.AddNodePtxz("osm4272141012", -1432.559, -1197.655);
            grc.AddNodePtxz("osm4272141011", -1416.859, -1192.676);
            grc.AddNodePtxz("osm4272140997", -1407.380, -1189.534);
            grc.AddNodePtxz("osm4272141008", -1396.240, -1185.847);
            grc.AddNodePtxz("osm4272141006", -1290.066, -1153.483);
            grc.AddNodePtxz("osm4272141005", -1253.765, -1140.010);
            grc.AddNodePtxz("osm4272141013", -1462.255, -1125.692);
            grc.AddNodePtxz("osm53237529", -1480.318, -1015.654);
            grc.AddNodePtxz("osm4272141010", -1487.628, -971.136);
            grc.AddNodePtxz("osm3682699442", -1452.939, -1182.143);
            grc.AddNodePtxz("osm4272143191", 898.195, -379.520);
            grc.AddNodePtxz("osm6219028621", 819.792, -397.433);
            grc.AddNodePtxz("osm3810659587", 747.326, 320.559);
            grc.AddNodePtxz("osm4272154843", 559.404, 419.317);
            grc.AddNodePtxz("osm6196828180", 612.417, 390.255);
            grc.AddNodePtxz("osm4045186096", 803.054, 265.176);
            grc.AddNodePtxz("osm674168910", 852.319, 133.398);
            grc.AddNodePtxz("osm4272164137", 871.580, 81.888);
            grc.AddNodePtxz("osm6248078753", 653.611, 733.363);
            grc.AddNodePtxz("osm4584498744", 650.200, 744.021);
            grc.AddNodePtxz("osm4272164126", 639.421, 778.528);
            grc.AddNodePtxz("osm3810659582", 884.757, 67.539);
            grc.AddNodePtxz("osm4293776045", 829.676, 216.726);
            grc.AddNodePtxz("osm4272164132", 824.360, 231.129);
            grc.AddNodePtxz("osm4584498742", 636.194, 788.862);
            grc.AddNodePtxz("osm4272164124", 607.426, 883.488);
            grc.AddNodePtxz("osm4272164128", 669.977, 681.797);
            grc.AddNodePtxz("osm6199263525", 922.360, -56.762);
            grc.AddNodePtxz("osm3810659611", 803.275, 287.701);
            grc.AddNodePtxz("osm6193024941", 759.909, 410.472);
            grc.AddNodePtxz("osm6199821194", 757.186, 418.935);
            grc.AddNodePtxz("osm4272164134", 989.160, -238.462);
            grc.AddNodePtxz("osm3810659604", 726.527, 499.186);
            grc.AddNodePtxz("osm3810659581", 732.446, 494.154);
            grc.AddNodePtxz("osm3810659589", 877.878, 64.281);
            grc.AddNodePtxz("osm4272164130", 1046.921, -400.863);
            grc.AddNodePtxz("osm3218977986", 1061.996, -445.591);
            grc.AddNodePtxz("osm3218977979", 1069.738, -455.076);
            grc.AddNodePtxz("osm6193462228", 783.781, 318.266);
            grc.AddNodePtxz("osm6219028624", 1054.485, -398.147);
            grc.AddNodePtxz("osm6219028625", 1048.856, -380.595);
            grc.AddNodePtxz("osm346516420", 1046.246, -372.355);
            grc.AddNodePtxz("osm6217633460", 1037.323, -344.549);
            grc.AddNodePtxz("osm3810659603", 942.054, -87.662);
            grc.AddNodePtxz("osm6199263526", 940.732, -84.130);
            grc.AddNodePtxz("osm3810659605", 934.901, -91.346);
            grc.AddNodePtxz("osm4584498716", 724.215, 506.546);
            grc.AddNodePtxz("osm6193202162", 716.939, 529.561);
            grc.AddNodePtxz("osm281302447", -1154.888, 1200.670);
            grc.AddNodePtxz("osm740159709", -1169.149, 1198.449);
            grc.AddNodePtxz("osm4272180371", -1178.434, 1196.031);
            grc.AddNodePtxz("osm740159753", -1182.293, 1195.027);
            grc.AddNodePtxz("osm740159578", -1195.935, 1190.167);
            grc.AddNodePtxz("osm4272180375", -1234.694, 1208.060);
            grc.AddNodePtxz("osm4272180376", -1251.710, 1255.562);
            grc.AddNodePtxz("osm4272180372", -990.740, 526.216);
            grc.AddNodePtxz("osm53247738", -1016.077, 597.825);
            grc.AddNodePtxz("osm4272236135", -866.274, 171.531);
            grc.AddNodePtxz("osm6073204938", -869.417, 179.477);
            grc.AddNodePtxz("osm752197889", -22.528, 761.061);
            grc.AddNodePtxz("osm6219028623", 591.529, -473.082);
            grc.AddNodePtxz("osm4272203618", -372.809, -809.737);
            grc.AddNodePtxz("osm4272203619", -381.768, -800.178);
            grc.AddNodePtxz("osm4272203601", 307.212, -569.347);
            grc.AddNodePtxz("osm4272203607", 98.808, -636.471);
            grc.AddNodePtxz("osm4272203608", 22.447, -663.833);
            grc.AddNodePtxz("osm4272203615", -276.788, -765.220);
            grc.AddNodePtxz("osm4272203604", 242.978, -602.118);
            grc.AddNodePtxz("osm4272203598", 347.572, -555.237);
            grc.AddNodePtxz("osm5362545372", 325.548, -562.936);
            grc.AddNodePtxz("osm4608804237", 295.544, -584.637);
            grc.AddNodePtxz("osm4272203600", 330.340, -573.565);
            grc.AddNodePtxz("osm4272203599", 349.394, -566.511);
            grc.AddNodePtxz("osm4608804222", -303.808, -787.153);
            grc.AddNodePtxz("osm4608804219", -143.668, -731.585);
            grc.AddNodePtxz("osm4272203613", -125.600, -725.217);
            grc.AddNodePtxz("osm4608804253", 184.087, -609.613);
            grc.AddNodePtxz("osm4272203610", -23.213, -690.467);
            grc.AddNodePtxz("osm4272203621", -436.863, -831.325);
            grc.AddNodePtxz("osm4608804261", 433.190, -531.463);
            grc.AddNodePtxz("osm4272205044", 404.158, -541.379);
            grc.AddNodePtxz("osm6323443783", 377.297, -550.757);
            grc.AddNodePtxz("osm4272218349", -946.008, -1011.513);
            grc.AddNodePtxz("osm4272218350", -962.506, -1018.017);
            grc.AddNodePtxz("osm4608804229", -719.790, -929.435);
            grc.AddNodePtxz("osm3819829438", -753.315, -942.179);
            grc.AddNodePtxz("osm2699075015", -507.245, -845.708);
            grc.AddNodePtxz("osm4272218345", -679.768, -908.850);
            grc.AddNodePtxz("osm4272218344", -674.140, -918.900);
            grc.AddNodePtxz("osm4272218346", -796.677, -953.919);
            grc.AddNodePtxz("osm4272218351", -959.004, -1028.296);
            grc.AddNodePtxz("osm4272218347", -793.365, -963.859);
            grc.AddNodePtxz("osm4856116759", -641.281, -447.762);
            grc.AddNodePtxz("osm4606062790", -656.742, -402.841);
            grc.AddNodePtxz("osm4272219829", -549.871, -693.992);
            grc.AddNodePtxz("osm4488084045", -541.014, -717.948);
            grc.AddNodePtxz("osm4272219828", -512.471, -798.892);
            grc.AddNodePtxz("osm4278458231", -527.234, -756.465);
            grc.AddNodePtxz("osm4856116761", -568.764, -642.991);
            grc.AddNodePtxz("osm4272219830", -609.741, -532.876);
            grc.AddNodePtxz("osm4045186149", -624.882, -492.195);
            grc.AddNodePtxz("osm4488084043", -626.373, -488.182);
            grc.AddNodePtxz("osm4856116757", -632.828, -471.103);
            grc.AddNodePtxz("osm3679402922", -491.987, -856.913);
            grc.AddNodePtxz("osm321709000", -720.705, -226.705);
            grc.AddNodePtxz("osm4272236137", -914.901, 308.582);
            grc.AddNodePtxz("osm4272236134", -798.063, -13.147);
            grc.AddNodePtxz("osm4987343128", -941.780, 385.358);
            grc.AddNodePtxz("osm4987343129", -952.638, 416.661);
            grc.AddNodePtxz("osm4272236136", -961.315, 441.851);
            grc.AddNodePtxz("osm4272236133", -786.761, -43.530);
            grc.AddNodePtxz("osm6116835246", -841.761, 105.090);
            grc.AddNodePtxz("osm2192655195", -768.552, -93.791);
            grc.AddNodePtxz("osm6122409041", -2240.875, 221.456);
            grc.AddNodePtxz("osm6122409050", -2242.913, 222.993);
            grc.AddNodePtxz("osm740155416", -2292.054, 246.267);
            grc.AddNodePtxz("osm4272285442", -2316.775, 203.133);
            grc.AddNodePtxz("osm4272285440", -2260.279, 296.126);
            grc.AddNodePtxz("osm4272285450", -2384.565, 85.819);
            grc.AddNodePtxz("osm4272285439", -1946.627, 685.701);
            grc.AddNodePtxz("osm4272285449", -2372.065, 108.183);
            grc.AddNodePtxz("osm53252645", -1799.400, 768.985);
            grc.AddNodePtxz("osm690687741", -1698.353, 821.567);
            grc.AddNodePtxz("osm4272285437", -1722.993, 807.405);
            grc.AddNodePtxz("osm690687880", -1952.499, 681.726);
            grc.AddNodePtxz("osm2493194111", -1973.806, 665.061);
            grc.AddNodePtxz("osm6060263317", -1978.013, 661.387);
            grc.AddNodePtxz("osm4272285444", -2336.616, 178.628);
            grc.AddNodePtxz("osm4272285446", -2343.762, 167.999);
            grc.AddNodePtxz("osm4853787417", -2346.694, 163.177);
            grc.AddNodePtxz("osm53252649", -2246.987, 317.074);
            grc.AddNodePtxz("osm4853787416", -2339.318, 157.591);
            grc.AddNodePtxz("osm4272285445", -2334.711, 166.210);
            grc.AddNodePtxz("osm4272285443", -2330.409, 174.590);
            grc.AddNodePtxz("osm4272285436", -1670.341, 895.050);
            grc.AddNodePtxz("osm2493196268", -1673.298, 887.645);
            grc.AddNodePtxz("osm690687878", -1680.553, 873.327);
            grc.AddNodePtxz("osm6193024939", 681.766, 398.035);
            grc.AddNodePtxz("osm6196828177", 650.103, 386.474);
            grc.AddNodePtxz("osm6196828179", 614.455, 374.199);
            grc.AddNodePtxz("osm752210661", 566.468, 358.159);
            grc.AddNodePtxz("osm6196828176", 506.300, 337.664);
            grc.AddNodePtxz("osm6198892491", 125.453, 208.416);
            grc.AddNodePtxz("osm4275697396", 418.807, 308.274);
            grc.AddNodePtxz("osm4275697395", 424.285, 304.699);
            grc.AddNodePtxz("osm4275697392", 471.629, 321.667);
            grc.AddNodePtxz("osm4275697391", 475.828, 327.652);
            grc.AddNodePtxz("osm4275697393", 466.466, 329.485);
            grc.AddNodePtxz("osm4275697394", 422.250, 313.658);
            grc.AddNodePtxz("osm4275697405", 140.860, 213.389);
            grc.AddNodePtxz("osm4275697403", 147.650, 210.850);
            grc.AddNodePtxz("osm6198892492", 195.910, 227.625);
            grc.AddNodePtxz("osm4275697398", 295.596, 262.069);
            grc.AddNodePtxz("osm6198892495", 325.192, 282.713);
            grc.AddNodePtxz("osm4275697399", 290.630, 270.841);
            grc.AddNodePtxz("osm6198892493", 227.249, 248.580);
            grc.AddNodePtxz("osm53191546", 189.850, 235.983);
            grc.AddNodePtxz("osm4275697404", 143.970, 219.619);
            grc.AddNodePtxz("osm4294894961", -167.176, -220.888);
            grc.AddNodePtxz("osm705015506", 510.735, 1187.043);
            grc.AddNodePtxz("osm2502193869", -2148.711, -587.066);
            grc.AddNodePtxz("osm4728687020", -1954.095, -518.136);
            grc.AddNodePtxz("osm6577707100", -1678.424, -420.395);
            grc.AddNodePtxz("osm3222406608", -1641.763, -406.973);
            grc.AddNodePtxz("osm3682699016", -1639.145, -405.894);
            grc.AddNodePtxz("osm53110393", -2297.299, -644.358);
            grc.AddNodePtxz("osm4761352780", -2255.276, -629.473);
            grc.AddNodePtxz("osm4272285448", -2371.196, 122.913);
            grc.AddNodePtxz("osm4272285447", -2361.535, 116.026);
            grc.AddNodePtxz("osm5879789088", -554.209, -21.070);
            grc.AddNodePtxz("osm53191549", -429.881, 21.113);
            grc.AddNodePtxz("osm5916951297", -406.184, 29.154);
            grc.AddNodePtxz("osm4488084040", -626.050, -45.443);
            grc.AddNodePtxz("osm4488084047", -674.119, -61.756);
            grc.AddNodePtxz("osm5131013167", -564.824, -24.672);
            grc.AddNodePtxz("osm1082877458", 138.252, -32.487);
            grc.AddNodePtxz("osm4488084015", 134.845, -29.502);
            grc.AddNodePtxz("osm2563978821", 130.730, -27.624);
            grc.AddNodePtxz("osm4488084016", 126.242, -27.006);
            grc.AddNodePtxz("osm1082877376", 121.784, -27.716);
            grc.AddNodePtxz("osm1082877438", 141.895, -43.098);
            grc.AddNodePtxz("osm4488084014", 141.649, -39.641);
            grc.AddNodePtxz("osm1082877401", 127.342, -57.665);
            grc.AddNodePtxz("osm4488084021", 131.111, -57.008);
            grc.AddNodePtxz("osm1082881765", 134.596, -55.443);
            grc.AddNodePtxz("osm4488084020", 137.584, -53.066);
            grc.AddNodePtxz("osm1082877371", 139.880, -50.030);
            grc.AddNodePtxz("osm4488084019", 120.024, -56.241);
            grc.AddNodePtxz("osm53247741", -1383.953, 1628.370);
            grc.AddNodePtxz("osm796660935", -1391.582, 1624.530);
            grc.AddNodePtxz("osm53076884", -1463.455, 1589.255);
            grc.AddNodePtxz("osm1066589803", -1499.070, 1570.939);
            grc.AddNodePtxz("osm53252639", -1533.416, 1550.586);
            grc.AddNodePtxz("osm1066589810", -1552.710, 1537.224);
            grc.AddNodePtxz("osm796651321", -1569.832, 1522.451);
            grc.AddNodePtxz("osm1066589821", -1583.458, 1508.906);
            grc.AddNodePtxz("osm690687875", -1595.112, 1495.023);
            grc.AddNodePtxz("osm1066589824", -1607.860, 1478.238);
            grc.AddNodePtxz("osm1066589826", -1617.757, 1462.104);
            grc.AddNodePtxz("osm2371263479", -1622.102, 1454.755);
            grc.AddNodePtxz("osm1066589827", -1626.592, 1447.182);
            grc.AddNodePtxz("osm53252640", -1633.635, 1432.025);
            grc.AddNodePtxz("osm1066589834", -1641.217, 1414.134);
            grc.AddNodePtxz("osm1066589841", -1647.618, 1394.729);
            grc.AddNodePtxz("osm1066589846", -1652.171, 1375.537);
            grc.AddNodePtxz("osm690687876", -1656.403, 1355.061);
            grc.AddNodePtxz("osm1066589848", -1659.051, 1321.400);
            grc.AddNodePtxz("osm53182769", -1658.649, 1292.562);
            grc.AddNodePtxz("osm743394911", -1658.220, 1245.062);
            grc.AddNodePtxz("osm743394823", -1657.064, 1188.970);
            grc.AddNodePtxz("osm53069769", -1656.935, 1182.353);
            grc.AddNodePtxz("osm53252642", -1656.477, 992.136);
            grc.AddNodePtxz("osm796660828", -1657.973, 929.417);
            grc.AddNodePtxz("osm690687877", -1663.202, 912.925);
            grc.AddNodePtxz("osm2192655196", -594.398, -34.725);
            grc.AddNodePtxz("osm53091624", 250.951, -111.838);
            grc.AddNodePtxz("osm53091627", 221.882, -99.602);
            grc.AddNodePtxz("osm53091628", 200.106, -91.507);
            grc.AddNodePtxz("osm6053893671", 806.188, 441.327);
            grc.AddNodePtxz("osm752197921", 784.316, 433.364);
            grc.AddNodePtxz("osm6193024940", 763.864, 426.093);
            grc.AddNodePtxz("osm6199821196", 760.613, 424.869);
            grc.AddNodePtxz("osm3543342002", -997.180, -175.356);
            grc.AddNodePtxz("osm6193024935", 687.187, 394.353);
            grc.AddNodePtxz("osm6193024936", 690.763, 395.562);
            grc.AddNodePtxz("osm6193024937", 727.819, 408.865);
            grc.AddNodePtxz("osm6193024938", 732.683, 410.737);
            grc.AddNodePtxz("osm6193024931", 739.560, 412.956);
            grc.AddNodePtxz("osm6193024933", 742.716, 414.116);
            grc.AddNodePtxz("osm6248078761", 702.522, 577.453);
            grc.AddNodePtxz("osm6248078754", 679.473, 651.453);
            grc.AddNodePtxz("osm6196828184", 581.541, 417.351);
            grc.AddNodePtxz("osm6196828182", 547.340, 437.621);
            grc.AddNodePtxz("osm6198892494", 328.769, 273.196);
            grc.AddNodePtxz("osm6198892496", 405.210, 303.825);
            grc.AddNodePtxz("osm2563978877", 119.932, 23.907);
            grc.AddNodePtxz("osm6198997573", 102.946, 70.516);
            grc.AddNodePtxz("osm6198997575", 94.242, 94.674);
            grc.AddNodePtxz("osm6199662233", 675.791, -25.680);
            grc.AddNodePtxz("osm4488084035", 661.029, -30.742);
            grc.AddNodePtxz("osm752210682", 593.054, -54.266);
            grc.AddNodePtxz("osm6199662239", 569.453, -62.615);
            grc.AddNodePtxz("osm53091609", 533.291, -75.106);
            grc.AddNodePtxz("osm5429903916", 516.544, -81.037);
            grc.AddNodePtxz("osm6217212445", 979.587, -188.468);
            grc.AddNodePtxz("osm6217212446", 1011.260, -272.887);
            grc.AddNodePtxz("osm4272164125", 1060.803, -418.060);
            grc.AddNodePtxz("osm747467327", 704.455, 410.998);
            grc.AddNodePtxz("osm752210738", 685.379, 404.444);
            grc.AddNodePtxz("osm752198068", 859.822, 299.590);
            grc.AddNodePtxz("osm752197930", 848.575, 298.662);
            grc.AddNodePtxz("osm6196861275", 842.134, 298.358);
            grc.AddNodePtxz("osm6319309348", 841.158, 298.349);
            grc.AddNodePtxz("osm2500972696", 835.373, 298.294);
            grc.AddNodePtxz("osm6193462232", 808.091, 299.893);
            grc.AddNodePtxz("osm6217633461", 1017.782, -338.786);
            grc.AddLinkByNodeName("osm1052709790", "osm4272141009", usetype: LinkUse.road, comment: "Northeast 51st Street.link1");
            grc.AddLinkByNodeName("osm53052387", "osm1052709790", usetype: LinkUse.road, comment: "Northeast 51st Street.link2");
            grc.AddLinkByNodeName("osm796674146", "osm53135596", usetype: LinkUse.road, comment: "Bel-Red Road.link1");
            grc.AddLinkByNodeName("osm53084592", "osm796674146", usetype: LinkUse.road, comment: "Bel-Red Road.link2");
            grc.AddLinkByNodeName("osm53091684", "osm53084592", usetype: LinkUse.road, comment: "Bel-Red Road.link3");
            grc.AddLinkByNodeName("osm53174314", "osm53091684", usetype: LinkUse.road, comment: "Bel-Red Road.link4");
            grc.AddLinkByNodeName("osm796660850", "osm53174314", usetype: LinkUse.road, comment: "Bel-Red Road.link5");
            grc.AddLinkByNodeName("osm53252643", "osm796660850", usetype: LinkUse.road, comment: "Bel-Red Road.link6");
            grc.AddLinkByNodeName("osm3801669662", "osm53048846", usetype: LinkUse.road, comment: "148th Avenue Northeast.link1");
            grc.AddLinkByNodeName("osm2501227138", "osm4272180373", usetype: LinkUse.road, comment: "Northeast 40th Street.link1");
            grc.AddLinkByNodeName("osm6127378392", "osm2501227138", usetype: LinkUse.road, comment: "Northeast 40th Street.link2");
            grc.AddLinkByNodeName("osm53217134", "osm6127378392", usetype: LinkUse.road, comment: "Northeast 40th Street.link3");
            grc.AddLinkByNodeName("osm2408047912", "osm53217134", usetype: LinkUse.road, comment: "Northeast 40th Street.link4");
            grc.AddLinkByNodeName("osm2501224454", "osm2408047912", usetype: LinkUse.road, comment: "Northeast 40th Street.link5");
            grc.AddLinkByNodeName("osm1632149759", "osm2501224454", usetype: LinkUse.road, comment: "Northeast 40th Street.link6");
            grc.AddLinkByNodeName("osm53141528", "osm1632149759", usetype: LinkUse.road, comment: "Northeast 40th Street.link7");
            grc.AddLinkByNodeName("osm53191528", "osm53141528", usetype: LinkUse.road, comment: "Northeast 40th Street.link8");
            grc.AddLinkByNodeName("osm4272180374", "osm53191528", usetype: LinkUse.road, comment: "Northeast 40th Street.link9");
            grc.AddLinkByNodeName("osm3682698107", "osm53100935", usetype: LinkUse.road, comment: "154th Place Northeast.link1");
            grc.AddLinkByNodeName("osm6097094640", "osm3682698107", usetype: LinkUse.road, comment: "154th Place Northeast.link2");
            grc.AddLinkByNodeName("osm3735501408", "osm6097094640", usetype: LinkUse.road, comment: "154th Place Northeast.link3");
            grc.AddLinkByNodeName("osm332178519", "osm3735501408", usetype: LinkUse.road, comment: "154th Place Northeast.link4");
            grc.AddLinkByNodeName("osm332178520", "osm332178519", usetype: LinkUse.road, comment: "154th Place Northeast.link5");
            grc.AddLinkByNodeName("osm2493133614", "osm332178520", usetype: LinkUse.road, comment: "154th Place Northeast.link6");
            grc.AddLinkByNodeName("osm332178521", "osm2493133614", usetype: LinkUse.road, comment: "154th Place Northeast.link7");
            grc.AddLinkByNodeName("osm2493133611", "osm332178521", usetype: LinkUse.road, comment: "154th Place Northeast.link8");
            grc.AddLinkByNodeName("osm5916810770", "osm2493133611", usetype: LinkUse.road, comment: "154th Place Northeast.link9");
            grc.AddLinkByNodeName("osm5916810769", "osm5916810770", usetype: LinkUse.road, comment: "154th Place Northeast.link10");
            grc.AddLinkByNodeName("osm332178893", "osm5916810769", usetype: LinkUse.road, comment: "154th Place Northeast.link11");
            grc.AddLinkByNodeName("osm332178895", "osm332178893", usetype: LinkUse.road, comment: "154th Place Northeast.link12");
            grc.AddLinkByNodeName("osm5916810768", "osm332178895", usetype: LinkUse.road, comment: "154th Place Northeast.link13");
            grc.AddLinkByNodeName("osm2493133616", "osm5916810768", usetype: LinkUse.road, comment: "154th Place Northeast.link14");
            grc.AddLinkByNodeName("osm5916810767", "osm2493133616", usetype: LinkUse.road, comment: "154th Place Northeast.link15");
            grc.AddLinkByNodeName("osm332178897", "osm5916810767", usetype: LinkUse.road, comment: "154th Place Northeast.link16");
            grc.AddLinkByNodeName("osm5916810766", "osm332178897", usetype: LinkUse.road, comment: "154th Place Northeast.link17");
            grc.AddLinkByNodeName("osm332178899", "osm5916810766", usetype: LinkUse.road, comment: "154th Place Northeast.link18");
            grc.AddLinkByNodeName("osm6074673255", "osm332178899", usetype: LinkUse.road, comment: "154th Place Northeast.link19");
            grc.AddLinkByNodeName("osm332178901", "osm6074673255", usetype: LinkUse.road, comment: "154th Place Northeast.link20");
            grc.AddLinkByNodeName("osm2493133618", "osm332178901", usetype: LinkUse.road, comment: "154th Place Northeast.link21");
            grc.AddLinkByNodeName("osm332178903", "osm2493133618", usetype: LinkUse.road, comment: "154th Place Northeast.link22");
            grc.AddLinkByNodeName("osm332178905", "osm332178903", usetype: LinkUse.road, comment: "154th Place Northeast.link23");
            grc.AddLinkByNodeName("osm332178907", "osm332178905", usetype: LinkUse.road, comment: "154th Place Northeast.link24");
            grc.AddLinkByNodeName("osm5916652901", "osm332178907", usetype: LinkUse.road, comment: "154th Place Northeast.link25");
            grc.AddLinkByNodeName("osm332178909", "osm5916652901", usetype: LinkUse.road, comment: "154th Place Northeast.link26");
            grc.AddLinkByNodeName("osm2493133609", "osm332178909", usetype: LinkUse.road, comment: "154th Place Northeast.link27");
            grc.AddLinkByNodeName("osm332178911", "osm2493133609", usetype: LinkUse.road, comment: "154th Place Northeast.link28");
            grc.AddLinkByNodeName("osm332178913", "osm332178911", usetype: LinkUse.road, comment: "154th Place Northeast.link29");
            grc.AddLinkByNodeName("osm1100843196", "osm332178913", usetype: LinkUse.road, comment: "154th Place Northeast.link30");
            grc.AddLinkByNodeName("osm332178915", "osm1100843196", usetype: LinkUse.road, comment: "154th Place Northeast.link31");
            grc.AddLinkByNodeName("osm332178917", "osm332178915", usetype: LinkUse.road, comment: "154th Place Northeast.link32");
            grc.AddLinkByNodeName("osm2493133619", "osm332178917", usetype: LinkUse.road, comment: "154th Place Northeast.link33");
            grc.AddLinkByNodeName("osm332178919", "osm2493133619", usetype: LinkUse.road, comment: "154th Place Northeast.link34");
            grc.AddLinkByNodeName("osm5916652958", "osm332178919", usetype: LinkUse.road, comment: "154th Place Northeast.link35");
            grc.AddLinkByNodeName("osm332178921", "osm5916652958", usetype: LinkUse.road, comment: "154th Place Northeast.link36");
            grc.AddLinkByNodeName("osm6047169084", "osm332178921", usetype: LinkUse.road, comment: "154th Place Northeast.link37");
            grc.AddLinkByNodeName("osm332178923", "osm6047169084", usetype: LinkUse.road, comment: "154th Place Northeast.link38");
            grc.AddLinkByNodeName("osm5916652961", "osm332178923", usetype: LinkUse.road, comment: "154th Place Northeast.link39");
            grc.AddLinkByNodeName("osm2493133606", "osm5916652961", usetype: LinkUse.road, comment: "154th Place Northeast.link40");
            grc.AddLinkByNodeName("osm6047169085", "osm2493133606", usetype: LinkUse.road, comment: "154th Place Northeast.link41");
            grc.AddLinkByNodeName("osm332178925", "osm6047169085", usetype: LinkUse.road, comment: "154th Place Northeast.link42");
            grc.AddLinkByNodeName("osm6047169086", "osm332178925", usetype: LinkUse.road, comment: "154th Place Northeast.link43");
            grc.AddLinkByNodeName("osm332178927", "osm6047169086", usetype: LinkUse.road, comment: "154th Place Northeast.link44");
            grc.AddLinkByNodeName("osm6047169087", "osm332178927", usetype: LinkUse.road, comment: "154th Place Northeast.link45");
            grc.AddLinkByNodeName("osm5916720781", "osm6047169087", usetype: LinkUse.road, comment: "154th Place Northeast.link46");
            grc.AddLinkByNodeName("osm332178929", "osm5916720781", usetype: LinkUse.road, comment: "154th Place Northeast.link47");
            grc.AddLinkByNodeName("osm6047169088", "osm332178929", usetype: LinkUse.road, comment: "154th Place Northeast.link48");
            grc.AddLinkByNodeName("osm6047169089", "osm6047169088", usetype: LinkUse.road, comment: "154th Place Northeast.link49");
            grc.AddLinkByNodeName("osm332178931", "osm6047169089", usetype: LinkUse.road, comment: "154th Place Northeast.link50");
            grc.AddLinkByNodeName("osm6047169091", "osm332178931", usetype: LinkUse.road, comment: "154th Place Northeast.link51");
            grc.AddLinkByNodeName("osm332178933", "osm6047169091", usetype: LinkUse.road, comment: "154th Place Northeast.link52");
            grc.AddLinkByNodeName("osm332178935", "osm332178933", usetype: LinkUse.road, comment: "154th Place Northeast.link53");
            grc.AddLinkByNodeName("osm332178937", "osm332178935", usetype: LinkUse.road, comment: "154th Place Northeast.link54");
            grc.AddLinkByNodeName("osm332178939", "osm332178937", usetype: LinkUse.road, comment: "154th Place Northeast.link55");
            grc.AddLinkByNodeName("osm332178941", "osm332178939", usetype: LinkUse.road, comment: "154th Place Northeast.link56");
            grc.AddLinkByNodeName("osm2493133621", "osm332178941", usetype: LinkUse.road, comment: "154th Place Northeast.link57");
            grc.AddLinkByNodeName("osm332178943", "osm2493133621", usetype: LinkUse.road, comment: "154th Place Northeast.link58");
            grc.AddLinkByNodeName("osm332178945", "osm332178943", usetype: LinkUse.road, comment: "154th Place Northeast.link59");
            grc.AddLinkByNodeName("osm6097094800", "osm332178945", usetype: LinkUse.road, comment: "154th Place Northeast.link60");
            grc.AddLinkByNodeName("osm332178947", "osm6097094800", usetype: LinkUse.road, comment: "154th Place Northeast.link61");
            grc.AddLinkByNodeName("osm4274320609", "osm332178947", usetype: LinkUse.road, comment: "154th Place Northeast.link62");
            grc.AddLinkByNodeName("osm332178949", "osm4274320609", usetype: LinkUse.road, comment: "154th Place Northeast.link63");
            grc.AddLinkByNodeName("osm766934115", "osm4272219831", usetype: LinkUse.road, comment: "Northeast 40th Street001.link1");
            grc.AddLinkByNodeName("osm53101051", "osm766934115", usetype: LinkUse.road, comment: "Northeast 40th Street001.link2");
            grc.AddLinkByNodeName("osm321709193", "osm53101051", usetype: LinkUse.road, comment: "Northeast 40th Street001.link3");
            grc.AddLinkByNodeName("osm53052405", "osm53206031", usetype: LinkUse.road, comment: "Northeast 51st Street001.link1");
            grc.AddLinkByNodeName("osm4272141007", "osm602854096", usetype: LinkUse.road, comment: "Northeast 51st Street002.link1");
            grc.AddLinkByNodeName("osm752210733", "osm752210775", usetype: LinkUse.road, comment: "secondary_link001.link1");
            grc.AddLinkByNodeName("osm752210691", "osm752210733", usetype: LinkUse.road, comment: "secondary_link001.link2");
            grc.AddLinkByNodeName("osm6199263535", "osm752210691", usetype: LinkUse.road, comment: "secondary_link001.link3");
            grc.AddLinkByNodeName("osm752210663", "osm6199263535", usetype: LinkUse.road, comment: "secondary_link001.link4");
            grc.AddLinkByNodeName("osm3940750553", "osm1036690323", usetype: LinkUse.road, comment: "unclassified001.link1");
            grc.AddLinkByNodeName("osm2298864452", "osm3940750553", usetype: LinkUse.road, comment: "unclassified001.link2");
            grc.AddLinkByNodeName("osm2298864462", "osm2298864452", usetype: LinkUse.road, comment: "unclassified001.link3");
            grc.AddLinkByNodeName("osm809706774", "osm2298864462", usetype: LinkUse.road, comment: "unclassified001.link4");
            grc.AddLinkByNodeName("osm1117301838", "osm1082877364", usetype: LinkUse.road, comment: "Northeast 36th Street003.link1");
            grc.AddLinkByNodeName("osm1082877387", "osm1117301838", usetype: LinkUse.road, comment: "Northeast 36th Street003.link2");
            grc.AddLinkByNodeName("osm1082877367", "osm1082881764", usetype: LinkUse.road, comment: "tertiary001.link1");
            grc.AddLinkByNodeName("osm4488084017", "osm1082877367", usetype: LinkUse.road, comment: "tertiary001.link2");
            grc.AddLinkByNodeName("osm2563978829", "osm4488084017", usetype: LinkUse.road, comment: "tertiary001.link3");
            grc.AddLinkByNodeName("osm4488084018", "osm2563978829", usetype: LinkUse.road, comment: "tertiary001.link4");
            grc.AddLinkByNodeName("osm1488907729", "osm4488084018", usetype: LinkUse.road, comment: "tertiary001.link5");
            grc.AddLinkByNodeName("osm1082877399", "osm1488907729", usetype: LinkUse.road, comment: "tertiary001.link6");
            grc.AddLinkByNodeName("osm1105703434", "osm346078654", usetype: LinkUse.road, comment: "Northeast 40th Street002.link1");
            grc.AddLinkByNodeName("osm1835913814", "osm1082877435", usetype: LinkUse.road, comment: "Northeast 36th Street004.link1");
            grc.AddLinkByNodeName("osm3801669633", "osm3801669662", usetype: LinkUse.road, comment: "148th Avenue Northeast001.link1");
            grc.AddLinkByNodeName("osm6219028620", "osm3801669633", usetype: LinkUse.road, comment: "148th Avenue Northeast001.link2");
            grc.AddLinkByNodeName("osm739212836", "osm6219028620", usetype: LinkUse.road, comment: "148th Avenue Northeast001.link3");
            grc.AddLinkByNodeName("osm3801669779", "osm739212836", usetype: LinkUse.road, comment: "148th Avenue Northeast001.link4");
            grc.AddLinkByNodeName("osm5147868528", "osm6199662240", usetype: LinkUse.road, comment: "152nd Avenue Northeast001.link1");
            grc.AddLinkByNodeName("osm352544253", "osm5147868528", usetype: LinkUse.road, comment: "152nd Avenue Northeast001.link2");
            grc.AddLinkByNodeName("osm5429902641", "osm352544253", usetype: LinkUse.road, comment: "152nd Avenue Northeast001.link3");
            grc.AddLinkByNodeName("osm6323984645", "osm5429902641", usetype: LinkUse.road, comment: "152nd Avenue Northeast001.link4");
            grc.AddLinkByNodeName("osm2672560741", "osm6323984645", usetype: LinkUse.road, comment: "152nd Avenue Northeast001.link5");
            grc.AddLinkByNodeName("osm2500980951", "osm2672560741", usetype: LinkUse.road, comment: "152nd Avenue Northeast001.link6");
            grc.AddLinkByNodeName("osm1082877423", "osm2500980951", usetype: LinkUse.road, comment: "152nd Avenue Northeast001.link7");
            grc.AddLinkByNodeName("osm1488907744", "osm1082877423", usetype: LinkUse.road, comment: "152nd Avenue Northeast001.link8");
            grc.AddLinkByNodeName("osm53091621", "osm1488907744", usetype: LinkUse.road, comment: "152nd Avenue Northeast001.link9");
            grc.AddLinkByNodeName("osm53091623", "osm53091621", usetype: LinkUse.road, comment: "152nd Avenue Northeast001.link10");
            grc.AddLinkByNodeName("osm6046905082", "osm53091623", usetype: LinkUse.road, comment: "152nd Avenue Northeast001.link11");
            grc.AddLinkByNodeName("osm347249273", "osm752210744", usetype: LinkUse.road, comment: "152nd Avenue Northeast002.link1");
            grc.AddLinkByNodeName("osm347249342", "osm347249273", usetype: LinkUse.road, comment: "152nd Avenue Northeast002.link2");
            grc.AddLinkByNodeName("osm6199662234", "osm347249342", usetype: LinkUse.road, comment: "152nd Avenue Northeast002.link3");
            grc.AddLinkByNodeName("osm2563978831", "osm1082877435", usetype: LinkUse.road, comment: "tertiary_link001.link1");
            grc.AddLinkByNodeName("osm2563978833", "osm2563978831", usetype: LinkUse.road, comment: "tertiary_link001.link2");
            grc.AddLinkByNodeName("osm4274827327", "osm2563978833", usetype: LinkUse.road, comment: "tertiary_link001.link3");
            grc.AddLinkByNodeName("osm2563978835", "osm4274827327", usetype: LinkUse.road, comment: "tertiary_link001.link4");
            grc.AddLinkByNodeName("osm2563978837", "osm2563978835", usetype: LinkUse.road, comment: "tertiary_link001.link5");
            grc.AddLinkByNodeName("osm2563978839", "osm2563978837", usetype: LinkUse.road, comment: "tertiary_link001.link6");
            grc.AddLinkByNodeName("osm1082877399", "osm2563978839", usetype: LinkUse.road, comment: "tertiary_link001.link7");
            grc.AddLinkByNodeName("osm2563978841", "osm1082881763", usetype: LinkUse.road, comment: "tertiary_link002.link1");
            grc.AddLinkByNodeName("osm2563978843", "osm2563978841", usetype: LinkUse.road, comment: "tertiary_link002.link2");
            grc.AddLinkByNodeName("osm3934726146", "osm2563978843", usetype: LinkUse.road, comment: "tertiary_link002.link3");
            grc.AddLinkByNodeName("osm2563978845", "osm3934726146", usetype: LinkUse.road, comment: "tertiary_link002.link4");
            grc.AddLinkByNodeName("osm2563978847", "osm2563978845", usetype: LinkUse.road, comment: "tertiary_link002.link5");
            grc.AddLinkByNodeName("osm2563978848", "osm2563978847", usetype: LinkUse.road, comment: "tertiary_link002.link6");
            grc.AddLinkByNodeName("osm2563978850", "osm2563978848", usetype: LinkUse.road, comment: "tertiary_link002.link7");
            grc.AddLinkByNodeName("osm2563978852", "osm2563978850", usetype: LinkUse.road, comment: "tertiary_link002.link8");
            grc.AddLinkByNodeName("osm2563978827", "osm2563978852", usetype: LinkUse.road, comment: "tertiary_link002.link9");
            grc.AddLinkByNodeName("osm2563978855", "osm2563978827", usetype: LinkUse.road, comment: "tertiary_link003.link1");
            grc.AddLinkByNodeName("osm2563978856", "osm2563978855", usetype: LinkUse.road, comment: "tertiary_link003.link2");
            grc.AddLinkByNodeName("osm2563978859", "osm2563978856", usetype: LinkUse.road, comment: "tertiary_link003.link3");
            grc.AddLinkByNodeName("osm2563978861", "osm2563978859", usetype: LinkUse.road, comment: "tertiary_link003.link4");
            grc.AddLinkByNodeName("osm2563978863", "osm2563978861", usetype: LinkUse.road, comment: "tertiary_link003.link5");
            grc.AddLinkByNodeName("osm2563978865", "osm2563978863", usetype: LinkUse.road, comment: "tertiary_link003.link6");
            grc.AddLinkByNodeName("osm2563978867", "osm2563978865", usetype: LinkUse.road, comment: "tertiary_link003.link7");
            grc.AddLinkByNodeName("osm2563978869", "osm2563978867", usetype: LinkUse.road, comment: "tertiary_link003.link8");
            grc.AddLinkByNodeName("osm1082881766", "osm2563978869", usetype: LinkUse.road, comment: "tertiary_link003.link9");
            grc.AddLinkByNodeName("osm2563978870", "osm1082877406", usetype: LinkUse.road, comment: "Northest 31st Street.link1");
            grc.AddLinkByNodeName("osm2563978871", "osm2563978870", usetype: LinkUse.road, comment: "Northest 31st Street.link2");
            grc.AddLinkByNodeName("osm3934726738", "osm2563978871", usetype: LinkUse.road, comment: "Northest 31st Street.link3");
            grc.AddLinkByNodeName("osm2563978872", "osm3934726738", usetype: LinkUse.road, comment: "Northest 31st Street.link4");
            grc.AddLinkByNodeName("osm2563978873", "osm2563978872", usetype: LinkUse.road, comment: "Northest 31st Street.link5");
            grc.AddLinkByNodeName("osm2563978874", "osm2563978873", usetype: LinkUse.road, comment: "Northest 31st Street.link6");
            grc.AddLinkByNodeName("osm2563978903", "osm2563978874", usetype: LinkUse.road, comment: "Northest 31st Street.link7");
            grc.AddLinkByNodeName("osm2563978875", "osm2563978903", usetype: LinkUse.road, comment: "Northest 31st Street.link8");
            grc.AddLinkByNodeName("osm2563978876", "osm2563978875", usetype: LinkUse.road, comment: "Northest 31st Street.link9");
            grc.AddLinkByNodeName("osm6198997576", "osm1082877429", usetype: LinkUse.road, comment: "Northest 31st Street001.link1");
            grc.AddLinkByNodeName("osm6198997574", "osm6198997576", usetype: LinkUse.road, comment: "Northest 31st Street001.link2");
            grc.AddLinkByNodeName("osm409460061", "osm6198997574", usetype: LinkUse.road, comment: "Northest 31st Street001.link3");
            grc.AddLinkByNodeName("osm6198997570", "osm409460061", usetype: LinkUse.road, comment: "Northest 31st Street001.link4");
            grc.AddLinkByNodeName("osm2563978878", "osm6198997570", usetype: LinkUse.road, comment: "Northest 31st Street001.link5");
            grc.AddLinkByNodeName("osm2563978879", "osm2563978878", usetype: LinkUse.road, comment: "Northest 31st Street001.link6");
            grc.AddLinkByNodeName("osm2563978880", "osm2563978879", usetype: LinkUse.road, comment: "Northest 31st Street001.link7");
            grc.AddLinkByNodeName("osm2563978881", "osm2563978880", usetype: LinkUse.road, comment: "Northest 31st Street001.link8");
            grc.AddLinkByNodeName("osm2563978882", "osm2563978881", usetype: LinkUse.road, comment: "Northest 31st Street001.link9");
            grc.AddLinkByNodeName("osm2563978883", "osm2563978882", usetype: LinkUse.road, comment: "Northest 31st Street001.link10");
            grc.AddLinkByNodeName("osm2563978884", "osm2563978883", usetype: LinkUse.road, comment: "Northest 31st Street001.link11");
            grc.AddLinkByNodeName("osm2563978885", "osm2563978884", usetype: LinkUse.road, comment: "Northest 31st Street001.link12");
            grc.AddLinkByNodeName("osm2563978886", "osm2563978885", usetype: LinkUse.road, comment: "Northest 31st Street001.link13");
            grc.AddLinkByNodeName("osm2563978888", "osm2563978886", usetype: LinkUse.road, comment: "Northest 31st Street001.link14");
            grc.AddLinkByNodeName("osm1082877433", "osm2563978888", usetype: LinkUse.road, comment: "Northest 31st Street001.link15");
            grc.AddLinkByNodeName("osm2563978893", "osm1082881764", usetype: LinkUse.road, comment: "tertiary_link004.link1");
            grc.AddLinkByNodeName("osm2563978889", "osm2563978893", usetype: LinkUse.road, comment: "tertiary_link004.link2");
            grc.AddLinkByNodeName("osm4274827329", "osm2563978889", usetype: LinkUse.road, comment: "tertiary_link004.link3");
            grc.AddLinkByNodeName("osm2563978891", "osm4274827329", usetype: LinkUse.road, comment: "tertiary_link004.link4");
            grc.AddLinkByNodeName("osm1082877435", "osm2563978891", usetype: LinkUse.road, comment: "tertiary_link004.link5");
            grc.AddLinkByNodeName("osm1491102454", "osm357040781", usetype: LinkUse.road, comment: "Northeast 36th Street005.link1");
            grc.AddLinkByNodeName("osm321548681", "osm1491102454", usetype: LinkUse.road, comment: "Northeast 36th Street005.link2");
            grc.AddLinkByNodeName("osm3679402919", "osm321548681", usetype: LinkUse.road, comment: "Northeast 36th Street005.link3");
            grc.AddLinkByNodeName("osm321548682", "osm3679402919", usetype: LinkUse.road, comment: "Northeast 36th Street005.link4");
            grc.AddLinkByNodeName("osm2502193874", "osm53191556", usetype: LinkUse.road, comment: "156th Avenue Northeast.link1");
            grc.AddLinkByNodeName("osm2493133613", "osm53100935", usetype: LinkUse.road, comment: "Northeast 51st Street003.link1");
            grc.AddLinkByNodeName("osm3222406596", "osm2493133613", usetype: LinkUse.road, comment: "Northeast 51st Street003.link2");
            grc.AddLinkByNodeName("osm334967225", "osm3222406596", usetype: LinkUse.road, comment: "Northeast 51st Street003.link3");
            grc.AddLinkByNodeName("osm3682699014", "osm334967225", usetype: LinkUse.road, comment: "Northeast 51st Street003.link4");
            grc.AddLinkByNodeName("osm53191551", "osm3682699014", usetype: LinkUse.road, comment: "Northeast 51st Street003.link5");
            grc.AddLinkByNodeName("osm3682699013", "osm53191551", usetype: LinkUse.road, comment: "156th Avenue Northeast001.link1");
            grc.AddLinkByNodeName("osm1100843195", "osm3682699013", usetype: LinkUse.road, comment: "156th Avenue Northeast001.link2");
            grc.AddLinkByNodeName("osm335782985", "osm1100843195", usetype: LinkUse.road, comment: "156th Avenue Northeast001.link3");
            grc.AddLinkByNodeName("osm53191550", "osm335782985", usetype: LinkUse.road, comment: "156th Avenue Northeast001.link4");
            grc.AddLinkByNodeName("osm321550408", "osm53191550", usetype: LinkUse.road, comment: "156th Avenue Northeast001.link5");
            grc.AddLinkByNodeName("osm6577715947", "osm2300480674", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast.link1");
            grc.AddLinkByNodeName("osm53252647", "osm6577715947", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast.link2");
            grc.AddLinkByNodeName("osm53252648", "osm53252647", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast.link3");
            grc.AddLinkByNodeName("osm53252650", "osm53133391", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast001.link1");
            grc.AddLinkByNodeName("osm53252651", "osm53252650", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast001.link2");
            grc.AddLinkByNodeName("osm3163410722", "osm53252651", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast001.link3");
            grc.AddLinkByNodeName("osm740159704", "osm3163410722", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast001.link4");
            grc.AddLinkByNodeName("osm740159647", "osm740159704", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast001.link5");
            grc.AddLinkByNodeName("osm53083965", "osm740159647", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast001.link6");
            grc.AddLinkByNodeName("osm4049735544", "osm321548679", usetype: LinkUse.road, comment: "Northeast 36th Street006.link1");
            grc.AddLinkByNodeName("osm327748939", "osm4049735544", usetype: LinkUse.road, comment: "Northeast 36th Street006.link2");
            grc.AddLinkByNodeName("osm321548680", "osm327748939", usetype: LinkUse.road, comment: "Northeast 36th Street006.link3");
            grc.AddLinkByNodeName("osm3731157589", "osm321548680", usetype: LinkUse.road, comment: "Northeast 36th Street006.link4");
            grc.AddLinkByNodeName("osm357040781", "osm3731157589", usetype: LinkUse.road, comment: "Northeast 36th Street006.link5");
            grc.AddLinkByNodeName("osm53135584", "osm2657798420", usetype: LinkUse.road, comment: "Bel-Red Road001.link1");
            grc.AddLinkByNodeName("osm4272190807", "osm53135584", usetype: LinkUse.road, comment: "Bel-Red Road001.link2");
            grc.AddLinkByNodeName("osm1063428302", "osm2657798417", usetype: LinkUse.road, comment: "Bel-Red Road002.link1");
            grc.AddLinkByNodeName("osm53081337", "osm1063428302", usetype: LinkUse.road, comment: "Bel-Red Road002.link2");
            grc.AddLinkByNodeName("osm740159575", "osm53081337", usetype: LinkUse.road, comment: "Bel-Red Road002.link3");
            grc.AddLinkByNodeName("osm740159694", "osm740159575", usetype: LinkUse.road, comment: "Bel-Red Road002.link4");
            grc.AddLinkByNodeName("osm281302479", "osm740159694", usetype: LinkUse.road, comment: "Bel-Red Road002.link5");
            grc.AddLinkByNodeName("osm2501221678", "osm281302479", usetype: LinkUse.road, comment: "Bel-Red Road002.link6");
            grc.AddLinkByNodeName("osm2501221677", "osm2501221678", usetype: LinkUse.road, comment: "Bel-Red Road002.link7");
            grc.AddLinkByNodeName("osm53220860", "osm3218977981", usetype: LinkUse.road, comment: "148th Avenue Northeast002.link1");
            grc.AddLinkByNodeName("osm6217633462", "osm3801669809", usetype: LinkUse.road, comment: "Northeast 24th Street.link1");
            grc.AddLinkByNodeName("osm3218977982", "osm6217633462", usetype: LinkUse.road, comment: "Northeast 24th Street.link2");
            grc.AddLinkByNodeName("osm3801669691", "osm3218977982", usetype: LinkUse.road, comment: "Northeast 24th Street.link3");
            grc.AddLinkByNodeName("osm829661224", "osm4272164139", usetype: LinkUse.road, comment: "Northeast 24th Street001.link1");
            grc.AddLinkByNodeName("osm6193024942", "osm829661224", usetype: LinkUse.road, comment: "Northeast 24th Street001.link2");
            grc.AddLinkByNodeName("osm3810659585", "osm6193024942", usetype: LinkUse.road, comment: "Northeast 24th Street001.link3");
            grc.AddLinkByNodeName("osm6199821193", "osm3810659585", usetype: LinkUse.road, comment: "Northeast 24th Street001.link4");
            grc.AddLinkByNodeName("osm2500883983", "osm1082877387", usetype: LinkUse.road, comment: "Northeast 36th Street007.link1");
            grc.AddLinkByNodeName("osm327750040", "osm2500883983", usetype: LinkUse.road, comment: "Northeast 36th Street007.link2");
            grc.AddLinkByNodeName("osm1488907728", "osm327750040", usetype: LinkUse.road, comment: "Northeast 36th Street007.link3");
            grc.AddLinkByNodeName("osm1738823908", "osm1488907728", usetype: LinkUse.road, comment: "Northeast 36th Street007.link4");
            grc.AddLinkByNodeName("osm4049735526", "osm1738823908", usetype: LinkUse.road, comment: "Northeast 36th Street007.link5");
            grc.AddLinkByNodeName("osm321548678", "osm4049735526", usetype: LinkUse.road, comment: "Northeast 36th Street007.link6");
            grc.AddLinkByNodeName("osm1491102457", "osm321548678", usetype: LinkUse.road, comment: "Northeast 36th Street007.link7");
            grc.AddLinkByNodeName("osm4049735528", "osm1491102457", usetype: LinkUse.road, comment: "Northeast 36th Street007.link8");
            grc.AddLinkByNodeName("osm321548679", "osm4049735528", usetype: LinkUse.road, comment: "Northeast 36th Street007.link9");
            grc.AddLinkByNodeName("osm1082877364", "osm1835913814", usetype: LinkUse.road, comment: "Northeast 36th Street008.link1");
            grc.AddLinkByNodeName("osm53048846", "osm53051520", usetype: LinkUse.road, comment: "148th Avenue Northeast003.link1");
            grc.AddLinkByNodeName("osm3801669737", "osm740159601", usetype: LinkUse.road, comment: "148th Avenue Northeast004.link1");
            grc.AddLinkByNodeName("osm53051520", "osm3801669737", usetype: LinkUse.road, comment: "148th Avenue Northeast004.link2");
            grc.AddLinkByNodeName("osm3682699015", "osm53191551", usetype: LinkUse.road, comment: "Northeast 51st Street004.link1");
            grc.AddLinkByNodeName("osm6577673585", "osm3682699015", usetype: LinkUse.road, comment: "Northeast 51st Street004.link2");
            grc.AddLinkByNodeName("osm53162445", "osm6577673585", usetype: LinkUse.road, comment: "Northeast 51st Street004.link3");
            grc.AddLinkByNodeName("osm3682698110", "osm53162445", usetype: LinkUse.road, comment: "Northeast 51st Street004.link4");
            grc.AddLinkByNodeName("osm53237531", "osm3682698110", usetype: LinkUse.road, comment: "Northeast 51st Street004.link5");
            grc.AddLinkByNodeName("osm53227661", "osm53237531", usetype: LinkUse.road, comment: "Northeast 51st Street004.link6");
            grc.AddLinkByNodeName("osm3588045954", "osm53227661", usetype: LinkUse.road, comment: "Northeast 51st Street004.link7");
            grc.AddLinkByNodeName("osm2493146411", "osm3588045954", usetype: LinkUse.road, comment: "Northeast 51st Street004.link8");
            grc.AddLinkByNodeName("osm53176109", "osm2493146411", usetype: LinkUse.road, comment: "Northeast 51st Street004.link9");
            grc.AddLinkByNodeName("osm2493146434", "osm53176109", usetype: LinkUse.road, comment: "Northeast 51st Street004.link10");
            grc.AddLinkByNodeName("osm53237532", "osm2493146434", usetype: LinkUse.road, comment: "Northeast 51st Street004.link11");
            grc.AddLinkByNodeName("osm53237533", "osm53237532", usetype: LinkUse.road, comment: "Northeast 51st Street004.link12");
            grc.AddLinkByNodeName("osm6122409163", "osm53237533", usetype: LinkUse.road, comment: "Northeast 51st Street004.link13");
            grc.AddLinkByNodeName("osm6122409166", "osm6122409163", usetype: LinkUse.road, comment: "Northeast 51st Street004.link14");
            grc.AddLinkByNodeName("osm53124320", "osm6122409166", usetype: LinkUse.road, comment: "Northeast 51st Street004.link15");
            grc.AddLinkByNodeName("osm6577716007", "osm53124320", usetype: LinkUse.road, comment: "Northeast 51st Street004.link16");
            grc.AddLinkByNodeName("osm690687066", "osm6577716007", usetype: LinkUse.road, comment: "Northeast 51st Street004.link17");
            grc.AddLinkByNodeName("osm2493194112", "osm690687066", usetype: LinkUse.road, comment: "Northeast 51st Street004.link18");
            grc.AddLinkByNodeName("osm2493194059", "osm2493194112", usetype: LinkUse.road, comment: "Northeast 51st Street004.link19");
            grc.AddLinkByNodeName("osm53124370", "osm2493194059", usetype: LinkUse.road, comment: "Northeast 51st Street004.link20");
            grc.AddLinkByNodeName("osm740155369", "osm53124370", usetype: LinkUse.road, comment: "Northeast 51st Street004.link21");
            grc.AddLinkByNodeName("osm6122409136", "osm740155369", usetype: LinkUse.road, comment: "Northeast 51st Street004.link22");
            grc.AddLinkByNodeName("osm4272285441", "osm6122409136", usetype: LinkUse.road, comment: "Northeast 51st Street004.link23");
            grc.AddLinkByNodeName("osm3682685796", "osm53052405", usetype: LinkUse.road, comment: "Northeast 51st Street005.link1");
            grc.AddLinkByNodeName("osm3682698109", "osm3682685796", usetype: LinkUse.road, comment: "Northeast 51st Street005.link2");
            grc.AddLinkByNodeName("osm53237530", "osm3682698109", usetype: LinkUse.road, comment: "Northeast 51st Street006.link1");
            grc.AddLinkByNodeName("osm53100935", "osm53237530", usetype: LinkUse.road, comment: "Northeast 51st Street006.link2");
            grc.AddLinkByNodeName("osm748632244", "osm53135585", usetype: LinkUse.road, comment: "Bel-Red Road003.link1");
            grc.AddLinkByNodeName("osm878302217", "osm4272190808", usetype: LinkUse.road, comment: "Bel-Red Road004.link1");
            grc.AddLinkByNodeName("osm2657798422", "osm878302217", usetype: LinkUse.road, comment: "Bel-Red Road004.link2");
            grc.AddLinkByNodeName("osm53135587", "osm2657798422", usetype: LinkUse.road, comment: "Bel-Red Road004.link3");
            grc.AddLinkByNodeName("osm53135589", "osm53135587", usetype: LinkUse.road, comment: "Bel-Red Road004.link4");
            grc.AddLinkByNodeName("osm53081274", "osm53135589", usetype: LinkUse.road, comment: "Bel-Red Road004.link5");
            grc.AddLinkByNodeName("osm52987393", "osm53081274", usetype: LinkUse.road, comment: "Bel-Red Road004.link6");
            grc.AddLinkByNodeName("osm2657798417", "osm52987393", usetype: LinkUse.road, comment: "Bel-Red Road004.link7");
            grc.AddLinkByNodeName("osm1724480327", "osm3722441489", usetype: LinkUse.road, comment: "Northeast 29th Place.link1");
            grc.AddLinkByNodeName("osm2500812148", "osm1724480327", usetype: LinkUse.road, comment: "Northeast 29th Place.link2");
            grc.AddLinkByNodeName("osm1724480343", "osm2500812148", usetype: LinkUse.road, comment: "Northeast 29th Place.link3");
            grc.AddLinkByNodeName("osm2500812146", "osm1724480343", usetype: LinkUse.road, comment: "Northeast 29th Place.link4");
            grc.AddLinkByNodeName("osm1724480377", "osm2500812146", usetype: LinkUse.road, comment: "Northeast 29th Place.link5");
            grc.AddLinkByNodeName("osm1724480347", "osm1724480377", usetype: LinkUse.road, comment: "Northeast 29th Place.link6");
            grc.AddLinkByNodeName("osm1724480331", "osm1724480347", usetype: LinkUse.road, comment: "Northeast 29th Place.link7");
            grc.AddLinkByNodeName("osm1724480340", "osm1724480331", usetype: LinkUse.road, comment: "Northeast 29th Place.link8");
            grc.AddLinkByNodeName("osm2500812153", "osm1724480340", usetype: LinkUse.road, comment: "Northeast 29th Place.link9");
            grc.AddLinkByNodeName("osm2500812145", "osm2500812153", usetype: LinkUse.road, comment: "Northeast 29th Place.link10");
            grc.AddLinkByNodeName("osm1724480381", "osm2500812145", usetype: LinkUse.road, comment: "Northeast 29th Place.link11");
            grc.AddLinkByNodeName("osm2500812152", "osm1724480381", usetype: LinkUse.road, comment: "Northeast 29th Place.link12");
            grc.AddLinkByNodeName("osm1724480386", "osm2500812152", usetype: LinkUse.road, comment: "Northeast 29th Place.link13");
            grc.AddLinkByNodeName("osm1724480389", "osm1724480386", usetype: LinkUse.road, comment: "Northeast 29th Place.link14");
            grc.AddLinkByNodeName("osm3377549101", "osm1724480389", usetype: LinkUse.road, comment: "Northeast 29th Place.link15");
            grc.AddLinkByNodeName("osm53130846", "osm3377549101", usetype: LinkUse.road, comment: "Northeast 29th Place.link16");
            grc.AddLinkByNodeName("osm1738783629", "osm53130846", usetype: LinkUse.road, comment: "Northeast 29th Place.link17");
            grc.AddLinkByNodeName("osm2155615936", "osm1738783629", usetype: LinkUse.road, comment: "Northeast 29th Place.link18");
            grc.AddLinkByNodeName("osm3731157286", "osm2155615936", usetype: LinkUse.road, comment: "Northeast 29th Place.link19");
            grc.AddLinkByNodeName("osm2155615939", "osm3731157286", usetype: LinkUse.road, comment: "Northeast 29th Place.link20");
            grc.AddLinkByNodeName("osm1835922428", "osm2155615939", usetype: LinkUse.road, comment: "Northeast 29th Place.link21");
            grc.AddLinkByNodeName("osm1835922410", "osm1835922428", usetype: LinkUse.road, comment: "Northeast 29th Place.link22");
            grc.AddLinkByNodeName("osm53130848", "osm1835922410", usetype: LinkUse.road, comment: "Northeast 29th Place.link23");
            grc.AddLinkByNodeName("osm53130849", "osm53130848", usetype: LinkUse.road, comment: "Northeast 29th Place.link24");
            grc.AddLinkByNodeName("osm1738771461", "osm53130849", usetype: LinkUse.road, comment: "Northeast 29th Place.link25");
            grc.AddLinkByNodeName("osm346508486", "osm1738771461", usetype: LinkUse.road, comment: "Northeast 29th Place.link26");
            grc.AddLinkByNodeName("osm346082665", "osm346508486", usetype: LinkUse.road, comment: "Northeast 29th Place.link27");
            grc.AddLinkByNodeName("osm53130850", "osm346082665", usetype: LinkUse.road, comment: "Northeast 29th Place.link28");
            grc.AddLinkByNodeName("osm2500881974", "osm53130850", usetype: LinkUse.road, comment: "Northeast 29th Place.link29");
            grc.AddLinkByNodeName("osm1738771468", "osm2500881974", usetype: LinkUse.road, comment: "Northeast 29th Place.link30");
            grc.AddLinkByNodeName("osm2500881948", "osm1738771468", usetype: LinkUse.road, comment: "Northeast 29th Place.link31");
            grc.AddLinkByNodeName("osm2500881972", "osm2500881948", usetype: LinkUse.road, comment: "Northeast 29th Place.link32");
            grc.AddLinkByNodeName("osm53036753", "osm2500881972", usetype: LinkUse.road, comment: "Northeast 29th Place.link33");
            grc.AddLinkByNodeName("osm2500881961", "osm53036753", usetype: LinkUse.road, comment: "Northeast 29th Place.link34");
            grc.AddLinkByNodeName("osm346508489", "osm2500881961", usetype: LinkUse.road, comment: "Northeast 29th Place.link35");
            grc.AddLinkByNodeName("osm2500881969", "osm346508489", usetype: LinkUse.road, comment: "Northeast 29th Place.link36");
            grc.AddLinkByNodeName("osm740159768", "osm2500881969", usetype: LinkUse.road, comment: "Northeast 29th Place.link37");
            grc.AddLinkByNodeName("osm53059230", "osm740159768", usetype: LinkUse.road, comment: "Northeast 29th Place.link38");
            grc.AddLinkByNodeName("osm3801669622", "osm3801669809", usetype: LinkUse.road, comment: "secondary_link002.link1");
            grc.AddLinkByNodeName("osm4735590835", "osm3801669622", usetype: LinkUse.road, comment: "secondary_link002.link2");
            grc.AddLinkByNodeName("osm3801669020", "osm4735590835", usetype: LinkUse.road, comment: "secondary_link002.link3");
            grc.AddLinkByNodeName("osm3801669680", "osm3801669020", usetype: LinkUse.road, comment: "secondary_link002.link4");
            grc.AddLinkByNodeName("osm3801669748", "osm3801669054", usetype: LinkUse.road, comment: "148th Avenue Northeast005.link1");
            grc.AddLinkByNodeName("osm740159601", "osm3801669748", usetype: LinkUse.road, comment: "148th Avenue Northeast005.link2");
            grc.AddLinkByNodeName("osm4045186106", "osm53200804", usetype: LinkUse.road, comment: "148th Avenue Northeast006.link1");
            grc.AddLinkByNodeName("osm53040038", "osm4045186106", usetype: LinkUse.road, comment: "148th Avenue Northeast006.link2");
            grc.AddLinkByNodeName("osm53220872", "osm53040038", usetype: LinkUse.road, comment: "148th Avenue Northeast006.link3");
            grc.AddLinkByNodeName("osm3054311140", "osm53220872", usetype: LinkUse.road, comment: "148th Avenue Northeast006.link4");
            grc.AddLinkByNodeName("osm4045186108", "osm3054311140", usetype: LinkUse.road, comment: "148th Avenue Northeast006.link5");
            grc.AddLinkByNodeName("osm3054311154", "osm4045186108", usetype: LinkUse.road, comment: "148th Avenue Northeast006.link6");
            grc.AddLinkByNodeName("osm3682699441", "osm3054311154", usetype: LinkUse.road, comment: "148th Avenue Northeast006.link7");
            grc.AddLinkByNodeName("osm53220873", "osm3682699441", usetype: LinkUse.road, comment: "148th Avenue Northeast006.link8");
            grc.AddLinkByNodeName("osm3801669574", "osm3801669764", usetype: LinkUse.road, comment: "148th Avenue Northeast007.link1");
            grc.AddLinkByNodeName("osm3801669691", "osm3801669799", usetype: LinkUse.road, comment: "148th Avenue Northeast008.link1");
            grc.AddLinkByNodeName("osm3810659588", "osm3810659612", usetype: LinkUse.road, comment: "secondary_link003.link1");
            grc.AddLinkByNodeName("osm3940718876", "osm352588051", usetype: LinkUse.road, comment: "Bel-Red Road005.link1");
            grc.AddLinkByNodeName("osm752210775", "osm3940718876", usetype: LinkUse.road, comment: "Bel-Red Road005.link2");
            grc.AddLinkByNodeName("osm6196828178", "osm752210775", usetype: LinkUse.road, comment: "Bel-Red Road005.link3");
            grc.AddLinkByNodeName("osm6196828181", "osm6196828178", usetype: LinkUse.road, comment: "Bel-Red Road005.link4");
            grc.AddLinkByNodeName("osm3810659590", "osm6196828181", usetype: LinkUse.road, comment: "Bel-Red Road005.link5");
            grc.AddLinkByNodeName("osm708983284", "osm321546603", usetype: LinkUse.road, comment: "Bel-Red Road006.link1");
            grc.AddLinkByNodeName("osm3810659617", "osm708983284", usetype: LinkUse.road, comment: "Bel-Red Road006.link2");
            grc.AddLinkByNodeName("osm3810659613", "osm3810659617", usetype: LinkUse.road, comment: "Bel-Red Road006.link3");
            grc.AddLinkByNodeName("osm3810659583", "osm3810659613", usetype: LinkUse.road, comment: "Bel-Red Road006.link4");
            grc.AddLinkByNodeName("osm352588095", "osm3810659583", usetype: LinkUse.road, comment: "Bel-Red Road006.link5");
            grc.AddLinkByNodeName("osm3810659618", "osm352588095", usetype: LinkUse.road, comment: "Bel-Red Road006.link6");
            grc.AddLinkByNodeName("osm752197967", "osm752197849", usetype: LinkUse.road, comment: "Bel-Red Road007.link1");
            grc.AddLinkByNodeName("osm752198074", "osm752197967", usetype: LinkUse.road, comment: "Bel-Red Road007.link2");
            grc.AddLinkByNodeName("osm752198041", "osm752198074", usetype: LinkUse.road, comment: "Bel-Red Road007.link3");
            grc.AddLinkByNodeName("osm752198142", "osm752198041", usetype: LinkUse.road, comment: "Bel-Red Road007.link4");
            grc.AddLinkByNodeName("osm752197846", "osm752198142", usetype: LinkUse.road, comment: "Bel-Red Road007.link5");
            grc.AddLinkByNodeName("osm752198034", "osm752197846", usetype: LinkUse.road, comment: "Bel-Red Road007.link6");
            grc.AddLinkByNodeName("osm752198079", "osm752198034", usetype: LinkUse.road, comment: "Bel-Red Road007.link7");
            grc.AddLinkByNodeName("osm53135573", "osm752198079", usetype: LinkUse.road, comment: "Bel-Red Road007.link8");
            grc.AddLinkByNodeName("osm2657798420", "osm53135573", usetype: LinkUse.road, comment: "Bel-Red Road007.link9");
            grc.AddLinkByNodeName("osm3810659586", "osm6199821195", usetype: LinkUse.road, comment: "Northeast 24th Street002.link1");
            grc.AddLinkByNodeName("osm752197878", "osm3810659586", usetype: LinkUse.road, comment: "Northeast 24th Street002.link2");
            grc.AddLinkByNodeName("osm752210770", "osm752197878", usetype: LinkUse.road, comment: "Northeast 24th Street002.link3");
            grc.AddLinkByNodeName("osm4272164140", "osm752210770", usetype: LinkUse.road, comment: "Northeast 24th Street002.link4");
            grc.AddLinkByNodeName("osm741922180", "osm6215037915", usetype: LinkUse.road, comment: "Northeast 24th Street003.link1");
            grc.AddLinkByNodeName("osm4272164136", "osm741922180", usetype: LinkUse.road, comment: "Northeast 24th Street003.link2");
            grc.AddLinkByNodeName("osm6199263530", "osm6199263532", usetype: LinkUse.road, comment: "Northeast 24th Street004.link1");
            grc.AddLinkByNodeName("osm3810659599", "osm6199263530", usetype: LinkUse.road, comment: "Northeast 24th Street004.link2");
            grc.AddLinkByNodeName("osm332159041", "osm3810659599", usetype: LinkUse.road, comment: "Northeast 24th Street004.link3");
            grc.AddLinkByNodeName("osm4272164127", "osm332159041", usetype: LinkUse.road, comment: "Northeast 24th Street004.link4");
            grc.AddLinkByNodeName("osm3810659598", "osm6199821192", usetype: LinkUse.road, comment: "Northeast 24th Street005.link1");
            grc.AddLinkByNodeName("osm4584498739", "osm3810659598", usetype: LinkUse.road, comment: "Northeast 24th Street005.link2");
            grc.AddLinkByNodeName("osm4272164133", "osm4584498739", usetype: LinkUse.road, comment: "Northeast 24th Street005.link3");
            grc.AddLinkByNodeName("osm6193462229", "osm6193462233", usetype: LinkUse.road, comment: "Northeast 24th Street006.link1");
            grc.AddLinkByNodeName("osm3810659609", "osm6193462229", usetype: LinkUse.road, comment: "Northeast 24th Street006.link2");
            grc.AddLinkByNodeName("osm4272164135", "osm3810659609", usetype: LinkUse.road, comment: "Northeast 24th Street006.link3");
            grc.AddLinkByNodeName("osm3218977989", "osm3810659594", usetype: LinkUse.road, comment: "secondary_link004.link1");
            grc.AddLinkByNodeName("osm829661281", "osm4272203620", usetype: LinkUse.road, comment: "148th Avenue Northeast009.link1");
            grc.AddLinkByNodeName("osm53220868", "osm829661281", usetype: LinkUse.road, comment: "148th Avenue Northeast009.link2");
            grc.AddLinkByNodeName("osm741885671", "osm347253787", usetype: LinkUse.road, comment: "152nd Avenue Northeast003.link1");
            grc.AddLinkByNodeName("osm322979488", "osm741885671", usetype: LinkUse.road, comment: "152nd Avenue Northeast003.link2");
            grc.AddLinkByNodeName("osm4280806663", "osm322979488", usetype: LinkUse.road, comment: "152nd Avenue Northeast003.link3");
            grc.AddLinkByNodeName("osm3054684636", "osm4280806663", usetype: LinkUse.road, comment: "152nd Avenue Northeast003.link4");
            grc.AddLinkByNodeName("osm741885588", "osm3054684636", usetype: LinkUse.road, comment: "152nd Avenue Northeast003.link5");
            grc.AddLinkByNodeName("osm741885728", "osm741885588", usetype: LinkUse.road, comment: "152nd Avenue Northeast003.link6");
            grc.AddLinkByNodeName("osm3054684633", "osm741885728", usetype: LinkUse.road, comment: "152nd Avenue Northeast003.link7");
            grc.AddLinkByNodeName("osm53074772", "osm3054684633", usetype: LinkUse.road, comment: "152nd Avenue Northeast003.link8");
            grc.AddLinkByNodeName("osm3054683928", "osm53074772", usetype: LinkUse.road, comment: "152nd Avenue Northeast003.link9");
            grc.AddLinkByNodeName("osm3054683903", "osm3054683928", usetype: LinkUse.road, comment: "152nd Avenue Northeast003.link10");
            grc.AddLinkByNodeName("osm741885667", "osm3054683903", usetype: LinkUse.road, comment: "152nd Avenue Northeast003.link11");
            grc.AddLinkByNodeName("osm741599962", "osm741885667", usetype: LinkUse.road, comment: "152nd Avenue Northeast003.link12");
            grc.AddLinkByNodeName("osm752210675", "osm347260128", usetype: LinkUse.road, comment: "152nd Avenue Northeast004.link1");
            grc.AddLinkByNodeName("osm4488084036", "osm752210675", usetype: LinkUse.road, comment: "152nd Avenue Northeast004.link2");
            grc.AddLinkByNodeName("osm324749908", "osm4488084036", usetype: LinkUse.road, comment: "152nd Avenue Northeast004.link3");
            grc.AddLinkByNodeName("osm6199662231", "osm324749908", usetype: LinkUse.road, comment: "152nd Avenue Northeast004.link4");
            grc.AddLinkByNodeName("osm4045186101", "osm53183285", usetype: LinkUse.road, comment: "156th Avenue Northeast002.link1");
            grc.AddLinkByNodeName("osm5434210419", "osm4045186101", usetype: LinkUse.road, comment: "156th Avenue Northeast002.link2");
            grc.AddLinkByNodeName("osm53146535", "osm5434210419", usetype: LinkUse.road, comment: "156th Avenue Northeast002.link3");
            grc.AddLinkByNodeName("osm5434223623", "osm53146535", usetype: LinkUse.road, comment: "156th Avenue Northeast002.link4");
            grc.AddLinkByNodeName("osm3807446933", "osm5434223623", usetype: LinkUse.road, comment: "156th Avenue Northeast002.link5");
            grc.AddLinkByNodeName("osm767541773", "osm3807446933", usetype: LinkUse.road, comment: "156th Avenue Northeast002.link6");
            grc.AddLinkByNodeName("osm2671019420", "osm767541773", usetype: LinkUse.road, comment: "156th Avenue Northeast002.link7");
            grc.AddLinkByNodeName("osm1738648032", "osm2671019405", usetype: LinkUse.road, comment: "156th Avenue Northeast003.link1");
            grc.AddLinkByNodeName("osm4275697397", "osm1738648032", usetype: LinkUse.road, comment: "156th Avenue Northeast003.link2");
            grc.AddLinkByNodeName("osm4045186098", "osm1082877429", usetype: LinkUse.road, comment: "Northeast 31st Street005.link1");
            grc.AddLinkByNodeName("osm1036683210", "osm4045186098", usetype: LinkUse.road, comment: "Northeast 31st Street005.link2");
            grc.AddLinkByNodeName("osm53183285", "osm1036683210", usetype: LinkUse.road, comment: "Northeast 31st Street005.link3");
            grc.AddLinkByNodeName("osm5916914821", "osm4272236132", usetype: LinkUse.road, comment: "Northeast 40th Street003.link1");
            grc.AddLinkByNodeName("osm1036683207", "osm5916914821", usetype: LinkUse.road, comment: "Northeast 40th Street003.link2");
            grc.AddLinkByNodeName("osm4272236131", "osm1036683207", usetype: LinkUse.road, comment: "Northeast 40th Street003.link3");
            grc.AddLinkByNodeName("osm2298864238", "osm829661249", usetype: LinkUse.road, comment: "Northeast 40th Street004.link1");
            grc.AddLinkByNodeName("osm829661270", "osm2298864238", usetype: LinkUse.road, comment: "Northeast 40th Street004.link2");
            grc.AddLinkByNodeName("osm829661304", "osm829661270", usetype: LinkUse.road, comment: "Northeast 40th Street004.link3");
            grc.AddLinkByNodeName("osm2614085260", "osm829661304", usetype: LinkUse.road, comment: "Northeast 40th Street004.link4");
            grc.AddLinkByNodeName("osm4272219827", "osm2614085260", usetype: LinkUse.road, comment: "Northeast 40th Street004.link5");
            grc.AddLinkByNodeName("osm741885662", "osm53135569", usetype: LinkUse.road, comment: "Bel-Red Road008.link1");
            grc.AddLinkByNodeName("osm6193462231", "osm741885662", usetype: LinkUse.road, comment: "Bel-Red Road008.link2");
            grc.AddLinkByNodeName("osm752210687", "osm6193462231", usetype: LinkUse.road, comment: "Bel-Red Road008.link3");
            grc.AddLinkByNodeName("osm3810659618", "osm752210687", usetype: LinkUse.road, comment: "Bel-Red Road008.link4");
            grc.AddLinkByNodeName("osm4267453634", "osm4267453637", usetype: LinkUse.road, comment: "secondary_link005.link1");
            grc.AddLinkByNodeName("osm4267453636", "osm4267453634", usetype: LinkUse.road, comment: "secondary_link005.link2");
            grc.AddLinkByNodeName("osm6199263534", "osm4267453636", usetype: LinkUse.road, comment: "secondary_link005.link3");
            grc.AddLinkByNodeName("osm4267453640", "osm6199263534", usetype: LinkUse.road, comment: "secondary_link005.link4");
            grc.AddLinkByNodeName("osm4272218340", "osm4272218339", usetype: LinkUse.road, comment: "148th Avenue Northeast010.link1");
            grc.AddLinkByNodeName("osm4045186102", "osm4272218340", usetype: LinkUse.road, comment: "148th Avenue Northeast010.link2");
            grc.AddLinkByNodeName("osm387552346", "osm4045186102", usetype: LinkUse.road, comment: "148th Avenue Northeast010.link3");
            grc.AddLinkByNodeName("osm4302836459", "osm387552346", usetype: LinkUse.road, comment: "148th Avenue Northeast010.link4");
            grc.AddLinkByNodeName("osm4272218343", "osm4302836459", usetype: LinkUse.road, comment: "148th Avenue Northeast010.link5");
            grc.AddLinkByNodeName("osm4608804269", "osm4272141024", usetype: LinkUse.road, comment: "148th Avenue Northeast011.link1");
            grc.AddLinkByNodeName("osm4272141023", "osm4608804269", usetype: LinkUse.road, comment: "148th Avenue Northeast011.link2");
            grc.AddLinkByNodeName("osm4272141021", "osm336497626", usetype: LinkUse.road, comment: "148th Avenue Northeast012.link1");
            grc.AddLinkByNodeName("osm4608804262", "osm334984185", usetype: LinkUse.road, comment: "148th Avenue Northeast013.link1");
            grc.AddLinkByNodeName("osm4272141025", "osm4608804262", usetype: LinkUse.road, comment: "148th Avenue Northeast013.link2");
            grc.AddLinkByNodeName("osm53102800", "osm4272141025", usetype: LinkUse.road, comment: "148th Avenue Northeast014.link1");
            grc.AddLinkByNodeName("osm3805839899", "osm4272141021", usetype: LinkUse.road, comment: "148th Avenue Northeast015.link1");
            grc.AddLinkByNodeName("osm334984185", "osm3805839899", usetype: LinkUse.road, comment: "148th Avenue Northeast015.link2");
            grc.AddLinkByNodeName("osm4272140996", "osm4272141004", usetype: LinkUse.road, comment: "148th Avenue Northeast016.link1");
            grc.AddLinkByNodeName("osm4272141003", "osm4272140996", usetype: LinkUse.road, comment: "148th Avenue Northeast016.link2");
            grc.AddLinkByNodeName("osm53220874", "osm4272141018", usetype: LinkUse.road, comment: "148th Avenue Northeast017.link1");
            grc.AddLinkByNodeName("osm336497626", "osm53220874", usetype: LinkUse.road, comment: "148th Avenue Northeast017.link2");
            grc.AddLinkByNodeName("osm3805839898", "osm53102800", usetype: LinkUse.road, comment: "148th Avenue Northeast018.link1");
            grc.AddLinkByNodeName("osm3222664596", "osm3805839898", usetype: LinkUse.road, comment: "148th Avenue Northeast018.link2");
            grc.AddLinkByNodeName("osm2298864385", "osm2493126713", usetype: LinkUse.road, comment: "148th Avenue Northeast019.link1");
            grc.AddLinkByNodeName("osm4613004707", "osm2298864385", usetype: LinkUse.road, comment: "148th Avenue Northeast019.link2");
            grc.AddLinkByNodeName("osm53220871", "osm4613004707", usetype: LinkUse.road, comment: "148th Avenue Northeast019.link3");
            grc.AddLinkByNodeName("osm1036690323", "osm53220871", usetype: LinkUse.road, comment: "148th Avenue Northeast019.link4");
            grc.AddLinkByNodeName("osm53200804", "osm4272141002", usetype: LinkUse.road, comment: "148th Avenue Northeast020.link1");
            grc.AddLinkByNodeName("osm4272140998", "osm4272141017", usetype: LinkUse.road, comment: "148th Avenue Northeast021.link1");
            grc.AddLinkByNodeName("osm4272141016", "osm4272140998", usetype: LinkUse.road, comment: "148th Avenue Northeast021.link2");
            grc.AddLinkByNodeName("osm4272141015", "osm4272141016", usetype: LinkUse.road, comment: "148th Avenue Northeast021.link3");
            grc.AddLinkByNodeName("osm4272141027", "osm4272141028", usetype: LinkUse.road, comment: "148th Avenue Northeast022.link1");
            grc.AddLinkByNodeName("osm4272141026", "osm4272141027", usetype: LinkUse.road, comment: "148th Avenue Northeast022.link2");
            grc.AddLinkByNodeName("osm4272141024", "osm4272141026", usetype: LinkUse.road, comment: "148th Avenue Northeast022.link3");
            grc.AddLinkByNodeName("osm3682699443", "osm53220873", usetype: LinkUse.road, comment: "148th Avenue Northeast023.link1");
            grc.AddLinkByNodeName("osm4045186110", "osm3682699443", usetype: LinkUse.road, comment: "148th Avenue Northeast023.link2");
            grc.AddLinkByNodeName("osm4272141018", "osm4045186110", usetype: LinkUse.road, comment: "148th Avenue Northeast023.link3");
            grc.AddLinkByNodeName("osm4272140999", "osm1036690323", usetype: LinkUse.road, comment: "148th Avenue Northeast024.link1");
            grc.AddLinkByNodeName("osm6372504741", "osm4272140999", usetype: LinkUse.road, comment: "148th Avenue Northeast024.link2");
            grc.AddLinkByNodeName("osm53079445", "osm6372504741", usetype: LinkUse.road, comment: "148th Avenue Northeast024.link3");
            grc.AddLinkByNodeName("osm4272141002", "osm53079445", usetype: LinkUse.road, comment: "148th Avenue Northeast024.link4");
            grc.AddLinkByNodeName("osm4272141020", "osm4272141023", usetype: LinkUse.road, comment: "148th Avenue Northeast025.link1");
            grc.AddLinkByNodeName("osm4272141017", "osm4272141020", usetype: LinkUse.road, comment: "148th Avenue Northeast025.link2");
            grc.AddLinkByNodeName("osm4272140995", "osm4272141003", usetype: LinkUse.road, comment: "148th Avenue Northeast026.link1");
            grc.AddLinkByNodeName("osm4272141001", "osm4272140995", usetype: LinkUse.road, comment: "148th Avenue Northeast026.link2");
            grc.AddLinkByNodeName("osm4272141000", "osm4272141001", usetype: LinkUse.road, comment: "148th Avenue Northeast026.link3");
            grc.AddLinkByNodeName("osm1036690323", "osm4272141000", usetype: LinkUse.road, comment: "148th Avenue Northeast026.link4");
            grc.AddLinkByNodeName("osm4272141012", "osm4272141015", usetype: LinkUse.road, comment: "148th Avenue Northeast027.link1");
            grc.AddLinkByNodeName("osm4272141011", "osm4272141012", usetype: LinkUse.road, comment: "148th Avenue Northeast027.link2");
            grc.AddLinkByNodeName("osm4272140997", "osm4272141011", usetype: LinkUse.road, comment: "148th Avenue Northeast027.link3");
            grc.AddLinkByNodeName("osm4272141008", "osm4272140997", usetype: LinkUse.road, comment: "148th Avenue Northeast027.link4");
            grc.AddLinkByNodeName("osm4272141006", "osm4272141008", usetype: LinkUse.road, comment: "148th Avenue Northeast027.link5");
            grc.AddLinkByNodeName("osm4272141005", "osm4272141006", usetype: LinkUse.road, comment: "148th Avenue Northeast027.link6");
            grc.AddLinkByNodeName("osm4272141004", "osm4272141005", usetype: LinkUse.road, comment: "148th Avenue Northeast027.link7");
            grc.AddLinkByNodeName("osm4272141013", "osm3054311159", usetype: LinkUse.road, comment: "Northeast 51st Street007.link1");
            grc.AddLinkByNodeName("osm53206031", "osm4272141007", usetype: LinkUse.road, comment: "Northeast 51st Street008.link1");
            grc.AddLinkByNodeName("osm4272141010", "osm53237529", usetype: LinkUse.road, comment: "Northeast 51st Street009.link1");
            grc.AddLinkByNodeName("osm602854096", "osm53052387", usetype: LinkUse.road, comment: "Northeast 51st Street010.link1");
            grc.AddLinkByNodeName("osm3682699442", "osm53220873", usetype: LinkUse.road, comment: "Northeast 51st Street011.link1");
            grc.AddLinkByNodeName("osm3054311159", "osm3682699442", usetype: LinkUse.road, comment: "Northeast 51st Street011.link2");
            grc.AddLinkByNodeName("osm3054311158", "osm4272141013", usetype: LinkUse.road, comment: "Northeast 51st Street012.link1");
            grc.AddLinkByNodeName("osm53237529", "osm3054311158", usetype: LinkUse.road, comment: "Northeast 51st Street012.link2");
            grc.AddLinkByNodeName("osm4272141009", "osm4272141010", usetype: LinkUse.road, comment: "Northeast 51st Street013.link1");
            grc.AddLinkByNodeName("osm334984185", "osm4272141023", usetype: LinkUse.road, comment: "secondary001.link1");
            grc.AddLinkByNodeName("osm4272143191", "osm3801669779", usetype: LinkUse.road, comment: "148th Avenue Northeast028.link1");
            grc.AddLinkByNodeName("osm6219028621", "osm53048880", usetype: LinkUse.road, comment: "148th Avenue Northeast029.link1");
            grc.AddLinkByNodeName("osm3801669768", "osm6219028621", usetype: LinkUse.road, comment: "148th Avenue Northeast029.link2");
            grc.AddLinkByNodeName("osm3801669564", "osm3801669768", usetype: LinkUse.road, comment: "148th Avenue Northeast029.link3");
            grc.AddLinkByNodeName("osm3801669764", "osm3801669564", usetype: LinkUse.road, comment: "148th Avenue Northeast029.link4");
            grc.AddLinkByNodeName("osm3801669788", "osm4272143191", usetype: LinkUse.road, comment: "148th Avenue Northeast030.link1");
            grc.AddLinkByNodeName("osm346516376", "osm3801669788", usetype: LinkUse.road, comment: "148th Avenue Northeast030.link2");
            grc.AddLinkByNodeName("osm3810659587", "osm3810659618", usetype: LinkUse.road, comment: "Bel-Red Road009.link1");
            grc.AddLinkByNodeName("osm352588051", "osm3810659587", usetype: LinkUse.road, comment: "Bel-Red Road009.link2");
            grc.AddLinkByNodeName("osm4267453637", "osm4272154843", usetype: LinkUse.road, comment: "Bel-Red Road010.link1");
            grc.AddLinkByNodeName("osm6196828180", "osm4267453637", usetype: LinkUse.road, comment: "Bel-Red Road010.link2");
            grc.AddLinkByNodeName("osm708983296", "osm6196828180", usetype: LinkUse.road, comment: "Bel-Red Road010.link3");
            grc.AddLinkByNodeName("osm321546603", "osm708983296", usetype: LinkUse.road, comment: "Bel-Red Road010.link4");
            grc.AddLinkByNodeName("osm3218977981", "osm3801669691", usetype: LinkUse.road, comment: "Northeast 24th Street007.link1");
            grc.AddLinkByNodeName("osm741885619", "osm53135569", usetype: LinkUse.road, comment: "Northeast 24th Street008.link1");
            grc.AddLinkByNodeName("osm4045186096", "osm741885619", usetype: LinkUse.road, comment: "Northeast 24th Street008.link2");
            grc.AddLinkByNodeName("osm3218977989", "osm4045186096", usetype: LinkUse.road, comment: "Northeast 24th Street008.link3");
            grc.AddLinkByNodeName("osm674168910", "osm3218977989", usetype: LinkUse.road, comment: "Northeast 24th Street008.link4");
            grc.AddLinkByNodeName("osm4272164137", "osm674168910", usetype: LinkUse.road, comment: "Northeast 24th Street008.link5");
            grc.AddLinkByNodeName("osm6248078753", "osm53227633", usetype: LinkUse.road, comment: "Northeast 24th Street009.link1");
            grc.AddLinkByNodeName("osm4584498744", "osm6248078753", usetype: LinkUse.road, comment: "Northeast 24th Street009.link2");
            grc.AddLinkByNodeName("osm4272164126", "osm4584498744", usetype: LinkUse.road, comment: "Northeast 24th Street009.link3");
            grc.AddLinkByNodeName("osm741885710", "osm347253787", usetype: LinkUse.road, comment: "Northeast 24th Street010.link1");
            grc.AddLinkByNodeName("osm3810659582", "osm741885710", usetype: LinkUse.road, comment: "Northeast 24th Street010.link2");
            grc.AddLinkByNodeName("osm3810659600", "osm3810659582", usetype: LinkUse.road, comment: "Northeast 24th Street010.link3");
            grc.AddLinkByNodeName("osm3810659594", "osm3810659600", usetype: LinkUse.road, comment: "Northeast 24th Street010.link4");
            grc.AddLinkByNodeName("osm4293776045", "osm3810659594", usetype: LinkUse.road, comment: "Northeast 24th Street010.link5");
            grc.AddLinkByNodeName("osm4272164132", "osm4293776045", usetype: LinkUse.road, comment: "Northeast 24th Street010.link6");
            grc.AddLinkByNodeName("osm4584498742", "osm4272164126", usetype: LinkUse.road, comment: "Northeast 24th Street011.link1");
            grc.AddLinkByNodeName("osm53195788", "osm4584498742", usetype: LinkUse.road, comment: "Northeast 24th Street011.link2");
            grc.AddLinkByNodeName("osm4272164124", "osm53195788", usetype: LinkUse.road, comment: "Northeast 24th Street012.link1");
            grc.AddLinkByNodeName("osm53227633", "osm4272164128", usetype: LinkUse.road, comment: "Northeast 24th Street013.link1");
            grc.AddLinkByNodeName("osm6199263525", "osm4272164136", usetype: LinkUse.road, comment: "Northeast 24th Street014.link1");
            grc.AddLinkByNodeName("osm6199263531", "osm6199263525", usetype: LinkUse.road, comment: "Northeast 24th Street014.link2");
            grc.AddLinkByNodeName("osm6199263533", "osm6199263531", usetype: LinkUse.road, comment: "Northeast 24th Street014.link3");
            grc.AddLinkByNodeName("osm3810659611", "osm4272164132", usetype: LinkUse.road, comment: "Northeast 24th Street015.link1");
            grc.AddLinkByNodeName("osm6193462230", "osm3810659611", usetype: LinkUse.road, comment: "Northeast 24th Street015.link2");
            grc.AddLinkByNodeName("osm6193462233", "osm6193462230", usetype: LinkUse.road, comment: "Northeast 24th Street015.link3");
            grc.AddLinkByNodeName("osm6193024941", "osm4272164135", usetype: LinkUse.road, comment: "Northeast 24th Street016.link1");
            grc.AddLinkByNodeName("osm3810659579", "osm6193024941", usetype: LinkUse.road, comment: "Northeast 24th Street016.link2");
            grc.AddLinkByNodeName("osm6199821194", "osm3810659579", usetype: LinkUse.road, comment: "Northeast 24th Street016.link3");
            grc.AddLinkByNodeName("osm3218977985", "osm4272164134", usetype: LinkUse.road, comment: "Northeast 24th Street017.link1");
            grc.AddLinkByNodeName("osm3801669809", "osm3218977985", usetype: LinkUse.road, comment: "Northeast 24th Street017.link2");
            grc.AddLinkByNodeName("osm752197888", "osm3810659604", usetype: LinkUse.road, comment: "Northeast 24th Street018.link1");
            grc.AddLinkByNodeName("osm4272164139", "osm752197888", usetype: LinkUse.road, comment: "Northeast 24th Street018.link2");
            grc.AddLinkByNodeName("osm3810659581", "osm4272164133", usetype: LinkUse.road, comment: "Northeast 24th Street019.link1");
            grc.AddLinkByNodeName("osm3810659604", "osm3810659581", usetype: LinkUse.road, comment: "Northeast 24th Street019.link2");
            grc.AddLinkByNodeName("osm3810659589", "osm4272164137", usetype: LinkUse.road, comment: "Northeast 24th Street020.link1");
            grc.AddLinkByNodeName("osm6196674550", "osm3810659589", usetype: LinkUse.road, comment: "Northeast 24th Street020.link2");
            grc.AddLinkByNodeName("osm6215037915", "osm6196674550", usetype: LinkUse.road, comment: "Northeast 24th Street020.link3");
            grc.AddLinkByNodeName("osm6215037916", "osm4272164127", usetype: LinkUse.road, comment: "Northeast 24th Street021.link1");
            grc.AddLinkByNodeName("osm347253787", "osm6215037916", usetype: LinkUse.road, comment: "Northeast 24th Street021.link2");
            grc.AddLinkByNodeName("osm3218977983", "osm3218977981", usetype: LinkUse.road, comment: "Northeast 24th Street022.link1");
            grc.AddLinkByNodeName("osm3218977984", "osm3218977983", usetype: LinkUse.road, comment: "Northeast 24th Street022.link2");
            grc.AddLinkByNodeName("osm4272164130", "osm3218977984", usetype: LinkUse.road, comment: "Northeast 24th Street022.link3");
            grc.AddLinkByNodeName("osm2920682248", "osm4272164130", usetype: LinkUse.road, comment: "Northeast 24th Street023.link1");
            grc.AddLinkByNodeName("osm3218977986", "osm2920682248", usetype: LinkUse.road, comment: "Northeast 24th Street023.link2");
            grc.AddLinkByNodeName("osm3218977979", "osm3218977986", usetype: LinkUse.road, comment: "Northeast 24th Street023.link3");
            grc.AddLinkByNodeName("osm752210658", "osm4272164140", usetype: LinkUse.road, comment: "Northeast 24th Street024.link1");
            grc.AddLinkByNodeName("osm6193462228", "osm752210658", usetype: LinkUse.road, comment: "Northeast 24th Street024.link2");
            grc.AddLinkByNodeName("osm741885590", "osm6193462228", usetype: LinkUse.road, comment: "Northeast 24th Street024.link3");
            grc.AddLinkByNodeName("osm53135569", "osm741885590", usetype: LinkUse.road, comment: "Northeast 24th Street024.link4");
            grc.AddLinkByNodeName("osm6219028625", "osm6219028624", usetype: LinkUse.road, comment: "Northeast 24th Street025.link1");
            grc.AddLinkByNodeName("osm346516420", "osm6219028625", usetype: LinkUse.road, comment: "Northeast 24th Street025.link2");
            grc.AddLinkByNodeName("osm6217633460", "osm346516420", usetype: LinkUse.road, comment: "Northeast 24th Street025.link3");
            grc.AddLinkByNodeName("osm740155200", "osm6217633460", usetype: LinkUse.road, comment: "Northeast 24th Street025.link4");
            grc.AddLinkByNodeName("osm53220860", "osm740155200", usetype: LinkUse.road, comment: "Northeast 24th Street025.link5");
            grc.AddLinkByNodeName("osm332158830", "osm3810659612", usetype: LinkUse.road, comment: "Northeast 24th Street026.link1");
            grc.AddLinkByNodeName("osm3810659603", "osm332158830", usetype: LinkUse.road, comment: "Northeast 24th Street026.link2");
            grc.AddLinkByNodeName("osm6199263526", "osm3810659603", usetype: LinkUse.road, comment: "Northeast 24th Street026.link3");
            grc.AddLinkByNodeName("osm6199263529", "osm6199263526", usetype: LinkUse.road, comment: "Northeast 24th Street026.link4");
            grc.AddLinkByNodeName("osm6199263532", "osm6199263529", usetype: LinkUse.road, comment: "Northeast 24th Street026.link5");
            grc.AddLinkByNodeName("osm741922198", "osm6199263533", usetype: LinkUse.road, comment: "Northeast 24th Street027.link1");
            grc.AddLinkByNodeName("osm3810659605", "osm741922198", usetype: LinkUse.road, comment: "Northeast 24th Street027.link2");
            grc.AddLinkByNodeName("osm3810659588", "osm3810659605", usetype: LinkUse.road, comment: "Northeast 24th Street027.link3");
            grc.AddLinkByNodeName("osm3218977987", "osm3810659588", usetype: LinkUse.road, comment: "Northeast 24th Street027.link4");
            grc.AddLinkByNodeName("osm4272164134", "osm3218977987", usetype: LinkUse.road, comment: "Northeast 24th Street027.link5");
            grc.AddLinkByNodeName("osm4584498716", "osm3810659604", usetype: LinkUse.road, comment: "Northeast 24th Street028.link1");
            grc.AddLinkByNodeName("osm752197997", "osm4584498716", usetype: LinkUse.road, comment: "Northeast 24th Street028.link2");
            grc.AddLinkByNodeName("osm6193202162", "osm752197997", usetype: LinkUse.road, comment: "Northeast 24th Street028.link3");
            grc.AddLinkByNodeName("osm281302447", "osm2501221677", usetype: LinkUse.road, comment: "Bel-Red Road011.link1");
            grc.AddLinkByNodeName("osm740159709", "osm281302447", usetype: LinkUse.road, comment: "Bel-Red Road011.link2");
            grc.AddLinkByNodeName("osm4272180371", "osm740159709", usetype: LinkUse.road, comment: "Bel-Red Road011.link3");
            grc.AddLinkByNodeName("osm740159753", "osm4272180371", usetype: LinkUse.road, comment: "Bel-Red Road012.link1");
            grc.AddLinkByNodeName("osm740159578", "osm740159753", usetype: LinkUse.road, comment: "Bel-Red Road012.link2");
            grc.AddLinkByNodeName("osm796674160", "osm740159578", usetype: LinkUse.road, comment: "Bel-Red Road012.link3");
            grc.AddLinkByNodeName("osm53135596", "osm796674160", usetype: LinkUse.road, comment: "Bel-Red Road012.link4");
            grc.AddLinkByNodeName("osm4272180376", "osm4272180375", usetype: LinkUse.road, comment: "Northeast 40th Street005.link1");
            grc.AddLinkByNodeName("osm53222541", "osm4272180372", usetype: LinkUse.road, comment: "Northeast 40th Street006.link1");
            grc.AddLinkByNodeName("osm53247738", "osm53222541", usetype: LinkUse.road, comment: "Northeast 40th Street007.link1");
            grc.AddLinkByNodeName("osm4272180373", "osm53247738", usetype: LinkUse.road, comment: "Northeast 40th Street007.link2");
            grc.AddLinkByNodeName("osm740155215", "osm4272180374", usetype: LinkUse.road, comment: "Northeast 40th Street008.link1");
            grc.AddLinkByNodeName("osm53135596", "osm740155215", usetype: LinkUse.road, comment: "Northeast 40th Street008.link2");
            grc.AddLinkByNodeName("osm796674175", "osm53135596", usetype: LinkUse.road, comment: "Northeast 40th Street009.link1");
            grc.AddLinkByNodeName("osm4272180375", "osm796674175", usetype: LinkUse.road, comment: "Northeast 40th Street009.link2");
            grc.AddLinkByNodeName("osm6073204938", "osm4272236135", usetype: LinkUse.road, comment: "Northeast 40th Street010.link1");
            grc.AddLinkByNodeName("osm1738648109", "osm6073204938", usetype: LinkUse.road, comment: "Northeast 40th Street010.link2");
            grc.AddLinkByNodeName("osm407651372", "osm1738648109", usetype: LinkUse.road, comment: "Northeast 40th Street010.link3");
            grc.AddLinkByNodeName("osm53135585", "osm4272190807", usetype: LinkUse.road, comment: "Bel-Red Road013.link1");
            grc.AddLinkByNodeName("osm752197889", "osm748632244", usetype: LinkUse.road, comment: "Bel-Red Road014.link1");
            grc.AddLinkByNodeName("osm4272190808", "osm752197889", usetype: LinkUse.road, comment: "Bel-Red Road014.link2");
            grc.AddLinkByNodeName("osm6219028623", "osm3801669574", usetype: LinkUse.road, comment: "148th Avenue Northeast031.link1");
            grc.AddLinkByNodeName("osm3801669054", "osm6219028623", usetype: LinkUse.road, comment: "148th Avenue Northeast031.link2");
            grc.AddLinkByNodeName("osm4272203617", "osm4272203618", usetype: LinkUse.road, comment: "148th Avenue Northeast032.link1");
            grc.AddLinkByNodeName("osm4272203620", "osm4272203619", usetype: LinkUse.road, comment: "148th Avenue Northeast033.link1");
            grc.AddLinkByNodeName("osm346502680", "osm4272203601", usetype: LinkUse.road, comment: "148th Avenue Northeast034.link1");
            grc.AddLinkByNodeName("osm4272203608", "osm4272203607", usetype: LinkUse.road, comment: "148th Avenue Northeast035.link1");
            grc.AddLinkByNodeName("osm53183073", "osm4272203615", usetype: LinkUse.road, comment: "148th Avenue Northeast036.link1");
            grc.AddLinkByNodeName("osm3225792975", "osm4272203608", usetype: LinkUse.road, comment: "148th Avenue Northeast037.link1");
            grc.AddLinkByNodeName("osm321548682", "osm3225792975", usetype: LinkUse.road, comment: "148th Avenue Northeast037.link2");
            grc.AddLinkByNodeName("osm53200311", "osm53183073", usetype: LinkUse.road, comment: "148th Avenue Northeast038.link1");
            grc.AddLinkByNodeName("osm4272203619", "osm53200311", usetype: LinkUse.road, comment: "148th Avenue Northeast038.link2");
            grc.AddLinkByNodeName("osm4272203603", "osm4272203604", usetype: LinkUse.road, comment: "148th Avenue Northeast039.link1");
            grc.AddLinkByNodeName("osm4272203602", "osm4272203603", usetype: LinkUse.road, comment: "148th Avenue Northeast039.link2");
            grc.AddLinkByNodeName("osm4272203598", "osm53220861", usetype: LinkUse.road, comment: "148th Avenue Northeast040.link1");
            grc.AddLinkByNodeName("osm5362545372", "osm4272203598", usetype: LinkUse.road, comment: "148th Avenue Northeast040.link2");
            grc.AddLinkByNodeName("osm4272203601", "osm5362545372", usetype: LinkUse.road, comment: "148th Avenue Northeast040.link3");
            grc.AddLinkByNodeName("osm4608804237", "osm4272203602", usetype: LinkUse.road, comment: "148th Avenue Northeast041.link1");
            grc.AddLinkByNodeName("osm4272203600", "osm4608804237", usetype: LinkUse.road, comment: "148th Avenue Northeast041.link2");
            grc.AddLinkByNodeName("osm4272203599", "osm4272203600", usetype: LinkUse.road, comment: "148th Avenue Northeast041.link3");
            grc.AddLinkByNodeName("osm53220861", "osm4272203599", usetype: LinkUse.road, comment: "148th Avenue Northeast041.link4");
            grc.AddLinkByNodeName("osm4608804222", "osm4272203617", usetype: LinkUse.road, comment: "148th Avenue Northeast042.link1");
            grc.AddLinkByNodeName("osm4272203616", "osm4608804222", usetype: LinkUse.road, comment: "148th Avenue Northeast042.link2");
            grc.AddLinkByNodeName("osm4272203614", "osm4272203616", usetype: LinkUse.road, comment: "148th Avenue Northeast042.link3");
            grc.AddLinkByNodeName("osm4608804219", "osm4272203614", usetype: LinkUse.road, comment: "148th Avenue Northeast042.link4");
            grc.AddLinkByNodeName("osm4272203613", "osm4608804219", usetype: LinkUse.road, comment: "148th Avenue Northeast042.link5");
            grc.AddLinkByNodeName("osm321549405", "osm346502680", usetype: LinkUse.road, comment: "148th Avenue Northeast043.link1");
            grc.AddLinkByNodeName("osm3225789655", "osm321549405", usetype: LinkUse.road, comment: "148th Avenue Northeast043.link2");
            grc.AddLinkByNodeName("osm4608804253", "osm3225789655", usetype: LinkUse.road, comment: "148th Avenue Northeast043.link3");
            grc.AddLinkByNodeName("osm4272203607", "osm4608804253", usetype: LinkUse.road, comment: "148th Avenue Northeast043.link4");
            grc.AddLinkByNodeName("osm4272203612", "osm4272203613", usetype: LinkUse.road, comment: "148th Avenue Northeast044.link1");
            grc.AddLinkByNodeName("osm4272203611", "osm4272203612", usetype: LinkUse.road, comment: "148th Avenue Northeast044.link2");
            grc.AddLinkByNodeName("osm4272203610", "osm4272203611", usetype: LinkUse.road, comment: "148th Avenue Northeast044.link3");
            grc.AddLinkByNodeName("osm4272203623", "osm53220868", usetype: LinkUse.road, comment: "148th Avenue Northeast045.link1");
            grc.AddLinkByNodeName("osm4272203622", "osm4272203623", usetype: LinkUse.road, comment: "148th Avenue Northeast045.link2");
            grc.AddLinkByNodeName("osm4272203621", "osm4272203622", usetype: LinkUse.road, comment: "148th Avenue Northeast045.link3");
            grc.AddLinkByNodeName("osm4272203618", "osm4272203621", usetype: LinkUse.road, comment: "148th Avenue Northeast045.link4");
            grc.AddLinkByNodeName("osm740159624", "osm53059230", usetype: LinkUse.road, comment: "148th Avenue Northeast046.link1");
            grc.AddLinkByNodeName("osm4608804261", "osm740159624", usetype: LinkUse.road, comment: "148th Avenue Northeast046.link2");
            grc.AddLinkByNodeName("osm4272205044", "osm4608804261", usetype: LinkUse.road, comment: "148th Avenue Northeast046.link3");
            grc.AddLinkByNodeName("osm3227264069", "osm321548682", usetype: LinkUse.road, comment: "148th Avenue Northeast047.link1");
            grc.AddLinkByNodeName("osm3227263344", "osm3227264069", usetype: LinkUse.road, comment: "148th Avenue Northeast047.link2");
            grc.AddLinkByNodeName("osm331738691", "osm3227263344", usetype: LinkUse.road, comment: "148th Avenue Northeast047.link3");
            grc.AddLinkByNodeName("osm4272203615", "osm331738691", usetype: LinkUse.road, comment: "148th Avenue Northeast047.link4");
            grc.AddLinkByNodeName("osm4272203609", "osm4272203610", usetype: LinkUse.road, comment: "148th Avenue Northeast048.link1");
            grc.AddLinkByNodeName("osm4272203606", "osm4272203609", usetype: LinkUse.road, comment: "148th Avenue Northeast048.link2");
            grc.AddLinkByNodeName("osm4272203605", "osm4272203606", usetype: LinkUse.road, comment: "148th Avenue Northeast048.link3");
            grc.AddLinkByNodeName("osm4272203604", "osm4272203605", usetype: LinkUse.road, comment: "148th Avenue Northeast048.link4");
            grc.AddLinkByNodeName("osm53059230", "osm740159601", usetype: LinkUse.road, comment: "148th Avenue Northeast049.link1");
            grc.AddLinkByNodeName("osm415837860", "osm4272205044", usetype: LinkUse.road, comment: "148th Avenue Northeast050.link1");
            grc.AddLinkByNodeName("osm6323443783", "osm415837860", usetype: LinkUse.road, comment: "148th Avenue Northeast050.link2");
            grc.AddLinkByNodeName("osm53220861", "osm6323443783", usetype: LinkUse.road, comment: "148th Avenue Northeast050.link3");
            grc.AddLinkByNodeName("osm4272218350", "osm4272218349", usetype: LinkUse.road, comment: "148th Avenue Northeast051.link1");
            grc.AddLinkByNodeName("osm2493126713", "osm4272218350", usetype: LinkUse.road, comment: "148th Avenue Northeast051.link2");
            grc.AddLinkByNodeName("osm4608804229", "osm387552332", usetype: LinkUse.road, comment: "148th Avenue Northeast052.link1");
            grc.AddLinkByNodeName("osm3819829438", "osm4608804229", usetype: LinkUse.road, comment: "148th Avenue Northeast052.link2");
            grc.AddLinkByNodeName("osm53220870", "osm3819829438", usetype: LinkUse.road, comment: "148th Avenue Northeast052.link3");
            grc.AddLinkByNodeName("osm2699075015", "osm53220868", usetype: LinkUse.road, comment: "148th Avenue Northeast053.link1");
            grc.AddLinkByNodeName("osm4272218339", "osm2699075015", usetype: LinkUse.road, comment: "148th Avenue Northeast053.link2");
            grc.AddLinkByNodeName("osm4272218345", "osm4272218343", usetype: LinkUse.road, comment: "148th Avenue Northeast054.link1");
            grc.AddLinkByNodeName("osm387552332", "osm4272218345", usetype: LinkUse.road, comment: "148th Avenue Northeast054.link2");
            grc.AddLinkByNodeName("osm4272218344", "osm387552332", usetype: LinkUse.road, comment: "148th Avenue Northeast055.link1");
            grc.AddLinkByNodeName("osm4272218342", "osm4272218344", usetype: LinkUse.road, comment: "148th Avenue Northeast055.link2");
            grc.AddLinkByNodeName("osm4272218341", "osm4272218342", usetype: LinkUse.road, comment: "148th Avenue Northeast055.link3");
            grc.AddLinkByNodeName("osm4272218339", "osm4272218341", usetype: LinkUse.road, comment: "148th Avenue Northeast055.link4");
            grc.AddLinkByNodeName("osm4272218346", "osm53220870", usetype: LinkUse.road, comment: "148th Avenue Northeast056.link1");
            grc.AddLinkByNodeName("osm345259333", "osm4272218346", usetype: LinkUse.road, comment: "148th Avenue Northeast056.link2");
            grc.AddLinkByNodeName("osm345259229", "osm345259333", usetype: LinkUse.road, comment: "148th Avenue Northeast056.link3");
            grc.AddLinkByNodeName("osm4272218349", "osm345259229", usetype: LinkUse.road, comment: "148th Avenue Northeast056.link4");
            grc.AddLinkByNodeName("osm4272218351", "osm2493126713", usetype: LinkUse.road, comment: "148th Avenue Northeast057.link1");
            grc.AddLinkByNodeName("osm4272218348", "osm4272218351", usetype: LinkUse.road, comment: "148th Avenue Northeast057.link2");
            grc.AddLinkByNodeName("osm4272218347", "osm4272218348", usetype: LinkUse.road, comment: "148th Avenue Northeast057.link3");
            grc.AddLinkByNodeName("osm53220870", "osm4272218347", usetype: LinkUse.road, comment: "148th Avenue Northeast057.link4");
            grc.AddLinkByNodeName("osm4856116759", "osm743394852", usetype: LinkUse.road, comment: "Northeast 40th Street011.link1");
            grc.AddLinkByNodeName("osm4606062790", "osm4856116759", usetype: LinkUse.road, comment: "Northeast 40th Street011.link2");
            grc.AddLinkByNodeName("osm4272219831", "osm4606062790", usetype: LinkUse.road, comment: "Northeast 40th Street011.link3");
            grc.AddLinkByNodeName("osm53247733", "osm4272219829", usetype: LinkUse.road, comment: "Northeast 40th Street012.link1");
            grc.AddLinkByNodeName("osm4488084045", "osm281301770", usetype: LinkUse.road, comment: "Northeast 40th Street013.link1");
            grc.AddLinkByNodeName("osm4272219829", "osm4488084045", usetype: LinkUse.road, comment: "Northeast 40th Street013.link2");
            grc.AddLinkByNodeName("osm4278458231", "osm4272219828", usetype: LinkUse.road, comment: "Northeast 40th Street014.link1");
            grc.AddLinkByNodeName("osm281301770", "osm4278458231", usetype: LinkUse.road, comment: "Northeast 40th Street014.link2");
            grc.AddLinkByNodeName("osm321709193", "osm1105703434", usetype: LinkUse.road, comment: "Northeast 40th Street015.link1");
            grc.AddLinkByNodeName("osm4856116761", "osm53247733", usetype: LinkUse.road, comment: "Northeast 40th Street016.link1");
            grc.AddLinkByNodeName("osm4272219830", "osm4856116761", usetype: LinkUse.road, comment: "Northeast 40th Street016.link2");
            grc.AddLinkByNodeName("osm4045186149", "osm4272219830", usetype: LinkUse.road, comment: "Northeast 40th Street017.link1");
            grc.AddLinkByNodeName("osm4488084043", "osm4045186149", usetype: LinkUse.road, comment: "Northeast 40th Street017.link2");
            grc.AddLinkByNodeName("osm4856116757", "osm4488084043", usetype: LinkUse.road, comment: "Northeast 40th Street017.link3");
            grc.AddLinkByNodeName("osm743394852", "osm4856116757", usetype: LinkUse.road, comment: "Northeast 40th Street017.link4");
            grc.AddLinkByNodeName("osm3679402922", "osm4272219827", usetype: LinkUse.road, comment: "Northeast 40th Street018.link1");
            grc.AddLinkByNodeName("osm53220868", "osm3679402922", usetype: LinkUse.road, comment: "Northeast 40th Street018.link2");
            grc.AddLinkByNodeName("osm3227263347", "osm53220868", usetype: LinkUse.road, comment: "Northeast 40th Street019.link1");
            grc.AddLinkByNodeName("osm4272219828", "osm3227263347", usetype: LinkUse.road, comment: "Northeast 40th Street019.link2");
            grc.AddLinkByNodeName("osm346078654", "osm321709000", usetype: LinkUse.road, comment: "Northeast 40th Street020.link1");
            grc.AddLinkByNodeName("osm53195739", "osm4272236137", usetype: LinkUse.road, comment: "Northeast 40th Street021.link1");
            grc.AddLinkByNodeName("osm2671019418", "osm4272236134", usetype: LinkUse.road, comment: "Northeast 40th Street022.link1");
            grc.AddLinkByNodeName("osm321709000", "osm4272236131", usetype: LinkUse.road, comment: "Northeast 40th Street023.link1");
            grc.AddLinkByNodeName("osm4987343128", "osm53195739", usetype: LinkUse.road, comment: "Northeast 40th Street024.link1");
            grc.AddLinkByNodeName("osm4987343129", "osm4987343128", usetype: LinkUse.road, comment: "Northeast 40th Street024.link2");
            grc.AddLinkByNodeName("osm4272236136", "osm4987343129", usetype: LinkUse.road, comment: "Northeast 40th Street024.link3");
            grc.AddLinkByNodeName("osm53124375", "osm4272236136", usetype: LinkUse.road, comment: "Northeast 40th Street025.link1");
            grc.AddLinkByNodeName("osm4272236134", "osm4272236133", usetype: LinkUse.road, comment: "Northeast 40th Street026.link1");
            grc.AddLinkByNodeName("osm6116835246", "osm2671019418", usetype: LinkUse.road, comment: "Northeast 40th Street027.link1");
            grc.AddLinkByNodeName("osm4272236135", "osm6116835246", usetype: LinkUse.road, comment: "Northeast 40th Street027.link2");
            grc.AddLinkByNodeName("osm4272180372", "osm53124375", usetype: LinkUse.road, comment: "Northeast 40th Street028.link1");
            grc.AddLinkByNodeName("osm1738648104", "osm2192655195", usetype: LinkUse.road, comment: "Northeast 40th Street029.link1");
            grc.AddLinkByNodeName("osm4272236133", "osm1738648104", usetype: LinkUse.road, comment: "Northeast 40th Street029.link2");
            grc.AddLinkByNodeName("osm767541804", "osm2192655195", usetype: LinkUse.road, comment: "Northeast 40th Street030.link1");
            grc.AddLinkByNodeName("osm4272236132", "osm767541804", usetype: LinkUse.road, comment: "Northeast 40th Street030.link2");
            grc.AddLinkByNodeName("osm3516771379", "osm407651372", usetype: LinkUse.road, comment: "Northeast 40th Street031.link1");
            grc.AddLinkByNodeName("osm4272236137", "osm3516771379", usetype: LinkUse.road, comment: "Northeast 40th Street031.link2");
            grc.AddLinkByNodeName("osm6122409041", "osm4272285441", usetype: LinkUse.road, comment: "Northeast 51st Street014.link1");
            grc.AddLinkByNodeName("osm6122409050", "osm6122409041", usetype: LinkUse.road, comment: "Northeast 51st Street014.link2");
            grc.AddLinkByNodeName("osm53237534", "osm6122409050", usetype: LinkUse.road, comment: "Northeast 51st Street014.link3");
            grc.AddLinkByNodeName("osm690687786", "osm53070318", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast002.link1");
            grc.AddLinkByNodeName("osm4272285442", "osm740155416", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast003.link1");
            grc.AddLinkByNodeName("osm53237534", "osm4272285440", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast004.link1");
            grc.AddLinkByNodeName("osm53133391", "osm4272285450", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast005.link1");
            grc.AddLinkByNodeName("osm740155416", "osm53237534", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast006.link1");
            grc.AddLinkByNodeName("osm4272285439", "osm690687786", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast007.link1");
            grc.AddLinkByNodeName("osm4272285450", "osm4272285449", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast008.link1");
            grc.AddLinkByNodeName("osm53070318", "osm53252645", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast009.link1");
            grc.AddLinkByNodeName("osm690687741", "osm53252643", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast010.link1");
            grc.AddLinkByNodeName("osm4272285437", "osm690687741", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast010.link2");
            grc.AddLinkByNodeName("osm690687880", "osm4272285439", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast011.link1");
            grc.AddLinkByNodeName("osm2493194111", "osm690687880", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast011.link2");
            grc.AddLinkByNodeName("osm6060263317", "osm2493194111", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast011.link3");
            grc.AddLinkByNodeName("osm2300480674", "osm6060263317", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast011.link4");
            grc.AddLinkByNodeName("osm53252644", "osm4272285437", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast012.link1");
            grc.AddLinkByNodeName("osm740159652", "osm53252644", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast012.link2");
            grc.AddLinkByNodeName("osm53252645", "osm740159652", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast012.link3");
            grc.AddLinkByNodeName("osm4272285444", "osm4272285442", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast013.link1");
            grc.AddLinkByNodeName("osm4272285446", "osm4272285444", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast013.link2");
            grc.AddLinkByNodeName("osm4853787417", "osm4272285446", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast013.link3");
            grc.AddLinkByNodeName("osm53152869", "osm53252648", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast014.link1");
            grc.AddLinkByNodeName("osm53162576", "osm53152869", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast014.link2");
            grc.AddLinkByNodeName("osm53252649", "osm53162576", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast014.link3");
            grc.AddLinkByNodeName("osm4272285440", "osm53252649", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast014.link4");
            grc.AddLinkByNodeName("osm4272285445", "osm4853787416", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast015.link1");
            grc.AddLinkByNodeName("osm4272285443", "osm4272285445", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast015.link2");
            grc.AddLinkByNodeName("osm4272285442", "osm4272285443", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast015.link3");
            grc.AddLinkByNodeName("osm2493196268", "osm4272285436", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast016.link1");
            grc.AddLinkByNodeName("osm690687878", "osm2493196268", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast016.link2");
            grc.AddLinkByNodeName("osm690687879", "osm690687878", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast016.link3");
            grc.AddLinkByNodeName("osm796660790", "osm690687879", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast016.link4");
            grc.AddLinkByNodeName("osm53252643", "osm796660790", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast016.link5");
            grc.AddLinkByNodeName("osm752210663", "osm6193024939", usetype: LinkUse.road, comment: "156th Avenue Northeast004.link1");
            grc.AddLinkByNodeName("osm6196828177", "osm752210663", usetype: LinkUse.road, comment: "156th Avenue Northeast004.link2");
            grc.AddLinkByNodeName("osm767507601", "osm6196828177", usetype: LinkUse.road, comment: "156th Avenue Northeast004.link3");
            grc.AddLinkByNodeName("osm3810659590", "osm767507601", usetype: LinkUse.road, comment: "156th Avenue Northeast004.link4");
            grc.AddLinkByNodeName("osm321546603", "osm3810659590", usetype: LinkUse.road, comment: "156th Avenue Northeast004.link5");
            grc.AddLinkByNodeName("osm708983283", "osm321546603", usetype: LinkUse.road, comment: "156th Avenue Northeast004.link6");
            grc.AddLinkByNodeName("osm6196828179", "osm708983283", usetype: LinkUse.road, comment: "156th Avenue Northeast004.link7");
            grc.AddLinkByNodeName("osm4267453640", "osm6196828179", usetype: LinkUse.road, comment: "156th Avenue Northeast004.link8");
            grc.AddLinkByNodeName("osm752210661", "osm4267453640", usetype: LinkUse.road, comment: "156th Avenue Northeast004.link9");
            grc.AddLinkByNodeName("osm747467301", "osm752210661", usetype: LinkUse.road, comment: "156th Avenue Northeast004.link10");
            grc.AddLinkByNodeName("osm6196828176", "osm747467301", usetype: LinkUse.road, comment: "156th Avenue Northeast004.link11");
            grc.AddLinkByNodeName("osm1036683205", "osm6198892491", usetype: LinkUse.road, comment: "156th Avenue Northeast005.link1");
            grc.AddLinkByNodeName("osm53183285", "osm1036683205", usetype: LinkUse.road, comment: "156th Avenue Northeast005.link2");
            grc.AddLinkByNodeName("osm4275697395", "osm4275697396", usetype: LinkUse.road, comment: "156th Avenue Northeast006.link1");
            grc.AddLinkByNodeName("osm4275697392", "osm4275697395", usetype: LinkUse.road, comment: "156th Avenue Northeast006.link2");
            grc.AddLinkByNodeName("osm4275697391", "osm4275697392", usetype: LinkUse.road, comment: "156th Avenue Northeast006.link3");
            grc.AddLinkByNodeName("osm4275697393", "osm4275697391", usetype: LinkUse.road, comment: "156th Avenue Northeast007.link1");
            grc.AddLinkByNodeName("osm752197940", "osm4275697393", usetype: LinkUse.road, comment: "156th Avenue Northeast007.link2");
            grc.AddLinkByNodeName("osm4275697394", "osm752197940", usetype: LinkUse.road, comment: "156th Avenue Northeast007.link3");
            grc.AddLinkByNodeName("osm4275697396", "osm4275697394", usetype: LinkUse.road, comment: "156th Avenue Northeast007.link4");
            grc.AddLinkByNodeName("osm4275697403", "osm4275697405", usetype: LinkUse.road, comment: "156th Avenue Northeast008.link1");
            grc.AddLinkByNodeName("osm6198892492", "osm4275697403", usetype: LinkUse.road, comment: "156th Avenue Northeast008.link2");
            grc.AddLinkByNodeName("osm4275697402", "osm6198892492", usetype: LinkUse.road, comment: "156th Avenue Northeast008.link3");
            grc.AddLinkByNodeName("osm4278382985", "osm4275697402", usetype: LinkUse.road, comment: "156th Avenue Northeast008.link4");
            grc.AddLinkByNodeName("osm4275697398", "osm4278382985", usetype: LinkUse.road, comment: "156th Avenue Northeast008.link5");
            grc.AddLinkByNodeName("osm6198892495", "osm4275697397", usetype: LinkUse.road, comment: "156th Avenue Northeast009.link1");
            grc.AddLinkByNodeName("osm4275697399", "osm6198892495", usetype: LinkUse.road, comment: "156th Avenue Northeast009.link2");
            grc.AddLinkByNodeName("osm6198892493", "osm4275697399", usetype: LinkUse.road, comment: "156th Avenue Northeast009.link3");
            grc.AddLinkByNodeName("osm4017340409", "osm6198892493", usetype: LinkUse.road, comment: "156th Avenue Northeast009.link4");
            grc.AddLinkByNodeName("osm53191546", "osm4017340409", usetype: LinkUse.road, comment: "156th Avenue Northeast009.link5");
            grc.AddLinkByNodeName("osm4275697404", "osm53191546", usetype: LinkUse.road, comment: "156th Avenue Northeast009.link6");
            grc.AddLinkByNodeName("osm4275697405", "osm4275697404", usetype: LinkUse.road, comment: "156th Avenue Northeast009.link7");
            grc.AddLinkByNodeName("osm4294894961", "osm4294894960", usetype: LinkUse.road, comment: "unclassified002.link1");
            grc.AddLinkByNodeName("osm828422475", "osm705015506", usetype: LinkUse.road, comment: "164th Avenue Northeast001.link1");
            grc.AddLinkByNodeName("osm53116727", "osm828422475", usetype: LinkUse.road, comment: "164th Avenue Northeast001.link2");
            grc.AddLinkByNodeName("osm53098139", "osm53116727", usetype: LinkUse.road, comment: "164th Avenue Northeast001.link3");
            grc.AddLinkByNodeName("osm53135404", "osm53098139", usetype: LinkUse.road, comment: "164th Avenue Northeast001.link4");
            grc.AddLinkByNodeName("osm53135406", "osm53135404", usetype: LinkUse.road, comment: "164th Avenue Northeast001.link5");
            grc.AddLinkByNodeName("osm878385128", "osm53135406", usetype: LinkUse.road, comment: "164th Avenue Northeast001.link6");
            grc.AddLinkByNodeName("osm53089852", "osm878385128", usetype: LinkUse.road, comment: "164th Avenue Northeast001.link7");
            grc.AddLinkByNodeName("osm878385178", "osm53089852", usetype: LinkUse.road, comment: "164th Avenue Northeast001.link8");
            grc.AddLinkByNodeName("osm53135409", "osm878385178", usetype: LinkUse.road, comment: "164th Avenue Northeast001.link9");
            grc.AddLinkByNodeName("osm2502193869", "osm2502193874", usetype: LinkUse.road, comment: "156th Avenue Northeast010.link1");
            grc.AddLinkByNodeName("osm53190554", "osm2502193869", usetype: LinkUse.road, comment: "156th Avenue Northeast010.link2");
            grc.AddLinkByNodeName("osm53152233", "osm53190554", usetype: LinkUse.road, comment: "156th Avenue Northeast010.link3");
            grc.AddLinkByNodeName("osm53191553", "osm53152233", usetype: LinkUse.road, comment: "156th Avenue Northeast010.link4");
            grc.AddLinkByNodeName("osm4728687020", "osm53191553", usetype: LinkUse.road, comment: "156th Avenue Northeast010.link5");
            grc.AddLinkByNodeName("osm53191552", "osm4728687020", usetype: LinkUse.road, comment: "156th Avenue Northeast010.link6");
            grc.AddLinkByNodeName("osm53097858", "osm53191552", usetype: LinkUse.road, comment: "156th Avenue Northeast010.link7");
            grc.AddLinkByNodeName("osm6577707100", "osm53097858", usetype: LinkUse.road, comment: "156th Avenue Northeast010.link8");
            grc.AddLinkByNodeName("osm3222406608", "osm6577707100", usetype: LinkUse.road, comment: "156th Avenue Northeast010.link9");
            grc.AddLinkByNodeName("osm3682699016", "osm3222406608", usetype: LinkUse.road, comment: "156th Avenue Northeast010.link10");
            grc.AddLinkByNodeName("osm53191551", "osm3682699016", usetype: LinkUse.road, comment: "156th Avenue Northeast010.link11");
            grc.AddLinkByNodeName("osm4761352780", "osm53110393", usetype: LinkUse.road, comment: "156th Avenue Northeast011.link1");
            grc.AddLinkByNodeName("osm53191556", "osm4761352780", usetype: LinkUse.road, comment: "156th Avenue Northeast011.link2");
            grc.AddLinkByNodeName("osm4272285448", "osm4853787417", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast017.link1");
            grc.AddLinkByNodeName("osm4272285449", "osm4272285448", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast017.link2");
            grc.AddLinkByNodeName("osm4272285447", "osm4272285449", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast018.link1");
            grc.AddLinkByNodeName("osm4853787416", "osm4272285447", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast018.link2");
            grc.AddLinkByNodeName("osm53191549", "osm5879789088", usetype: LinkUse.road, comment: "156th Avenue Northeast012.link1");
            grc.AddLinkByNodeName("osm2192655194", "osm53191549", usetype: LinkUse.road, comment: "156th Avenue Northeast012.link2");
            grc.AddLinkByNodeName("osm5916951297", "osm2192655194", usetype: LinkUse.road, comment: "156th Avenue Northeast012.link3");
            grc.AddLinkByNodeName("osm2671019420", "osm5916951297", usetype: LinkUse.road, comment: "156th Avenue Northeast012.link4");
            grc.AddLinkByNodeName("osm4488084047", "osm4488084040", usetype: LinkUse.road, comment: "156th Avenue Northeast013.link1");
            grc.AddLinkByNodeName("osm767541807", "osm4488084047", usetype: LinkUse.road, comment: "156th Avenue Northeast013.link2");
            grc.AddLinkByNodeName("osm2192655195", "osm767541807", usetype: LinkUse.road, comment: "156th Avenue Northeast013.link3");
            grc.AddLinkByNodeName("osm1082877458", "osm1082877406", usetype: LinkUse.road, comment: "tertiary002.link1");
            grc.AddLinkByNodeName("osm4488084015", "osm1082877458", usetype: LinkUse.road, comment: "tertiary002.link2");
            grc.AddLinkByNodeName("osm2563978821", "osm4488084015", usetype: LinkUse.road, comment: "tertiary002.link3");
            grc.AddLinkByNodeName("osm4488084016", "osm2563978821", usetype: LinkUse.road, comment: "tertiary002.link4");
            grc.AddLinkByNodeName("osm1082877376", "osm4488084016", usetype: LinkUse.road, comment: "tertiary002.link5");
            grc.AddLinkByNodeName("osm1082877433", "osm1082877376", usetype: LinkUse.road, comment: "tertiary002.link6");
            grc.AddLinkByNodeName("osm1082877438", "osm1082881766", usetype: LinkUse.road, comment: "tertiary003.link1");
            grc.AddLinkByNodeName("osm4488084014", "osm1082877438", usetype: LinkUse.road, comment: "tertiary003.link2");
            grc.AddLinkByNodeName("osm1082877406", "osm4488084014", usetype: LinkUse.road, comment: "tertiary003.link3");
            grc.AddLinkByNodeName("osm1082877401", "osm1082881763", usetype: LinkUse.road, comment: "tertiary004.link1");
            grc.AddLinkByNodeName("osm4488084021", "osm1082877401", usetype: LinkUse.road, comment: "tertiary004.link2");
            grc.AddLinkByNodeName("osm1082881765", "osm4488084021", usetype: LinkUse.road, comment: "tertiary004.link3");
            grc.AddLinkByNodeName("osm4488084020", "osm1082881765", usetype: LinkUse.road, comment: "tertiary004.link4");
            grc.AddLinkByNodeName("osm1082877371", "osm4488084020", usetype: LinkUse.road, comment: "tertiary004.link5");
            grc.AddLinkByNodeName("osm1082881766", "osm1082877371", usetype: LinkUse.road, comment: "tertiary004.link6");
            grc.AddLinkByNodeName("osm4272203610", "osm321548682", usetype: LinkUse.road, comment: "Northeast 35th Street002.link1");
            grc.AddLinkByNodeName("osm4488084019", "osm1082877399", usetype: LinkUse.road, comment: "tertiary005.link1");
            grc.AddLinkByNodeName("osm1082881763", "osm4488084019", usetype: LinkUse.road, comment: "tertiary005.link2");
            grc.AddLinkByNodeName("osm1082881764", "osm1082877433", usetype: LinkUse.road, comment: "tertiary006.link1");
            grc.AddLinkByNodeName("osm796660935", "osm53247741", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link1");
            grc.AddLinkByNodeName("osm53076884", "osm796660935", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link2");
            grc.AddLinkByNodeName("osm1066589803", "osm53076884", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link3");
            grc.AddLinkByNodeName("osm53252639", "osm1066589803", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link4");
            grc.AddLinkByNodeName("osm1066589810", "osm53252639", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link5");
            grc.AddLinkByNodeName("osm796651321", "osm1066589810", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link6");
            grc.AddLinkByNodeName("osm1066589821", "osm796651321", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link7");
            grc.AddLinkByNodeName("osm690687875", "osm1066589821", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link8");
            grc.AddLinkByNodeName("osm1066589824", "osm690687875", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link9");
            grc.AddLinkByNodeName("osm1066589826", "osm1066589824", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link10");
            grc.AddLinkByNodeName("osm2371263479", "osm1066589826", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link11");
            grc.AddLinkByNodeName("osm1066589827", "osm2371263479", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link12");
            grc.AddLinkByNodeName("osm53252640", "osm1066589827", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link13");
            grc.AddLinkByNodeName("osm1066589834", "osm53252640", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link14");
            grc.AddLinkByNodeName("osm1066589841", "osm1066589834", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link15");
            grc.AddLinkByNodeName("osm1066589846", "osm1066589841", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link16");
            grc.AddLinkByNodeName("osm690687876", "osm1066589846", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link17");
            grc.AddLinkByNodeName("osm1066589848", "osm690687876", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link18");
            grc.AddLinkByNodeName("osm53182769", "osm1066589848", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link19");
            grc.AddLinkByNodeName("osm743394911", "osm53182769", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link20");
            grc.AddLinkByNodeName("osm743394823", "osm743394911", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link21");
            grc.AddLinkByNodeName("osm53069769", "osm743394823", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link22");
            grc.AddLinkByNodeName("osm53222823", "osm53069769", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link23");
            grc.AddLinkByNodeName("osm53252642", "osm53222823", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link24");
            grc.AddLinkByNodeName("osm690687732", "osm53252642", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link25");
            grc.AddLinkByNodeName("osm796660783", "osm690687732", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link26");
            grc.AddLinkByNodeName("osm796660828", "osm796660783", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link27");
            grc.AddLinkByNodeName("osm796660876", "osm796660828", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link28");
            grc.AddLinkByNodeName("osm690687877", "osm796660876", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link29");
            grc.AddLinkByNodeName("osm4272285436", "osm690687877", usetype: LinkUse.road, comment: "West Lake Sammamish Parkway Northeast019.link30");
            grc.AddLinkByNodeName("osm4272141015", "osm53220873", usetype: LinkUse.road, comment: "Northeast 51st Street015.link1");
            grc.AddLinkByNodeName("osm5131013167", "osm5879789088", usetype: LinkUse.road, comment: "156th Avenue Northeast014.link1");
            grc.AddLinkByNodeName("osm345518571", "osm5131013167", usetype: LinkUse.road, comment: "156th Avenue Northeast014.link2");
            grc.AddLinkByNodeName("osm2192655196", "osm345518571", usetype: LinkUse.road, comment: "156th Avenue Northeast015.link1");
            grc.AddLinkByNodeName("osm4488084040", "osm2192655196", usetype: LinkUse.road, comment: "156th Avenue Northeast015.link2");
            grc.AddLinkByNodeName("osm53091627", "osm53091624", usetype: LinkUse.road, comment: "152nd Avenue Northeast005.link1");
            grc.AddLinkByNodeName("osm53091628", "osm53091627", usetype: LinkUse.road, comment: "152nd Avenue Northeast005.link2");
            grc.AddLinkByNodeName("osm2563978827", "osm53091628", usetype: LinkUse.road, comment: "152nd Avenue Northeast005.link3");
            grc.AddLinkByNodeName("osm53091624", "osm6046905082", usetype: LinkUse.road, comment: "152nd Avenue Northeast006.link1");
            grc.AddLinkByNodeName("osm752197921", "osm6053893671", usetype: LinkUse.road, comment: "156th Avenue Northeast016.link1");
            grc.AddLinkByNodeName("osm6193024940", "osm752197921", usetype: LinkUse.road, comment: "156th Avenue Northeast016.link2");
            grc.AddLinkByNodeName("osm708968737", "osm6193024940", usetype: LinkUse.road, comment: "156th Avenue Northeast016.link3");
            grc.AddLinkByNodeName("osm6199821196", "osm708968737", usetype: LinkUse.road, comment: "156th Avenue Northeast016.link4");
            grc.AddLinkByNodeName("osm53033470", "osm3543342002", usetype: LinkUse.road, comment: "156th Avenue Northeast017.link1");
            grc.AddLinkByNodeName("osm767541796", "osm53033470", usetype: LinkUse.road, comment: "156th Avenue Northeast017.link2");
            grc.AddLinkByNodeName("osm2192655195", "osm767541796", usetype: LinkUse.road, comment: "156th Avenue Northeast017.link3");
            grc.AddLinkByNodeName("osm3543342002", "osm321550409", usetype: LinkUse.road, comment: "156th Avenue Northeast018.link1");
            grc.AddLinkByNodeName("osm321550409", "osm3543342011", usetype: LinkUse.road, comment: "156th Avenue Northeast019.link1");
            grc.AddLinkByNodeName("osm3543342011", "osm321550408", usetype: LinkUse.road, comment: "156th Avenue Northeast020.link1");
            grc.AddLinkByNodeName("osm6193024935", "osm6193024939", usetype: LinkUse.road, comment: "156th Avenue Northeast021.link1");
            grc.AddLinkByNodeName("osm6193024936", "osm6193024935", usetype: LinkUse.road, comment: "156th Avenue Northeast021.link2");
            grc.AddLinkByNodeName("osm6193024934", "osm6193024936", usetype: LinkUse.road, comment: "156th Avenue Northeast021.link3");
            grc.AddLinkByNodeName("osm6193024937", "osm6193024934", usetype: LinkUse.road, comment: "156th Avenue Northeast021.link4");
            grc.AddLinkByNodeName("osm6193024938", "osm6193024937", usetype: LinkUse.road, comment: "156th Avenue Northeast021.link5");
            grc.AddLinkByNodeName("osm6193024931", "osm6193024938", usetype: LinkUse.road, comment: "156th Avenue Northeast021.link6");
            grc.AddLinkByNodeName("osm6193024932", "osm6193024931", usetype: LinkUse.road, comment: "156th Avenue Northeast021.link7");
            grc.AddLinkByNodeName("osm6193024933", "osm6193024932", usetype: LinkUse.road, comment: "156th Avenue Northeast021.link8");
            grc.AddLinkByNodeName("osm6199821195", "osm6193024933", usetype: LinkUse.road, comment: "156th Avenue Northeast021.link9");
            grc.AddLinkByNodeName("osm6199821192", "osm6199821196", usetype: LinkUse.road, comment: "156th Avenue Northeast022.link1");
            grc.AddLinkByNodeName("osm747690834", "osm6193202162", usetype: LinkUse.road, comment: "Northeast 24th Street029.link1");
            grc.AddLinkByNodeName("osm6193202163", "osm747690834", usetype: LinkUse.road, comment: "Northeast 24th Street029.link2");
            grc.AddLinkByNodeName("osm6248078761", "osm6193202163", usetype: LinkUse.road, comment: "Northeast 24th Street029.link3");
            grc.AddLinkByNodeName("osm321378847", "osm6248078761", usetype: LinkUse.road, comment: "Northeast 24th Street029.link4");
            grc.AddLinkByNodeName("osm6248078754", "osm321378847", usetype: LinkUse.road, comment: "Northeast 24th Street030.link1");
            grc.AddLinkByNodeName("osm3810659600", "osm674168910", usetype: LinkUse.road, comment: "secondary_link006.link1");
            grc.AddLinkByNodeName("osm4275697391", "osm6196828176", usetype: LinkUse.road, comment: "156th Avenue Northeast023.link1");
            grc.AddLinkByNodeName("osm6196828183", "osm3810659590", usetype: LinkUse.road, comment: "Bel-Red Road015.link1");
            grc.AddLinkByNodeName("osm6196828184", "osm6196828183", usetype: LinkUse.road, comment: "Bel-Red Road015.link2");
            grc.AddLinkByNodeName("osm6196828182", "osm6196828184", usetype: LinkUse.road, comment: "Bel-Red Road015.link3");
            grc.AddLinkByNodeName("osm752197849", "osm6196828182", usetype: LinkUse.road, comment: "Bel-Red Road015.link4");
            grc.AddLinkByNodeName("osm747467298", "osm752197849", usetype: LinkUse.road, comment: "Bel-Red Road016.link1");
            grc.AddLinkByNodeName("osm4272154843", "osm747467298", usetype: LinkUse.road, comment: "Bel-Red Road016.link2");
            grc.AddLinkByNodeName("osm6198892491", "osm4275697405", usetype: LinkUse.road, comment: "156th Avenue Northeast024.link1");
            grc.AddLinkByNodeName("osm6198892494", "osm4275697398", usetype: LinkUse.road, comment: "156th Avenue Northeast025.link1");
            grc.AddLinkByNodeName("osm4275697397", "osm6198892494", usetype: LinkUse.road, comment: "156th Avenue Northeast025.link2");
            grc.AddLinkByNodeName("osm752198130", "osm6198892496", usetype: LinkUse.road, comment: "156th Avenue Northeast026.link1");
            grc.AddLinkByNodeName("osm2671019405", "osm752198130", usetype: LinkUse.road, comment: "156th Avenue Northeast026.link2");
            grc.AddLinkByNodeName("osm752197903", "osm4275697396", usetype: LinkUse.road, comment: "156th Avenue Northeast027.link1");
            grc.AddLinkByNodeName("osm6198892496", "osm752197903", usetype: LinkUse.road, comment: "156th Avenue Northeast027.link2");
            grc.AddLinkByNodeName("osm2563978877", "osm2563978876", usetype: LinkUse.road, comment: "Northest 31st Street002.link1");
            grc.AddLinkByNodeName("osm6198997573", "osm2563978877", usetype: LinkUse.road, comment: "Northest 31st Street002.link2");
            grc.AddLinkByNodeName("osm3934726662", "osm6198997573", usetype: LinkUse.road, comment: "Northest 31st Street003.link1");
            grc.AddLinkByNodeName("osm6198997575", "osm3934726662", usetype: LinkUse.road, comment: "Northest 31st Street003.link2");
            grc.AddLinkByNodeName("osm1082877429", "osm6198997575", usetype: LinkUse.road, comment: "Northest 31st Street003.link3");
            grc.AddLinkByNodeName("osm409460061", "osm6198997573", usetype: LinkUse.road, comment: "tertiary_link005.link1");
            grc.AddLinkByNodeName("osm741922213", "osm6199662231", usetype: LinkUse.road, comment: "152nd Avenue Northeast007.link1");
            grc.AddLinkByNodeName("osm6215037915", "osm741922213", usetype: LinkUse.road, comment: "152nd Avenue Northeast007.link2");
            grc.AddLinkByNodeName("osm347253787", "osm6215037915", usetype: LinkUse.road, comment: "152nd Avenue Northeast007.link3");
            grc.AddLinkByNodeName("osm752210780", "osm6199662233", usetype: LinkUse.road, comment: "152nd Avenue Northeast008.link1");
            grc.AddLinkByNodeName("osm347260128", "osm752210780", usetype: LinkUse.road, comment: "152nd Avenue Northeast008.link2");
            grc.AddLinkByNodeName("osm4488084035", "osm6199662234", usetype: LinkUse.road, comment: "152nd Avenue Northeast009.link1");
            grc.AddLinkByNodeName("osm6199662233", "osm4488084035", usetype: LinkUse.road, comment: "152nd Avenue Northeast009.link2");
            grc.AddLinkByNodeName("osm752210682", "osm6199662239", usetype: LinkUse.road, comment: "152nd Avenue Northeast010.link1");
            grc.AddLinkByNodeName("osm752210744", "osm752210682", usetype: LinkUse.road, comment: "152nd Avenue Northeast010.link2");
            grc.AddLinkByNodeName("osm6199662239", "osm53091609", usetype: LinkUse.road, comment: "152nd Avenue Northeast011.link1");
            grc.AddLinkByNodeName("osm5429903916", "osm4881717531", usetype: LinkUse.road, comment: "152nd Avenue Northeast012.link1");
            grc.AddLinkByNodeName("osm53091609", "osm5429903916", usetype: LinkUse.road, comment: "152nd Avenue Northeast012.link2");
            grc.AddLinkByNodeName("osm4881717531", "osm6199662240", usetype: LinkUse.road, comment: "152nd Avenue Northeast013.link1");
            grc.AddLinkByNodeName("osm3810659612", "osm6217212445", usetype: LinkUse.road, comment: "Northeast 24th Street031.link1");
            grc.AddLinkByNodeName("osm6217212445", "osm674168908", usetype: LinkUse.road, comment: "Northeast 24th Street032.link1");
            grc.AddLinkByNodeName("osm674168908", "osm6217212446", usetype: LinkUse.road, comment: "Northeast 24th Street033.link1");
            grc.AddLinkByNodeName("osm53048880", "osm3801669680", usetype: LinkUse.road, comment: "148th Avenue Northeast058.link1");
            grc.AddLinkByNodeName("osm6219028624", "osm4272164125", usetype: LinkUse.road, comment: "Northeast 24th Street034.link1");
            grc.AddLinkByNodeName("osm3218977984", "osm6219028625", usetype: LinkUse.road, comment: "secondary_link007.link1");
            grc.AddLinkByNodeName("osm6199821194", "osm6199821195", usetype: LinkUse.road, comment: "156th Avenue Northeast028.link1");
            grc.AddLinkByNodeName("osm6199821193", "osm6199821192", usetype: LinkUse.road, comment: "156th Avenue Northeast029.link1");
            grc.AddLinkByNodeName("osm6199821195", "osm6199821193", usetype: LinkUse.road, comment: "Northeast 24th Street035.link1");
            grc.AddLinkByNodeName("osm708968749", "osm6199821193", usetype: LinkUse.road, comment: "156th Avenue Northeast030.link1");
            grc.AddLinkByNodeName("osm747467327", "osm708968749", usetype: LinkUse.road, comment: "156th Avenue Northeast030.link2");
            grc.AddLinkByNodeName("osm752210738", "osm747467327", usetype: LinkUse.road, comment: "156th Avenue Northeast030.link3");
            grc.AddLinkByNodeName("osm6193024939", "osm752210738", usetype: LinkUse.road, comment: "156th Avenue Northeast030.link4");
            grc.AddLinkByNodeName("osm6199821192", "osm6199821194", usetype: LinkUse.road, comment: "Northeast 24th Street036.link1");
            grc.AddLinkByNodeName("osm6199821196", "osm6199821194", usetype: LinkUse.road, comment: "156th Avenue Northeast031.link1");
            grc.AddLinkByNodeName("osm4272164128", "osm6248078754", usetype: LinkUse.road, comment: "Northeast 24th Street037.link1");
            grc.AddLinkByNodeName("osm752197930", "osm752198068", usetype: LinkUse.road, comment: "Bel-Red Road017.link1");
            grc.AddLinkByNodeName("osm6196861275", "osm752197930", usetype: LinkUse.road, comment: "Bel-Red Road017.link2");
            grc.AddLinkByNodeName("osm6319309348", "osm6196861275", usetype: LinkUse.road, comment: "Bel-Red Road017.link3");
            grc.AddLinkByNodeName("osm2500972696", "osm6319309348", usetype: LinkUse.road, comment: "Bel-Red Road017.link4");
            grc.AddLinkByNodeName("osm6193462232", "osm2500972696", usetype: LinkUse.road, comment: "Bel-Red Road017.link5");
            grc.AddLinkByNodeName("osm321372391", "osm6193462232", usetype: LinkUse.road, comment: "Bel-Red Road017.link6");
            grc.AddLinkByNodeName("osm6193462233", "osm321372391", usetype: LinkUse.road, comment: "Bel-Red Road017.link7");
            grc.AddLinkByNodeName("osm53135569", "osm6193462233", usetype: LinkUse.road, comment: "Bel-Red Road018.link1");
            grc.AddLinkByNodeName("osm3801669596", "osm3801669691", usetype: LinkUse.road, comment: "148th Avenue Northeast059.link1");
            grc.AddLinkByNodeName("osm3801669680", "osm3801669596", usetype: LinkUse.road, comment: "148th Avenue Northeast059.link2");
            grc.AddLinkByNodeName("osm6217633461", "osm346516376", usetype: LinkUse.road, comment: "148th Avenue Northeast060.link1");
            grc.AddLinkByNodeName("osm741922201", "osm6217633461", usetype: LinkUse.road, comment: "148th Avenue Northeast060.link2");
            grc.AddLinkByNodeName("osm3218977981", "osm741922201", usetype: LinkUse.road, comment: "148th Avenue Northeast060.link3");
            grc.AddLinkByNodeName("osm741922215", "osm3801669799", usetype: LinkUse.road, comment: "Northeast 24th Street038.link1");
            grc.AddLinkByNodeName("osm6217212446", "osm741922215", usetype: LinkUse.road, comment: "Northeast 24th Street038.link2");
            grc.regman.SetRegion("default");
        }


    }
}
