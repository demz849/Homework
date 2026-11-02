using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using windows_texted_based_rpg.civ;

Character chr = new Character();  weapon wep = new weapon();  string[] info,infofile; Random rnd = new Random(); town place = new town();


void main()
{
    
    begin();

    



    continueg(); 
    
  

}
 void continueg()
{
    int enct = rnd.Next(22);
    save();
    switch (enct)
    {
        case <=9: npcencounter(); break;
        case <=19: enemyencounter(); break;
        case <= 22:
      

            place.townn(chr,info);

            chr = place.chra;
            continueg(); break;
           
    }
}
string path;
void begin()
{

    string[] tnames = File.ReadAllLines(@".\\townnames.txt");
    int f = rnd.Next(tnames.Length);
    place.name = tnames[f];


    int pt = 12;
    Console.WriteLine("what is your name:");

    chr.name = Console.ReadLine();
    path = @".\\" + chr.name + ".txt";
    bool nw = true;
    if (File.Exists(path))
    {
        Console.WriteLine("a character with that name already exists. load[1] or overwrite[2]?");
        string choice = Console.ReadLine();
       

        if (choice.Trim() == "2")
        {
            File.Delete(path);
        }
        else
        {
            nw = false;
        }
    }
    int inp=0;


    if (nw)
    {

        Console.WriteLine("who do you hail our great saviour in r'lyeh with \n the Esoteric Order of Dagon[1] \n the Cult of Cthulhu[2] ");
        switch (Convert.ToInt32(Console.ReadLine())) {

            case 1 : Console.WriteLine("so you have chosen to fight for the deep ones"); chr.inventory[2] = 1; break;
            default: Console.WriteLine("the deathless masters welcome you"); chr.inventory[2] = 2;  break;
         
        }
        Thread.Sleep(500);
        Console.WriteLine("what is your age:");
        try
        {
            chr.age = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("enter a integer value" + e.Message);
            throw;
        }

        Thread.Sleep(500);
        Console.WriteLine("you have 12pt to distribute");
        Console.WriteLine("what is your con:");
        chr.con = Convert.ToInt32(Console.ReadLine());
        pt -= chr.con; Thread.Sleep(500);
        Console.WriteLine("what is your str:");
        chr.str = Convert.ToInt32(Console.ReadLine());
        pt -= chr.str; Thread.Sleep(500);
        Console.WriteLine("how brave are you");
        chr.bravery = Convert.ToInt32(Console.ReadLine());
        pt -= chr.bravery; Thread.Sleep(500);
        Console.WriteLine("how agile are you");
        chr.dex = Convert.ToInt32(Console.ReadLine());
        pt -= chr.dex; Thread.Sleep(500);
        if (pt < 0)
        {
            Console.Clear();
            Console.WriteLine("please only use 12 pt, try again");
            main();
        }
        
        Console.WriteLine("choose your weapon \n  stake[1] \n holy water[2] \n silver knife[3]");
         inp = Convert.ToInt32(Console.ReadLine()); Thread.Sleep(500);


    }

    wep.wepinit(inp); chr.inventory[3] = wep.id;
    chr.wep = wep;

    chr.maxhealth = chr.con * 7;
    chr.health = chr.maxhealth;
 
    if (nw)
    {
        Console.WriteLine("creating new character...");
        Thread.Sleep(500);
        info = ["name:" + chr.name, "age:" + chr.age, "health:" + chr.health, "con:" + chr.con, "str:" + chr.str, "bravery:" + chr.bravery, "dex:" + chr.dex, string.Join("\n", chr.invstr).ToString()];
        infofile = [chr.name.ToString(), chr.age.ToString(), chr.health.ToString(), chr.con.ToString(), chr.str.ToString(), chr.bravery.ToString(), chr.dex.ToString(), chr.inventory[0].ToString(), chr.inventory[1].ToString(), chr.inventory[2].ToString(), chr.inventory[3].ToString(), chr.inventory[4].ToString()];
        FileStream file = File.Create(path);
        file.Close();
        File.WriteAllText(path, string.Join("\n", infofile));
        Console.WriteLine("your character has been created stats: \n" + string.Join("\n", info));
    }
    else
    {
      
        Console.WriteLine("loading character"); load();
    }
    
    
    }



   

main();





void load()
{
    infofile = File.ReadAllLines(path);

    chr.name = infofile[0];

    chr.age = Convert.ToInt32(infofile[1]);
    chr.health = Convert.ToInt32(infofile[2]);
    chr.con = Convert.ToInt32(infofile[3]);
    chr.str = Convert.ToInt32(infofile[4]);
    chr.bravery = Convert.ToInt32(infofile[5]);
    chr.dex = Convert.ToInt32(infofile[6]);
    chr.inventory[0] = Convert.ToInt32(infofile[7]);
    chr.inventory[1] = Convert.ToInt32(infofile[8]);
    chr.inventory[2] = Convert.ToInt32(infofile[9]);
    wep.id = Convert.ToInt32(infofile[10]);
    chr.inventory[3] = wep.id;
    chr.inventory[4] = Convert.ToInt32(infofile[11]);
    wep.wepinit(wep.id); 
 
    chr.updateinv(wep);
    
    info = ["name:" + chr.name, "age:" + chr.age, "health:" + chr.health, "con:" + chr.con, "str:" + chr.str, "bravery:" + chr.bravery, "dex:" + chr.dex, "gold:" + chr.inventory[1],"wepid:" + wep.id, "inventory:"+ string.Join("\n",chr.invstr).ToString()];
    Console.WriteLine("your character has been loaded stats: \n" + string.Join("\n", info));
    chr.maxhealth = chr.con * 7;
    chr.health = chr.maxhealth;
    place.chra = chr;
    place.townn(chr,info);
  

}

void save()
{
    //Thread.Sleep(500);
    chr.wep = wep;
    chr.updateinv(wep);
    infofile = [chr.name.ToString(), chr.age.ToString(), chr.health.ToString(), chr.con.ToString(), chr.str.ToString(), chr.bravery.ToString(), chr.dex.ToString(), chr.inventory[0].ToString(), chr.inventory[1].ToString(), chr.inventory[2].ToString(), chr.inventory[3].ToString(), chr.inventory[4].ToString()];
    FileStream file = File.Create(path);
    file.Close();
    File.WriteAllText(path, string.Join("\n", infofile));
    place.chra = chr;

}








void enemyencounter()
{
   
    enemy en = new enemy();
   
    int h = rnd.Next(3);
    
    en.liv = true;
    switch (h)
    {
        case 0:
            en.namee = "ghost";
            en.health = 10;
            en.damage = 3;
            en.critchance = 10;
            en.grngmin = 1; en.grngmax = 3;
            en.type = enemyt.ghost;
            en.dese = ["pale","other worldyly","angry"];

            break;
        case 1:
            en.namee = "vampire";
            en.health = 15;
            en.damage = 5;
            en.critchance = 4;
            en.grngmin = 4; en.grngmax = 9;
            en.type = enemyt.vampire;
            en.dese = ["pale", "hungry", "old"];
            break;
        case 2:
            en.namee = "werewolf";
            en.health = 19;
            en.damage =6;
            en.critchance = 0;
            en.grngmin = 1; en.grngmax = 7;
            en.type = enemyt.werewolf;
            en.dese = ["fluffy", "lunar", "hungry"];
            break;
    }
    Console.WriteLine("there is something {0} lurking in the shadows what will  you do \n\n run[1] or fight[2]" ,en.dese[rnd.Next(en.dese.Length)]);
    int y = Convert.ToInt32(Console.ReadLine());
    if (y != 1)
    {
       
        bool isturn = true;
        
        do
        {
            Thread.Sleep(450);
            int prepared = 1;

            int pdp = 0;
            if (isturn)
            {
                Console.WriteLine("your turn: attack[1]  prepare[2] use item[3] or heal [4]");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    
                    case 4: Console.WriteLine(" \r you have {0} rations eat one? y/n", chr.inventory[0]);

                        if (Console.ReadLine().Trim().ToLower().ToCharArray()[0] == 'n')
                        {
                            continue;
                        }else if (chr.inventory[0]<=0)
                        {
                            Console.WriteLine("you do not have enough rations"); continue;
                        }
                        else
                        {
                            Console.WriteLine("you are healed 10 points"); chr.inventory[0]--; chr.health += 10;
                        }
                        
                        break;
                    case 2: prepared = 2; Console.WriteLine(" you brace yourself for impact"); break;
                    case 3:  Console.WriteLine(" inventory:{0} \n would you like to use your item? y/n", chr.invstr);
                        if (chr.inventory[4] == 0 || chr.inventory[4] == 2)
                        {
                            Console.WriteLine("you cant use this item");
                        }
                        else if (Console.ReadLine().Trim().ToLower().ToCharArray()[0] == 'y')
                        {
                            switch (chr.inventory[4])
                            {
                                case 1:
                                    pdp = 15; Console.WriteLine("you feel enraged");
                                    break;

                                case 3:
                                    prepared = 100;
                                    Console.WriteLine("you feel deathless");
                                    break;
                            }
                            chr.inventory[4] = 0;
                        }
                        else
                        {
                            continue;
                        }
                        
                        break;

                    default:
                        if (wep.damage==0)
                        {
                            wep.wepinit(chr.inventory[3]);
                        }
                        if (wep.vun == en.type)
                        {
                            pdp += chr.wep.damage;
                        }
                        if (chr.inventory[4]==2)
                        {
                            int crt = rnd.Next(100);

                            if (crt <= 30)
                            {
                                Console.WriteLine("your {} glows and you feel lucky", chr.wep.name);
                                pdp += 10;
                            }
                        }
                       else  if (wep.res == en.type)
                        {
                            Math.Clamp(pdp, 0, 100); pdp -= chr.wep.damage / 2;
                        }
                        Console.WriteLine("your turn:" + en.health.ToString() + "-" + (wep.damage + chr.str + pdp).ToString());
                        en.health -= (wep.damage + chr.str+pdp); break;
                }
             
               
                isturn =false;
            }
            else
            {
                int c = rnd.Next(100);
                if (c <= en.critchance)
                {
                    Console.WriteLine("enemy turn:"+chr.health.ToString() + "-" + (en.damage*3/prepared).ToString() +"CRITICAL HIT");
                    healthchange(-(en.damage * 3/prepared));
                }
                else
                {
                    Console.WriteLine("enemy:" + chr.health.ToString() + "-" + (en.damage/prepared).ToString());
                    healthchange(-(en.damage/prepared));
                }
                Thread.Sleep(rnd.Next(100,1000));
                isturn = true;
             
            }
            if (en.health <= 0)
            {
                en.liv = false;
            }

        } while (en.liv && chr.health > 0);

        if (en.liv == false) {
            int gf = rnd.Next(en.grngmin,en.grngmax);
            Console.WriteLine("the {0} crumples to the floor, fading to dust\n\n you gain {1} gold from the corpse", en.namee,gf);
            chr.inventory[1] += gf;
            healthchange(chr.con * 2);
        }
      
    }
    else
    {

       int u=  rnd.Next(1,100);

        if (u<= (chr.dex*15))
        {
            Console.WriteLine("you run from the shadows");

        }
        else
        {

            int dam = en.damage;
            Console.WriteLine("the {0}  catches up to you you lose {1}  life",en.namee,dam);
            healthchange(-dam);
            save();
        }
    }
        continueg();
}

void healthchange(int change ){

    chr.health += change;
    if (chr.health > chr.maxhealth)
    {
        chr.health = chr.maxhealth;
    }
 else if (chr.health <= 0)
{
    Console.WriteLine("you have died adventurer you lost {0} gold", chr.inventory[1]);
    chr.health = chr.maxhealth;
}


    
}
void npcencounter()
{
    npc dude = new npc();
    Random n = new Random();
    dude.dudegen = Convert.ToBoolean(n.Next(1));
    dude.health = n.Next(3, 20);
        dude.align = (alignment)n.Next(3);
    string pathn = @".\\NPCNAMES.txt";
    string[] namefile = File.ReadAllLines(pathn);
    dude.name = namefile[n.Next(namefile.Length)];
    Console.WriteLine("you have encountered a " + dude.name + " they seem " + dude.align + " what will you do \n\n run[1]  talk[2]");
    Random r = new Random();
    int opt = r.Next(3);
    switch (Convert.ToInt32(Console.ReadLine()))
    {
        case 1:; Console.WriteLine("you run from " + dude.name); 
            break;
        case 2:
            Console.WriteLine("hi:" + dude.name); int g = r.Next(1, 10);
            switch (dude.align)
            {
                case alignment.good:
                    switch (opt)
                    {
                        case 0:
                            chr.bravery++;
                            Console.WriteLine("you are filled with confidence");
                            break;
                        case 1:
                            chr.health += chr.con * r.Next(1, 3);
                            Console.WriteLine("you are healed and blessed");
                            break;
                        case 2:
                            Console.WriteLine("good fortune upon you: +" + g.ToString() + " gold added");
                            break;
                    }
                    break;
                case alignment.evil:
                    switch (opt)
                    {
                        case 0:
                            chr.bravery--;
                            Console.WriteLine("you are filled with FEAR");
                            break;
                        case 1:
                            healthchange(-chr.con);
                            int e = chr.health;
                            Console.WriteLine("you feel your lifeforce siphoned as your wallet gets heavier \n +" + e.ToString() + " gold");
                            chr.inventory[1] += chr.con;
                            break;
                        case 2:
                            Console.WriteLine("HAHAHAHAHAHa good luck adventure \n\n\n    youll need it"); enemyencounter();
                            break;
                    }
                    break;
                case alignment.neutral:
                    Console.WriteLine("on your way then");
                    break;
            }
            break;
              }
    continueg();
}






























class npc()
{
    public bool liv = true;
    public bool dudegen = true;
    public string name;
    public int health =10;
    public alignment align = alignment.good; 
}

   

 
    class enemy()
      
{
    public enemyt type;
    public string namee =" ";
   public int health = 15;
  public  int damage =0;
   public int critchance =1;
    public bool liv = true;
    public int grngmin=0, grngmax=5;
    public string[] dese;
}
class Character()
{
    public string name = "name";
    public weapon wep;
    public faith cult;
    public int age ,con ,str, dex, health, bravery;
  public  int maxhealth =20;
    public int[] inventory = new int[5];
    public string[] invstr = new string[5];
    int[] wepopt = [1, 2, 3];
   public void updateinv(weapon weapon)
    {
        switch (inventory[4])
        {
            case 1: cult = faith.cuthulu;  break;
            case 2: cult = faith.dagon;  break;
        }
        if (wepopt.Contains(wep.id))
        {
            inventory[3] = wep.id;
        }
        else
        {
            Console.WriteLine("errror");
        }
       
        invstr[0] = "rations:" + inventory[0];
        invstr[1] = "gold;" + inventory[1];
        invstr[2] = "faith:" + cult.ToString();
        invstr[3] = "weapon;" + wep.name;

        switch (inventory[4])
        {
            case 1: invstr[4] = "potion of attack"; break;
            case 2: invstr[4] = "token of critical hit "; break;
            case 3: invstr[4] = "potion of defense"; break;


            default:

                invstr[4] = "empty";
                break; 
        }



       
    }
    


    public void checkstats(string[] infofile)
    {
        Console.Clear();
        Console.WriteLine("stats: \n"+string.Join("\n", invstr));
        Console.WriteLine(string.Join("\n\t", infofile));
    }
}
class weapon()
{
    public int id;
    public string name;
    public int damage;

    public enemyt res;
    public enemyt vun;

    public int speed;



    public void wepinit(int inp)
    {
        id = inp;
        switch (inp)
        {
            case 3:
             
                vun = enemyt.werewolf;
                res = enemyt.vampire;
                name = "silver knife";
                damage = 5;
                break;
            case 2:
              
                vun = enemyt.ghost;
                res = enemyt.werewolf;
                name = "holy water";
                damage = 5;
                break;
            case 1:
              
                vun = enemyt.vampire;
                res = enemyt.ghost;
                name = "stake";
                damage = 5;
                break;

        }
    }
}
enum alignment
{
    good,
    evil,
    neutral
}
enum enemyt
{
    vampire,
    ghost,
    werewolf,
    gladiator

}
enum faith
{
   cuthulu,
   dagon 
}