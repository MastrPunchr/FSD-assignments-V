# Assignment 1: Abstraction, Inheritance & Polymorphism

---
You’ve been assigned to the backend team for PaymentPlus – a payment processor that handles all forms of payments. Your job is to build out the backend data models for the system. PaymentPlus aims to support a wide variety of payment methods, both online and offline, to cater to a diverse client base ranging from small e-commerce stores to large multinational corporations.

### Objective

---
Your task is to develop a robust and extensible payment system using a class hierarchy in C#. This system should demonstrate an effective use of object-oriented programming principles, focusing particularly on abstraction, inheritance, polymorphism, and the strategic use of abstract, virtual, and override keywords. You should strive to minimize repeated code and maximize code reuse.

###Task Background

---
PaymentPlus handles 2 types of payments: Online and Offline payments. The online payments are further subdivided into credit card and bitcoin payments, while the offline payments are subdivided into cash and cheque. They also support 3 currencies: CAD, USD, and EUR.

PaymentPlus has some strange payment processing requirements that come from the banking side. Unfortunately, as a developer, you were told not to ask too many questions. You will need to implement these requirements listed below:

    - In general, you cannot accept payments with amounts ending in .99 (e.g 0.99, 1.99), except for cash payments, which can end in any number.
    - For cash payments, EUR is not accepted.
    - For online payments, the transaction amount must be greater than $5.00/ €5.00 (in whichever currency is used)
    - For credit payments, the minimum is $5.00 if using CAD or USD, but €10.00 with EUR.
    - For cheque payments in USD or EUR (not CAD), it can only be in whole-dollar amounts ($1.00/€1.00, $5.00/€5.00)

Tip: You can use the modulus (%) operator to determine if amounts end in .00 or .99. If using decimal values, multiply by 100, if using integer cents, no conversion is necessary.

### Object Hierarchy

---
Payment (abstract class)
This class represents a generic payment, whether online or in-person. It should have properties to track the amount of the payment, as well as the currency (eg. “CAD”, or “USD”). It should have the following methods:

    - `ProcessPayment()`: Abstract method for payment processing; For now, just print out the type of payment and amount validated.
    - `ValidatePayment()`: Validation for the payment amount/etc to see if it is valid according to the rules set out by the banking department. Returns true if the payment is valid, false otherwise.
    - `LogPayment()`: Prints out the details of the payment. You should aim to have this method print out the most accurate details, depending on the class implementation.
    - Online Payment (abstract class). In addition to the properties from payment, it should also have a field to track the Payment Gateway (e.g “Stripe”, “PayPal”). It should also have an abstract `Authorize()` method to authorize the payment through the online gateway (you will just print in console for authorization for now).
    - Credit Card Payment (inherits from online payment). Include additional properties for Card Number, expiry date and CVV.
    - Bitcoin Payment (inherits from online payment). Include an additional property for wallet ID (string).
    - Offline Payment (abstract class). In addition to the properties and methods from payment, include a `RecordPayment()` abstract method, to record payment details in the offline systems (for now, you can just print to indicate the recording of offline details).
    - Cash Payment (inherits from offline payment). Implement all abstract methods, nothing new added.
    - ChequePayment (inherits from offline payment). Include additional properties for cheque number and bank name.

### Payment Manager

---
In addition to the payment classes, we will need a Payment Manager class to store and track all of the payments. It should store a list of payments, and include the following methods:

    `AddPayment(Payment payment)`: Adds a payment to the list
    `ValidatePayments()`: Validates all the payments in the list. For each invalid payment, it should be printed out in full detail, and then removed from the list.
    `AuthorizePayments()`: calls .Authorize() for all of the online payments on the list.
    `RecordOffline()`: calls .RecordPayment() for all the offline payments on the list.
    `ProcessPayments()`: Processes all payments left in the list.

### Using your Payment Manager

---w
Finally, in the main method, create a demonstration for the frontend team to use your backend code. Show them how to create a payment manager, add all the different types of valid and invalid payments to it (try to cover all cases), authorizing and recording payments, and finally processing them