# Dips-Bank-Challenge
I forbindelse med at jeg søkte på en jobb hos DIPS AS fikk jeg denne oppgaven for å kunne få mulighet til å møte til intervju.
## Oppgaven var:
Lag en klasse Bank med følgende metoder i C#:
```
Account CreateAccount(Person customer, Money initialDeposit)
Account[] GetAccountForCustomer(Person customer)
void Deposit(Account to, Money amount)
void Withdraw(Account from, Money amount)
void Transfer(Account from, Account to, Money amount)
```
## Oppgaven skulle inneholde følgende brukerscenarioer:
### CreateAccount:
1. Lager konto for en gitt person med en gitt startbalanse. Navnet på kontoen er kundens navn etterfulgt løpenummer som starter på 1. Løpenummeret er pr kunde.
2. Påfølgende kontoer for personen skal ha samme navn, men høyere løpenummer
3. Konto skal ikke opprettes dersom personen har for lite penger til å dekke første
innskudd
### GetAccountForCustomer:
1. Henter alle konti for en gitt person
2. Gir en tom tabell dersom personen ikke har konto i banken
### Deposit:
1. Personen som eier kontoen setter pengene inn på kontoen
2. Penger skal ikke settes inn dersom personen har for lite
### Withdraw:
1. Personen som eier kontoen tar ut pengene fra kontoen
2. Pengene skal ikke tas ut dersom kontoen ikke har dekning for summen
### Transfer:
1. Overfører penger fra en konto til en annen
2. Penger skal ikke overføres dersom kontoen ikke har dekning for summen

For å teste at alt funket som det gjorde ble det også laget en enhetstest

## Hva som kan gjøres videre
Tanken jeg hadde mens jeg kodet var at denne kan jeg utvikle videre slik at det kunne hatt en GUI slik at alt ble testet gjennom den i tillegg til enhetstester.


