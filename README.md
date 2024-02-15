# EventManagment - Platforma do organizacji wydarzeń

## Instrukcja uruchomienia projektu w środowisku lokalnym
1. Należy pobrać całe repozytorium w formie pliku .zip oraz wypakować go w wybranym przez nas folderze.
2. Otwórz plik 'EventManagment.sln' przy użyciu najnowszej wersji programu Visual Studio.
3. Po załadowaniu się rozwiązania przejdź kolejno do zakładki Widok -> Inne okna -> Konsola menedżera pakietów.
4. W konsoli kolejno należy wykonać podane niżej komendy:
	```
	Add-Migration Migration_Name
	Update-Database
	```
	[Wykonanie tych komend jest szczególnie ważne, gdyż bez nich nie zadziała nam połączenie z bazą danych]
5. Uruchomić projekt w wybranej przez siebie przeglądarce.

## Opis projektu
Użytkownicy będą mieli możliwość łatwego organizowania i uczestniczenia w różnorodnych
wydarzeniach..
- Baza danych przechowywuje informację o wydarzeniach, zarejestrowanych użytkownikach.
- Moduł rejestracji, logowania i wylogowania przy pomocy Identity. Użytkownikowi umożliwiona
jest funkcja edycji swojego konta, dodanie weryfikacji dwu-etapowej, zmianę hasła, adresu e-mail,
bądź też danych osobowych (nazwę, numer telefonu).
- Publiczne podstrony będą obejmować przegląd dostępnych wydarzeń, informacje o nich takie
jak miejsce, czas, datę rozpoczęcia wydarzenia, oraz zdjęcie.
- Podstrony tylko dla zalogowanych użytkowników będą pozwalały na dodawanie nowych
wydarzeń (wydarzenie zostaje dodane dopiero po jego potwierdzeniu przez administratora w
jego panelu), potwierdzenie wzięcia udziału w wydarzeniu, oraz zarządzanie swoimi wcześniej
utworzonymi wydarzeniami.
- Pierwsza strona dostępna tylko dla zalogowanych użytkowników pozwala na przeglądanie wydarzeń
utworzonych. Wyświetla wszystkie podstawowe dane [tytuł, opis, czas rozpoczęcia, lokalizację,
kto jest organizatorem], oraz możliwość edycji, usunięcią lub podejrzenia wydarzenia.
- Możliwość komentowania wydarzeń, oraz ich ocena po zakończeniu.