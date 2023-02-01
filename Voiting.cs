using System;

namespace c__101_proj{
    internal class Program{
        public static void Main(){
            VoteSystem app = new VoteSystem();
            Console.Write("********** OYLAMA UYGULAMASINA HOSGELDINIZ **********\n- Oylama yapabilmek icin sisteme giris yapmaniz gerekmektedir!\n\n");
            app.init();
        }

        public class VoteSystem{
            List<User> users;
            Dictionary<int,int> votes;
            User ActiveUser;
            int totalVotes;

            public void init(){
                string[] userNames = {"melda" , "ferda" , "ahmet12" , "selimso" , "ahmetrifat"};
                votes = new Dictionary<int, int>();
                totalVotes = 0;
                foreach(string username in userNames){
                    if(!(users is object)){
                        users = new List<User>();
                    }
                    this.users.Add(new User(username));
                }
                foreach(int id in Enum.GetValues(typeof(Categories))){
                    votes.Add(id , 0);
                }
                Login();
            }
            public void Login(){
                if(ActiveUser is object){
                    Categories();
                    return;
                }
                Console.Clear();
                Console.Write("-----| GIRIS EKRANI |-----\n\n(1) Giris Yap\n(2) Kayit Ol\n-> ");
                string inp = Console.ReadLine() , username;
                switch(inp){
                    case "1":{
                        Console.Write("Kullanici Adi : ");
                        username = Console.ReadLine();
                        if(UserCheck(username)){
                            Console.Clear();
                            ActiveUser = GetUser(username);
                            Categories();
                        }else{
                            Console.WriteLine("X Kullanici Bulunamadi! Kayit Olmak icin 1, programdan cikmak icin 0'a basin.");
                            Selection:
                            switch(Console.ReadLine()){
                                case "0":{
                                    Environment.Exit(0);
                                    break;
                                }
                                case "1":{
                                    Register();
                                    break;
                                }
                                default:{
                                    Console.WriteLine("X Gecersiz islem girdiniz!");
                                    goto Selection;
                                }
                            }
                        }
                        break;
                    }
                    case "2":{
                        Register();
                        break;
                    }
                    default:{
                        Console.WriteLine("X Gecerli bir islem giriniz! {1,2}");
                        Login();
                        break;
                    }
                }
            }
            public void Register(){
                Console.Clear();
                Console.Write("-----| KAYIT EKRANI |-----\n\n");
                Selection:
                Console.Write("- Kullanici Adi: ");
                string username = Console.ReadLine();
                if(!UserCheck(username)){
                    User u = new User(username);
                    users.Add(u);
                    ActiveUser = u;
                    Login();
                }else{
                    Console.WriteLine($"{username} adinda bir kullanici mevcut. Lutfen baska kullanici adiile kayit olun!");
                    goto Selection; 
                }
            }
            public void Categories(){
                Console.WriteLine("Aktif kategoriler asagidaki gibidir.\n");
                ListCategories();
                Vote:
                Console.Write("\nHangi kategoriye oy vermek istiyorsunuz: ");
                int inp ;
                if(int.TryParse(Console.ReadLine() , out inp)){
                    if(inp <= Enum.GetNames(typeof(Categories)).Length){
                        if(!ActiveUser.Voted){
                            Vote(inp);
                            Console.WriteLine("Oyunuz Basariyla Alinmistir!");
                            users.Find(u => ActiveUser.ID == u.ID).Voted = true;
                        }else{
                            Console.WriteLine("Zaten bir oy kullandiniz!");
                        }
                        PrintCurrentStatus();
                        ReturnHome();
                    }
                }else{
                    Console.WriteLine("X Gecerli bir oy sayisi giriniz {1-8}.");
                    goto Vote;
                }
            }
            public void ListCategories(){
                for(int i=1; i<Enum.GetNames(typeof(Categories)).Length; i++){
                    Console.WriteLine($"({i}) {(Categories)i}");
                }
            }
            public void PrintCurrentStatus(){
                Console.WriteLine($"\n-- OY DURUMLARI --\n\n");
                foreach(var vote in votes.OrderByDescending(v => v.Value)){
                        float c = vote.Value;
                        float ratio = (c/this.totalVotes) * 100; 
                        Console.WriteLine($"%{ratio:F0}\t({vote.Value})\t{(Categories)vote.Key}");
                }
                Console.WriteLine($"\nTotal Votes : {totalVotes}");
            }
            public void Vote(int categoryID){
                foreach(var vote in votes){
                    if(vote.Key == categoryID){
                        votes[vote.Key] = vote.Value + 1;
                        totalVotes += 1;
                    }
                }
            }
            public bool UserCheck(string username){
                return (users.Find(u=>u.UserName == username) is null)?false:true;
            }
            public User GetUser(string username){
                return users.Find(u=>u.UserName == username);
            }
            public void ReturnHome(){
                Console.WriteLine("\n(1) Cikis Yap\n(2) Programi Kapat");
                string inp = Console.ReadLine();
                switch(inp){
                    case "1":{
                        ActiveUser = null;
                        Login();
                        break;
                    }
                    case "2":{
                        Environment.Exit(0);
                        break;
                    }
                    default:{
                        Console.WriteLine("X Gecersiz islem girdiniz! Lutfen {1 yada 2} olarak tuslayin.");
                        break;
                    }
                }
            }
        }
        public enum Categories{
            C=1,
            C_Sharp,
            C_Plus_Plus,
            Java,
            Python,
            JavaScript,
            Ruby,
            Swift,
            Kotlin
        }

        public class User{
            string username;
            int id;
            bool voted;
            DateTime createdDate;
            public string UserName { get => this.username; set => this.username = value;}
            public bool Voted { get => this.voted; set => this.voted = value;}
            public int ID { get => this.id;}
            public DateTime CreatedDate { get => this.createdDate;}
            public User(string name){
                Random rnd = new Random();
                this.id = rnd.Next(10000,99999);
                this.username = name;
                this.createdDate = DateTime.Now;
                this.voted = false;
            }
        }

    }
}
