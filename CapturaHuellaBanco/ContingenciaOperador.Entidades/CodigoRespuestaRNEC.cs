namespace ContingenciaOperador
{
    /// <summary>
    /// Posibles valores retornados por la consulta a RNEC.
    /// </summary>
    public enum CodigoRespuestaRNEC
    {
        candidatenotfound = 0,
        candidatefound = 1,
        candidatefoundpartialfingers = 2,
        candidatenotautorizedbyage = 3,
        candidatefoundinvalidfingers = 4,
        error_while_saving_transaction = 13,
        invalidoperatorid = 110,
        operatordisabled = 111,
        invalidnut = 120,
        invalidnuipnip = 130,
        invalidfingerid = 140,
        fingerdatanotenough = 142,
        invalidclientid = 150,
        clientdisabled = 151,
        invalidfingerprintformat = 160,
        fingerprintformatnotauthorized = 162,
        invalidclientoperatorlink = 170,
        clientoperatorlinkdisabled = 171,
        inactiveagreement = 172,
        expiredagreement = 173,
        fingerprintnotfound = 200,
        fingerprintconverterror = 250,
        fingerprintconverttoisoerror = 260,
        fingerprintconverttoansierror = 270,
        communicationerror = 830,
        databaseerror = 840,
        unknownerror = 999
    }
}
