﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day8
    {
        private static List<string> lines;
        private static Dictionary<string, string> operationConditonDict;
        private static Dictionary<string, int> registers;
        public static string Input
        {
            get
            {
                return @"t inc 245 if xq != 0
hi inc 119 if gf >= -5
w dec 529 if s == 0
p inc 19 if fi > -2
kgp dec 133 if kbm > -6
pl inc -407 if pvo != 0
gf dec 348 if gf <= 7
e inc -277 if pdg == 0
pdg dec 480 if p == 19
pl dec 932 if kgp <= -127
gf inc 711 if xq <= 7
e dec -359 if esj < -2
l dec -543 if jcf <= 9
bh inc 958 if t > -10
h dec 87 if hsv == -6
e inc 290 if esj >= -4
e dec -378 if fi >= -2
fi inc 722 if esj == 0
w dec -350 if bh != 948
e dec 974 if fi > 716
hsv inc 852 if xq >= -6
gf dec -548 if bh >= 958
fi dec -234 if fi > 722
fi dec 983 if gf != 919
esj dec -155 if kgp <= -125
p inc -411 if gf <= 913
kgp dec 304 if kgp == -133
hi inc -488 if e == -583
pvo inc -524 if f > -1
gf inc 654 if s == 0
fw dec -872 if pdg > -478
kgp inc 627 if kbm != 0
u dec 294 if fw >= 8
esj dec -979 if esj <= 160
pl dec -194 if fw <= 4
ls dec 74 if fw <= 5
pvo inc 413 if f <= 6
ls inc 917 if bh != 951
jlg inc 866 if h == 0
hi inc -598 if gf <= 1567
p dec 138 if l > 549
hsv inc -530 if pl != -738
bh inc 160 if f <= 0
s dec -619 if p >= -396
p dec 243 if hi != -971
gf dec 614 if pdg < -470
s dec 804 if f == -2
xq inc 10 if esj != 1144
p inc 860 if gf > 943
pl dec 564 if fi >= -267
ls inc 736 if kbm >= -5
hsv dec 774 if gf != 946
f inc 301 if p == 232
w dec -553 if hi != -965
kbm inc -875 if pvo != -115
pvo dec 376 if esj > 1134
kbm dec -293 if u != 0
pdg dec -274 if pvo <= -111
xq dec -385 if f > 0
gf dec 202 if pl < -1293
s inc 782 if pvo <= -104
p dec -652 if w == 374
w inc 61 if bh < 1122
ls inc -978 if ls != 1570
p inc 504 if esj < 1137
xq inc 111 if fw == -10
h dec -183 if h > -3
fi dec 990 if fw < 1
kbm inc -534 if s == 1401
esj inc -619 if hsv > 70
p inc 704 if kgp != -437
hi inc 637 if esj > 511
hsv dec 653 if h > 179
s dec -866 if kgp < -431
pdg dec -769 if bh > 1111
s dec -796 if p >= 1390
s dec 137 if jcf == 0
w inc -818 if p <= 1381
l dec -601 if h >= 177
pdg dec 50 if f == 0
ls inc -607 if f <= 4
gf inc 894 if l >= 1136
kbm dec -775 if u < 7
pdg inc 151 if pvo != -109
hsv inc 366 if jlg != 861
t inc 960 if f > -7
pdg inc -397 if kbm < -632
xq inc -71 if fi > -1258
ls inc 211 if hsv > -208
pl dec 442 if fi == -1251
kbm inc -920 if pdg > 263
kgp dec 627 if t >= 956
kgp inc 447 if u < -6
s inc 815 if f != 3
w dec -201 if jlg < 876
s inc 630 if t > 967
h dec 4 if l != 1144
gf inc 346 if l < 1146
jcf dec -72 if pdg == 267
pl inc 804 if p <= 1384
pl dec -48 if e == -583
p inc 622 if s == 2945
fi inc -513 if ls != -14
pl dec -802 if fw > -2
bh dec -438 if f <= 6
fi dec -968 if gf > 1987
pdg inc -973 if xq <= -57
kbm inc -482 if pvo != -111
s dec -228 if ls >= -8
e inc 850 if hsv == -209
gf inc -540 if u != 9
hi inc 176 if kbm > -1555
p dec -868 if e > 265
s dec 141 if kgp > -1063
e inc 438 if w == -178
hsv inc 982 if fi <= -796
hsv inc 67 if hsv == 773
hi inc -633 if e == 267
hi dec -361 if kgp <= -1070
ls dec -474 if pdg < -704
kgp dec 650 if fw <= 9
pdg dec 355 if h == 183
e inc -298 if kgp == -1714
hsv dec -112 if f <= 0
p dec -491 if jcf == 72
pvo inc 749 if pvo >= -116
bh inc 165 if s <= 3178
p dec -598 if jlg < 872
jlg inc -72 if f >= -5
t inc 416 if l < 1146
w dec 343 if ls < 468
ls inc 405 if h >= 179
pl inc -984 if u >= 5
pvo inc 440 if jlg >= 785
fi inc -729 if jlg != 784
kgp inc 351 if s < 3182
bh inc 181 if h >= 189
pvo dec -445 if pl <= -90
pdg dec 658 if t < 1385
bh inc 64 if xq != -67
hi inc -88 if bh >= 1778
fi dec 413 if jlg < 795
ls dec -602 if fw > -9
h inc 228 if jlg <= 791
e inc -190 if e == -31
jcf inc -600 if xq == -61
ls dec -549 if pdg != -1723
u inc 348 if u != -7
hi dec 967 if h < 193
s inc -323 if l >= 1149
xq inc -252 if hi >= -1848
f inc 80 if t <= 1383
bh inc -890 if jcf > -520
pdg inc -267 if kgp < -1369
jcf dec 569 if gf <= 1453
h inc -632 if hsv == 952
jcf dec 917 if s == 3173
fw inc -403 if e == -221
kbm inc -763 if t >= 1376
fw dec 821 if e <= -219
esj inc 630 if xq != -313
e inc -982 if t <= 1382
kgp dec -802 if t == 1372
t inc 511 if fw < -1215
e dec 750 if w >= -178
bh dec 549 if hsv == 952
h dec 881 if kbm == -2317
fw dec -883 if jlg < 798
p inc -86 if kbm <= -2317
xq dec -277 if ls <= 2017
pdg inc 518 if e < -1209
l inc 933 if esj == 515
xq dec 962 if w <= -173
jlg dec -79 if w >= -178
pvo dec 200 if jlg == 794
f dec -31 if pvo != 1321
pl inc -585 if pvo == 1323
u inc -750 if pdg == -1719
jlg dec 445 if l <= 2082
l inc -373 if kgp <= -1362
w dec 812 if pl == -682
fi dec 760 if f <= 115
t inc 457 if w != -181
u inc -562 if ls >= 2017
hsv dec -666 if t > 2338
pvo dec 771 if gf != 1446
gf inc 665 if pl <= -674
xq inc -465 if t < 2339
e dec 519 if gf > 2112
esj inc -518 if f <= 114
gf inc -794 if s != 3183
p inc 254 if hsv == 1618
t inc 242 if fw < -331
fw inc -52 if kbm > -2327
gf inc -483 if l >= 1703
kgp dec -569 if hi > -1851
t inc 409 if kgp < -801
kgp dec 528 if u < -958
gf dec -961 if jlg < 348
jcf inc 713 if esj > -12
w inc -429 if hi != -1835
h dec -168 if f > 104
e dec -942 if jlg > 344
h dec -429 if esj != 6
e dec -481 if jcf <= -1295
e inc -676 if e > -307
p inc 855 if pdg == -1719
pvo inc 993 if fw > -398
kgp dec 196 if kgp >= -1325
s dec -576 if pl >= -679
xq inc 510 if p > 4979
jlg dec -898 if hsv != 1610
pl inc -153 if xq > -774
l dec -319 if ls == 2024
l inc -945 if s <= 3757
bh dec -937 if hi <= -1846
u inc -631 if xq <= -758
l dec 966 if h <= -734
gf dec -2 if w == -611
t dec 803 if w <= -619
hsv dec -167 if jcf < -1296
pdg inc 136 if pl <= -835
hsv inc 29 if t > 2582
fi dec 808 if jcf >= -1306
pl inc -910 if pvo > 1546
pdg inc 487 if pl <= -831
hsv inc 265 if fi < -3509
jlg dec 239 if pdg >= -1727
esj dec -811 if hsv < 1822
f inc -467 if xq == -765
fw dec -644 if u >= -1592
fw dec -767 if kbm > -2324
jlg dec 890 if xq <= -766
xq dec -855 if jlg < 1009
u inc 810 if hsv == 1819
s inc 379 if jcf < -1306
ls dec -475 if l <= 1078
kbm dec -339 if pdg <= -1717
hi dec -911 if l < 1083
hi inc 85 if xq != 85
hsv inc 439 if pl > -834
h dec -956 if bh < 1237
pdg inc -508 if kgp > -1522
t dec -63 if kbm >= -1974
kbm inc -619 if f < -354
s inc -110 if pvo < 1552
e dec -100 if jcf <= -1301
fi dec 369 if jcf > -1304
w dec -191 if kgp <= -1515
hsv inc 742 if w == -420
gf dec -445 if e >= -877
ls dec -582 if kgp >= -1519
pl inc 561 if jcf >= -1310
t dec -910 if fi <= -3881
ls inc -772 if e < -874
e dec -322 if bh <= 1237
pvo dec 189 if l == 1078
kgp inc -727 if l != 1071
ls inc -461 if esj == 808
p inc -781 if ls > 1843
fw dec -284 if hi == -853
pvo dec -946 if w <= -414
s dec 409 if pl < -259
pdg dec -490 if esj != 808
h inc 400 if kgp > -2251
ls inc 240 if fi > -3882
jcf inc -944 if u > -1602
u dec 315 if f >= -361
hi dec -353 if h >= 621
jlg inc 846 if f < -354
hi dec -49 if jcf > -2246
f dec 274 if p > 4208
h dec -772 if esj != 815
fi inc 656 if hi < -440
fi dec -49 if t > 2585
w dec -219 if fw != 368
fi inc 142 if fi == -3162
kgp dec 574 if pl > -262
u dec -855 if xq > 85
f dec -137 if f >= -347
bh inc 355 if e == -553
hsv inc 310 if pdg > -2230
hi dec -219 if hi != -445
u dec -915 if pdg > -2236
hi inc -4 if fw > 369
pdg dec -364 if fw >= 365
bh inc 768 if e <= -551
f inc 409 if s >= 3224
esj inc 968 if gf < 1275
jlg dec -21 if kgp >= -2245
f inc -206 if fi < -3162
u dec -829 if w == -201
s dec 878 if hi != -230
hsv inc 467 if fw >= 365
u dec 725 if fi <= -3166
gf dec 391 if kbm < -2589
bh dec 535 if fi == -3166
gf dec 540 if e <= -553
fw inc 645 if kbm <= -2592
pl inc 606 if f != -149
xq dec 421 if jlg < 1878
p dec 244 if esj == 808
gf inc 160 if jlg > 1869
pvo dec -243 if pvo >= 2295
jcf inc 100 if hsv >= 3776
s dec 43 if ls < 2093
fi dec -487 if hi == -229
pl inc -875 if pdg == -1863
fi dec 56 if bh == 2359
s inc -659 if hi > -237
gf dec 371 if gf >= 523
gf dec -431 if bh == 2359
jlg dec 650 if w <= -210
h inc 7 if t != 2576
pdg dec -147 if hi <= -230
fw inc 118 if pl > -531
fw dec -291 if f >= -160
fw inc -548 if s == 1650
bh inc 519 if pdg >= -1872
xq dec -192 if hi < -221
f inc 988 if kbm > -2604
pl dec -188 if esj >= 803
w dec -643 if u != -36
fw dec 215 if hi < -228
jcf inc -158 if fi != -2739
f dec 574 if s == 1650
f inc -960 if pvo != 2553
gf dec -877 if u == -35
h dec -456 if l == 1078
l inc 382 if l < 1085
fw dec -301 if jcf < -2241
u inc 273 if w < -195
jcf dec 801 if fw >= 848
h dec -679 if jcf != -3049
e dec 925 if fi != -2734
e inc -167 if t != 2583
xq dec 194 if jcf == -3046
w dec -367 if ls <= 2095
jlg inc 425 if pl == -347
p dec 594 if pdg > -1862
h dec 693 if kbm <= -2595
pl inc -951 if w > 164
pvo inc -781 if gf <= 953
w dec 903 if hsv <= 3777
e dec 679 if kbm != -2592
e inc 805 if hi != -220
l inc 93 if gf < 943
bh dec 26 if w >= -738
w dec 66 if jlg < 1883
esj dec 174 if gf > 945
e inc 954 if bh != 2853
ls dec 197 if hsv > 3778
kgp inc -129 if hi > -232
kbm inc 496 if f == -699
ls inc 466 if s > 1648
pl inc -942 if w == -803
s inc 211 if pl == -2241
xq dec 992 if e > -566
pl inc 644 if t >= 2580
hsv dec -309 if u <= 236
pdg dec -381 if bh > 2843
hsv dec -865 if w == -803
fw inc -456 if kgp == -2374
f inc 454 if hsv != 4635
jcf inc 902 if xq < -1321
t inc -496 if jlg <= 1880
kgp dec -228 if kgp >= -2375
xq dec -161 if e != -566
pdg dec -738 if l == 1460
f dec -965 if l < 1465
jlg dec 518 if f == 720
esj inc 358 if bh <= 2852
ls inc 916 if h > 1840
t dec -94 if bh < 2858
h inc -881 if kbm == -2101
e dec -741 if gf >= 950
ls inc 868 if fw >= 402
jcf inc 330 if p < 3964
l dec 428 if kbm >= -2103
p inc 699 if kgp < -2136
l dec 602 if w == -803
fi inc 843 if jcf != -1820
gf dec -860 if esj < 1175
l inc -184 if hsv > 4628
l dec -305 if fi <= -1906
pl dec -338 if f != 720
hi inc -202 if f == 720
s inc 342 if w == -811
kgp dec -684 if p != 4665
t inc 815 if pl >= -1598
fw dec 543 if hsv <= 4628
t dec -414 if xq >= -1167
p inc 275 if e == -565
pvo dec -896 if fw >= 400
pl inc 505 if pvo > 1771
xq dec 129 if esj <= 1170
bh dec -75 if l == 246
pl dec -397 if gf != 1812
p dec 681 if esj <= 1167
pl inc -224 if h == 963
gf dec 964 if pl <= -1426
f inc -298 if kgp >= -1471
bh inc 1000 if l <= 248
pvo dec -455 if p != 4257
s dec 183 if w != -797
f dec -232 if l < 247
hi inc 766 if hi == -431
fw dec 973 if ls < 3474
pvo dec 685 if kgp == -1462
p inc 781 if h < 965
kbm dec -179 if hsv < 4632
hsv dec -827 if w == -803
jlg dec 83 if jlg <= 1360
kbm dec 283 if fi == -1896
w dec -933 if xq <= -1288
jlg inc -566 if kbm <= -2382
jlg dec -652 if e > -575
hi dec 965 if ls > 3467
hsv dec 599 if f >= 663
xq inc 395 if hi > -631
hi inc 29 if kgp <= -1464
l inc -656 if ls <= 3471
l inc 475 if xq == -898
fw dec -997 if jlg >= 1361
xq dec 218 if pvo < 1532
gf inc -920 if pl == -1424
e inc -707 if f <= 657
p dec 438 if pl < -1422
fw dec -192 if h <= 972
p dec 153 if fi != -1890
hsv inc 614 if pvo != 1534
bh dec 508 if gf >= 882
pvo dec 670 if ls <= 3473
pvo inc 72 if ls <= 3463
kbm dec -783 if jlg != 1360
gf inc 309 if s <= 1684
u inc 250 if l <= 73
hi dec -128 if h < 971
jlg dec 588 if pvo > 861
h inc -690 if jlg <= 776
xq dec -56 if esj == 1166
t inc 762 if esj < 1168
fw dec 190 if w <= 138
jcf inc 305 if bh == 3419
t dec -35 if hsv == 5464
gf dec -464 if kbm < -2380
bh inc -315 if jlg < 782
e dec 436 if kbm <= -2379
u inc -135 if l < 66
gf inc -996 if p == 4441
s inc 69 if l == 65
kbm dec 583 if kgp < -1470
w inc -539 if p >= 4435
s dec 630 if fw >= -576
jcf dec -585 if w < -405
ls dec 803 if pvo != 864
u dec -704 if p >= 4448
t dec 567 if s < 1748
bh dec 973 if w >= -413
kgp dec 605 if p <= 4435
fw inc 502 if t != 3651
s dec 804 if jcf > -932
u inc 723 if jlg <= 776
f inc 476 if u > 1074
fi dec -345 if xq >= -851
ls inc 554 if fi <= -1559
ls inc 705 if pl <= -1421
kgp dec -439 if xq >= -843
xq inc -540 if xq > -847
e inc -969 if xq != -1377
pl dec -935 if p <= 4442
jlg inc 208 if jlg < 780
t dec 431 if xq > -1391
s inc -182 if kbm <= -2382
w inc -678 if h < 283
esj inc 662 if hi <= -507
jcf dec 267 if t != 3219
jcf inc -948 if fw == -77
s inc 358 if hi >= -507
f inc 364 if jcf <= -2139
u dec -178 if xq == -1382
fw inc 174 if kbm <= -2378
p inc 607 if t == 3213
jcf inc 448 if pl > -494
pl inc 217 if kgp != -1023
pl inc -395 if kbm < -2378
bh inc -422 if hi <= -507
kgp dec -845 if p != 4437
kbm dec -660 if pdg == -747
jcf dec 653 if e == -2677
h dec 103 if s < 1123
jlg inc -504 if pvo > 868
l dec 824 if fi < -1543
jcf inc -325 if ls <= 4166
esj inc -485 if fi >= -1546
pl dec 719 if l >= -761
kgp inc -257 if gf >= 655
s dec 612 if kgp >= -425
s inc 67 if s > 1111
f dec 967 if pdg > -745
kbm inc 827 if l > -765
h dec 423 if fw > 105
ls inc 431 if h > 166
f dec 592 if esj >= 1171
f dec 532 if jcf == -2338
kbm inc -162 if h > 165
w inc 180 if hi != -495
ls inc 603 if hi >= -496
xq inc -516 if fi != -1551
s inc -30 if hi != -495
jcf inc -342 if pdg < -737
pl dec -278 if esj > 1158
pdg dec -961 if hi == -502
bh inc 972 if esj >= 1157
l dec -854 if jlg <= 985
l dec -966 if h == 170
fw dec 262 if pdg < 223
esj dec 35 if ls != 4603
xq dec 497 if pdg == 217
t inc 998 if hsv < 5471
gf inc 283 if fi > -1553
s dec -592 if kgp < -427
hi inc 883 if l < 1064
s inc -388 if s <= 1751
p dec -950 if pdg == 218
kbm dec 127 if kgp == -435
l dec -217 if w >= -911
w dec -210 if p > 4435
hsv inc 726 if gf <= 946
hi dec -199 if h <= 170
hi inc -481 if fi >= -1541
w dec 295 if t <= 4205
gf inc 791 if jcf == -2692
u dec -988 if bh >= 3096
jlg inc -821 if esj < 1132
fi inc 893 if fw == -165
pvo inc 177 if esj > 1130
bh dec 475 if kgp == -435
ls inc 273 if pvo >= 1049
pvo dec -983 if fw >= -161
s inc 529 if jcf >= -2691
pl dec -154 if xq < -1872
bh inc 211 if pl <= -1164
gf inc 519 if jcf != -2695
esj dec -726 if kbm >= -1851
w inc -251 if jlg != 151
l dec -162 if fw < -163
w inc -25 if h != 174
s inc -303 if kgp == -435
l dec 439 if ls < 4600
fi dec -171 if pdg <= 211
pvo dec 4 if hi > 586
pvo dec 492 if pdg == 211
u inc -355 if gf == 1463
kgp dec 822 if kbm < -1841
bh inc 808 if s < 1592
pl inc -827 if t == 4210
l inc -748 if pdg <= 213
jcf inc 49 if p < 4446
f inc 781 if pdg >= 208
hsv dec -263 if t > 4201
p dec -424 if kgp < -1253
hi inc 528 if ls <= 4606
u inc 240 if ls != 4596
ls inc -2 if h == 170
esj dec -884 if l == 1440
w dec -883 if u <= 2130
kbm inc -450 if kgp <= -1250
jcf inc 38 if f < 1304
ls dec 121 if fw < -162
s inc 139 if jlg == 159
jlg dec 984 if ls < 4491
u inc -837 if bh != 3640
fi inc -56 if p <= 4873
jcf dec 198 if esj == 2741
hsv inc 731 if jcf > -2836
jlg inc 765 if hi > 1104
gf inc 630 if pvo < 1044
s dec 510 if pvo <= 1043
bh dec 168 if esj < 2742
pvo dec 135 if fi >= -713
kgp inc 578 if u > 1279
hi dec -842 if pdg < 213
pvo dec -908 if pdg < 221
p dec 152 if fi >= -718
fi dec -217 if t >= 4206
esj dec -237 if jlg == -60
kbm inc -637 if pvo <= 1946
t inc 324 if gf > 2090
xq inc -950 if h > 179
s inc -285 if u < 1292
h dec 469 if fi >= -503
jlg dec 810 if pvo >= 1948
hi dec 903 if fi != -493
h inc -548 if u < 1295
hi inc 269 if l >= 1438
fi dec 341 if hsv < 7193
xq inc -292 if u == 1289
s dec -183 if ls >= 4480
gf dec -654 if hsv > 7178
pvo dec 871 if l < 1445
kgp inc -251 if xq > -2179
f inc 7 if l >= 1439
pvo inc -116 if f > 1313
fw inc 199 if f > 1310
kbm inc -481 if ls == 4483
h dec -765 if pvo == 962
fw dec 109 if bh > 3475
jcf dec 691 if pl <= -1997
t inc -786 if fw <= -71
f inc 209 if l > 1434
xq inc -11 if h > -83
pdg dec 650 if kbm < -2771
w dec -914 if xq <= -2191
kgp inc 403 if pdg >= -442
f inc -274 if h >= -76
l dec -548 if gf >= 2742
e dec -969 if gf != 2739
hi dec -299 if e > -1705
fw inc 654 if jcf < -3521
bh inc 86 if esj >= 2969
l inc -671 if fw >= 578
f inc 44 if hi < 472
pdg inc 882 if xq <= -2175
fi dec 672 if bh == 3565
hsv dec 916 if f != 1528
fi dec 355 if fw >= 579
pvo dec -34 if kbm < -2776
bh inc 495 if t >= 3739
gf dec -974 if kgp >= -527
pdg inc -220 if xq < -2178
h inc -968 if t < 3750
s dec -868 if esj > 2977
ls inc -988 if h != -1041
kgp inc -730 if jcf > -3528
s inc 354 if esj > 2969
xq dec -358 if pdg > 226
pdg dec 183 if pdg != 238
fi dec -27 if l < 1320
p dec 930 if f <= 1531
esj inc -690 if kgp <= -1251
fw dec 855 if fi >= -1840
fi inc 395 if kgp > -1260
e inc 271 if kgp >= -1255
hi inc 453 if p > 3781
bh inc -111 if hi < 935
fw dec 868 if bh >= 3947
kbm inc 13 if l == 1317
w inc -530 if gf >= 3725
p inc -743 if l <= 1322
t dec 180 if gf >= 3716
hi dec 332 if f != 1532
kgp dec 330 if bh >= 3954
xq dec 709 if kbm != -2772
l inc -44 if hi > 590
u dec -442 if pl != -2006
t dec -2 if hi <= 593
p dec -846 if e >= -1710
e inc 692 if t >= 3565
s inc 548 if xq < -2539
kgp inc -40 if fi != -1450
jlg dec -560 if jlg >= -877
pvo dec 865 if w == -85
fi dec -879 if kgp >= -1304
hsv dec 470 if hsv >= 6265
e dec 240 if p >= 3882
hsv inc -213 if hi == 591
pvo dec 835 if e <= -1250
s inc -382 if l <= 1277
ls dec 322 if t == 3568
jlg inc -864 if bh != 3949
s dec -350 if s <= 1956
fi inc -772 if jlg > -304
ls dec -906 if jlg < -307
e dec -301 if fi > -566
pvo dec -421 if fw != -1148
l dec 159 if xq == -2533
e inc -426 if f < 1523
p inc -161 if jcf == -3519
p dec -180 if w == -86
u inc 164 if pdg >= 38
kgp dec 514 if u <= 1896
fw dec 43 if xq <= -2534
ls inc -549 if hsv >= 5790
jcf dec 999 if kgp <= -1807
u dec -265 if esj <= 2292
pvo dec -637 if pdg == 56
hsv dec 315 if ls < 3538
pl inc -158 if w < -88
jcf dec 832 if f < 1530
fi dec -25 if p < 3891
p inc 311 if pvo > 572
f dec -634 if h <= -1060
f dec 659 if hsv >= 5479
kgp dec 143 if gf <= 3729
hsv inc 16 if fi <= -539
f inc -13 if ls <= 3533
kbm dec 35 if kgp > -1957
w dec -392 if u == 2160
pl dec -367 if hsv < 5494
pdg dec 733 if xq > -2539
fi inc 772 if h <= -1055
jcf inc 925 if p >= 4192
jcf inc 806 if hi >= 587
l dec 267 if hi > 589
esj inc -42 if jlg > -314
f dec 75 if e <= -953
s dec 742 if l <= 848
hi inc 785 if kgp == -1954
s dec 562 if hsv < 5503
s dec -392 if esj <= 2248
fw dec 342 if jcf == -3630
u dec 379 if e >= -963
xq dec 510 if pdg != -693
e dec -436 if u > 1778
jcf dec -307 if hsv != 5499
pvo dec 695 if kbm == -2799
xq inc -425 if e < -513
bh inc -161 if pdg > -692
gf dec -656 if u < 1782
esj dec 6 if esj != 2250
hsv dec 153 if s > 1383
w dec 947 if p > 4187
t inc 616 if ls < 3540
ls dec -110 if w <= -646
f inc -813 if w >= -647
jcf inc 447 if kbm >= -2805
hsv inc 945 if pdg > -680
jlg dec 600 if f >= -45
s inc -138 if xq >= -3474
u inc -39 if kbm != -2805
t inc -161 if s >= 1252
kbm dec 685 if e >= -517
fw inc 431 if jcf == -3179
l dec 791 if h > -1044
esj dec 534 if fw >= -713
pl inc -500 if fi < -538
pdg inc -632 if gf >= 4385
hi inc -269 if fi < -538
ls dec 561 if pdg != -677
hi dec -611 if esj > 1701
gf dec -800 if pdg < -678
s inc 624 if w != -636
hsv inc -935 if h != -1052
jcf inc 343 if e == -519
xq dec -199 if f <= -28
p inc -511 if gf >= 5168
p dec 973 if t <= 4024
gf inc 197 if hi > 1730
jlg inc -239 if l <= 855
hi dec -402 if l >= 845
p dec -125 if bh == 3792
w inc -263 if gf != 5175
xq inc -658 if xq >= -3277
h inc 174 if jlg < -1152
gf dec -81 if t <= 4031
u inc -677 if kgp == -1954
u dec 647 if jlg == -1157
fi dec 783 if fw >= -714
hsv dec -829 if hsv <= 4418
jcf dec -524 if f == -36
ls dec -760 if w >= -911
e inc -690 if pvo <= -122
jcf dec -870 if hi < 2126
f inc 500 if s == 1877
jlg dec 2 if p != 2713
jlg inc 260 if p != 2705
bh inc -167 if pdg >= -677
fw inc -545 if s >= 1870
jcf dec 304 if w != -911
u dec -355 if pvo <= -113
jlg dec 425 if u == 1420
l dec 994 if kgp == -1954
l inc 985 if pl <= -2666
hi dec 870 if ls == 3729
esj dec 552 if f >= 474
bh inc 234 if bh < 3794
s dec -537 if pl <= -2655
t dec -838 if xq <= -3925
t inc 562 if jlg != -1317
hi inc -205 if e > -523
s inc 26 if fw > -1260
kbm dec 52 if pl < -2647
jcf dec -478 if h <= -1048
esj inc 982 if l >= -141
u dec -579 if h <= -1047
fi inc 757 if w < -903
fi dec 56 if hi == 1052
xq dec -443 if u <= 2006
kgp inc -883 if esj <= 1709
hsv dec -429 if xq < -3482
s inc 362 if h > -1059
u dec -45 if l >= -155
hi inc -870 if pdg > -694
fw inc -436 if l < -141
jlg dec 544 if p < 2709
t inc -345 if bh != 4021
h dec -67 if esj == 1705
jcf dec -458 if jlg < -1312
s inc 115 if ls < 3735
kgp dec 884 if p <= 2719
pvo dec 476 if esj <= 1706
f inc -41 if pvo < -583
fw dec 699 if h <= -1041
e inc -922 if gf > 5255
p dec 482 if s > 2912
w inc -240 if fi == -565
f inc -39 if kgp > -3731
ls dec 891 if xq >= -3487
esj inc -711 if fw == -2393
ls dec 653 if fw <= -2390
bh dec 447 if hsv > 5662
ls dec 207 if pdg < -685
hi dec -461 if bh == 3575
pdg inc -499 if w <= -1146
w inc 33 if kbm > -2858
pvo inc -830 if gf < 5265
xq dec -212 if s == 2917
esj inc -124 if hi < 645
hsv dec 661 if u < 2043
xq dec 473 if jlg == -1320
esj dec 18 if l <= -151
kbm dec 184 if kbm <= -2850
gf inc -706 if h < -1058
esj dec 772 if ls < 1982
hi inc 573 if pl > -2660
t dec 612 if h > -1059
u inc 946 if f != 381
t dec 775 if h == -1050
jlg inc -310 if l < -137
w dec -649 if hi == 1213
pl inc -561 if jlg != -1622
bh dec -845 if kgp >= -3718
fi dec 927 if h == -1050
fi inc 240 if s != 2922
pl dec 529 if l >= -153
bh dec -913 if jcf == -810
fw inc 208 if pvo < -1418
e dec -944 if hi > 1206
t inc -627 if e > -505
t inc -524 if s >= 2923
w dec -41 if pvo != -1419
jcf inc 387 if fi < -1250
kbm inc 878 if w == -466
ls inc -595 if kbm >= -2164
kbm dec 41 if bh == 4488
u dec -752 if h == -1050
fw dec 901 if fi > -1254
s inc -939 if h > -1051
l dec 888 if xq < -3268
f inc -13 if p < 2232
esj inc -479 if ls == 1383
pl dec -640 if kgp < -3713
l inc 999 if p == 2231
e inc -493 if s < 1978
p dec -7 if jcf < -416
u dec -496 if l > -40
jcf dec -648 if pdg < -1193
l dec -754 if h >= -1054
w dec 119 if ls >= 1383
t inc 403 if ls <= 1392
pl inc -232 if w == -585
gf inc 807 if w > -590
kbm dec 700 if hi != 1206
esj inc -67 if e < -487
e inc 736 if p >= 2233
e dec 346 if h <= -1043
kbm dec -791 if t != 3467
gf dec -100 if bh == 4488
fi inc 713 if h > -1056
hsv dec 744 if t >= 3466
xq inc -731 if jcf > -416
p dec -974 if l > 708
w inc -485 if ls >= 1381
u inc 982 if fi >= -543
esj dec -651 if jlg != -1624
esj inc -754 if ls <= 1387
bh dec 670 if p != 3203
w inc 121 if bh > 3814
kbm dec 696 if pl > -3342
l inc 800 if hsv >= 4926
hsv inc 232 if kbm > -3601
gf dec 100 if h != -1050
gf inc -403 if t >= 3465
p dec -642 if esj == -1199
jlg dec 807 if e != -99
w inc -428 if fw < -3082
ls inc -893 if hi >= 1210
jcf inc -412 if pvo <= -1411
fw inc 942 if bh > 3809
bh dec 996 if esj <= -1195
pvo dec 388 if h >= -1044
fw inc 354 if p <= 3212
f dec 667 if jcf > -841
f inc 842 if s == 1978
pvo inc 9 if ls == 490
hi dec 355 if ls == 490
pl inc 371 if jcf < -825
hsv dec -741 if t == 3458
xq inc -377 if fi > -537
xq dec 848 if fi <= -540
e inc -855 if t <= 3467
pl inc 207 if xq < -3273
jlg dec -270 if kgp <= -3716
jlg inc 909 if w > -1383
p dec -736 if fi <= -547
l dec 869 if fw == -1790
bh inc -398 if u != 5227
kgp dec -312 if s > 1976
e inc 494 if fi == -539
hi inc -942 if xq == -3272
hsv dec 698 if e >= -471
kbm dec 546 if h <= -1060
ls inc -782 if e > -473
fw dec -245 if p <= 3221
s inc 19 if esj > -1211
pdg dec 394 if esj < -1208
l dec -433 if w >= -1380
e dec -738 if l <= 283
kgp inc 383 if pl < -2962
ls inc -369 if hi > -75
bh dec -724 if bh <= 2429
fi inc -52 if bh != 3154
xq inc -145 if h >= -1053
fi dec 1000 if xq < -3413
pvo inc 591 if jcf < -838
p dec 693 if pl >= -2971
jcf dec 232 if pdg < -1178
s dec -669 if pvo != -1410
kgp inc -102 if l > 280
l dec -421 if w >= -1378
l inc -299 if hi <= -84
esj dec 707 if e <= 270
kgp dec -225 if f >= 538
f dec -845 if hi != -80
hsv dec 870 if l <= 409
e dec 213 if gf == 5762
jlg inc 210 if jcf > -1076
pl dec -436 if kbm > -3604
p dec 431 if jlg != -1037
xq inc -703 if pvo > -1411
fi inc -484 if e >= 54
xq dec -134 if w == -1377
hi dec 640 if e < 48
pdg dec 745 if kgp <= -2909
l inc 444 if s < 2004
hi dec 874 if w <= -1387
jlg dec -178 if f != 1387
t inc -216 if u < 5218
pl inc 601 if fi >= -2077
hi inc -818 if ls <= -286
pvo inc -31 if w < -1368
pvo inc -865 if f < 1395
s dec -626 if t < 3474
h inc 478 if jlg < -858
u inc -390 if jcf <= -1061
h inc -155 if pl != -1921
jlg inc -949 if esj < -1904
xq dec -437 if h > -731
hsv dec -812 if pl < -1925
t inc -940 if pl >= -1933
jcf inc -903 if pvo <= -2303
xq inc -19 if esj >= -1911
w inc 238 if pdg <= -1183
f inc -441 if hsv >= 4408
l dec 15 if s > 2614
hsv dec -238 if pvo == -2306
ls dec 641 if p > 2083
h dec -548 if kgp >= -2899
hsv inc 472 if hsv >= 4637
bh dec 123 if s <= 2632
pdg dec 314 if u >= 4827
pl dec -600 if pl >= -1934
h dec -697 if hsv <= 5104
u dec -458 if s >= 2623
gf dec -688 if w == -1139
jcf dec -739 if xq != -3567
l dec -886 if pdg > -1498
s dec -24 if pvo < -2300
kbm inc -76 if jlg >= -1821
fi inc 992 if pvo != -2299
fi inc 638 if fi >= -1091
u inc 452 if ls > -934
h inc 713 if gf <= 6443
p inc -60 if jlg > -1816
bh dec -100 if hsv < 5117
l inc -290 if kgp <= -2895
pvo dec 900 if gf == 6450
u dec 470 if jcf != -1222
bh inc -730 if fw >= -1547
jcf inc 584 if esj >= -1915
e inc -43 if e >= 57
bh inc -883 if l != 552
fi dec 306 if jcf < -645
pl dec -428 if l > 535
s dec 793 if esj == -1908
pl inc 78 if w == -1139
gf dec 107 if p <= 2031
jcf dec -150 if pl <= -820
w inc -854 if jlg < -1808";
            }
        }

        public static void Init()
        {
            lines = new List<string>();
            string[] separators = new string[] { "\r\n" };
            lines = Input.Split(separators, StringSplitOptions.None).ToList();
            registers = new Dictionary<string, int>();

        }

        public static object StarOne()
        {
            Init();
            foreach (var line in lines)
            {
                string[] separators = new string[] { "if" };
                var lineParams = line.Split(' ');
                var regnametochange = lineParams[0];
                if (!registers.ContainsKey(regnametochange))
                {
                    registers.Add(lineParams[0], 0);
                }

                var regnametocheck = lineParams[4];
                var comparator = lineParams[5];
                var compareValue = lineParams[6];
                if (!registers.ContainsKey(regnametocheck))
                {
                    registers.Add(regnametocheck, 0);
                }
                bool conditionIsTrue = CheckCondition(regnametocheck, comparator, compareValue);
                if (conditionIsTrue)
                {
                    var isIncrease = lineParams[1] == "inc";
                    var value = Int32.Parse(lineParams[2]);
                    if (isIncrease)
                    {
                        registers[regnametochange] += value;
                    }
                    else
                    {
                        registers[regnametochange] -= value;
                    }
                }
            }
            return registers.OrderByDescending(pair => pair.Value).FirstOrDefault().Value;
        }

        private static bool CheckCondition(string regnametocheck, string comparator, string compareValue)
        {
            var result = false;
            var value = Int32.Parse(compareValue);
            switch (comparator)
            {
                case ">":
                    if (registers[regnametocheck] > value)
                        result = true;
                    break;
                case ">=":
                    if (registers[regnametocheck] >= value)
                        result = true;
                    break;
                case "==":
                    if (registers[regnametocheck] == value)
                        result = true;
                    break;
                case "!=":
                    if (registers[regnametocheck] != value)
                        result = true;
                    break;
                case "<=":
                    if (registers[regnametocheck] <= value)
                        result = true;
                    break;
                case "<":
                    if (registers[regnametocheck] < value)
                        result = true;
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }
            return result;
        }

        public static object StarTwo()
        {
            Init();
            return -2;
        }
    }
}
