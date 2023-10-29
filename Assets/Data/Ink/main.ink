INCLUDE VARS.ink
INCLUDE Unique NPC.ink
INCLUDE FUNCTIONS.ink
INCLUDE day1.ink
INCLUDE day2.ink
INCLUDE day3.ink
INCLUDE day4.ink
INCLUDE day5.ink
INCLUDE Intro.ink
INCLUDE Endings.ink




-> day1Customer.random
-> day1UniqueCustomer.Asep
-> day1UniqueCustomer.weirdPreacher
-> day2Customer.random
-> day2UniqueCustomer.Asep
-> day3Customer.random
-> day3UniqueCustomer.mbahNgesi
-> day4Customer.random
-> day5Customer.random
-> endingChoice
=== endingChoice ===
VAR playerMoney = {GetPlayerMoney()}
VAR moneyTarget = 100000
VAR requestText = ""
{asepEnding == true: ->endings.asepEndings}
{playerMoney >= moneyTarget: -> endings.justEnding | -> endings.badEndings}






