const Registry = artifacts.require("Registry");

contract("Registry", function(accounts) {
  beforeEach(async function () {
      this.registry = await Registry.new({from: accounts[0]});
  });

  it.only("should set claim", async function () {
    const name = await this.registry.setClaim(accounts[1], );
    assert.equal(name, "Token", "Name should be Token");

    const symbol = await this.token.symbol();
    assert.equal(symbol, "TOKEN", "Symbol should be TOKEN");
  });
});