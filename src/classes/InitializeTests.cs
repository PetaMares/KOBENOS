﻿using kobenos.category.test;
using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.category
{
    class InitializeTests
    {
        List<ICategory> categories = new List<ICategory>();
        public List<Category> initilize()
        {
            List<Category> categories = new List<Category>();
            Category general = new Category("Všeobecná nastavení", "Všeobecná nastavení", "Všeobecná nastavení");
            Result checkSystemTest = new CheckSystemTest("Kontrola verze Windows", "Kontrola verze Windows", "Kontrola typu a aktivace Windows");
            general.addTest(checkSystemTest);
            Result section4Test = new Section4Test("Kontrola nastavení BIOS", "Kontrola nastavení BIOS/UEFI", "Kontrola nastavení BIOS/UEFI");
            general.addTest(section4Test);
            Result section6Test = new Section6Test("Kontrola deaktivace ReadyBoost", "Kontrola deaktivace ReadyBoost", "Kontrola deaktivace ReadyBoost");
            general.addTest(section6Test);
            Result section7Test = new Section7Test("Kontrola deaktivace WLAN", "Kontrola deaktivace WLAN", "Kontrola deaktivace WLAN");
            general.addTest(section7Test);
            Result section8Test = new Section8Test("Kontrola deaktivace Bluetooth", "Kontrola deaktivace Bluetooth", "Kontrola deaktivace Bluetooth");
            general.addTest(section8Test);
            Result section9Test = new Section9Test("Nastavení systémových služeb", "Nastavení systémových služeb", "Nastavení systémových služeb");
            general.addTest(section9Test);
            Result section10Test = new Section10Test("Kontrola výchozího nastavení práv k souboru a složkám", "Kontrola výchozího nastavení práv k souboru a složkám", "Kontrola výchozího nastavení práv k souboru a složkám");
            general.addTest(section10Test);
            Result section11Test = new Section11Test("Kontrola uživatelských účtů a skupin podle doporučené tabulky", "Kontrola uživatelských účtů a skupin podle doporučené tabulky", "Kontrola uživatelských účtů a skupin podle doporučené tabulky");
            general.addTest(section11Test);
            Result section12Test = new Section12Test("Kontrola nastavení práv k tiskárnám", "Kontrola nastavení práv k tiskárnám", "Kontrola nastavení práv k tiskárnám");
            general.addTest(section12Test);
            Result section13Test = new Section13Test("Kontrola odinstalovaných nepotřebných aplikací", "Kontrola odinstalovaných nepotřebných aplikací", "Potvrzovací okno, jestli byly odinstolovávány nepotřebné aplikace");
            general.addTest(section13Test);

            Category passwords = new Category("Hesla", "Hesla", "Hesla");
            Result section14Test = new Section14Test("Kontrola zásad hesel", "Kontrola zásad hesel", "Kontrola zásad hesel");
            passwords.addTest(section14Test);
            Result section15Test = new Section15Test("Kontrola zásad uzamčení účtů", "Kontrola zásad uzamčení účtů", "Kontrola zásad uzamčení účtů");
            passwords.addTest(section15Test);

            Category localSetting = new Category("Místní zásady", "Místní zásady", "Místní zásady");
            Result section16Test = new Section16Test("Kontrola zásad auditování", "Kontrola zásad auditování", "Kontrola zásad auditování");
            localSetting.addTest(section16Test);
            Result section17Test = new Section17Test("Kontrola přiřazení uživatelských práv", "Kontrola přiřazení uživatelských práv", "Kontrola přiřazení uživatelských práv");
            localSetting.addTest(section17Test);
            Result section18Test = new Section18Test("Kontrola možností zabezpečení", "Kontrola možností zabezpečení", "Kontrola možností zabezpečení");
            localSetting.addTest(section18Test);

            Category eventProtocol = new Category("Protokol událostí", "Protokol událostí", "Protokol událostí");
            Result section19Test = new Section19Test("Nastavení služeb protokolu událostí", "Nastavení služeb protokolu událostí", "Nastavení služeb protokolu událostí");
            eventProtocol.addTest(section19Test);

            Category computerSetting = new Category("Konfigurace počítače", "Konfigurace počítače", "Konfigurace počítače");
            Result section20Test = new Section20Test("Přihlášení k systému Windows", "Přihlášení k systému Windows", "Přihlášení k systému Windows");
            computerSetting.addTest(section20Test);
            Result section21Test = new Section21Test("OneDrive", "OneDrive", "OneDrive");
            computerSetting.addTest(section21Test);
            Result section22Test = new Section22Test("Zásady automatického přehrávání", "Zásady automatického přehrávání", "Zásady automatického přehrávání");
            computerSetting.addTest(section22Test);
            Result section23Test = new Section23Test("Přihlášení", "Přihlášení", "Přihlášení");
            computerSetting.addTest(section23Test);
            Result section24Test = new Section24Test("Zásady skupiny", "Zásady skupiny", "Zásady skupiny");
            computerSetting.addTest(section24Test);
            Result section25Test = new Section25Test("Omezení pro instalaci zařízení", "Omezení pro instalaci zařízení", "Omezení pro instalaci zařízení");
            computerSetting.addTest(section25Test);
            Result section26Test = new Section26Test("Přístup k vyměnitelnému uložišti", "Přístup k vyměnitelnému uložišti", "Přístup k vyměnitelnému uložišti");
            computerSetting.addTest(section26Test);
            Result section27Test = new Section27Test("Obnovení", "Obnovení", "Obnovení");
            computerSetting.addTest(section27Test);
            Result section28Test = new Section28Test("Obnovení systému", "Obnovení systému", "Obnovení systému");
            computerSetting.addTest(section28Test);
            Result section29Test = new Section29Test("Přizpůsobení", "Přizpůsobení", "Přizpůsobení");
            computerSetting.addTest(section29Test);

            Category userSetting = new Category("Konfigurace uživatele", "Konfigurace uživatele", "Konfigurace uživatele");
            Result section30Test = new Section30Test("Přizpůsobení", "Přizpůsobení", "Přizpůsobení");
            userSetting.addTest(section30Test);
            Result section31Test = new Section31Test("Průzkumník Windows", "Průzkumník Windows", "Průzkumník Windows");
            userSetting.addTest(section31Test);

            categories.Add(general);
            categories.Add(passwords);
            categories.Add(localSetting);
            categories.Add(eventProtocol);
            categories.Add(computerSetting);
            categories.Add(userSetting);

            return categories;
        }
    }
}
