=== day5Customer ===
= random
{Greetings, I command |Hey, urgently require |Salutations, I insist upon |Hello, in desperate need of } <> #speaker {currentName}
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

{Oh well, onward to the next store...|That's unfortunate...||Aw man, the trials of shopping} #speaker {currentName}
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
+ [Regrettably, Out of Stock] Apologies, we're out of stock for that, and it's causing financial mayhem.
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
Thanks for this! I'm very happy! (placeholder text) Delighted, but also on the verge of bankruptcy.
-> finish

= finish
    ~ ConsumeProducts()
    ~ AddMoney(GetPrice())
    ~ ResetProductRequest()
Thank you for coming! I hope you enjoy your crazed shopping spree.
-> END

= stareAtPlayer
~ temp rand = RANDOM(0, 100)
{
    - rand < 20: {The customer stares at you without uttering a word.|A customer stands motionless, staring at you.}
    - rand >= 20 && rand < 40: {The customer smiles awkwardly, their eyes wide and unsettling.|A bizarre smile stretches across the customer's face, creating an uncomfortable atmosphere.}
    - rand >= 40 && rand < 60: {The customer brandishes a peculiar object, staring at you with intense focus.|You notice the customer has a strange item in their hand, and they keep glancing at you with an unsettling expression.}
    - rand >= 60: {The customer starts laughing maniacally, making everyone in the store uncomfortable.|Suddenly, the customer bursts into laughter, an eerie and unsettling sound that echoes through the store.}
}
~ RejectSale()
-> END
