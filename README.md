<p align="center">
  <a href="#">
    <img alt="logo" src="Sundae.png">
  </a>
</p>

# Sundae

This is a project started out of need, on a Sunday afternoon. It grew from the frustration of the available .NET XMPP libraries, due to them being closed source, unmaintained, hard to debug, or a mix of all of those.

## ejabberd

[ejabberd](https://www.ejabberd.im) is the XMPP server used for tests. [Manual tests](TestApplication/Program.cs), unfortunately, there's no automated tests at the moment.

SASL is not implemented, the `Authenticate` and `Register` methods are predicated on ejabberd behavior. `mod_legacy_auth` must be enabled due to the lack of TLS support right now. Sorry.
