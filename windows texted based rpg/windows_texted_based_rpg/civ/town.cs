

using System.Net;

namespace windows_texted_based_rpg.civ
{
    class town()
    {
        public string name = "town";
        public alignment al = alignment.good;
        public Character chra = new Character();
        private Random rnd = new Random();

        public void townn(Character chr,string[] infofile)
        {
            chra = chr;
            bool intown = true;
            string dest = "bussling town with performs and markets galore";
            Console.WriteLine(" a sign looms infront of you reading welcome to {0}", name);
            Thread.Sleep(500);
            do
            {
                Thread.Sleep(500);


                Console.WriteLine("before you is a {0} where would you like to go there is: \n a food market[1] \n a church[2] \n a mage emporium[3] \n  blacksmiths[4]\n a combat lounge[5] \n check stats[6] \n leave[7]", dest);
                int pl = Convert.ToInt32(Console.ReadLine());

                switch (pl)
                {
                    case 1: fmarket(); break;

                    case 2: fchurch(); break;

                    case 3: fmage(); break;

                   

                    case 4: fsmith(); break;

                    case 5: fcombat(); break;

                    case 6: chra.checkstats(infofile); break;

                    case 7: intown = false; break;

                }


               
            } while (intown);

        }


        private void fcombat() {


            bool incombat = true;
            Console.WriteLine("you enter the combat lounge  \n\n would you like to fight? for gold and glory y/n");
            Character protochar = chra;
            if (Console.ReadLine().Trim().ToLower().ToCharArray()[0] =='y')
            {
                Console.WriteLine("the pits are not for everyone, goobye battle brother");
            }
            else
            {
                Console.WriteLine("your led to a gate, gaurds on each side   a sign reads choose your challenger [1-5]"); int difficulty = Convert.ToInt32(Console.ReadLine());
                do
                {
                    bool isturn = true;
                    enemy en = new enemy();
                    en.namee = "challenger";

                    en.health = difficulty * 10;
                    en.damage = difficulty + 2;
                    en.critchance = difficulty;
                    en.grngmin = difficulty; en.grngmax = (difficulty * 5) + 2;
                    en.type = enemyt.gladiator;
                    en.dese = ["muscular", "lean", "angry"];

                    int prepared = 1;

                    int pdp = 0;


                    do
                    {
                        if (isturn)
                        {
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {

                                case 4:
                                    Console.WriteLine(" \r you have {0} rations eat one? y/n", protochar.inventory[0]);

                                    if (Console.ReadLine().Trim().ToLower().ToCharArray()[0] == 'n')
                                    {
                                        continue;
                                    }
                                    else if (chra.inventory[0] <= 0)
                                    {
                                        Console.WriteLine("you do not have enough rations"); continue;
                                    }
                                    else
                                    {
                                        Console.WriteLine("you are healed 10 points"); protochar.inventory[0]--; protochar.health += 10;
                                    }

                                    break;
                                case 2: prepared = 2; Console.WriteLine(" you brace yourself for impact"); break;
                                case 3:
                                    Console.WriteLine(" inventory:{0} \n would you like to use your item? y/n", protochar.invstr);
                                    if (protochar.inventory[4] == 0 || protochar.inventory[4] == 2)
                                    {
                                        Console.WriteLine("you cant use this item");
                                    }
                                    else if (Console.ReadLine().Trim().ToLower().ToCharArray()[0] == 'y')
                                    {
                                        switch (protochar.inventory[4])
                                        {
                                            case 1:
                                                pdp = 15; Console.WriteLine("you feel enraged");
                                                break;

                                            case 3:
                                                prepared = 100;
                                                Console.WriteLine("you feel deathless");
                                                break;
                                        }
                                        protochar.inventory[4] = 0;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;

                                default:
                                    if (protochar.wep.damage == 0)
                                    {
                                        protochar.wep.wepinit(protochar.inventory[3]);
                                    }
                                    if (protochar.wep.vun == en.type)
                                    {
                                        pdp += protochar.wep.damage;
                                    }
                                    if (protochar.inventory[4] == 2)
                                    {
                                        int crt = rnd.Next(100);

                                        if (crt <= 30)
                                        {
                                            Console.WriteLine("your {} glows and you feel lucky", protochar.wep.name);
                                            pdp += 10;
                                        }
                                    }
                                    else if (protochar.wep.res == en.type)
                                    {
                                        Math.Clamp(pdp, 0, 100); pdp -= protochar.wep.damage / 2;
                                    }
                                    Console.WriteLine("your turn:" + en.health.ToString() + "-" + (protochar.wep.damage + protochar.str + pdp).ToString());
                                    en.health -= (protochar.wep.damage + protochar.str + pdp); break;
                            }
                        }
                        else
                        {

                        }
                    } while (isturn);
                    }
                    while (incombat);
                }
           


        }

        private void fmage()
        {
            bool inmage = true;
            int[] invs = [1, 2, 3];
            do
            {
                Thread.Sleep(500);
                int mcost = rnd.Next(10, 35);
                Console.WriteLine("welcome adevnturer to the mage emporium come browse my wares y/n");
                char ans = Console.ReadLine().ToCharArray()[0];


                

               


                switch (ans)
                {
                    case 'y':

                        Console.WriteLine(" oh thank you adventurer what would you like to buy?  \n potion of attack 5gp [1] \n token of critical hit 20gp [2] \n potion of defense 5gp [3] or not[5]");
                        int i = Convert.ToInt32(Console.ReadLine());
                       switch (i){

                            case 1: chra.inventory[1] -= 5; chra.inventory[4] = 1;Console.WriteLine("you have purchased a potion of attack"); break;
                            case 2: chra.inventory[1] -= 20; chra.inventory[4] = 2; Console.WriteLine("you have purchased an enchanted token of critical hit"); break;
                            case 3: chra.inventory[1] -= 5; chra.inventory[4] = 3; Console.WriteLine("you have purchased a potion of defense"); break;

                        }
                        Console.WriteLine("goodbye adventurer the mystical arts await me ");




                        break;
                    default:

                        Console.WriteLine("ah well adventurer come back any time"); inmage = false;
                        break;
                }



            } while (inmage);
        }
 







        private void fchurch()
        {
            bool inchurch = true;
            do
            {
                Thread.Sleep(500);
                int hcost = rnd.Next(10, 35);
                Console.WriteLine("ah welcome young adventurer come hail the great cuthulu and and be healed by his power \n\n would you like to bathe and be healed in his power? \n fuklly heal for {0} gold", hcost);
                char ans = Console.ReadLine().ToCharArray()[0];
                switch (ans)
                {
                    case 'y':
                        Console.WriteLine("Ph’nglui mglw'nafh Cthulhu R’lyeh, wgah’nagl fhtagn. \n(In his house at R’lyeh dead Cthulhu waits dreaming)");
                     

                        if (chra.inventory[1]-hcost >= 0)
                        {
                            chra.health = chra.maxhealth+1;

                            Console.WriteLine("you have been blessed and are now at {0} health",chra.health);
                            
                        }
                        else
                        {
                            Console.WriteLine("you dont have enough gold dear follower");


                        }
                        break;
                    default:

                        Console.WriteLine("ah well adventurer come back any time"); inchurch = false;
                        break;
                }



            } while (inchurch);
        }





        private void fsmith()
        {
            bool insmith = true;
             int[] invs = [1, 2, 3];
            do
            {
                Thread.Sleep(500);
                int hcost = rnd.Next(10, 35);
                Console.WriteLine("hello adventurer come to choose a new weapon? y/n");
                char ans = Console.ReadLine().ToCharArray()[0];


                string[] smithinv =["error"];

                switch (chra.wep.id) {

                    case 1: smithinv = ["holy water[2]", "silver knife[3]"]; break; 
                    
                    case 2: smithinv = ["stake[1]", "silver knife[3]"];  break;

                    case 3: smithinv = ["holy water[2]", "stake[1]"]; break;
                }

                    
                switch (ans)
                {
                    case 'y':

                        Console.WriteLine(" oh thank you adventurer what would you like to buy only 10gold each?    {0}   or not[5]",string.Join("\n\n",smithinv));
                        int i = Convert.ToInt32(Console.ReadLine());
                        if (invs.Contains(i) )
                        {
                            chra.wep.id = i; chra.wep.wepinit(i);
                        } else 
                        {
                            Console.WriteLine("goodbye adventurer the forge awaits me ");
                        }


                        break;
                    default:

                        Console.WriteLine("ah well adventurer come back any time"); insmith = false;
                        break;
                }



            } while (insmith);
        }



        private void fmarket()
        {
            bool inmarket = true;
            do
            {
                Thread.Sleep(500);
                int rtcost = rnd.Next(1, 5);
                Console.WriteLine("ah welcome young adventurer would you like to buy some rations only {0}   y/n", rtcost);
                char ans = Console.ReadLine().ToCharArray()[0];
                switch (ans)
                {
                    case 'y':
                        Console.WriteLine("oh thank you adventurer how many would you like");
                        int amount = Convert.ToInt32(Console.ReadLine());

                        if (chra.inventory[1] / amount >= 0)
                        {

                            inmarket = false;
                            Console.WriteLine("you spend {0} to gain {1} adept rations these gain 10 life back per use ", amount * rtcost, amount);
                            chra.inventory[1] -= (amount * rtcost);
                            chra.inventory[0] += amount;
                          
                        }
                        else
                        {
                            Console.WriteLine("you dont have enough gold");
                        }
                        break;
                    default:

                        Console.WriteLine("ah well adventurer come back any time"); inmarket = false;
                        break;
                }

            } while (inmarket);
        }




        

    }
}