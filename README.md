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

## Sample output
```json
{
    "success": true,
    "data": "{\r\n  \"Customer\": [\r\n    {\r\n      \"name\": \"Customer1\",\r\n      \"address\": \"address\",\r\n      \"city\": \"chennai\"\r\n    }\r\n  ]\r\n}",
    "errorCode": "0",
    "errorMessage": ""
}
```

---

⭐️ From [@aruljey](https://github.com/aruljey)

