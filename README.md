# Debatní mayhem

## Databáze

Pro spuštění je potřeba Azure SQL nebo SQL Server 2019 databáze.

### Konfigurace

Do SQL tabulky `dbo.Configuration` je potřeba přidat záznamy
- `K` - maximální možný zisk nebo ztráta skóre za kolo (pozn. skóre za body týmu a body řečníka se udělují smostatně)
- `TenToOneOdds` - hodnota reprezentující rozdíl skóre dvou stran tak, aby pravděpodonost výhry první strany byla 10:1

Do SQL tabulky `ScoreToSpearPointsIntervals` je potřeba přidat intervaly pro převod skóre na očekávané body řečníka.

Do SQL tabulky `Players` je potřeba přidat hráče. Počet aktivních hráčů musí být dělitelný 8 beze zbytku.

### Procedury

#### dbo.CreateNewRound

Vytvoří nové kolo a rozřadí aktivní hráče do debat. Při rozřazování zohledňuje, zda hráč již hrál danou pozici (např. první vláda). 

Kolo vzniká v neaktivním stavu a se skrytou tezí. Pouze jedno kolo může být aktivní.

#### dbo.DeleteRound

Smaže určené kolo a jeho debaty.

#### dbo.ActiveNextRound

Zneaktivní aktivní kolo a aktivuje následující, nebo explicitně specifikované kolo. První kolo musí být aktivováno explicitně.

Aktivní kolo nelze zneaktivně dokud není ke všem debatám v kole přirazen výsledek. Pouze jedno kolo může být aktivní.

Aktivace kola skryje tezi i když byla předtím odhalená.

#### dbo.RevealActiveRoundInfoSlide

Odhalí info slide právě běžícího kola. Vrací error pokud právě běžící kolo nemá info slide.

#### dbo.RevealActiveRoundTopic

Odalí tezi právě běžícího kola. Vrací error pokud právě běžící kolo má info slide, který není odhalen.

#### dbo.ScoreMatch

Nastaví konkrétní debatě výsledek a přepočítá skóre jejích učastníků.

## Webová aplikace

Vyžaduje .NET 8 Runtime. Lze spustit v IIS nebo jako Azure App Service.

Je potřeba dodat connection string jménem `MayhemDatabase` přes appsettings.json (sekce `ConnectionStrings`) nebo env proměnou (`ConnectionStrings:MayhemDatabase`).

Pro tisk kartiček lze nastavit v konfiguraci položku `PrintingKey`. Pokud je vyplněná, tiskařský endpoint vyžadue query-string `key` odpovídající této hodnotě.

### Pohledy

Všechny pohledy se obnovuje každých 10 vteřin.

#### Seznam probíhajících debat

URL: /

Zobrazuje seznam právě probíhajících debat včetně informace který hráč je v které debatě, a kde debata probíhá.

Dále zobrazuje aktuální tezi a info slide.

#### Detail hráče

URL: /player/{publicId:guid}

O daném hráči zobrazuje, zda je účasten v nějaké debatě, jeho body které utržil v předchozích debatách, součet bodů řečník a jeho skóre.

Dále zobrazuje historii debat kterých se účastnil a jejich výsledek.

Je-li řečník účasten v debatě, zobrazuje ve vztahu k této debatě informace shodné se seznamem probíhajících debat.

### Tisk kartiček

URL: /print/{roundId:int}?key=

Pro každé kolo lze pro rozhodčí vygenerovat kartičky. Každá kartička odpovídá jedné debatě.

Kartička obsahuje tezi daného kola a proto je tento endpoint potenciálně nebezpečný.
Tím že ID kol jsou vzestupná řada `int`, lze narozdíl od endpointu detailu hráče tipnout další ID v pořadí, a tak získat tezi.
Proto je vhodné zabezpečit endpoint přes `PrintingKey` a jeho hodnotu udržovat v tajnosti.
