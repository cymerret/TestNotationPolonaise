/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        static float Polonaise(String laFormule)
        {
            try
            {
                // définition du tableau
                string[] tableau = laFormule.Split(' ');
                int last = tableau.Length - 1;
                // parcours du tableau pour trouver le dernier opérateur
                for (int i = last; last > 0; i--)
                {
                    if (tableau[i] == "+" || tableau[i] == "-" || tableau[i] == "*" || tableau[i] == "/")
                    {
                        // réalisation du calcul
                        switch (tableau[i])
                        {
                            case "+":
                                tableau[i] = (float.Parse(tableau[i + 1]) + float.Parse(tableau[i + 2])).ToString();
                                break;
                            case "-":
                                tableau[i] = (float.Parse(tableau[i + 1]) - float.Parse(tableau[i + 2])).ToString();
                                break;
                            case "*":
                                tableau[i] = (float.Parse(tableau[i + 1]) * float.Parse(tableau[i + 2])).ToString();
                                break;
                            case "/":
                                if (tableau[i + 2] == "0")
                                {
                                    return float.NaN;
                                }
                                tableau[i] = (float.Parse(tableau[i + 1]) / float.Parse(tableau[i + 2])).ToString();
                                break;
                        }
                        // décalage des contenus des cases
                        for (int j = i + 1; j < last - 1; j++)
                        {
                            tableau[j] = tableau[j + 2];
                        }
                        // nettoyage des 2 dernières cases du tableau
                        tableau[last] = "";
                        tableau[last - 1] = "";
                        // actualisation
                        last -= 2;
                        i = last + 1;
                    }
                }
                return float.Parse(tableau[0]);
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
        static char Saisie(string message, char carac1, char carac2)
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
                Console.WriteLine("Entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat = " + Polonaise(laFormule));
                reponse = Saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }

    }
}
