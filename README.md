# .NET Drug Product Database (DPD) API Wrapper

- An easy to use library that makes connecting with the [Canadian Government's Drug Product Database API](https://health-products.canada.ca/api/documentation/dpd-documentation-en.html) easy for .NET applications.

<p align="center">
  <a href="https://github.com/Clinical-Support-Systems/canadian-drug-product-database/actions/workflows/nuget_publish.yml">
    <img src="https://github.com/Clinical-Support-Systems/canadian-drug-product-database/actions/workflows/nuget_publish.yml/badge.svg" alt="Sublime's custom image"/>
  </a>
  <img alt="GitHub Workflow Status" src="https://img.shields.io/github/workflow/status/Clinical-Support-Systems/oneid-oauth-middleware/CI">
<img alt="Nuget" src="https://img.shields.io/nuget/dt/DrugProductDatabase">
  <img alt="Nuget Version" src="https://img.shields.io/nuget/v/DrugProductDatabase">
</p>

<p align="center">
    <a href="#beginner-about">About</a> |
    <a href="#sunny-usage">Usage</a> |
    <a href="#wrench-development">Development</a> |    
    <a href="#star2-creditacknowledgment">Acknowledgement</a> |
    <a href="#lock-mit-license">License</a>
</p>

---

# :beginner: About
This library was created by Clinical Support Systems, who have experience integrating with APIs of varying complexity. We wanted to simplify the connection in .NET web applications so we could get on with the actual API implementation related to our work using the eHealth DHDR service which references drugs using the Drug Identification Number (DIN) so additional information is needed to be able to complete the remaining drug product information.

# :sunny: Usage
Here's how to use this library in your project.

###  :electric_plug: NuGet Installation

```powershell
Install-Package DrugProductDatabase
```

###  :package: YourCode.cs

Add the following to your code:

```csharp
var result = await DrugProductRequest.GetDrugProduct(din: "02247087");
```

#  :wrench: Development
If you want other people to contribute to this project, this is the section, make sure you always add this.

### :notebook: Pre-Requisites

- Nothing! This is a fully public API that has no authentication.

 ###  :fire: Contribution

 Your contributions are always welcome and appreciated. Following are the things you can do to contribute to this project.

 1. **Report a bug** <br>
 If you think you have encountered a bug, and I should know about it, feel free to report it and I will take care of it.

 2. **Request a feature** <br>
 You can also request for a feature.

 3. **Create a pull request** <br>
 It can't get better then this, your pull request will be appreciated by the community. You can get started by picking up any open issues from [here](https://github.com/Clinical-Support-Systems/oneid-oauth-middleware/issues) and make a pull request.

 > If you are new to open-source, make sure to check read more about it [here](https://www.digitalocean.com/community/tutorial_series/an-introduction-to-open-source) and learn more about creating a pull request [here](https://www.digitalocean.com/community/tutorials/how-to-create-a-pull-request-on-github).


 ### :cactus: Branches

 I use an agile continuous integration methodology, so the version is frequently updated and development is really fast.

1. **`develop`** is the development branch.

2. **`main`** is the production branch.

4. No further branches should be created in the main repository.

**Steps to create a pull request**

1. Make a PR to `main` branch.
2. Comply with the best practices and guidelines e.g. where the PR concerns visual elements it should have an image showing the effect.
3. It must pass all continuous integration checks and get positive reviews.

After this, changes will be merged.

# :star2: Credit/Acknowledgment
 * David Ball
 * Kori Francis

#  :lock: MIT License

[License](https://raw.githubusercontent.com/Clinical-Support-Systems/canadian-drug-product-database/main/LICENSE?token=AAAQP5WQ2DTNHWIGPVVICWLA73TK2)
