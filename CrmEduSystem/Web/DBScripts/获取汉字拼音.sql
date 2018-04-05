CREATE FUNCTION [dbo].[test_GetPinyin] ( @words NVARCHAR(2000) )
RETURNS VARCHAR(8000)
AS
    BEGIN 
        DECLARE @word NCHAR(1) 
        DECLARE @pinyin VARCHAR(8000) 
        DECLARE @i INT 
        DECLARE @words_len INT 
        DECLARE @unicode INT 
        SET @i = 1 
        SET @words = LTRIM(RTRIM(@words)) 
        SET @words_len = LEN(@words) 
        WHILE ( @i <= @words_len ) --ѭ��ȡ�ַ� 
            BEGIN 
                SET @word = SUBSTRING(@words, @i, 1) 
                SET @unicode = UNICODE(@word) 
                SET @pinyin = ISNULL(@pinyin + SPACE(1), '')
                    + ( CASE WHEN UNICODE(@word) BETWEEN 19968 AND 19968
                                  + 20901
                             THEN ( SELECT TOP 1
                                            py
                                    FROM    ( SELECT    'a' AS py ,
                                                        N'��' AS word
                                              UNION ALL
                                              SELECT    'ai' ,
                                                        N'�a'
                                              UNION ALL
                                              SELECT    'an' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ang' ,
                                                        N'�l'
                                              UNION ALL
                                              SELECT    'ao' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'ba' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'bai' ,
                                                        N'�B' --�v�ĮB 
                                              UNION ALL
                                              SELECT    'ban' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'bang' ,
                                                        N'�^'
                                              UNION ALL
                                              SELECT    'bao' ,
                                                        N'�t'
                                              UNION ALL
                                              SELECT    'bei' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ben' ,
                                                        N'ݙ'
                                              UNION ALL
                                              SELECT    'beng' ,
                                                        N'�a'
                                              UNION ALL
                                              SELECT    'bi' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'bian' ,
                                                        N'׃'
                                              UNION ALL
                                              SELECT    'biao' ,
                                                        N'�B'
                                              UNION ALL
                                              SELECT    'bie' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'bin' ,
                                                        N'�W'
                                              UNION ALL
                                              SELECT    'bing' ,
                                                        N'�h'
                                              UNION ALL
                                              SELECT    'bo' ,
                                                        N'�N'
                                              UNION ALL
                                              SELECT    'bu' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ca' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'cai' ,
                                                        N'�k' --�n�k 
                                              UNION ALL
                                              SELECT    'can' ,
                                                        N'�|'
                                              UNION ALL
                                              SELECT    'cang' ,
                                                        N'ى'
                                              UNION ALL
                                              SELECT    'cao' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ce' ,
                                                        N'�u'
                                              UNION ALL
                                              SELECT    'cen' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ceng' ,
                                                        N'�u' --�����K�e�u 
                                              UNION ALL
                                              SELECT    'cha' ,
                                                        N'Ԍ'
                                              UNION ALL
                                              SELECT    'chai' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'chan' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'chang' ,
                                                        N'�o'
                                              UNION ALL
                                              SELECT    'chao' ,
                                                        N'�e'
                                              UNION ALL
                                              SELECT    'che' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'chen' ,
                                                        N'׏'
                                              UNION ALL
                                              SELECT    'cheng' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'chi' ,
                                                        N'�u'
                                              UNION ALL
                                              SELECT    'chong' ,
                                                        N'�|'
                                              UNION ALL
                                              SELECT    'chou' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'chu' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'chuai' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'chuan' ,
                                                        N'�E'
                                              UNION ALL
                                              SELECT    'chuang' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'chui' ,
                                                        N'�q'
                                              UNION ALL
                                              SELECT    'chun' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'chuo' ,
                                                        N'�W'
                                              UNION ALL
                                              SELECT    'ci' ,
                                                        N'��' --�n�� 
                                              UNION ALL
                                              SELECT    'cong' ,
                                                        N'ց'
                                              UNION ALL
                                              SELECT    'cou' ,
                                                        N'ݏ'
                                              UNION ALL
                                              SELECT    'cu' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'cuan' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'cui' ,
                                                        N'ě'
                                              UNION ALL
                                              SELECT    'cun' ,
                                                        N'�v'
                                              UNION ALL
                                              SELECT    'cuo' ,
                                                        N'�e'
                                              UNION ALL
                                              SELECT    'da' ,
                                                        N'�\'
                                              UNION ALL
                                              SELECT    'dai' ,
                                                        N'�^'
                                              UNION ALL
                                              SELECT    'dan' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'dang' ,
                                                        N'�W'
                                              UNION ALL
                                              SELECT    'dao' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'de' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'den' ,
                                                        N'�Y'
                                              UNION ALL
                                              SELECT    'deng' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'di' ,
                                                        N'�E'
                                              UNION ALL
                                              SELECT    'dia' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'dian' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'diao' ,
                                                        N'�S'
                                              UNION ALL
                                              SELECT    'die' ,
                                                        N'��' --���� 
                                              UNION ALL
                                              SELECT    'ding' ,
                                                        N'�r'
                                              UNION ALL
                                              SELECT    'diu' ,
                                                        N'�A'
                                              UNION ALL
                                              SELECT    'dong' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'dou' ,
                                                        N'�a'
                                              UNION ALL
                                              SELECT    'du' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'duan' ,
                                                        N'��' --�f�� 
                                              UNION ALL
                                              SELECT    'dui' ,
                                                        N'�m'
                                              UNION ALL
                                              SELECT    'dun' ,
                                                        N'�v'
                                              UNION ALL
                                              SELECT    'duo' ,
                                                        N'�z'
                                              UNION ALL
                                              SELECT    'e' ,
                                                        N'�{'
                                              UNION ALL
                                              SELECT    'en' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'eng' ,
                                                        N'�E'
                                              UNION ALL
                                              SELECT    'er' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'fa' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'fan' ,
                                                        N'�~'
                                              UNION ALL
                                              SELECT    'fang' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'fei' ,
                                                        N'�]'
                                              UNION ALL
                                              SELECT    'fen' ,
                                                        N'�a'
                                              UNION ALL
                                              SELECT    'feng' ,
                                                        N'҅'
                                              UNION ALL
                                              SELECT    'fo' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'fou' ,
                                                        N'�]'
                                              UNION ALL
                                              SELECT    'fu' ,
                                                        N'�g' --�v�g 
                                              UNION ALL
                                              SELECT    'ga' ,
                                                        N'�p'
                                              UNION ALL
                                              SELECT    'gai' ,
                                                        N'�y'
                                              UNION ALL
                                              SELECT    'gan' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'gang' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'gao' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'ge' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'gei' ,
                                                        N'�o'
                                              UNION ALL
                                              SELECT    'gen' ,
                                                        N'�j'
                                              UNION ALL
                                              SELECT    'geng' ,
                                                        N'��' --���톯�ֆ� 
                                              UNION ALL
                                              SELECT    'gong' ,
                                                        N'��' --���C���� 
                                              UNION ALL
                                              SELECT    'gou' ,
                                                        N'ُ'
                                              UNION ALL
                                              SELECT    'gu' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'gua' ,
                                                        N'ԟ'
                                              UNION ALL
                                              SELECT    'guai' ,
                                                        N'�s'
                                              UNION ALL
                                              SELECT    'guan' ,
                                                        N'�}'
                                              UNION ALL
                                              SELECT    'guang' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'gui' ,
                                                        N'�i'
                                              UNION ALL
                                              SELECT    'gun' ,
                                                        N'֏'
                                              UNION ALL
                                              SELECT    'guo' ,
                                                        N'�B'
                                              UNION ALL
                                              SELECT    'ha' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'hai' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'han' ,
                                                        N'�['
                                              UNION ALL
                                              SELECT    'hang' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'hao' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'he' ,
                                                        N'�g'
                                              UNION ALL
                                              SELECT    'hei' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'hen' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'heng' ,
                                                        N'��' --���� 
                                              UNION ALL
                                              SELECT    'hong' ,
                                                        N'�\'
                                              UNION ALL
                                              SELECT    'hou' ,
                                                        N'�c'
                                              UNION ALL
                                              SELECT    'hu' ,
                                                        N'�I'
                                              UNION ALL
                                              SELECT    'hua' ,
                                                        N'�s'
                                              UNION ALL
                                              SELECT    'huai' ,
                                                        N'�|'
                                              UNION ALL
                                              SELECT    'huan' ,
                                                        N'�d'
                                              UNION ALL
                                              SELECT    'huang' ,
                                                        N'�w'
                                              UNION ALL
                                              SELECT    'hui' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'hun' ,
                                                        N'՟'
                                              UNION ALL
                                              SELECT    'huo' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ji' ,
                                                        N'�K'
                                              UNION ALL
                                              SELECT    'jia' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'jian' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'jiang' ,
                                                        N'֘'
                                              UNION ALL
                                              SELECT    'jiao' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'jie' ,
                                                        N'�T'
                                              UNION ALL
                                              SELECT    'jin' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'jing' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'jiong' ,
                                                        N'�W'
                                              UNION ALL
                                              SELECT    'jiu' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ju' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'juan' ,
                                                        N'�\'
                                              UNION ALL
                                              SELECT    'jue' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'jun' ,
                                                        N'�h'
                                              UNION ALL
                                              SELECT    'ka' ,
                                                        N'�l'
                                              UNION ALL
                                              SELECT    'kai' ,
                                                        N'�f' --�b�f 
                                              UNION ALL
                                              SELECT    'kan' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'kang' ,
                                                        N'�`'
                                              UNION ALL
                                              SELECT    'kao' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ke' ,
                                                        N'�S'
                                              UNION ALL
                                              SELECT    'ken' ,
                                                        N'�y'
                                              UNION ALL
                                              SELECT    'keng' ,
                                                        N'�H' --�|�g�{���] 
                                              UNION ALL
                                              SELECT    'kong' ,
                                                        N'�W'
                                              UNION ALL
                                              SELECT    'kou' ,
                                                        N'�d'
                                              UNION ALL
                                              SELECT    'ku' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'kua' ,
                                                        N'�g'
                                              UNION ALL
                                              SELECT    'kuai' ,
                                                        N'�d'
                                              UNION ALL
                                              SELECT    'kuan' ,
                                                        N'�U'
                                              UNION ALL
                                              SELECT    'kuang' ,
                                                        N'�k'
                                              UNION ALL
                                              SELECT    'kui' ,
                                                        N'�^'
                                              UNION ALL
                                              SELECT    'kun' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'kuo' ,
                                                        N'�i'
                                              UNION ALL
                                              SELECT    'la' ,
                                                        N'�B'
                                              UNION ALL
                                              SELECT    'lai' ,
                                                        N'�['
                                              UNION ALL
                                              SELECT    'lan' ,
                                                        N'�h'
                                              UNION ALL
                                              SELECT    'lang' ,
                                                        N'�}'
                                              UNION ALL
                                              SELECT    'lao' ,
                                                        N'�~'
                                              UNION ALL
                                              SELECT    'le' ,
                                                        N'�E'
                                              UNION ALL
                                              SELECT    'lei' ,
                                                        N'Ú' --��Ú 
                                              UNION ALL
                                              SELECT    'leng' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'li' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'lia' ,
                                                        N'�z'
                                              UNION ALL
                                              SELECT    'lian' ,
                                                        N'�~'
                                              UNION ALL
                                              SELECT    'liang' ,
                                                        N'�y'
                                              UNION ALL
                                              SELECT    'liao' ,
                                                        N'�t'
                                              UNION ALL
                                              SELECT    'lie' ,
                                                        N'�v'
                                              UNION ALL
                                              SELECT    'lin' ,
                                                        N'�`' --�`�� 
                                              UNION ALL
                                              SELECT    'ling' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'liu' ,
                                                        N'��' --�F�M�޿� 
                                              UNION ALL
                                              SELECT    'long' ,
                                                        N'�L'
                                              UNION ALL
                                              SELECT    'lou' ,
                                                        N'�U'
                                              UNION ALL
                                              SELECT    'lu' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'lv' ,
                                                        N'�r'
                                              UNION ALL
                                              SELECT    'luan' ,
                                                        N'�y'
                                              UNION ALL
                                              SELECT    'lue' ,
                                                        N'�^'
                                              UNION ALL
                                              SELECT    'lun' ,
                                                        N'Փ'
                                              UNION ALL
                                              SELECT    'luo' ,
                                                        N'�w'
                                              UNION ALL
                                              SELECT    'ma' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'mai' ,
                                                        N'�A'
                                              UNION ALL
                                              SELECT    'man' ,
                                                        N'�p'
                                              UNION ALL
                                              SELECT    'mang' ,
                                                        N'ϑ'
                                              UNION ALL
                                              SELECT    'mao' ,
                                                        N'�x'
                                              UNION ALL
                                              SELECT    'me' ,
                                                        N'�Z' --�Z�� 
                                              UNION ALL
                                              SELECT    'mei' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'men' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'meng' ,
                                                        N'�D' --�W�_ 
                                              UNION ALL
                                              SELECT    'mi' ,
                                                        N'�]'
                                              UNION ALL
                                              SELECT    'mian' ,
                                                        N'�I'
                                              UNION ALL
                                              SELECT    'miao' ,
                                                        N'�R'
                                              UNION ALL
                                              SELECT    'mie' ,
                                                        N'�x' --�x�� 
                                              UNION ALL
                                              SELECT    'min' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ming' ,
                                                        N'Ԛ'
                                              UNION ALL
                                              SELECT    'miu' ,
                                                        N'և'
                                              UNION ALL
                                              SELECT    'mo' ,
                                                        N'��' --��i 
                                              UNION ALL
                                              SELECT    'mou' ,
                                                        N'�E' --�E�w 
                                              UNION ALL
                                              SELECT    'mu' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'na' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'nai' ,
                                                        N'�r'
                                              UNION ALL
                                              SELECT    'nan' ,
                                                        N'�R'
                                              UNION ALL
                                              SELECT    'nang' ,
                                                        N'�Q'
                                              UNION ALL
                                              SELECT    'nao' ,
                                                        N'Ğ'
                                              UNION ALL
                                              SELECT    'ne' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'nei' ,
                                                        N'��' --�۟� 
                                              UNION ALL
                                              SELECT    'nen' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'neng' ,
                                                        N'��' --ǂ����G�� 
                                              UNION ALL
                                              SELECT    'ni' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'nian' ,
                                                        N'ň'
                                              UNION ALL
                                              SELECT    'niang' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'niao' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'nie' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'nin' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ning' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'niu' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'nong' ,
                                                        N'�P'
                                              UNION ALL
                                              SELECT    'nou' ,
                                                        N'�k'
                                              UNION ALL
                                              SELECT    'nu' ,
                                                        N'�x'
                                              UNION ALL
                                              SELECT    'nv' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'nue' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'nuan' ,
                                                        N'�\' --���Q�\�G 
                                              UNION ALL
                                              SELECT    'nuo' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'o' ,
                                                        N'�M' --�ĉ�j�M 
                                              UNION ALL
                                              SELECT    'ou' ,
                                                        N'�a'
                                              UNION ALL
                                              SELECT    'pa' ,
                                                        N'В'
                                              UNION ALL
                                              SELECT    'pai' ,
                                                        N'�s' --�W�s 
                                              UNION ALL
                                              SELECT    'pan' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'pang' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'pao' ,
                                                        N'�^'
                                              UNION ALL
                                              SELECT    'pei' ,
                                                        N'�\'
                                              UNION ALL
                                              SELECT    'pen' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'peng' ,
                                                        N'��' --�����C�n�� 
                                              UNION ALL
                                              SELECT    'pi' ,
                                                        N'�G'
                                              UNION ALL
                                              SELECT    'pian' ,
                                                        N'�_'
                                              UNION ALL
                                              SELECT    'piao' ,
                                                        N'�G'
                                              UNION ALL
                                              SELECT    'pie' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'pin' ,
                                                        N'Ƹ'
                                              UNION ALL
                                              SELECT    'ping' ,
                                                        N'�O'
                                              UNION ALL
                                              SELECT    'po' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'pou' ,
                                                        N'�R' --�͆R 
                                              UNION ALL
                                              SELECT    'pu' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'qi' ,
                                                        N'τ'
                                              UNION ALL
                                              SELECT    'qia' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'qian' ,
                                                        N'�y'
                                              UNION ALL
                                              SELECT    'qiang' ,
                                                        N'��' --������ 
                                              UNION ALL
                                              SELECT    'qiao' ,
                                                        N'�N'
                                              UNION ALL
                                              SELECT    'qie' ,
                                                        N'�]'
                                              UNION ALL
                                              SELECT    'qin' ,
                                                        N'�C'
                                              UNION ALL
                                              SELECT    'qing' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'qiong' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'qiu' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'qu' ,
                                                        N'�Y'
                                              UNION ALL
                                              SELECT    'quan' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'que' ,
                                                        N'�]'
                                              UNION ALL
                                              SELECT    'qun' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ran' ,
                                                        N'�L'
                                              UNION ALL
                                              SELECT    'rang' ,
                                                        N'׌'
                                              UNION ALL
                                              SELECT    'rao' ,
                                                        N'�@'
                                              UNION ALL
                                              SELECT    're' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ren' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'reng' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'ri' ,
                                                        N'�_'
                                              UNION ALL
                                              SELECT    'rong' ,
                                                        N'�\'
                                              UNION ALL
                                              SELECT    'rou' ,
                                                        N'�]'
                                              UNION ALL
                                              SELECT    'ru' ,
                                                        N'�J'
                                              UNION ALL
                                              SELECT    'ruan' ,
                                                        N'�O'
                                              UNION ALL
                                              SELECT    'rui' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'run' ,
                                                        N'��' --���� 
                                              UNION ALL
                                              SELECT    'ruo' ,
                                                        N'�U'
                                              UNION ALL
                                              SELECT    'sa' ,
                                                        N'��' --���� 
                                              UNION ALL
                                              SELECT    'sai' ,
                                                        N'̃' --��̃ 
                                              UNION ALL
                                              SELECT    'san' ,
                                                        N'�d'
                                              UNION ALL
                                              SELECT    'sang' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'sao' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'se' ,
                                                        N'�o' --�S�{ 
                                              UNION ALL
                                              SELECT    'sen' ,
                                                        N'�d'
                                              UNION ALL
                                              SELECT    'seng' ,
                                                        N'�L' --�~�L 
                                              UNION ALL
                                              SELECT    'sha' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'shai' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'shan' ,
                                                        N'�X'
                                              UNION ALL
                                              SELECT    'shang' ,
                                                        N'�y'
                                              UNION ALL
                                              SELECT    'shao' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'she' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'shen' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'sheng' ,
                                                        N'ً'
                                              UNION ALL
                                              SELECT    'shi' ,
                                                        N'��' --�|�a���� 
                                              UNION ALL
                                              SELECT    'shou' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'shu' ,
                                                        N'̠'
                                              UNION ALL
                                              SELECT    'shua' ,
                                                        N'�X'
                                              UNION ALL
                                              SELECT    'shuai' ,
                                                        N'�i'
                                              UNION ALL
                                              SELECT    'shuan' ,
                                                        N'�Y'
                                              UNION ALL
                                              SELECT    'shuang' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'shui' ,
                                                        N'˯'
                                              UNION ALL
                                              SELECT    'shun' ,
                                                        N'�B'
                                              UNION ALL
                                              SELECT    'shuo' ,
                                                        N'�p'
                                              UNION ALL
                                              SELECT    'si' ,
                                                        N'�r' --�[�A�r 
                                              UNION ALL
                                              SELECT    'song' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'sou' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'su' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'suan' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'sui' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'sun' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'suo' ,
                                                        N'�R'
                                              UNION ALL
                                              SELECT    'ta' ,
                                                        N'�k' --�c�k 
                                              UNION ALL
                                              SELECT    'tai' ,
                                                        N'�M'
                                              UNION ALL
                                              SELECT    'tan' ,
                                                        N'�y'
                                              UNION ALL
                                              SELECT    'tang' ,
                                                        N'�C'
                                              UNION ALL
                                              SELECT    'tao' ,
                                                        N'�z' --ӑ�z 
                                              UNION ALL
                                              SELECT    'te' ,
                                                        N'�c'
                                              UNION ALL
                                              SELECT    'teng' ,
                                                        N'�Y' --�L�z�Y 
                                              UNION ALL
                                              SELECT    'ti' ,
                                                        N'ڌ'
                                              UNION ALL
                                              SELECT    'tian' ,
                                                        N'�q'
                                              UNION ALL
                                              SELECT    'tiao' ,
                                                        N'�g'
                                              UNION ALL
                                              SELECT    'tie' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ting' ,
                                                        N'�h' --��h 
                                              UNION ALL
                                              SELECT    'tong' ,
                                                        N'�q'
                                              UNION ALL
                                              SELECT    'tou' ,
                                                        N'͸'
                                              UNION ALL
                                              SELECT    'tu' ,
                                                        N'�r'
                                              UNION ALL
                                              SELECT    'tuan' ,
                                                        N'щ'
                                              UNION ALL
                                              SELECT    'tui' ,
                                                        N'�D'
                                              UNION ALL
                                              SELECT    'tun' ,
                                                        N'�d'
                                              UNION ALL
                                              SELECT    'tuo' ,
                                                        N'�X'
                                              UNION ALL
                                              SELECT    'wa' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'wai' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'wan' ,
                                                        N'�@'
                                              UNION ALL
                                              SELECT    'wang' ,
                                                        N'�R'
                                              UNION ALL
                                              SELECT    'wei' ,
                                                        N'�^'
                                              UNION ALL
                                              SELECT    'wen' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'weng' ,
                                                        N'�N'
                                              UNION ALL
                                              SELECT    'wo' ,
                                                        N'�}'
                                              UNION ALL
                                              SELECT    'wu' ,
                                                        N'�F'
                                              UNION ALL
                                              SELECT    'xi' ,
                                                        N'�a'
                                              UNION ALL
                                              SELECT    'xia' ,
                                                        N'�]'
                                              UNION ALL
                                              SELECT    'xian' ,
                                                        N'�E'
                                              UNION ALL
                                              SELECT    'xiang' ,
                                                        N'�P'
                                              UNION ALL
                                              SELECT    'xiao' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'xie' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'xin' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'xing' ,
                                                        N'�B'
                                              UNION ALL
                                              SELECT    'xiong' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'xiu' ,
                                                        N'�M'
                                              UNION ALL
                                              SELECT    'xu' ,
                                                        N'ޣ'
                                              UNION ALL
                                              SELECT    'xuan' ,
                                                        N'�K'
                                              UNION ALL
                                              SELECT    'xue' ,
                                                        N'�y'
                                              UNION ALL
                                              SELECT    'xun' ,
                                                        N'�R'
                                              UNION ALL
                                              SELECT    'ya' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'yan' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'yang' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'yao' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'ye' ,
                                                        N'��' --�EČ�� 
                                              UNION ALL
                                              SELECT    'yi' ,
                                                        N'�~'
                                              UNION ALL
                                              SELECT    'yin' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'ying' ,
                                                        N'�G'
                                              UNION ALL
                                              SELECT    'yo' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'yong' ,
                                                        N'�k'
                                              UNION ALL
                                              SELECT    'you' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'yu' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'yuan' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'yue' ,
                                                        N'�V'
                                              UNION ALL
                                              SELECT    'yun' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'za' ,
                                                        N'�{'
                                              UNION ALL
                                              SELECT    'zai' ,
                                                        N'�f'
                                              UNION ALL
                                              SELECT    'zan' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'zang' ,
                                                        N'�K'
                                              UNION ALL
                                              SELECT    'zao' ,
                                                        N'�^'
                                              UNION ALL
                                              SELECT    'ze' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'zei' ,
                                                        N'�e'
                                              UNION ALL
                                              SELECT    'zen' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'zeng' ,
                                                        N'ٛ'
                                              UNION ALL
                                              SELECT    'zha' ,
                                                        N'�m'
                                              UNION ALL
                                              SELECT    'zhai' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'zhan' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'zhang' ,
                                                        N'�d'
                                              UNION ALL
                                              SELECT    'zhao' ,
                                                        N'�^'
                                              UNION ALL
                                              SELECT    'zhe' ,
                                                        N'�p'
                                              UNION ALL
                                              SELECT    'zhen' ,
                                                        N'�l'
                                              UNION ALL
                                              SELECT    'zheng' ,
                                                        N'�C'
                                              UNION ALL
                                              SELECT    'zhi' ,
                                                        N'�U'
                                              UNION ALL
                                              SELECT    'zhong' ,
                                                        N'�A'
                                              UNION ALL
                                              SELECT    'zhou' ,
                                                        N'�E'
                                              UNION ALL
                                              SELECT    'zhu' ,
                                                        N'�T'
                                              UNION ALL
                                              SELECT    'zhua' ,
                                                        N'צ'
                                              UNION ALL
                                              SELECT    'zhuai' ,
                                                        N'�J'
                                              UNION ALL
                                              SELECT    'zhuan' ,
                                                        N'�M'
                                              UNION ALL
                                              SELECT    'zhuang' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'zhui' ,
                                                        N'�V'
                                              UNION ALL
                                              SELECT    'zhun' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'zhuo' ,
                                                        N'�m'
                                              UNION ALL
                                              SELECT    'zi' ,
                                                        N'�n' --�n�� 
                                              UNION ALL
                                              SELECT    'zong' ,
                                                        N'�v'
                                              UNION ALL
                                              SELECT    'zou' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'zu' ,
                                                        N'֊'
                                              UNION ALL
                                              SELECT    'zuan' ,
                                                        N'߬'
                                              UNION ALL
                                              SELECT    'zui' ,
                                                        N'��'
                                              UNION ALL
                                              SELECT    'zun' ,
                                                        N'�'
                                              UNION ALL
                                              SELECT    'zuo' ,
                                                        N'��'
                                            ) t
                                    WHERE   word >= @word COLLATE Chinese_PRC_CS_AS_KS_WS
                                    ORDER BY word ASC
                                  )
                             ELSE @word
                        END ) 
                SET @i = @i + 1 
            END 
        RETURN @pinyin 
    END 
GO 

SELECT  dbo.test_GetPinyin('�Բۣ��������2������') 