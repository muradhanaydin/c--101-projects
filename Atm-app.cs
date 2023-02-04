using System;

namespace c__101_proj{
    internal class CashDispenser{
        static User user;
        static Logger logger = new Logger();
        static List<User> users = new List<User>();
        public static void Main(){
            users.Add(new User("4512632514876548" , 1234 , "Mehmet" , "Ince" , 157.78 ));
            users.Add(new User("8745365214789564" , 9874 , "Elif" , "Akbaba" , 1478.98 ));
            users.Add(new User("6325896552367541" , 0102 , "Soner" , "Pank" , 465.78 ));
            users.Add(new User("1784563298654123" , 4561 , "Elif" , "Kaya" , 2000));
            users.Add(new User("7894561237894561" , 1234 , "Admin" , "Root" , 0));
            Login();
        }
        static void MainScreen(){
                Console.WriteLine($"\nHosgeldiniz Syn.{user.Name} {user.Surname} | XTC BANK");
                Console.WriteLine($"Guncel bakiyeniz {user.Balance}TL {(user.Debt > 0?"| Borcunuz: "+user.Debt:"")}\n");
                Console.WriteLine($"Yapmak istediginiz islemi seciniz;\n");
                Console.WriteLine("(1) Para Cek");
                Console.WriteLine("(2) Para Yatirma");
                Console.WriteLine("(3) Borc Al");
                Console.WriteLine("(4) Borc Ode");
                Console.WriteLine("(5) Cikis");
                int opt = 0;
                do{
                    try{
                        opt = int.Parse(Console.ReadLine());
                        switch(opt){
                            case 1:{
                                Withdraw(user);
                                break;
                            }
                            case 2:{
                                Deposit(user);
                                break;
                            }
                            case 3:{
                                BarrowMoney(user);
                                break;
                            }
                            case 4:{
                                DebtPayment(user);
                                break;
                            }
                            case 5:{
                                logger.EndOfDayReport();
                                Login();
                                break;
                            }
                        }
                    }catch{
                        Console.WriteLine("Sadece rakam giriniz!");
                    }
                }while(true);
            }
            static void Login(){
                Console.WriteLine("XCT BANK'a Hosgeldiniz!");
                string card = "";
                int pin = 0;
                user = null;
                while(true){
                    try{
                        Console.Write("Kart numarasini giriniz: ");
                        card = Console.ReadLine();
                        user = users.Find(u => u.Cardnumber == card);
                        if(user is null){
                            Console.WriteLine($"Sistemde {card} numarasina ait bir kart bulunamadi!");
                            Console.WriteLine("Lutfen tekrar deneyin!");
                        }else{
                            break;
                        }
                    }catch{
                        Console.WriteLine($"Sistemde {card} numarasina ait bir kart bulunamadi!");
                    }
                }
                while(true){
                    try{
                        Console.Write("Sifrenizi giriniz: ");
                        pin = int.Parse(Console.ReadLine());
                        if(user.Pin == pin){
                            Console.Clear();
                            MainScreen();
                        }else{
                            Console.WriteLine("Girilen sifre yanlis! Lutfen tekrar deneyin!");
                        }
                    }catch{
                        Console.WriteLine("Bir hata olustu!");
                    }
                }
            }

            static void Deposit(User u){
                Console.Write("Ne kadar para yatirmak istiyorsunuz: ");
                double deposit = 0;
                deposit = Double.Parse(Console.ReadLine());
                u.Balance += deposit;
                Console.WriteLine($"{deposit}TL hesabiniza yatirildi. Guncel Bakiyeniz: {u.Balance}");
                logger.Deposit(u , deposit);
                MainScreen();
            }
            static void Withdraw(User u){
                Console.Write("Ne kadar para cekmek istiyorsunuz: ");
                double withdraw = 0;
                withdraw = Double.Parse(Console.ReadLine());
                if(u.Balance >= withdraw){
                    u.Balance -= withdraw;
                    Console.WriteLine($"{Withdraw}TL hesabinizdan cekildi. Guncel Bakiyeniz: {u.Balance}");
                    logger.Withdraw(u,withdraw);
                }else{
                    Console.WriteLine($"Hesabinizda {Withdraw}TL bulunmamaktadir. Guncel Bakiyeniz {u.Balance}Tl'dir.");
                }
                MainScreen();
            }
            static void DebtPayment(User u){
                Console.Write("Ne kadar borcunuzu odemek istiyorsunuz: ");
                double debt = 0;
                debt = double.Parse(Console.ReadLine());
                if(u.Balance < debt){
                    Console.WriteLine("Yeterli bakiye bulunmamaktadir! Lutfen yukleme yapiniz!");
                }else{
                    u.Balance -= debt;
                    u.Debt -= debt; 
                    Console.WriteLine($"{debt}TL borcunuz basariyla odenmistir!");
                    logger.Debt(u , debt);
                }
                MainScreen();
            }
            static void BarrowMoney(User u){
                Console.Write("Ne kadar borc almak istiyorsunuz: ");
                double debt = 0;
                debt = double.Parse(Console.ReadLine());
                u.Debt += debt;
                Console.WriteLine($"{debt}TL para basariyla verilmistir!");
                logger.Barrow(u , debt);
                MainScreen();
            }
    }
    public class Logger{
        Dictionary<string,string> logs = new Dictionary<string,string>();
        void Add(User u ,string log){
            if(logs.ContainsKey(u.Cardnumber)){
                logs[u.Cardnumber] += log;
            }else{
                logs.Add(u.Cardnumber , log);
            }
        }
        public void Deposit(User u , double mn){
            string log = $"{DateTime.Now.ToString()}\t{u.Cardnumber} nuamrali hesaba {mn}TL para eklendi!\n";
            Add(u , log);
        }
        public void Withdraw(User u , double mn){
            string log = $"{DateTime.Now.ToString()}\t{u.Cardnumber} numarali hesaptan {mn}TL para cekildi!\n";
            Add(u , log);
        }
        public void Debt(User u , double mn){
            string log = $"{DateTime.Now.ToString()}\t{u.Cardnumber} numarali hesap sahibinin {u.Debt}TL borcunun {mn}Tl'si odendi!\n";
            Add(u , log);
        }
        public void Barrow(User u , double mn){
            string log = $"{DateTime.Now.ToString()}\t{u.Cardnumber} numarali hesap sahibi {u.Debt}TL borc para cekildi!\n";
            Add(u , log);
        }
        public void EndOfDayReport(){
            try{
                string day = DateTime.Now.ToString("ddMMyy");
                string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\EOD_{day}.txt";
                string logtxt = "";
                if(!File.Exists(path)){
                    File.Create(path);
                }
                logtxt = GetOldLogs(path);
                StreamWriter  sw = new StreamWriter(path);
                foreach(var log in logs){
                    logtxt += log.Value;
                }
                sw.WriteLine(logtxt);
                sw.Close();
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
        string GetOldLogs(string path){
            StreamReader sr = new StreamReader(path);
            string log = "";
            string line = "";
            while(line == null){
                log += sr.ReadLine()+"\n";
            }
            sr.Close();
            return log;
        }
    }
    public class User{
        string name;
        string surname;
        string cardnumber;
        int pin;
        double balance;
        double debt = 0;
        public string Name { get => this.name; set => this.name = value; }
        public string Surname { get => this.surname; set => this.surname = value; }
        public string Cardnumber { get => this.cardnumber; set => this.cardnumber = value; }
        public int Pin { get => this.pin; set => this.pin = value; }
        public double Balance { get => this.balance; set => this.balance = value ;}
        public double Debt { get => this.debt; set => this.debt = value; }
        public User(string cardnumber , int pin , string name , string surname, double balance){
            this.name = name;
            this.surname = surname;
            this.cardnumber = cardnumber;
            this.pin = pin;
            this.balance = balance;
        }
    }
}