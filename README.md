# Inteligentna-Analiza-Danych
Zadanie 1 z przedmiotu Inteligentna Analiza Danych

Zadaniem jest napisanie aplikacji przetwarzającej zbiory danych oraz wyliczającej i prezentującej różne ich charakterystyki. Każdy element przetwarzanego zbioru opisany jest przez zbiór atrybutów (cech): numerycznych bądź symbolicznych. Atrybuty zwykle dzieli się ze względu na na typ danych wartości je opisujących. Z tego względy dzielimy ja na cechy o wartościach przeliczalnych (dyskretnych) i nieprzeliczalnych (najczęściej ze zbioru ciągłego). Ponadto wśród atrybutów przeliczalnych wyróżnia się atrybuty nominalne, których specyficzność polega na braku naturalnego, algebraicznego opisu ich zbioru wartości (przeważnie skończonego), który przeważnie należy postrzegać jako nieuporządkowany zbiór ,,etykiet''.

Poniżej prezentowane są różne przykładowe charakterystyki oraz metody analizy, których wyliczenie może być przydatne w analizie przydzielonych zbiorów. Listy tej nie należy jednak traktować jako zamkniętej.

    Miary średnie klasyczne i pozycyjne
    Miary rozproszenia:
    Miary asymetrii
    Miary koncentracji:
    Normalizacja zmiennej losowej. Dopasowanie rozkładu i analiza danych w jego kontekście.
    Formułowanie i weryfikacja hipotez statystycznych.

Aplikacja powinna również umieć wyrysowywać histogram dla każdej cechy.

UWAGA:

    Wszystkie powyższe charakterystyki należy zaimplementować własnoręcznie (włącznie z obliczaniem histogramu).
    Istotną rolę w analizie pełnią atrybuty nominalne, które mogą posłużyć do podzielenia zbioru na klasy abstrakcji.
    Często stawianym w analizie danych pytaniem jest obecność zależności funkcyjnych między różnymi atrybutami - zbiorami atrybutów

Szczegółowe wymagania funkcjonalne:

    Aplikacja w trybie wsadowym powinna wyniki logować w formie tekstowej na konsolę lub do wskazanego pliku.
    Histogram należy zwizualizować w dowolnym formacie graficznym (sugerowany png). Warto przyjrzeć się w tym celu programowi gnuplot
    Interfejs graficzny powinien umożliwiać ładowanie zbiorów danych, wybór statystyk i cech do przeanalizowania, oraz proste przeglądania danych i wyników.

Dane do testowania wstępnego:

Iris Flower Data Set

Wymagania dotyczące sprawozdania:

W dalszej części zajęć każdej grupie przekazane zostaną zbiory danych do analizy. Z wykorzystaniem zaimplementowanych metod przeprowadzić obliczenia (wedle waszego uznania) prowadzące do jak najlepszego opisania przekazanego wam zbioru. Efektami analizy powinny byś w postaci sformułowanych w sprawozdaniu obserwacji i wniosków, powinny być podparte stosownymi obliczeniami zaprezentowanymi w czytelny i przejrzysty sposób, np. przy pomocy tabel i wykresów.


UWAGA: Aplikacja powinna wczytywać zbiory w formacie CSV w możliwością ustalenia separatora wartości.
UWAGA: Integralną częścią zadania pierwszego jest testowanie hipotez, opisane w odrębnym pliku pdf.
