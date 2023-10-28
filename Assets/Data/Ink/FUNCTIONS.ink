EXTERNAL AddMoney(amount)
EXTERNAL StartSale()
EXTERNAL RejectSale()
EXTERNAL ConsumeProducts()
EXTERNAL GetPrice()
EXTERNAL GenerateProductRequest(count)
EXTERNAL ResetProductRequest()
EXTERNAL GetProductRequestAmount(index)
EXTERNAL GetProductRequestName(index)
EXTERNAL GetFulfillmentScore()

=== function GetFulfillmentScore() ===
~ return RANDOM(-100, 100) / 100.0

=== function GetProductAmount(index) ===
~ return RANDOM(1, 5)

=== function GetProductName(index) ===
~ return products(index + 1)

=== function GenerateProductRequest(count) ===
#will generate {count} product
~ return

=== function ResetProductRequest() ===
#will reset request
~ return

=== function GetPrice() ===
#get price
~ return 0

=== function StartSale() ===
#sale started
~ return

=== function AddMoney(amount) ===
#added {amount} money
~ return

=== function RejectSale() ===
#sale rejected
~ return

=== function ConsumeProducts() ===
#products consumed
~ return

=== function formatProductAt(index) ===
~ return formatProduct(GetProductRequestName(index), GetProductRequestAmount(index))

=== function getLabel(product) ===
{
    - product == minyakGoreng: ~ return "packs"
    - product == minyakTanah: ~ return "liter"
    - product == tepung: ~ return "kilogram"
    - product == telur: ~ return "kilogram"
    - product == beras: ~ return "kilogram"
    - product == gula: ~ return "kilogram"
    - else: ~ return "errLabel"
}

=== function formatProduct(product, amount) ===
{
    - product == minyakGoreng: ~ return "{amount} {getLabel(product)} of Frying Oil"
    - product == minyakTanah: ~ return "{amount} {getLabel(product)} of Kerosene"
    - product == tepung: ~ return "{amount} {getLabel(product)} of Flour"
    - product == telur: ~ return "{amount} {getLabel(product)} of Eggs"
    - product == beras: ~ return "{amount} {getLabel(product)} of Rice"
    - product == gula: ~ return "{amount} {getLabel(product)} of Sugar"
    - else: ~ return "errFormat"
}


