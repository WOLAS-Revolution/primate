Primate
=======

C# wrapper for the .NET Mandrill API, which exposes easy-to-use email and templating methods.

## Configuration
Before sending email or getting a template, the configuration settings must be initialized using the `Primate.CONFIG.SetConfig()` method. This method has several overloads, and properties that are not set using the method are set using values from the configuration file, or from the defaults defined in `DEFAULTS.cs`.

The config settings in app.config are as follows, these can be used in place of the `CONFIG.SetConfig()` overloads, and must be used for the Trap email settings:

- `Mandrill.Trap.Email`
- `Mandrill.Trap.Key`
- `Mandrill.Trap.Account`
- `Mandrill.SubAccount`
- `Mandrill.ProjectTag`

## CONFIG
Configuration class used to set up global settings such as API key, from name and from email.

### SetConfig [4 Overloads]
Sets the config values.

- `apiKey` - The Mandrill API key to use when sending/getting templates
- `fromName` - The name that will appear as the "From" sender
- `fromEmail` - The email address to send from
- `projectTag` - The tag to attach to all emails sent from the application
- `subAccount` - The Mandrill subaccount to send the emails from

```
Primate.CONFIG.SetConfig("-d2hjud818911z_d", "primate@gmail.com", "Primate");
```
