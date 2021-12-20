import express from 'express';
import { createClient } from '@supabase/supabase-js'
const supabaseUrl = 'https://vneidrffkiqxdxwpwrzk.supabase.co'
const supabaseKey = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoic2VydmljZV9yb2xlIiwiaWF0IjoxNjM5OTA4OTU1LCJleHAiOjE5NTU0ODQ5NTV9.G45qH-0YOQgNt0ZmIgvjyC5Ue2HL6CFlgul_BYRo0fI';
const supabase = createClient(supabaseUrl, supabaseKey)
const app = express();
const PORT = 8080;
const VERSION = "/v1";
app.use( express.json() )

// app.get(VERSION+'/pack', (req, res) => 
// {
//     res.status(200).send({
//         name: 'Example',
//         version: '1.12'
//     })
// });

app.get(VERSION+'/create/:id', (req, res) => 
{
    const { id } = req.params;
    const { body } = req.body;
    const { name } = req.body;
    if (!body)
    {
        res.status(420).send({ message: 'INVALID ARGUMENTS'})
    }
    //var today = new Date();

    //let { data, error } = supabase
        //.from('pack')
        //.insert(`{ id: ${id}, created_at: '${today.toISOString()}', name: ${name }, version:'1.12.2', count: 10, download: 'https://example.com/test.zip' }`)
        //.then(data => { res.status(200).send(data) }).catch(console.log);
});

app.get(VERSION+'/pack/:id', (req, res) => 
{
    const { id } = req.params;
    if (!id)
    {
        res.status(420).send({ message: 'INVALID ARGUMENTS'})
    }

    let { data, error } = supabase.from('pack').select('*').order('id', true).eq('id', id).then(data => { res.status(200).send(data.body) }).catch(console.log);
    console.log(`Sent pack request: ${data}`);
});

app.listen(
    PORT,
    () => console.log(`Server Running: http://localhost:${PORT}`)
)