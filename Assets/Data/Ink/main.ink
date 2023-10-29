INCLUDE VARS.ink
INCLUDE FUNCTIONS.ink

-> day1Customer.random

VAR requestText = ""

=== day1Customer ===
= random
#speaker {currentName}

{Hello, i want |Hey, i need |Hi, i would like |Hey, can i get } <>
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
#speaker {currentName}

~ temp rand = RANDOM(0, 100)
{rand < 40: ->randomRenegotiate}

{Oh well, to the next store...|That sucks...||Aw man...}
~ RejectSale()
~ ResetProductRequest()
-> END

= randomRenegotiate
#speaker {currentName}
{Ok, how about|Alright then, but can i get|Ok, but what about}
<> -> randomProducts 

= response
+ [Sure] {Ok give me a moment|Sure Thing|Alright}
    ~ StartSale()
    -> END
+ [Sorry, Out of Stock] Sorry, we're out of stock for that.
    -> randomRejectedResponse
    
    
= presentProduct
Ok, that'll be {GetPrice()} Rupiah
~ temp rand = RANDOM(0, 100)
{
    - rand < 10: -> nevermind
    - rand < 30: -> requestMore
    - else: -> evaluate
}

= requestMore
{On Second Thought, i'd like to add |Actually, i also more. I need an extra of |Wait, can you add } <>
-> randomProducts
= nevermind
{Actually, Nevermind, sorry. I forgot my wallet home |Wait, i need to go. Please cancel my orders}
~ RejectSale()
~ ResetProductRequest()
-> END

= evaluate
~temp score = GetFulfillmentScore()
{
    - score < -1:
    Are you sure this is all?
    + [No] -> repeat
    + [Yes] -> veryAngry
    - score < -0.2:
    Are you sure this is all?
    + [No] -> repeat
    + [Yes] -> angry
    - score < 0.2 && score > -0.2: -> finish
    - score > 0.2: -> finish
    - score > 1:
    Wow this is alot more than i thought. Are you sure?
    + [No] -> repeat
    + [Yes] -> veryHappy
}

= repeat
Alright, just to be clear, i need {requestText}
-> END

= veryAngry
IM VERY ANGRYYYYY (placeholder text)
~ RejectSale()
~ ResetProductRequest()
-> END

= angry
Im angry (placeholder text)
~ RejectSale()
~ ResetProductRequest()
-> END

= veryHappy
Thanks for this! im very happy! (placeholder text)
-> finish

= finish
    ~ ConsumeProducts()
    ~ AddMoney(GetPrice())
    ~ ResetProductRequest()
Thank you for coming!
-> END



