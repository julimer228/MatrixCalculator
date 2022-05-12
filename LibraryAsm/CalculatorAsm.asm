;------Projekt j�zyki assemblerowe--------------------------------------------
;Rok akademicki 2021/2022
;Prowadz�cy: mgr. in�. Krzysztof Hanzel
;Autorka: Julia Merta 
;Grupa: 5 
;Sekcja: 1
;Temat projektu: Kalkulator macierzy
;Program ma realizowa� podstawowe operacje takie jak dodawanie macierzy,
;odejmowanie macierzy oraz mno�enie macierzy. 
;-----------------------------------------------------------------------------

.code
;Procedura dodawania wektor�w
;rcx - d�ugo�� tablicy
;rdx - wska�nik na macierz A
;r8 - wska�nik na macierz B
;r9 - wska�nik na macierz Result
AsmAddProc proc
push rbx ; odk�adamy niezb�dne warto�ci rejestr�w na stos
push rbp
push rdi
push rsi
push r10
push r11
push r12
push r13
push r14
push r15
xor rbx, rbx ; zero do por�wnania czy p�tla si� zako�czy�a
@obliczenie:
vmovups ymm0, [rdx] ;wczytanie 4 liczb typu double z pierwszej tablicy
vmovups ymm1, [r8] ; wczytanie 4 liczb typu double z drugiej tablicy
vaddpd ymm2, ymm1, ymm0 ; jednoczesne dodanie wektor�w 4 liczb typu double i zapisanie wyniku w rejestrze ymm0
vmovups [r9], ymm2 ; zapisanie wyniku do tablicy wynikowej
add rdx, 32 ;przesuniecie wskaznikow wszystkich tablic o 32 bajty (typ double zajmuje 8 bajt�w, a my pobrali�my 4 razy 8 bajt�w)
add r8, 32
add r9, 32
sub rcx, 32 ; odj�cie liczby bajt�w od licznika p�tli
cmp rcx, rbx ; sprawdzamy przez por�wnanie z zerem w rejestrze rbx czy mamy jeszcze jakie� bajty do przes�ania
jg @obliczenie ;jesli wieksze od 0 to skok
pop r15
pop r14
pop r13
pop r12
pop r11
pop r10
pop rsi ; zdejmujemy warto�ci rejestr�w ze stosu
pop rdi
pop rbp
pop rbx
ret
AsmAddProc endp
;-------------------------------------------------------------------------------------------------------------------------
;Procedura odejmowania wektor�w
;rcx - d�ugo�� tablicy
;rdx - wska�nik na macierz A
;r8 - wska�nik na macierz B
;r9 - wska�nik na macierz Result

AsmSubProc proc
push rbx ; zapisanie warto�ci rejestr�w na stosie
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
vsubpd ymm2, ymm1, ymm0 ; odj�cie liczb, zapis wyniku do rejestru ymm2
vmovups [r9], ymm2 ; zapis wyniku do macierzy wynikowej
add rdx, 32 ;przesuniecie wskaznikow o 32 bajty (4 * sizeof(double))
add r8, 32
add r9, 32
sub rcx, 32 ; zmniejszenie licznika p�tli
cmp rcx, rbx ; por�wnanie czy s� jeszcze jakie� liczby do odj�cia
jg @obliczenie ;jesli wieksze od 0 to skok 
pop r15
pop r14
pop r13
pop r12
pop r11
pop r10
pop rsi ; przywr�cenie warto�ci rejest�w 
pop rdi
pop rbp
pop rbx
ret
AsmSubProc endp
;-------------------------------------------------------------------------------------------------------------------------
;Procedura mno�enia 
;rcx - liczba element�w w wierszu (macierz A) kolumnie (macierz B)
;rsi - zmienna p�tli
;rdx - wska�nik na wiersz macierzy A
;r8 - wska�nik na kolumn� macierzy B
;xmm0 - rejestr do kt�rego zwracany jest wynik

AsmMultiplyProc proc
local temp: qword ; zmienna pomocnicza do zapisu wyniku ze stosu
push rbx ; zapisanie warto�ci rejestr�w na stosie
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
fldz ;�adowanie zera na stos
@obliczenie:
fld qword ptr [rdx+rsi*8] ; �aduje element z wiersza macierzy A na stos
fmul qword ptr[r8+rsi*8] ; mno�enie elementu ze stosu (elementu macierzy A) przez element z kolumny macierzy B
faddp st(1), st; dodaj pierwszy element stosu 
inc rsi ;  zwi�kszamy licznik o jeden
cmp rsi, rcx ; sprawdzamy czy koniec p�tli
jl @obliczenie ;jesli wieksze od 0 to skok  
fstp temp ; zapisujemy wynik ze stosu do zmiennej
movsd xmm0, temp ; wynik posy�amy do rejestru xmm0
pop r15
pop r14
pop r13
pop r12
pop r11
pop r10
pop rsi ; przywracamy warto�ci rejestr�w
pop rdi
pop rbp
pop rbx
ret
AsmMultiplyProc endp
end
