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

Kolo vzniká v neaktivním stavu. Pouze jedno kolo může být aktivní.

#### dbo.ActiveNextRound

Zneaktivní aktivní kolo a aktivuje následující, nebo explicitně specifikované kolo.

Aktivní kolo nelze zneaktivně dokud není ke všem debatám v kole přirazen výsledek. Pouze jedno kolo může být aktivní.

#### dbo.DeleteRound

Smaže určené kolo a jeho debaty.

### Pohledy

#### dbo.OngoingMatches

Vrátí seznam debat z právě probíhajícího kola. Seznam aktivních debat je zobrazen skrze webovou aplikaci.

#### dbo.PlayerDetailLinks

Vrátí seznam osobních odkazů pro hráče pomocí který mohou přes webovou aplikaci sledovat svoje statistiky.

## Webová aplikace

Vyžaduje .NET 8 Runtime. Lze spustit v IIS nebo jako Azure App Service.

### Pohledy

#### Seznam probíhajících debat

URL: /

Zobrazuje seznam právě probíhajících debat včetně informace který hráč je v které debatě.

Dále zobrazuje aktuální tezi a info slide.

Automaticky se obnovuje každých 10 vteřin.

TODO: Místnosti

#### Detail hráče

URL: /player/{publicId:guid}

O daném hráči zobrazuje, zda je účasten v nějaké debatě, jeho body které utržil v předchozích debatách, součet bodů řečník a jeho skóre.

Je-li řečník účasten v debatě, zobrazuje i tezi a info slide.
