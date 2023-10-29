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
->END
+Sorry , not again
Pleasee
++ Alright. just this time not again.
Thank you, very much you save me bro
->END
++Nope
okay, i go another place
->END

