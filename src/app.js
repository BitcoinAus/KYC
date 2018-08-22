import { Connect, SimpleSigner } from 'uport-connect'

const uport = new Connect('Lucas Cullen\'s new app', {
  clientId: '2ofGDsP2Rb51Bt76jVjSzresYwxgKcqyGbs',
  network: 'rinkeby or ropsten or kovan',
  signer: SimpleSigner('7e19ca36858807ac5b5092313e5f329d0057ba4eff8d6f88d4770de6380f289f')
})

// Request credentials to login
uport.requestCredentials({
  requested: ['name', 'phone', 'country'],
  notifications: true // We want this if we want to recieve credentials
})
.then((credentials) => {
  // Do something
})

// Attest specific credentials
uport.attestCredentials({
  sub: THE_RECEIVING_UPORT_ADDRESS,
  claim: {
    CREDENTIAL_NAME: CREDENTIAL_VALUE
  },
  exp: new Date().getTime() + 30 * 24 * 60 * 60 * 1000, // 30 days from now
})