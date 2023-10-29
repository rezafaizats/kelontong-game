=== day1UniqueCustomer ===
= Asep
~currentName = "Asep"
Hello my name is Asep, i need  <> #speaker {currentName}

~ GenerateProductRequest(2)  

~ requestText = "{formatProductAt(0)} and {formatProductAt(1)}"

<> {requestText}. But, can i pay it tomorrow after my family at my hometown send me some money? Please. 

-> asepResponse 

= asepResponse
+ Sure, but please remember to pay it #speaker You
    ~ StartSale()
    Thank you brother.i pay you back tomorrow
    ~ asepDay1 = true
    -> END
+ Sorry we don't do that here 
    -> END
    

= weirdPreacher
~currentName = "Weird Preacher"
The world is ending kid, save yourself.
->END

=== day2UniqueCustomer ===
= Asep
~currentName = "Asep"
Hey bro, am sorry but my family didn't send the money yet can i get <> #speaker {currentName}
~GenerateProductRequest(2)
~ requestText = "{formatProductAt(0)} and {formatProductAt(1)}"

<> {requestText}. for eat today? very Please. i pay you back 👏
->asepResponse

=asepResponse
+ Alright, i got you
~StartSale()
Thank you, very much you save me bro
~asepDay2 = true
{asepDay1 == true:
~asepEnding = true
}
->END
+Sorry , not again
Pleasee
++ Alright. just this time not again.
~StartSale()
Thank you, very much you save me bro
->END
++Nope
okay, i go another place
->END

=== day3UniqueCustomer ===
= mbahNgesi
~currentName = "Mbah Ngesi"
my son, grandma need <> #speaker {currentName}
~GenerateProductRequest(2)
~ requestText = "{formatProductAt(0)} and {formatProductAt(1)}"
<> {requestText}. please bring it to me.
->mbahNgesiResponse

=mbahNgesiResponse
+Yes, wait a second mbah
~StartSale()
        ahhh i just remember, i need more.please add <> #speaker {currentName}
    ~GenerateProductRequest(2)
    ~ requestText = "{formatProductAt(2)} and {formatProductAt(3)}"
    <> {requestText}. please bring it here too.
    ++Alright, Please wait
    ~StartSale()
        am sorry just remember more, please bring me  <> #speaker {currentName}
        ~GenerateProductRequest(1)
        ~ requestText = "{formatProductAt(4)}"
        <> {requestText}. This the last one.
        +++Alright, Please wait
        ~StartSale()
        wait why am here? who are you?
        ->END
        
        +++No, it just too many. take it or leave it
        i go another place then, bad son. doesn't know how to respect elderly
        ->END

    ++No, i don't trust your memory
    i go another place then, bad son. doesn't know how to respect elderly
->END
+No, go away
youngling these days doesn't know how to respect older people
->END