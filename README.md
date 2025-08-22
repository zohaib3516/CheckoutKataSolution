# CheckoutKataSolution

Checkout Kata:
This project is a Test-Driven Development (TDD) kata in C#/.NET, implementing a supermarket checkout system with unit pricing and special multi-buy offers. The focus is on clean design, decoupling, and testability.

Problem:
In a normal supermarket, products are identified using SKUs.
Each product has A unit price. Optionally, one or more special offers (e.g., 3 for 130).

The checkout should:
Accept scanned items in any order.
Apply the best applicable pricing rule(s).
Support flexible, configurable pricing rules that can change frequently.

Example:
SKU A: 50 each, or 3 for 130
SKU B: 30 each, or 2 for 45
SKU C: 20
SKU D: 15

Key Features
Unit Pricing:   Simple per-item price.
Multi-Buy Pricing,   e.g., 3 for 130, valid only for a limited period.
Time-Bound Promotions:   Special offers only apply within a start/end date.
Flexible Design   Rules are decoupled from the checkout engine, making it easy to add new types of pricing rules in the future.

TDD with NUnit Development was guided by unit tests from the start.
Open/Closed Principle (OCP)   The checkout system is open for extension (new pricing rules can be added easily) but closed for modification (the core checkout logic remains unchanged).
