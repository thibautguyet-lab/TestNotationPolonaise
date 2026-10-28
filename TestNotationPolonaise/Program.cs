using System;

namespace TestNotationPolonaise
{
    class Program
    {
        static float Polonaise (string laFormule)
        {
            String phrase = laFormule;
            string[] tab = phrase.Split (' ');
            int position;
            try
            {
                while (true)
                {
                    int index = -1;

                    for (position = tab.Length - 1; position >= 0; position--)
                    {
                        if (tab[position] == "+" || tab[position] == "-" || tab[position] == "*" || tab[position] == "/")
                        {
                            index = position;
                            break;
                        }
                    }
                        if (position != -1)
                        {
                            if (tab[position] == "+")
                            {
                                tab[position] = (float.Parse(tab[position + 1]) + float.Parse(tab[position + 2])).ToString();
                            }
                            else
                            {
                                if (tab[position] == "-")
                                {
                                    tab[position] = (float.Parse(tab[position + 1]) - float.Parse(tab[position + 2])).ToString();
                                }
                                else
                                {
                                    if (tab[position] == "*")
                                    {
                                        tab[position] = (float.Parse(tab[position + 1]) * float.Parse(tab[position + 2])).ToString();
                                    }
                                    else
                                    {
                                        if (tab[position] == "/")
                                        {
                                                tab[position] = (float.Parse(tab[position + 1]) / float.Parse(tab[position + 2])).ToString();
                                        }
                                    }
                                }
                            }
                            //supprimer cases
                            for (int s = position +1; s < tab.Length - 2; s++)
                            {
                                tab[s] = tab[s + 2];
                            }
                            tab[tab.Length - 2] = " ";
                        }
                        else { break; }

                }
                float resultat = float.Parse(tab[0]);

                return resultat;
            }

            catch
            {
                return float.NaN;
            }
            
            
        }

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
