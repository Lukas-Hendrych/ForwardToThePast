using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library {
    public class Dialogs {

        private Dictionary<string, string> returnedDialog = new Dictionary<string, string>();
        public Dictionary<string, string> ReturnedDialog { get => returnedDialog; private set => returnedDialog = value; }

        public Dictionary<string, string> DialogsData(string storyLevel) {
            returnedDialog.Clear();
            switch (storyLevel) {
                case "1_1": {
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You woke up with a headache. You cannot remember where you are or how did you get here. " +
                        "Suddenly you hear a noise. Terrifying noise like someone is screaming. There is a stick next to you but you can also see a huge bolder.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "2");
                    ReturnedDialog.Add("bt1Text", "Pick up the stick");
                    ReturnedDialog.Add("bt1Name", "1_2");
                    ReturnedDialog.Add("bt1Blunt", "Stick");
                    ReturnedDialog.Add("bt2Text", "Hide behind the bolder");
                    ReturnedDialog.Add("bt2Name", "1_3");
                    break;
                }
                case "1_2": {
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "It is quite a good stick to defend yourself.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "2");
                    ReturnedDialog.Add("bt1Text", "Attack!");
                    ReturnedDialog.Add("bt1Name", "1_4");
                    ReturnedDialog.Add("bt2Text", "Hide behind the bolder");
                    ReturnedDialog.Add("bt2Name", "1_3");
                    break;
                }
                case "1_3": {
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You hid behind the boulder but now you can hear someone is approaching.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "2");
                    ReturnedDialog.Add("bt1Text", "Attack!");
                    ReturnedDialog.Add("bt1Name", "1_4");
                    ReturnedDialog.Add("bt2Text", "Stay hidden");
                    ReturnedDialog.Add("bt2Name", "1_5");
                    break;
                }
                case "1_4": {
                    ReturnedDialog.Add("tellerLevel", "99_1");
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You prepared your attack. As soon as you saw the silhouette, you aimed to the head with a successful hit! You see a man with a club. He looks like a brigand! " +
                        "You can also see an unconscious man laying on the ground.");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    break;
                }
                case "1_5": {
                    ReturnedDialog.Add("tellerLevel", "1_6");
                    ReturnedDialog.Add("tellerName", "Stranger");
                    ReturnedDialog.Add("tellerText", "You can come out now, I know you are there. Let's talk.");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    break;
                }
                case "1_6": {
                    ReturnedDialog.Add("tellerLevel", "1_7");
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You waited for a second but then you came out from behind the boulder. Now you can see a stranger who is laughing at you. An unconscious man is laying next to him. " +
                        "You just realized you had made a mistake. It's a brigand.");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    break;
                }
                case "1_7": {
                    ReturnedDialog.Add("tellerLevel", "99_1");
                    ReturnedDialog.Add("tellerName", "Brigand");
                    ReturnedDialog.Add("tellerText", "What are you wearing? Are you some kind of nobleman? Come here and put these chains on, you are my prisoner now!");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "1");
                    ReturnedDialog.Add("bt1Text", "Attack!");
                    ReturnedDialog.Add("bt1Name", "99_1");
                    break;
                }
                case "1_8": {
                    ReturnedDialog.Add("tellerLevel", "1_11");
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You fought well, Brigand is unconscious. You see the unconscious man is now standing.");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    break;
                }

                case "1_9": {
                    ReturnedDialog.Add("tellerLevel", "1_10");
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You see the brigand to prepare his final blow. Suddenly the unconscious man stands. He takes a rock and hits the brigand to the head.");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    break;
                }

                case "1_10": {
                    ReturnedDialog.Add("tellerLevel", "1_11");
                    ReturnedDialog.Add("tellerName", "Random voice");
                    ReturnedDialog.Add("tellerText", "You were lucky. You should be more careful. Next time you might not continue your adventure.");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    break;
                }

                case "1_11": {
                    ReturnedDialog.Add("tellerLevel", "1_12");
                    ReturnedDialog.Add("tellerName", "Conscious man");
                    ReturnedDialog.Add("tellerText", "Quick, we need to get out of here before his friends are back!");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    break;
                }

                case "1_12": {
                    ReturnedDialog.Add("tellerLevel", "1_14");
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You followed him outside. Now you are thinking what is happening. Why does this man look like he is from 15th century? And where is he " +
                        "taking you? Last time you remember you were going to sleep. INSIDE your apartment.");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    break;
                }
                case "1_14": {
                    ReturnedDialog.Add("tellerName", "Conscious man");
                    ReturnedDialog.Add("tellerText", "We are here. It is my home. By the way, my name is John and who might you be?");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "1");
                    ReturnedDialog.Add("bt1Text", "Player");
                    ReturnedDialog.Add("bt1Name", "1_15");
                    break;
                }
                case "1_15": {
                    ReturnedDialog.Add("tellerName", "John");
                    ReturnedDialog.Add("tellerText", "Ehm, ok? How did you get here? Oh, I might have an idea. Are you a merchant? You look like one, all these clothes you have. Are you from afar?");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "1");
                    ReturnedDialog.Add("bt1Text", "Czech Republic");
                    ReturnedDialog.Add("bt1Name", "1_16");
                    break;
                }
                case "1_16": {
                    ReturnedDialog.Add("tellerName", "John");
                    ReturnedDialog.Add("tellerText", "Republic? Ain't never heard of it. Here, have a drink. It's slivovice.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "2");
                    ReturnedDialog.Add("bt1Text", "Drink");
                    ReturnedDialog.Add("bt1Name", "1_17");
                    ReturnedDialog.Add("bt2Text", "Refuse");
                    ReturnedDialog.Add("bt2Name", "1_18");
                    break;
                }
                case "1_17": {
                    ReturnedDialog.Add("tellerLevel", "1_20");
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You accepted his drink. Now you feel like something happened inside you.\n\nYou just gained 5 attribute points!");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    ReturnedDialog.Add("attributePoints", "5");
                    break;
                }
                case "1_18": {
                    ReturnedDialog.Add("tellerName", "John");
                    ReturnedDialog.Add("tellerText", "Eh, doesn't matter. Here, I think it is yours. It was in the cave.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "1");
                    ReturnedDialog.Add("bt1Text", "Take combat manual");
                    ReturnedDialog.Add("bt1Name", "1_19");
                    break;
                }
                case "1_19": {
                    ReturnedDialog.Add("tellerLevel", "1_22");
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You took a look at the thing. It's a combat manual.\n\nYou just gained 2 more action points!");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    ReturnedDialog.Add("actionPoints", "2");
                    break;
                }
                case "1_20": {
                    ReturnedDialog.Add("tellerName", "John");
                    ReturnedDialog.Add("tellerText", "It's good, isn't it? Oh, here, I think it is yours. It was in the cave.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "1");
                    ReturnedDialog.Add("bt1Text", "Take combat manual");
                    ReturnedDialog.Add("bt1Name", "1_21");
                    break;
                }
                case "1_21": {
                    ReturnedDialog.Add("tellerLevel", "1_22");
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You took a look at the thing. It's a combat manual.\n\nIt's a shame you cannot read it right now because of that slivovice.");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    break;
                }
                case "1_22": {
                    ReturnedDialog.Add("tellerName", "John");
                    ReturnedDialog.Add("tellerText", "Hey, I am leaving. I don't want to spend any time longer here when I know there are brigands on the loose. I suggest you do the same." +
                        "As a token of friendship, take this dagger. It's nothing special but it will do the work.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "1");
                    ReturnedDialog.Add("bt1Text", "Take dagger");
                    ReturnedDialog.Add("bt1Name", "1_23");
                    ReturnedDialog.Add("bt1Sharp", "Rusty dagger");
                    break;
                }

                case "1_23": {
                    ReturnedDialog.Add("tellerLevel", "1_24");
                    ReturnedDialog.Add("tellerName", "John");
                    ReturnedDialog.Add("tellerText", "You should head out to the town. Take a right and go through the forest. Take care.");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    break;
                }
                case "1_24": {
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You left John's house. Hopefully someone in the town will help you understand what is happening. After a while you got to a crossroad. " +
                        "Left to a lake, right to a forest which leads to some town.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "2");
                    ReturnedDialog.Add("bt1Text", "Go left");
                    ReturnedDialog.Add("bt1Name", "1_25");
                    ReturnedDialog.Add("bt2Text", "Go right");
                    ReturnedDialog.Add("bt2Name", "1_30");
                    break;
                }
                case "1_25": {
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You took the left road which led you to the lake. There is nothing.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "1");
                    ReturnedDialog.Add("bt1Text", "Go back");
                    ReturnedDialog.Add("bt1Name", "1_26");
                    break;
                }
                case "1_26": {
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You are back at the crossroad. Left to the lake, right to a forest. Something is telling you to go to the lake.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "2");
                    ReturnedDialog.Add("bt1Text", "Go left");
                    ReturnedDialog.Add("bt1Name", "1_27");
                    ReturnedDialog.Add("bt2Text", "Go right");
                    ReturnedDialog.Add("bt2Name", "1_26***");
                    break;
                }
                case "1_27": {
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You are back at the lake. You see something behind the bush.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "1");
                    ReturnedDialog.Add("bt1Text", "Take it");
                    ReturnedDialog.Add("bt1Name", "1_28");
                    ReturnedDialog.Add("bt1Sharp", "Excalibur");
                    break;
                }
                case "1_28": {
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You just found some kind of sword. When you wield it you feel so much power.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "1");
                    ReturnedDialog.Add("bt1Text", "Go back");
                    ReturnedDialog.Add("bt1Name", "1_29");
                    break;
                }
                case "1_29": {
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You are back at the crossroad. There is no point to go to the lake again. You should head to the town through the forest.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "1");
                    ReturnedDialog.Add("bt1Text", "Go right");
                    ReturnedDialog.Add("bt1Name", "1_30");
                    break;
                }
                case "1_30": {
                    ReturnedDialog.Add("tellerLevel", "1_31");
                    ReturnedDialog.Add("tellerName", "");
                    ReturnedDialog.Add("tellerText", "You are going through the forest when suddenly you hear someone whistling. A man just appear from nowhere. He is now standing in fron of you.");
                    ReturnedDialog.Add("tellerContinue", "true");
                    ReturnedDialog.Add("buttonsCount", "0");
                    break;
                }
                case "1_31": {
                    ReturnedDialog.Add("tellerName", "Hobin Rood");
                    ReturnedDialog.Add("tellerText", "Well well well. Some richman just got lost in the forest. Unfortunatelly it is your unlucky day. Give me everything you have.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "1");
                    ReturnedDialog.Add("bt1Text", "Fight!");
                    ReturnedDialog.Add("bt1Name", "99_2");
                    break;
                }

                case "1_32": {
                    ReturnedDialog.Add("tellerName", "Lukáš Hendrych");
                    ReturnedDialog.Add("tellerText", "Thank you for playing Forward to the Past - demo version. I hope you enjoyed it.");
                    ReturnedDialog.Add("tellerContinue", "false");
                    ReturnedDialog.Add("buttonsCount", "0");
                    break;
                }

                case "99_1": {
                    ReturnedDialog.Add("enemyName", "Brigand");
                    ReturnedDialog.Add("enemyImage", "brigand");
                    ReturnedDialog.Add("enemyHealth", "70");
                    ReturnedDialog.Add("enemyMaxHealth", "80");
                    ReturnedDialog.Add("enemyStrength", "5");
                    ReturnedDialog.Add("enemyDexterity", "6");
                    ReturnedDialog.Add("enemyCritChance", "30");
                    ReturnedDialog.Add("enemyCritDamage", "20");
                    ReturnedDialog.Add("enemyBlockChance", "20");
                    ReturnedDialog.Add("enemyEvasionChance", "30");
                    ReturnedDialog.Add("enemyActionPoints", "2");
                    ReturnedDialog.Add("enemyWeapon", "Blunt");
                    ReturnedDialog.Add("enemyWeaponName", "Old club");
                    ReturnedDialog.Add("gameOver", "false");
                    ReturnedDialog.Add("fightWon", "1_8");
                    ReturnedDialog.Add("fightLost", "1_9");
                    break;
                }

                case "99_2": {
                    ReturnedDialog.Add("enemyName", "Hobin Rood");
                    ReturnedDialog.Add("enemyImage", "hobin_rood");
                    ReturnedDialog.Add("enemyHealth", "350");
                    ReturnedDialog.Add("enemyMaxHealth", "350");
                    ReturnedDialog.Add("enemyStrength", "16");
                    ReturnedDialog.Add("enemyDexterity", "28");
                    ReturnedDialog.Add("enemyCritChance", "20");
                    ReturnedDialog.Add("enemyCritDamage", "30");
                    ReturnedDialog.Add("enemyBlockChance", "10");
                    ReturnedDialog.Add("enemyEvasionChance", "40");
                    ReturnedDialog.Add("enemyActionPoints", "3");
                    ReturnedDialog.Add("enemyWeapon", "Sharp");
                    ReturnedDialog.Add("enemyWeaponName", "Rusty dagger");
                    ReturnedDialog.Add("gameOver", "true");
                    ReturnedDialog.Add("fightWon", "1_32");
                    ReturnedDialog.Add("fightLost", "1_24");
                    break;
                }

            }
            return ReturnedDialog;
        }
    }
}
