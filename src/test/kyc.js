const KYC = artifacts.require("KYC");

contract("KYC", function(accounts) {
  beforeEach(async function () {
      this.kyc = await KYC.new({from: accounts[0]});
  });

  it.skip("should test ERC20 public properties", async function () {
    const name = await this.token.name();
    assert.equal(name, "Token", "Name should be Token");

    const symbol = await this.token.symbol();
    assert.equal(symbol, "TOKEN", "Symbol should be TOKEN");
  });
});