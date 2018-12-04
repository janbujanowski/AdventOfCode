﻿using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day12
    {
        static int[] blocks;
        static List<string> lines;
        static Dictionary<int, List<int>> ParentChildrenDict;
        static Dictionary<string, int> ParentMemoryDict;
        static Dictionary<string, bool> ProgramHasParentDict;
        public static string Input
        {
            get
            {
                return @"0 <-> 199, 1774
1 <-> 350, 1328, 1920
2 <-> 477, 984, 1419
3 <-> 1465, 1568
4 <-> 359, 1047, 1215, 1580, 1969
5 <-> 613
6 <-> 49, 617, 1213
7 <-> 1263
8 <-> 410
9 <-> 1224
10 <-> 1157
11 <-> 304, 1168, 1875
12 <-> 868, 891, 1369, 1712
13 <-> 958, 1371
14 <-> 1814
15 <-> 261, 556
16 <-> 830, 1646, 1901, 1933
17 <-> 962, 1778
18 <-> 109, 1229
19 <-> 239, 1070, 1886, 1930
20 <-> 327, 1307, 1801, 1905
21 <-> 943, 1950
22 <-> 1310
23 <-> 659, 917
24 <-> 373
25 <-> 369
26 <-> 947, 1023
27 <-> 338, 1901
28 <-> 1691
29 <-> 132, 1219, 1699, 1962
30 <-> 424, 822, 1419
31 <-> 1444, 1464
32 <-> 702, 1517
33 <-> 1639
34 <-> 909
35 <-> 690, 1655
36 <-> 988, 1149, 1166
37 <-> 649, 1300, 1441, 1699
38 <-> 1848
39 <-> 382
40 <-> 827, 1203, 1510
41 <-> 714, 1056, 1184
42 <-> 1018, 1873
43 <-> 214
44 <-> 670, 957
45 <-> 45
46 <-> 1195
47 <-> 559, 1504
48 <-> 1958
49 <-> 6
50 <-> 50, 1248
51 <-> 1151
52 <-> 52, 521, 1791
53 <-> 304
54 <-> 601
55 <-> 1328
56 <-> 939
57 <-> 1583, 1995
58 <-> 1422, 1694
59 <-> 395, 1233
60 <-> 862, 1811
61 <-> 345, 1694
62 <-> 62, 276
63 <-> 280
64 <-> 199
65 <-> 117, 930
66 <-> 364, 697
67 <-> 1043
68 <-> 287, 504, 1554
69 <-> 498, 706
70 <-> 77, 333, 713, 972, 1299
71 <-> 1643
72 <-> 694
73 <-> 1381
74 <-> 955, 1790
75 <-> 1691, 1743
76 <-> 76, 638, 1429
77 <-> 70
78 <-> 1513
79 <-> 1397, 1716
80 <-> 897
81 <-> 968, 1841
82 <-> 649
83 <-> 522
84 <-> 84, 125, 399, 498
85 <-> 880, 1554, 1888
86 <-> 86
87 <-> 579, 1947
88 <-> 470, 1451, 1750
89 <-> 805, 1434
90 <-> 453
91 <-> 1208
92 <-> 688, 1358, 1746
93 <-> 357, 647
94 <-> 234, 1270, 1520
95 <-> 620, 1454
96 <-> 390, 869, 919
97 <-> 693, 1783
98 <-> 259, 529, 782, 1018
99 <-> 678
100 <-> 1215
101 <-> 459, 887
102 <-> 888, 1135
103 <-> 1006
104 <-> 1375, 1422
105 <-> 1657, 1730
106 <-> 216, 1434
107 <-> 333
108 <-> 468, 1654
109 <-> 18, 1791
110 <-> 372
111 <-> 111, 861, 1383
112 <-> 1359, 1937
113 <-> 414, 736, 1446
114 <-> 426, 1457
115 <-> 1605, 1672
116 <-> 116, 713, 1584, 1602
117 <-> 65
118 <-> 1611, 1897
119 <-> 541, 1569
120 <-> 412, 787
121 <-> 1344
122 <-> 698, 752, 1693
123 <-> 1173, 1576, 1634, 1802
124 <-> 735
125 <-> 84, 1032
126 <-> 126, 225, 332
127 <-> 1350
128 <-> 128, 319, 327, 1582
129 <-> 129, 654, 1260
130 <-> 1080, 1296, 1350
131 <-> 131
132 <-> 29, 856, 1064
133 <-> 659, 1367, 1776
134 <-> 648, 1147, 1450, 1910
135 <-> 411
136 <-> 353, 935, 1590
137 <-> 228
138 <-> 194, 452, 1746, 1794
139 <-> 139, 494, 1635
140 <-> 681
141 <-> 1507
142 <-> 1288
143 <-> 845
144 <-> 1516
145 <-> 502, 1146, 1155, 1809
146 <-> 146, 750
147 <-> 1600
148 <-> 1206
149 <-> 829, 1457
150 <-> 675, 915
151 <-> 651, 1678
152 <-> 888, 1503
153 <-> 498, 960, 1515
154 <-> 1468
155 <-> 751
156 <-> 528, 803, 1655
157 <-> 1486, 1937
158 <-> 590, 1876
159 <-> 159, 185, 1287, 1550, 1588
160 <-> 160, 548
161 <-> 1303, 1364
162 <-> 1855
163 <-> 1181
164 <-> 442
165 <-> 490
166 <-> 1105
167 <-> 1121
168 <-> 760, 1129
169 <-> 747
170 <-> 1890
171 <-> 1644
172 <-> 593, 665
173 <-> 1092, 1869
174 <-> 705
175 <-> 1345, 1999
176 <-> 234, 606
177 <-> 557, 688
178 <-> 373
179 <-> 1376
180 <-> 638
181 <-> 1996
182 <-> 1094, 1206, 1748
183 <-> 931
184 <-> 880
185 <-> 159, 1058, 1704
186 <-> 765, 1178, 1877
187 <-> 732
188 <-> 188
189 <-> 189, 1871
190 <-> 395, 1639
191 <-> 441
192 <-> 192, 1034
193 <-> 494
194 <-> 138, 995, 1308
195 <-> 1024
196 <-> 226, 1632, 1919
197 <-> 786
198 <-> 286, 758, 1852
199 <-> 0, 64, 1646
200 <-> 314
201 <-> 459, 658
202 <-> 321, 492, 599, 1081, 1460
203 <-> 225
204 <-> 331, 462, 600
205 <-> 898
206 <-> 734, 1321
207 <-> 558, 991
208 <-> 397
209 <-> 1145, 1886
210 <-> 1343, 1925
211 <-> 840, 1409
212 <-> 1308
213 <-> 1813
214 <-> 43, 282
215 <-> 1270
216 <-> 106, 836, 1275, 1507
217 <-> 312
218 <-> 290, 386, 639, 1920
219 <-> 784, 1001
220 <-> 220, 322
221 <-> 1681
222 <-> 1616, 1653
223 <-> 436, 1272, 1625
224 <-> 1398, 1696
225 <-> 126, 203, 1182
226 <-> 196, 1655
227 <-> 623
228 <-> 137, 923
229 <-> 253, 1387
230 <-> 1374
231 <-> 389, 1499
232 <-> 442
233 <-> 473, 1406
234 <-> 94, 176
235 <-> 235
236 <-> 607, 838, 1487, 1856
237 <-> 818
238 <-> 387, 628
239 <-> 19
240 <-> 818
241 <-> 1027, 1524
242 <-> 1085, 1971
243 <-> 1942
244 <-> 299, 390, 916
245 <-> 906
246 <-> 246, 534, 763, 1427
247 <-> 531, 1675
248 <-> 336, 1832
249 <-> 1497
250 <-> 1836
251 <-> 1309
252 <-> 581, 1104
253 <-> 229, 877, 1743
254 <-> 254, 621
255 <-> 831, 866, 874
256 <-> 1942
257 <-> 906
258 <-> 1224
259 <-> 98, 316, 419, 718, 1519
260 <-> 1223, 1516, 1547, 1845, 1944
261 <-> 15, 278, 1607, 1808
262 <-> 1112, 1172
263 <-> 424
264 <-> 680
265 <-> 1968
266 <-> 804, 1252
267 <-> 1739
268 <-> 538, 546
269 <-> 1265
270 <-> 270
271 <-> 1150
272 <-> 272
273 <-> 1208, 1537
274 <-> 1427
275 <-> 1349, 1829
276 <-> 62, 906
277 <-> 461, 634, 1887
278 <-> 261, 1224, 1904
279 <-> 303, 537
280 <-> 63, 280, 926, 931
281 <-> 862, 1041, 1119, 1863
282 <-> 214, 488, 644
283 <-> 646, 1124
284 <-> 860, 1759
285 <-> 746
286 <-> 198
287 <-> 68, 1045
288 <-> 332, 1133, 1277, 1628, 1744, 1770, 1934
289 <-> 1578, 1766
290 <-> 218, 439, 1661
291 <-> 596, 1377, 1620
292 <-> 700, 848, 1099
293 <-> 293, 1592, 1938
294 <-> 653, 1948
295 <-> 1505, 1936
296 <-> 625, 925
297 <-> 1105, 1185
298 <-> 298, 544, 1444
299 <-> 244, 933, 1012
300 <-> 300, 1461, 1883
301 <-> 880, 1698
302 <-> 1221
303 <-> 279, 375
304 <-> 11, 53, 967, 1362
305 <-> 777
306 <-> 344
307 <-> 582, 770
308 <-> 792, 1895
309 <-> 539
310 <-> 390, 1482
311 <-> 441, 1294
312 <-> 217, 743
313 <-> 1522
314 <-> 200, 502, 835, 1084, 1134
315 <-> 1970
316 <-> 259
317 <-> 1302, 1437
318 <-> 365
319 <-> 128, 976
320 <-> 1056, 1466, 1778
321 <-> 202
322 <-> 220, 1431
323 <-> 838, 1465, 1895
324 <-> 443
325 <-> 1056
326 <-> 463, 1741, 1761
327 <-> 20, 128, 681, 1797
328 <-> 328, 348
329 <-> 378, 1738
330 <-> 459
331 <-> 204, 331
332 <-> 126, 288
333 <-> 70, 107, 1747
334 <-> 517, 614
335 <-> 1259
336 <-> 248, 550, 1485
337 <-> 337
338 <-> 27, 1212, 1264
339 <-> 430, 963
340 <-> 769
341 <-> 341
342 <-> 593, 718, 895
343 <-> 569
344 <-> 306, 1440, 1650, 1742
345 <-> 61, 1006, 1664
346 <-> 448, 1928
347 <-> 1022, 1052
348 <-> 328, 1232
349 <-> 1232
350 <-> 1, 526, 1086, 1821
351 <-> 584
352 <-> 518, 686, 1324, 1437
353 <-> 136, 936
354 <-> 1470
355 <-> 1173, 1814
356 <-> 698
357 <-> 93
358 <-> 737, 986, 1169
359 <-> 4
360 <-> 363
361 <-> 417, 841
362 <-> 928
363 <-> 360, 1751
364 <-> 66, 364, 1596
365 <-> 318, 1766
366 <-> 366
367 <-> 367
368 <-> 1897
369 <-> 25, 369, 1460
370 <-> 370
371 <-> 1568
372 <-> 110, 582
373 <-> 24, 178, 1924
374 <-> 374
375 <-> 303
376 <-> 1331, 1990
377 <-> 388, 601, 837
378 <-> 329
379 <-> 623
380 <-> 671
381 <-> 938
382 <-> 39, 1458
383 <-> 383, 1490, 1763, 1844
384 <-> 832
385 <-> 745, 1673
386 <-> 218, 779
387 <-> 238
388 <-> 377, 1817
389 <-> 231, 656, 1038, 1960
390 <-> 96, 244, 310, 721, 1094, 1501
391 <-> 438, 819, 1870
392 <-> 697
393 <-> 443, 1275, 1463
394 <-> 480
395 <-> 59, 190, 1117, 1997
396 <-> 595
397 <-> 208, 397, 1727
398 <-> 1153
399 <-> 84
400 <-> 825, 1693
401 <-> 812
402 <-> 1191
403 <-> 1446, 1820
404 <-> 442, 871, 1637
405 <-> 426, 1067
406 <-> 460, 1290
407 <-> 1951
408 <-> 1335, 1391, 1897
409 <-> 984, 1217
410 <-> 8, 1607
411 <-> 135, 411, 454, 1393
412 <-> 120
413 <-> 1208
414 <-> 113
415 <-> 415, 1803
416 <-> 428
417 <-> 361
418 <-> 1129
419 <-> 259
420 <-> 628
421 <-> 1485
422 <-> 1110, 1785
423 <-> 1418
424 <-> 30, 263
425 <-> 1497
426 <-> 114, 405, 780
427 <-> 427
428 <-> 416, 782
429 <-> 429
430 <-> 339, 1513
431 <-> 886, 1408
432 <-> 586, 1725
433 <-> 889, 1753, 1881
434 <-> 1078, 1120
435 <-> 660, 1194, 1662
436 <-> 223, 1332
437 <-> 1487
438 <-> 391
439 <-> 290
440 <-> 1828
441 <-> 191, 311, 1003, 1561, 1702
442 <-> 164, 232, 404
443 <-> 324, 393
444 <-> 1215, 1251
445 <-> 792
446 <-> 1015, 1392
447 <-> 777
448 <-> 346, 1097
449 <-> 1117
450 <-> 1395
451 <-> 1414, 1845
452 <-> 138
453 <-> 90, 453
454 <-> 411
455 <-> 1801
456 <-> 456, 791, 902, 1111
457 <-> 457, 1075, 1384
458 <-> 770, 1600
459 <-> 101, 201, 330, 1108
460 <-> 406, 1529
461 <-> 277, 839, 1552
462 <-> 204
463 <-> 326, 1899
464 <-> 1098
465 <-> 764, 1630, 1779
466 <-> 627
467 <-> 904
468 <-> 108, 1849
469 <-> 469, 603, 780
470 <-> 88, 1276, 1533
471 <-> 1492
472 <-> 472, 1048, 1409, 1518, 1758
473 <-> 233, 1413, 1826
474 <-> 780
475 <-> 1005, 1968
476 <-> 809
477 <-> 2
478 <-> 753
479 <-> 479, 1296, 1615
480 <-> 394, 775, 1623
481 <-> 774, 1604
482 <-> 763
483 <-> 522, 591, 1344
484 <-> 894, 1219
485 <-> 507, 1114, 1250, 1351
486 <-> 1099, 1879
487 <-> 487
488 <-> 282, 1164, 1189
489 <-> 900, 1889
490 <-> 165, 918, 1007
491 <-> 1800
492 <-> 202
493 <-> 615, 899, 1200, 1326
494 <-> 139, 193
495 <-> 704, 1988
496 <-> 496
497 <-> 1149, 1216
498 <-> 69, 84, 153
499 <-> 1125, 1149
500 <-> 642
501 <-> 524, 1176
502 <-> 145, 314
503 <-> 1330, 1626
504 <-> 68, 699
505 <-> 672
506 <-> 1083
507 <-> 485, 1743
508 <-> 520, 1236, 1296
509 <-> 1676
510 <-> 875, 1066
511 <-> 511
512 <-> 512, 1240
513 <-> 705, 812
514 <-> 1758
515 <-> 1165, 1168
516 <-> 811
517 <-> 334, 1132, 1339
518 <-> 352, 1674
519 <-> 824, 1396, 1659
520 <-> 508
521 <-> 52, 915
522 <-> 83, 483, 1637
523 <-> 1317
524 <-> 501
525 <-> 525
526 <-> 350, 850, 930
527 <-> 527, 1338, 1449
528 <-> 156
529 <-> 98
530 <-> 691, 1175, 1505
531 <-> 247, 785, 1389, 1623
532 <-> 1159
533 <-> 1152, 1297
534 <-> 246
535 <-> 1144, 1491, 1622, 1935
536 <-> 708
537 <-> 279, 1656
538 <-> 268, 538, 1756
539 <-> 309, 802
540 <-> 1239
541 <-> 119, 1679, 1741
542 <-> 1204
543 <-> 642, 1926
544 <-> 298
545 <-> 1971
546 <-> 268
547 <-> 1465, 1613, 1614
548 <-> 160
549 <-> 820
550 <-> 336
551 <-> 1733
552 <-> 552, 1563
553 <-> 1654
554 <-> 554, 1641, 1665
555 <-> 555
556 <-> 15
557 <-> 177, 1204
558 <-> 207, 1004
559 <-> 47, 1297
560 <-> 1189, 1709
561 <-> 1013, 1709
562 <-> 762, 912
563 <-> 563
564 <-> 585
565 <-> 1333, 1494
566 <-> 566, 938
567 <-> 894
568 <-> 586, 1397
569 <-> 343, 1572
570 <-> 704, 1220, 1459
571 <-> 1451
572 <-> 651, 846, 909
573 <-> 1881
574 <-> 1866
575 <-> 1379
576 <-> 1060, 1210
577 <-> 1837
578 <-> 1346
579 <-> 87
580 <-> 1509
581 <-> 252, 1548
582 <-> 307, 372
583 <-> 624, 1599, 1753, 1908
584 <-> 351, 774
585 <-> 564, 977
586 <-> 432, 568, 773, 1789
587 <-> 826
588 <-> 1854
589 <-> 719, 845, 1214
590 <-> 158, 1259
591 <-> 483
592 <-> 743, 898
593 <-> 172, 342, 852, 943, 1053
594 <-> 594
595 <-> 396, 928
596 <-> 291, 596
597 <-> 597
598 <-> 1980
599 <-> 202, 1764
600 <-> 204
601 <-> 54, 377, 1340
602 <-> 1718, 1866
603 <-> 469, 789
604 <-> 1006, 1033, 1626
605 <-> 1535
606 <-> 176
607 <-> 236, 911, 1218
608 <-> 1193, 1825
609 <-> 1657
610 <-> 733, 841
611 <-> 747, 1892
612 <-> 1098, 1196, 1267
613 <-> 5, 1372
614 <-> 334, 1492
615 <-> 493, 798
616 <-> 1025, 1940
617 <-> 6, 666, 1155
618 <-> 762, 1621, 1895
619 <-> 1187
620 <-> 95, 1761
621 <-> 254
622 <-> 784, 1476
623 <-> 227, 379, 1081
624 <-> 583
625 <-> 296, 1222, 1882
626 <-> 905
627 <-> 466, 1692
628 <-> 238, 420, 1004, 1412
629 <-> 1532
630 <-> 630
631 <-> 977, 1092, 1458, 1713
632 <-> 777, 1049, 1404
633 <-> 994
634 <-> 277
635 <-> 635
636 <-> 703, 1756
637 <-> 840, 1585
638 <-> 76, 180, 1373
639 <-> 218, 639, 1835
640 <-> 1559
641 <-> 1800
642 <-> 500, 543
643 <-> 1808
644 <-> 282
645 <-> 1253, 1475
646 <-> 283, 646, 864
647 <-> 93, 1508
648 <-> 134, 956, 1762
649 <-> 37, 82
650 <-> 1480, 1916
651 <-> 151, 572, 1357
652 <-> 1261
653 <-> 294, 653
654 <-> 129, 1139, 1176
655 <-> 1251, 1656
656 <-> 389
657 <-> 1604
658 <-> 201, 1208
659 <-> 23, 133, 1868
660 <-> 435
661 <-> 1634
662 <-> 1667, 1701
663 <-> 974
664 <-> 664, 1167
665 <-> 172, 1370
666 <-> 617
667 <-> 1824
668 <-> 952, 1605
669 <-> 1822
670 <-> 44, 670
671 <-> 380, 1145, 1693, 1906
672 <-> 505, 693
673 <-> 1610
674 <-> 1249, 1302
675 <-> 150, 777
676 <-> 1675
677 <-> 910, 1282
678 <-> 99, 1004
679 <-> 679
680 <-> 264, 917, 1137, 1687
681 <-> 140, 327, 746
682 <-> 682
683 <-> 794, 1315
684 <-> 1000, 1342
685 <-> 1111, 1348, 1523, 1932
686 <-> 352
687 <-> 979, 1667
688 <-> 92, 177
689 <-> 937, 1939
690 <-> 35, 1608
691 <-> 530, 691
692 <-> 1871
693 <-> 97, 672
694 <-> 72, 694
695 <-> 1076
696 <-> 1954
697 <-> 66, 392, 1892
698 <-> 122, 356, 698
699 <-> 504, 1470
700 <-> 292, 1407
701 <-> 1231, 1327
702 <-> 32
703 <-> 636, 1083, 1210
704 <-> 495, 570
705 <-> 174, 513, 1332
706 <-> 69, 1088
707 <-> 1036, 1867
708 <-> 536, 805, 1958
709 <-> 709
710 <-> 915, 1578
711 <-> 711, 1478
712 <-> 813, 927
713 <-> 70, 116, 1469, 1539
714 <-> 41
715 <-> 840, 1473, 1562, 1705
716 <-> 716
717 <-> 949, 1864
718 <-> 259, 342, 1557, 1853
719 <-> 589, 781, 802
720 <-> 1125
721 <-> 390, 878
722 <-> 1026
723 <-> 1039, 1467
724 <-> 1535
725 <-> 883
726 <-> 1832, 1917
727 <-> 1245
728 <-> 1291
729 <-> 1203
730 <-> 824
731 <-> 1984
732 <-> 187, 1214
733 <-> 610, 1079, 1198
734 <-> 206, 872, 1479, 1855
735 <-> 124, 1371
736 <-> 113, 736
737 <-> 358, 1426
738 <-> 974, 1024, 1717, 1842
739 <-> 1489
740 <-> 1634
741 <-> 873, 1695
742 <-> 1700
743 <-> 312, 592, 1493
744 <-> 948, 1306, 1400
745 <-> 385, 1029, 1315, 1474
746 <-> 285, 681, 793
747 <-> 169, 611, 814, 1548
748 <-> 748
749 <-> 1134, 1498
750 <-> 146
751 <-> 155, 783, 1856
752 <-> 122, 1417
753 <-> 478, 1505
754 <-> 810, 1742, 1955
755 <-> 1735, 1847
756 <-> 978, 1095
757 <-> 1153, 1730
758 <-> 198, 1476
759 <-> 759
760 <-> 168
761 <-> 1496
762 <-> 562, 618
763 <-> 246, 482, 1258
764 <-> 465
765 <-> 186
766 <-> 1448
767 <-> 893, 896, 1019
768 <-> 1730
769 <-> 340, 1043, 1065
770 <-> 307, 458, 1453
771 <-> 1168
772 <-> 911
773 <-> 586
774 <-> 481, 584, 774, 1148
775 <-> 480, 1485, 1894
776 <-> 926
777 <-> 305, 447, 632, 675
778 <-> 1690
779 <-> 386
780 <-> 426, 469, 474
781 <-> 719, 1543
782 <-> 98, 428, 903
783 <-> 751, 1558
784 <-> 219, 622
785 <-> 531
786 <-> 197, 911, 1312
787 <-> 120, 880
788 <-> 1089, 1487
789 <-> 603, 844, 1681, 1731
790 <-> 790, 1126
791 <-> 456, 1363
792 <-> 308, 445
793 <-> 746
794 <-> 683, 951
795 <-> 1732, 1986
796 <-> 1210, 1878
797 <-> 804
798 <-> 615
799 <-> 1651
800 <-> 851, 860, 1907
801 <-> 1110, 1537, 1773
802 <-> 539, 719
803 <-> 156, 1528
804 <-> 266, 797, 1549
805 <-> 89, 708, 962
806 <-> 1429
807 <-> 1800
808 <-> 873, 1421
809 <-> 476, 809
810 <-> 754
811 <-> 516, 965
812 <-> 401, 513
813 <-> 712, 1023
814 <-> 747
815 <-> 1145
816 <-> 1413
817 <-> 1235
818 <-> 237, 240, 1506
819 <-> 391, 857
820 <-> 549, 1162
821 <-> 1410, 1607
822 <-> 30, 1485
823 <-> 1445, 1454
824 <-> 519, 730, 1824
825 <-> 400, 1381, 1472
826 <-> 587, 1040, 1198, 1618
827 <-> 40
828 <-> 1870
829 <-> 149
830 <-> 16
831 <-> 255
832 <-> 384, 1890, 1913
833 <-> 1529
834 <-> 834
835 <-> 314
836 <-> 216, 1166
837 <-> 377, 988
838 <-> 236, 323
839 <-> 461, 1825
840 <-> 211, 637, 715, 1710
841 <-> 361, 610, 841, 1815
842 <-> 1669
843 <-> 874, 1468
844 <-> 789
845 <-> 143, 589, 1053
846 <-> 572
847 <-> 1285
848 <-> 292
849 <-> 849
850 <-> 526
851 <-> 800, 1368, 1497
852 <-> 593, 1798
853 <-> 1339, 1593, 1749
854 <-> 1445, 1787
855 <-> 1026, 1356
856 <-> 132
857 <-> 819
858 <-> 1511
859 <-> 1191
860 <-> 284, 800, 1619
861 <-> 111, 1266
862 <-> 60, 281
863 <-> 1605
864 <-> 646
865 <-> 873
866 <-> 255, 924
867 <-> 871, 1707
868 <-> 12
869 <-> 96, 1278
870 <-> 1307
871 <-> 404, 867, 1482
872 <-> 734, 1200
873 <-> 741, 808, 865, 873
874 <-> 255, 843, 1201
875 <-> 510, 1325, 1797
876 <-> 1504, 1825
877 <-> 253
878 <-> 721
879 <-> 948, 1291, 1847
880 <-> 85, 184, 301, 787, 1503, 1617
881 <-> 1688
882 <-> 882
883 <-> 725, 1582, 1874
884 <-> 1352
885 <-> 885, 1974
886 <-> 431, 1650
887 <-> 101
888 <-> 102, 152
889 <-> 433, 1016
890 <-> 890
891 <-> 12
892 <-> 1402, 1923
893 <-> 767
894 <-> 484, 567
895 <-> 342, 1123, 1158, 1648
896 <-> 767
897 <-> 80, 986, 1418
898 <-> 205, 592, 1019
899 <-> 493, 1053
900 <-> 489
901 <-> 901
902 <-> 456
903 <-> 782
904 <-> 467, 904, 1924
905 <-> 626, 1881
906 <-> 245, 257, 276
907 <-> 907, 1101, 1826
908 <-> 908, 1230
909 <-> 34, 572, 1186
910 <-> 677, 961
911 <-> 607, 772, 786, 1196, 1405
912 <-> 562
913 <-> 1636
914 <-> 1892, 1963
915 <-> 150, 521, 710
916 <-> 244
917 <-> 23, 680, 1336
918 <-> 490, 1483
919 <-> 96
920 <-> 1880
921 <-> 921
922 <-> 975, 1255
923 <-> 228, 1202, 1452
924 <-> 866
925 <-> 296, 1270
926 <-> 280, 776, 1170, 1788, 1970
927 <-> 712
928 <-> 362, 595, 1103
929 <-> 929
930 <-> 65, 526, 1256, 1500, 1722
931 <-> 183, 280, 1484
932 <-> 1737
933 <-> 299
934 <-> 1387, 1851
935 <-> 136, 935, 1537, 1775
936 <-> 353
937 <-> 689, 1347
938 <-> 381, 566
939 <-> 56, 1762
940 <-> 1559, 1860
941 <-> 1504, 1671, 1723, 1724
942 <-> 1293
943 <-> 21, 593
944 <-> 1335
945 <-> 1650
946 <-> 1556
947 <-> 26
948 <-> 744, 879
949 <-> 717, 1604
950 <-> 1201, 1322
951 <-> 794
952 <-> 668, 1371
953 <-> 1272
954 <-> 954
955 <-> 74
956 <-> 648, 1870
957 <-> 44, 1769
958 <-> 13, 1388, 1660
959 <-> 959
960 <-> 153
961 <-> 910
962 <-> 17, 805
963 <-> 339, 1783
964 <-> 1100
965 <-> 811, 1677
966 <-> 966
967 <-> 304, 1029, 1269, 1910
968 <-> 81, 1091
969 <-> 1379, 1693
970 <-> 1289
971 <-> 971
972 <-> 70
973 <-> 973
974 <-> 663, 738, 1005
975 <-> 922
976 <-> 319
977 <-> 585, 631
978 <-> 756, 1628
979 <-> 687, 979
980 <-> 1151, 1317
981 <-> 1199, 1902
982 <-> 1223
983 <-> 1931
984 <-> 2, 409
985 <-> 985
986 <-> 358, 897, 1564
987 <-> 987, 1644
988 <-> 36, 837
989 <-> 1275
990 <-> 990, 1295
991 <-> 207, 1415
992 <-> 1242, 1397, 1467, 1579
993 <-> 1042, 1767
994 <-> 633, 1595, 1813
995 <-> 194
996 <-> 1096, 1369
997 <-> 1231, 1973
998 <-> 1367
999 <-> 999
1000 <-> 684, 1078
1001 <-> 219
1002 <-> 1442
1003 <-> 441
1004 <-> 558, 628, 678
1005 <-> 475, 974
1006 <-> 103, 345, 604
1007 <-> 490, 1274
1008 <-> 1708, 1819
1009 <-> 1009, 1118
1010 <-> 1223, 1803
1011 <-> 1867
1012 <-> 299, 1923
1013 <-> 561, 1187, 1477, 1926
1014 <-> 1861
1015 <-> 446, 1015, 1858
1016 <-> 889
1017 <-> 1435
1018 <-> 42, 98
1019 <-> 767, 898, 1764
1020 <-> 1020
1021 <-> 1666
1022 <-> 347, 1022, 1310
1023 <-> 26, 813, 1109, 1538, 1988
1024 <-> 195, 738
1025 <-> 616
1026 <-> 722, 855, 1337, 1415
1027 <-> 241, 1309
1028 <-> 1028
1029 <-> 745, 967
1030 <-> 1577, 1689
1031 <-> 1031
1032 <-> 125
1033 <-> 604, 1127, 1194
1034 <-> 192
1035 <-> 1992
1036 <-> 707, 1509
1037 <-> 1347
1038 <-> 389
1039 <-> 723, 1535
1040 <-> 826, 1245, 1918
1041 <-> 281
1042 <-> 993
1043 <-> 67, 769, 1142
1044 <-> 1690
1045 <-> 287
1046 <-> 1561
1047 <-> 4
1048 <-> 472, 1703
1049 <-> 632, 1816
1050 <-> 1157, 1899
1051 <-> 1818
1052 <-> 347, 1904
1053 <-> 593, 845, 899
1054 <-> 1983
1055 <-> 1599
1056 <-> 41, 320, 325, 1567
1057 <-> 1372, 1569
1058 <-> 185
1059 <-> 1112, 1939
1060 <-> 576, 1314, 1557, 1751, 1752
1061 <-> 1285
1062 <-> 1162, 1338, 1739
1063 <-> 1291
1064 <-> 132
1065 <-> 769, 1317
1066 <-> 510
1067 <-> 405, 1452, 1953
1068 <-> 1200
1069 <-> 1069
1070 <-> 19
1071 <-> 1361, 1382
1072 <-> 1307, 1534
1073 <-> 1282
1074 <-> 1323, 1653
1075 <-> 457
1076 <-> 695, 1703
1077 <-> 1180
1078 <-> 434, 1000
1079 <-> 733
1080 <-> 130, 1757
1081 <-> 202, 623
1082 <-> 1082
1083 <-> 506, 703, 1279
1084 <-> 314, 1812
1085 <-> 242
1086 <-> 350
1087 <-> 1524
1088 <-> 706, 1900
1089 <-> 788
1090 <-> 1260
1091 <-> 968, 1522
1092 <-> 173, 631, 1850
1093 <-> 1093, 1390
1094 <-> 182, 390
1095 <-> 756
1096 <-> 996
1097 <-> 448
1098 <-> 464, 612
1099 <-> 292, 486
1100 <-> 964, 1326
1101 <-> 907, 1799
1102 <-> 1927
1103 <-> 928, 1103
1104 <-> 252
1105 <-> 166, 297
1106 <-> 1106, 1896
1107 <-> 1107
1108 <-> 459
1109 <-> 1023
1110 <-> 422, 801
1111 <-> 456, 685
1112 <-> 262, 1059
1113 <-> 1267
1114 <-> 485
1115 <-> 1115, 1827
1116 <-> 1596
1117 <-> 395, 449, 1382
1118 <-> 1009
1119 <-> 281, 1670
1120 <-> 434, 1165
1121 <-> 167, 1121
1122 <-> 1809
1123 <-> 895
1124 <-> 283
1125 <-> 499, 720, 1308
1126 <-> 790, 1526
1127 <-> 1033
1128 <-> 1500
1129 <-> 168, 418, 1642, 1947
1130 <-> 1454
1131 <-> 1683
1132 <-> 517, 1784
1133 <-> 288
1134 <-> 314, 749, 1586
1135 <-> 102
1136 <-> 1136
1137 <-> 680
1138 <-> 1755
1139 <-> 654
1140 <-> 1140
1141 <-> 1141
1142 <-> 1043, 1862
1143 <-> 1550
1144 <-> 535, 1144, 1849
1145 <-> 209, 671, 815, 1268
1146 <-> 145
1147 <-> 134
1148 <-> 774
1149 <-> 36, 497, 499, 1652
1150 <-> 271, 1150
1151 <-> 51, 980, 1651
1152 <-> 533
1153 <-> 398, 757
1154 <-> 1313
1155 <-> 145, 617, 1336, 1721
1156 <-> 1838
1157 <-> 10, 1050
1158 <-> 895
1159 <-> 532, 1708
1160 <-> 1357
1161 <-> 1200, 1999
1162 <-> 820, 1062
1163 <-> 1821
1164 <-> 488, 1572
1165 <-> 515, 1120
1166 <-> 36, 836
1167 <-> 664
1168 <-> 11, 515, 771, 1967
1169 <-> 358
1170 <-> 926
1171 <-> 1666, 1827
1172 <-> 262, 1439
1173 <-> 123, 355, 1341
1174 <-> 1204, 1525
1175 <-> 530
1176 <-> 501, 654
1177 <-> 1311, 1796
1178 <-> 186, 1536, 1551, 1853
1179 <-> 1822, 1947
1180 <-> 1077, 1264
1181 <-> 163, 1181
1182 <-> 225
1183 <-> 1237, 1715, 1798
1184 <-> 41
1185 <-> 297, 1185
1186 <-> 909
1187 <-> 619, 1013
1188 <-> 1698
1189 <-> 488, 560
1190 <-> 1834, 1933
1191 <-> 402, 859, 1191
1192 <-> 1839
1193 <-> 608, 1438
1194 <-> 435, 1033, 1754
1195 <-> 46, 1828
1196 <-> 612, 911, 1975
1197 <-> 1503, 1854
1198 <-> 733, 826
1199 <-> 981
1200 <-> 493, 872, 1068, 1161
1201 <-> 874, 950
1202 <-> 923
1203 <-> 40, 729, 1719
1204 <-> 542, 557, 1174
1205 <-> 1332
1206 <-> 148, 182
1207 <-> 1207
1208 <-> 91, 273, 413, 658, 1234
1209 <-> 1995
1210 <-> 576, 703, 796
1211 <-> 1227, 1891
1212 <-> 338, 1362
1213 <-> 6
1214 <-> 589, 732
1215 <-> 4, 100, 444, 1842
1216 <-> 497, 1745
1217 <-> 409, 1354
1218 <-> 607
1219 <-> 29, 484, 1712
1220 <-> 570
1221 <-> 302, 1429
1222 <-> 625, 1412
1223 <-> 260, 982, 1010, 1591
1224 <-> 9, 258, 278, 1506, 1893
1225 <-> 1906
1226 <-> 1226
1227 <-> 1211
1228 <-> 1773
1229 <-> 18
1230 <-> 908
1231 <-> 701, 997
1232 <-> 348, 349
1233 <-> 59
1234 <-> 1208
1235 <-> 817, 1994
1236 <-> 508
1237 <-> 1183
1238 <-> 1529
1239 <-> 540, 1524, 1552
1240 <-> 512
1241 <-> 1241
1242 <-> 992, 1685
1243 <-> 1934
1244 <-> 1574, 1839
1245 <-> 727, 1040
1246 <-> 1380
1247 <-> 1506, 1923
1248 <-> 50, 1610
1249 <-> 674
1250 <-> 485
1251 <-> 444, 655, 1718
1252 <-> 266, 1862
1253 <-> 645, 1709
1254 <-> 1254
1255 <-> 922, 1255, 1341
1256 <-> 930, 1346
1257 <-> 1465, 1844
1258 <-> 763
1259 <-> 335, 590, 1259
1260 <-> 129, 1090
1261 <-> 652, 1261, 1838
1262 <-> 1262, 1912
1263 <-> 7, 1438, 1554
1264 <-> 338, 1180
1265 <-> 269, 1265
1266 <-> 861, 1281, 1423
1267 <-> 612, 1113, 1289
1268 <-> 1145
1269 <-> 967
1270 <-> 94, 215, 925, 1860
1271 <-> 1376
1272 <-> 223, 953
1273 <-> 1301
1274 <-> 1007, 1860
1275 <-> 216, 393, 989, 1275
1276 <-> 470
1277 <-> 288
1278 <-> 869
1279 <-> 1083, 1755
1280 <-> 1588
1281 <-> 1266
1282 <-> 677, 1073, 1575, 1625
1283 <-> 1571
1284 <-> 1828
1285 <-> 847, 1061, 1641
1286 <-> 1494, 1649, 1889
1287 <-> 159
1288 <-> 142, 1288
1289 <-> 970, 1267, 1668
1290 <-> 406
1291 <-> 728, 879, 1063, 1885
1292 <-> 1407
1293 <-> 942, 1318, 1459
1294 <-> 311, 1754
1295 <-> 990, 1512
1296 <-> 130, 479, 508
1297 <-> 533, 559
1298 <-> 1839
1299 <-> 70
1300 <-> 37, 1886, 1998
1301 <-> 1273, 1340
1302 <-> 317, 674, 1485
1303 <-> 161, 1624
1304 <-> 1304
1305 <-> 1410
1306 <-> 744
1307 <-> 20, 870, 1072
1308 <-> 194, 212, 1125
1309 <-> 251, 1027
1310 <-> 22, 1022, 1777
1311 <-> 1177
1312 <-> 786
1313 <-> 1154, 1706
1314 <-> 1060
1315 <-> 683, 745
1316 <-> 1793, 1898
1317 <-> 523, 980, 1065, 1787
1318 <-> 1293
1319 <-> 1319
1320 <-> 1320
1321 <-> 206
1322 <-> 950, 1957
1323 <-> 1074, 1823
1324 <-> 352
1325 <-> 875, 1740
1326 <-> 493, 1100
1327 <-> 701, 1633
1328 <-> 1, 55
1329 <-> 1633
1330 <-> 503, 1687, 1782
1331 <-> 376, 1531, 1766
1332 <-> 436, 705, 1205
1333 <-> 565
1334 <-> 1805
1335 <-> 408, 944
1336 <-> 917, 1155
1337 <-> 1026
1338 <-> 527, 1062
1339 <-> 517, 853
1340 <-> 601, 1301, 1708
1341 <-> 1173, 1255
1342 <-> 684
1343 <-> 210
1344 <-> 121, 483
1345 <-> 175
1346 <-> 578, 1256
1347 <-> 937, 1037, 1735
1348 <-> 685
1349 <-> 275, 1594
1350 <-> 127, 130
1351 <-> 485
1352 <-> 884, 1352
1353 <-> 1604, 1800
1354 <-> 1217
1355 <-> 1355, 1985
1356 <-> 855, 1840
1357 <-> 651, 1160, 1388
1358 <-> 92
1359 <-> 112
1360 <-> 1455
1361 <-> 1071, 1909
1362 <-> 304, 1212
1363 <-> 791
1364 <-> 161, 1426
1365 <-> 1365
1366 <-> 1366, 1433
1367 <-> 133, 998
1368 <-> 851
1369 <-> 12, 996, 1425
1370 <-> 665
1371 <-> 13, 735, 952, 1371, 1857
1372 <-> 613, 1057
1373 <-> 638, 1511
1374 <-> 230, 1593
1375 <-> 104
1376 <-> 179, 1271, 1639
1377 <-> 291
1378 <-> 1919
1379 <-> 575, 969
1380 <-> 1246, 1501, 1903
1381 <-> 73, 825, 1922
1382 <-> 1071, 1117, 1541, 1810
1383 <-> 111
1384 <-> 457
1385 <-> 1878, 1966
1386 <-> 1396
1387 <-> 229, 934, 1853
1388 <-> 958, 1357, 1424
1389 <-> 531
1390 <-> 1093, 1603
1391 <-> 408
1392 <-> 446
1393 <-> 411
1394 <-> 1866
1395 <-> 450, 1851
1396 <-> 519, 1386
1397 <-> 79, 568, 992
1398 <-> 224
1399 <-> 1443, 1799, 1915
1400 <-> 744
1401 <-> 1685
1402 <-> 892
1403 <-> 1714
1404 <-> 632
1405 <-> 911, 1532
1406 <-> 233, 1606
1407 <-> 700, 1292
1408 <-> 431, 1408, 1416
1409 <-> 211, 472
1410 <-> 821, 1305
1411 <-> 1653, 1993
1412 <-> 628, 1222
1413 <-> 473, 816
1414 <-> 451
1415 <-> 991, 1026
1416 <-> 1408
1417 <-> 752
1418 <-> 423, 897
1419 <-> 2, 30
1420 <-> 1420
1421 <-> 808
1422 <-> 58, 104
1423 <-> 1266
1424 <-> 1388
1425 <-> 1369
1426 <-> 737, 1364, 1847, 1913
1427 <-> 246, 274
1428 <-> 1964
1429 <-> 76, 806, 1221
1430 <-> 1430
1431 <-> 322
1432 <-> 1719
1433 <-> 1366, 1988
1434 <-> 89, 106
1435 <-> 1017, 1730
1436 <-> 1997
1437 <-> 317, 352
1438 <-> 1193, 1263
1439 <-> 1172
1440 <-> 344
1441 <-> 37
1442 <-> 1002, 1860
1443 <-> 1399
1444 <-> 31, 298
1445 <-> 823, 854
1446 <-> 113, 403
1447 <-> 1508, 1720
1448 <-> 766, 1791
1449 <-> 527
1450 <-> 134
1451 <-> 88, 571
1452 <-> 923, 1067
1453 <-> 770
1454 <-> 95, 823, 1130, 1454
1455 <-> 1360, 1533
1456 <-> 1456, 1489, 1529
1457 <-> 114, 149, 1956
1458 <-> 382, 631, 1458
1459 <-> 570, 1293
1460 <-> 202, 369
1461 <-> 300
1462 <-> 1636
1463 <-> 393, 1659, 1939
1464 <-> 31
1465 <-> 3, 323, 547, 1257, 1732
1466 <-> 320
1467 <-> 723, 992, 1706
1468 <-> 154, 843
1469 <-> 713
1470 <-> 354, 699
1471 <-> 1471
1472 <-> 825
1473 <-> 715
1474 <-> 745
1475 <-> 645
1476 <-> 622, 758
1477 <-> 1013, 1645, 1669
1478 <-> 711
1479 <-> 734
1480 <-> 650
1481 <-> 1481
1482 <-> 310, 871
1483 <-> 918, 1504
1484 <-> 931
1485 <-> 336, 421, 775, 822, 1302
1486 <-> 157, 1631
1487 <-> 236, 437, 788, 1980
1488 <-> 1560
1489 <-> 739, 1456
1490 <-> 383
1491 <-> 535
1492 <-> 471, 614
1493 <-> 743
1494 <-> 565, 1286
1495 <-> 1627
1496 <-> 761, 1496
1497 <-> 249, 425, 851
1498 <-> 749
1499 <-> 231
1500 <-> 930, 1128
1501 <-> 390, 1380
1502 <-> 1713
1503 <-> 152, 880, 1197
1504 <-> 47, 876, 941, 1483, 1945
1505 <-> 295, 530, 753
1506 <-> 818, 1224, 1247
1507 <-> 141, 216, 1565, 1726
1508 <-> 647, 1447, 1521, 1590
1509 <-> 580, 1036, 1605, 1609
1510 <-> 40, 1885
1511 <-> 858, 1373
1512 <-> 1295
1513 <-> 78, 430
1514 <-> 1772
1515 <-> 153
1516 <-> 144, 260, 1818
1517 <-> 32, 1616, 1806
1518 <-> 472
1519 <-> 259
1520 <-> 94, 1542
1521 <-> 1508
1522 <-> 313, 1091, 1631
1523 <-> 685
1524 <-> 241, 1087, 1239
1525 <-> 1174
1526 <-> 1126
1527 <-> 1835
1528 <-> 803
1529 <-> 460, 833, 1238, 1456
1530 <-> 1784
1531 <-> 1331
1532 <-> 629, 1405
1533 <-> 470, 1455, 1533, 1796
1534 <-> 1072
1535 <-> 605, 724, 1039
1536 <-> 1178
1537 <-> 273, 801, 935
1538 <-> 1023, 1734
1539 <-> 713
1540 <-> 1748
1541 <-> 1382, 1683
1542 <-> 1520
1543 <-> 781
1544 <-> 1631
1545 <-> 1910
1546 <-> 1942
1547 <-> 260
1548 <-> 581, 747
1549 <-> 804
1550 <-> 159, 1143
1551 <-> 1178
1552 <-> 461, 1239, 1846
1553 <-> 1553, 1982
1554 <-> 68, 85, 1263, 1597
1555 <-> 1713, 1931
1556 <-> 946, 1556
1557 <-> 718, 1060
1558 <-> 783
1559 <-> 640, 940
1560 <-> 1488, 1806, 1898, 1949
1561 <-> 441, 1046
1562 <-> 715, 1889
1563 <-> 552
1564 <-> 986
1565 <-> 1507, 1689
1566 <-> 1570
1567 <-> 1056
1568 <-> 3, 371
1569 <-> 119, 1057, 1852
1570 <-> 1566, 1570
1571 <-> 1283, 1736
1572 <-> 569, 1164, 1995
1573 <-> 1573, 1784, 1987
1574 <-> 1244, 1574
1575 <-> 1282, 1575, 1866
1576 <-> 123
1577 <-> 1030
1578 <-> 289, 710
1579 <-> 992, 1684
1580 <-> 4
1581 <-> 1581
1582 <-> 128, 883
1583 <-> 57
1584 <-> 116
1585 <-> 637
1586 <-> 1134
1587 <-> 1587
1588 <-> 159, 1280
1589 <-> 1915
1590 <-> 136, 1508
1591 <-> 1223
1592 <-> 293, 1891
1593 <-> 853, 1374
1594 <-> 1349, 1886
1595 <-> 994, 1595
1596 <-> 364, 1116
1597 <-> 1554
1598 <-> 1729
1599 <-> 583, 1055
1600 <-> 147, 458, 1600
1601 <-> 1894
1602 <-> 116
1603 <-> 1390
1604 <-> 481, 657, 949, 1353, 1983
1605 <-> 115, 668, 863, 1509
1606 <-> 1406
1607 <-> 261, 410, 821
1608 <-> 690
1609 <-> 1509
1610 <-> 673, 1248
1611 <-> 118, 1788
1612 <-> 1854
1613 <-> 547
1614 <-> 547, 1807
1615 <-> 479
1616 <-> 222, 1517
1617 <-> 880, 1989
1618 <-> 826
1619 <-> 860, 1807
1620 <-> 291
1621 <-> 618, 1957
1622 <-> 535
1623 <-> 480, 531
1624 <-> 1303
1625 <-> 223, 1282
1626 <-> 503, 604
1627 <-> 1495, 1933
1628 <-> 288, 978
1629 <-> 1629
1630 <-> 465, 1872
1631 <-> 1486, 1522, 1544
1632 <-> 196
1633 <-> 1327, 1329
1634 <-> 123, 661, 740
1635 <-> 139
1636 <-> 913, 1462, 1752
1637 <-> 404, 522
1638 <-> 1779, 1813
1639 <-> 33, 190, 1376, 1639
1640 <-> 1816
1641 <-> 554, 1285
1642 <-> 1129
1643 <-> 71, 1844
1644 <-> 171, 987
1645 <-> 1477
1646 <-> 16, 199
1647 <-> 1702
1648 <-> 895
1649 <-> 1286
1650 <-> 344, 886, 945
1651 <-> 799, 1151
1652 <-> 1149, 1961, 1984
1653 <-> 222, 1074, 1411
1654 <-> 108, 553
1655 <-> 35, 156, 226, 1992
1656 <-> 537, 655
1657 <-> 105, 609
1658 <-> 1658
1659 <-> 519, 1463
1660 <-> 958
1661 <-> 290, 1929
1662 <-> 435
1663 <-> 1855
1664 <-> 345
1665 <-> 554
1666 <-> 1021, 1171
1667 <-> 662, 687
1668 <-> 1289
1669 <-> 842, 1477, 1795, 1975
1670 <-> 1119, 1921
1671 <-> 941
1672 <-> 115
1673 <-> 385
1674 <-> 518
1675 <-> 247, 676
1676 <-> 509, 1987
1677 <-> 965, 1677
1678 <-> 151, 1692
1679 <-> 541
1680 <-> 1680
1681 <-> 221, 789
1682 <-> 1736, 1767, 1947
1683 <-> 1131, 1541
1684 <-> 1579
1685 <-> 1242, 1401
1686 <-> 1736
1687 <-> 680, 1330
1688 <-> 881, 1829
1689 <-> 1030, 1565
1690 <-> 778, 1044, 1900
1691 <-> 28, 75
1692 <-> 627, 1678
1693 <-> 122, 400, 671, 969
1694 <-> 58, 61
1695 <-> 741
1696 <-> 224, 1958
1697 <-> 1935
1698 <-> 301, 1188
1699 <-> 29, 37
1700 <-> 742, 1883
1701 <-> 662
1702 <-> 441, 1647
1703 <-> 1048, 1076
1704 <-> 185
1705 <-> 715
1706 <-> 1313, 1467
1707 <-> 867
1708 <-> 1008, 1159, 1340
1709 <-> 560, 561, 1253, 1976
1710 <-> 840
1711 <-> 1711
1712 <-> 12, 1219
1713 <-> 631, 1502, 1555
1714 <-> 1403, 1714, 1902
1715 <-> 1183
1716 <-> 79
1717 <-> 738
1718 <-> 602, 1251
1719 <-> 1203, 1432
1720 <-> 1447
1721 <-> 1155
1722 <-> 930
1723 <-> 941
1724 <-> 941
1725 <-> 432
1726 <-> 1507
1727 <-> 397
1728 <-> 1728, 1937
1729 <-> 1598, 1913
1730 <-> 105, 757, 768, 1435, 1730
1731 <-> 789
1732 <-> 795, 1465
1733 <-> 551, 1765, 1835
1734 <-> 1538
1735 <-> 755, 1347
1736 <-> 1571, 1682, 1686
1737 <-> 932, 1795
1738 <-> 329, 1738
1739 <-> 267, 1062, 1848
1740 <-> 1325
1741 <-> 326, 541, 1952
1742 <-> 344, 754
1743 <-> 75, 253, 507
1744 <-> 288
1745 <-> 1216
1746 <-> 92, 138
1747 <-> 333
1748 <-> 182, 1540
1749 <-> 853
1750 <-> 88
1751 <-> 363, 1060
1752 <-> 1060, 1636
1753 <-> 433, 583, 1873
1754 <-> 1194, 1294
1755 <-> 1138, 1279
1756 <-> 538, 636
1757 <-> 1080
1758 <-> 472, 514
1759 <-> 284
1760 <-> 1760
1761 <-> 326, 620
1762 <-> 648, 939, 1989
1763 <-> 383
1764 <-> 599, 1019, 1941
1765 <-> 1733
1766 <-> 289, 365, 1331
1767 <-> 993, 1682, 1767
1768 <-> 1768, 1859
1769 <-> 957
1770 <-> 288
1771 <-> 1875
1772 <-> 1514, 1772
1773 <-> 801, 1228
1774 <-> 0
1775 <-> 935
1776 <-> 133
1777 <-> 1310
1778 <-> 17, 320
1779 <-> 465, 1638
1780 <-> 1906
1781 <-> 1969
1782 <-> 1330
1783 <-> 97, 963, 1960, 1983
1784 <-> 1132, 1530, 1573
1785 <-> 422
1786 <-> 1786
1787 <-> 854, 1317
1788 <-> 926, 1611
1789 <-> 586, 1829
1790 <-> 74, 1790
1791 <-> 52, 109, 1448
1792 <-> 1860
1793 <-> 1316, 1981
1794 <-> 138
1795 <-> 1669, 1737, 1861
1796 <-> 1177, 1533
1797 <-> 327, 875
1798 <-> 852, 1183
1799 <-> 1101, 1399, 1964
1800 <-> 491, 641, 807, 1353
1801 <-> 20, 455
1802 <-> 123
1803 <-> 415, 1010
1804 <-> 1804
1805 <-> 1334, 1926
1806 <-> 1517, 1560
1807 <-> 1614, 1619
1808 <-> 261, 643
1809 <-> 145, 1122
1810 <-> 1382
1811 <-> 60
1812 <-> 1084
1813 <-> 213, 994, 1638
1814 <-> 14, 355
1815 <-> 841, 1996
1816 <-> 1049, 1640
1817 <-> 388
1818 <-> 1051, 1516
1819 <-> 1008
1820 <-> 403
1821 <-> 350, 1163
1822 <-> 669, 1179, 1927
1823 <-> 1323
1824 <-> 667, 824, 1879
1825 <-> 608, 839, 876, 1965
1826 <-> 473, 907
1827 <-> 1115, 1171
1828 <-> 440, 1195, 1284, 1913
1829 <-> 275, 1688, 1789
1830 <-> 1830
1831 <-> 1831
1832 <-> 248, 726
1833 <-> 1833
1834 <-> 1190
1835 <-> 639, 1527, 1733
1836 <-> 250, 1836
1837 <-> 577, 1970
1838 <-> 1156, 1261
1839 <-> 1192, 1244, 1298
1840 <-> 1356
1841 <-> 81
1842 <-> 738, 1215
1843 <-> 1843
1844 <-> 383, 1257, 1643
1845 <-> 260, 451
1846 <-> 1552
1847 <-> 755, 879, 1426
1848 <-> 38, 1739
1849 <-> 468, 1144
1850 <-> 1092
1851 <-> 934, 1395
1852 <-> 198, 1569
1853 <-> 718, 1178, 1387
1854 <-> 588, 1197, 1612
1855 <-> 162, 734, 1663
1856 <-> 236, 751
1857 <-> 1371
1858 <-> 1015
1859 <-> 1768
1860 <-> 940, 1270, 1274, 1442, 1792
1861 <-> 1014, 1795
1862 <-> 1142, 1252
1863 <-> 281
1864 <-> 717
1865 <-> 1865
1866 <-> 574, 602, 1394, 1575
1867 <-> 707, 1011
1868 <-> 659, 1868
1869 <-> 173, 1991
1870 <-> 391, 828, 956, 1880
1871 <-> 189, 692
1872 <-> 1630
1873 <-> 42, 1753
1874 <-> 883
1875 <-> 11, 1771
1876 <-> 158
1877 <-> 186
1878 <-> 796, 1385
1879 <-> 486, 1824
1880 <-> 920, 1870
1881 <-> 433, 573, 905
1882 <-> 625, 1954
1883 <-> 300, 1700
1884 <-> 1884
1885 <-> 1291, 1510
1886 <-> 19, 209, 1300, 1594
1887 <-> 277
1888 <-> 85
1889 <-> 489, 1286, 1562
1890 <-> 170, 832
1891 <-> 1211, 1592, 1973
1892 <-> 611, 697, 914
1893 <-> 1224
1894 <-> 775, 1601
1895 <-> 308, 323, 618
1896 <-> 1106
1897 <-> 118, 368, 408
1898 <-> 1316, 1560, 1944
1899 <-> 463, 1050
1900 <-> 1088, 1690, 1951
1901 <-> 16, 27
1902 <-> 981, 1714
1903 <-> 1380
1904 <-> 278, 1052
1905 <-> 20
1906 <-> 671, 1225, 1780
1907 <-> 800
1908 <-> 583
1909 <-> 1361, 1940
1910 <-> 134, 967, 1545
1911 <-> 1973
1912 <-> 1262
1913 <-> 832, 1426, 1729, 1828
1914 <-> 1914
1915 <-> 1399, 1589
1916 <-> 650, 1916
1917 <-> 726, 1917
1918 <-> 1040
1919 <-> 196, 1378, 1919
1920 <-> 1, 218
1921 <-> 1670, 1952
1922 <-> 1381
1923 <-> 892, 1012, 1247
1924 <-> 373, 904
1925 <-> 210, 1935
1926 <-> 543, 1013, 1805
1927 <-> 1102, 1822
1928 <-> 346, 1928
1929 <-> 1661
1930 <-> 19
1931 <-> 983, 1555
1932 <-> 685
1933 <-> 16, 1190, 1627, 1933
1934 <-> 288, 1243
1935 <-> 535, 1697, 1925
1936 <-> 295
1937 <-> 112, 157, 1728
1938 <-> 293
1939 <-> 689, 1059, 1463
1940 <-> 616, 1909
1941 <-> 1764
1942 <-> 243, 256, 1546
1943 <-> 1950
1944 <-> 260, 1898
1945 <-> 1504
1946 <-> 1946
1947 <-> 87, 1129, 1179, 1682
1948 <-> 294
1949 <-> 1560
1950 <-> 21, 1943
1951 <-> 407, 1900
1952 <-> 1741, 1921
1953 <-> 1067
1954 <-> 696, 1882
1955 <-> 754
1956 <-> 1457
1957 <-> 1322, 1621
1958 <-> 48, 708, 1696
1959 <-> 1959
1960 <-> 389, 1783
1961 <-> 1652
1962 <-> 29
1963 <-> 914
1964 <-> 1428, 1799
1965 <-> 1825
1966 <-> 1385
1967 <-> 1168
1968 <-> 265, 475
1969 <-> 4, 1781
1970 <-> 315, 926, 1837
1971 <-> 242, 545, 1971
1972 <-> 1972
1973 <-> 997, 1891, 1911
1974 <-> 885
1975 <-> 1196, 1669
1976 <-> 1709
1977 <-> 1977
1978 <-> 1978
1979 <-> 1979
1980 <-> 598, 1487
1981 <-> 1793
1982 <-> 1553
1983 <-> 1054, 1604, 1783
1984 <-> 731, 1652
1985 <-> 1355
1986 <-> 795
1987 <-> 1573, 1676
1988 <-> 495, 1023, 1433
1989 <-> 1617, 1762
1990 <-> 376
1991 <-> 1869
1992 <-> 1035, 1655
1993 <-> 1411
1994 <-> 1235, 1994
1995 <-> 57, 1209, 1572
1996 <-> 181, 1815
1997 <-> 395, 1436
1998 <-> 1300
1999 <-> 175, 1161";
            }
        }
        private static void Init()
        {
            lines = new List<string>();
            string[] separators = new string[] { "\r\n" };
            lines = Input.Split(separators, StringSplitOptions.None).ToList();
            ParentChildrenDict = new Dictionary<int, List<int>>();

            string[] separatorLine = new string[] { "<->" };
            foreach (var line in lines)
            {
                var args = line.Split(separatorLine, StringSplitOptions.None);
                int key = Int32.Parse(args[0]);
                var argsnodes = args[1].Split(',');
                var nodes = new List<int>() { };
                foreach (var numb in argsnodes)
                {
                    nodes.Add(Convert.ToInt32(numb));
                }
                ParentChildrenDict.Add(key, nodes);
            }
        }
        public new static object StarOne()
        {
            Init();
            List<int> progsInRelationWithNumber = CheckRelations(0);
            return progsInRelationWithNumber.Count;
        }

        private static List<int> CheckRelations(int v)
        {
            List<int> progsChecked = new List<int> { v };
            var opr = new List<int>(ParentChildrenDict[v]);
            ParentChildrenDict[v] = new List<int>();
            foreach (var numba in opr)
            {
                if (!progsChecked.Contains(numba))
                {
                    progsChecked.Add(numba);
                    var relatedNest = CheckRelations(numba);
                    foreach (var numba2 in relatedNest)
                    {
                        if (!progsChecked.Contains(numba2))
                        {
                            progsChecked.Add(numba2);
                        }
                    }
                }
            }
            return progsChecked;
        }
        public new static object StarTwo()
        {
            Init();
            var size = ParentChildrenDict.Count;
            List<List<int>> groupSizes = new List<List<int>>();
            for (int i = 0; i < size; i++)
            {
                Init();
                var newList = CheckRelations(i);
                newList.Sort();
                var add = true;
                foreach (var item in groupSizes)
                {
                    if (Enumerable.SequenceEqual(newList,item))
                    {
                        add = false;
                        break;
                    }
                }
                if (add)
                {
                    groupSizes.Add(newList);
                }
            }

            return groupSizes.Count();
        }
    }
}
