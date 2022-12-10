using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017
{
    [TestClass]
    public class Test2017
    {
        [TestMethod]
        public void DayXStarOne()
        {
            string input = "428122498997587283996116951397957933569136949848379417125362532269869461185743113733992331379856446362482129646556286611543756564275715359874924898113424472782974789464348626278532936228881786273586278886575828239366794429223317476722337424399239986153675275924113322561873814364451339186918813451685263192891627186769818128715595715444565444581514677521874935942913547121751851631373316122491471564697731298951989511917272684335463436218283261962158671266625299188764589814518793576375629163896349665312991285776595142146261792244475721782941364787968924537841698538288459355159783985638187254653851864874544584878999193242641611859756728634623853475638478923744471563845635468173824196684361934269459459124269196811512927442662761563824323621758785866391424778683599179447845595931928589255935953295111937431266815352781399967295389339626178664148415561175386725992469782888757942558362117938629369129439717427474416851628121191639355646394276451847131182652486561415942815818785884559193483878139351841633366398788657844396925423217662517356486193821341454889283266691224778723833397914224396722559593959125317175899594685524852419495793389481831354787287452367145661829287518771631939314683137722493531318181315216342994141683484111969476952946378314883421677952397588613562958741328987734565492378977396431481215983656814486518865642645612413945129485464979535991675776338786758997128124651311153182816188924935186361813797251997643992686294724699281969473142721116432968216434977684138184481963845141486793996476793954226225885432422654394439882842163295458549755137247614338991879966665925466545111899714943716571113326479432925939227996799951279485722836754457737668191845914566732285928453781818792236447816127492445993945894435692799839217467253986218213131249786833333936332257795191937942688668182629489191693154184177398186462481316834678733713614889439352976144726162214648922159719979143735815478633912633185334529484779322818611438194522292278787653763328944421516569181178517915745625295158611636365253948455727653672922299582352766484";
            Assert.AreEqual(1034, new Day1().StarOne(input));
        }
        [TestMethod]
        public void DayXStarTwo()
        {
            string input = "428122498997587283996116951397957933569136949848379417125362532269869461185743113733992331379856446362482129646556286611543756564275715359874924898113424472782974789464348626278532936228881786273586278886575828239366794429223317476722337424399239986153675275924113322561873814364451339186918813451685263192891627186769818128715595715444565444581514677521874935942913547121751851631373316122491471564697731298951989511917272684335463436218283261962158671266625299188764589814518793576375629163896349665312991285776595142146261792244475721782941364787968924537841698538288459355159783985638187254653851864874544584878999193242641611859756728634623853475638478923744471563845635468173824196684361934269459459124269196811512927442662761563824323621758785866391424778683599179447845595931928589255935953295111937431266815352781399967295389339626178664148415561175386725992469782888757942558362117938629369129439717427474416851628121191639355646394276451847131182652486561415942815818785884559193483878139351841633366398788657844396925423217662517356486193821341454889283266691224778723833397914224396722559593959125317175899594685524852419495793389481831354787287452367145661829287518771631939314683137722493531318181315216342994141683484111969476952946378314883421677952397588613562958741328987734565492378977396431481215983656814486518865642645612413945129485464979535991675776338786758997128124651311153182816188924935186361813797251997643992686294724699281969473142721116432968216434977684138184481963845141486793996476793954226225885432422654394439882842163295458549755137247614338991879966665925466545111899714943716571113326479432925939227996799951279485722836754457737668191845914566732285928453781818792236447816127492445993945894435692799839217467253986218213131249786833333936332257795191937942688668182629489191693154184177398186462481316834678733713614889439352976144726162214648922159719979143735815478633912633185334529484779322818611438194522292278787653763328944421516569181178517915745625295158611636365253948455727653672922299582352766484";
            Assert.AreEqual(1356, new Day1().StarTwo(input));
        }

        [TestMethod]
        public void Day1StarOne()
        {
            //The night before Christmas, one of Santa's Elves calls you in a panic. "The printer's broken! We can't print the Naughty or Nice List!" By the time you make it to sub-basement 17, there are only a few minutes until midnight. "We have a big problem," she says; "there must be almost fifty bugs in this system, but nothing else can print The List. Stand in this square, quick! There's no time to explain; if you can convince them to pay you in stars, you'll be able to--" She pulls a lever and the world goes blurry.

            //When your eyes can focus again, everything seems a lot more pixelated than before. She must have sent you inside the computer! You check the system clock: 25 milliseconds until midnight. With that much time, you should be able to collect all fifty stars by December 25th.

            //Collect stars by solving puzzles. Two puzzles will be made available on each day millisecond in the advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!

            //You're standing in a room with "digitization quarantine" written in LEDs along one wall. The only door is locked, but it includes a small interface. "Restricted Area - Strictly No Digitized Users Allowed."

            //It goes on to explain that you may only leave by solving a captcha to prove you're not a human. Apparently, you only get one millisecond to solve the captcha: too fast for a normal human, but it feels like hours to you.

            //The captcha requires you to review a sequence of digits (your puzzle input) and find the sum of all digits that match the next digit in the list. The list is circular, so the digit after the last digit is the first digit in the list.

            //For example:

            //1122 produces a sum of 3 (1 + 2) because the first digit (1) matches the second digit and the third digit (2) matches the fourth digit.
            //1111 produces 4 because each digit (all 1) matches the next.
            //1234 produces 0 because no digit matches the next.
            //91212129 produces 9 because the only digit that matches the next one is the last digit, 9.
            //What is the solution to your captcha?
            string input = "428122498997587283996116951397957933569136949848379417125362532269869461185743113733992331379856446362482129646556286611543756564275715359874924898113424472782974789464348626278532936228881786273586278886575828239366794429223317476722337424399239986153675275924113322561873814364451339186918813451685263192891627186769818128715595715444565444581514677521874935942913547121751851631373316122491471564697731298951989511917272684335463436218283261962158671266625299188764589814518793576375629163896349665312991285776595142146261792244475721782941364787968924537841698538288459355159783985638187254653851864874544584878999193242641611859756728634623853475638478923744471563845635468173824196684361934269459459124269196811512927442662761563824323621758785866391424778683599179447845595931928589255935953295111937431266815352781399967295389339626178664148415561175386725992469782888757942558362117938629369129439717427474416851628121191639355646394276451847131182652486561415942815818785884559193483878139351841633366398788657844396925423217662517356486193821341454889283266691224778723833397914224396722559593959125317175899594685524852419495793389481831354787287452367145661829287518771631939314683137722493531318181315216342994141683484111969476952946378314883421677952397588613562958741328987734565492378977396431481215983656814486518865642645612413945129485464979535991675776338786758997128124651311153182816188924935186361813797251997643992686294724699281969473142721116432968216434977684138184481963845141486793996476793954226225885432422654394439882842163295458549755137247614338991879966665925466545111899714943716571113326479432925939227996799951279485722836754457737668191845914566732285928453781818792236447816127492445993945894435692799839217467253986218213131249786833333936332257795191937942688668182629489191693154184177398186462481316834678733713614889439352976144726162214648922159719979143735815478633912633185334529484779322818611438194522292278787653763328944421516569181178517915745625295158611636365253948455727653672922299582352766484";
            Assert.AreEqual(1034, new Day1().StarOne(input));
        }
        [TestMethod]
        public void Day1StarTwo()
        {
            //You notice a progress bar that jumps to 50% completion. Apparently, the door isn't yet satisfied, but it did emit a star as encouragement. The instructions change:

            //Now, instead of considering the next digit, it wants you to consider the digit halfway around the circular list. That is, if your list contains 10 items, only include a digit in your sum if the digit 10/2 = 5 steps forward matches it. Fortunately, your list has an even number of elements.

            //For example:

            //1212 produces 6: the list contains 4 items, and all four digits match the digit 2 items ahead.
            //1221 produces 0, because every comparison is between a 1 and a 2.
            //123425 produces 4, because both 2s match each other, but no other digit has a match.
            //123123 produces 12.
            //12131415 produces 4.
            //What is the solution to your new captcha?
            string input = "428122498997587283996116951397957933569136949848379417125362532269869461185743113733992331379856446362482129646556286611543756564275715359874924898113424472782974789464348626278532936228881786273586278886575828239366794429223317476722337424399239986153675275924113322561873814364451339186918813451685263192891627186769818128715595715444565444581514677521874935942913547121751851631373316122491471564697731298951989511917272684335463436218283261962158671266625299188764589814518793576375629163896349665312991285776595142146261792244475721782941364787968924537841698538288459355159783985638187254653851864874544584878999193242641611859756728634623853475638478923744471563845635468173824196684361934269459459124269196811512927442662761563824323621758785866391424778683599179447845595931928589255935953295111937431266815352781399967295389339626178664148415561175386725992469782888757942558362117938629369129439717427474416851628121191639355646394276451847131182652486561415942815818785884559193483878139351841633366398788657844396925423217662517356486193821341454889283266691224778723833397914224396722559593959125317175899594685524852419495793389481831354787287452367145661829287518771631939314683137722493531318181315216342994141683484111969476952946378314883421677952397588613562958741328987734565492378977396431481215983656814486518865642645612413945129485464979535991675776338786758997128124651311153182816188924935186361813797251997643992686294724699281969473142721116432968216434977684138184481963845141486793996476793954226225885432422654394439882842163295458549755137247614338991879966665925466545111899714943716571113326479432925939227996799951279485722836754457737668191845914566732285928453781818792236447816127492445993945894435692799839217467253986218213131249786833333936332257795191937942688668182629489191693154184177398186462481316834678733713614889439352976144726162214648922159719979143735815478633912633185334529484779322818611438194522292278787653763328944421516569181178517915745625295158611636365253948455727653672922299582352766484";
            Assert.AreEqual(1356, new Day1().StarTwo(input));
        }
        [TestMethod]
        public void Day2StarOne()
        {
            //As you walk through the door, a glowing humanoid shape yells in your direction. "You there! Your state appears to be idle. Come help us repair the corruption in this spreadsheet - if we take another millisecond, we'll have to display an hourglass cursor!"

            //The spreadsheet consists of rows of apparently-random numbers. To make sure the recovery process is on the right track, they need you to calculate the spreadsheet's checksum. For each row, determine the difference between the largest value and the smallest value; the checksum is the sum of all of these differences.

            //For example, given the following spreadsheet:

            //5 1 9 5
            //7 5 3
            //2 4 6 8
            //The first row's largest and smallest values are 9 and 1, and their difference is 8.
            //The second row's largest and smallest values are 7 and 3, and their difference is 4.
            //The third row's difference is 6.
            //In this example, the spreadsheet's checksum would be 8 + 4 + 6 = 18.

            //What is the checksum for the spreadsheet in your puzzle input?

            Assert.AreEqual(30994, Day2.StartOne());
        }
        [TestMethod]
        public void Day2StarTwo()
        {
            //"Great work; looks like we're on the right track after all. Here's a star for your effort." However, the program seems a little worried. Can programs be worried?

            //"Based on what we're seeing, it looks like all the User wanted is some information about the evenly divisible values in the spreadsheet. Unfortunately, none of us are equipped for that kind of calculation - most of us specialize in bitwise operations."

            //It sounds like the goal is to find the only two numbers in each row where one evenly divides the other - that is, where the result of the division operation is a whole number. They would like you to find those numbers on each line, divide them, and add up each line's result.

            //For example, given the following spreadsheet:

            //5 9 2 8
            //9 4 7 3
            //3 8 6 5
            //In the first row, the only two numbers that evenly divide are 8 and 2; the result of this division is 4.
            //In the second row, the two numbers are 9 and 3; the result is 3.
            //In the third row, the result is 2.
            //In this example, the sum of the results would be 4 + 3 + 2 = 9.

            //What is the sum of each row's result in your puzzle input?

            Assert.AreEqual(233, Day2.StartTwo());
        }
        [TestMethod]
        public void Day3StarOne()
        {
            //You come across an experimental new kind of memory stored on an infinite two - dimensional grid.

            //Each square on the grid is allocated in a spiral pattern starting at a location marked 1 and then counting up while spiraling outward.For example, the first few squares are allocated like this:

            //17  16  15  14  13
            //18   5   4   3  12
            //19   6   1   2  11
            //20   7   8   9  10
            //21  22  23---> ...
            //While this is very space - efficient(no squares are skipped), requested data must be carried back to square 1(the location of the only access port for this memory system) by programs that can only move up, down, left, or right. They always take the shortest path: the Manhattan Distance between the location of the data and square 1.

            //For example:

            //Data from square 1 is carried 0 steps, since it's at the access port.
            //Data from square 12 is carried 3 steps, such as: down, left, left.
            //Data from square 23 is carried only 2 steps: up twice.
            //Data from square 1024 must be carried 31 steps.
            //How many steps are required to carry the data from the square identified in your puzzle input all the way to the access port?

            //Your puzzle input is 312051.
            Assert.AreEqual(430, Day3.StarOne());
        }
        [TestMethod]
        public void Day3StarTwo()
        {
            //As a stress test on the system, the programs here clear the grid and then store the value 1 in square 1. Then, in the same allocation order as shown above, they store the sum of the values in all adjacent squares, including diagonals.

            //So, the first few squares' values are chosen as follows:

            //Square 1 starts with the value 1.
            //Square 2 has only one adjacent filled square (with value 1), so it also stores 1.
            //Square 3 has both of the above squares as neighbors and stores the sum of their values, 2.
            //Square 4 has all three of the aforementioned squares as neighbors and stores the sum of their values, 4.
            //Square 5 only has the first and fourth squares as neighbors, so it gets the value 5.
            //Once a square is written, its value does not change. Therefore, the first few squares would receive the following values:

            //147  142  133  122   59
            //304    5    4    2   57
            //330   10    1    1   54
            //351   11   23   25   26
            //362  747  806--->   ...
            //What is the first value written that is larger than your puzzle input?

            Assert.AreEqual(312453, Day3.StarTwo());
        }
        [TestMethod]
        public void Day4StarOne()
        {
            //A new system policy has been put in place that requires all accounts to use a passphrase instead of simply a password. A passphrase consists of a series of words (lowercase letters) separated by spaces.

            //To ensure security, a valid passphrase must contain no duplicate words.

            //For example:

            //aa bb cc dd ee is valid.
            //aa bb cc dd aa is not valid - the word aa appears more than once.
            //aa bb cc dd aaa is valid - aa and aaa count as different words.
            //The system's full passphrase list is available as your puzzle input. How many passphrases are valid?
            Assert.AreEqual(455, Day4.StarOne());
        }
        [TestMethod]
        public void Day4StarTwo()
        {
            //For added security, yet another system policy has been put in place. Now, a valid passphrase must contain no two words that are anagrams of each other - that is, a passphrase is invalid if any word's letters can be rearranged to form any other word in the passphrase.

            //For example:

            //abcde fghij is a valid passphrase.
            //abcde xyz ecdab is not valid - the letters from the third word can be rearranged to form the first word.
            //a ab abc abd abf abj is a valid passphrase, because all letters need to be used when forming another word.
            //iiii oiii ooii oooi oooo is valid.
            //oiii ioii iioi iiio is not valid - any of these words can be rearranged to form any other word.
            //Under this new system policy, how many passphrases are valid?
            Assert.AreEqual(186, Day4.StarTwo());
        }
        [TestMethod]
        public void Day5StarOne()
        {
            //An urgent interrupt arrives from the CPU: it's trapped in a maze of jump instructions, and it would like assistance from any programs with spare cycles to help find the exit.

            //The message includes a list of the offsets for each jump. Jumps are relative: -1 moves to the previous instruction, and 2 skips the next one. Start at the first instruction in the list. The goal is to follow the jumps until one leads outside the list.

            //In addition, these instructions are a little strange; after each jump, the offset of that instruction increases by 1. So, if you come across an offset of 3, you would move three instructions forward, but change it to a 4 for the next time it is encountered.

            //For example, consider the following list of jump offsets:

            //0
            //3
            //0
            //1
            //-3
            //Positive jumps ("forward") move downward; negative jumps move upward. For legibility in this example, these offset values will be written all on one line, with the current instruction marked in parentheses. The following steps would be taken before an exit is found:

            //(0) 3  0  1  -3  - before we have taken any steps.
            //(1) 3  0  1  -3  - jump with offset 0 (that is, don't jump at all). Fortunately, the instruction is then incremented to 1.
            // 2 (3) 0  1  -3  - step forward because of the instruction we just modified. The first instruction is incremented again, now to 2.
            // 2  4  0  1 (-3) - jump all the way to the end; leave a 4 behind.
            // 2 (4) 0  1  -2  - go back to where we just were; increment -3 to -2.
            // 2  5  0  1  -2  - jump 4 steps forward, escaping the maze.
            //In this example, the exit is reached in 5 steps.

            //How many steps does it take to reach the exit?
            Assert.AreEqual(358309, Day5.StarOne());
        }
        [TestMethod]
        public void Day5StarTwo()
        {
            //Now, the jumps are even stranger: after each jump, if the offset was three or more, instead decrease it by 1. Otherwise, increase it by 1 as before.

            //Using this rule with the above example, the process now takes 10 steps, and the offset values after finding the exit are left as 2 3 2 3 -1.

            //How many steps does it now take to reach the exit?
            Assert.AreEqual(28178177, Day5.StarTwo());
        }
        [TestMethod]
        public void Day6StarOne()
        {

            //Assert.AreEqual(11137, Day6.StarOne());
        }
        [TestMethod]
        public void Day6StarTwo()
        {

            //Assert.AreEqual(1356, Day6.StarTwo());
        }
        [TestMethod]
        public void Day7StarOne()
        {
            //Wandering further through the circuits of the computer, you come upon a tower of programs that have gotten themselves into a bit of trouble. 
            //A recursive algorithm has gotten out of hand, and now they're balanced precariously in a large tower.
            //One program at the bottom supports the entire tower. It's holding a large disc, and on the disc are balanced several more sub-towers. 
            //At the bottom of these sub-towers, standing on the bottom disc, are other programs, each holding their own disc, and so on. At the very tops of these sub-sub-sub-...-towers, 
            //many programs stand simply keeping the disc below them balanced but with no disc of their own.
            //You offer to help, but first you need to understand the structure of these towers. You ask each program to yell out their name, their weight, 
            //and (if they're holding a disc) the names of the programs immediately above them balancing on that disc. You write this information down (your puzzle input). 
            //Unfortunately, in their panic, they don't do this in an orderly fashion; by the time you're done, you're not sure which program gave which information.
            //For example, if your list is the following:

            //pbga (66)
            //xhth (57)
            //ebii (61)
            //havc (66)
            //ktlj (57)
            //fwft (72) -> ktlj, cntj, xhth
            //qoyq (66)
            //padx (45) -> pbga, havc, qoyq
            //tknk (41) -> ugml, padx, fwft
            //jptl (61)
            //ugml (68) -> gyxo, ebii, jptl
            //gyxo (61)
            //cntj (57)
            //...then you would be able to recreate the structure of the towers that looks like this:

            //                gyxo
            //              /     
            //         ugml - ebii
            //       /      \     
            //      |         jptl
            //      |        
            //      |         pbga
            //     /        /
            //tknk --- padx - havc
            //     \        \
            //      |         qoyq
            //      |             
            //      |         ktlj
            //       \      /     
            //         fwft - cntj
            //              \     
            //                xhth
            //In this example, tknk is at the bottom of the tower (the bottom program), and is holding up ugml, padx, and fwft. 
            //Those programs are, in turn, holding up other programs; in this example, none of those programs are holding up any other programs, 
            //and are all the tops of their own towers. (The actual tower balancing in front of you is much larger.)
            //Before you're ready to help them, you need to make sure your information is correct. What is the name of the bottom program?

            Assert.AreEqual("hlhomy", Day7.StarOne());
        }
        [TestMethod]
        public void Day7StarTwo()
        {
            //The programs explain the situation: they can't get down. Rather, they could get down, if they weren't expending all of their energy trying to keep the tower balanced. Apparently, one program has the wrong weight, and until it's fixed, they're stuck here.

            //For any program holding a disc, each program standing on that disc forms a sub-tower.Each of those sub - towers are supposed to be the same weight, or the disc itself isn't balanced. The weight of a tower is the sum of the weights of the programs in that tower.

            //In the example above, this means that for ugml's disc to be balanced, gyxo, ebii, and jptl must all have the same weight, and they do: 61.

            //However, for tknk to be balanced, each of the programs standing on its disc and all programs above it must each match.This means that the following sums must all be the same:

            //ugml + (gyxo + ebii + jptl) = 68 + (61 + 61 + 61) = 251
            //padx + (pbga + havc + qoyq) = 45 + (66 + 66 + 66) = 243
            //fwft + (ktlj + cntj + xhth) = 72 + (57 + 57 + 57) = 243
            //As you can see, tknk's disc is unbalanced: ugml's stack is heavier than the other two.Even though the nodes above ugml are balanced, ugml itself is too heavy: it needs to be 8 units lighter for its stack to weigh 243 and keep the towers balanced.If this change were made, its weight would be 60.


            //Given that exactly one program is the wrong weight, what would its weight need to be to balance the entire tower ?
            Assert.AreEqual(1356, Day7.StarTwo());
        }
        [TestMethod]
        public void Day8StarOne()
        {
            //You receive a signal directly from the CPU. Because of your recent assistance with jump instructions, it would like you to compute the result of a series of unusual register instructions.

            //Each instruction consists of several parts: the register to modify, whether to increase or decrease that register's value, the amount by which to increase or decrease it, and a condition. If the condition fails, skip the instruction without modifying the register. The registers all start at 0. The instructions look like this:

            //b inc 5 if a > 1
            //a inc 1 if b < 5
            //c dec -10 if a >= 1
            //c inc -20 if c == 10
            //These instructions would be processed as follows:

            //Because a starts at 0, it is not greater than 1, and so b is not modified.
            //a is increased by 1(to 1) because b is less than 5(it is 0).
            //c is decreased by - 10(to 10) because a is now greater than or equal to 1(it is 1).
            //c is increased by - 20(to - 10) because c is equal to 10.
            //After this process, the largest value in any register is 1.

            //You might also encounter <= (less than or equal to) or != (not equal to). However, the CPU doesn't have the bandwidth to tell you what all the registers are named, and leaves that to you to determine.

            //What is the largest value in any register after completing the instructions in your puzzle input?
            Assert.AreEqual(6343, Day8.StarOne());
        }
        [TestMethod]
        public void Day8StarTwo()
        {
            //To be safe, the CPU also needs to know the highest value held in any register during this process so that it can decide how much memory to allocate to these operations. 
            //For example, in the above instructions, the highest value ever held was 10(in register c after the third instruction was evaluated).
            Assert.AreEqual(7184, Day8.StarTwo());
        }
        [TestMethod]
        public void Day9StarOne()
        {
            //A large stream blocks your path. According to the locals, it's not safe to cross the stream at the moment because it's full of garbage. You look down at the stream; rather than water, you discover that it's a stream of characters.

            //You sit for a while and record part of the stream(your puzzle input).The characters represent groups - sequences that begin with { and end with }. Within a group, there are zero or more other things, separated by commas: either another group or garbage.Since groups can contain other groups, a }
            //        only closes the most-recently-opened unclosed group - that is, they are nestable.Your puzzle input represents a single, large group which itself contains many smaller ones.

            //Sometimes, instead of a group, you will find garbage.Garbage begins with<and ends with>.Between those angle brackets, almost any character can appear, including { and
            //    }. Within garbage, < has no special meaning.

            //In a futile attempt to clean up the garbage, some program has canceled some of the characters within it using !: inside garbage, any character that comes after ! should be ignored, including<,>, and even another !.

            //You don't see any characters that deviate from these rules. Outside garbage, you only find well-formed groups, and garbage always terminates according to the rules above.

            //Here are some self-contained pieces of garbage:

            //<>, empty garbage.
            //<random characters>, garbage containing random characters.
            //<<<<>, because the extra<are ignored.
            //<{ !>}>, because the first > is canceled.
            //<!!>, because the second ! is canceled, allowing the > to terminate the garbage.
            //<!!!>>, because the second ! and the first > are canceled.
            //<{
            //        o"i!a,<{i<a>, which ends at the first >.
            //Here are some examples of whole streams and the number of groups they contain:

            //{ }, 1 group.
            //{ { { } } }, 3 groups.
            //{ { },{ } }, also 3 groups.
            //{ { { },{ },{ { } } } }, 6 groups.
            //{<{ },{ },{ { } }>}, 1 group(which itself contains garbage).
            //{< a >,< a >,< a >,< a >}, 1 group.
            //{ {< a >},{< a >},{< a >},{< a >} }, 5 groups.
            //{ {< !>},{< !>},{< !>},{< a >} }, 2 groups(since all but the last > are canceled).
            //Your goal is to find the total score for all groups in your input.Each group is assigned a score which is one more than the score of the group that immediately contains it. (The outermost group gets a score of 1.)

            //{ }, score of 1.
            //{ { { } } }, score of 1 + 2 + 3 = 6.
            //{ { },{ } }, score of 1 + 2 + 2 = 5.
            //{ { { },{ },{ { } } } }, score of 1 + 2 + 3 + 3 + 3 + 4 = 16.
            //{< a >,< a >,< a >,< a >}, score of 1.
            //{ {< ab >},{< ab >},{< ab >},{< ab >} }, score of 1 + 2 + 2 + 2 + 2 = 9.
            //{ {< !!>},{< !!>},{< !!>},{< !!>} }, score of 1 + 2 + 2 + 2 + 2 = 9.
            //{ {< a!>},{< a!>},{< a!>},{< ab >} }, score of 1 + 2 = 3.
            //What is the total score for all groups in your input ?

            Assert.AreEqual(1034, Day9.StarOne());
        }
        [TestMethod]
        public void Day9StarTwo()
        {

            Assert.AreEqual(1356, Day9.StarTwo());
        }
        [TestMethod]
        public void Day10StarOne()
        {
            //You come across some programs that are trying to implement a software emulation of a hash based on knot - tying.The hash these programs are implementing isn't very strong, but you decide to help them anyway. You make a mental note to remind the Elves later not to invent their own cryptographic functions.

            //This hash function simulates tying a knot in a circle of string with 256 marks on it.Based on the input to be hashed, the function repeatedly selects a span of string, brings the ends together, and gives the span a half-twist to reverse the order of the marks within it.After doing this many times, the order of the marks is used to build the resulting hash.

            //  4--5   pinch   4  5           4   1
            // /    \  5,0,1 / \/ \  twist / \ / \
            //3      0-- > 3      0-- > 3   X   0
            // \    /         \ /\ /         \ / \ /
            //  2--1           2  1           2   5
            //To achieve this, begin with a list of numbers from 0 to 255, a current position which begins at 0(the first element in the list), a skip size(which starts at 0), and a sequence of lengths(your puzzle input).Then, for each length:

            //Reverse the order of that length of elements in the list, starting with the element at the current position.
            //Move the current position forward by that length plus the skip size.
            //Increase the skip size by one.
            //The list is circular; if the current position and the length try to reverse elements beyond the end of the list, the operation reverses using as many extra elements as it needs from the front of the list.If the current position moves past the end of the list, it wraps around to the front. Lengths larger than the size of the list are invalid.

            //Here's an example using a smaller list:

            //Suppose we instead only had a circular list containing five elements, 0, 1, 2, 3, 4, and were given input lengths of 3, 4, 1, 5.

            //The list begins as [0] 1 2 3 4(where square brackets indicate the current position).
            //The first length, 3, selects([0] 1 2) 3 4(where parentheses indicate the sublist to be reversed).
            //After reversing that section(0 1 2 into 2 1 0), we get([2] 1 0) 3 4.
            //Then, the current position moves forward by the length, 3, plus the skip size, 0: 2 1 0[3] 4.Finally, the skip size increases to 1.
            //The second length, 4, selects a section which wraps: 2 1) 0([3] 4.
            //The sublist 3 4 2 1 is reversed to form 1 2 4 3: 4 3) 0([1] 2.
            //The current position moves forward by the length plus the skip size, a total of 5, causing it not to move because it wraps around: 4 3 0[1] 2.The skip size increases to 2.
            //The third length, 1, selects a sublist of a single element, and so reversing it has no effect.
            //The current position moves forward by the length(1) plus the skip size(2): 4[3] 0 1 2.The skip size increases to 3.
            //The fourth length, 5, selects every element starting with the second: 4) ([3] 0 1 2.Reversing this sublist(3 0 1 2 4 into 4 2 1 0 3) produces: 3) ([4] 2 1 0.
            //Finally, the current position moves forward by 8: 3 4 2 1[0].The skip size increases to 4.
            //In this example, the first two numbers in the list end up being 3 and 4; to check the process, you can multiply them together to produce 12.

            //However, you should instead use the standard list size of 256(with values 0 to 255) and the sequence of lengths in your puzzle input.Once this process is complete, what is the result of multiplying the first two numbers in the list?

            Assert.AreEqual(40132, Day10.StarOne());
        }
        [TestMethod]
        public void Day10StarTwo()
        {
            //The logic you've constructed forms a single round of the Knot Hash algorithm; running the full thing requires many of these rounds. Some input and output processing is also required.

            //First, from now on, your input should be taken not as a list of numbers, but as a string of bytes instead. Unless otherwise specified, convert characters to bytes using their ASCII codes.This will allow you to handle arbitrary ASCII strings, and it also ensures that your input lengths are never larger than 255.For example, if you are given 1,2,3, you should convert it to the ASCII codes for each character: 49, 44, 50, 44, 51.


            //Once you have determined the sequence of lengths to use, add the following lengths to the end of the sequence: 17, 31, 73, 47, 23.For example, if you are given 1,2,3, your final sequence of lengths should be 49,44,50,44,51,17,31,73,47,23(the ASCII codes from the input string combined with the standard length suffix values).

            //Second, instead of merely running one round like you did above, run a total of 64 rounds, using the same length sequence in each round. The current position and skip size should be preserved between rounds.For example, if the previous example was your first round, you would start your second round with the same length sequence(3, 4, 1, 5, 17, 31, 73, 47, 23, now assuming they came from ASCII codes and include the suffix), but start with the previous round's current position (4) and skip size (4).

            //Once the rounds are complete, you will be left with the numbers from 0 to 255 in some order, called the sparse hash.Your next task is to reduce these to a list of only 16 numbers called the dense hash.To do this, use numeric bitwise XOR to combine each consecutive block of 16 numbers in the sparse hash(there are 16 such blocks in a list of 256 numbers).So, the first element in the dense hash is the first sixteen elements of the sparse hash XOR'd together, the second element in the dense hash is the second sixteen elements of the sparse hash XOR'd together, etc.

            //For example, if the first sixteen elements of your sparse hash are as shown below, and the XOR operator is ^, you would calculate the first output number like this:

            //65 ^ 27 ^ 9 ^ 1 ^ 4 ^ 3 ^ 40 ^ 50 ^ 91 ^ 7 ^ 6 ^ 0 ^ 2 ^ 5 ^ 68 ^ 22 = 64
            //Perform this operation on each of the sixteen blocks of sixteen numbers in your sparse hash to determine the sixteen numbers in your dense hash.

            //Finally, the standard way to represent a Knot Hash is as a single hexadecimal string; the final output is the dense hash in hexadecimal notation. Because each number in your dense hash will be between 0 and 255(inclusive), always represent each number as two hexadecimal digits(including a leading zero as necessary). So, if your first three numbers are 64, 7, 255, they correspond to the hexadecimal numbers 40, 07, ff, and so the first six characters of the hash would be 4007ff.Because every Knot Hash is sixteen such numbers, the hexadecimal representation is always 32 hexadecimal digits(0 - f) long.

            //Here are some example hashes:

            //            The empty string becomes a2582a3a0e66e6e86e3812dcb672a272.
            //            AoC 2017 becomes 33efeb34ea91902bb2f59c9920caa6cd.
            //1,2,3 becomes 3efbe78a8d82f29979031a4aa0b16a9d.
            //1,2,4 becomes 63960835bcdc130f0b66d7ff4f6a5a8e.
            //Treating your puzzle input as a string of ASCII characters, what is the Knot Hash of your puzzle input? Ignore any leading or trailing whitespace you might encounter.


            Assert.AreEqual("49,44,50,44,51,17,31,73,47,23", Day10.ConvertInputToStarTwoLengths("1,2,3"));
            Assert.AreEqual("a2582a3a0e66e6e86e3812dcb672a272", Day10.StarTwo(""));
            Assert.AreEqual("33efeb34ea91902bb2f59c9920caa6cd", Day10.StarTwo("AoC 2017"));
            Assert.AreEqual("3efbe78a8d82f29979031a4aa0b16a9d", Day10.StarTwo("1,2,3"));
            Assert.AreEqual("63960835bcdc130f0b66d7ff4f6a5a8e", Day10.StarTwo("1,2,4"));

            //Yeah - the right answer is below
            Assert.AreEqual("35b028fe2c958793f7d5a61d07a008c8", Day10.StarTwo(null));
        }
        [TestMethod]
        public void Day11StarOne()
        {
            //Crossing the bridge, you've barely reached the other side of the stream when a program comes up to you, clearly in distress. "It's my child process," she says, "he's gotten lost in an infinite grid!"

            //Fortunately for her, you have plenty of experience with infinite grids.

            //Unfortunately for you, it's a hex grid.

            //The hexagons("hexes") in this grid are aligned such that adjacent hexes can be found to the north, northeast, southeast, south, southwest, and northwest:

            //  \ n /
            //nw + --+ne
            //  /    \
            //-+ +-
            //  \    /
            //sw + --+se
            //  / s  \
            //You have the path the child process took.Starting where he started, you need to determine the fewest number of steps required to reach him. (A "step" means to move from the hex you are in to any adjacent hex.)

            //For example:

            //ne, ne, ne is 3 steps away.
            //ne, ne, sw, sw is 0 steps away(back where you started).
            //ne, ne, s, s is 2 steps away(se, se).
            //se, sw, se, sw, sw is 3 steps away(s, s, sw).
            Assert.AreEqual(796, Day11.StarOne(null));
        }
        [TestMethod]
        public void Day11StarTwo()
        {
            //How many steps away is the **furthest** he ever got from his starting position?
            Assert.AreEqual(1585, Day11.StarTwo(null));
        }
        [TestMethod]
        public void Day12StarOne()
        {
            //---Day 12: Digital Plumber ---
            //Walking along the memory banks of the stream, you find a small village that is experiencing a little confusion: some programs can't communicate with each other.

            //Programs in this village communicate using a fixed system of pipes.Messages are passed between programs using these pipes, but most programs aren't connected to each other directly. Instead, programs pass messages between each other until the message reaches the intended recipient.

            //For some reason, though, some of these messages aren't ever reaching their intended recipient, and the programs suspect that some pipes are missing. They would like you to investigate.

            //You walk through the village and record the ID of each program and the IDs with which it can communicate directly(your puzzle input).Each program has one or more programs with which it can communicate, and these pipes are bidirectional; if 8 says it can communicate with 11, then 11 will say it can communicate with 8.

            //You need to figure out how many programs are in the group that contains program ID 0.

            //For example, suppose you go door - to - door like a travelling salesman and record the following list:

            //            0 <-> 2
            //1 <-> 1
            //2 <-> 0, 3, 4
            //3 <-> 2, 4
            //4 <-> 2, 3, 6
            //5 <-> 6
            //6 <-> 4, 5
            //In this example, the following programs are in the group that contains program ID 0:

            //Program 0 by definition.
            //Program 2, directly connected to program 0.
            //Program 3 via program 2.
            //Program 4 via program 2.
            //Program 5 via programs 6, then 4, then 2.
            //Program 6 via programs 4, then 2.
            //Therefore, a total of 6 programs are in this group; all but program 1, which has a pipe that connects it to itself.

            //How many programs are in the group that contains program ID 0 ?
            Assert.AreEqual(175, Day12.StarOne());
        }
        [TestMethod]
        public void Day12StarTwo()
        {

            Assert.AreEqual(213, Day12.StarTwo());
        }
        [TestMethod]
        public void Day13StarOne()
        {
            //---Day 13: Packet Scanners ---
            //You need to cross a vast firewall. The firewall consists of several layers, each with a security scanner that moves back and forth across the layer. To succeed, you must not be detected by a scanner.

            //By studying the firewall briefly, you are able to record(in your puzzle input) the depth of each layer and the range of the scanning area for the scanner within it, written as depth: range.Each layer has a thickness of exactly 1.A layer at depth 0 begins immediately inside the firewall; a layer at depth 1 would start immediately after that.

            //For example, suppose you've recorded the following:

            //0: 3
            //1: 2
            //4: 4
            //6: 4
            //This means that there is a layer immediately inside the firewall(with range 3), a second layer immediately after that(with range 2), a third layer which begins at depth 4(with range 4), and a fourth layer which begins at depth 6(also with range 4).Visually, it might look like this:

            // 0   1   2   3   4   5   6
            //[ ][ ]... ... [ ]... [ ]
            //[ ][ ][ ][ ]
            //[ ][ ][ ]
            //                [ ][ ]
            //Within each layer, a security scanner moves back and forth within its range. Each security scanner starts at the top and moves down until it reaches the bottom, then moves up until it reaches the top, and repeats.A security scanner takes one picosecond to move one step. Drawing scanners as S, the first few picoseconds look like this:


            //Picosecond 0:
            // 0   1   2   3   4   5   6
            //[S][S]... ... [S]... [S]
            //[ ][ ][ ][ ]
            //[ ][ ][ ]
            //                [ ][ ]

            //Picosecond 1:
            // 0   1   2   3   4   5   6
            //[ ][ ]... ... [ ]... [ ]
            //[S][S][S][S]
            //[ ][ ][ ]
            //                [ ][ ]

            //Picosecond 2:
            // 0   1   2   3   4   5   6
            //[ ][S]... ... [ ]... [ ]
            //[ ][ ][ ][ ]
            //[S][S][S]
            //                [ ][ ]

            //Picosecond 3:
            // 0   1   2   3   4   5   6
            //[ ][ ]... ... [ ]... [ ]
            //[S][S][ ][ ]
            //[ ][ ][ ]
            //                [S][S]
            //Your plan is to hitch a ride on a packet about to move through the firewall.The packet will travel along the top of each layer, and it moves at one layer per picosecond.Each picosecond, the packet moves one layer forward(its first move takes it into layer 0), and then the scanners move one step.If there is a scanner at the top of the layer as your packet enters it, you are caught. (If a scanner moves into the top of its layer while you are there, you are not caught: it doesn't have time to notice you before you leave.) If you were to do this in the configuration above, marking your current position with parentheses, your passage through the firewall would look like this:

            //Initial state:
            // 0   1   2   3   4   5   6
            //[S][S]... ... [S]... [S]
            //[ ][ ][ ][ ]
            //[ ][ ][ ]
            //                [ ][ ]

            //Picosecond 0:
            // 0   1   2   3   4   5   6
            //(S)[S]... ... [S]... [S]
            //[ ][ ][ ][ ]
            //[ ][ ][ ]
            //                [ ][ ]

            // 0   1   2   3   4   5   6
            //()[ ]... ... [ ]... [ ]
            //[S][S][S][S]
            //[ ][ ][ ]
            //                [ ][ ]


            //Picosecond 1:
            // 0   1   2   3   4   5   6
            //[ ]()... ... [ ]... [ ]
            //[S][S][S][S]
            //[ ][ ][ ]
            //                [ ][ ]

            // 0   1   2   3   4   5   6
            //[ ](S)... ... [ ]... [ ]
            //[ ][ ][ ][ ]
            //[S][S][S]
            //                [ ][ ]


            //Picosecond 2:
            // 0   1   2   3   4   5   6
            //[ ][S](.)... [ ]... [ ]
            //[ ][ ][ ][ ]
            //[S][S][S]
            //                [ ][ ]

            // 0   1   2   3   4   5   6
            //[ ][ ](.)... [ ]... [ ]
            //[S][S][ ][ ]
            //[ ][ ][ ]
            //                [S][S]


            //Picosecond 3:
            // 0   1   2   3   4   5   6
            //[ ][ ]... (.)[ ]... [ ]
            //[S][S][ ][ ]
            //[ ][ ][ ]
            //                [S][S]

            // 0   1   2   3   4   5   6
            //[S][S]... (.)[ ]... [ ]
            //[ ][ ][ ][ ]
            //[ ][S][S]
            //                [ ][ ]


            //Picosecond 4:
            // 0   1   2   3   4   5   6
            //[S][S]... ... ()... [ ]
            //[ ][ ][ ][ ]
            //[ ][S][S]
            //                [ ][ ]

            // 0   1   2   3   4   5   6
            //[ ][ ]... ... ()... [ ]
            //[S][S][S][S]
            //[ ][ ][ ]
            //                [ ][ ]


            //Picosecond 5:
            // 0   1   2   3   4   5   6
            //[ ][ ]... ... [ ](.)[ ]
            //[S][S][S][S]
            //[ ][ ][ ]
            //                [ ][ ]

            // 0   1   2   3   4   5   6
            //[ ][S]... ... [S](.)[S]
            //[ ][ ][ ][ ]
            //[S][ ][ ]
            //                [ ][ ]


            //Picosecond 6:
            // 0   1   2   3   4   5   6
            //[ ][S]... ... [S]... (S)
            //[ ][ ][ ][ ]
            //[S][ ][ ]
            //                [ ][ ]

            // 0   1   2   3   4   5   6
            //[ ][ ]... ... [ ]... ()
            //[S][S][S][S]
            //[ ][ ][ ]
            //                [ ][ ]
            //In this situation, you are caught in layers 0 and 6, because your packet entered the layer when its scanner was at the top when you entered it.You are not caught in layer 1, since the scanner moved into the top of the layer once you were already there.

            //The severity of getting caught on a layer is equal to its depth multiplied by its range. (Ignore layers in which you do not get caught.) The severity of the whole trip is the sum of these values.In the example above, the trip severity is 0 * 3 + 6 * 4 = 24.

            //Given the details of the firewall you've recorded, if you leave immediately, what is the severity of your whole trip?
            Assert.AreEqual(1900, Day13.StarOne());
        }
        [TestMethod]
        public void Day13StarTwo()
        {
            //You need to cross a vast firewall.The firewall consists of several layers, each with a security scanner that moves back and forth across the layer. To succeed, you must not be detected by a scanner.

            //By studying the firewall briefly, you are able to record(in your puzzle input) the depth of each layer and the range of the scanning area for the scanner within it, written as depth: range.
            //Each layer has a thickness of exactly 1.A layer at depth 0 begins immediately inside the firewall; a layer at depth 1 would start immediately after that.

            //For example, suppose you've recorded the following:

            //0: 3
            //1: 2
            //4: 4
            //6: 4
            //This means that there is a layer immediately inside the firewall(with range 3), a second layer immediately after that(with range 2), a third layer which begins at depth 4(with range 4), 
            //and a fourth layer which begins at depth 6(also with range 4).Visually, it might look like this:

            // 0   1   2   3   4   5   6
            //[ ][ ]... ... [ ]... [ ]
            //[ ][ ][ ][ ]
            //[ ][ ][ ]
            //                [ ][ ]
            //Within each layer, a security scanner moves back and forth within its range. Each security scanner starts at the top and moves down until it reaches the bottom, then moves up until it
            //reaches the top, and repeats.A security scanner takes one picosecond to move one step. Drawing scanners as S, the first few picoseconds look like this:
            //Your plan is to hitch a ride on a packet about to move through the firewall.The packet will travel along the top of each layer, and it moves at one layer per picosecond.
            //Each picosecond, the packet moves one layer forward(its first move takes it into layer 0), and then the scanners move one step.If there is a scanner at the top of the layer as your packet enters it, you are caught. (If a scanner moves into the top of its layer while you are there, you are not caught: it doesn't have time to notice you before you leave.)K
            //In this situation, you are caught in layers 0 and 6, because your packet entered the layer when its scanner was at the top when you entered it.You are not caught in layer 1, 
            //since the scanner moved into the top of the layer once you were already there.

            //The severity of getting caught on a layer is equal to its depth multiplied by its range. (Ignore layers in which you do not get caught.) 
            //The severity of the whole trip is the sum of these values.In the example above, the trip severity is 0 * 3 + 6 * 4 = 24.

            //Given the details of the firewall you've recorded, if you leave immediately, what is the severity of your whole trip?
            Assert.AreEqual(3966414, Day13.StarTwo());
        }
        [TestMethod]
        public void Day14StarOne()
        {
            Assert.AreEqual(8316, Day14.StarOne());
            Assert.AreEqual(8108, Day14.StarOne("flqrgnkx"));

        }
        [TestMethod]
        public void Day14StarTwo()
        {
            Assert.AreEqual(1074, Day14.StarTwo());
            Assert.AreEqual(1242, Day14.StarTwo("flqrgnkx"));
        }
        [TestMethod]
        public void Day15StarOne()
        {
            Assert.AreEqual(567, Day15.StarOne(512, 191));
            Assert.AreEqual(588, Day15.StarOne(65, 8921));
        }
        [TestMethod]
        public void Day15StarTwo()
        {
            Assert.AreEqual(309, Day15.StarTwo(65, 8921));
            Assert.AreEqual(323, Day15.StarTwo(512, 191));
        }
        [TestMethod]
        public void Day18StarOne()
        {
            //You discover a tablet containing some strange assembly code labeled simply "Duet".Rather than bother the sound card with it, you decide to run the code yourself.Unfortunately, you don't see any documentation, so you're left to figure out what the instructions mean on your own.

            //It seems like the assembly is meant to operate on a set of registers that are each named with a single letter and that can each hold a single integer. You suppose each register should start with a value of 0.

            //There aren't that many instructions, so it shouldn't be hard to figure out what they do.Here's what you determine:

            //snd X plays a sound with a frequency equal to the value of X.
            //set X Y sets register X to the value of Y.
            //add X Y increases register X by the value of Y.
            //mul X Y sets register X to the result of multiplying the value contained in register X by the value of Y.
            //mod X Y sets register X to the remainder of dividing the value contained in register X by the value of Y(that is, it sets X to the result of X modulo Y).
            //rcv X recovers the frequency of the last sound played, but only when the value of X is not zero. (If it is zero, the command does nothing.)
            //jgz X Y jumps with an offset of the value of Y, but only if the value of X is greater than zero. (An offset of 2 skips the next instruction, an offset of - 1 jumps to the previous instruction, and so on.)
            //Many of the instructions can take either a register(a single letter) or a number.The value of a register is the integer it contains; the value of a number is that number.

            //After each jump instruction, the program continues with the instruction to which the jump jumped. After any other instruction, the program continues with the next instruction. Continuing(or jumping) off either end of the program terminates it.

            //For example:

            //set a 1
            //add a 2
            //mul a a
            //mod a 5
            //snd a
            //set a 0
            //rcv a
            //jgz a -1
            //set a 1
            //jgz a -2
            //The first four instructions set a to 1, add 2 to it, square it, and then set it to itself modulo 5, resulting in a value of 4.
            //Then, a sound with frequency 4(the value of a) is played.
            //After that, a is set to 0, causing the subsequent rcv and jgz instructions to both be skipped(rcv because a is 0, and jgz because a is not greater than 0).
            //Finally, a is set to 1, causing the next jgz instruction to activate, jumping back two instructions to another jump, which jumps again to the rcv, which ultimately triggers the recover operation.
            //At the time the recover operation is executed, the frequency of the last sound played is 4.

            //What is the value of the recovered frequency(the value of the most recently played sound) the first time a rcv instruction is executed with a non-zero value?
            Assert.AreEqual((long)9423, Day18.StarOne());
        }
        [TestMethod]
        public void Day18StarTwo()
        {

            Assert.AreEqual(213, Day18.StarTwo());
        }
    }
}
