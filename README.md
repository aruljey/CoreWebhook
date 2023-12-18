# CoreWebhook
Webhook in .net core

## WebHook Receiver Name
``corehook``

## Apikey Settings
appsettings.json
```json
"WebHooks": {
    "corehook": {
        "SecretKey": {
            "default": "b81438db517aebb6d30abea3e24b94b2cba43afb"                
        }
    }
},
```
## POST Webhook Api Link
``https://localhost:7221/api/webhooks/incoming/corehook/?apikey=b81438db517aebb6d30abea3e24b94b2cba43afb``

## Post Body
```json
{
    "Customer":
    [
    {
        "name":"Customer1",
        "address":"address",
        "city":"chennai"        
    }
    ]
}
```

---

⭐️ From [@aruljey](https://github.com/aruljey)

