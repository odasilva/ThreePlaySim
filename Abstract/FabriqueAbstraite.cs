/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 15/12/2014
 * Time: 14:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;

namespace ThreePlaySim.Abstract
{
	/// <summary>
	/// Description of FabriqueAbstraite.
	/// </summary>
	abstract public class FabriqueAbstraite
	{
        protected readonly  string xmlFile;
        protected  XmlDocument xmlDoc;
        protected string xmlPath = @"..\..\xml\";
        protected string imagePath = @"..\..\image\";

        public  FabriqueAbstraite(string filename)
        {
            xmlFile = filename;
            xmlDoc = new XmlDocument();
        }
	}
	
 }

