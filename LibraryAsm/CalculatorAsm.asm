;------Projekt jêzyki assemblerowe--------------------------------------------
;Rok akademicki 2021/2022
;Prowadz¹cy: mgr. in¿. Krzysztof Hanzel
;Autorka: Julia Merta 
;Grupa: 5 
;Sekcja: 1
;Temat projektu: Kalkulator macierzy
;Program ma realizowaæ podstawowe operacje takie jak dodawanie macierzy,
;odejmowanie macierzy oraz mno¿enie macierzy. 
;-----------------------------------------------------------------------------

.code
;Procedura dodawania wektorów
;rcx - d³ugoœæ tablicy
;rdx - wskaŸnik na macierz A
;r8 - wskaŸnik na macierz B
;r9 - wskaŸnik na macierz Result
AsmAddProc proc
push rbx ; odk³adamy niezbêdne wartoœci rejestrów na stos
push rbp
push rdi
push rsi
push r10
push r11
push r12
push r13
push r14
push r15
xor rbx, rbx ; zero do porównania czy pêtla siê zakoñczy³a
@obliczenie:
vmovups ymm0, [rdx] ;wczytanie 4 liczb typu double z pierwszej tablicy
vmovups ymm1, [r8] ; wczytanie 4 liczb typu double z drugiej tablicy
vaddpd ymm2, ymm1, ymm0 ; jednoczesne dodanie wektorów 4 liczb typu double i zapisanie wyniku w rejestrze ymm0
vmovups [r9], ymm2 ; zapisanie wyniku do tablicy wynikowej
add rdx, 32 ;przesuniecie wskaznikow wszystkich tablic o 32 bajty (typ double zajmuje 8 bajtów, a my pobraliœmy 4 razy 8 bajtów)
add r8, 32
add r9, 32
sub rcx, 32 ; odjêcie liczby bajtów od licznika pêtli
cmp rcx, rbx ; sprawdzamy przez porównanie z zerem w rejestrze rbx czy mamy jeszcze jakieœ bajty do przes³ania
jg @obliczenie ;jesli wieksze od 0 to skok
pop r15
pop r14
pop r13
pop r12
pop r11
pop r10
pop rsi ; zdejmujemy wartoœci rejestrów ze stosu
pop rdi
pop rbp
pop rbx
ret
AsmAddProc endp
;-------------------------------------------------------------------------------------------------------------------------
;Procedura odejmowania wektorów
;rcx - d³ugoœæ tablicy
;rdx - wskaŸnik na macierz A
;r8 - wskaŸnik na macierz B
;r9 - wskaŸnik na macierz Result

AsmSubProc proc
push rbx ; zapisanie wartoœci rejestrów na stosie
push rbp
push rdi
push rsi
push r10
push r11
push r12
push r13
push r14
push r15
xor rbx, rbx ;zeby miec jakies 0 do porownania
@obliczenie:
vmovups ymm0, [rdx] ;wczytanie 4 double z macierzy A
vmovups ymm1, [r8] ; wczytanie 4 double z macierzy B
vsubpd ymm2, ymm1, ymm0 ; odjêcie liczb, zapis wyniku do rejestru ymm2
vmovups [r9], ymm2 ; zapis wyniku do macierzy wynikowej
add rdx, 32 ;przesuniecie wskaznikow o 32 bajty (4 * sizeof(double))
add r8, 32
add r9, 32
sub rcx, 32 ; zmniejszenie licznika pêtli
cmp rcx, rbx ; porównanie czy s¹ jeszcze jakieœ liczby do odjêcia
jg @obliczenie ;jesli wieksze od 0 to skok 
pop r15
pop r14
pop r13
pop r12
pop r11
pop r10
pop rsi ; przywrócenie wartoœci rejestów 
pop rdi
pop rbp
pop rbx
ret
AsmSubProc endp
;-------------------------------------------------------------------------------------------------------------------------
;Procedura mno¿enia 
;rcx - liczba elementów w wierszu (macierz A) kolumnie (macierz B)
;rsi - zmienna pêtli
;rdx - wskaŸnik na wiersz macierzy A
;r8 - wskaŸnik na kolumnê macierzy B
;xmm0 - rejestr do którego zwracany jest wynik

AsmMultiplyProc proc
local temp: qword ; zmienna pomocnicza do zapisu wyniku ze stosu
push rbx ; zapisanie wartoœci rejestrów na stosie
push rbp
push rdi
push rsi
push r10
push r11
push r12
push r13
push r14
push r15
xor rbx, rbx ;zeby miec jakies 0 do porownania
xor rsi, rsi ; wyzerowanie licznika
fldz ;³adowanie zera na stos
@obliczenie:
fld qword ptr [rdx+rsi*8] ; ³aduje element z wiersza macierzy A na stos
fmul qword ptr[r8+rsi*8] ; mno¿enie elementu ze stosu (elementu macierzy A) przez element z kolumny macierzy B
faddp st(1), st; dodaj pierwszy element stosu 
inc rsi ;  zwiêkszamy licznik o jeden
cmp rsi, rcx ; sprawdzamy czy koniec pêtli
jl @obliczenie ;jesli wieksze od 0 to skok  
fstp temp ; zapisujemy wynik ze stosu do zmiennej
movsd xmm0, temp ; wynik posy³amy do rejestru xmm0
pop r15
pop r14
pop r13
pop r12
pop r11
pop r10
pop rsi ; przywracamy wartoœci rejestrów
pop rdi
pop rbp
pop rbx
ret
AsmMultiplyProc endp
end
