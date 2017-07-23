# cryptinsure
Cryptinsure solution to insure crypto currency transactions

Cryptinsure is a smart contract which insures users against making a 'fat finger' mistake when copying or typing out cyptocurrency or token addresses, which tend to be long and complex strings of numbers. 
This emerges as a problem for new cryptocurrency users, who are not acquainted with copying and pasting in these numbers and may still try to type out their addresses when transferring an address from a phone to a laptop or vice versa.
By paying a premium for a transaction, and sending the transaction ID for the insured transaction, users can insure themselves against mistyping an address by submitting claims to the smart contract.

Process flow
1.	User wallet opts-in to insurance smart contract.
2.	User intends to send ether to the intended wallet (X), but instead, ‘fat fingers’ and sends ether to the mistake address (Y).
3.	Right afterwards, the premium and the transaction ID for 2 is sent to the smart contract.
4.	User realises that they have ‘fat fingered’ the address by one letter and Makes a Claim – putting in the transaction ID and the intended address
5.	Smart contract compares the intended address to the address in the original transaction
6.	If there is a 1 character difference at the end of the address, the contract is activated and the amount in the original transaction is sent to the intended address.

Value
Cryptocurrency addresses are complex lines of code which are quite daunting for new users. Even ENS domain names can be written in an incorrect manner – e.g. Ststus.eth instead of Status.eth, and if a domain dame for this exists, then funds will be sent there irreversiby.

In order to reassure small businesses and others who may be sending large amounts of cryptocurrency, the insurance contract would allow for peace of mind when sending cryptocurrency.

Weak points
Fraud – The opportunity for fraud would be rife if the insurance claim was sent back to the original user, as they could easily send money to a ‘mistake’ address (actually their friend's or their own wallet) and then have the money returned to their original account. To stop this, the claimed money would get sent to the original intended address so the original transaction is enacted.

The current code looks for a difference of one character at the end of the address – this may not be particularly useful to those who manually write out an address and make a mistake in the middle, but is a realistic amount to achieve in our time frame.

There is currently no system in place for establishing the premiums that a user would pay – though it would most likely come from a combination of the number of transactions a user has made, the length of time the wallet has been active, the number of claims made from that address in the past.

Possible Expansion
Token based reputation system – in order to help establish premium levels, some kind of non-tradeable token asset could be given to a wallet. When establishing an insurance smart contract, these tokens could be sent to the smart contract in lieu of a certain amount of ether. Once the elapsed time the smart contract runs for has completed, these would be returned. In the case of when a claim is made, some of these tokens could be burned – reducing the user’s effective ‘credit’
It would allow insurance companies to get a foot in the door within the emerging cryptocurrency ecosystem – though starting with small, easy to compute claims such as mis-typed addresses, a similar contract could eventually be used to ensure transactions against false addresses or malware-caused copy and paste issues.
Staking pools could be set up by the smart contract once they have effective liquidity in order to profit from the Ether that is sent to and left in the address. This could be used to fund underwriters and discovering other methods of insuring the market via smart contracts or claims agents.
