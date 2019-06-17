﻿#				 Galaxy

### 1.	Опис на апликацијата:
Нашиот тип изработи игра инспирирана од играта Bejeweled (https://www.match3games.com/game/Bejeweled+2). Основната идеа на играта ја проширивме со неколку нови функционалности, додавајќи опција за помош (Hint) и мини игри (Helpers) кои нудат помош при играње на главната игра.

### 2.	Упатство за играње на играта: 
По оклучување на апликацијата се појавува формата од слика 1, на која се прикажани три копчиња:


копче 1 – New Game започнување на нова игра </br>
копче 2 – How to Play можност за преглед на правилата за играње на играта </br>
копче 3 – High Scores  за приказ на најдобрите резултати од претходните играчи <br>
![Main menu](/Images/MainMenu.png)<br>
*слика 1*

#### 2.1	New Game
Со избор на копчето New Game се отвара формата од слика 2 и играта започнува. Играчот има 4 минути да го постигне највисокиот резултат. 
Доколку во било кој момент се случи да нема можни комбинации се прави преместување на сликичките при што се гарантира дека ќе има барем еден можен следен потег. 
Играчот иста така може да ги користи и копчиња од тастурата при играње. Буквата S е за вклучување и исклучување за звукот, H е за Hint , N е за нова игра, и P за пауза.
<br>![Game](/Images/Game.png)<br>
*слика 2*

#### 2.2	How to play
Со клик на How to play копчето се појавува форма во која се објаснети правилата на играта.
Користејќи ги копчињата Next, Prev и  Skip играчот може да се движи низ формата.
Копчето Next го носи играчот на следната слика и објаснување, Prev го враќа назад а со Skip може да ги скокне објаснувањета и да започе со играње.
<br>![How To Play](/Images/HowToPlay.png)<br>
*слика 3*

#### 2.3	Highs Scores
Во играта се зачувуваат имињата и резултатие на 10те најдобри играчи. По завршувањето на играта се појавува форма во која го пишува резултатот на играчот и ако тој сака да си го зачува треба да  го внесе своето име при што се појавува формата од слика 4 во која се покажуваат сортирани по најголемиот резултат резулатите на предходните најдобри играчи. 
За имплементација на оваа функционалност креиравме класа Score, во која се чува името и резултатот на играчот.
Со FileStream и TextWriter запишуваме во текст фајл линија по линија земајќи информации од листа со играчи. Потоа со StreamReader се читаат и запишуваат во listBox.
<br>![High Scores](/Images/HighScores.png)<br>
*слика 4*

### 3.	Правила и можности на играта:

#### 3.1	Правила
Целта на играта е да се донесат едно до друго (хоризонтално или вертикално ) три или повеќе исти елементи при што ова се смета за комбинација и играчот добива поени, а овие елементи исчезнуваа. На нивно место се слуштаат елемените одозгоре (ако ги има) и празниот простор се потполнува со нови рандом избрани елементи. 

#### 3.2	Бомби

Ако играчот успее да соедини 4 исти елементи (хоризонтално или вертикално ), добива Bomb. При поместување бомбата се активира и сите елементи кои се наоѓаат околу неа исчезнуваат. Ако пак успее да сооедини 5 исти, добива Super Bomb. Со поместување на оваа бомба добива 4 секунди, за време на кои треба да селектира што е можно повеќе елементи, кои по истекот на времето ќе исчезнат.

#### 3.3	Hint 

При играње играчот има право 3 пати да искористи помош т.е да кликне на иконката за Hint (или копчето H од тастaтура) при што во играта му се обележуваат елементите кои прават една комбинација од можните следни комбинации.  

#### 3.4	Helpers

##### 3.4.1	Sound Helper
  При клик на оваа иконка се отвара нова мини игра, во која целта е да се погоди името на песната во позадина. Секоја точно погодена песна додава 300 поени на главната игра. 
##### 3.4.2	Snake Helper
   При клик на оваа иконка се отвара нова мини игра, при што играчот треба користејќи ги стрелките од тастатурата, да ја движи змијата и да собере колку може повеќе ѕвезди. Секоја ѕвезда додава 5 секунди на времето од главната игра.
##### 3.4.3	Association Helper
   При клик на оваа иконка се отвара нова мини игра, во која целта е да се погоди името на сликата во позадина. Секој точно погоден термин додава 1 бомба од тип Bomb на главната игра. Доколку не се знае одговорот може да се кликне на копчето Skip кое генерира нова слика.

### 4.	Функционалности

#### 4.1  Опис на функцијата GenerateRandomImages

![Code for function GenerateRandomImages](/Images/Function.png)<br>
*слика 5*<br>
Оваа функција служи за исполнување на матрицата со рандом избрани слики од елементите. Играта е составена од 6 различни сликички од по 50px. Имаме класа Img каде за секоја слика чуваме тип, почетни координати, дали е селектирана и дали е означена за бришење. Функцијава со помош на рандом генератор бира бројче од 0 до 5 и според тоа на секоја ќелија од матрицата се доделува објект од класата Img. По избор на секоја од сликите се пушта функцијата ThreeFromTheSameType која проверува дали со последниот избор има 3 соседни исти елементи, ако нема се бира објект за следната келија, а ако има повторно се бира објект за оваа ќелија.



Изработиле:<br>
Марија Шопова 161044<br>
Наташа Карачанакова 161075<br>
Кристина Андоновска 161033<br>



