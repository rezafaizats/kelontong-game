=== day4Customer ===
= random
{Greetings, I demand |Hey, I urgently need |Greetings, I must acquire |Hello, I am in dire need of } <> #speaker {currentName}
-> randomProducts
= randomProducts
~ temp rand = RANDOM(0, 100)
~ temp count = 1
{
    - rand < 20: ~ count = 4
    - rand < 60: ~ count = 3
}
~ GenerateProductRequest(count)

{
    - count == 1: ~ requestText = "{formatProductAt(0)}"
    - count == 3: ~ requestText = "{formatProductAt(0)}, {formatProductAt(1)}, and {formatProductAt(2)}"
    - count == 4: ~ requestText = "{formatProductAt(0)}, {formatProductAt(1)}, {formatProductAt(2)}, and {formatProductAt(3)}"
}

<> {requestText}

-> response

= randomRejectedResponse

~ temp rand = RANDOM(0, 100)
{rand < 30: ->randomRenegotiate}

{Oh well, to the next store...|That sucks...||Aw man...} #speaker {currentName}
~ RejectSale()
~ ResetProductRequest()
-> END

= randomRenegotiate

{Ok, how about|Alright then, but can I get|Ok, but what about} #speaker {currentName}
<> -> randomProducts

= response
+ [Sure] {Ok give me a moment|Sure thing|Alright} #speaker You
    ~ StartSale()
    -> END
+ [Sorry, Out of Stock] Sorry, we're out of stock for that, and it's practically bankrupting me.
    -> randomRejectedResponse

= presentProduct
Ok, that'll be {GetPrice()} Rupiah. Ridiculous, right?
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
{Actually, nevermind, sorry. I forgot my wallet at home |Wait, I need to go. Please cancel my orders.}
~ RejectSale()
~ ResetProductRequest()
-> END

= evaluate
~ temp score = GetFulfillmentScore()
{
    - score < -1:
    Are you sure this is all? I'm practically bankrupt here!
    + [No] -> repeat
    + [Yes] -> veryAngry
    - score < -0.5:
    Are you sure this is all? Do you want me to starve for real?
    + [No] -> repeat
    + [Yes] -> angry
    - score < 0.2 && score > -0.5: -> finish
    - score > 0.2: -> finish
    - score > 1:
    Wow, this is a lot more than I thought. Are you sure? I might have to sell my soul.
    + [No] -> repeat
    + [Yes] -> veryHappy
}

= repeat
Alright, just to be clear, I need {requestText}, and it's costing me a fortune. You're practically looting me.
-> END

= veryAngry
I'M VERY ANGRYYYYY! (placeholder text)
~ RejectSale()
~ ResetProductRequest()
-> END

= angry
I'm angry (placeholder text). You're bleeding me dry! My bank account is crying.
~ RejectSale()
~ ResetProductRequest()
-> END

= veryHappy
Thanks for this! I'm very happy! (placeholder text) Happy, but also on the verge of bankruptcy.
-> finish

= finish
    ~ ConsumeProducts()
    ~ AddMoney(GetPrice())
    ~ ResetProductRequest()
Thank you for coming! I hope you enjoy your insane shopping spree.
-> END

= stareAtPlayer
{The customer stares at you without saying a word.|A customer stands motionless, staring at you.}
~ RejectSale()
-> END
