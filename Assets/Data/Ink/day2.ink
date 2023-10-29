=== day2Customer ===
= random
{Greetings, I demand |Hey, I urgently need |Salutations, I must acquire |Hello, I am in dire need of } <> #speaker {currentName}
-> randomProducts
= randomProducts
~ temp rand = RANDOM(0, 100)
~ temp count = 1
{
    - rand < 20: ~ count = 3
    - rand < 60: ~ count = 2
}
~ GenerateProductRequest(count)

{
    - count == 1: ~ requestText = "{formatProductAt(0)}"
    - count == 2: ~ requestText = "{formatProductAt(0)} and {formatProductAt(1)}"
    - count == 3: ~ requestText = "{formatProductAt(0)}, {formatProductAt(1)}, and {formatProductAt(2)}"
}

<> {requestText}

-> response

= randomRejectedResponse

~ temp rand = RANDOM(0, 100)
{rand < 40: ->randomRenegotiate}

{Oh well, on to the next store...|Well, that's unfortunate...||Aw man, the struggle is real.} #speaker {currentName}
~ RejectSale()
~ ResetProductRequest()
-> END

= randomRenegotiate

{Fine, how about|Alright then, but can I get|Okay, but what about} #speaker {currentName}
<> -> randomProducts

= response
+ [Certainly] {Okay, give me a moment|Certainly, I'll attend to that|Alright} #speaker You
    ~ StartSale()
    -> END
+ [Apologies, Out of Stock] Apologies, we're out of stock for that, and the prices are soaring.
    -> randomRejectedResponse

= presentProduct
Alright, that will be {GetPrice()} Rupiah. Absurd, isn't it?
~ temp rand = RANDOM(0, 100)
{
    - rand < 10: -> nevermind
    - rand < 30: -> requestMore
    - else: -> evaluate
}

= requestMore
{On second thought, I'd like to add |Actually, I also need more. Can you throw in an extra |Wait, can you add } <>
-> randomProducts
= nevermind
{Nevermind, actually. My apologies, but I forgot my wallet at home |Wait, I need to go. Please cancel my orders.}
~ RejectSale()
~ ResetProductRequest()
-> END

= evaluate
~ temp score = GetFulfillmentScore()
{
    - score < -1:
    Are you sure this is all? I'm practically going bankrupt here!
    + [No] -> repeat
    + [Yes] -> veryAngry
    - score < -0.2:
    Are you sure this is all? Do you want me to starve?
    + [No] -> repeat
    + [Yes] -> angry
    - score < 0.2 && score > -0.2: -> finish
    - score > 0.2: -> finish
    - score > 1:
    Wow, this is a lot more than I thought. Are you sure? I might have to sell my kidneys.
    + [No] -> repeat
    + [Yes] -> veryHappy
}

= repeat
Alright, just to be clear, I need {requestText}, and it's costing me a fortune.
-> END

= veryAngry
I'M VERY ANGRYYYYY! (placeholder text)
~ RejectSale()
~ ResetProductRequest()
-> END

= angry
I'm angry (placeholder text). You're bleeding me dry!
~ RejectSale()
~ ResetProductRequest()
-> END

= veryHappy
Thanks for this! I'm very happy! (placeholder text) Happy, but also broke.
-> finish

= finish
    ~ ConsumeProducts()
    ~ AddMoney(GetPrice())
    ~ ResetProductRequest()
Thank you for coming!.
-> END
