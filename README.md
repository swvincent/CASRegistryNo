# CAS Registry Number

CAS Registry Numbers (CAS RNs) are unique numerical identifiers assigned to chemical substances. They are managed by the [Chemical Abstracts Service](https://www.cas.org/).

This project contains the CasRN class I've written to validate CAS RNs by ensuring they're in the correct format and that they contains a valid check digit. It is demonstrated by a simple Console application.

I wrote this for C# 7.0 since it uses a Tuple to return the validation result and error message. It could be easily adapted to earlier versions with some minor changes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

# References

- [Wikipedia entry on CAS Registry Number](https://en.wikipedia.org/wiki/CAS_Registry_Number)
- [CAS Registry FAQ](https://www.cas.org/support/documentation/chemical-substances/faqs)
- [Check Digit Verification of CAS Registry Numbers](https://www.cas.org/support/documentation/chemical-substances/checkdig)