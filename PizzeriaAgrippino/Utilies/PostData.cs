using PizzeriaAgrippino.Models;
namespace PizzeriaAgrippino.Utilies
{
    public static class PostData 
    {
        //è una classe statica perché deve solo restituirci i post e nient'altro 

        private static List<Pizze> pizzes;

        //creiamo un metodo prende la mia lista di post e la restituisce
        //essendo una classe statica per far dunzonare tutto dobbiamo inserire PostData.Pizzes, altrimenti non funziona 
        // Dopo aver creato tutto il metodo possiamo dare nuove direttive a Pizzacontroller
        public static List<Pizze> GetPosts()
        {
            if (PostData.pizzes != null)
            {
              return PostData.pizzes; //se la lista è piena ritorna indietro i post 
            } 

            //se una lista è vuota devo dicharare io cosa fare, instazio un for 
            List<Pizze> NuovaPizza = new List<Pizze> ();

                       
                Pizze  Margherita = new Pizze (0,"~/img_pizza/Margherita.png", "Margherita", "Pomodoro San Marzano D.O.P., fior di latte di Agerola, basilico e olio evo.", 4.00 );
                NuovaPizza.Add(Margherita);
                Pizze AmatricianaCroccante = new Pizze(1, "~/img_pizza/Amatriciana_Croccante.png", "Amatriciana Croccante","Pizza croccante cotta a bassa temperatura con pomodorini del piennolo gialli e rossi sfumati con vino bianco guanciale di cinghiale pecorino romano e provola di agerola.", 10.00);
                NuovaPizza.Add(AmatricianaCroccante);
                Pizze AmericanParty = new Pizze(2, "~/img_pizza/American_Party.png", "American Party", "Becon croccante cheddar provola di Agerola salsiccia sbriciolata crunch di cipolla e salsa bbq.", 9.00);
                NuovaPizza.Add(AmericanParty);
                Pizze Carrettiera = new Pizze(3, "~/img_pizza/Carrettiera.png", "Carrettiera", "Salsiccia di maialino nero, probola IGP, fiarielli", 7.50) ;
                NuovaPizza.Add(Carrettiera);
                Pizze Ereditadellanonna = new Pizze(4, "~/img_pizza/Eredita_Della_Nonna.png", "Eredita della nonna", "Parmigiana di melanzane ricetta tradizionale della nonna, salsiccia di maialino nero sbriciolata, provola affumicata di Agerola, basilico, scaglie di Parmigiano Reggiano 24 mesi e olio evo.", 8.00);
                NuovaPizza.Add(Ereditadellanonna);
                Pizze Fugadalfuturo = new Pizze(5, "~/img_pizza/Fuda_Dal_Futuro.png", "Fuga da futuro", " Vellutata di zucchine, fior di latte di Agerola, salmone affumicato, ciuffetti di ricotta di fuscella, zest di limone ed olio evo.",12.00);
                NuovaPizza.Add(Fugadalfuturo);
                Pizze Genovesedicinghiale = new Pizze(6, "~/img_pizza/Genovese_Di_Cinghiale.png", "Genovese di cinghiale", "Genovese di cinghiale cotta a bassa temperatura per 24h, provola di agerola, scaglie di parmigiano, olio evo e basilico.", 9.00);
                NuovaPizza.Add(Genovesedicinghiale);
                Pizze KFC = new Pizze(7, "~/img_pizza/KFC.png", "KFC", "  Salsa aromatizzata ai peperoni, provola di Agerola, pollo impanato e fritto, chips di patate, spuma di maionese, basilico e olio evo.", 8.00);
                NuovaPizza.Add(KFC);
                Pizze London19 = new Pizze(8, "~/img_pizza/London_19.png", "London 1.9", "Bacon croccante, fior di latte di Agerola, all'uscita: chips di patate, fonduta di formaggio e olio evo.", 8.00);
                NuovaPizza.Add(London19);
                Pizze PestoePomodori = new Pizze(9, "~/img_pizza/Pesto_Pomodorini.png", "Pesto e pomodori", "Pesto di basilico, pomodorini del piennolo, provola di agerola IGP, basilico, scaglie di parmigiano e olio evo.", 9.00);
                NuovaPizza.Add(PestoePomodori);
                Pizze Trezucca = new Pizze(10, "~/img_pizza/Tre_Zucca.png", "Tre zucca", "Fondo della pizza con crema di zucca, zucca arrostita,tocchettini di zucca, bacon, provola IGP e olio evo.", 11.50);
                NuovaPizza.Add(Trezucca);
                Pizze Orangeisthenewblack = new Pizze(11, "~/img_pizza/Zuccotta.png", "Orange is the new black", "Crema di zucca, provola affummicata di agerola, melanzane arrostite, salsiccia di maialino nero sbriciolata, scaglie di parmigiano Reggiano 24 mesi, basilico e olio evo.", 8.00);
                NuovaPizza.Add(Orangeisthenewblack);
            

             //devo salvare il nuovo oggetto che ho creato dentro la lista statica così
             PostData.pizzes = NuovaPizza;
            //restituisco poi le pizze 
             return PostData.pizzes;

        }
    }
}
