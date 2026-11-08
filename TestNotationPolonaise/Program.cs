using System;
using System.Collections.Specialized;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }
        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>

        static float Polonaise(string formule)
        {
            
            
            string[] polonaise = formule.Split(' ');

            int nbCase = polonaise.Length;

            while (nbCase > 1)
            {

                int k = nbCase - 1;
                while (k > 0 && polonaise[k] != "+" && polonaise[k] != "-"
                             && polonaise[k] != "*" && polonaise[k] != "/")
                {
                    k--;
                }

                if (polonaise[k] != "+" && polonaise[k] != "-"
                    && polonaise[k] != "*" && polonaise[k] != "/")
                {
                    return float.NaN;
                }

                if (k + 2 >= nbCase)
                {
                    return float.NaN;
                }

                if (!float.TryParse(polonaise[k + 1], out float c1) ||
                    !float.TryParse(polonaise[k + 2], out float c2))
                {
                    return float.NaN;
                }

                float result = 0;
                
                switch (polonaise[k])
                {
                    case "+" : result = c1 + c2; break;
                    case "-": result = c1 - c2; break;
                    case "*": result = c1 * c2; break;
                    case "/":
                        if (c2 == 0)
                        {
                            return float.NaN;
                        }
                        result = c1 / c2;
                        break;
                }

                polonaise[k] = result.ToString();

                for (int j = k + 1 ; j < nbCase - 2; j++)
                {
                    polonaise[j] = polonaise[j + 2];
                }
                nbCase -= 2;

            }

            if (!float.TryParse(polonaise[0], out float final))
            {
                return float.NaN;
            }
            return final;
        }
        
        
        
        
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
