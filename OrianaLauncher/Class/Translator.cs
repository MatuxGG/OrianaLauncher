using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrianaLauncher.Class
{
    public class Translator
    {
        public OrianaLauncher orianaLauncher;
        public Translator(OrianaLauncher orianaLauncher)
        {
            this.orianaLauncher = orianaLauncher;
        }

        public string lg(string w)
        {
            switch (this.orianaLauncher.config.language)
            {
                case "fr_FR":
                    return this.fr_FR(w);
                    break;
                default: // en_US
                    return w;
                    break;
            }
            return w;
        }

        public string fr_FR(string w)
        {
            switch (w)
            {
                case "Install":
                    return "Installer";
                    break;
                case "Update":
                    return "Mettre à jour";
                    break;
                case "Oriana Launcher by Matux - Designed by Asman - Mods & Content by Lunastellia":
                    return "Launcher Oriana par Matux - Design par Asman - Mods & Contenu par Lunastellia";
                    break;
                case "Downloading Client ...":
                    return "Téléchargement du Client ...";
                    break;
                case "Extracting Client ...":
                    return "Extraction du Client ...";
                    break;
                case "Downloading Mod ...":
                    return "Téléchargement du Mod ...";
                    break;
                case "Extracting Mod ...":
                    return "Extraction du Mod ...";
                    break;
                case "Completed !":
                    return "Terminé !";
                    break;
            }
            return w;
        }
    }
}
