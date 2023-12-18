# CoreWebhook
Webhook in .net core

## WebHook Receiver Name
``corehook``

## Apikey Settings
appsettings.json
``
"WebHooks": {
    "corehook": {
        "SecretKey": {
            "default": "b81438db517aebb6d30abea3e24b94b2cba43afb"                
        }
    }
},
``
## POST Webhook Api Link
``https://localhost:7221/api/webhooks/incoming/corehook/?apikey=b81438db517aebb6d30abea3e24b94b2cba43afb``

---

⭐️ From [@aruljey](https://github.com/aruljey)

